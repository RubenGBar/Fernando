using ENT;
using BL;
using MAUI.Models;
using System.ComponentModel;

namespace MAUI.VM
{
    public class Partida : INotifyPropertyChanged
    {
        #region Atributos
        private List<Pregunta> preguntas;
        private Pregunta preguntaActual;
        private string nickJugador;
        private int ronda;
        private int puntos;
        #endregion

        #region Propiedades
        public List<Pregunta> Preguntas
        {
            get { return preguntas; }
        }

        public Pregunta PreguntaActual
        {
            get 
            {
                /*if (preguntas[ronda].Correcto)
                {
                    ronda++;
                }
                else if (cuentaAtras == 0)
                {
                    ronda++;
                }

                preguntaActual = preguntas[ronda];
                OnPropertyChanged(nameof(PreguntaActual));
                */
                return preguntas[ronda]; 
            }
        }

        public string NickJugador
        {
            get { return nickJugador; }
            set { nickJugador = value; }
        }

        public int Ronda
        {
            get { return ronda; }
            set 
            { 
                ronda = value;
                OnPropertyChanged(nameof(Ronda));
            }
        }

        public int Puntos
        {
            get { return puntos; } 
            set 
            { 
                puntos = value; 
                OnPropertyChanged(nameof(Puntos)); 
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Constructores
        public Partida() 
        {
            preguntas = new List<Pregunta>();
            for (int i = 0; i < 20; i++)
            {
                preguntas.Add(new Pregunta());
            }
            preguntaActual = preguntas[ronda];
            ronda = 0;
            puntos = 0;
        }
        #endregion

        #region Notify
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
