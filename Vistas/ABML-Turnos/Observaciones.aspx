<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Observaciones.aspx.cs" Inherits="Vistas.ABML_Turnos.Observaciones" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión de Turnos - Observaciones</title>
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
        .txtObservaciones {
            width: 100%;
            height: 50px; 
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
        .divisionAux {
            width: 100%; 
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
                <asp:LinkButton ID="lnkPerfil" runat="server" CssClass="lnkbtn" OnClick="lnkPerfil_Click" CausesValidation="False">Perfil</asp:LinkButton>
                <asp:LinkButton ID="lnkCerrarSesion" runat="server" CssClass="lnkbtn" OnClick="lnkCerrarSesion_Click" CausesValidation="False">Cerrar Sesion</asp:LinkButton>
            </div>
        </div>
        <br /><br />
        <div class="contenedor">
            <div class="encabezado">
                <h3>Observaciones</h3>
            </div>
            <div class="grupo">
                <div class="division">
                    <asp:Label ID="lblTurno" runat="server" Text="ID Turno:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtTurno" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtNombrePaciente" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtApellidoPaciente" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblDNI" runat="server" Text="DNI:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtDNIPaciente" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlEstadoPaciente" runat="server" CssClass="txt" AutoPostBack="True" OnSelectedIndexChanged="ddlEstadoPaciente_SelectedIndexChanged">
                        <asp:ListItem Text="Ausente" Value="AUSENTE"></asp:ListItem>
                        <asp:ListItem Text="Presente" Value="PRESENTE"></asp:ListItem>
                        <asp:ListItem Value="PENDIENTE">Pendiente</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="division">
                    <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:" CssClass="lbl"></asp:Label>
                </div>
                <div class="divisionAux">
                    <asp:TextBox ID="txtObservacionesPaciente" runat="server" CssClass="txtObservaciones" Enabled="False"></asp:TextBox>
                    <asp:Button ID="btnGuardarCambios" runat="server" Text="Guardar Cambios" CssClass="btn" OnClick="btnGuardarCambios_Click" Enabled="False" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelar_Click" />
                    <asp:Label Text="" ForeColor="Green" ID="lblTurnoModificado" runat="server" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
