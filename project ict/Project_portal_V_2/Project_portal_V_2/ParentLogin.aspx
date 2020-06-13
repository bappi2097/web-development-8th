<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogin.Master" AutoEventWireup="true" CodeBehind="ParentLogin.aspx.cs" Inherits="Project_portal_V_2.ParentLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
         <div class="row">
        
        <div class="col-md-6">
            <h2>Login</h2>
            <table>
                <tr>
                    <td>
                        <br /><br /><br />UserName 
                    </td>
                    <td>
                        <br /><br /><br /><asp:TextBox ID="txtLoginUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <br /><br />Password 
                    </td>
                    <td>
                        <br /><br /><asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                    <td>
                        <asp:Label ID="lblMessageLogin" runat="server" Height="15px" Width="200px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br /><br />
                    </td>
                    <td>
                        <br /><br /><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    </td>
                </tr>
            </table>
        </div>
             <hr>
        <div class="col-md-6">
            <h2 style="color:blue">Not a user?</h2>
            <h2>Register</h2>
            
            <table>
                <tr>
                    <td>
                        <br /><br /><br />Name 
                    </td>
                    <td>
                        <br /><br /><br /><asp:TextBox ID="txtParentName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <br /><br />Student  ID
                    </td>
                    <td>
                        <br /><br /><asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br /><br />Relation
                    </td>
                    <td>
                        <br /><br /><asp:TextBox ID="txtParentRelation" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br /><br />Contact Number
                    </td>
                    <td>
                        <br /><br /><asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                       <br /><br />UserName
                    </td>
                    <td>
                 <br /><br /><asp:TextBox ID="txtParentUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <br /><br />Password 
                    </td>
                    <td>
                        <br /><br /><asp:TextBox ID="txtParentPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <br /><br />Confirm Password 
                    </td>
                    <td>
                        <br /><br /><asp:TextBox ID="txtParentConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                    <td>
                        <asp:Label ID="lblMessageRegistration" runat="server" Height="15px" Width="200px" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br /><br />
                    </td>
                    <td>
                        <br /><br /><asp:Button ID="btnParentRegistrtion" runat="server" Text="Register" OnClick="btnParentRegistrtion_Click" />
                    </td>
                </tr>
            </table>
            
        </div>
    </div>
    </div>
</asp:Content>
