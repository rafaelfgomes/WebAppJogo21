using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppJogo21
{
    public partial class Inicio : System.Web.UI.Page
    {

        Cookies cookie;
        int pontosJogador1 = 0, pontosJogador2 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            txtNomeJogador1.Focus();

            if (Request.Cookies["jogador1"] != null || Request.Cookies["jogador2"] != null)
            {

                cookie = new Cookies();

                cookie.Jogador1.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie.Jogador1);

                cookie.Jogador2.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie.Jogador2);

            }

        }

        protected void btnIniciarJogo_Click(object sender, EventArgs e)
        {

            if (!campoEmBranco())
            {

                cookie = new Cookies();

                if (Request.Cookies["jogador1"] == null || Request.Cookies["jogador2"] == null)
                {

                    cookie.Jogador1["nome"] = txtNomeJogador1.Text;
                    cookie.Jogador1["pontos"] = pontosJogador1.ToString();
                    cookie.Jogador1.Expires = DateTime.Now.AddHours(3);

                    Response.Cookies.Add(cookie.Jogador1);

                    cookie.Jogador2["nome"] = txtNomeJogador2.Text;
                    cookie.Jogador2["pontos"] = pontosJogador2.ToString();
                    cookie.Jogador2.Expires = DateTime.Now.AddHours(3);

                    Response.Cookies.Add(cookie.Jogador2);

                }
                else
                {

                    cookie.Jogador1 = Request.Cookies["jogador1"];
                    cookie.Jogador2 = Request.Cookies["jogador2"];

                }

                Response.Redirect("Jogo.aspx");

            }

        }

        public bool campoEmBranco()
        {

            bool embranco;

            if (txtNomeJogador1.Text.Trim() == "" || txtNomeJogador2.Text.Trim() == "")
            {

                if (txtNomeJogador1.Text.Trim() == "" && txtNomeJogador2.Text.Trim() == "")
                {

                    lblErroJogador1.Visible = true;
                    lblErroJogador1.Text = "Campo obrigatório";

                    lblErroJogador2.Visible = true;
                    lblErroJogador2.Text = "Campo obrigatório";

                    txtNomeJogador1.Focus();

                }
                else
                {

                    if (txtNomeJogador1.Text.Trim() == "")
                    {

                        lblErroJogador1.Visible = true;
                        lblErroJogador1.Text = "Campo obrigatório";
                        txtNomeJogador1.Focus();

                    }
                    else
                    {

                        lblErroJogador1.Text = "";
                        lblErroJogador1.Visible = false;

                    }

                    if (txtNomeJogador2.Text.Trim() == "")
                    {

                        lblErroJogador2.Visible = true;
                        lblErroJogador2.Text = "Campo obrigatório";
                        txtNomeJogador2.Focus();

                    }
                    else
                    {

                        lblErroJogador2.Text = "";
                        lblErroJogador2.Visible = false;

                    }

                }

                embranco = true;

            }
            else
            {

                lblErroJogador1.Text = "";
                lblErroJogador1.Visible = false;

                lblErroJogador2.Text = "";
                lblErroJogador2.Visible = false;

                embranco = false;

            }

            return embranco;

        }

    }//class

}//namespace