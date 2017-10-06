<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jogo.aspx.cs" Inherits="WebAppJogo21.Jogo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">

    <head runat="server">

        <meta charset="UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />

        <link href="Content/bootstrap.css" rel="stylesheet" />
        <link href="Content/bootstrap-theme.css" rel="stylesheet" />
        <link href="Content/styles.css" rel="stylesheet" />
        
        <link rel="icon" href="images/Coringa.png" />

        <title>Jogo 21</title>
        <a href="Jogo.aspx">Jogo.aspx</a>
    </head>

    <body>

        <div class="container">

            <div class="row">
                
                <p id="titulo" class="h1 text-center">Jogo 21 (BlackJack)</p>

            </div>

            <form id="frmJogo" runat="server">

                <br />

                <div id="paineljogador1" class="panel">

                    <div class="panel-body">

                        <div class="row">

                            <div class="col-md-1 col-sm-1">

                                <span id="simboloVezJogador1" runat="server" class="glyphicon glyphicon-ok-circle text-right"></span>

                            </div>

                            <div class="col-md-2 col-sm-2">

                                <asp:Label ID="lblJogador1" CssClass="text-right" Font-Bold="true" ForeColor="Black" runat="server" Text="Jogador 1: "></asp:Label>

                            </div>

                            <div class="col-md-2 col-sm-2 text-left">

                                <asp:Label ID="lblNomeJogador1" Font-Size="Larger" CssClass="label label-default" runat="server" Text=""></asp:Label>

                            </div>

                            <div class="col-md-3 col-sm-3 text-center">

                                <asp:Button ID="btnFinalizarJogador1" runat="server" CssClass="btn btn-default" Text="Finalizar jogo" OnClick="btnFinalizarJogador1_Click" />

                            </div>

                            <div class="col-md-2 col-sm-2">

                                <asp:Label ID="lblPontosJogador1" CssClass="texto" Font-Bold="true" runat="server" Text="Pontos: "></asp:Label>

                            </div>

                            <div class="col-md-2 col-sm-2 text-left">

                                <asp:Label ID="lblQtdPontosJogador1" runat="server" Font-Size="Large" Text=""></asp:Label>

                            </div>

                        </div>

                    </div>

                </div>

                <br />
                
                <div id="cartasj1" class="well text-center" style="margin-left: 30%; margin-right: 25%;">

                    <div id="cartasJogador1" runat="server" class="row">

                    </div>

                </div>

                <br />

                <div class="row">

                    <div class="col-md-12 text-center">

                        <asp:Label ID="lblJogadorVencedor" CssClass="label label-success" Font-Size="Large" runat="server" Visible="false" Text=""></asp:Label>&nbsp;&nbsp;<asp:Button ID="btnNovaPartida" runat="server" CssClass="btn btn-default" Visible="false" Text="Nova Partida" OnClick="btnNovaPartida_Click" />&nbsp;&nbsp;<asp:Button ID="btnNovoJogo" runat="server" CssClass="btn btn-default" Visible="false" Text="Novo Jogo" OnClick="btnNovoJogo_Click" />

                    </div>

                    <p>&nbsp;</p>

                    <div class="col-md-12 text-center">

                        <asp:ImageButton ID="monteBaralho" runat="server" Width="100px" Height="150px" OnClick="monteBaralho_Click" />

                    </div>

                    <div class="col-md-12 text-center">

                        <asp:Label ID="lblSemCartas" CssClass="label label-danger" runat="server" Visible="false" Text=""></asp:Label>

                    </div>

                </div>

                <br />

                <div id="cartasj2" class="well text-center" style="margin-left: 30%; margin-right: 25%;">

                    <div id="cartasJogador2" runat="server" class="row text-center">

                    </div>

                </div>

                <br />

                <div id="paineljogador2" class="panel">

                    <div class="panel-body">

                        <div class="row">

                            <div class="col-md-1 col-sm-1">

                                <span id="simboloVezJogador2" runat="server" class="glyphicon glyphicon-ok-circle text-right"></span>

                            </div>

                            <div class="col-md-2 col-sm-2">

                                <asp:Label ID="lblJogador2" Font-Bold="true" Height="40px" runat="server" Text="Jogador 2: "></asp:Label>

                            </div>

                            <div class="col-md-2 col-sm-2 text-left">

                                <asp:Label ID="lblNomeJogador2" CssClass="label label-default" Font-Size="Larger" runat="server" Text=""></asp:Label>

                            </div>

                            <div class="col-md-3 col-sm-3 text-center">

                                <asp:Button ID="btnFinalizarJogador2" runat="server" CssClass="btn btn-default" Text="Finalizar jogo" OnClick="btnFinalizarJogador2_Click" />

                            </div>

                            <div class="col-md-2 col-sm-2">

                                <asp:Label ID="lblPontosJogador2" Font-Bold="true" CssClass="texto" runat="server" Text="Pontos: "></asp:Label>

                            </div>

                            <div class="col-md-2 col-sm-2 text-left">

                                <asp:Label ID="lblQtdPontosJogador2" Font-Size="Large" runat="server" Text=""></asp:Label>

                            </div>

                        </div>

                    </div>

                </div>

            </form>

        </div>

    </body>

</html>