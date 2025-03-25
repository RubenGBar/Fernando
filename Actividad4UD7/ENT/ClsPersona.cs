namespace ENT
{
    public class ClsPersona
    {

        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string IdDepartamento { get; set; }
        #endregion

        #region Constructores
        public ClsPersona()
        {
            
        }
        public ClsPersona(int idPersona, string nombre, string apellido, int fechaNacimiento, string telefono, string idDepartamento)
        {
            this.Id = idPersona;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaNacimiento = fechaNacimiento;
            this.Telefono = telefono;
            this.IdDepartamento = idDepartamento;
        }
        #endregion

    }
}
