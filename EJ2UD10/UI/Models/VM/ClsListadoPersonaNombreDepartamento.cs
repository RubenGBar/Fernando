using BL;
using ENT;

namespace UI.Models.VM
{
    public class ClsListadoPersonaNombreDepartamento
    {
        #region Propiedades
        public List<ClsPersonaConDepartamento> listadoCompleto { get; }
        #endregion


        public ClsListadoPersonaNombreDepartamento()
        {
            List<ClsPersona> listadoPersonas = ClsListadoPersonasBL.obtenerListadoBD();
            List<ClsDepartamento> listadoDepartamentos = ClsListadoDepartamentosBL.obtenerListadoDepartamentosBD();
            listadoCompleto = new List<ClsListadoPersonaNombreDepartamento>();
            foreach (ClsPersona persona in listadoPersonas)
            {
                ClsPersonaConDepartamento nuevaPersona = new ClsPersonaConDepartamento(persona, listadoDepartamentos);
                listadoCompleto.Add(nuevaPersona);
            }
        }
    }
}
