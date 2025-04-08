using BL;
using ENT;

namespace UI.Models.VM
{
    public class ClsListadoPersonaNombreDepartamento : ClsPersona
    {
        #region Propiedades
        public List<ClsPersona> ListadoCompleto = new List<ClsPersona>();
        public string NombreDepartamento { get; set; }
        #endregion

        #region Constructores
        public ClsListadoPersonaNombreDepartamento(ClsPersona persona, List<ClsDepartamento> listaDepartamento)
        : base(persona.Id, persona.Nombre, persona.Apellido, persona.Email, persona.Telefono, persona.IdDepartamento, persona.Dni, persona.Sexo)
        {
            foreach (ClsDepartamento departamento in listaDepartamento)
            {
                if (departamento.Id == persona.IdDepartamento)
                {
                    NombreDepartamento = departamento.Nombre;
                }
                ListadoCompleto.Add(persona);
            }
        }
        #endregion
    }
}
