<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio - Clinica Grupo 21 </title>
    <style>
        body, html {
            height: 100%;
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            background-color: #f7f7f7;
            font-family: Arial, sans-serif;
        }
        .contenedor {
            padding: 20px;
            width: 300px;
            border: 1px solid #ccc;
        }
        .encabezado {
            background-color: #9ae0c4;
            color: white;
            padding: 10px;
            text-align: center;
            margin-bottom: 20px; 
        }
        .grupo {
            margin-bottom: 10px; 
        }
        .lbl {
            margin-bottom: 5px;
            display: block;
        }
        .txt {
            margin-bottom: 5px;
            width: 100%;
            padding: 10px;
            box-sizing: border-box;
        }
        .txtContenedor {
            display: flex;
            justify-content: space-between;
        }
        .lblError {
            margin-bottom: 5px;
            font-size: 12px;
            color: red;
            flex-grow: 1;
            text-align: left;
        }
        .rfvError {
            margin-bottom: 5px;
            font-size: 12px;
            color: red;
            flex-grow: 1;
            text-align: right;
        }
        .btn {
            margin-bottom: 10px;
            width: 100%;
            padding: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <div class="encabezado">
                <h1>Clínica G21</h1>
            </div>
            <div class="grupo">
                <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo de usuario:" CssClass="lbl"></asp:Label>
                <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="txt">
                    <asp:ListItem Value="0">Administrador</asp:ListItem>
                    <asp:ListItem Value="1">Medico</asp:ListItem>
                </asp:DropDownList>
                <div class="txtContenedor">
                    <asp:Label ID="lblErrorPermiso" runat="server" CssClass="lblError"></asp:Label>
                </div>
            </div>
            <div class="grupo"><br />
                <asp:Label ID="lblUsuario" runat="server" Text="Nombre de usuario:" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="txt"></asp:TextBox>
                <div class="txtContenedor">
                    <asp:Label ID="lblErrorUsuario" runat="server" CssClass="lblError"></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" ControlToValidate="txtUsuario" CssClass="rfvError">Este campo es obligatorio</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="grupo">
                <asp:Label ID="lblPass" runat="server" Text="Contraseña:" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
                <div class="txtContenedor">
                    <asp:Label ID="lblErrorPass" runat="server" CssClass="lblError"></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="txtPass" CssClass="rfvError">Este campo es obligatorio</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="grupo">
                <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn" OnClick="btnLogin_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
