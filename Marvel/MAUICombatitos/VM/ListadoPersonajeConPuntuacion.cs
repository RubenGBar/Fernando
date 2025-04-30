using BL;
using DTO;
using System.ComponentModel;

namespace MAUICombatitos.VM
{
    public class ListadoPersonajeConPuntuacion : INotifyPropertyChanged
    {
        #region Propiedades
        public List<PersonajeConPuntuacionTotal> ListadoPersonajesConPuntuacion { get; set; }
        #endregion

        #region Constructores
        public ListadoPersonajeConPuntuacion()
        {
            try
            {
                ListadoPersonajesConPuntuacion = ManejadoraBL.obtenerListadoPersonajesConPuntuacionTotalBL();
            }
            catch (Exception ex)
            {
                MuestraMensaje("Error", "Hubo un error inesperado", "Aceptar");
            }
        }

        #endregion

        #region Funciones
        /// <summary>
        /// Esta función muestra un mensaje en la pantalla
        /// </summary>
        /// <param name="mensajeTitulo"> Mensaje de la cabecera </param>
        /// <param name="mensajeCuerpo"> Mensaje del cuerpo </param>
        /// <param name="mensajeBoton"> Mensaje del botón </param>
        public async void MuestraMensaje(string mensajeTitulo, string mensajeCuerpo, string mensajeBoton)
        {
            await Shell.Current.DisplayAlert(mensajeTitulo, mensajeCuerpo, mensajeBoton);
        }

        public async void recargarLista()
        {
            try
            {
                ListadoPersonajesConPuntuacion = ManejadoraBL.obtenerListadoPersonajesConPuntuacionTotalBL();
                OnPropertyChanged(nameof(ListadoPersonajesConPuntuacion));
            }
            catch (Exception ex)
            {
                MuestraMensaje("Error", "Hubo un error inesperado al conectar con la BD, intentelo más tarde", "Aceptar");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
