<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTeacher.Master" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="Project_portal_V_2.Teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-2">

            </div>
            <div class="col-md-8">
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtSearchStudentID" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbSemester" runat="server" OnSelectedIndexChanged="cmbSemester_SelectedIndexChanged">
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Summer-19</asp:ListItem>
                                <asp:ListItem>Spring-19</asp:ListItem>
                                <asp:ListItem>Fall-18</asp:ListItem>
                                <asp:ListItem>Summer-18</asp:ListItem>
                                <asp:ListItem>Spring-18</asp:ListItem>
                                <asp:ListItem>Fall-17</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbCourseID" runat="server" DataSourceID="SqlDataSource1" DataTextField="Course_ID" DataValueField="Course_ID" OnSelectedIndexChanged="cmbCourseID_SelectedIndexChanged"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Parent_portal_DB_V_1ConnectionString %>" SelectCommand="SELECT [Course_ID] FROM [Course]"></asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="grdvwShowStudent" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="grdvwShowStudent_RowCancelingEdit" OnRowEditing="grdvwShowStudent_RowEditing" OnRowUpdating="grdvwShowStudent_RowUpdating">
                    <Columns>
                        <asp:TemplateField HeaderText="Student ID">
                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Student_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Course">
                            
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Course_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quiz-1">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Quiz1") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Quiz1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quiz-2">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Quiz2") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Quiz2") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quiz-3">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Quiz3") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Quiz3") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mid">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Mid") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("Mid") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Final") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("Final") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Credit">
                            
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Credit") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Semester">
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("Semester") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-2">

            </div>
        </div>
    </div>
</asp:Content>
