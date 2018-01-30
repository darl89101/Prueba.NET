using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba.MVP.Interface
{
    public interface ILogin
    {
        void ShowMessage(string message, MessageBoxIcon type);
    }
}
