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

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Constructores
        public Pregunta()
        {
            List<int> idRepetidos = new List<int>();
            int idAleatorio;
            pokemonAdivinar = ManejadoraBL.obtenerUnPokemonAleatorio().Result;
            
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    idAleatorio = Random.Shared.Next(1, 1303);
                } while (idRepetidos.Contains(idAleatorio) || idAleatorio == pokemonAdivinar.Id);
                idRepetidos.Add(idAleatorio);
            }

            correcto = false;
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
