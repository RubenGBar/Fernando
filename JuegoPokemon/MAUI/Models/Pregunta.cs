using BL;
using DTO;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MAUI.Models
{
    public class Pregunta : INotifyPropertyChanged
    {
        #region Atributos
        private Pokemon pokemonAdivinar;
        private Pokemon pokemonSeleccionado;
        private ObservableCollection<Pokemon> pokemonsIncorrectos;
        private ObservableCollection<Pokemon> pokemonClickables;
        private int tiempo;
        #endregion

        #region Propiedades
        public Pokemon PokemonAdivinar
        {
            get { return pokemonAdivinar; }
        }
        public Pokemon PokemonSeleccionado
        {
            get { return pokemonSeleccionado; }
            set 
            { 
                pokemonSeleccionado = value;
                OnPropertyChanged(nameof(PokemonSeleccionado));
            }
        }
        public ObservableCollection<Pokemon> PokemonsIncorrectos
        {
            get { return pokemonsIncorrectos; }
        }

        public ObservableCollection<Pokemon> PokemonClickables
        {
            get 
            {
                return pokemonClickables; 
            }
        }

        public int Tiempo
        {
            get { return tiempo; }
            set 
            { 
                tiempo = value;
                OnPropertyChanged(nameof(Tiempo));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Constructores
        public Pregunta()
        {
            pokemonAdivinar = new Pokemon();
            pokemonsIncorrectos = new ObservableCollection<Pokemon>();
        }
        #endregion

        #region Funciones
        /// <summary>
        /// Funcion que rellena la pregunta recibida. La primera vez que se llama, no se comparan los IDs con la lista de IDs repetidos, 
        /// ya que todavía no hay ninguno
        /// </summary>
        /// <param name="preguntaRellenar"> Pregunta a rellenar </param>
        /// <param name="idPokemonAnteriores"> Lista de IDs repetidos </param>
        /// <returns></returns>
        public static async Task prepararPartida(Pregunta preguntaRellenar, HashSet<int> idPokemonAnteriores)
        {
            HashSet<int> idRepetidos = new HashSet<int>();
            preguntaRellenar.pokemonAdivinar = new Pokemon();
            preguntaRellenar.pokemonsIncorrectos = new ObservableCollection<Pokemon>();
            preguntaRellenar.pokemonClickables = new ObservableCollection<Pokemon>();
            Pokemon pokemonIncorrecto = new Pokemon();
            int idAleatorio;
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    if (idPokemonAnteriores.Any())
                    {
                        do
                        {
                            idAleatorio = Random.Shared.Next(1, 1026);
                        } while (idPokemonAnteriores.Contains(idAleatorio) || idRepetidos.Contains(idAleatorio));
                    }
                    else
                    {
                        do
                        {
                            idAleatorio = Random.Shared.Next(1, 1026);
                        } while (idRepetidos.Contains(idAleatorio));
                    }

                    if (i == 0)
                    {
                        preguntaRellenar.pokemonAdivinar = await ManejadoraBL.obtenerUnPokemonPorIDBL(idAleatorio);
                        preguntaRellenar.pokemonClickables.Add(preguntaRellenar.pokemonAdivinar);
                    }
                    else
                    {
                        pokemonIncorrecto = await ManejadoraBL.obtenerUnPokemonPorIDBL(idAleatorio);
                        preguntaRellenar.pokemonsIncorrectos.Add(pokemonIncorrecto);
                        preguntaRellenar.pokemonClickables.Add(pokemonIncorrecto);
                    }

                    // Pongo el esCorrecto de cada pokemon de la pregunta a null para que aparezca transparente
                    preguntaRellenar.pokemonClickables[i].EsCorrecto = null;

                    idRepetidos.Add(idAleatorio);
                }

                shuffle(preguntaRellenar.pokemonClickables);

                preguntaRellenar.tiempo = 5;
            }
            catch (Exception ex) 
            {
                
                MuestraMensaje("Error:", "Ha ocurrido un error inesperado con la BD, intentélo más tarde", "Ok");
            }

        }

        /// <summary>
        /// Función para mezclar una lista de forma aleatoria porque en c# no existe el método shuffle de Java
        /// </summary>
        /// <param name="listaMezclar"> lista a mezclar </param>
        private static void shuffle(ObservableCollection<Pokemon> listaMezclar)
        {
            Random rnd = new Random();
            int indice = listaMezclar.Count();
            int posicionMezcla;
            Pokemon pokemonApoyo;

            while (indice > 1)
            {
                indice--;
                posicionMezcla = rnd.Next(indice + 1);
                pokemonApoyo = listaMezclar[posicionMezcla];
                listaMezclar[posicionMezcla] = listaMezclar[indice];
                listaMezclar[indice] = pokemonApoyo;

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
