namespace ENT
{
    public class Pokemon
    {
        #region Propiedades
        public int Id { get; }
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
        public Pokemon(string nombre, string foto)
        {
            Nombre = nombre;
            Foto = foto;
        }
        #endregion
    }
}
