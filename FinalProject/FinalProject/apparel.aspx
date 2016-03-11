<%@ Page Title="" Language="C#" MasterPageFile="~/ProductsMaster.Master" AutoEventWireup="true" CodeBehind="apparel.aspx.cs" Inherits="FinalProject.apparel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    <p><asp:Label ID="lblPageName" runat="server" Text="APPAREL"></asp:Label></p>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cphCategories" runat="server">
    <!--Add Categories to Left Hand Options Menu-->

    <asp:CheckBox ID="chkJackets" runat="server" Checked="false" Text="Jackets" AutoPostBack="true" OnCheckedChanged="checkBoxChanged" />    
    <br />
    <asp:CheckBox ID="chkShirts" runat="server" Checked="false" Text="Shirts" AutoPostBack="true" OnCheckedChanged="checkBoxChanged" />    
    <br />
    <asp:CheckBox ID="chkPants" runat="server" Checked="false" Text="Pants" AutoPostBack="true" OnCheckedChanged="checkBoxChanged" />    
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphPrice" runat="server">
    <!--Add Price Ranges to Left Hand Options Menu-->

    <asp:CheckBox ID="chkRangeZeroFifty" runat="server" Checked="false" Text="$0 - $50" OnCheckedChanged="priceCheckBoxChanged"  AutoPostBack="true" />
    <br />
    <asp:CheckBox ID="chkRangeFiftyOneHundred" runat="server" Checked="false" Text="$50 - $100" OnCheckedChanged="priceCheckBoxChanged"  AutoPostBack="true" />
    <br />
    <asp:CheckBox ID="chkRangeOneHundredTwoHundred" runat="server" Checked="false" Text="$100 - $200" OnCheckedChanged="priceCheckBoxChanged"  AutoPostBack="true" />
    <br />
    <asp:CheckBox ID="chkRangeTwoHundredPlus" runat="server" Checked="false" Text ="$200+" OnCheckedChanged="priceCheckBoxChanged"  AutoPostBack="true" />
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="cphRightDetail" runat="server">

    <asp:Table ID="tblProducts" runat="server">
        
    </asp:Table>

</asp:Content>
