using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Nicholas Baltodano
/// This page controls Table of Accounts
/// This creates a new select statement for the user selected account 
/// </summary>
public partial class AccountDataPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        
        if(this.IsPostBack)
        {
            var selectedValue = DropDownList1.SelectedValue;
            SqlDataSource1.SelectCommand = "SELECT * FROM Accounts WHERE AccountID = " + selectedValue;
            GridView1.DataBind();  
        }
        
    }

    

    
}