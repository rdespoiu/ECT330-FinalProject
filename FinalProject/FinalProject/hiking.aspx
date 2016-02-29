<%@ Page Title="" Language="C#" MasterPageFile="~/ProductsMaster.Master" AutoEventWireup="true" CodeBehind="hiking.aspx.cs" Inherits="FinalProject.hiking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    <p>HIKING</p>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cphCategories" runat="server">
    <!--Add Categories to Left Hand Options Menu-->

    <asp:CheckBox ID="chkPacks" runat="server" Checked="false" />    
    <asp:Label ID="lblPacks" runat="server" Text="Packs"></asp:Label>
    <br />
    <asp:CheckBox ID="chkSleepingBags" runat="server" Checked="false" />    
    <asp:Label ID="lblSleepingBags" runat="server" Text="Sleeping Bags"></asp:Label>
    <br />
    <asp:CheckBox ID="chkHikingBoots" runat="server" Checked="false" />    
    <asp:Label ID="lblHikingBoots" runat="server" Text="Hiking Boots"></asp:Label>
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
        
    </asp:Table>
</asp:Content>
