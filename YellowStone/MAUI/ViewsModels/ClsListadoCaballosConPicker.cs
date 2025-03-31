using ENT;
using BL;
using System.Collections.ObjectModel;
using MAUI.Models;
using MAUI.ViewsModels.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUI.ViewsModels
{
    internal class ClsListadoCaballosConPicker
    {

        #region Propiedades
        public ObservableCollection<ClsCaballoConListadoRazas> ListadoDeCaballosConConListaDeRazas { get; }
        public DelegateCommand ActualizarCommand { get; }
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Constructores
        public ClsListadoCaballosConPicker()
        {
            try
            {
                List<ClsCaballo> listadoCaballos = ClsListadosBL.obtenerListadoCaballoBL();
                List<ClsRaza> listadoRazas = ClsListadosBL.obtenerListadoRazaBL();
                // Para que en el Picker Aparezca esta opción de forma predeterminada
                listadoRazas.Insert(0, new ClsRaza(0, "--- SELECCIONA UNA RAZA ---"));
                ListadoDeCaballosConConListaDeRazas = new ObservableCollection<ClsCaballoConListadoRazas>();

                foreach (ClsCaballo caballo in listadoCaballos)
                {
                    ClsCaballoConListadoRazas caballoConRazas = new ClsCaballoConListadoRazas(caballo, listadoRazas);
                    ListadoDeCaballosConConListaDeRazas.Add(caballoConRazas);
                }

                ActualizarCommand = new DelegateCommand(ActualizarCommand_Executed);

            }
            catch (Exception e)
            {
                //TODO: Avisar al usuario mediante un display alert que halgo ha pasado con la Base de Datos
            }
        }
        #endregion

        #region Comandos
        private async void ActualizarCommand_Executed()
        {
            int filasAfectadas = 0;
            foreach (ClsCaballoConListadoRazas caballoConRazas in ListadoDeCaballosConConListaDeRazas)
            {
                if (caballoConRazas.RazaSeleccionada.IdRaza != 0)
                {
                    filasAfectadas += ClsManejadoraBL.actualizarRazaCaballoBL(caballoConRazas.IdCaballo, caballoConRazas.RazaSeleccionada.IdRaza);
                }  
            }
            await Shell.Current.DisplayAlert("Actualizado", "Se ha/n actualizado " + filasAfectadas + " caballo/s", "OK");
        }
        #endregion
    }
}
