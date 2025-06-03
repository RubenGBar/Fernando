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
        private bool correcto;
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
        public bool Correcto
        {
            get { return correcto; }
        }
        public Pokemon PokemonSeleccionado
        {
            get { return pokemonSeleccionado; }
            set 
            { 
                pokemonSeleccionado = value;
                if (pokemonSeleccionado.Id == pokemonAdivinar.Id)
                {
                    correcto = true;
                }
                OnPropertyChanged(nameof(Correcto));
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
        public Pregunta(List<int> idPokemonAnteriores)
        {
            List<int> idRepetidos = new List<int>();
            pokemonAdivinar = new Pokemon();
            pokemonsIncorrectos = new ObservableCollection<Pokemon>();
            int idAleatorio;
            
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    idAleatorio = Random.Shared.Next(1, 1303);
                         // Puede que reviente por nulos?
                } while (idPokemonAnteriores.Contains(idAleatorio) && (idRepetidos.Contains(idAleatorio) || idAleatorio == pokemonAdivinar.Id));

                if (i == 0)
                {
                    // Tengo que llamar a un método asíncrono desde el constructor y no sé como hacerlo
                    pokemonAdivinar = obtenerPokemonPorID(idAleatorio);
                } 
                else
                {
                    pokemonsIncorrectos.Add(ManejadoraBL.obtenerUnPokemonPorIDBL(idAleatorio).Result);
                }

                pokemonClickables.Add(pokemonAdivinar);
                pokemonClickables.Add(pokemonsIncorrectos[i]);

                idRepetidos.Add(idAleatorio);
            }

            shuffle(pokemonClickables);

            tiempo = 5;
            correcto = false;
        }
        #endregion

        #region Funciones
        private void shuffle(ObservableCollection<Pokemon> listaMezclar)
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
        public async Task<Pokemon> obtenerPokemonPorID(int id)
        {
            Pokemon pokemon = new Pokemon();

            pokemon = await ManejadoraBL.obtenerUnPokemonPorIDBL(id);

            return pokemon;
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
