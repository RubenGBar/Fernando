using BL;
using ENT;
using MAUI.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MAUI.VM
{
    public class Partida : INotifyPropertyChanged
    {
        #region Atributos
        private ObservableCollection<Pregunta> preguntas;
        private Pregunta preguntaActual;
        private string nickJugador;
        private int ronda;
        private int puntos;
        #endregion

        #region Propiedades
        public ObservableCollection<Pregunta> Preguntas
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
            List<int> idPokemonAnteriores = new List<int>();
            preguntas = new ObservableCollection<Pregunta>();
            
            for (int i = 0; i < 20; i++)
            {
                // Guardo los IDs de los Pokémon ya usados para evitar que se repitan en futuras preguntas
                // Puede que reviente por nulos?
                for (int j = 0; j < 4; j++)
                {
                    idPokemonAnteriores.Add(preguntaActual.PokemonsIncorrectos[i].Id);
                }

                preguntas.Add(new Pregunta(idPokemonAnteriores));

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
