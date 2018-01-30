using Prueba.MVP.Interface;
using Prueba.MVP.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba
{
    public partial class FrmUser : Form, IUser
    {
        #region Builder
        public FrmUser()
        {
            InitializeComponent();            
            _presenter = new PUser(this);
        }
        #endregion

        #region Properties
        private PUser _presenter;
        #endregion

        #region Handlers
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            _presenter.Dispose();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            await _presenter.CreateNewUser(TxtEmail.Text.Trim()
                , TxtPassword.Text.Trim()
                , TxtName.Text.Trim());
        }

        private void FrmUser_Shown(object sender, EventArgs e)
        {
            TxtEmail.Focus();
        }

        private void ChkView_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkView.Checked)
                TxtPassword.PasswordChar = new char();
            else
                TxtPassword.PasswordChar = '*';
        }
        #endregion

        #region IUser
        public void ShowMessage(string message, MessageBoxIcon type)
        {
            MessageBox.Show(this, message, "Prueba.NET", MessageBoxButtons.OK, type);
        }

        public void CleanControls()
        {
            TxtEmail.Text = string.Empty;
            TxtPassword.Text = string.Empty;
            TxtName.Text = string.Empty;
            TxtEmail.Focus();
        }

        public void EnableControls(bool value)
        {
            TxtEmail.Enabled = value;
            TxtName.Enabled = value;
            TxtPassword.Enabled = value;
        }
        #endregion        
    }
}
