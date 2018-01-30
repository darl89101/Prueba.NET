using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba.MVP.Interface
{
    public interface IUser
    {
        void ShowMessage(string message, MessageBoxIcon type);
        void CleanControls();
        void EnableControls(bool value);
    }
}
