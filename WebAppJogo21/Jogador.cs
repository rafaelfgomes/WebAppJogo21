using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppJogo21
{
    public class Jogador
    {
        private string nome;
        private int pontos;
        private bool vencedor;
        private List<Carta> cartasJogador;

        public string Nome { get => nome; set => nome = value; }
        public int Pontos { get => pontos; set => pontos = value; }
        public List<Carta> CartasJogador { get => cartasJogador; set => cartasJogador = value; }
        public bool Vencedor { get => vencedor; set => vencedor = value; }

        public Jogador(string nome, int pontos)
        {

            this.nome = nome;
            this.pontos = pontos;
            this.vencedor = false;
            cartasJogador = new List<Carta>();

        }

        public int somarPontos(int ponto)
        {

            return pontos += ponto;

        }

        public static string embaralhaJogador()
        {

            int escolhido = 0;

            Random rnd = new Random();

            escolhido = rnd.Next(2, 10);

            if (escolhido % 2 == 0)
            {

                return "jogador1";

            }
            else
            {

                return "jogador2";

            }

        }
        
    }

}