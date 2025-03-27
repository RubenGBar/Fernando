using ENT;
using BL;
using System.Collections.ObjectModel;
using MAUI.Models;
using System.Windows.Input;

namespace MAUI.ViewsModels
{
    internal class ClsListadoCaballosConPicker
    {

        #region Propiedades
        public ObservableCollection<ClsCaballoConListadoRazas> ListadoDeCaballosConConListaDeRazas { get; }
        //public ICommand ActualizarCommand { get; }
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
            }
            catch (Exception e)
            {
                //TODO: Avisar al usuario mediante un display alert que halgo ha pasado con la Base de Datos
            }
            #endregion
        }

    }
}
