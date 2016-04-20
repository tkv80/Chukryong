using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Chukryong.Entity;
using Chukryong.Manager;

namespace Chukryong.Worker

{
    class Worker : BackgroundWorker
    {
        public Worker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        public int Interval { private get; set; }
        public List<Reservation > Reservations { private get; set; }
        
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            string message = "";
            while (!CancellationPending)
            {

                foreach (var reservation in Reservations)
                {
                    var checkreservation= HttpManager.GetCheckInFacility(reservation.Site.FacilityCode, reservation.Site.SiteCode, reservation.StartDate);

                    if (checkreservation.Item1)
                    {
                        new GcmManager().SendNotification("축령산 날짜찾기 성공", reservation.StartDate.ToString("yyyy-MM-dd"));

                        #region 예약

                        try
                        {
                            //return;
                            var sUrl =
                                "https://chukryong.gg.go.kr:456/new2006/appointment/reserve_write.asp?res_hu=A&res_si={0}&fdate=0";
                            sUrl = string.Format(sUrl, reservation.Site.SiteCode);
                            var telSplit = reservation.Client.Tel.Split('-');
                            var parameter =
                                string.Format(
                                    "res_name={0}&tel_1={1}&tel_2={2}&tel_3={3}&res_mail={4}&res_add={5}&res_qty={10}&res_bank={8}&res_bankno={9}&res_bankname={0}&res_children=&money_chk=money&s_date={6}&e_date={7}&edd=0&t_money={11}",
                                    HttpUtility.UrlEncode(reservation.Client.Name, Encoding.GetEncoding("euc-kr")),
                                    telSplit[0],
                                    telSplit[1],
                                    telSplit[2],
                                    reservation.Client.Mail,
                                    HttpUtility.UrlEncode(reservation.Client.Address, Encoding.GetEncoding("euc-kr")),
                                    reservation.StartDate.ToString("yyyy-MM-dd"),
                                    reservation.EndDate.ToString("yyyy-MM-dd"),
                                    reservation.Client.BankName,
                                    reservation.Client.BankNumber,
                                    reservation.UserCount,
                                    reservation.Cost);


                            var httpWRequest = (HttpWebRequest) WebRequest.Create(sUrl);
                            httpWRequest.Accept = "text/html, application/xhtml+xml";
                            httpWRequest.Referer =
                                string.Format(
                                    @"https://chukryong.gg.go.kr:456/new2006/appointment/reserve_rsv.asp?res_hu=A&res_si={0}&st_date={1}&ed_date={2}&su_date=0&su_qty={3}",
                                    reservation.Site.SiteCode,
                                    reservation.StartDate.ToString("yyyy-MM-dd"),
                                    reservation.EndDate.ToString("yyyy-MM-dd"),
                                    reservation.UserCount);
                            httpWRequest.UserAgent =
                                "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
                            httpWRequest.Headers.Add("Accept-Language", "ko-KR");
                            httpWRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                            httpWRequest.Host = "chukryong.gg.go.kr:456";
                            httpWRequest.ContentType = "application/x-www-form-urlencoded";
                            httpWRequest.KeepAlive = true;
                            httpWRequest.Method = "Post";
                            httpWRequest.ContentLength = parameter.Length;
                            httpWRequest.CookieContainer = new CookieContainer();
                            httpWRequest.CookieContainer.Add(new Cookie("__utma",
                                "206204609.1877502704.1378257147.1378257147.1378257148.2", "/", "chukryong.gg.go.kr"));
                            httpWRequest.CookieContainer.Add(new Cookie("__utmb", "206204609.45.10.1378257148", "/",
                                "chukryong.gg.go.kr"));
                            httpWRequest.CookieContainer.Add(new Cookie("__utmz",
                                "06204609.1378257148.2.2.utmcsr=naver|utmccn=(organic)|utmcmd=organic|utmctr=%EC%B6%95%EB%A0%B9%EC%82%B0%EC%9E%90%EC%97%B0%ED%9C%B4%EC%96%91%EB%A6%BC",
                                "/", "chukryong.gg.go.kr"));
                            httpWRequest.CookieContainer.Add(new Cookie("ASPSESSIONIDQAQTDRRQ",
                                "LLNMHHBCJNPNGFELHMAHHJBF", "/",
                                "chukryong.gg.go.kr"));
                            httpWRequest.CookieContainer.Add(new Cookie("__utmc", "206204609", "/", "chukryong.gg.go.kr"));

                            var sw = new StreamWriter(httpWRequest.GetRequestStream());
                            sw.Write(parameter);
                            sw.Close();

                            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
                            var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

                            string data = sr.ReadToEnd();

                            if (data.Contains("예약이 완료되었습니다."))
                            {
                                message = string.Format("{0} - 예약완료~ {1}일 {2}사이트\r\n",
                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                    reservation.StartDate.ToString("yyyy-MM-dd"),
                                    reservation.Site.SiteName);

                                new GcmManager().SendNotification(message, "캠핑예약");
                                CancelAsync();
                            }
                            else
                            {
                                message = string.Format("{0} - 예약실패\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                //txtLog.AppendText(log);
                            }
                        }
                        catch (WebException webExcp)
                        {
                            var sr = new StreamReader(webExcp.Response.GetResponseStream(),
                                Encoding.GetEncoding("euc-kr"));

                            message = sr.ReadToEnd();
                        }
                        catch (Exception ex) // get any other error
                        {
                            message = (ex.Message);
                        }

                        #endregion
                    }
                    else
                    {
                        message = "실패 " + reservation.StartDate +" " + reservation.Site.Facility;
                    }

                    ReportProgress(0, message);

                    Thread.Sleep(100*Interval);
                }
            }
        }
    }
}
