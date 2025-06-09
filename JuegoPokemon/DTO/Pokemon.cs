using Newtonsoft.Json;
using System.ComponentModel;

namespace DTO
{
    public class Pokemon : INotifyPropertyChanged
    {
        // He tenido que añadir esto aquí para poder cambiar el color del frame en cada pokemon individualmente
        #region Atributos
        private bool? esCorrecto;
        #endregion

        #region Propiedades
        [JsonProperty("id")]
        public int Id { get; }
        /// <summary>
        /// Subclase con el nombre del pokemon, ya que la API lo guarda en un array y no en un string directamente
        /// </summary>
        [JsonProperty("species")]
        public Especie Especie { get; set; }
        public string Foto { get; set; }
        public bool? EsCorrecto
        {
            get { return esCorrecto; }
            set
            {
                esCorrecto = value;
                OnPropertyChanged(nameof(EsCorrecto));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Constructores
        public Pokemon()
        {

        }
        public Pokemon(int id)
        {
            Id = id;
        }
        public Pokemon(int id, Especie especie)
        {
            Id = id;
            Especie = especie;
        }
        public Pokemon(int id, Especie especie, string foto)
        {
            Id = id;
            Especie = especie;
            Foto = foto;
        }
        #endregion

        #region Funciones
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
