using ExceptionsTest;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Helpers;
using Prueba.MVP.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.MVP.Presenter
{
    public class PLogin : IDisposable
    {
        /// <summary>
        /// variable que contiene las variables del config
        /// </summary>
        private NameValueCollection ConfigData = System.Configuration.ConfigurationManager.AppSettings;

        /// <summary>
        /// Interfaz con la vista
        /// </summary>
        private ILogin _iview;
        
        private FirebaseAuthProvider fbProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="PLogin"/> class.
        /// </summary>
        /// <param name="iview">The iview.</param>
        public PLogin(ILogin iview)
        {
            this._iview = iview;
            // Convert the access token to firebase token
            fbProvider = new FirebaseAuthProvider(new FirebaseConfig(ConfigData.Get("FirebaseAppKey")));
        }

        /// <summary>
        /// Ejecuta el proceso de autenticacion
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        public async Task<bool> Login(string email, string password)
        {
            try
            {
                if (!Helpers.Utils.emailIsValid(email))
                {
                    _iview.ShowMessage("El email ingresado no corresponde a un formato de correo correcto.", System.Windows.Forms.MessageBoxIcon.Warning);
                    return false;
                }
                var result = await fbProvider.SignInWithEmailAndPasswordAsync(email, password);
                SessionValues.Instance.emailUser = email;
                SessionValues.Instance.Password = password;
                SessionValues.Instance.UserName = result.User.DisplayName;
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
                this._iview.ShowMessage(ex.Message, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<bool> PasswordRecover(string email)
        {
            try
            {
                if (!Helpers.Utils.emailIsValid(email))
                {
                    _iview.ShowMessage("El email ingresado no corresponde a un formato de correo correcto.", System.Windows.Forms.MessageBoxIcon.Warning);
                    return false;
                }
                await fbProvider.SendPasswordResetEmailAsync(email);
                this._iview.ShowMessage($"Se ha enviado un mensaje de recuperación al correo ({email})", System.Windows.Forms.MessageBoxIcon.Information);
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