namespace ENT
{
    public class Personaje
    {
        #region Propiedades
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        #endregion

        #region Constructores
        public Personaje() 
        {
            
        }

        public Personaje(int id, string nombre, string imagen)
        {
            ID = id;
            Nombre = nombre;
            Imagen = imagen;
        }
        #endregion

    }
}
