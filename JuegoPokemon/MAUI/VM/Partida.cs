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
        private bool mostrarJuego;
        private bool mostrarInstrucciones;
        private bool mostrarFinal;
        private DelegateCommand cargarPreguntas;
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

        public Pokemon PokemonSeleccionado
        {
            // He tenido que poner ahí que pregunta actual puede ser null, porque si no me daba un error al entrar en la vista
            get { return PreguntaActual?.PokemonSeleccionado; }
            set
            {
                if (preguntaActual != null) 
                {
                    preguntaActual.PokemonSeleccionado = value;
                    if (value != null) 
                    {
                        sumarPuntuacion();
                    }

                }
            }
        }

        public Pregunta PreguntaActual
        {
            get { return preguntaActual; }
            private set
            { 
                preguntaActual = value; 
                OnPropertyChanged(nameof(PreguntaActual));
            }
        }

        public DelegateCommand MiCommand
        {
            get { return cargarPreguntas; }
        }

        public DelegateCommand GuardarPartida
        {
            get { return guardarPartida; }
        }

        public DelegateCommand IrRanking
        {
            get { return irRanking; }
        }

        // Estas propiedades hago el property change en el private set, porque he probado a hacerlo de la otra forma y no funcionaba
        public bool MostrarFinal
        {
            get { return mostrarFinal; }
            private set
            {
                mostrarFinal = value;
                OnPropertyChanged(nameof(MostrarFinal));
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

        public bool PuedeGuardarPartida
        {
            get { return puedeGuardarPartida; }
            private set
            {
                puedeGuardarPartida = value;
                OnPropertyChanged(nameof(PuedeGuardarPartida));
                guardarPartida.RaiseCanExecuteChanged();
            }
        }

        public bool PuedeIrRanking
        {
            get { return puedeIrRanking; }
            private set
            {
                puedeIrRanking = value;
                OnPropertyChanged(nameof(PuedeIrRanking));
                irRanking.RaiseCanExecuteChanged();
            }
        }
        // Hasta aquí

        public string NickJugador
        {
            get { return nickJugador; }
            set { nickJugador = value; }
        }

        public int Ronda
        {
            get { return ronda; }
        }

        public int Puntos
        {
            get { return puntos; } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Constructores
        public Partida() 
        {
            preguntas = new ObservableCollection<Pregunta>();

            mostrarInstrucciones = true;

            cargarPreguntas = new DelegateCommand(() => EmpezarPartida());
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
        /// <summary>
        /// Función en la que preparo las preguntas y lo pongo todo bien antes de que empiece la partida.
        /// </summary>
        /// <returns></returns>
        private async Task EmpezarPartida()
        {
            try
            {
                Cargando = true;

                int indicePregunta = 0;
                HashSet<int> idPokemonAnteriores = new HashSet<int>();
                int idRepetido = 0;
                Pregunta nuevaPregunta;

                // Cargo las preguntas
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

                // Dejo de mostrar el activityIndicator
                Cargando = false;

                // Muestro el juego y oculto las instrucciones
                MostrarJuego = true;
                MostrarInstrucciones = !mostrarInstrucciones;
                if (!mostrarInstrucciones)
                {
                    MostrarJuego = true;
                }

                // Si hay alguna pregunta, inicializo la pregunta actual, el tiempo y la ronda
                if (preguntas.Any())
                {
                    preguntaActual = preguntas[indicePregunta];
                    preguntaActual.Tiempo = 5;

                    OnPropertyChanged(nameof(PreguntaActual));

                    ronda = 1;
                    OnPropertyChanged(nameof(Ronda));

                }

                cuentaHaciaAtras.Start();
            }
            catch (Exception ex)
            {
                MuestraMensaje("Error:", "Ha ocurrido un error inesperado con la BD, intentélo más tarde", "Ok");
            }

        }

        /// <summary>
        /// Función para sumar la puntuación sólo cuando se ha seleccionado y así no tener que comprobar en cada tick
        /// </summary>
        /// <returns></returns>
        public async Task sumarPuntuacion() 
        {
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

        /// <summary>
        /// Función principal del juego, que será la que el timer repetirá en cada tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void juegoPrincipal(object? sender, EventArgs e)
        {
            // Se ejecuta mientras haya preguntas
            if (indicePregunta >= preguntas.Count())
            {
                cuentaHaciaAtras.Stop();
            }
            else
            {
                // Entro a la lógica de pasar ronda solo cuando el tiempo llegue a 0 o se haya respondido la pregunta
                if (preguntaActual.Tiempo == 0 || preguntaRespondida)
                {
                    indicePregunta++;
                    ronda++;
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
                        ronda = 20;
                        OnPropertyChanged(nameof(Ronda));
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

        /// <summary>
        /// Esta función muestra un mensaje en la pantalla
        /// </summary>
        /// <param name="mensajeTitulo"> Mensaje de la cabecera </param>
        /// <param name="mensajeCuerpo"> Mensaje del cuerpo </param>
        /// <param name="mensajeBoton"> Mensaje del botón </param>
        public static async void MuestraMensaje(string mensajeTitulo, string mensajeCuerpo, string mensajeBoton)
        {
            await Shell.Current.DisplayAlert(mensajeTitulo, mensajeCuerpo, mensajeBoton);
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
