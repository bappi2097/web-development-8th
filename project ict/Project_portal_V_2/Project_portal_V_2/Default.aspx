<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project_portal_V_2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Daffodil International University</h1>
        <asp:Image ID="imgDIUHome" runat="server" Height="361px" Width="1060px" ImageAlign="Middle" ImageUrl="Image/Home.jpg" />
        <p><a href="http://daffodilvarsity.edu.bd/" class="btn btn-primary btn-lg" target="_blank">DIU Official &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Campus</h2>
            <asp:Image ID="imgDIUCampus" runat="server" Height="175px" ImageUrl="Image/Campus.jpg" Width="300px" />
            <p>
                Excellent natural environment<br />
                20% special waiver on tuition fees<br />
                Female students will be entitled to enjoy additional 10% tuition fees waiver.<br />
                Students of evening programs will get 20% waiver benefit in general.<br />
                Hostel accommodation available (male & female)<br />
                Medical doctor available<br />
                Indoor and outdoor games facility<br />
                Transport facility available<br />
                Big playground<br />
                Wi-Fi available<br />
                Attractive laboratories for science & engineering<br />
                Online/digital library system<br />
                24 hours security<br />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Hostel</h2>
            <asp:Image ID="imgDIUHostel" runat="server" ImageUrl="Image/Hostel.jpg" Height="175px" Width="300px" />
            <p>
                Daffodil international university have a decent and one of the biggest hostel among the private university . Well furnished , good meal, Cloth cleaning facility and so many facility are given to student
            </p>
        </div>
        <div class="col-md-4">
            <h2>Library</h2>
            <asp:Image ID="imgDIULibrary" runat="server" ImageUrl="image/Library.jpg" Height="175px" Width="300px" />
            <p>
                Daffodil international university have a large building only for library . A huge collection of books are reserved there for student's and they can borrow books from library . their is a very calm environment to sit there and read books .
            </p>
            
            <p>
                <a class="btn btn-default" href="http://library.daffodilvarsity.edu.bd/" target="_blank">Official &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
