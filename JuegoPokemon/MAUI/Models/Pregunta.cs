using BL;
using DTO;
using System.ComponentModel;

namespace MAUI.Models
{
    public class Pregunta : INotifyPropertyChanged
    {
        #region Atributos
        private Pokemon pokemonAdivinar;
        private bool correcto;
        private Pokemon pokemonSeleccionado;
        private List<Pokemon> pokemonsIncorrectos;
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
        public List<Pokemon> PokemonsIncorrectos
        {
            get { return pokemonsIncorrectos; }
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
            List<int> idRepetidos = new List<int>();
            pokemonAdivinar = new Pokemon();
            pokemonsIncorrectos = new List<Pokemon>();
            int idAleatorio;
            
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    idAleatorio = Random.Shared.Next(1, 1303);
                } while (idRepetidos.Contains(idAleatorio) || idAleatorio == pokemonAdivinar.Id);

                if (i == 0)
                {
                    pokemonAdivinar = ManejadoraBL.obtenerUnPokemonPorIDBL(idAleatorio).Result;
                } 
                else
                {
                    pokemonsIncorrectos.Add(ManejadoraBL.obtenerUnPokemonPorIDBL(idAleatorio).Result);
                }

                idRepetidos.Add(idAleatorio);
            }
            tiempo = 5;
            correcto = false;
        }
        #endregion

        #region Funciones
        #endregion

        #region Notify
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
