<%@ Page Title="" Language="C#" MasterPageFile="~/Actions.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="FinalProject.register" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphPageName" runat="server">
    <p><asp:Label ID="lblPageName" runat="server" Text="Register for a new account"></asp:Label></p>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cphTop" runat="server">
    <div id="registerContent">
        <div id="registerLeft">
            <asp:TextBox ID="txtFirstName" runat="server" Placeholder="First Name" CssClass="registerInput"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="reqFirstName" runat="server" ErrorMessage="First name is required!" ForeColor="Red" EnableClientScript="true" ControlToValidate="txtFirstName" CssClass="registerText"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtLastName" runat="server" Placeholder="Last Name" CssClass="registerInput"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="reqLastName" runat="server" ErrorMessage="Last name is required!" ForeColor="Red" EnableClientScript="true" ControlToValidate="txtLastName" CssClass="registerText"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtBillingAddress" runat="server" Placeholder="Billing Address" CssClass="registerInput"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="reqBillingAddress" runat="server" ErrorMessage="Billing address is required!" ForeColor="Red" EnableClientScript="true" ControlToValidate="txtBillingAddress" CssClass="registerText"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtShippingAddress" runat="server" Placeholder="Shipping Address" CssClass="registerInput"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="reqShippingAddress" runat="server" ErrorMessage="Shipping address is required!" ForeColor="Red" EnableClientScript="true" ControlToValidate="txtShippingAddress" CssClass="registerText"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID ="txtCity" runat="server" Placeholder="City" CssClass="registerInput"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="reqCity" runat="server" ErrorMessage="City is required!" ForeColor="Red" EnableClientScript="true" ControlToValidate="txtCity" CssClass="registerText"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtZip" runat="server" Placeholder="Zip Code" CssClass="registerInput"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="reqZip" runat="server" ErrorMessage="Zip code is required!" ForeColor="Red" EnableClientScript="true" ControlToValidate="txtZip" CssClass="registerText"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="ddlState" runat="server" CssClass="registerInput">
                <asp:ListItem Text="Select a State"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:RequiredFieldValidator ID="reqState" runat="server" ControlToValidate="ddlState" InitialValue="Select a State" ErrorMessage="You must choose a state!" EnableClientScript="true" CssClass="registerText" ForeColor="Red"></asp:RequiredFieldValidator>
            
        </div>


    
        <div id="registerRight">
            <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email Address" CssClass="registerInput"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="reqEmail" runat="server" ErrorMessage="Email is required!" ForeColor="Red" EnableClientScript="true" ControlToValidate="txtEmail" CssClass="registerText"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtEmailConf" runat="server" Placeholder="Confirm your email address" CssClass="registerInput"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="reqEmailConf" runat="server" ErrorMessage="Please confirm your email address" ForeColor="Red" EnableClientScript="true" ControlToValidate="txtEmailConf" CssClass="registerText"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvEmails" runat="server" ControlToCompare="txtEmail" ControlToValidate="txtEmailConf" ErrorMessage="Your email addresses do not match" EnableClientScript="true" ForeColor="Red" CssClass="registerText"></asp:CompareValidator>
            <br />
            <asp:TextBox ID="txtUsername" runat="server" Placeholder="Choose a username" CssClass="registerInput"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="reqUsername" runat="server" ErrorMessage="Please enter a username!" ForeColor="Red" EnableClientScript="true" ControlToValidate="txtUsername" CssClass="registerText"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtPass1" runat="server" Placeholder="Choose a password" TextMode="Password" CssClass="registerInput"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="reqPass1" runat="server" ErrorMessage="Please choose a password!" ForeColor="Red" EnableClientScript="true" ControlToValidate="txtPass1" CssClass="registerText"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtPass2" runat="server" Placeholder="Confirm your password" TextMode="Password" CssClass="registerInput"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="reqPass2" runat="server" ErrorMessage="Please confirm your password!" ForeColor="Red" EnableClientScript="true" ControlToValidate="txtPass2" CssClass="registerText"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvPasswords" runat="server" ErrorMessage="Your passwords do not match!" ControlToCompare="txtPass1" ControlToValidate="txtPass2" EnableClientScript="true" ForeColor="Red" CssClass="registerText"></asp:CompareValidator>
            <br />
            <asp:Label ID="lblNewsletter" runat="server" Text="Would you like to receive news and exclusive deals?" CssClass="registerText"></asp:Label>
            <br />
            <asp:CheckBox ID="chkNewsletter" runat="server" Checked="true" />
            <asp:Label ID="lblYes" runat="server" Text="YES! Send me those deals!" CssClass="registerText"></asp:Label>
        </div>
    </div>
    

    







</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">

    <div id="bottomLeft">

    </div>

    <div id="bottomRight">
        <asp:Button ID="btnSubmit" runat="server" Text="Register" OnClick="btnSubmit_Click" CssClass="actionButton" />
    </div>
    
    
</asp:Content>
