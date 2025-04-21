namespace ENT
{
    public class Combate
    {

        #region Propiedades
        public int IdCombatiente1 { get; set; }
        public int IdCombatiente2 { get; set; }
        public DateTime Fecha { get; set; }
        public int PuntosCombatiente1 { get; set; }
        public int PuntosCombatiente2 { get; set; }
        #endregion

        #region Constructores
        public Combate()
        {
            this.Fecha = DateTime.Now;
        }

        public Combate(int idCombatiente1, int idCombatiente2, int puntosCombatiente1, int puntosCombatiente2)
        {
            IdCombatiente1 = idCombatiente1;
            IdCombatiente2 = idCombatiente2;
            Fecha = DateTime.Now;
            PuntosCombatiente1 = puntosCombatiente1;
            PuntosCombatiente2 = puntosCombatiente2;
        }
        #endregion

    }
}
