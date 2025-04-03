using ENT;
using BL;
using System.Collections.ObjectModel;
using MAUI.Models;
using MAUI.ViewsModels.Utils;
using System.ComponentModel;

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
                MuestraMensaje("Error", "No se ha podido cargar el listado de caballos, intentelo más tarde", "OK");
            }
        }
        #endregion

        #region Comandos
        private async void ActualizarCommand_Executed()
        {
            int filasTotalesAfectadas = 0;
            int filaActualAfectada = 0;
            string mensajeCuerpo;
            foreach (ClsCaballoConListadoRazas caballoConRazas in ListadoDeCaballosConConListaDeRazas)
            {
                if (caballoConRazas.RazaSeleccionada.IdRaza != 0 && caballoConRazas.RazaSeleccionada.IdRaza != caballoConRazas.IdRaza)
                {
                    try
                    {
                        filaActualAfectada = ClsManejadoraBL.actualizarRazaCaballoBL(caballoConRazas.IdCaballo, caballoConRazas.RazaSeleccionada.IdRaza);
                    }
                    catch (Exception e)
                    {
                        MuestraMensaje("Error", "No se ha podido actualizar el caballo, intentelo más tarde", "OK");
                    }

                    if (filaActualAfectada == 1)
                    {
                        caballoConRazas.IdRaza = caballoConRazas.RazaSeleccionada.IdRaza;
                        filasTotalesAfectadas++;
                    }
                }  
            }
            mensajeCuerpo = "Se ha/n actualizado " + filasTotalesAfectadas + " caballo/s";
            MuestraMensaje("Actualizado", mensajeCuerpo, "OK");
        }
        #endregion

        #region Funciones
        public async void MuestraMensaje(string mensajeTitulo, string mensajeCuerpo, string mensajeBoton)
        {
            await Shell.Current.DisplayAlert(mensajeTitulo, mensajeCuerpo, mensajeBoton);
        }
        #endregion
    }
}
