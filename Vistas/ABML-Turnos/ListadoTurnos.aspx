<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoTurnos.aspx.cs" Inherits="Vistas.ABML_Turnos.ListadoTurnos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Listado de Turnos - Clinica G21</title>
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
            width: 32%;
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
                <asp:LinkButton ID="lnkPerfil" runat="server" CssClass="lnkbtn" OnClick="lnkPerfil_Click">Perfil</asp:LinkButton>
                <asp:LinkButton ID="lnkCerrarSesion" runat="server" CssClass="lnkbtn" OnClick="lnkCerrarSesion_Click">Cerrar Sesion</asp:LinkButton>
            </div>
        </div>
        <br />
        <br />
        <div class="contenedor">
            <div class="encabezado">
                <h2>Listado de Turnos</h2>
            </div>
            <div class="grupo">
                <div class="division">
                    <asp:Label ID="lblLegajoMedico" runat="server" Text="Legajo del Medico:" CssClass="lbl" />
                    <asp:TextBox ID="txtLegajoMedico" runat="server" CssClass="txt" Enabled="False" />
                </div>
                <div class="division">
                    <asp:Label ID="lblBuscarTurno" runat="server" Text="Buscar turno:" CssClass="lbl" />
                    <asp:TextBox ID="txtBuscarTurno" runat="server" CssClass="txt" />
                </div>
                <div class="division">
                    <asp:Label ID="lblCriterioBusqueda" runat="server" Text="Criterio de búsqueda:" CssClass="lbl" />
                    <asp:DropDownList ID="ddlCriterioBusqueda" runat="server" CssClass="txt" AutoPostBack="True" OnSelectedIndexChanged="ddlCriterioBusqueda_SelectedIndexChanged">
                        <asp:ListItem Value="Nombre">Nombre del Paciente</asp:ListItem>
                        <asp:ListItem Value="Fecha">Fecha</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="grupo">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBuscar_Click" />

            </div>
            <br />
            <asp:GridView runat="server" ID="gvTurnos" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" CssClass="txt" OnRowCommand="gvTurnos_RowCommand" OnPageIndexChanging="gvTurnos_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="ID Turno">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_CodigoTurno" runat="server" Text='<%# Bind("CodigoTurno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Especialidad">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Especialidad" runat="server" Text='<%# Bind("Especialidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Paciente">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Paciente" runat="server" Text='<%# Bind("Paciente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Dia" runat="server" Text='<%# Eval("Dia", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hora">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Hora" runat="server" Text='<%# Eval("Dia", "{0:HH:mm tt}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Estado" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" CommandName="observaciones" Text="Observaciones" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
