using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace PM2T2.Models
{
    public class Firmas
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }

        public string codigoimagen { get; set; }

        [MaxLength(150)]
        public string nombre { get; set; }

        [MaxLength(150)]
        public string descripcion { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
