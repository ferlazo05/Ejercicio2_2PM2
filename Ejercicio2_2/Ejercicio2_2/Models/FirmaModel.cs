using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ejercicio2_2.Models
{
    public class FirmaModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public Byte[] Firma { get; set; }
    }
}
