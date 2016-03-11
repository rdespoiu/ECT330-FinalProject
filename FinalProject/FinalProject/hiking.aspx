<%@ Page Title="" Language="C#" MasterPageFile="~/ProductsMaster.Master" AutoEventWireup="true" CodeBehind="hiking.aspx.cs" Inherits="FinalProject.hiking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    <p><asp:Label ID="lblPageName" runat="server" Text="HIKING"></asp:Label></p>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cphCategories" runat="server">
    <!--Add Categories to Left Hand Options Menu-->

    <asp:CheckBox ID="chkPacks" runat="server" Checked="false" Text="Packs" AutoPostBack="true" OnCheckedChanged="checkBoxChanged" />    
    <br />
    <asp:CheckBox ID="chkSleepingBags" runat="server" Checked="false" Text="Sleeping Bags" AutoPostBack="true" OnCheckedChanged="checkBoxChanged" />    
    <br />
    <asp:CheckBox ID="chkHikingBoots" runat="server" Checked="false" Text="Hiking Boots" AutoPostBack="true" OnCheckedChanged="checkBoxChanged" />    
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphPrice" runat="server">
    <!--Add Price Ranges to Left Hand Options Menu-->

    <asp:CheckBox ID="chkRangeZeroFifty" runat="server" Checked="false" Text="$0 - $50" AutoPostBack="true" OnCheckedChanged="priceCheckBoxChanged" />
    <br />
    <asp:CheckBox ID="chkRangeFiftyOneHundred" runat="server" Checked="false" Text="$50 - $100" AutoPostBack="true" OnCheckedChanged="priceCheckBoxChanged" />
    <br />
    <asp:CheckBox ID="chkRangeOneHundredTwoHundred" runat="server" Checked="false" Text="$100 - $200" AutoPostBack="true" OnCheckedChanged="priceCheckBoxChanged" />
    <br />
    <asp:CheckBox ID="chkRangeTwoHundredPlus" runat="server" Checked="false" Text="$200+" AutoPostBack="true" OnCheckedChanged="priceCheckBoxChanged" />
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="cphRightDetail" runat="server">

    <asp:Table ID="tblProducts" runat="server">
        
    </asp:Table>

</asp:Content>
