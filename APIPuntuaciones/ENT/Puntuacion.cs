namespace ENT
{
    public class Puntuacion
    {
        #region Propiedades
        public int Id { get; }
        public string Nickname { get; set; }
        public int Puntos { get; set; }
        #endregion

        #region Constructores
        public Puntuacion()
        {

        }
        public Puntuacion(int id)
        {
            Id = id;
        }
        public Puntuacion(string nickname, int puntos)
        {
            Nickname = nickname;
            Puntos = puntos;
        }
        #endregion

    }
}
