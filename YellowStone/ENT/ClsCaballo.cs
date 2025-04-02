namespace ENT
{
    public class ClsCaballo
    {
        // Ejemplo propiedades no implementada
        //#region Atributos
        //private string nombre;
        //#endregion

        //#region Propiedades
        //public int Nombre
        //{
        //    get { return nombre; }
        //    set { nombre = value; }
        //}
        //#endregion

        // Usar propiedades autoimplementadas cuando no queramos realizar ninguna operación en el get o set
        #region Propiedades
        public int IdCaballo { get; }
        public string Nombre { get; set; }
        public int IdRaza { get; set; }
        #endregion

        #region Constructores
        public ClsCaballo()
        {
            
        }
        public ClsCaballo(int idCaballo, string nombre, int idRaza)
        {
            this.IdCaballo = idCaballo;
            this.Nombre = nombre;
            this.IdRaza = idRaza;
        }
        public ClsCaballo(int idCaballo)
        {
            this.IdCaballo = idCaballo;
        }
        #endregion


    }
}
