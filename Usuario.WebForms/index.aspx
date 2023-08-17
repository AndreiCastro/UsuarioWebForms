<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Usuario.WebForms.index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtId" runat="server" Visible="False" ></asp:TextBox>
    <div>
        <asp:Label ID="lblNome" runat="server" Text="Nome:" Font-Bold="False" Font-Overline="False"></asp:Label>&nbsp
        <asp:TextBox ID="txtNome" runat="server" Width="337px" style="margin-left: 78px" ></asp:TextBox>
    </div>
    <br />
    <div>
        <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label>&nbsp
        <asp:TextBox ID="txtEmail" runat="server" style="margin-left: 74px" Width="337px"></asp:TextBox>
    </div>
    <br />
    <div>
        <asp:Label ID="lblTelefone" runat="server" Text="Telefone:"></asp:Label> &nbsp   
        <asp:TextBox ID="txtTelefone" runat="server" style="margin-left: 57px" Width="140px"></asp:TextBox>
    </div>        
    <br />
    <div>
        <asp:Label ID="lblMae" runat="server" Text="Nome da Mãe:"></asp:Label> &nbsp
        <asp:TextBox ID="txtMae" runat="server" style="margin-left: 21px" Width="337px"></asp:TextBox>
    </div>    
    <br />
    <div>
        <asp:Label ID="lblPai" runat="server" Text="Nome do Pai:"></asp:Label> &nbsp
        <asp:TextBox ID="txtPai" runat="server" style="margin-left: 29px" Width="337px"></asp:TextBox>
    </div>    
    <br />
    <div>
        <asp:Label ID="lblDocumento" runat="server" Text="Documento:"></asp:Label> &nbsp   
        <asp:TextBox ID="txtDocumento" runat="server" style="margin-left: 38px" Width="140px"></asp:TextBox>
    </div>        
    <br />
    <div>
        <asp:Label ID="lblDataNascimento" runat="server" Text="Data Nascimento:"></asp:Label> &nbsp
        <asp:TextBox ID="txtDataNascimento" runat="server" style="margin-left: 2px" Width="140px"></asp:TextBox>
    </div>
    <div style="margin: 20px 0px 0px 270px">
        <asp:Button ID="btnInserir" runat="server" Text="Inserir" OnClick="btnInserir_Click" /> &nbsp
        <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" Visible="False"/> &nbsp
        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" Visible="False"/> &nbsp
        <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
    </div>
    <br />
    <div>
        <asp:Label ID="lblMsg" runat="server" Visible="False" ForeColor="Red" ></asp:Label> &nbsp   
    </div>
    <br />
    <asp:Label ID="lblListaUsuarios" runat="server" Text="Lista de Usuários" Font-Bold="True" Font-Size="Large"></asp:Label>
    <asp:GridView ID="GridUsuario" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="958px" Height="272px" 
                  Style="margin-top: 5px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridUsuario_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="true" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
            <asp:BoundField DataField="NomeMae" HeaderText="Nome Mãe" />
            <asp:BoundField DataField="NomePai" HeaderText="Nome Pai" />
            <asp:BoundField DataField="Documento" HeaderText="Documento" />
            <asp:BoundField DataField="DataNascimento" HeaderText="Data de Nascimento" DataFormatString="{0:dd-MM-yyyy}"/>

            <asp:ButtonField Text="select" CommandName="select" />

        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
</asp:Content>
