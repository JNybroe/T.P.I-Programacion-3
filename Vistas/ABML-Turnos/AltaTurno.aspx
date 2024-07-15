<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaTurno.aspx.cs" Inherits="Vistas.ABML_Turnos.AltaTurno" %>

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
                <asp:LinkButton ID="lnkPerfil" runat="server" CssClass="lnkbtn" OnClick="lnkPerfil_Click" CausesValidation="False">Perfil</asp:LinkButton>
                <asp:LinkButton ID="lnkCerrarSesion" runat="server" CssClass="lnkbtn" OnClick="lnkCerrarSesion_Click" CausesValidation="False">Cerrar Sesion</asp:LinkButton>
            </div>
        </div>
        <br />
        <br />
        <div class="contenedor">
            <div class="encabezado">
                <h2>Alta de Turno</h2>
            </div>
            <div class="grupo">
                <div class="division">
                    <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:" CssClass="lbl" />
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="txt" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label Text="" ForeColor="Red" ID="lblEspecialidadError" runat="server" />
                </div>
                <div class="division">
                    <asp:Label ID="lblMedicoDesignado" runat="server" Text="Medico designado:" CssClass="lbl" />
                    <asp:DropDownList ID="ddlMedicoDesignado" runat="server" CssClass="txt">
                    </asp:DropDownList>
                    <asp:Label Text="" ForeColor="Red" ID="lblMedicoError" runat="server" />
                </div>
                <div class="division">
                    <asp:Label ID="lblFechaTurno" runat="server" Text="Fecha del turno:" CssClass="lbl" />
                    <asp:TextBox ID="txtFechaTurno" runat="server" TextMode="Date" CssClass="txt" />
                    <asp:Label Text="" ID="lblFechaError" ForeColor="Red" runat="server" />
                </div>
                <div class="division">
                    <asp:Label ID="lblHorarioConsulta" runat="server" Text="Horario de consulta:" CssClass="lbl" />
                    <asp:DropDownList ID="ddlHorarioTurno" runat="server" CssClass="txt">
                        <asp:ListItem>- Seleccione un horario - </asp:ListItem>
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
                    <asp:Label Text="" ID="lblErrorHorario" ForeColor="Red" runat="server" />
                </div>
                <div class="division">
                    <asp:Label ID="lblPaciente" runat="server" Text="Dni del Paciente:" CssClass="lbl" />
                    <asp:DropDownList ID="ddlPaciente" runat="server" CssClass="txt" AutoPostBack="True" OnSelectedIndexChanged="ddlPaciente_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label Text="" ForeColor="Red" ID="lblPacienteError" runat="server" />

                </div>
                <div class="division">
                    <asp:Label ID="lblIdentificadorPaciente" runat="server" Text="Identificador del paciente:" CssClass="lbl" />
                    <asp:TextBox ID="txtIdentificadorPaciente" runat="server" CssClass="txt" ReadOnly="True" />
                </div>
                <div class="division">
                    <asp:Label ID="lblNombrePaciente" runat="server" Text="Nombre del paciente:" CssClass="lbl" />
                    <asp:TextBox ID="txtNombrePaciente" runat="server" CssClass="txt" ReadOnly="True" />
                </div>
                <div class="division">
                    <asp:Label ID="lblApellidoPaciente" runat="server" Text="Apellido del paciente:" CssClass="lbl" />
                    <asp:TextBox ID="txtApellidoPaciente" runat="server" CssClass="txt" ReadOnly="True" />
                </div>
            </div>
            <div>
                <asp:Button ID="btnAgregarTurno" runat="server" Text="Agregar turno" CssClass="btn" OnClick="btnAgregarTurno_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelar_Click" />
                <asp:Label ID="lblTurnoExistente" runat="server" ForeColor="Red" />
            </div>
        </div>
    </form>
</body>
</html>
