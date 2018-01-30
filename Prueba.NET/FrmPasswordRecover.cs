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
    public partial class FrmPasswordRecover : Form, ILogin
    {
        private PLogin _presenter;

        public string Email { get { return TxtEmail.Text; } internal set { TxtEmail.Text = value; } }

        public FrmPasswordRecover()
        {
            InitializeComponent();
            _presenter = new PLogin(this);
        }

        public void ShowMessage(string message, MessageBoxIcon type)
        {
            MessageBox.Show(this, message, "Prueba.NET", MessageBoxButtons.OK, type);
        }

        private void FrmPasswordRecover_Load(object sender, EventArgs e)
        {

        }

        private void FrmPasswordRecover_Shown(object sender, EventArgs e)
        {
            TxtEmail.Focus();
        }

        private async void TxtSendMail_Click(object sender, EventArgs e)
        {
            await _presenter.PasswordRecover(TxtEmail.Text.Trim());
        }

        private void FrmPasswordRecover_FormClosing(object sender, FormClosingEventArgs e)
        {
            _presenter.Dispose();
        }
    }
}
