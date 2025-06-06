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
        public static async Task prepararPartida(Pregunta preguntaRellenar, HashSet<int> idPokemonAnteriores)
        {
            List<int> idRepetidos = new List<int>();
            preguntaRellenar.pokemonAdivinar = new Pokemon();
            preguntaRellenar.pokemonsIncorrectos = new ObservableCollection<Pokemon>();
            preguntaRellenar.pokemonClickables = new ObservableCollection<Pokemon>();
            Pokemon pokemonIncorrecto = new Pokemon();
            int idAleatorio;

            if (idPokemonAnteriores.Any()) 
            {
                for (int i = 0; i < 4; i++)
                {
                    do
                    {
                        idAleatorio = Random.Shared.Next(1, 1026);
                        // Puede que reviente por nulos?
                    } while (idPokemonAnteriores.Contains(idAleatorio) && idRepetidos.Contains(idAleatorio));

                    if (i == 0)
                    {
                        // Tengo que llamar a un método asíncrono desde el constructor y no sé como hacerlo
                        preguntaRellenar.pokemonAdivinar = await ManejadoraBL.obtenerUnPokemonPorIDBL(idAleatorio);
                        preguntaRellenar.pokemonClickables.Add(preguntaRellenar.pokemonAdivinar);
                    }
                    else
                    {
                        pokemonIncorrecto = await ManejadoraBL.obtenerUnPokemonPorIDBL(idAleatorio);
                        preguntaRellenar.pokemonsIncorrectos.Add(pokemonIncorrecto);
                        preguntaRellenar.pokemonClickables.Add(pokemonIncorrecto);
                    }

                    idRepetidos.Add(idAleatorio);
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    do
                    {
                        idAleatorio = Random.Shared.Next(1, 1026);
                        // Puede que reviente por nulos?
                    } while (idRepetidos.Contains(idAleatorio) || idAleatorio == preguntaRellenar.pokemonAdivinar.Id);

                    if (i == 0)
                    {
                        // Tengo que llamar a un método asíncrono desde el constructor y no sé como hacerlo
                        preguntaRellenar.pokemonAdivinar = await ManejadoraBL.obtenerUnPokemonPorIDBL(idAleatorio);
                        preguntaRellenar.pokemonClickables.Add(preguntaRellenar.pokemonAdivinar);
                    }
                    else
                    {
                        pokemonIncorrecto = await ManejadoraBL.obtenerUnPokemonPorIDBL(idAleatorio);
                        preguntaRellenar.pokemonsIncorrectos.Add(pokemonIncorrecto);
                        preguntaRellenar.pokemonClickables.Add(pokemonIncorrecto);
                    }

                    idRepetidos.Add(idAleatorio);
                }
            }

            shuffle(preguntaRellenar.pokemonClickables);

            preguntaRellenar.tiempo = 5;

        }

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
        #endregion

        #region Notify
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
