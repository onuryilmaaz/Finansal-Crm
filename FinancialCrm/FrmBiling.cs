using System;
using System.Collections.Generic;
using FinancialCrm.Models;
using System.Windows.Forms;
using System.Linq;

namespace FinancialCrm
{
	public partial class FrmBiling : Form
	{
		public FrmBiling()
		{
			InitializeComponent();
		}

		FinancialCrmDbEntities db = new FinancialCrmDbEntities();

		public void GetAllBill()
		{
			var values = db.Bills.ToList();
			dataGridView1.DataSource = values;
		}

		private void FrmBiling_Load(object sender, EventArgs e)
		{
			GetAllBill();
		}

		private void btnBillList_Click(object sender, EventArgs e)
		{
			GetAllBill();
		}

		private void btnCreateBill_Click(object sender, EventArgs e)
		{
			string title = txtBillTitle.Text;
			decimal amount = decimal.Parse(txtBillAmount.Text);
			string period = txtBillPeriod.Text;

			Bills bills = new Bills();
			bills.BİllTitle = title;
			bills.BillAmount = amount;
			bills.BillPeriod = period;
			db.Bills.Add(bills);
			db.SaveChanges();
			MessageBox.Show("Ödeme Başarılı Bir Şekilde Sisteme Eklendi.","Ödemeler & Faturalar",MessageBoxButtons.OK,MessageBoxIcon.Information);
			GetAllBill();
		}

		private void btnRemoveBill_Click(object sender, EventArgs e)
		{
			int id = int.Parse(txtBillId.Text);
			var removeValue = db.Bills.Find(id);
			db.Bills.Remove(removeValue);
			db.SaveChanges();
			MessageBox.Show("Ödeme Başarılı Bir Şekilde Sistemden Silindi.", "Ödemeler & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
			GetAllBill();
		}

		private void btnUpdateBill_Click(object sender, EventArgs e)
		{
			int id = int.Parse(txtBillId.Text);
			string title = txtBillTitle.Text;
			decimal amount = decimal.Parse(txtBillAmount.Text);
			string period = txtBillPeriod.Text;

			var updatedValue = db.Bills.Find(id);


			updatedValue.BİllTitle = title;
			updatedValue.BillAmount = amount;
			updatedValue.BillPeriod = period;
			db.SaveChanges();
			MessageBox.Show("Ödeme Başarılı Bir Şekilde Güncellendi.", "Ödemeler & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
			GetAllBill();
		}

		private void btnBanksForm_Click(object sender, EventArgs e)
		{
			FrmBanks frmBanks = new FrmBanks();
			frmBanks.Show();
			this.Hide();
		}

		private void btnDashboardForm_Click(object sender, EventArgs e)
		{
			FrmDashboard frmDashboard = new FrmDashboard();
			frmDashboard.Show();
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
