using FinancialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
	public partial class FrmBanks : Form
	{
		public FrmBanks()
		{
			InitializeComponent();
		}

		FinancialCrmDbEntities db = new FinancialCrmDbEntities();

		private void FrmBanks_Load(object sender, EventArgs e)
		{

			//Banka bakiyelerini getirme
			var ziraatBankBalance = db.Banks.Where(x=>x.BankTitle== "Ziraat Bankası").Select(y=>y.BankBalance).FirstOrDefault();
			var vakifBankBalance = db.Banks.Where(x => x.BankTitle == "Vakıfbank").Select(y => y.BankBalance).FirstOrDefault();
			var isBankBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();

			lblZiraatBankBalance.Text = ziraatBankBalance.ToString() + " ₺";
			lblVakifbankBalance.Text = vakifBankBalance.ToString() + " ₺";
			lblIsBanksiBalance.Text = isBankBalance.ToString() + " ₺";

			//Banka hareketlerini getirme
			var bankProcess1= db.BankProcesses.OrderByDescending(x => x.ProcessDate).Take(1).FirstOrDefault();
			lblBankProcess1.Text = $"{bankProcess1.Description} {" - "} {bankProcess1.Amount} {"₺ - "}{bankProcess1.ProcessDate:dd MMMM yyyy}";
			var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Skip(1).Take(1).FirstOrDefault();
			lblBankProcess2.Text = $"{bankProcess2.Description} {" - "} {bankProcess2.Amount} {"₺ - "}{bankProcess2.ProcessDate:dd MMMM yyyy}";
			var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Skip(2).Take(1).FirstOrDefault();
			lblBankProcess3.Text = $"{bankProcess3.Description} {" - "} {bankProcess3.Amount} {"₺ - "}{bankProcess3.ProcessDate:dd MMMM yyyy}";
			var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Skip(3).Take(1).FirstOrDefault();
			lblBankProcess4.Text = $"{bankProcess4.Description} {" - "} {bankProcess4.Amount} {"₺ - "}{bankProcess4.ProcessDate:dd MMMM yyyy}";
			var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Skip(4).Take(1).FirstOrDefault();
			lblBankProcess5.Text = $"{bankProcess5.Description} {" - "} {bankProcess5.Amount} {"₺ - "}{bankProcess5.ProcessDate:dd MMMM yyyy}";



		}

		private void btnBillForms_Click(object sender, EventArgs e)
		{
			FrmBiling frmBiling = new FrmBiling();
			frmBiling.Show();
			this.Hide();
		}
	}
}
