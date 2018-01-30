using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class SessionValues
    {
        private static SessionValues _instance;

        public static SessionValues Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SessionValues();
                return _instance;
            }
        }
        
        public string emailUser { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
