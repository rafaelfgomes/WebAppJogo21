using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAppJogo21
{
    public class Baralho
    {

        private Stack<Carta> baralhoJogo, baralhoEspecial;
        DirectoryInfo di;
        FileInfo[] cartasBaralho;
        string[] separacaoNomeArquivo;
        static Random rnd = new Random();

        public Baralho()
        {

            baralhoJogo = new Stack<Carta>();
            baralhoEspecial = new Stack<Carta>();

            di = new DirectoryInfo(String.Format(@"{0}images", HttpContext.Current.Server.MapPath("~")));
            cartasBaralho = di.GetFiles();

            foreach (FileInfo arquivo in cartasBaralho)
            {

                if (arquivo.Name != "logo.png" && arquivo.Name != "FundoAzul.png" && arquivo.Name != "FundoVermelho.png" && arquivo.Name != "Coringa.png" && arquivo.Name != "fundo.jpg" && arquivo.Name != "fundo2.jpg" && arquivo.Name != "semcarta.png" && arquivo.Name != "fundotransparente.png")
                {

                    separacaoNomeArquivo = Path.GetFileNameWithoutExtension(arquivo.Name).Split('_');

                    baralhoJogo.Push(new Carta(int.Parse(separacaoNomeArquivo[0]), separacaoNomeArquivo[1], String.Format("{0}\\{1}_{2}", di.FullName, separacaoNomeArquivo[0], separacaoNomeArquivo[1])));
                    

                }
                else
                {

                    if (arquivo.Name != "logo.png" && arquivo.Name != "fundo.jpg" && arquivo.Name != "fundo2.jpg")
                    {

                        baralhoEspecial.Push(new Carta(Path.GetFileNameWithoutExtension(arquivo.Name), String.Format("{0}\\{1}", di.FullName, arquivo.Name)));

                    }
                    
                }

            }

        }

        public Stack<Carta> BaralhoJogo { get => baralhoJogo; set => baralhoJogo = value; }
        public Stack<Carta> BaralhoEspecial { get => baralhoEspecial; set => baralhoEspecial = value; }

        public void embaralharCartas(Stack<Carta> cartas)
        {

            List<Carta> cartasAux = new List<Carta>();
            List<int> trocados = new List<int>();
            Carta cartaAux = new Carta();

            int cont = 0, r = 0;

            foreach (var carta in cartas)
            {

                cartasAux.Add(carta);

            }

            while (trocados.Count < 52)
            {

                r = rnd.Next(0, 52);

                if (cont == 0)
                {

                    trocados.Add(r);

                }
                else
                {

                    if (!(trocados.Contains(r)))
                    {

                        trocados.Add(r);

                    }

                }

                cont++;

            }

            baralhoJogo.Clear();

            foreach (var c in cartasAux)
            {

                baralhoJogo.Push(cartasAux.ElementAt(trocados.ElementAt(cartasAux.IndexOf(c))));

            }

        }

    }

}