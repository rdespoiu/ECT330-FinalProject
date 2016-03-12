<%@ Page Title="" Language="C#" MasterPageFile="~/Actions.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="FinalProject.checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/CSS/checkout.css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    <asp:Label ID="lblPageName" runat="server" Text="CHECKOUT"></asp:Label>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cphTop" runat="server">
    <div id="checkoutTop">
        <div id="checkoutLeft">
            <p><b>Shipping Address</b></p>
            <asp:Label ID="lblShippingAddress" runat="server" Text="123 Easy Street (Placeholder)"></asp:Label>
            <br />
            <asp:Label ID="lblShippingCity" runat="server" Text="Twentynine Palms (Placeholder)"></asp:Label>
            <br />
            <asp:Label ID="lblShippingState" runat="server" Text="California (Placeholder)"></asp:Label>
            <asp:Label ID="lblShippingZip" runat="server" Text="92278 (Placeholder)"></asp:Label>
        </div>

        <div id="checkoutRight">
            <p><b>Billing Address</b></p>
            <asp:Label ID="lblBillingAddress" runat="server" Text="123 Easy Street (Placeholder)"></asp:Label>
            <br />
            <asp:Label ID="lblBillingCity" runat="server" Text="Twentynine Palms (Placeholder)"></asp:Label>
            <br />
            <asp:Label ID="lblBillingState" runat="server" Text="California (Placeholder)"></asp:Label>
            <asp:Label ID="lblBillingZip" runat="server" Text="92278 (Placeholder)"></asp:Label>
        </div>

        
    </div>

    <div id="checkoutBottom">
        <p><b>YOUR ORDER</b></p>
        
        <asp:Table ID="tblOrderConfirmation" runat="server">
            <asp:TableHeaderRow>
                <asp:TableCell><b>Product Name</b></asp:TableCell>
                <asp:TableCell><b>Cost</b></asp:TableCell>
                <asp:TableCell><b>Quantity</b></asp:TableCell>
            </asp:TableHeaderRow>
        </asp:Table>    
    </div>

    
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
    <div id="checkoutConfirmBottom">

        <div id="checkoutConfirmBottomLeft">
            <asp:Label ID="lblTotal" runat="server"></asp:Label>
        </div>

        <div id="checkoutConfirmBottomRight">
            <asp:Button ID="btnPay" runat="server" Text="Pay by Credit Card" CssClass="payButton" OnClick="RedirectUser" />
        </div>

    </div>
</asp:Content>
