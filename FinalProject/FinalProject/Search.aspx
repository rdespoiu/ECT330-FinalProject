<%@ Page Title="" Language="C#" MasterPageFile="~/Actions.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="FinalProject.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTop" runat="server">
    <asp:Label runat="server" ID="lblSearch" Text="Found "></asp:Label>
    <hr />
    <asp:Table runat="server" ID="tblSearch"></asp:Table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>
