<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaMedico.aspx.cs" Inherits="Vistas.BajaMedico" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Baja de Médicos - Clinica G21</title>
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

        .btnEliminar {
            width: 45%;
            padding: 10px;
            margin-left: 20px;
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

        .alineado {
            display: flex;
            align-items: center;
            justify-content: space-between;
        }

        .chk {
            margin-right: 10px;
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

        .lblError {
            font-size: 12px;
            color: red;
            margin-bottom: -10px;
        }

        .lblOk {
            text-align: center;
            font-size: 12px;
            color: green;
            margin-bottom: 10px;
        }

        .grupoAux {
            display: flex;
            flex-wrap: wrap;
        }

        .divisionAux {
            width: 100%;
            display: flex;
            flex-wrap: wrap;
            align-items: center;
        }

        #btnBuscar {
            margin-top: 18px;
            margin-left: 16px;
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
                <asp:LinkButton ID="lnkCerrarSesion" runat="server" CssClass="lnkbtn" OnClick="lnkCerrarSesion_Click">Cerrar Sesion</asp:LinkButton>
            </div>
        </div>
        <br />
        <br />
        <div class="contenedor">
            <div class="encabezado">
                <h2>Baja de Médico</h2>
            </div>
            <div class="grupoAux">
                <div class="divisionAux">
                    <div style="width: 48%; display: flex; flex-direction: column; align-items: flex-start; margin-bottom: auto;">
                        <asp:Label ID="lblLegajoMedico" runat="server" Text="Legajo:" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtLegajoMedico" runat="server" CssClass="txt"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBuscar_Click" Style="width: auto;" />
                    <asp:Label runat="server" ID="lblLegajoIncorrecto" CssClass="lblError" />&nbsp;
                        <asp:RequiredFieldValidator ID="rfvLegajoMedico" runat="server" ControlToValidate="txtLegajoMedico" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="grupo" id="ingresos" runat="server">
                <div class="division">
                    <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="txt" Enabled="False">
                    </asp:DropDownList>
                </div>
                <div class="division">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblDNI" runat="server" Text="DNI:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblIdentificadorUsuario" runat="server" Text="Identificador de Usuario:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtIdentificadorUsuario" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblPrivilegiosUsuario" runat="server" Text="Privilegios de Usuario:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtPrivilegiosUsuario" runat="server" CssClass="txt" Text="Medico" Enabled="false" />
                </div>
            </div>
            <div>
                <br />
                <asp:Button ID="btnEliminarMedico" runat="server" Text="Eliminar médico" CssClass="btn" OnClick="btnEliminarMedico_Click" />
                <asp:Button ID="btnListado" runat="server" Text="Listado de Medicos" CssClass="btn" CausesValidation="false" OnClick="btnListado_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelar_Click" CausesValidation="false" />
            </div>
            <div>
                <asp:CheckBox ID="chkConfirmarBaja" runat="server" Text="Confirmar baja del médico" CssClass="chk" Visible="False" />
                <asp:Button ID="btnConfirmarbaja" runat="server" Text="Aceptar" CssClass="btnEliminar" Visible="False" OnClick="btnConfirmarbaja_Click" />
                <div>
                    <asp:Label Text="" ID="lblBajaCompleta" runat="server" CssClass="lblOk" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
