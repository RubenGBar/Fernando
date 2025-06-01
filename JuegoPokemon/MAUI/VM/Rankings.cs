using BL;
using ENT;
using System.ComponentModel;

namespace MAUI.VM
{
    public class Rankings : INotifyPropertyChanged
    {
        #region Atributos
        private List<Puntuacion> litadoPuntuaciones;
        #endregion

        #region Propiedades
        public List<Puntuacion> LitadoPuntuaciones 
        {
            get 
            {
                OnPropertyChanged(nameof(LitadoPuntuaciones));
                return litadoPuntuaciones;
            } 
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Conructores
        public Rankings()
        {
            var datos = ListadosBL.obtenerListadoPuntuacionesBL().Result;
            litadoPuntuaciones = datos.OrderByDescending(p => p.Puntos).ToList();
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
