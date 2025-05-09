<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GoodsForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <asp:Label ID="lblId" runat="server" Text="ID" Visible="false"></asp:Label>
        <asp:TextBox ID="txtId" runat="server" Visible="false"></asp:TextBox><br />

        <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblCategory" runat="server" Text="Category:"></asp:Label>
        <asp:DropDownList ID="ddlCategory" runat="server">
            <asp:ListItem Text="Electronics" Value="Electronics" />
            <asp:ListItem Text="Furniture" Value="Furniture" />
            <asp:ListItem Text="Stationery" Value="Stationery" />
        </asp:DropDownList><br />

        <asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label>
        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblAvailability" runat="server" Text="Availability:"></asp:Label><br />
        <asp:RadioButton ID="rbAvailable" runat="server" Text="Available" GroupName="Availability" Checked="true" />
        <asp:RadioButton ID="rbNotAvailable" runat="server" Text="Not Available" GroupName="Availability" /><br />

        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /><br /><br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="True"></asp:GridView>
    </main>
</asp:Content>