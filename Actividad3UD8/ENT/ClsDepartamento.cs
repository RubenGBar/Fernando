namespace ENT
{
    public class ClsDepartamento
    {
        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        #endregion

        #region Constructores
        public ClsDepartamento()
        {

        }
        public ClsDepartamento(int idDepartamento, string nombre)
        {
            this.Id = idDepartamento;
            this.Nombre = nombre;
        }
        #endregion
    }
}
