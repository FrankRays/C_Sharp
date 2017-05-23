using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Nicholas Baltodano
/// This page controls the story
/// Most functions are controlling the validity of the user input values
/// </summary>

public partial class Story : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(checkValidation())
        {
            if(cleanwords())
            {
               noun1Text.Text =  noun1copy.Text = noun1.Text;
               noun2text.Text = noun2.Text;
               verb1text.Text = verb1.Text;
               verb2text.Text = verb2.Text;
               adjective1Text.Text = adjective1.Text;
               adjective2text.Text = adjective2.Text;
               adverb1text.Text = adverb1.Text;
               adverb2text.Text = adverb2.Text;
           }
        }
    }

    private bool cleanwords()
    {
        bool validity = true;

        if (noun1.Text == "phantom" || noun1.Text == "sword")
            validity = false;
        else if (noun2.Text == "phantom" || noun2.Text == "sword")
            validity = false;
        else if (adverb1.Text == "phantom" || adverb1.Text == "sword")
            validity = false;
        else if (adverb2.Text == "phantom" || adverb2.Text == "sword")
            validity = false;
        else if (adjective1.Text == "phantom" || adjective1.Text == "sword")
            validity = false;
        else if (adjective2.Text == "phantom" || adjective2.Text == "sword")
            validity = false;
        else if (verb1.Text == "phantom" || verb1.Text == "sword")
            validity = false;
        else if (verb2.Text == "phantom" || verb2.Text == "sword")
            validity = false;

        
        return validity;
    }

    private bool checkValidation()
    {
        bool Validity = false;

        if (reqFieldValidatorAdj1.IsValid == true && reqFieldValidatorAdj2.IsValid == true && reqFieldValidatorAdv1.IsValid == true &&
            reqFieldValidatorAdv2.IsValid == true && reqFieldValidatorNoun1.IsValid == true && reqFieldValidatorNoun2.IsValid == true && reqFieldValidatorVerb1.IsValid == true
            && reqFieldValidatorVerb2.IsValid == true)
        {
            if (reqFieldValidatorVerb2.IsValid == true && reqFieldValidatorVerb1.IsValid == true && reqFieldValidatorNoun2.IsValid == true && reqFieldValidatorNoun1.IsValid == true && reqFieldValidatorAdv2.IsValid == true
                && reqFieldValidatorAdv1.IsValid == true && reqFieldValidatorAdj2.IsValid == true && reqFieldValidatorAdj1.IsValid == true)
               
                Validity = true;
        }
        else
            Validity = false;

        return Validity;
    }
}