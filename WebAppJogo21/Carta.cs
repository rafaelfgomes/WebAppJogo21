using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebAppJogo21
{
    public class Carta
    {

        private int valorCarta;
        private string nomeCarta;
        private Image cartaBaralho;

        public Carta() : this(0, "", "") { }

        public Carta(string nome, string url)
        {

            nomeCarta = nome;

            cartaBaralho = new Image()
            {

                ID = String.Format("{0}", nomeCarta),
                ImageUrl = url,
                Width = 100,
                Height = 150,
                ImageAlign = ImageAlign.Middle

            };

        }

        public Carta(int valor, string nome, string url)
        {

            valorCarta = valor;
            nomeCarta = nome;

            cartaBaralho = new Image()
            {

                ID = String.Format("{0}", nomeCarta),
                ImageUrl = url,
                Width = 100,
                Height = 150,
                ImageAlign = ImageAlign.Middle,
                AlternateText = valorCarta.ToString()

            };

        }

        public int ValorCarta { get => valorCarta; }
        public string NomeCarta { get => nomeCarta; }
        public Image CartaBaralho { get => cartaBaralho; set => cartaBaralho = value; }
    }

}