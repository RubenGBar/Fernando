using Newtonsoft.Json;

namespace DTO
{
    public class Pokemon
    {
        #region Propiedades
        [JsonProperty("id")]
        public int Id { get; }
        /// <summary>
        /// Subclase con el nombre del pokemon, ya que la API lo guarda en un array y no en un string directamente
        /// </summary>
        [JsonProperty("species")]
        public Especie Especie { get; set; }
        public string Foto { get; set; }
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
    }
}
