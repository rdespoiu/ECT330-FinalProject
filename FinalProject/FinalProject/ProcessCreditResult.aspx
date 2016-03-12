<%@ Page Title="" Language="C#" MasterPageFile="~/Actions.Master" AutoEventWireup="true" CodeBehind="ProcessCreditResult.aspx.cs" Inherits="FinalProject.ProcessCreditResult1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/CSS/results.css"
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    <asp:Label ID="lblPageName" runat="server" Text="CHECKOUT SUCCESSFUL"></asp:Label>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cphTop" runat="server">

    <div id="resultsContent">

        <div id="resultsContentTop">
            <asp:Label ID="lblStatus" runat="server" Text="Transaction approved"></asp:Label>
        </div>

        <div id="resultsContentMid">
            <asp:Label ID="lblShipping" runat="server" Text="Ship status"></asp:Label>
            <br />
            <asp:Label ID="lblDelivery" runat="server" Text="Delivery time"></asp:Label>
            <br />
            <asp:Label ID="lblWarning" runat="server" Text="Warning"></asp:Label>
            <br /><br />
            <asp:Label ID="lblConfirmationEmail" runat="server" Text="You should receive an order confirmation shortly at Heisenberg@Bluesky.com"></asp:Label>
        </div>

        <div id="resultsContentBottom">
            <asp:Button ID="btnKeepShopping" runat="server" Text="Okay, let me shop some more" CssClass="shopButton" OnClick="btnKeepShopping_Click" />
        </div>

    </div>
    
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
    <div id="randomFact">
        <asp:Label ID="lblRandomFact" runat="server" Text="Did you know? Deer can jump 20 feet!"></asp:Label>
    </div>
    
</asp:Content>
