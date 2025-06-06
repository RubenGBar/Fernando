using BL;
using DTO;
using ENT;
using MAUI.Models;
using MAUI.Views;
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
        private bool mostrarFinal;
        private DelegateCommand miCommand;
        private DelegateCommand guardarPartida;
        private DelegateCommand irRanking;
        private bool puedeGuardarPartida;
        private bool puedeIrRanking;
        private bool cargando;
        #endregion

        #region Propiedades
        public ObservableCollection<Pregunta> Preguntas
        {
            get { return preguntas; }
        }

        public bool MostrarFinal
        {
            get => mostrarFinal;
            private set
            {
                mostrarFinal = value;
                OnPropertyChanged(nameof(MostrarFinal));
            }
        }

        public bool PuedeGuardarPartida
        {
            get => puedeGuardarPartida;
            private set
            {
                puedeGuardarPartida = value;
                OnPropertyChanged(nameof(PuedeGuardarPartida));
                guardarPartida.RaiseCanExecuteChanged();
            }
        }

        public bool PuedeIrRanking
        {
            get => puedeIrRanking;
            private set
            {
                puedeIrRanking = value;
                OnPropertyChanged(nameof(PuedeIrRanking));
                irRanking.RaiseCanExecuteChanged();
            }
        }

        public bool Cargando
        {
            get { return cargando; }
            private set 
            { 
                cargando = value; 
                OnPropertyChanged(nameof(Cargando)); 
            }
        }

        public Pregunta PreguntaActual
        {
            get 
            {
                return preguntaActual; 
            }
            private set
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

        public DelegateCommand GuardarPartida
        {
            get { return guardarPartida; }
        }

        public DelegateCommand IrRanking
        {
            get { return irRanking; }
        }

        public bool MostrarJuego
        {
            get { return mostrarJuego; }
            private set
            { 
                mostrarJuego = value; 
                OnPropertyChanged(nameof(MostrarJuego)); 
            }
        }

        public bool MostrarInstrucciones
        {
            get { return mostrarInstrucciones; }
            private set 
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
            private set 
            { 
                ronda = value;
                OnPropertyChanged(nameof(Ronda));
            }
        }

        public int Puntos
        {
            get { return puntos; } 
            private set 
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
            guardarPartida = new DelegateCommand(()=>guardarPartida_Execute(), guardarPartida_CanExecute);
            irRanking = new DelegateCommand(() => irRanking_Execute(), irRanking_CanExecute);

            PuedeGuardarPartida = true;
            PuedeIrRanking = false;

        }

        private bool irRanking_CanExecute()
        {
            return PuedeIrRanking;
        }

        private async Task irRanking_Execute()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Ranking());
        }

        private bool guardarPartida_CanExecute()
        {
            return PuedeGuardarPartida;
        }

        private async Task guardarPartida_Execute()
        {
            Puntuacion puntuacionGuardar = new Puntuacion(nickJugador, puntos);
            await ManejadoraBL.guardarPuntuacionBL(puntuacionGuardar);

            PuedeGuardarPartida = false; 
            PuedeIrRanking = true;

        }
        #endregion

        #region Funciones
        private async Task EmpezarPartida()
        {
            Cargando = true;

            int indicePregunta = 0;
            HashSet<int> idPokemonAnteriores = new HashSet<int>();
            int idRepetido = 0;
            Pregunta nuevaPregunta;
            bool seguir = true;
            bool preguntaRespondida = false;
            puntos = 0;

            for (int i = 0; i < 20; i++)
            {
                if (preguntaActual != null) 
                {
                    // Guardo los IDs de los Pokémon ya usados para evitar que se repitan en futuras preguntas
                    foreach (Pokemon pokemonRepetido in preguntaActual.PokemonClickables)
                    {
                        idRepetido = pokemonRepetido.Id;
                        idPokemonAnteriores.Add(idRepetido);
                    }
                }

                nuevaPregunta = new Pregunta();

                await Pregunta.prepararPartida(nuevaPregunta, idPokemonAnteriores);

                preguntas.Add(nuevaPregunta);

            }

            Cargando = false;
            //OnPropertyChanged(nameof(Cargando));

            // Puede que esto no haga falta
            OnPropertyChanged(nameof(ronda));
            MostrarJuego = true;

            MostrarInstrucciones = !mostrarInstrucciones;

            if (!MostrarInstrucciones)
            {
                MostrarJuego = true;
            }

            if (preguntas.Any())
            {
                preguntaActual = preguntas[indicePregunta];
                preguntaActual.Tiempo = 5;

                OnPropertyChanged(nameof(PreguntaActual));

                Ronda = 1;
                OnPropertyChanged(nameof(Ronda));

            }

            Dispatcher.StartTimer(TimeSpan.FromSeconds(1.5), () =>
            {
                if (indicePregunta >= preguntas.Count())
                {
                    seguir = false;
                }
                else
                {

                    if (preguntaActual.PokemonSeleccionado != null && !preguntaRespondida && preguntaActual.PokemonSeleccionado == preguntaActual.PokemonAdivinar)
                    {
                        puntos += preguntaActual.Tiempo;
                        OnPropertyChanged(nameof(Puntos));
                        preguntaRespondida = true;
                    }

                    if (preguntaActual.Tiempo == 0 || preguntaRespondida)
                    {
                        indicePregunta++;
                        Ronda++;
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

                        if (Ronda > 20)
                        {
                            Ronda = 20;
                            MostrarJuego = false;
                            MostrarFinal = true;
                        }

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
