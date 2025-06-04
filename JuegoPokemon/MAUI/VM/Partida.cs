using BL;
using ENT;
using MAUI.Models;
using MAUI.VM.Utils;
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
        private IDispatcher dispatcher;
        private bool mostrarJuego;
        private bool mostrarInstrucciones;
        private DelegateCommand miCommand;
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
                return preguntaActual; 
            }
            set 
            { 
                preguntaActual = value; 
                OnPropertyChanged(nameof(PreguntaActual));
            }
        }

        public IDispatcher Dispatcher
        {
            get { return dispatcher; }
            set { dispatcher = value; }
        }

        public DelegateCommand MiCommand
        {
            get { return miCommand; }
        }

        public bool MostrarJuego
        {
            get { return mostrarJuego; }
            set 
            { 
                mostrarJuego = value; 
                OnPropertyChanged(nameof(MostrarJuego)); 
            }
        }

        public bool MostrarInstrucciones
        {
            get { return mostrarInstrucciones; }
            set 
            { 
                mostrarInstrucciones = value; 
                OnPropertyChanged(nameof(MostrarInstrucciones)); 
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
            preguntas = new ObservableCollection<Pregunta>();

            mostrarInstrucciones = true;

            miCommand = new DelegateCommand(() => EmpezarPartida());

        }
        #endregion

        #region Funciones

        private async Task PrepararPartida(List<int> idPokemonAnteriores)
        {
            await preguntaActual.prepararPartida(idPokemonAnteriores);
        }

        private async Task EmpezarPartida()
        {
            int indicePregunta = 0;
            List<int> idPokemonAnteriores = new List<int>();
            bool seguir = true;
            bool preguntaRespondida = false;
            ronda = 1;
            puntos = 0;

            for (int i = 0; i < 20; i++)
            {
                if (preguntaActual != null) 
                {
                    // Guardo los IDs de los Pokémon ya usados para evitar que se repitan en futuras preguntas
                    for (int j = 0; j < 4; j++)
                    {
                        idPokemonAnteriores.Add(preguntaActual.PokemonsIncorrectos[i].Id);
                    }
                }

                preguntas.Add(new Pregunta());

                if (preguntas.Any())
                {
                    preguntaActual = preguntas[indicePregunta];
                }

                await PrepararPartida(idPokemonAnteriores);

            }

            OnPropertyChanged(nameof(ronda));
            mostrarJuego = true;

            mostrarInstrucciones = !mostrarInstrucciones;

            if (!mostrarInstrucciones)
            {
                mostrarJuego = true;
            }

            Dispatcher.StartTimer(TimeSpan.FromSeconds(1.5), () =>
            {
                if (indicePregunta >= preguntas.Count())
                {
                    seguir = false;

                }
                else
                {

                    if (preguntaActual.PokemonSeleccionado != null && !preguntaRespondida && preguntaActual.PokemonSeleccionado == PreguntaActual.PokemonAdivinar)
                    {
                        puntos += preguntaActual.Tiempo;
                        OnPropertyChanged(nameof(Puntos));
                        preguntaRespondida = true;
                    }

                    if (preguntaActual.Tiempo == 0 || preguntaRespondida)
                    {
                        indicePregunta++;
                        ronda++;
                        OnPropertyChanged(nameof(ronda));

                        if (indicePregunta >= preguntas.Count())
                        {
                            seguir = false;
                        }
                        else
                        {
                            preguntaActual = preguntas[indicePregunta];
                            OnPropertyChanged(nameof(PreguntaActual));
                        }

                        preguntaActual.Tiempo = 5;
                        preguntaRespondida = false;

                    }
                    else
                    {
                        preguntaActual.Tiempo--;
                    }

                }

                return seguir;
            });

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
