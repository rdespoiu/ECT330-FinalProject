<%@ Page Title="" Language="C#" MasterPageFile="~/ProductsMaster.Master" AutoEventWireup="true" CodeBehind="climbing.aspx.cs" Inherits="FinalProject.climbing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    <p><asp:Label ID="lblPageName" runat="server" Text="CLIMBING"></asp:Label></p>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cphCategories" runat="server">
    <!--Add Categories to Left Hand Options Menu-->

    <asp:CheckBox ID="chkShoes" runat="server" Checked="false" Text="Climbing Shoes" AutoPostBack="true" OnCheckedChanged="checkBoxChanged" />    
    <br />
    <asp:CheckBox ID="chkHarnesses" runat="server" Checked="false" Text="Harnesses" OnCheckedChanged="checkBoxChanged" AutoPostBack="true" />    
    <br />
    <asp:CheckBox ID="chkRopes" runat="server" Checked="false" Text="Ropes" OnCheckedChanged="checkBoxChanged" AutoPostBack="true" />    
    <br />
    <asp:CheckBox ID="chkCarabiners" runat="server" Checked="false" Text="Carabiners" OnCheckedChanged="checkBoxChanged"  AutoPostBack="true" />    
    <br />
    <asp:CheckBox ID="chkBelay" runat="server" Checked="false" Text="Belay Devices" OnCheckedChanged="checkBoxChanged"  AutoPostBack="true" />    
    <br />
    <asp:CheckBox ID="chkQuickdraws" runat="server" Checked="false" Text="Quickdraws" OnCheckedChanged="checkBoxChanged"  AutoPostBack="true" />    
    <br />
    <asp:CheckBox ID="chkHelmets" runat="server" Checked="false" Text="Helmets" OnCheckedChanged="checkBoxChanged"  AutoPostBack="true" />   
    <br />
    <asp:CheckBox ID="chkCams" runat="server" Checked ="false" Text="Cams" OnCheckedChanged="checkBoxChanged" AutoPostBack="true" /> 
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
