using Prueba.MVP.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers;
using Prueba.MVP.Presenter;

namespace Prueba
{
    public partial class Login : Form, ILogin
    {
        #region Builder
        public Login()
        {
            InitializeComponent();
            _presenter = new PLogin(this);
        }
        #endregion

        #region Properties
        private PLogin _presenter;
        #endregion

        #region Handlers
        public void ShowMessage(string message, MessageBoxIcon type)
        {
            MessageBox.Show(this, message, "Prueba.NET", MessageBoxButtons.OK, type);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        
        private void Login_Shown(object sender, EventArgs e)
        {
            TxtMail.Focus();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            if (await _presenter.Login(TxtMail.Text.Trim(), TxtPassword.Text.Trim()))
            {
                this.Visible = false;
                using (MDI mdi = new MDI())
                {
                    mdi.ShowDialog(this);
                    this.Close();
                }
                //using (FrmVehicles mdi = new FrmVehicles())
                //{
                //    mdi.ShowDialog(this);
                //    this.Close();
                //}
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            _presenter.Dispose();
        }

        private void LblRecoverPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FrmPasswordRecover psw = new FrmPasswordRecover())
            {
                psw.Email = TxtMail.Text.Trim();
                psw.ShowDialog(this);
            }
        }
        #endregion        
    }
}
