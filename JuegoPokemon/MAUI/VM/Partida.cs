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
        private IDispatcherTimer cuentaHaciaAtras;
        // Estas variables las tengo que declarar fuera de la función del juego principal para que no se reinicien en cada tick
        private int indicePregunta;
        private bool preguntaRespondida;
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

            indicePregunta = 0;
            preguntaRespondida = false;
            puntos = 0;

            cuentaHaciaAtras = Application.Current.Dispatcher.CreateTimer();
            cuentaHaciaAtras.Interval = TimeSpan.FromSeconds(1.5);
            cuentaHaciaAtras.Tick += juegoPrincipal;

            PuedeGuardarPartida = true;
            PuedeIrRanking = false;

        }
        #endregion

        #region Commands
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

            // Esto lo dejo en esta función que será la que se llame al pulsar el botón
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

            cuentaHaciaAtras.Start();

        }

        private async void juegoPrincipal(object? sender, EventArgs e)
        {

            if (indicePregunta >= preguntas.Count())
            {
                cuentaHaciaAtras.Stop();
            }
            else
            {

                if (preguntaActual.PokemonSeleccionado != null && !preguntaRespondida)
                {
                    // Pongo el esCorrecto de cada pokemon de la pregunta a null para que aparezca transparente
                    foreach (Pokemon pokemon in preguntaActual.PokemonClickables)
                    {
                        pokemon.EsCorrecto = null;
                    }

                    if (preguntaActual.PokemonSeleccionado == preguntaActual.PokemonAdivinar)
                    {
                        puntos += preguntaActual.Tiempo;
                        OnPropertyChanged(nameof(Puntos));
                        preguntaRespondida = true;
                        preguntaActual.PokemonSeleccionado.EsCorrecto = true;
                        // He tenido que poner esto para que en la vista de tiempo de verse el frame de color rojo o verde
                        await Task.Delay(1000);
                    }
                    else if (preguntaActual.PokemonSeleccionado != preguntaActual.PokemonAdivinar)
                    {
                        preguntaRespondida = true;
                        preguntaActual.PokemonSeleccionado.EsCorrecto = false;
                        // He tenido que poner esto para que en la vista de tiempo de verse el frame de color rojo o verde
                        await Task.Delay(1000);
                    }

                }

                if (preguntaActual.Tiempo == 0 || preguntaRespondida)
                {
                    indicePregunta++;
                    Ronda++;
                    OnPropertyChanged(nameof(Ronda));

                    if (indicePregunta >= preguntas.Count())
                    {
                        cuentaHaciaAtras.Stop();
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
