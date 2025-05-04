namespace ENT
{
    public class Invernadero
    {

        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        #endregion

        #region Constructores
        public Invernadero()
        {

        }
        public Invernadero(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        #endregion

    }
}
