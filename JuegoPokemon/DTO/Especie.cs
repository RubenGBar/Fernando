using Newtonsoft.Json;

namespace DTO
{
    /// <summary>
    /// Subclase hecha para guardar el nombre más bonito del pokemon, poruqe había otros más raros, y este estaaba entro de un array por lo que necesitaba una subclase
    /// </summary>
    public class Especie
    {
        [JsonProperty("name")]
        public string Nombre { get; set; }
    }
}
