using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
	public partial class FrmDashboard : Form
	{
		public FrmDashboard()
		{
			InitializeComponent();
		}
		FinancialCrmDbEntities db = new FinancialCrmDbEntities();
		int count = 0;

		private void FrmDashboard_Load(object sender, EventArgs e)
		{
			var totalBalance = db.Banks.Sum(x => x.BankBalance);
			lblTotalBalance.Text = totalBalance.ToString() + "  ₺";

			var lastBankProcess = db.BankProcesses.OrderByDescending(x=>x.BankProcessId).Take(1).Select(y=>y.Amount).FirstOrDefault();
			lblLastBankProcess.Text = lastBankProcess.ToString();


			//Chart1 
			var bankData = db.Banks.Select(x=> new
			{
				x.BankTitle,
				x.BankBalance
			}).ToList();
			chart1.Series.Clear();
			var series = chart1.Series.Add("Bankalar");
			foreach(var item in bankData)
			{
				series.Points.AddXY(item.BankTitle, item.BankBalance);
			}

			//Chart2
			var billData = db.Bills.Select(x => new
			{
				x.BİllTitle,
				x.BillAmount
			}).ToList();
			chart2.Series.Clear();
			var series2 = chart2.Series.Add("Faturalar");
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
			foreach (var item in billData)
			{
				series2.Points.AddXY(item.BİllTitle, item.BillAmount);
			}

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			count++;
			if (count % 4 == 0)
			{
				var internetFaturasi = db.Bills.Where(x => x.BİllTitle == "İnternet Faturası").Select(y => y.BillAmount).FirstOrDefault();
				lblBillTitle.Text = "İnternet Faturası";
				lblBillAmount.Text = internetFaturasi.ToString() + "  ₺";
			}
			if (count % 4 == 1)
			{
				var elektrikFaturasi = db.Bills.Where(x=>x.BİllTitle == "Elektrik Faturası").Select(y=>y.BillAmount).FirstOrDefault();
				lblBillTitle.Text = "Elektrik Faturası";
				lblBillAmount.Text= elektrikFaturasi.ToString() + "  ₺";
			}
			if (count % 4 == 2)
			{
				var dogalgazFaturasi = db.Bills.Where(x => x.BİllTitle == "Doğalgaz Faturası").Select(y => y.BillAmount).FirstOrDefault();
				lblBillTitle.Text = "Doğalgaz Faturası";
				lblBillAmount.Text = dogalgazFaturasi.ToString() + "  ₺";
			}
			if (count % 4 == 3)
			{
				var suFaturasi = db.Bills.Where(x => x.BİllTitle == "Su Faturası").Select(y => y.BillAmount).FirstOrDefault();
				lblBillTitle.Text = "Su Faturası";
				lblBillAmount.Text = suFaturasi.ToString() + "  ₺";
			}
		}

		private void btnBillForms_Click(object sender, EventArgs e)
		{
			FrmBiling frmBiling = new FrmBiling();
			frmBiling.Show();
			this.Hide();
		}

		private void btnBanksForm_Click(object sender, EventArgs e)
		{
			FrmBanks frmBanks = new FrmBanks();
			frmBanks.Show();
			this.Hide();
		}

		private void btnLogOut_Click(object sender, EventArgs e)
		{
			LoginFrm loginFrm = new LoginFrm();
			loginFrm.Show();
			this.Hide();
		}
	}
}
