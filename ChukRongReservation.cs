// *
// * @author  모바일 기술팀 KTG
// * @date    2013년 9월 5일 목요일 오전 10:11:39
// *

using System;
using System.Linq;
using System.Windows.Forms;
using Chukryong.Entity;
using Chukryong.Manager;

namespace Chukryong
{
    public partial class ChukRongReservation : Form
    {
        readonly Worker.Worker _worker = new Worker.Worker();

        public ChukRongReservation()
        {
            InitializeComponent();

            cbSite.DataSource = new SiteEntityManager().Sites(ReservationType.축령산자연휴양림);
            cbSite.DisplayMember = "SiteName";
            cbSite.ValueMember = "SiteCode";

            cbFacility.Items.Add(new Tuple<string, string>("숲속의집", "https://chukryong.gg.go.kr:456/new2006/appointment/reserve_list_check.asp"));
            cbFacility.Items.Add(new Tuple<string, string>("산림휴양관", "https://chukryong.gg.go.kr:456/new2006/appointment/reserve_list_check_h.asp"));
            cbFacility.Items.Add(new Tuple<string, string>("야영데크", "https://chukryong.gg.go.kr:456/new2006/appointment/reserve_list_check_c.asp"));
            cbFacility.DisplayMember = "item1";
            cbFacility.ValueMember = "item2";

            cbStay.Items.Add("1박2일");
            cbStay.Items.Add("2박3일");
            cbStay.Items.Add("3박4일");
            cbStay.SelectedIndex = 0;

            _worker.ProgressChanged += worker_ProgressChanged;
            _worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void cbFacility_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sites= HttpManager.GetSite(((Tuple<string, string>)cbFacility.SelectedItem).Item2, dateTimePicker1.Value);
            cbSite.DataSource = sites;
            cbSite.DisplayMember = "SiteName";
            cbSite.ValueMember = "SiteCode";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var reservationString = string.Format("{0} | {1} {2}",
                ((SiteEntity)cbSite.SelectedItem).SiteName,
                dateTimePicker1.Value.ToString("yyyy/MM/dd"),
                cbStay.SelectedText);
            lbReservation.Items.Add(
                new Tuple<string, Reservation>(
                    reservationString,
                    new Reservation()
                    {
                        Client = new ClientInfo()
                        {
                            Name = txtName.Text,
                            Address = txtAddress.Text,
                            BankName = txtBankName.Text,
                            BankNumber = txtAccountNumber.Text,
                            Mail = txtMail.Text,
                            Tel = txtTel1.Text
                        },
                        Cost = 6000,
                        StartDate = dateTimePicker1.Value,
                        EndDate = dateTimePicker1.Value.AddDays(cbStay.SelectedIndex +1),
                        Site = (SiteEntity)cbSite.SelectedItem
                    }
                    ));
            lbReservation.DisplayMember = "Item1";
            lbReservation.ValueMember = "Item2";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lbReservation.Items.RemoveAt(lbReservation.SelectedIndex);
        }

        private void btnStartReservation_Click(object sender, EventArgs e)
        {
            if (btnStartReservation.Text == "예약시작")
            {
                
                _worker.Interval = (int)numInterval.Value;
                _worker.Reservations =
                    (from object item in lbReservation.Items select ((Tuple<string, Reservation>)item).Item2).ToList();
                _worker.RunWorkerAsync();

                btnStartReservation.Text = "예약중지";
            }
            else
            {
                _worker.CancelAsync();
            }
        }

        #region worker

        private void worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (txtLog.Lines.Length <= 10)
            {
                Util.Logging(txtLog, e.UserState.ToString());
            }
            else
            {
                txtLog.Clear();
                Util.Logging(txtLog, e.UserState.ToString());
            }
        }

        private void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Util.Logging(txtLog, "완료~!!");
            btnStartReservation.Enabled = true;
            btnStartReservation.Text = @"예약시작";
        }

        #endregion
    }
}