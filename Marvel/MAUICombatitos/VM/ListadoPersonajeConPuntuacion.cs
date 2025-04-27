using BL;
using DTO;

namespace MAUICombatitos.VM
{
    public class ListadoPersonajeConPuntuacion
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
        #endregion
    }
}
