<%@ Page Title="" Language="C#" MasterPageFile="~/Actions.Master" AutoEventWireup="true" CodeBehind="FollowTwitter.aspx.cs" Inherits="FinalProject.FollowTwitter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    <p>
        <asp:Label ID="lblPageName" runat="server" Text="About Us"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTop" runat="server">
    <!-- add about us summary here
        -->
    <!--About us tag line
        “In mountaineering terms, the treeline is the “line” past which trees can no longer grow because of high altitude. Most difficult mountaineering ascents occur above the treeline.”
        -->
    <div class="aboutUs">
        <p>
            “In mountaineering terms, the treeline is the “line” past which trees can no longer grow because of high altitude. Most difficult mountaineering ascents occur above the treeline.”
        </p>
    </div>
    <br />
    <div class="summary">
        <asp:Table ID="tblAboutUs" GridLines="None" HorizontalAlign="Justify" runat="server">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <p>
                        We want all our customers to feel the thrill of reaching the treeline made possible with our products and strive to do so again, and again.
                        So follow us on Twitter to see some of our customer tweets and retweets or feel free to contact us at at weareabovetreeline@gmail.com.
                    </p>
                </asp:TableCell>
                <asp:TableCell>
                    <!-- Twitter card/button/trends -->
                    <!-- add contact information and twitter login  -->
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="https://twitter.com/TreelineAbove" Text="Follow @TreelineAbove" runat="server"></asp:HyperLink>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>
