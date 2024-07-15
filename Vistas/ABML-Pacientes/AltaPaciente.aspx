<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaPaciente.aspx.cs" Inherits="Vistas.ABML_Pacientes.AltaPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión de Pacientes - Clínica G21</title>
    <style>
        body, html {
            height: 100%;
            margin: 0;
            font-family: Arial, sans-serif;
        }

        .contenedor {
            padding: 20px;
            width: 600px;
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

        .grupoAux {
            display: flex;
            flex-wrap: wrap;
            align-items: baseline;
        }

        .division {
            width: 32%;
            margin-bottom: 10px;
        }

        .divisionAux {
            width: 48%;
            margin-bottom: 10px;
            display: flex;
            flex-direction: column;
            align-items: baseline;
        }

        #txtEmail {
            margin-right: 10px;
        }

        #txtDireccion {
            margin-left: 24px;
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

        .lblOk {
            text-align: center;
            font-size: 12px;
            color: green;
            margin-bottom: 5px;
        }

        .lblError {
            color: red;
            font-size: 12px;
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
                <h3>Alta de Paciente</h3>
            </div>
            <div class="grupo">
                <div class="division">
                    <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="txt" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="division">
                    <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="txt" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="division">
                    <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="txtNacionalidad" CssClass="lblError">Este campo es obligatorio</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="Solo se admiten letras." CssClass="lblError" ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" CssClass="lblError">Este campo es obligatorio</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Solo se admiten letras." CssClass="lblError" ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" CssClass="lblError">Este campo es obligatorio</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Solo se admiten letras." CssClass="lblError" ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:" CssClass="lbl"></asp:Label>
                    <asp:TextBox runat="server" TextMode="Date" ID="txtFechaNacimiento" CssClass="txt" />
                    <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" CssClass="lblError">Este campo es obligatorio</asp:RequiredFieldValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblDNI" runat="server" Text="DNI:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" CssClass="lblError">Este campo es obligatorio</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" ErrorMessage="Solo números." CssClass="lblError" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblSexo" runat="server" Text="Sexo:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlSexo" runat="server" CssClass="txt">
                        <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                        <asp:ListItem Value="F">Femenina</asp:ListItem>
                        <asp:ListItem Value="O">Otro</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="division">
                    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" CssClass="lblError">Este campo es obligatorio</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Solo números." CssClass="lblError" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="grupoAux">
                <div class="divisionAux">
                    <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" CssClass="lblError">Este campo es obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="divisionAux">
                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" CssClass="lblError">Este campo es obligatorio</asp:RequiredFieldValidator>
                </div>
            </div>
            <div>
                <asp:Button ID="btnAgregarPaciente" runat="server" Text="Agregar Paciente" CssClass="btn" OnClick="btnAgregarPaciente_Click" />
                <asp:Button ID="btnInicio" runat="server" Text="Volver al Inicio" CssClass="btn" OnClick="btnInicio_Click" CausesValidation="False" />
            </div>
            <div>
                <asp:Label ID="lblPacienteAgregado" runat="server" CssClass="lblOk"></asp:Label>
                <asp:Label ID="lblError" runat="server" CssClass="lblError"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
