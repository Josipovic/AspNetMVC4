using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNet5.Models
{
    public class Zaposlenik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public float Placa { get; set; }
        public string Telefon { get; set; }
    }
}