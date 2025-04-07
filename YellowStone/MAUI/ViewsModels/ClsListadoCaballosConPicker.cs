using ENT;
using BL;
using System.Collections.ObjectModel;
using MAUI.Models;
using MAUI.ViewsModels.Utils;
using System.ComponentModel;
using Microsoft.Data.SqlClient;

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
        /// <summary>
        /// Método asociado al execute del comando ActualizarCommand que actualiza la raza de los caballos en la base de datos si la raza seleccionada es distinta a la que ya tiene y a 0
        /// </summary>
        private async void ActualizarCommand_Executed()
        {
            int filasTotalesAfectadas = 0;
            int filaActualAfectada = 0;

            foreach (ClsCaballoConListadoRazas caballoConRazas in ListadoDeCaballosConConListaDeRazas)
            {
                if (caballoConRazas.RazaSeleccionada.IdRaza != 0 && caballoConRazas.RazaSeleccionada.IdRaza != caballoConRazas.IdRaza)
                {
                    try
                    {
                        filaActualAfectada = ClsManejadoraBL.actualizarRazaCaballoBL(caballoConRazas.IdCaballo, caballoConRazas.RazaSeleccionada.IdRaza);
                    }
                    catch (SqlException e)
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

            MuestraMensaje("Actualizado", $"Se ha/n actualizado {filasTotalesAfectadas} caballo/s", "OK");
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
