namespace ENT
{
    public class ClsRaza
    {

        #region Propiedades
        public int IdRaza { get; }
        public string Nombre { get; set; }
        #endregion

        #region Constructores
        public ClsRaza()
        {
            
        }
        public ClsRaza(int idRaza, string nombre)
        {
            this.IdRaza = idRaza;
            this.Nombre = nombre;
        }
        #endregion

    }
}
