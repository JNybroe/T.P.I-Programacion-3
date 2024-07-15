<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoPacientes.aspx.cs" Inherits="Vistas.ABML_Pacientes.ListadoPacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado de Pacientes - Clinica G21</title>
    <style>
        body, html {
            height: 100%;
            margin: 0;
            font-family: Arial, sans-serif;
        }
        .contenedor {
            padding: 20px;
            width: 700px;
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
            padding: 10px;
            box-sizing: border-box;
        }
        .grupo {
            display: flex;
            justify-content: space-between;
            align-items: center; 
        }
        .division {
            width: 48%;
            margin-bottom: 10px;
        }
        .divisionAux {
            width: 100%;
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
        <br/><br/>
        <div class="contenedor">
            <div class="encabezado">
                <h2>Listado de Pacientes</h2>
            </div>
            <div class="grupo">
                <div class="division">
                    <asp:Label ID="lblBuscarPaciente" runat="server" Text="Buscar paciente:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtBuscarPaciente" runat="server" CssClass="txt"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblCriterioBusqueda" runat="server" Text="Criterio de búsqueda:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlCriterioBusqueda" runat="server" CssClass="txt">
                        <asp:ListItem Value="ID">ID</asp:ListItem>
                        <asp:ListItem Value="DNI">DNI</asp:ListItem>
                        <asp:ListItem Value="APELLIDO">Apellido</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="grupo">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBuscarPaciente_Click"/>
                <asp:Button ID="btnVolver" runat="server" Text="Volver al inicio" CssClass="btn" OnClick="btnVolver_Click"/>
            </div> 
            <br/>
            <div class="divisionAux">
                <asp:GridView ID="grdListaPacientes" runat="server" CssClass="txt" AllowPaging="True" PageSize="5"  AutoGenerateColumns="False" OnRowCommand="grdListaPacientes_RowCommand" OnPageIndexChanging="grdListaPacientes_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="DNI">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_DNI" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>  
                                <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_ID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Provincia">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Provincia" runat="server" Text='<%# Bind("Provincia") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Localidad">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Localidad" runat="server" Text='<%# Bind("Localidad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Button" CommandName="eventoEditar" Text="Modificar" />
                        <asp:ButtonField ButtonType="Button" CommandName="eventoBaja" Text="Eliminar" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
