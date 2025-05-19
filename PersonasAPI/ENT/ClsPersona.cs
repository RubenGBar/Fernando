namespace ENT
{
    public class ClsPersona
    {
        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Dni { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public int IdDepartamento { get; set; }
        #endregion

        #region Constructores
        public ClsPersona()
        {

        }
        public ClsPersona(int idPersona)
        {
            this.Id = idPersona;
        }
        public ClsPersona(int idPersona, string nombre, string apellido, string email, string telefono, int idDepartamento, int dni, string sexo)
        {
            this.Id = idPersona;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
            this.Telefono = telefono;
            this.IdDepartamento = idDepartamento;
            this.Dni = dni;
            this.Sexo = sexo;
        }
        #endregion
    }
}
