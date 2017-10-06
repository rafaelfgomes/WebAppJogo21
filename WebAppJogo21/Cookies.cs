using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppJogo21
{
    public class Cookies
    {

        private HttpCookie jogador1, jogador2;

        public Cookies()
        {

            jogador1 = new HttpCookie("jogador1");
            jogador2 = new HttpCookie("jogador2");

        }

        public HttpCookie Jogador1 { get => jogador1; set => jogador1 = value; }
        public HttpCookie Jogador2 { get => jogador2; set => jogador2 = value; }

    }

}