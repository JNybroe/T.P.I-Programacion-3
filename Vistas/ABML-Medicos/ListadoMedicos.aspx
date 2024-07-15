<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoMedicos.aspx.cs" Inherits="Vistas.ListadoMedicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado de Médicos - Clinica G21</title>
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
                <h2>Listado de Médicos</h2>
            </div>
            <div class="grupo">
                <div class="division">
                    <asp:Label ID="lblBuscarMedico" runat="server" Text="Buscar médico:" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txtBuscarMedico" runat="server" CssClass="txt"></asp:TextBox>
                </div>
                <div class="division">
                    <asp:Label ID="lblCriterioBusqueda" runat="server" Text="Criterio de búsqueda:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlCriterioBusqueda" runat="server" CssClass="txt">
                        <asp:ListItem Value="legajo">Legajo</asp:ListItem>
                        <asp:ListItem Value="especialidad">Especialidad</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
               <div class="grupo">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBuscar_Click"/>
                    <asp:Button ID="btnVolver" runat="server" Text="Volver al inicio" CssClass="btn" OnClick="btnVolver_Click"/>
                </div> <br/>
            <asp:GridView ID="gvListadoMedicos" runat="server" CssClass="txt" AllowPaging="True" PageSize="5"
                OnPageIndexChanging="gvListadoMedicos_PageIndexChanging"  AutoGenerateColumns="False" OnRowCommand="gvListadoMedicos_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Legajo">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_legajo" runat="server" Text='<%# Bind("Legajo") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Especialidad">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Especialidad" runat="server" Text='<%# Bind("Especialidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" CommandName="eventoEditar" Text="Modificar" />
                    <asp:ButtonField ButtonType="Button" CommandName="eventoBaja" Text="Eliminar" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
