using ExceptionsTest;
using Firebase.Auth;
using Prueba.MVP.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.MVP.Presenter
{
    public class PUser
    {
        /// <summary>
        /// variable que contiene las variables del config
        /// </summary>
        private NameValueCollection ConfigData = System.Configuration.ConfigurationManager.AppSettings;
        private IUser _iview;
        private FirebaseAuthProvider fbProvider;

        public PUser(IUser iview)
        {
            this._iview = iview;
            fbProvider = new FirebaseAuthProvider(new FirebaseConfig(ConfigData.Get("FirebaseAppKey")));
        }

        public async Task<bool> CreateNewUser(string email, string password, string displayName)
        {
            try
            {
                if (!Helpers.Utils.emailIsValid(email))
                {
                    _iview.ShowMessage("El email ingresado no corresponde a un formato de correo correcto.", System.Windows.Forms.MessageBoxIcon.Warning);
                    return false;
                }
                _iview.EnableControls(false);
                await fbProvider.CreateUserWithEmailAndPasswordAsync(email, password, displayName);               
                this._iview.CleanControls();
                this._iview.ShowMessage("¡Usuario creado correctamente!", System.Windows.Forms.MessageBoxIcon.Information);
                return true;
            }
            catch (FirebaseAuthException ex)
            {
                ExceptionManager.HandleException(ex);
                this._iview.ShowMessage(ex.InnerException.Message, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                this._iview.ShowMessage(ex.InnerException.Message, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                _iview.EnableControls(true);
            }
        }

        #region IDisposable Support        
        /// <summary>
        /// Realiza tareas definidas por la aplicación asociadas a la liberación o al restablecimiento de recursos no administrados.
        /// </summary>
        public void Dispose()
        {
            fbProvider.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
