using ENT;
using BL;
using MAUI.ViewsModels.Utils;

namespace MAUICombatitos.VM
{
    public class CombateConListadoHeroes
    {
        #region Atributos
        private Personaje combatiente1;
        private Personaje combatiente2;
        private int puntuacionCombatiente1;
        private int puntuacionCombatiente2;
        #endregion

        #region Propiedades
        public Personaje Combatiente1
        {
            get { return combatiente1; }
            set 
            { 
                combatiente1 = value;
                BotonGuardar.RaiseCanExecuteChanged();
            }
        }
        public Personaje Combatiente2
        {
            get { return combatiente2; }
            set 
            { 
                combatiente2 = value;
                BotonGuardar.RaiseCanExecuteChanged();
            }
        }
        public List<Personaje> ListadoPersonajes { get; }
        public int PuntuacionMaxima { get; }
        public int PuntuacionCombatiente1 
        {
            get { return puntuacionCombatiente1; }
            set
            {
                puntuacionCombatiente1 = value;
                BotonGuardar.RaiseCanExecuteChanged();
            }
        }
        public int PuntuacionCombatiente2
        {
            get { return puntuacionCombatiente2; }
            set
            {
                puntuacionCombatiente2 = value;
                BotonGuardar.RaiseCanExecuteChanged();
            }
        }
        public DelegateCommand BotonGuardar { get; }
        #endregion

        #region Constructores
        public CombateConListadoHeroes()
        {
            try
            {
                ListadoPersonajes = ListadosBL.obtenerListadoPersonajesBL();
                PuntuacionMaxima = 5;
                BotonGuardar = new DelegateCommand(BotonGuardar_Execute, BotonGuardar_CanExecute);
            }
            catch (Exception ex)
            {
                MuestraMensaje("Error", "Hubo un error inesperado con la BD, intentelo más tarde", "Aceptar");
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

        #region Comandos
        private bool BotonGuardar_CanExecute()
        {
            bool ejecutar = false;

            if (Combatiente1 != null && Combatiente2 != null)
            {
                if ((Combatiente1.ID != Combatiente2.ID) && (PuntuacionCombatiente1 != 0 || PuntuacionCombatiente2 != 0))
                {
                    if (Combatiente1.ID != 0 && Combatiente2.ID != 0)
                    {
                        ejecutar = true;
                    }
                }
            }

            return ejecutar;
        }
        private void BotonGuardar_Execute()
        {
            Combate combateAGuardar = new Combate();
            combateAGuardar.IdCombatiente1 = Combatiente1.ID;
            combateAGuardar.IdCombatiente2 = Combatiente2.ID;
            combateAGuardar.PuntosCombatiente1 = PuntuacionCombatiente1;
            combateAGuardar.PuntosCombatiente2 = PuntuacionCombatiente2;
            try
            {
                if (ManejadoraBL.guardarCombateBL(combateAGuardar))
                {
                    MuestraMensaje("Éxito", "Combate guardado correctamente", "Aceptar");
                }
                else
                {
                    MuestraMensaje("Error", "No se ha podido guardar el combate, intentelo más tarde", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                MuestraMensaje("Error", "Hubo un error inesperado al guardar el combate, intentelo más tarde", "Aceptar");
            }
        }
        #endregion
    }
}
