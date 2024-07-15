<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarPass.aspx.cs" Inherits="Vistas.Sesion.ModificarPass" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestión de Usuario - Clinica G21</title>
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
            padding: 5px;
            text-align: center;
            margin-bottom: 10px; 
        }
        .grupo {
            margin-bottom: 10px; 
        }
        .grupoAux{
            margin-bottom: 10px;
            border: 1px solid #ccc;
            align-items: center;
            padding: 10px;

        }
        .lbl {
            margin-bottom: 10px;
            display: block;
        }
        .txt {
            margin-bottom: 10px;
            width: 100%;
            padding: 10px;
            box-sizing: border-box;
        }
        .btn {
            margin-bottom: 10px;
            width: 100%;
            padding: 10px;
        }
        .lblError {
            font-size: 12px;
            color: red;
            margin-bottom: 5px;
        }
        .lblOk {
            text-align: center;
            font-size: 12px;
            color: green;
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <div class="encabezado">
                <h3>Modificar Contraseña</h3>
            </div>
            <div class="grupoAux">
                <asp:Label ID="lblTipoUsuario" runat="server" CssClass="lbl" Font-Bold="False" Text="Tipo de Usuario:"></asp:Label>
            </div>
            <div class="grupoAux">
                <asp:Label ID="lblUsuario" runat="server" CssClass="lbl" Font-Bold="False" Text="Nombre de Usuario:" ></asp:Label>
            </div>
            <div class="grupo">
                <asp:Label ID="lblPassActual" runat="server" Text="Contraseña actual:" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="txtPassActual" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassActual" runat="server" ControlToValidate="txtPassActual" CssClass="lblError">Este campo es obligatorio</asp:RequiredFieldValidator>
            </div>
            <div class="grupo">
                <asp:Label ID="lblPassNuevo" runat="server" Text="Contraseña nueva:" CssClass="lbl" Visible="false"></asp:Label>
                <asp:TextBox ID="txtPassNuevo" runat="server" CssClass="txt" TextMode="Password" Visible="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassNuevo" runat="server" ControlToValidate="txtPassNuevo" CssClass="lblError">Este campo es obligatorio</asp:RequiredFieldValidator>
            </div>
            <div class="grupo">
                <asp:Label ID="lblPassAux" runat="server" Text="Confirme contraseña:" CssClass="lbl" Visible="false"></asp:Label>
                <asp:TextBox ID="txtPassAux" runat="server" CssClass="txt" TextMode="Password" Visible="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassAux" runat="server" ControlToValidate="txtPassAux" CssClass="lblError">Este campo es obligatorio</asp:RequiredFieldValidator>
            </div>
            <div class="grupo">
                <asp:Button ID="btnCambiarPass" runat="server" Text="Cambiar Contraseña" CssClass="btn" OnClick="btnCambiarPass_Click" />
                <asp:Button ID="btnConfirmarCambio" runat="server" Text="Confirmar Cambio" CssClass="btn" OnClick="btnConfirmarCambio_Click" Visible="false" />
                <asp:Button ID="btnInicio" runat="server" Text="Volver al Inicio" CssClass="btn" OnClick="btnInicio_Click" CausesValidation="false" />
            </div>
            <div class="grupo">
                <asp:Label ID="lblErrorPass" runat="server" CssClass="lblError"></asp:Label>
                <asp:Label ID="lblCambiosRealizados" runat="server" CssClass="lblOk"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
