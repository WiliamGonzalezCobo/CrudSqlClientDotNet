<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrudForm.aspx.cs" Inherits="CRUD.WebAplication.CrudForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manejo de CRUD</title>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>


</head>
<body>
    <section class="container">
    <form id="form1" runat="server" role="form">
        <div>
            <h1>Gestion de Bandas</h1
        </div>

        <div class="form-group">
        <asp:Label
            ID="lblIdBanda"
            runat="server"
            Text="Id"
            AssociatedControlID="txtIdBanda">
        </asp:Label>

            <asp:TextBox
                ID="txtIdBanda"
                runat="server"
                class="form-control">
            </asp:TextBox>

        <asp:CompareValidator
            ID="CVidBanda"
            runat="server"
            Type="Integer"
            ForeColor="red"
            ControlToValidate="txtIdBanda"
            Operator="DataTypeCheck"
            ErrorMessage="El campo debe ser Numerico"
            SetFocusOnError="true" 
            ValidationGroup="VGroupId">

        </asp:CompareValidator>

        <asp:RequiredFieldValidator
            ID="RFVidBAnda"
            runat="server"
            ErrorMessage="Campo Id requerido"
            ForeColor="Red"
            SetFocusOnError="True"
            ControlToValidate="txtIdBanda"
            ValidationGroup="VGroupId">
        </asp:RequiredFieldValidator>

          <asp:RequiredFieldValidator
            ID="RFVid2"
            runat="server"
            ErrorMessage="Campo Id requerido"
            ForeColor="Red"
            SetFocusOnError="True"
            ControlToValidate="txtIdBanda"
            ValidationGroup="GVPersonal">
        </asp:RequiredFieldValidator>
        </div>
        
        <br />
        <div class="form-group">
        <asp:Label
            ID="lblNombre"
            runat="server"
            AssociatedControlID="txtNombre"
            Text="Nombre">
            
        </asp:Label>
        <asp:TextBox
            ID="txtNombre"
            runat="server"
            class="form-control">

        </asp:TextBox>

        <asp:RequiredFieldValidator
            ID="RFVNombre"
            runat="server"
            ControlToValidate="txtNombre"
            ForeColor="Red"
            ErrorMessage="Campo Nombre Requerido"
            ValidationGroup="GVPersonal"
            SetFocusOnError="True">

        </asp:RequiredFieldValidator>
        </div>
        <br />
        <div class="form-group">
        <asp:Label
            ID="lblTipo"
            runat="server"
            Text="Tipo"
            AssociatedControlID="txtTipo">
        </asp:Label>

        <asp:TextBox
            ID="txtTipo"
            runat="server"
            class="form-control">

        </asp:TextBox>

        <asp:RequiredFieldValidator
            ID="RFVTipo"
            runat="server"
            ControlToValidate="txtTipo"
            ForeColor="Red"
            ValidationGroup="GVPersonal"
            ErrorMessage="Campo Tipo Requerido"
            SetFocusOnError="True">
            
        </asp:RequiredFieldValidator>
            </div>
        <br />

        <asp:Button
            ID="btnBuscar"
            runat="server"
            OnClick="btnBuscar_Click"
            Text="Buscar"
            ValidationGroup="VGroupId" 
            class="btn btn-default"/>

        <asp:Button
            ID="btnEliminar"
            runat="server"
            OnClick="btnEliminar_Click"
            Text="Eliminar"
            ValidationGroup="VGroupId" 
            class="btn btn-default"/>

        <asp:Button
            ID="btnUpdate"
            runat="server"
            OnClick="btnUpdate_Click"
            Text="Update"
            ValidationGroup="GVPersonal"
             class="btn btn-default"/>
        <asp:Button
            ID="btnCrear"
            runat="server"
            OnClick="btnCrear_Click"
            Text="Crear"
            ValidationGroup="GVCrear" 
            class="btn btn-default"/>
        <asp:Button
            ID="btnLimpiar"
            runat="server"
            OnClick="btnLimpiar_Click"
            Text="Limpiar" 
            class="btn btn-default"/>
        <br />

        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
       
        <br />
        <br />
        <asp:GridView ID="GrVBandas" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceBandas" AllowPaging="True" CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellSpacing="5" Width="753px">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Ibanda" HeaderText="Id" SortExpression="Ibanda" />
                <asp:BoundField DataField="StrNombre" HeaderText="Nombre" SortExpression="StrNombre" />
                <asp:BoundField DataField="StrTipo" HeaderText="Tipo" SortExpression="StrTipo" />
                <asp:ImageField AlternateText="ImagenField">
                </asp:ImageField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceBandas" runat="server" SelectMethod="readBandas" TypeName="CRUD.DAO.Model">
            <SelectParameters>
                <asp:Parameter Direction="Output" Name="Mensaje" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
   </section>
</body>
</html>
