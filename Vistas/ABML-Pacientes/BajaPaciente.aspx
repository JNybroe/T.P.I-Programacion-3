<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaPaciente.aspx.cs" Inherits="Vistas.ABML_Pacientes.BajaPaciente" %>

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
            align-items: baseline;
            margin-bottom: 10px;
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
            <asp:Label ID="lblBarraNavegacion" runat="server" Text="Clínica G21" Font-Bold="True"></asp:Label>
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
                <h2>Baja de Paciente</h2>
            </div>
            <div class="grupoAux">
                <div class="divisionAux">
                    <div style="width: 48%; display: flex; flex-direction: column; align-items: flex-start; margin-bottom:auto;">
                        <asp:Label ID="lblDniPacienteBusqueda" runat="server" Text="DNI del Paciente:" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtDniPacienteBusqueda" runat="server" CssClass="txt"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBuscar_Click" style="width: auto;" />
                    <asp:Label runat="server" ID="lblErrorDNI" CssClass="lblError" />&nbsp;
                    <asp:RequiredFieldValidator ID="rfvErrorDNI" runat="server" ControlToValidate="txtDniPacienteBusqueda" CssClass="lblError" ErrorMessage="Este campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="grupo" id="ingresos" runat="server">
                <div class="division">
                    <asp:Label ID="lblID" runat="server" Text="ID del Paciente:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtID" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblNombrePaciente" runat="server" Text="Nombre:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtNombrePaciente" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblApellidoPaciente" runat="server" Text="Apellido:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtApellidoPaciente" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblTelefonoPaciente" runat="server" Text="Teléfono:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtTelefonoPaciente" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblDireccionPaciente" runat="server" Text="Dirección:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtDireccionPaciente" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblEmailPaciente" runat="server" Text="Email:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtEmailPaciente" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                </div>
            </div>
            <div><br />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Paciente" CssClass="btn" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnListado" runat="server" Text="Listado de Pacientes" CssClass="btn" CausesValidation="false" OnClick="btnListado_Click" />                
                <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn" OnClick="btnVolver_Click" CausesValidation="false" />
            </div>
            <div>
                <asp:Label Text="" ID="lblBajaCompleta" runat="server" CssClass="lblOk" />
                <asp:Label ID="lblError" runat="server" CssClass="lblError" />
            </div>
        </div>
    </form>
</body>
</html>
