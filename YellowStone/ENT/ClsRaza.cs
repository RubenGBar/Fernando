namespace ENT
{
    public class ClsRaza
    {

        #region Propiedades
        public int IdRaza { get; }
        public string NombreRaza { get; set; }
        #endregion

        #region Constructores
        public ClsRaza()
        {
            
        }
        public ClsRaza(int idRaza, string nombre)
        {
            this.IdRaza = idRaza;
            this.NombreRaza = nombre;
        }
        public ClsRaza(int idRaza)
        {
            this.IdRaza = idRaza;
        }
        #endregion

    }
}
