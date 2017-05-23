<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccountDataPage.aspx.cs" Inherits="AccountDataPage" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link rel="icon" href="../../favicon.ico"/>

     <title>Nick's Home Page</title>

     <!-- Bootstrap core CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet"/>

    <!-- Custom styles for this template -->
    <link href="starter-template.css" rel="stylesheet"/>

  
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>

  <body>

    <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="Default.aspx">Nick's Project Home</a>
        </div>
        <div id="navbar" class="collapse navbar-collapse">
          <ul class="nav navbar-nav">
            <li class="active"><a href="Default.aspx">Home</a></li>
            <li><a href="AccountDataPage.aspx">Accounts </a></li>
             <li><a href="triangleCalculator.aspx">Triangle</a></li>
            <li><a href="Story.aspx" >Story</a></li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
    </nav>

    <div class="container">
       
       <form id="AccountDataForm" runat="server">
         
          <div class="spacing">
             <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="AccountID" DataValueField="AccountID"></asp:DropDownList>
          </div>
          <div class="centerHeading">
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountID" DataSourceID="SqlDataSource1">
                <Columns>
                   <asp:BoundField DataField="AccountID" HeaderText="AccountID" ReadOnly="True" SortExpression="AccountID" />
                   <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                   <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                   <asp:BoundField DataField="InterestRate" HeaderText="InterestRate" SortExpression="InterestRate" />
                   <asp:BoundField DataField="Balance" HeaderText="Balance" SortExpression="Balance" />
                </Columns>
             </asp:GridView>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CS364_ExampleConnectionString %>" SelectCommand="SELECT * FROM [Accounts]"></asp:SqlDataSource>
          </div>
       </form>


    </div><!-- /.container -->


    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery.min.js"><\/script>')</script>
    <script src="../../dist/js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../../assets/js/ie10-viewport-bug-workaround.js"></script>
  </body>
</html>