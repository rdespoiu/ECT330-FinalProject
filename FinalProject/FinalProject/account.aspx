<%@ Page Title="" Language="C#" MasterPageFile="~/Actions.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="FinalProject.account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="account.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    <p><asp:Label ID="lblPageName" runat="server"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTop" runat="server">
    <div id="accountContent">
        <asp:HyperLink ID="lnkOrders" runat="server" Text="My Orders" NavigateUrl="orders.aspx"></asp:HyperLink>
        <br /><br />
        <asp:HyperLink ID="lnkCart" runat="server" Text="My Shopping Cart" NavigateUrl="cart.aspx"></asp:HyperLink>
        <br /><br />
        <asp:HyperLink ID="lnkEditInfo" runat="server" Text="Edit Information" NavigateUrl="editinfo.aspx"></asp:HyperLink>
        <br /><br />
        <asp:HyperLink ID="lnkSignOut" runat="server" Text="Sign Out" NavigateUrl="index.aspx?action=logout"></asp:HyperLink>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>
