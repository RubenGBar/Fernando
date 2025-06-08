using BL;
using ENT;
using System.ComponentModel;

namespace MAUI.VM
{
    public class Rankings : INotifyPropertyChanged
    {
        #region Atributos
        private List<Puntuacion> litadoPuntuaciones;
        //private bool cargandoEsVisible;
        #endregion

        #region Propiedades
        /*public bool CargandoEsVisible 
        {
            get { return cargandoEsVisible; }
            private set 
            { 
                cargandoEsVisible = value; 
                OnPropertyChanged(nameof(CargandoEsVisible));
            }
        }*/
        public List<Puntuacion> LitadoPuntuaciones 
        {
            get { return litadoPuntuaciones; }
            private set 
            { 
                litadoPuntuaciones = value; 
                OnPropertyChanged(nameof(LitadoPuntuaciones));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Conructores
        public Rankings()
        {
            CargarDatosAsync();
        }
        #endregion

        #region Funciones
        private async Task CargarDatosAsync()
        {
            //CargandoEsVisible = true;
            var datos = await ListadosBL.obtenerListadoPuntuacionesBL();
            LitadoPuntuaciones = datos.OrderByDescending(p => p.Puntos).ToList();
            //CargandoEsVisible = false;
        }
        #endregion

        #region Notify
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
