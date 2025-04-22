using ENT;

namespace DTO
{
    public class PersonajeConPuntuacionTotal : Personaje
    {
        #region Propiedades
        public int PuntuacionTotal { get; set; }
        #endregion

        #region Constructores
        public PersonajeConPuntuacionTotal(Personaje personaje, int puntuacionTotal) 
        : base(personaje.ID, personaje.Nombre, personaje.Imagen)
        {
            PuntuacionTotal = puntuacionTotal;
        }
        public PersonajeConPuntuacionTotal() 
        : base()
        {

        }
        #endregion
    }
}
