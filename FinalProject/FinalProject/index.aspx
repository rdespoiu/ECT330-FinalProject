<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FinalProject.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="index.css">
    <link href='https://fonts.googleapis.com/css?family=Open+Sans+Condensed:300|Lora|Josefin+Sans|Source+Sans+Pro|Open+Sans|Roboto' rel='stylesheet' type='text/css'>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script type="text/javascript" src="index.js"></script>

    <title>COMPANY NAME HERE</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="mainContent">
            <div id="menuBar">
                <!--For mockup purposes-->
                <ul id="navContent">
                    <li>LOGO HERE</li>
                    <li><a href="#">Climbing</a></li>
                    <li><a href="#">Hiking</a></li>
                    <li><a href="#">Apparel</a></li>
                    <li><a href="#">Customer Photos</a></li>
                    <li><a href="#">Your Account</a></li> <!--This can be changed to an ASP method so that it shows your name or something when you're logged in -->
                    <li><a href="#">Shopping Cart</a></li> 
                    <li><asp:TextBox runat="server" ID="txtSearchBar" Placeholder="Search" CssClass="searchBox"></asp:TextBox></li>
                </ul>
            </div>

            <div id="featuredProducts">
                <div id="top">
                    <div id="leftFeatured">
                        <asp:Image ID="imgLeftFeatured" runat="server" ImageUrl="/Assets/climber1.jpg" CssClass="leftFeaturedImg" />
                        <p id="leftFeaturedText"><a href="#">Featured Product 1</a></p>
                    </div>

                    <div id="rightFeatured">
                        <asp:Image ID="imgRightFeatured" runat="server" ImageUrl="/Assets/climber1.jpg" CssClass="rightFeaturedImg" />
                        <p id="rightFeaturedText"><a href="#">Featured Product 2</a></p>
                    </div>
                </div>
                
                <div id="bottom">
                    <div id="bottomOne">
                        <asp:Image ID="imgBottomOne" runat="server" ImageUrl="/Assets/greenlandscape.jpg" CssClass="bottomOneImg" />
                        <p id="bottomOneFeaturedText"><a href="#">Featured Product 3</a></p>
                    </div>

                    <div id="bottomTwo">
                        <asp:Image ID="imgBottomTwo" runat="server" ImageUrl="/Assets/greenlandscape.jpg" CssClass="bottomTwoImg" />
                        <p id="bottomTwoFeaturedText"><a href="#">Featured Product 4</a></p>
                    </div>

                    <div id="bottomThree">
                        <asp:Image ID="imgBottomThree" runat="server" ImageUrl="/Assets/greenlandscape.jpg" CssClass="bottomThreeImg" />
                        <p id="bottomThreeFeaturedText"><a href="#">Featured Product 5</a></p>
                    </div>

                </div>



            </div>
        </div>
    </form>
</body>
</html>
