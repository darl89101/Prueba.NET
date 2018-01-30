using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Helpers;
using Newtonsoft.Json;
using Prueba.Entities;
using Prueba.MVP.Interface;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System;
using ExceptionsTest;

namespace Prueba.MVP.Presenter
{
    public class PVehicle
    {
        /// <summary>
        /// variable que contiene las variables del config
        /// </summary>
        private NameValueCollection ConfigData = System.Configuration.ConfigurationManager.AppSettings;

        private IVehicle _iview;

        private FirebaseAuthProvider fbProvider;

        private FirebaseClient db;

        public PVehicle(IVehicle iview)
        {
            _iview = iview;
            fbProvider = new FirebaseAuthProvider(new FirebaseConfig(ConfigData.Get("FirebaseAppKey")));
        }

        public async void ListVehicles(string filter = "")
        {
            try
            {
                var data = await fbProvider.SignInWithEmailAndPasswordAsync(SessionValues.Instance.emailUser, SessionValues.Instance.Password);
                db = new FirebaseClient(
                       ConfigData.Get("FirebaseAppUri"),
                       new FirebaseOptions
                       {
                           AuthTokenAsyncFactory = () => Task.FromResult(data.FirebaseToken)
                       });
                var dbData = (await db
                    .Child("users")
                    .Child(data.User.LocalId)
                    .Child("cars")
                    //.OrderBy("name")
                    //.StartAt(filter)
                    //.OrderByKey()
                    //.StartAt(filter)                
                    .OnceAsync<Vehicle>())
                    .Select(item =>
                        new Vehicle()
                        {
                            Id = item.Key,
                            Name = item.Object.Name,
                            Price = item.Object.Price,
                            ImageUrl = item.Object.ImageUrl,
                            Transmission = item.Object.Transmission
                        }).ToList();
                if (!string.IsNullOrEmpty(filter))
                {
                    dbData = dbData.FindAll(m => m.Name.ToLower().Contains(filter.ToLower()));
                }

                _iview.Vechicles = dbData;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
            }
        }

        public async void SaveVehicle(Vehicle vehicle)
        {
            try
            {
                _iview.EnableControls(false);
                var data = await fbProvider.SignInWithEmailAndPasswordAsync(SessionValues.Instance.emailUser, SessionValues.Instance.Password);
                db = new FirebaseClient(
                       ConfigData.Get("FirebaseAppUri"),
                       new FirebaseOptions
                       {
                           AuthTokenAsyncFactory = () => Task.FromResult(data.FirebaseToken)
                       });

                if (string.IsNullOrEmpty(vehicle.Id))
                {
                    await db
                    .Child("users")
                    .Child(data.User.LocalId)
                    .Child("cars")
                    .PostAsync(vehicle);
                }
                else
                {
                    await db
                       .Child("users")
                       .Child(data.User.LocalId)
                       .Child("cars")
                       .Child(vehicle.Id)
                       .PutAsync(vehicle);
                }

                
                _iview.ShowMessage("Registro guardado exitosamente", System.Windows.Forms.MessageBoxIcon.Information);
                _iview.EnableControls(true);
                _iview.CleanControls();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                _iview.EnableControls(true);
                _iview.ShowMessage(ex.Message, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public async void DeleteVehicle(Vehicle vehicle)
        {
            try
            {
                _iview.EnableControls(false);
                var data = await fbProvider.SignInWithEmailAndPasswordAsync(SessionValues.Instance.emailUser, SessionValues.Instance.Password);
                db = new FirebaseClient(
                       ConfigData.Get("FirebaseAppUri"),
                       new FirebaseOptions
                       {
                           AuthTokenAsyncFactory = () => Task.FromResult(data.FirebaseToken)
                       });
                await db
                    .Child("users")
                    .Child(data.User.LocalId)
                    .Child("cars")
                    .Child(vehicle.Id)
                    .DeleteAsync();
                _iview.ShowMessage("Registro guardado exitosamente", System.Windows.Forms.MessageBoxIcon.Information);
                _iview.EnableControls(true);
                _iview.CleanControls();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                _iview.EnableControls(true);
                _iview.ShowMessage(ex.Message, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
