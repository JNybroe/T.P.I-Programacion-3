<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="Vistas.Informes.Informes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión de Turnos - Clinica G21</title>
    <style>
        body, html {
            height: 100%;
            margin: 0;
            font-family: Arial, sans-serif;
        }

        .contenedor {
            padding: 20px;
            width: 500px;
            margin: 0 auto;
            border: 1px solid #ccc;
            text-align: center;
        }

        .encabezado {
            background-color: #9ae0c4;
            color: white;
            padding: 10px;
            margin-bottom: 20px;
        }

        .lbl {
            display: block;
            margin-bottom: 5px;
            text-align: left;
        }

        .txt {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
            margin-bottom: 10px;
        }

        .btn {
            width: 45%;
            padding: 10px;
            margin: 5px;
        }

        .grupo {
            display: flex;
            flex-wrap: wrap;
            justify-content: space-between;
        }

        .division {
            width: 48%;
            margin-bottom: 10px;
        }

        .barraNavegacion {
            width: 100%;
            background-color: #9ae0c4;
            padding: 20px;
            box-sizing: border-box;
            display: flex;
            justify-content: space-between;
            align-items: center;
            color: white;
        }

        .lnkbtn {
            color: white;
            text-decoration: none;
            padding: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="barraNavegacion">
            <asp:Label ID="lblBarraNavegacion" runat="server" Text="Clinica G21" Font-Bold="True"></asp:Label>
            <div>
                <asp:Label ID="lblUsuario" runat="server" Text="@Usuario"></asp:Label>
                <asp:LinkButton ID="lnkPerfil" runat="server" CssClass="lnkbtn" OnClick="lnkPerfil_Click">Perfil</asp:LinkButton>
                <asp:LinkButton ID="lnkCerrarSesion" runat="server" CssClass="lnkbtn" OnClick="lnkCerrarSesion_Click">Cerrar Sesion</asp:LinkButton>
            </div>
        </div>
        <div class="contenedor">
            <div class="encabezado">
                <h3>Informes</h3>
            </div>
            <div class="grupo">
                <div>
                    <asp:Label Text="Criterio de informe" runat="server" />
                    <asp:DropDownList ID="ddlCriterioInforme" CssClass="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCriterioInforme_SelectedIndexChanged">
                        <asp:ListItem>Especialidad</asp:ListItem>
                        <asp:ListItem>Fecha</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlEspecialidades" CssClass="txt" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <div>
                        <asp:Label Text="Fecha de inicio" ID="lblFechaInicio" runat="server" Visible="False" />
                        <asp:TextBox ID="txtFechaInicio" TextMode="Date" CssClass="txt" runat="server" Visible="False" />
                        <asp:Label Text="*Coloque una fecha valida." ID="lblFechaInicioVacia" ForeColor="Red" runat="server" Visible="False" />
                    </div>
                    <div>
                        <asp:Label Text="Fecha final" ID="lblFechaFinal" runat="server" Visible="False" />
                        <asp:TextBox ID="txtFechaFin" TextMode="Date" CssClass="txt" runat="server" Visible="False" />
                        <asp:Label Text="*Coloque una fecha valida." ID="lblFechaFinalVacia" ForeColor="Red" runat="server" Visible="False" />
                    </div>
                </div>
                <div class="grupo">
                    <asp:Button ID="btnGenerarInforme" runat="server" Text="Crear Informe" CssClass="btn" OnClick="btnGenerarInforme_Click" />
                    <asp:Button ID="btnVolver" runat="server" Text="Volver al inicio" CssClass="btn" OnClick="btnVolver_Click"/>
                </div>
            </div>
            <asp:GridView runat="server" ID="gvInforme" AllowPaging="True"></asp:GridView>
        </div>
    </form>
</body>
</html>
