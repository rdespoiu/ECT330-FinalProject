<%@ Page Title="" Language="C#" MasterPageFile="~/ProductDetail.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="FinalProject.product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphProductImage" runat="server">
    <!--Product image will go here. Should use an ASP image method and ppopulate it from DB tables. Current image is for testing only //RID-->
    <img src="/Assets/testshoe.jpg" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cphProductName" runat="server">
    <!--Product name will go here //RID-->
    <asp:Label ID="lblProductName" runat="server" Text="Hi! I'm a placeholder for product name!"></asp:Label>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphProductDescription" runat="server">
    <!--Product description will go here. Current text is for testing only //RID-->
    <asp:Label ID="lblProductDescription" runat="server" Text="And I'm a placeholder for product description! I will be populated from DB tables. You should probably delete me soon. SHE'S JUST A SMALL TOWN GIRL! LIVIN' IN A LOOOONELY WOOOORLD!"></asp:Label>
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="cphProductPrice" runat="server">
    <!--Product price will go here. It should probably be linked to quantity. Anytime a user updates their quantity, this should increase/decrease accordingly Current text is for testing only //RID-->
    <asp:Label ID="lblPrice" runat="server" Text="$1000 -- I'm a price tag!"></asp:Label>
</asp:Content>


<asp:Content ID="Content6" ContentPlaceHolderID="cphSize" runat="server">
    <!--Size options will go here. We may need a size table //RID-->
    <asp:DropDownList ID="ddlSize" runat="server">
        <asp:ListItem Text="Choose a size"></asp:ListItem>
    </asp:DropDownList>
</asp:Content>


<asp:Content ID="Content7" ContentPlaceHolderID="cphQuantity" runat="server">
    <!--Quantity options will go here. When a user tries to add to cart, if their chosen quantity > stock, it'll stop them. Otherwise the controls will be implemented at checkout //RID-->
    <asp:DropDownList ID="ddlQuantity" runat="server">
        <asp:ListItem Text="Choose a Quantity" Value="0"></asp:ListItem>
    </asp:DropDownList>
</asp:Content>


<asp:Content ID="Content8" ContentPlaceHolderID="cphAddToCart" runat="server">
    <!--Add item(s) to cart. This will need an onClick method //RID-->
    <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" CssClass="addToCartButton" />
</asp:Content>
