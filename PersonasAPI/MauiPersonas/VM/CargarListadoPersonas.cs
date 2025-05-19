using BL;
using ENT;
using MAUI.ViewsModels.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiPersonas.VM
{
    public class CargarListadoPersonas : INotifyPropertyChanged
    {
        #region Atributos
        private ObservableCollection<ClsPersona> listadoPersonas;

        #endregion

        #region Propiedades
        public ObservableCollection<ClsPersona> ListadoPersonas 
        {
            get { return listadoPersonas; } 
        }
        public DelegateCommand CargarListadoPersonasCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Constructores
        // TODO: Constructores
        #endregion

        #region Notify
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
