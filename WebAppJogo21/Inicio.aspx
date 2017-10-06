<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebAppJogo21.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">

    <head runat="server">

        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />

        <link href="Content/bootstrap.css" rel="stylesheet" />
        <link href="Content/bootstrap-theme.css" rel="stylesheet" />

        <link href="Content/styles.css" rel="stylesheet" />

        <link rel="icon" href="images/0_Coringa.png" />

        <title>Jogo 21</title>

    </head>

    <body>

        <div class="container">

            <p>&nbsp;</p>

            <form id="frmInicio" class="form-horizontal" runat="server">

                <div class="panel panel-default">

                    <div class="panel-heading">
                        
                        <p class="h1 text-center"><asp:Image ID="imgLogo" runat="server" ImageUrl="~/images/logo.png" Width="70px" Height="70px" />&nbsp;&nbsp;&nbsp;Jogo 21 (BlackJack)</p>

                    </div>

                    <div class="panel-body">

                        <p>&nbsp;</p>

                         <div class="form-group">
                             
                             <asp:Label ID="lblNomeJogador1" runat="server" CssClass="control-label col-md-offset-2 col-md-2" AssociatedControlID="txtNomeJogador1" Text="Jogador 1: "></asp:Label>
                             
                             <div class="col-md-5">
                                 
                                 <asp:TextBox ID="txtNomeJogador1" runat="server" CssClass="form-control" ToolTip="Nome do jogador 1"></asp:TextBox>

                             </div>
                             
                             <div class="col-md-3">
                                 
                                 <asp:Label ID="lblErroJogador1" CssClass="label label-danger" runat="server" Text="" Visible="false"></asp:Label>

                             </div>

                         </div>

                        <div class="form-group">
                            
                            <asp:Label ID="lblNomeJogador2" runat="server" CssClass="control-label col-md-offset-2 col-md-2" AssociatedControlID="txtNomeJogador2" Text="Jogador 2: "></asp:Label>
                            
                            <div class="col-md-5">
                                
                                <asp:TextBox ID="txtNomeJogador2" runat="server" CssClass="form-control" ToolTip="Nome do jogador 2"></asp:TextBox>

                            </div>
                            
                            <div class="col-md-3">
                                
                                <asp:Label ID="lblErroJogador2" CssClass="label label-danger" runat="server" Text="" Visible="false"></asp:Label>

                            </div>

                        </div>
                        
                        <p>&nbsp;</p>
                        
                        <div class="form-group">
                            
                            <div class="col-md-12 text-center">
                                
                                <asp:Button ID="btnIniciarJogo" CssClass="btn btn-default" runat="server" Text="Iniciar jogo" OnClick="btnIniciarJogo_Click" />

                            </div>

                        </div>

                    </div>

                    <div class="panel-footer">
                        
                        <p class="text-right h5">Jogo desenvolvido por Rafael Gomes&copy</p>

                    </div>

                </div>

            </form>

        </div>

        <script src="Scripts/jquery-3.2.1.js"></script>
        <script src="Scripts/bootstrap.js"></script>

    </body>

</html>