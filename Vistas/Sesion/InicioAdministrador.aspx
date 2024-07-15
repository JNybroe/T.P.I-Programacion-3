<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioAdministrador.aspx.cs" Inherits="Vistas.InicioAdministrador" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestión de Administrador - Clinica G21</title>
    <style>
        body, html {
            height: 100%;
            margin: 0;
            font-family: Arial, sans-serif;
        }
        .contenedor {
            padding: 20px;
            width: 350px;
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
        .subtitulo {
            border-bottom: 1px solid #ccc;
            margin-bottom: 5px;
            padding-bottom: 5px;
            text-align: center;
        }
        .btnContenedor {
            display: flex;
            justify-content: center;
            flex-wrap: wrap;
        }
        .btn {
            width: 45%;
            padding: 10px;
            margin: 5px;
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
            <asp:Label ID="lblBarraNavegacion" runat="server" Font-Bold="True" Text="Clinica G21"></asp:Label>
            <div>
                <asp:Label ID="lblUsuario" runat="server" Text="@Usuario"></asp:Label>
                <asp:LinkButton ID="lnkPerfil" runat="server" CssClass="lnkbtn" OnClick="lnkPerfil_Click">Perfil</asp:LinkButton>
                <asp:LinkButton ID="lnkCerrarSesion" runat="server" CssClass="lnkbtn" OnClick="lnkCerrarSesion_Click">Cerrar Sesion</asp:LinkButton>
            </div>
        </div>
        <br/><br/>
        <div class="contenedor">
            <div class="encabezado">
                <h2>Gestión de Administrador</h2>
            </div>
            <div class="subtitulo">
                <h3>Médicos</h3>
                <div class="btnContenedor">
                    <asp:Button ID="btnMedicosAlta" runat="server" Text="Alta" CssClass="btn" OnClick="btnMedicosAlta_Click" />
                    <asp:Button ID="btnMedicosBaja" runat="server" Text="Baja" CssClass="btn" OnClick="btnMedicosBaja_Click" />
                    <asp:Button ID="btnMedicosModificacion" runat="server" Text="Modificación" CssClass="btn" OnClick="btnMedicosModificacion_Click" />
                    <asp:Button ID="btnMedicosListado" runat="server" Text="Listado" CssClass="btn" OnClick="btnMedicosListado_Click" />
                </div>
            </div>
            <div class="subtitulo">
                <h3>Pacientes</h3>
                <div class="btnContenedor">
                    <asp:Button ID="btnPacientesAlta" runat="server" Text="Alta" CssClass="btn" OnClick="btnPacientesAlta_Click" />
                    <asp:Button ID="btnPacientesBaja" runat="server" Text="Baja" CssClass="btn" OnClick="btnPacientesBaja_Click" />
                    <asp:Button ID="btnPacientesModificacion" runat="server" Text="Modificación" CssClass="btn" OnClick="btnPacientesModificacion_Click" />
                    <asp:Button ID="btnPacientesListado" runat="server" Text="Listado" CssClass="btn" OnClick="btnPacientesListado_Click" />
                </div>
            </div>
            <div class="subtitulo">
                <h3>Turnos</h3>
                <div class="btnContenedor">
                    <asp:Button ID="btnTurnosAlta" runat="server" Text="Asignacion de Turnos" CssClass="btn" OnClick="btnTurnosAlta_Click" />
                     <asp:Button ID="btnTurnosModificar" runat="server" Text="Modificar Turno" CssClass="btn" OnClick="btnTurnosModificar_Click" />
                    <asp:Button ID="btnTurnosListado" runat="server" Text="Listado" CssClass="btn" OnClick="btnTurnosListado_Click" />
                </div>
            </div>
            <div class="subtitulo">
                <div>
                    <asp:Button ID="btnInformes" runat="server" Text="Informes" CssClass="btn" OnClick="btnInformes_Click" />
                   
                </div>
            </div>
        </div>
    </form>
</body>
</html>
