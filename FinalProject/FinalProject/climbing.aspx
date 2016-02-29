<%@ Page Title="" Language="C#" MasterPageFile="~/ProductsMaster.Master" AutoEventWireup="true" CodeBehind="climbing.aspx.cs" Inherits="FinalProject.climbing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    <p>CLIMBING</p>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cphCategories" runat="server">
    <!--Add Categories to Left Hand Options Menu-->

    <asp:CheckBox ID="chkShoes" runat="server" Checked="false" />    
    <asp:Label ID="lblShoes" runat="server" Text="Climbing Shoes"></asp:Label>
    <br />
    <asp:CheckBox ID="chkHarnesses" runat="server" Checked="false" />    
    <asp:Label ID="lblHarnesses" runat="server" Text="Harnesses"></asp:Label>
    <br />
    <asp:CheckBox ID="chkRopes" runat="server" Checked="false" />    
    <asp:Label ID="lblRopes" runat="server" Text="Ropes"></asp:Label>
    <br />
    <asp:CheckBox ID="chkCarabiners" runat="server" Checked="false" />    
    <asp:Label ID="lblCarabiners" runat="server" Text="Carabiners"></asp:Label>
    <br />
    <asp:CheckBox ID="chkBelay" runat="server" Checked="false" />    
    <asp:Label ID="lblBelay" runat="server" Text="Belay Devices"></asp:Label>
    <br />
    <asp:CheckBox ID="chkQuickdraws" runat="server" Checked="false" />    
    <asp:Label ID="lblQuickdraws" runat="server" Text="Quickdraws"></asp:Label>
    <br />
    <asp:CheckBox ID="chkHelmets" runat="server" Checked="false" />    
    <asp:Label ID="lblHelmets" runat="server" Text="Helmets"></asp:Label>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphPrice" runat="server">
    <!--Add Price Ranges to Left Hand Options Menu-->

    <asp:CheckBox ID="chkRangeZeroFifty" runat="server" Checked="false" />
    <asp:Label ID="lblRangeZeroFifty" runat="server" Text="$0 - $50"></asp:Label>
    <br />
    <asp:CheckBox ID="chkRangeFiftyOneHundred" runat="server" Checked="false" />
    <asp:Label ID="lblRangeFiftyOneHundred" runat="server" Text="$50 - $100"></asp:Label>
    <br />
    <asp:CheckBox ID="chkRangeOneHundredTwoHundred" runat="server" Checked="false" />
    <asp:Label ID="lblRangeOneHundredTwoHundred" runat="server" Text="$100 - $200"></asp:Label>
    <br />
    <asp:CheckBox ID="chkRangeTwoHundredPlus" runat="server" Checked="false" />
    <asp:Label ID="lblRangeTwoHundredPlus" runat="server" Text="$200+"></asp:Label>
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="cphRightDetail" runat="server">
    <!--Uses table to display products. Will populate from backend DB tables-->
    <!--Column order: Image, Product Name, Price, AddToCart-->
    <!--Header cells are not necessary-->
    <!--DELETE INITIAL ROW, THIS IS FOR TESTING PURPOSES ONLY-->
    <!--<asp:TableCell><img src="/Assets/testshoe.jpg" /></asp:TableCell>
            <asp:TableCell><a href="product.aspx">Sportiva TC Pro Rock Shoes</a></asp:TableCell>
            <asp:TableCell><a href="cart.aspx">$180.00</a></asp:TableCell>
            <asp:TableCell><asp:Button ID="btnAdd" runat="server" Text="Add To Cart" CssClass="addToCartButton" /></asp:TableCell>-->
    <asp:Table ID="tblProducts" runat="server">
        
    </asp:Table>
</asp:Content>
