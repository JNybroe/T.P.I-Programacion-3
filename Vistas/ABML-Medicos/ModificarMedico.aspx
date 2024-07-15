<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarMedico.aspx.cs" Inherits="Vistas.ModificarMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Modificacion de Médico - Clinica G21</title>
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
        #btnBuscarLegajo {
            margin-top: 18px;
            margin-left: 15px;
        }
        #lblTextVacio {
            margin-top: 18px;
        }
        #rfvLegajo{
            margin-top: 18px;
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
        .lblError {
            font-size: 12px;
            color: red;
            margin-bottom: 5px;
        }
        .lblOk {
            text-align: center;
            color: green;
            margin-bottom: 10px;
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
        </div> <br /><br />
        <div class="contenedor">
            <div class="encabezado">
                <h2>Modificar Médico</h2>
            </div>
            <div class="grupoAux">
                <div class="divisionAux">
                    <div style="width: 30%; display: flex; flex-direction: column; align-items: flex-start;">
                        <asp:Label ID="lblLegajo" runat="server" Text="Legajo:" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtLegajo" runat="server" CssClass="txt" ></asp:TextBox>
                    </div>
                    <asp:Button ID="btnBuscarLegajo" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBuscarLegajo_Click" style="width: auto;" />
                    <asp:Label runat="server" ID="lblTextVacio" CssClass="lblError" />
                    <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revLegajo" runat="server" ControlToValidate="txtLegajo" ErrorMessage="Caracteres Alfanumericos" CssClass="lblError" ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator>    
                </div>
            </div>
            <div class="grupo" id="ingresos" runat="server">
                <div class="division">
                    <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                </div>
                <div class="division">
                    <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="ddl" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="division">
                    <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                </div>
                <div class="division">
                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Solo se admiten letras." CssClass="lblError" ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Solo se admiten letras." CssClass="lblError" ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblDNI" runat="server" Text="DNI:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" ErrorMessage="Solo números." CssClass="lblError" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblSexo" runat="server" Text="Sexo:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlSexo" runat="server" CssClass="ddl">
                        <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                        <asp:ListItem Value="F">Femenino</asp:ListItem>
                        <asp:ListItem Value="O">Otro</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="division">
                    <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="txtNacionalidad" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Nacimiento:" CssClass="lbl"></asp:Label>
                    <asp:TextBox runat="server" TextMode="Date" ID="txtFechaNacimiento" CssClass="txt" />
                    <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Solo números." CssClass="lblError" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="lbl"></asp:Label>
                    <asp:TextBox runat="server" TextMode="Email" ID="txtEmail" CssClass="txt" />
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" ControlToValidate="txtNombreUsuario" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
                <div class="division">
                    <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtContrasena" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" ControlToValidate="txtContrasena" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div>
                <asp:Label ID="lblOk" runat="server" CssClass="lblOk"></asp:Label>
            </div><br />
            <div>
                <asp:Button ID="btnModificarMedico" runat="server" Text="Modificar Médico" CssClass="btn" OnClick="btnModificarMedico_Click" />
                <asp:Button ID="btnListado" runat="server" Text="Listado de Medicos" CssClass="btn" OnClick="btnListado_Click" CausesValidation="false" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelar_Click" CausesValidation="false"/>
            </div>
        </div>
    </form>
</body>
</html>
