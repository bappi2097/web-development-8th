<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogin.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Project_portal_V_2.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
        <div class="row">
            <div class="col-md-4">

            </div>
            <div class="col-md-4">
                 <h2  class="center-block">Login</h2>
                <table>
                    <tr>
                        <td>
                            <br /><br /><br />UserName 
                        </td>
                        <td>
                            <br /><br /><br /><asp:TextBox ID="txtLoginUserName" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                        <td>
                            <br /><br /><br /> <asp:Label ID="lblMessageLoginUserName" runat="server" Height="15px" Width="200px"></asp:Label>
                        </td>
                    </tr>
                
                    <tr>
                        <td>
                            <br /><br />Password 
                        </td>
                        <td>
                            <br /><br /><asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>

                        </td>
                        <td>
                            <br /><br /><asp:Label ID="lblMessageLoginPassword" runat="server" Height="15px" Width="200px"></asp:Label>
                            <br />
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
                            <br />
                        </td>
                        <td>
                            <br /><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="col-md-4">

            </div>
        </div>
           
        </div>
</asp:Content>
