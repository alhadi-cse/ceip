using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using AspMap;
using AspMap.Web;
using AspMap.Web.Extensions;


public partial class temp1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }


        //// Add a new IIS User
        //ManagementUserInfo user =
        //       ManagementAuthentication.CreateUser("MyUser", "ThePassword");

        //// Grant Permissions for The user to connect to Default Web Site

        //ManagementAuthorization.Grant(user.Name, "Default Web Site", false);

        //// Grant Permissions for regular Windows User to connect to Default Web Site
        //ManagementAuthorization.Grant("MyDomain\\NonAdminUser", "Default Web Site", false);
    }
   
    protected void btnEncrypt_Click(object sender, EventArgs e)
    {
        txtOutput.Text = UtilityClass.EncryptString(txtInput.Text);

    }
    protected void btnDecrypt_Click(object sender, EventArgs e)
    {
        txtOutput.Text = UtilityClass.DecryptString(txtInput.Text);
    } 
}