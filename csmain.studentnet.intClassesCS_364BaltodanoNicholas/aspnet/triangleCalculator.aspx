<%@ Page Language="C#" AutoEventWireup="true" CodeFile="triangleCalculator.aspx.cs" Inherits="triangleCalculator" %>

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
       
    <form id="triangleCalc" runat="server">
          <div>
             <h1> Calculate a triangle</h1>
             <p> Please enter Side A and Side B</p>
             <p> I will return the perimeter, side C, and the area for a right triangle.</p>
            
          </div>

       <div>
          
          <p> Side A:</p>
          <asp:TextBox ID="sideA" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidatorA" runat="server" ErrorMessage="Required Field" ControlToValidate="sideA"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="triangleValueValidator" runat="server" ErrorMessage="Please include only numbers limited to 2 decimals"
             ValidationExpression="^*[0-9]*.*[0-9]$" ControlToValidate="sideA">
             </asp:RegularExpressionValidator>
        
       </div>
        
       <div>
          <p> Side B:</p>
          <asp:TextBox ID="sideB" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidatorB" runat="server" ErrorMessage="Required Field" ControlToValidate="sideB"></asp:RequiredFieldValidator>
         
          <asp:RegularExpressionValidator ID="triangleValueValidatorB" runat="server"
             ControlToValidate="sideB"
             ErrorMessage="Please include only numbers limited to 2 decimals"
             ValidationExpression="^*[0-9]*.*[0-9]$">
          </asp:RegularExpressionValidator>
         
       </div>

       

       <div >
          <asp:Button ID="calculateButton" href="" runat="server" Text="Button" PostBackUrl="~/aspnet/triangleCalculator.aspx" />
      </div>

       <div >
          <asp:Literal ID="TriangleConfirmation" runat="server"></asp:Literal>
          <p></p>
          <asp:Literal ID="sideCText" runat="server">Side C:</asp:Literal>
           <p></p>
           <asp:Literal ID="areaText" runat="server"> Area:</asp:Literal>
           <p></p>
           <asp:Literal ID="perimeterText" runat="server">Perimeter:</asp:Literal>
          
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