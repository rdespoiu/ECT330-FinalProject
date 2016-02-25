<%@ Page Title="" Language="C#" MasterPageFile="~/ProductsMaster.Master" AutoEventWireup="true" CodeBehind="apparel.aspx.cs" Inherits="FinalProject.apparel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    <p>APPAREL</p>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cphCategories" runat="server">
    <!--Add Categories to Left Hand Options Menu-->

    <asp:CheckBox ID="chkJackets" runat="server" Checked="false" />    
    <asp:Label ID="lblJackets" runat="server" Text="Jackets"></asp:Label>
    <br />
    <asp:CheckBox ID="chkShirts" runat="server" Checked="false" />    
    <asp:Label ID="lblShirts" runat="server" Text="Shirts"></asp:Label>
    <br />
    <asp:CheckBox ID="chkPants" runat="server" Checked="false" />    
    <asp:Label ID="lblPants" runat="server" Text="Pants"></asp:Label>
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
    <asp:Table ID="tblProducts" runat="server">
        <asp:TableRow>
            <asp:TableCell><img src="/Assets/testshoe.jpg" /></asp:TableCell>
            <asp:TableCell><a href="#">Sportiva TC Pro Rock Shoes</a></asp:TableCell>
            <asp:TableCell>$180.00</asp:TableCell>
            <asp:TableCell><asp:Button ID="btnAdd" runat="server" Text="Add To Cart" CssClass="addToCartButton" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</asp:Content>
