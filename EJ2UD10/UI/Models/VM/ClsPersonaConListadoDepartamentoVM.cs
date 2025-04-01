using ENT;
using BL;

namespace UI.Models.VM
{
    public class ClsPersonaConListadoDepartamentoVM : ClsPersona
    {
        public List<ClsDepartamento> ListadoDepartamentos { get; }
        public ClsPersonaConListadoDepartamentoVM(ClsPersona persona, List<ClsDepartamento> listaDepartmento)
        : base(persona.Id, persona.Nombre, persona.Apellido, persona.Email, persona.Telefono, persona.IdDepartamento, persona.Dni, persona.Sexo)
        {
            ListadoDepartamentos = listaDepartmento;
        }
        public ClsPersonaConListadoDepartamentoVM(ClsPersona persona)
        : base(persona.Id, persona.Nombre, persona.Apellido, persona.Email, persona.Telefono, persona.IdDepartamento, persona.Dni, persona.Sexo)
        {
            ListadoDepartamentos = ClsListadoDepartamentosBL.obtenerListadoDepartamentosBL();
        }
    }
}
