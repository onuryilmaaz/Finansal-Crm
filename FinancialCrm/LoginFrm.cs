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
	public partial class LoginFrm : Form
	{
		public LoginFrm()
		{
			InitializeComponent();
		}
		FinancialCrmDbEntities db = new FinancialCrmDbEntities();

		private void btnLogin_Click(object sender, EventArgs e)
		{
			string username = txtUsername.Text;
			string password = txtPassword.Text;

			var user = db.Users.FirstOrDefault(x=>x.Username == username && x.Password == password);

			if (user != null)
			{
				MessageBox.Show("Giriş Başarılı!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FrmDashboard frmDashboard = new FrmDashboard();
				frmDashboard.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show("Giriş Başarısız!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
