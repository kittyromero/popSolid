using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceConexionn;

namespace StreamN
{
    public class Clientes
    {
       mySql mysql = new mySql();
        public bool Conexion()
        {
            bool conex = mysql.AccesoMysql("localhost", "root", "usbw", "pruebaalonso","3307");
            return conex;
        }
        
        string rfc;
        string nombre;
        string paterno;
        string materno;
        string nac;
        string direc;
        string correo;
        string telefono;
        

        public bool agregarCliente()
        {
            mysql.Abrir();
            //bool res = false;
            bool ejecutar = mysql.Agregar("clientes", "rfc,nombre,paterno,materno,nacimiento,direccion,correo,telefono", "'" + rfc + "','" + nombre + "','" + paterno + "','" + materno + "','" + nac  +"','"+ direc + "','" + correo + "','" + telefono + "'");
            //return res;
            mysql.Cerrar();
            return ejecutar;

        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Paterno
        {
            get
            {
                return paterno;
            }

            set
            {
                paterno = value;
            }
        }

        public string Materno
        {
            get
            {
                return materno;
            }

            set
            {
                materno = value;
            }
        }

        public string Direc
        {
            get
            {
                return direc;
            }

            set
            {
                direc = value;
            }
        }

        public string Rfc
        {
            get
            {
                return rfc;
            }

            set
            {
                rfc = value;
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }
        public string Nac 
        {
            get 
            {
                return nac;
            }
        set
        {
            nac = value;
        }
        }
        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }
    }
      
 }
