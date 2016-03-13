<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="twitterTest.aspx.cs" Inherits="FinalProject.twitterTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Testing Twitter API</h1>

        <h1>Hello Twitter: Foloow us at</h1>



        <h3>LinkButton Example</h3>
      <asp:LinkButton id="LinkButton1" 
           Text="Click Me" 
           Font-Name="Verdana" 
           Font-Size="14pt" 
           OnClick="LinkButton_Click" 
           runat="server"/>


       <h1> <asp:HyperLink ID="test" NavigateUrl="https://twitter.com/TreelineAbove" Text="Follow @TreelineAbove" runat="server"></asp:HyperLink>
           </h1>
        <a href="https://twitter.com/TreelineAbove" class="twitter-follow-button" data-show-count="false" data-size="large">Follow @TreelineAbove</a>

        <script>window.twttr = (function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0],
      t = window.twttr || {};
    if (d.getElementById(id)) return t;
    js = d.createElement(s);
    js.id = id;
    js.src = "https://platform.twitter.com/widgets.js";
    fjs.parentNode.insertBefore(js, fjs);

    t._e = [];
    t.ready = function (f) {
        t._e.push(f);
    };

    return t;
}(document, "script", "twitter-wjs"));</script>

           Enter Search Term: <asp:TextBox ID="txtSearchTerm" runat="server"></asp:TextBox><asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
    <asp:Panel Visible="false" runat="server" ID="pnTwitterResults">
        <asp:Repeater runat="server" ID="rptTweets" >
            <HeaderTemplate>
                <h3>Tweets</h3>
                <table>
                    <tr>
                        <th>Tweet</th>
                        <th>Created Date</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("Text") %></td>
                    <td><%#Eval("CreatedAt") %></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                 <tr style="background-color:lightgray;">
                    <td><%#Eval("Text") %></td>
                    <td><%#Eval("CreatedAt") %></td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
          
        <br />

        Local Trends: <asp:DropDownList ID="drpTrends" runat="server" OnSelectedIndexChanged="drpTrends_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        <br />

        
          <asp:Repeater runat="server" ID="rptTwitterTrendResults" Visible="false" >
            <HeaderTemplate>
                <h3>Trend Results</h3>
                <table>
                    <tr>
                        <th>Tweet</th>
                        <th>Created Date</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("Text") %></td>
                    <td><%#Eval("CreatedAt") %></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                 <tr style="background-color:lightgray;">
                    <td><%#Eval("Text") %></td>
                    <td><%#Eval("CreatedAt") %></td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        
        
        <br />

    </asp:Panel>

    </div>
    </form>
</body>
</html>
