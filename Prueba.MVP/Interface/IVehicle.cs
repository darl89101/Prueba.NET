using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Prueba.Entities;
using System.Windows.Forms;

namespace Prueba.MVP.Interface
{
    public interface IVehicle
    {
        List<Vehicle> Vechicles { get; set; }
        void CleanControls();
        void ShowMessage(string message, MessageBoxIcon type);
        void EnableControls(bool value);
    }
}
