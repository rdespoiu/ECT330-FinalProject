<%@ Page Title="" Language="C#" MasterPageFile="~/ProductsMaster.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FinalProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    CLIMBING
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphCategories" runat="server">
    <asp:CheckBox ID="chkShoes" runat="server" Checked="false" />    
    <asp:Label ID="lblShoes" runat="server" Text="Climbing Shoes"></asp:Label>
    <br />
    <asp:CheckBox ID="chkHarnesses" runat="server" Checked="false" />
    <asp:Label ID="lblHarnesses" runat="server" Text="Harnesses"></asp:Label>
    <br />
    <asp:CheckBox ID="chkRopes" runat="server" Checked="false" />
    <asp:Label ID="lblRopes" runat="server" Text="Ropes"></asp:Label>
    <br />
    <asp:CheckBox ID="chkProtection" runat="server" Checked="false" />
    <asp:Label ID="lblProtection" runat="server" Text="Protection"></asp:Label>
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphPrice" runat="server">
    <asp:CheckBox ID="chkRange3040" runat="server" Checked="false" />
    <asp:Label ID="lblRange3040" runat="server" Text="$30 - $40"></asp:Label>
    <br />
    <asp:CheckBox ID="chk4050" runat="server" Checked="false" />
    <asp:Label ID="lblRange4050" runat="server" Text="$40 - $50"></asp:Label>    
    <br />
    <asp:CheckBox ID="chk5060" runat="server" Checked="false" />
    <asp:Label ID="lbl5060" runat="server" Text="$50 - $60"></asp:Label>    
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphRightDetail" runat="server">
    <!--Column order: Image, Product Name, Price, AddToCart-->
    <asp:Table ID="tblProducts" runat="server">
        <asp:TableRow>
            <asp:TableCell><img src="/Assets/testshoe.jpg" /></asp:TableCell>
            <asp:TableCell><a href="#">Sportiva TC Pro Rock Shoes</a></asp:TableCell>
            <asp:TableCell>$180.00</asp:TableCell>
            <asp:TableCell><asp:Button ID="btnAdd" runat="server" Text="Add To Cart" CssClass="addToCartButton" /></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell><img src="/Assets/testshoe2.jpg" /></asp:TableCell>
            <asp:TableCell><a href="#">Scarpa Origin Rock Shoes</a></asp:TableCell>
            <asp:TableCell>$89.00</asp:TableCell>
            <asp:TableCell><asp:Button ID="btnAdd2" runat="server" Text="Add To Cart" CssClass="addToCartButton" /></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell><img src="/Assets/testrope.jpg" /></asp:TableCell>
            <asp:TableCell><a href="#">Mammut Gravity Classic 10.2mm x 60mm Rope</a></asp:TableCell>
            <asp:TableCell>$159.95</asp:TableCell>
            <asp:TableCell><asp:Button ID="btnAdd3" runat="server" Text="Add To Cart" CssClass="addToCartButton" /></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell><img src="/Assets/testrope2.jpg" /></asp:TableCell>
            <asp:TableCell><a href="#">Sterling Evolution VR-10 10.2mm x 60mm Rope</a></asp:TableCell>
            <asp:TableCell>$152.95</asp:TableCell>
            <asp:TableCell><asp:Button ID="btnAdd4" runat="server" Text="Add To Cart" CssClass="addToCartButton" /></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell><img src="/Assets/testcarabiner.jpg" /></asp:TableCell>
            <asp:TableCell><a href="#">Omega Pacific ISO Locking Standard Screwgate Carabiner</a></asp:TableCell>
            <asp:TableCell>$10.25</asp:TableCell>
            <asp:TableCell><asp:Button ID="btnAdd5" runat="server" Text="Add To Cart" CssClass="addToCartButton" /></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell><img src="/Assets/testcarabiner2.jpg" /></asp:TableCell>
            <asp:TableCell><a href="#">Metolius Element Locking Carabiner - BLack</a></asp:TableCell>
            <asp:TableCell>$9.95</asp:TableCell>
            <asp:TableCell><asp:Button ID="btnAdd6" runat="server" Text="Add To Cart" CssClass="addToCartButton" /></asp:TableCell>
        </asp:TableRow>

    </asp:Table>
</asp:Content>
