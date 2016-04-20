using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Chukryong.Entity;

namespace Chukryong.Manager
{
    internal static class HttpManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Tuple<bool, string> GetCheckInFacility(int facilityCode, string siteCode,  DateTime date)
        {
            var result = new Tuple<bool, string>(false, null);

            try
            {
                
                var httpWRequest =
                    (HttpWebRequest)
                        WebRequest.Create("https://chukryong.gg.go.kr:456/new2006/appointment/reserve_list.asp");
                var parameter = string.Format("gu={0}&edd=0&syyyy={1}&smm={2}&sdd={3}&title=A", facilityCode, date.Year, date.Month, date.Day);

                httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
                httpWRequest.ContentType = "application/x-www-form-urlencoded";

                httpWRequest.Method = "POST";
                httpWRequest.CookieContainer = new CookieContainer();

                ServicePointManager.ServerCertificateValidationCallback += ValidateServerCertificate;
                var sw = new StreamWriter(httpWRequest.GetRequestStream(), Encoding.GetEncoding("euc-kr"));
                sw.Write(parameter);
                sw.Close();

                var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
                var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

                string resultHtml = sr.ReadToEnd();
                if (!resultHtml.Contains("모든 시설예약이 종료되었습니다. "))
                {
                    if (resultHtml.Contains("<tr bgcolor=\"#FFFFFF\">"))
                    {
                        resultHtml = resultHtml.Substring("<tr bgcolor=\"#FFFFFF\">", "</tr>");

                        if (resultHtml.Contains("reserve_rsv.asp?res_hu=A"))
                        {
                            resultHtml = resultHtml.Substring("<a href=\"", "\" onFocus=");

                            if (resultHtml.Contains("res_si=" + siteCode))
                            {
                                result = new Tuple<bool, string>(true, resultHtml);    
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Util.ErrorLog(MethodBase.GetCurrentMethod(), ex, "에러");
            }
            return result;
        }
        // <summary>
        /// 
        /// 
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns></returns>
        private static bool ValidateServerCertificate(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SiteEntity> GetSite(string url, DateTime date)
        {

            IList<SiteEntity> sites = new List<SiteEntity>();
            var httpWRequest =
                (HttpWebRequest)
                    WebRequest.Create(string.Format("{0}?f_year={1}&f_month={2}&fac_hcode=A", url, date.Year, date.Month));
            httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";

            httpWRequest.Method = "Get";
            ServicePointManager.ServerCertificateValidationCallback += ValidateServerCertificate;

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

            string resultHtml = sr.ReadToEnd();

            int startIndex = 0;
            string startText = "<td width=\"688\" bgcolor=\"#fafafa\" align=\"center\">";
            string endText = "</td>";

            while (true)
            {
                try
                {
                    startIndex = resultHtml.IndexOf(startText, startIndex + 1);
                    if (startIndex == -1)
                    {
                        break;
                    }
                    string resultText =
                        resultHtml.Substring(startIndex + startText.Length,
                            resultHtml.IndexOf(endText, startIndex) - startIndex - startText.Length)
                            .Trim();

                    sites.Add(new SiteEntity {SiteName = resultText});
                }
                catch (Exception ex)
                {
                }
            }

            return sites;
        }
    }
}