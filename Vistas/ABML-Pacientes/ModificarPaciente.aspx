<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarPaciente.aspx.cs" Inherits="Vistas.ABML_Pacientes.ModificarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Modificar Paciente - Clinica G21</title>
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

        .txt, .ddl {
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
        }

        .division {
            width: calc(32% - 10px);
            margin-bottom: 10px;
        }

        .divisionAux {
            width: 100%;
            display: flex;
            flex-wrap: wrap;
            align-items: center;
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
            font-size: 12px;
            color: red;
            margin-bottom: 5px;
        }

        #btnBuscarIdPaciente {
            margin-top: 18px;
            margin-left: 15px;
        }

        #lblTextVacio {
            margin-top: 18px;
        }

        #rfvIdPaciente {
            margin-top: 18px;
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
                <h2>Modificar Paciente</h2>
            </div>
            <div class="grupoAux">
                <div class="divisionAux">
                    <div style="width: 30%; display: flex; flex-direction: column; align-items: flex-start;">
                        <asp:Label ID="lblIdPaciente" runat="server" Text="ID del paciente:" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtIdPaciente" runat="server" CssClass="txt"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnBuscarIdPaciente" runat="server" Text="Buscar" CssClass="btn"  style="width: auto;" OnClick="btnBuscarIdPaciente_Click" />
                    <asp:Label runat="server" ID="lblTextVacio" CssClass="lblError" />
                    <asp:RequiredFieldValidator ID="rfvIdPaciente" runat="server" ControlToValidate="txtIdPaciente" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revIdPaciente" runat="server" ControlToValidate="txtIdPaciente"
                        ErrorMessage="Formato inválido" ValidationExpression="^[0-9]*$" CssClass="lblError"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="grupo" id="ingresos" runat="server">
                <div class="division">
                    <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                </div>
                <div class="division">
                    <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="ddl" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="division">
                    <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="txtNacionalidad" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre"
                        ErrorMessage="Formato inválido" ValidationExpression="^[a-zA-Z\s]+$" CssClass="lblError"></asp:RegularExpressionValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido"
                        ErrorMessage="Formato inválido" ValidationExpression="^[a-zA-Z\s]+$" CssClass="lblError"></asp:RegularExpressionValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Nacimiento:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="txt" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblDNI" runat="server" Text="DNI:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI"
                        ErrorMessage="Formato inválido" ValidationExpression="^[0-9]+$" CssClass="lblError"></asp:RegularExpressionValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblSexo" runat="server" Text="Sexo:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlSexo" runat="server" CssClass="ddl">
                        <asp:ListItem Value="M">Masculino</asp:ListItem>
                        <asp:ListItem Value="F">Femenino</asp:ListItem>
                        <asp:ListItem Value="O">Otro</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="division">
                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                   
                </div>
                <div class="division">
                    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono"
                        ErrorMessage="Formato inválido" ValidationExpression="^[0-9]{8,10}$" CssClass="lblError"></asp:RegularExpressionValidator>
                </div>
            </div>
            <asp:Label runat="server" ID="lblMensaje" CssClass="lblOk" />
            <div>
                <asp:Button ID="btnModificarPaciente" runat="server" Text="Modificar Paciente" CssClass="btn" OnClick="btnModificarPaciente_Click" />
                <asp:Button ID="btnListado" runat="server" Text="Listado de Pacientes" CssClass="btn" OnClick="btnListado_Click" CausesValidation="false"/>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelar_Click" CausesValidation="false"/>
            </div>
        </div>
    </form>
</body>
</html>
