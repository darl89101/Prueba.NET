using Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            string tag = ((ToolStripMenuItem)sender).Tag.ToString();            
            Form frm = (Form)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(m => m.Name.Equals(tag)));

            frm.MdiParent = this;
            frm.Show();
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            LblNombreUsuario.Text = SessionValues.Instance.UserName;
        }
    }
}
