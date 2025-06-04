using Newtonsoft.Json;

namespace DTO
{
    public class Pokemon
    {
        #region Propiedades
        [JsonProperty("id")]
        public int Id { get; }
        [JsonProperty("name")]
        public string Nombre { get; set; }
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
        public Pokemon(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        public Pokemon(int id, string nombre, string foto)
        {
            Id = id;
            Nombre = nombre;
            Foto = foto;
        }
        #endregion
    }
}
