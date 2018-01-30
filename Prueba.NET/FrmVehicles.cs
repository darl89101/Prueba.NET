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
using Prueba.Entities;
using Prueba.MVP.Presenter;
using System.Threading;
using System.Net;

namespace Prueba
{
    public partial class FrmVehicles : Form, IVehicle
    {
        #region Builder
        public FrmVehicles()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            _presenter = new PVehicle(this);
        }
        #endregion

        private PVehicle _presenter;
        public List<Vehicle> Vechicles
        {
            get
            {
                return (List<Vehicle>)dataGridView1.DataSource;
            }
            set
            {
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(item.ImageUrl);
                        myRequest.Method = "GET";
                        HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                        myResponse.Close();


                        item.Image = bmp;
                    }
                }


                dataGridView1.DataSource = value;
                dataGridView1.Refresh();
            }
        }

        #region Handlers
        private void FrmVehicles_Load(object sender, EventArgs e)
        {
            _presenter.ListVehicles();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("ColImage")
            //    && dataGridView1.Rows[e.RowIndex].Cells["ColUrl"].Value != null)
            //{
            //    string uri = dataGridView1.Rows[e.RowIndex].Cells["ColUrl"].Value.ToString();
            //    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(uri);
            //    myRequest.Method = "GET";
            //    HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            //    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
            //    myResponse.Close();
            //    e.Value = bmp;
            //}
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            _presenter.ListVehicles(TxtFilter.Text.Trim());
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            using (FrmNewVehicle nv = new FrmNewVehicle())
            {
                nv.ShowDialog(this);
            }
        }

        public void CleanControls()
        {

        }

        public void ShowMessage(string message, MessageBoxIcon type)
        {
            MessageBox.Show(this, message, "Prueba.NET", MessageBoxButtons.OK, type);
        }

        public void EnableControls(bool value)
        {

        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (e.ColumnIndex == 5)
            {
                using (FrmNewVehicle nv = new FrmNewVehicle())
                {
                    nv.EditItem = (Vehicle)dgv.CurrentRow.DataBoundItem;
                    nv.ShowDialog(this);
                }
            }
            else if (e.ColumnIndex == 6)
            {
                if (MessageBox.Show(this, "¿Esta seguro que desea eliminar el registro?", "Prueba.NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _presenter.DeleteVehicle((Vehicle)dgv.CurrentRow.DataBoundItem);
                }
            }
        }
    }
}
