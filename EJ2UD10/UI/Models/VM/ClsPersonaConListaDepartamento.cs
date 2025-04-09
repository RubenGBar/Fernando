using BL;
using ENT;

namespace UI.Models.VM
{
    public class ClsPersonaConListaDepartamento : ClsPersona
    {
        #region Propiedades
        public List<ClsDepartamento> ListaDepartamentos { get; set; }
        #endregion

        #region Constructores
        public ClsPersonaConListaDepartamento(List<ClsDepartamento> listaDepartamentos)
        : base()
        {
            ListaDepartamentos = listaDepartamentos;
        }
        public ClsPersonaConListaDepartamento(ClsPersona persona, List<ClsDepartamento> listaDepartamentos)
        : base(persona.Id, persona.Nombre, persona.Apellido, persona.Email, persona.Telefono, persona.IdDepartamento, persona.Dni, persona.Sexo)
        {
            ListaDepartamentos = listaDepartamentos;
        }
        public ClsPersonaConListaDepartamento() { }
        #endregion

    }
}
