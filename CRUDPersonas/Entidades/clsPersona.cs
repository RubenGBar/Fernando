using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class clsPersona
    {
        #region Atributos
        String id { get; }
        String nombre { get; set; }
        String apellido { get; set; }
        String telefono { get; set; }
        String direccion { get; set; }
        String foto { get; set; }
        String idDepartamento { get; set; }
        #endregion Atributos

        #region Constructores
        public clsPersona()
        {

        }

        public clsPersona(String id, String nombre, String apellido, String telefono, String direccion, String foto, String idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.direccion = direccion;
            this.foto = foto;
            this.idDepartamento = idDepartamento;
        }
        #endregion

        #region Propiedades
        public String Id
        {
            get { return id; }
        }

        public String Nombre
        { 
            get { return nombre; } 
            set { nombre = value; }
        }

        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public String Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        public String IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }
        #endregion Propiedades
    }
}
