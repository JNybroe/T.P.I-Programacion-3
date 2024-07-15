<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarTurno.aspx.cs" Inherits="Vistas.ABML_Turnos.ModificarTurno" %>

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
                <asp:HyperLink ID="lnkPerfil" runat="server" NavigateUrl="#" CssClass="lnkbtn">Perfil</asp:HyperLink>
                <asp:HyperLink ID="lnkCerrarSesion" runat="server" NavigateUrl="#" CssClass="lnkbtn">Cerrar Sesión</asp:HyperLink>
            </div>
        </div>
        <br />
        <br />
        <div class="contenedor">
            <div class="encabezado">
                <h2>Modificación de Turno</h2>
            </div>
            <div class="grupo">
                <div class="division">
                    <asp:Label ID="lblIdentificadorTurno" runat="server" Text="Identificador del Turno:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtIdentificadorTurno" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:Label ID="lblIDVacio" runat="server" ForeColor="Red" />
                    <asp:Button Text="Buscar Turno" runat="server" CssClass="btn" ID="btnBuscarTurno" OnClick="btnBuscarTurno_Click" />
                </div>
                <div class="division">
                    <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlEspecialidades" CssClass="txt" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="division">
                    <asp:Label ID="lblMedicoDesignado" runat="server" Text="Medico designado:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlMedico" CssClass="txt">
                    </asp:DropDownList>
                </div>
                <div class="division">
                    <asp:Label ID="lblNombrePaciente" runat="server" Text="Nombre del paciente:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtNombrePaciente" runat="server" CssClass="txt" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblApellidoPaciente" runat="server" Text="Apellido del paciente:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtApellidoPaciente" runat="server" CssClass="txt" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblDNIPaciente" runat="server" Text="DNI del paciente:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtDNIPaciente" runat="server" CssClass="txt" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblFechaTurno" runat="server" Text="Fecha del turno:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtFechaTurno" runat="server" TextMode="Date" CssClass="txt" />
                </div>
                <div class="division">
                    <asp:Label ID="lblHorarioConsulta" runat="server" Text="Horario de consulta:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlHorario" CssClass="txt">
                        <asp:ListItem Value="08.00">08:00</asp:ListItem>
                        <asp:ListItem Value="09.00">09:00</asp:ListItem>
                        <asp:ListItem Value="10.00">10:00</asp:ListItem>
                        <asp:ListItem Value="11.00">11:00</asp:ListItem>
                        <asp:ListItem Value="12.00">12:00</asp:ListItem>
                        <asp:ListItem Value="13.00">13:00</asp:ListItem>
                        <asp:ListItem Value="14.00">14:00</asp:ListItem>
                        <asp:ListItem Value="15.00">15:00</asp:ListItem>
                        <asp:ListItem Value="16.00">16:00</asp:ListItem>
                        <asp:ListItem Value="17.00">17:00</asp:ListItem>
                        <asp:ListItem Value="18.00">18:00</asp:ListItem>
                        <asp:ListItem Value="19.00">19:00</asp:ListItem>
                        <asp:ListItem Value="20.00">20:00</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div>
                <asp:Button ID="btnModificarTurno" runat="server" Text="Modificar turno" CssClass="btn" OnClick="btnModificarTurno_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelar_Click" />
                <asp:Button ID="btnVolver" runat="server" Text="Inicio" CssClass="btn" OnClick="btnVolver_Click" />


                <asp:Label Text="" ForeColor="Green" ID="lblTurnoModificado" runat="server" />
            </div>
        </div>
    </form>

</body>
</html>
