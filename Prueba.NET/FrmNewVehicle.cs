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
using Prueba.Entities;

namespace Prueba
{
    public partial class FrmNewVehicle : Form, IVehicle
    {
        private PVehicle _presenter;

        public List<Vehicle> Vechicles
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

        private Vehicle _editVechicle;
        public Vehicle EditItem
        {
            set
            {
                _editVechicle = value;
                TxtName.Text = value.Name;
                TxtPrice.Text = value.Price.ToString();
                TxtTransmission.Text = value.Transmission;
                this.Text = "Editar Vehiculo";
            }
        }

        public FrmNewVehicle()
        {
            InitializeComponent();
            _presenter = new PVehicle(this);
        }

        private void FrmNewVehicle_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_editVechicle != null)
                _presenter.SaveVehicle(_editVechicle);
            else
                _presenter.SaveVehicle(new Vehicle()
                {
                    Name = TxtName.Text,
                    Transmission = TxtTransmission.Text,
                    Price = Convert.ToDouble(TxtPrice.Text)
                });
        }

        public void CleanControls()
        {
            TxtName.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            TxtTransmission.Text = string.Empty;
            TxtName.Focus();
        }

        public void ShowMessage(string message, MessageBoxIcon type)
        {
            MessageBox.Show(this, message, "Prueba.NET", MessageBoxButtons.OK, type);
        }

        public void EnableControls(bool value)
        {
            TxtName.Enabled = value;
            TxtPrice.Enabled = value;
            TxtTransmission.Enabled = value;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            CleanControls();
        }
    }
}
