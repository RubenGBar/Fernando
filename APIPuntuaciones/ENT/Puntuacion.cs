namespace ENT
{
    public class Puntuacion
    {
        #region Propiedades
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int Puntos { get; set; }
        #endregion

        #region Constructores
        public Puntuacion()
        {

        }
        public Puntuacion(string nickname, int puntos)
        {
            Nickname = nickname;
            Puntos = puntos;
        }
        #endregion

    }
}
