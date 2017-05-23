<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Story.aspx.cs" Inherits="Story" %>

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
       
    <form id="StoryMaker" runat="server">
      
      <div>
         <h1>Create a story</h1>
         <p> Enter in 2 nouns, 2 verbs, 2 adjectives, and 2 adverbs and I will produce a funny story</p>
      </div>

      <div>
         <p> Noun 1 :</p>
            <asp:TextBox ID="noun1" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="reqFieldValidatorNoun1" runat="server" ErrorMessage="Required Field" ControlToValidate="noun1"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="validatorRegExNoun1" runat="server" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ErrorMessage="Please enter only Text" ControlToValidate="noun1"></asp:RegularExpressionValidator>
      </div>
       
         <div>
            <p> Noun 2 :</p>
         <asp:TextBox ID="noun2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqFieldValidatorNoun2" runat="server" ErrorMessage="Required Field" ControlToValidate="noun2"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="validatorRegExNoun2" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" runat="server" ErrorMessage="Please enter only Text" ControlToValidate="noun2"></asp:RegularExpressionValidator>
      </div>

      <div>
         <p> Verb 1 :</p>
            <asp:TextBox ID="verb1" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="reqFieldValidatorVerb1" runat="server" ErrorMessage="Required Field" ControlToValidate="verb1"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="validatorRegExVerb1"  ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" runat="server" ErrorMessage="Please enter only Text" ControlToValidate="verb1"></asp:RegularExpressionValidator>
         </div>
         <div>
            <p> Verb 2 :</p>
         <asp:TextBox ID="verb2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqFieldValidatorVerb2" runat="server" ErrorMessage="Required Field" ControlToValidate="verb2"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="validatorRegExVerb2" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" runat="server" ErrorMessage="Please enter only Text" ControlToValidate="verb2"></asp:RegularExpressionValidator>
      </div>

      <div>
         <p> Adjective 1 :</p>
         <asp:TextBox ID="adjective1" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="reqFieldValidatorAdj1" runat="server" ErrorMessage="Required Field" ControlToValidate="adjective1"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="validatorRegExAdj1"  ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" runat="server" ErrorMessage="Please enter only Text" ControlToValidate="adjective1"></asp:RegularExpressionValidator>
      </div>
      <div>
         <p> Adjective 2 :</p>
         <asp:TextBox ID="adjective2" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="reqFieldValidatorAdj2" runat="server" ErrorMessage="Required Field" ControlToValidate="adjective2"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="validatorRegExAdj2" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"  runat="server" ErrorMessage="Please enter only Text" ControlToValidate="adjective2"></asp:RegularExpressionValidator>
      </div>

      <div>
         <p> Adverb 1 :</p>
         <asp:TextBox ID="adverb1" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="reqFieldValidatorAdv1" runat="server" ErrorMessage="Required Field" ControlToValidate="adverb1"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="validatorRegExAdv1" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" runat="server" ErrorMessage="Please enter only Text" ControlToValidate="adverb1"></asp:RegularExpressionValidator>
      </div>
      <div>
         <p> Adverb 2 :</p>
         <asp:TextBox ID="adverb2" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="reqFieldValidatorAdv2" runat="server" ErrorMessage="Required Field" ControlToValidate="adverb2"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="validatorRegExAdv2"  ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" runat="server" ErrorMessage="Please enter only Text" ControlToValidate="adverb2"></asp:RegularExpressionValidator>
      </div>
    
       <asp:Button ID="makeStory" runat="server" Text="Create Story" />
      
       <div class="jumbotron">
         <p>    
            <asp:Literal ID="noun1Text" runat="server" > (Noun 1)</asp:Literal> was a very large person who loved to eat 
            <asp:Literal ID="adjective1Text" runat="server">(Adjective 1)</asp:Literal>  <asp:Literal ID="noun2text" runat="server"> (Noun 2)</asp:Literal>.
            They were known for <asp:Literal ID="adverb1text" runat="server">(Adverb 1)</asp:Literal> <asp:Literal ID="verb1text" runat="server"> (Verb 1)</asp:Literal> their entire meal while
            trying to <asp:Literal ID="adverb2text" runat="server">(Adverb 2)</asp:Literal><asp:Literal ID="verb2text" runat="server"> Verb 2</asp:Literal>. The worst part of <asp:Literal ID="noun1copy" runat="server"> (Noun 1)</asp:Literal>
            was their <asp:Literal ID="adjective2text" runat="server"> (Adjective 2)</asp:Literal> pet skunk, who looked like an alpaca. No one like this person, and they ended up dying alone. 
           <b>  The end.</b>
         </p> 

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