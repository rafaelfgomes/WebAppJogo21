using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppJogo21
{
    public partial class Jogo : System.Web.UI.Page
    {
        static Cookies cookie;
        static Baralho baralho;
        static List<Jogador> jogador;
        static bool vezJogador1 = false, vezJogador2 = false;
        static int cont1 = 1, cont2 = 1;

        protected void Page_Load(object sender, EventArgs e)
        {

            btnNovaPartida.Visible = false;
            btnNovoJogo.Visible = false;

            if (!IsPostBack)
            {

                if (monteBaralho.Enabled == false)
                {

                    monteBaralho.Enabled = true;

                }

                #region Resgate de cookies

                cookie = new Cookies();

                cookie.Jogador1 = Request.Cookies["jogador1"];
                cookie.Jogador2 = Request.Cookies["jogador2"];

                lblNomeJogador1.Text = converterParaUTF8(cookie.Jogador1["nome"]);
                lblQtdPontosJogador1.Text = cookie.Jogador1["pontos"];

                lblNomeJogador2.Text = converterParaUTF8(cookie.Jogador2["nome"]);
                lblQtdPontosJogador2.Text = cookie.Jogador2["pontos"];

                #endregion

                #region Criação do baralho e embaralho das cartas

                baralho = new Baralho(); //cria o braralho
                baralho.embaralharCartas(baralho.BaralhoJogo);

                #endregion

                #region Criação dos jogadores e seus pontos

                jogador = new List<Jogador>();
                jogador.Add(new Jogador(cookie.Jogador1["nome"], int.Parse(cookie.Jogador1["pontos"])));
                jogador.Add(new Jogador(cookie.Jogador2["nome"], int.Parse(cookie.Jogador2["pontos"])));

                #endregion

                #region Sorteio inicial do jogador

                if (Jogador.embaralhaJogador() == "jogador1")
                {

                    vezDoJogador(jogador[0].Nome);

                }
                else
                {

                    vezDoJogador(jogador[1].Nome);

                }

                #endregion

                #region Coloca 1ª carta do jogador 1 e soma os pontos

                cartasJogador1.InnerHtml = String.Format("<div id=\"carta{0}jogador1\" class=\"col-md-3\"><img id=\"{1}\" src=\"images/{2}.png\" style=\"width: {3}; height: {4}; \">&nbsp;&nbsp;</div>", cont1, baralho.BaralhoJogo.Peek().CartaBaralho.ID, String.Format("{0}_{1}", baralho.BaralhoJogo.Peek().ValorCarta, baralho.BaralhoJogo.Peek().NomeCarta), baralho.BaralhoJogo.Peek().CartaBaralho.Width, baralho.BaralhoJogo.Peek().CartaBaralho.Height);

                jogador[0].somarPontos(baralho.BaralhoJogo.Peek().ValorCarta);
                jogador[0].CartasJogador.Add(baralho.BaralhoJogo.Pop());

                lblQtdPontosJogador1.Text = jogador[0].Pontos.ToString();

                corPontuacao(jogador[0].Pontos);

                cont1++;

                #endregion

                #region Coloca 1ª carta do jogador 2 e soma os pontos

                cartasJogador2.InnerHtml = String.Format("<div id=\"carta{0}jogador2\" class=\"col-md-3\"><img id=\"{1}\" src=\"images/{2}.png\" style=\"width: {3}; height: {4}; \">&nbsp;&nbsp;</div>", cont2, baralho.BaralhoJogo.Peek().CartaBaralho.ID, String.Format("{0}_{1}", baralho.BaralhoJogo.Peek().ValorCarta, baralho.BaralhoJogo.Peek().NomeCarta), baralho.BaralhoJogo.Peek().CartaBaralho.Width, baralho.BaralhoJogo.Peek().CartaBaralho.Height);

                jogador[1].somarPontos(baralho.BaralhoJogo.Peek().ValorCarta);
                jogador[1].CartasJogador.Add(baralho.BaralhoJogo.Pop());

                lblQtdPontosJogador2.Text = jogador[1].Pontos.ToString();

                corPontuacao(jogador[1].Pontos);

                cont2++;

                #endregion

                fundoMonte();

            }

        }

        protected void monteBaralho_Click(object sender, ImageClickEventArgs e)
        {

            if (baralho.BaralhoJogo.Count == 0)
            {

                lblSemCartas.Visible = true;
                lblSemCartas.Text = "Não há mais cartas no baralho!!!";

            }
            else
            {

                lblSemCartas.Text = "";
                lblSemCartas.Visible = false;

                if (vezJogador1)
                {

                    cartasJogador1.InnerHtml += String.Format("<div id=\"carta{0}jogador1\" class=\"col-md-3\"><img id=\"{1}\" src=\"images/{2}.png\" style=\"width: {3}; height: {4}; \"></div>", cont1, baralho.BaralhoJogo.Peek().CartaBaralho.ID, String.Format("{0}_{1}", baralho.BaralhoJogo.Peek().ValorCarta, baralho.BaralhoJogo.Peek().NomeCarta), baralho.BaralhoJogo.Peek().CartaBaralho.Width, baralho.BaralhoJogo.Peek().CartaBaralho.Height);

                    if (cont1 == 4 || cont1 == 8 || cont1 == 12 || cont1 == 16 || cont1 == 20 || cont1 == 24)
                    {

                        cartasJogador1.InnerHtml += "<p>&nbsp;</p>";

                    }

                    jogador[0].somarPontos(baralho.BaralhoJogo.Peek().ValorCarta);
                    jogador[0].CartasJogador.Add(baralho.BaralhoJogo.Pop());

                    lblQtdPontosJogador1.Text = jogador[0].Pontos.ToString();

                    corPontuacao(jogador[0].Pontos);

                    fundoMonte();

                    vezDoJogador(jogador[1].Nome);

                    cont1++;

                }
                else
                {

                    cartasJogador2.InnerHtml += String.Format("<div id=\"carta{0}jogador2\" class=\"col-md-3\"><img id=\"{1}\" src=\"images/{2}.png\" style=\"width: {3}; height: {4}; \"></div>", cont2, baralho.BaralhoJogo.Peek().CartaBaralho.ID, String.Format("{0}_{1}", baralho.BaralhoJogo.Peek().ValorCarta, baralho.BaralhoJogo.Peek().NomeCarta), baralho.BaralhoJogo.Peek().CartaBaralho.Width, baralho.BaralhoJogo.Peek().CartaBaralho.Height);

                    if (cont2 == 4 || cont2 == 8 || cont2 == 12 || cont2 == 16 || cont2 == 20 || cont2 == 24)
                    {

                        cartasJogador2.InnerHtml += "<p>&nbsp;</p>";

                    }

                    jogador[1].somarPontos(baralho.BaralhoJogo.Peek().ValorCarta);
                    jogador[1].CartasJogador.Add(baralho.BaralhoJogo.Pop());

                    lblQtdPontosJogador2.Text = jogador[1].Pontos.ToString();

                    corPontuacao(jogador[1].Pontos);

                    fundoMonte();

                    vezDoJogador(jogador[0].Nome);

                    cont2++;

                }

                verificaGanhador(jogador[0].Pontos, jogador[1].Pontos);

            }

        }

        protected void vezDoJogador(string nome)
        {

            if (jogador[0].Nome == nome)
            {

                vezJogador1 = true;
                vezJogador2 = false;

                btnFinalizarJogador1.Enabled = true;
                btnFinalizarJogador2.Enabled = false;

                simboloVezJogador2.Style.Add("display", "none");
                simboloVezJogador1.Style.Remove("display");

            }
            else
            {

                vezJogador2 = true;
                vezJogador1 = false;

                btnFinalizarJogador2.Enabled = true;
                btnFinalizarJogador1.Enabled = false;

                simboloVezJogador1.Style.Add("display", "none");
                simboloVezJogador2.Style.Remove("display");

            }

        }

        protected void fundoMonte()
        {

            if (baralho.BaralhoJogo.Count == 0)
            {

                monteBaralho.ImageUrl = "~/images/semcarta.png";

            }
            else
            {

                if (baralho.BaralhoJogo.Peek().NomeCarta.Contains("Ouro") || baralho.BaralhoJogo.Peek().NomeCarta.Contains("Copas"))
                {

                    monteBaralho.ImageUrl = "~/images/FundoVermelho.png";

                }
                else
                {

                    monteBaralho.ImageUrl = "~/images/FundoAzul.png";

                }

            }

        }

        protected void btnFinalizarJogador1_Click(object sender, EventArgs e)
        {

            int diferencaJogador1 = 0, diferencaJogador2 = 0;

            diferencaJogador1 = 21 - jogador[0].Pontos;
            diferencaJogador2 = 21 - jogador[1].Pontos;

            if (diferencaJogador1 < diferencaJogador2)
            {

                lblJogadorVencedor.Visible = true;  
                lblJogadorVencedor.Text = String.Format("{0} venceu o jogo!!!!", converterParaUTF8(jogador[0].Nome));

            }
            else if (diferencaJogador2 < diferencaJogador1)
            {

                lblJogadorVencedor.Visible = true;
                lblJogadorVencedor.Text = String.Format("{0} venceu o jogo!!!!", converterParaUTF8(jogador[1].Nome));

            }
            else
            {

                if (jogador[0].Pontos == jogador[1].Pontos)
                {

                    lblJogadorVencedor.Visible = true;
                    lblJogadorVencedor.Text = String.Format("A partida empatou!!!!");

                    btnNovaPartida.Visible = true;
                    btnNovoJogo.Visible = true;

                }
                else
                {

                    lblJogadorVencedor.Text = "";
                    lblJogadorVencedor.Visible = false;

                }

            }

            btnNovaPartida.Visible = true;
            btnNovoJogo.Visible = true;

        }

        protected void btnFinalizarJogador2_Click(object sender, EventArgs e)
        {

            int diferencaJogador1 = 0, diferencaJogador2 = 0;

            diferencaJogador1 = 21 - jogador[0].Pontos;
            diferencaJogador2 = 21 - jogador[1].Pontos;

            if (diferencaJogador1 < diferencaJogador2)
            {

                lblJogadorVencedor.Visible = true;
                lblJogadorVencedor.Text = String.Format("{0} venceu o jogo!!!!", converterParaUTF8(jogador[0].Nome));

            }
            else if(diferencaJogador2 < diferencaJogador1)
            {

                lblJogadorVencedor.Visible = true;
                lblJogadorVencedor.Text = String.Format("{0} venceu o jogo!!!!", converterParaUTF8(jogador[1].Nome));

            }
            else
            {

                if (jogador[0].Pontos == jogador[1].Pontos)
                {

                    lblJogadorVencedor.Visible = true;
                    lblJogadorVencedor.Text = String.Format("A partida empatou!!!!");

                    btnNovaPartida.Visible = true;
                    btnNovoJogo.Visible = true;

                }
                else
                {

                    lblJogadorVencedor.Text = "";
                    lblJogadorVencedor.Visible = false;

                }

            }

            btnNovaPartida.Visible = true;
            btnNovoJogo.Visible = true;

            btnFinalizarJogador1.Enabled = false;
            btnFinalizarJogador2.Enabled = false;

            monteBaralho.Enabled = false;

        }

        protected void btnNovaPartida_Click(object sender, EventArgs e)
        {

            jogador.Clear();
            baralho.BaralhoJogo.Clear();
            baralho.BaralhoEspecial.Clear();

            cont1 = 1;
            cont2 = 1;

            Response.Redirect("Jogo.aspx");

        }

        protected void btnNovoJogo_Click(object sender, EventArgs e)
        {

            cookie.Jogador1.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie.Jogador1);

            cookie.Jogador2.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie.Jogador2);
            
            jogador.Clear();
            baralho.BaralhoJogo.Clear();
            baralho.BaralhoEspecial.Clear();

            Response.Redirect("Inicio.aspx");

        }

        protected void verificaGanhador(int pontosJogador1, int pontosJogador2)
        {

            if (pontosJogador1 == 21)
            {

                lblJogadorVencedor.Visible = true;
                lblJogadorVencedor.Text = String.Format("{0} venceu o jogo!!!!", converterParaUTF8(jogador[0].Nome));

                btnNovaPartida.Visible = true;
                btnNovoJogo.Visible = true;

                btnFinalizarJogador1.Enabled = false;
                btnFinalizarJogador2.Enabled = false;

                monteBaralho.Enabled = false;

            }
            else if (pontosJogador2 == 21)
            {

                lblJogadorVencedor.Visible = true;
                lblJogadorVencedor.Text = String.Format("{0} venceu o jogo!!!!", converterParaUTF8(jogador[1].Nome));

                btnNovaPartida.Visible = true;
                btnNovoJogo.Visible = true;

                btnFinalizarJogador1.Enabled = false;
                btnFinalizarJogador2.Enabled = false;

                monteBaralho.Enabled = false;

            }
            else
            {

                if (pontosJogador1 > 21)
                {

                    lblJogadorVencedor.Visible = true;
                    lblJogadorVencedor.Text = String.Format("{0} venceu o jogo!!!!", converterParaUTF8(jogador[1].Nome));

                    btnNovaPartida.Visible = true;
                    btnNovoJogo.Visible = true;

                    btnFinalizarJogador1.Enabled = false;
                    btnFinalizarJogador2.Enabled = false;

                    monteBaralho.Enabled = false;

                }
                else if (pontosJogador2 > 21)
                {

                    lblJogadorVencedor.Visible = true;
                    lblJogadorVencedor.Text = String.Format("{0} venceu o jogo!!!!", converterParaUTF8(jogador[0].Nome));

                    btnNovaPartida.Visible = true;
                    btnNovoJogo.Visible = true;

                    btnFinalizarJogador1.Enabled = false;
                    btnFinalizarJogador2.Enabled = false;

                    monteBaralho.Enabled = false;

                }
                else
                {

                    lblJogadorVencedor.Text = "";
                    lblJogadorVencedor.Visible = false;

                    monteBaralho.Enabled = true;

                }

            }

        }

        protected void corPontuacao(int pontos)
        {

            if (pontos <= 10)
            {

                if (!IsPostBack)
                {

                    lblQtdPontosJogador1.CssClass = "label label-success";
                    lblQtdPontosJogador2.CssClass = "label label-success";

                }
                else
                {

                    if (vezJogador1)
                    {

                        lblQtdPontosJogador1.CssClass = "label label-success";

                    }
                    else
                    {

                        lblQtdPontosJogador2.CssClass = "label label-success";

                    }

                }

            }
            else if (pontos <= 18)
            {

                if (!IsPostBack)
                {

                    lblQtdPontosJogador1.CssClass = "label label-warning";
                    lblQtdPontosJogador2.CssClass = "label label-warning";

                }
                else
                {

                    if (vezJogador1)
                    {

                        lblQtdPontosJogador1.CssClass = "label label-warning";

                    }
                    else
                    {

                        lblQtdPontosJogador2.CssClass = "label label-warning";

                    }

                }

            }
            else if (pontos == 21)
            {

                if (vezJogador1)
                {

                    lblQtdPontosJogador1.CssClass = "label label-info";

                }
                else
                {

                    lblQtdPontosJogador2.CssClass = "label label-info";

                }

            }
            else
            {

                if (!IsPostBack)
                {

                    lblQtdPontosJogador1.CssClass = "label label-danger";
                    lblQtdPontosJogador2.CssClass = "label label-danger";

                }
                else
                {

                    if (vezJogador1)
                    {

                        lblQtdPontosJogador1.CssClass = "label label-danger";

                    }
                    else
                    {

                        lblQtdPontosJogador2.CssClass = "label label-danger";

                    }

                }

            }

        }

        protected string converterParaUTF8(string palavra)
        {

            byte[] letras = Encoding.Default.GetBytes(palavra);

            palavra = Encoding.UTF8.GetString(letras);

            return palavra;

        }

    }

}