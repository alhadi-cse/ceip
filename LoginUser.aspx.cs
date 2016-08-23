using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
//using System.DirectoryServices.AccountManagement;
public partial class LoginUser : System.Web.UI.Page
{
    DbAdmin dba = new DbAdmin();
    //LoginClass login = new LoginClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // Session["PageName"] = "Login";
            //LogUtility.LogPageVisitInfo("Login");


            //using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "YOURDOMAIN"))
            //{
            //    // validate the credentials
            //    bool isValid = pc.ValidateCredentials("myuser", "mypassword");
            //}


            ////////start
            //Session["UserID"] = "testsuper";
            //Session["UserLevel"] = "1";
            //Session["IsSuperUser"] = "1";
            //Session["IsEdit"] = "1";
            //Session["RegCode"] = "-1";
            //Session["RegName"] = "-1";
            //Session["AreaCode"] = "-1";
            //Session["AreaName"] = "-1";
            //Session["ThaCode"] = "-1";
            //Session["ThaName"] = "-1";

            //if (Session["ReturnUrl"] == null)
            //{
            //    Response.Redirect("Dashboard.aspx");
            //}
            //else
            //{
            //    Response.Redirect(Session["ReturnUrl"].ToString());
            //}
            ////////end

        }
    }
    
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        if (string.IsNullOrEmpty(UserName.Text.Trim()) || string.IsNullOrEmpty(Password.Text.Trim()))
        {
            msg = "User id or password does not blank!!!";
            goto Finish;
        }
        if (UserName.Text.Trim().Equals(Password.Text.Trim()))
        {
            Session["UserID"] = UserName.Text.Trim();
            if (Session["ReturnUrl"] == null)
                Response.Redirect("Default.aspx");
            else
                Response.Redirect(Session["ReturnUrl"].ToString());

        }
        //string errMsg = string.Empty;
        //string userid = UserName.Text.Trim();
        //string password = Password.Text.Trim();
        //if (!login.Check_User_Validity(userid))
        //{
        //    msg = "User id not found or user not active!!!";
        //    goto Finish;
        //}

        //if (!login.Check_User_Locked_Status(userid))
        //{
        //    msg = "User account locked. please try again later!!!";
        //    goto Finish;
        //}
        //if (!login.Check_User_Validity(userid, password, out errMsg))
        //{
        //    if (errMsg == "-1")
        //        msg = "password incorrect!!!";
        //    else
        //        msg = errMsg;
        //    goto Finish;
        //}

        //if (login.Check_Password_Validity(userid))
        //{
        //    modal_Password.Show();
        //}
        //else
        //{
        //    Session["UserID"] = userid;
        //    //lblErrMsg.Text = "success!!!";
        //    DataTable dt = dba.GetDataTableOracle("select user_level,cluster_code,cluster_name,region_code,region_name,area_code,area_name,territory_code,territory_name,thana_code,thana_name,sales_mo_access,oikotan_access,drivetest_access,edotco_access from login_user where user_id='" + userid + "'");
        //    if (dt != null)
        //    {
        //        if (dt.Rows.Count > 0)
        //        {

        //            if (dt.Rows[0]["user_level"].ToString().Equals("0"))
        //            {
        //                Session["UserLevel"] = "1";
        //                Session["IsSuperUser"] = "1";
        //                Session["IsEdit"] = "1";
        //            }
        //            else
        //            {
        //                Session["UserLevel"] = dt.Rows[0]["user_level"].ToString();
        //            }
        //            Session["OikotanAccess"] = "0";
        //            Session["UserClusterCode"] = dt.Rows[0]["cluster_code"].ToString();
        //            Session["UserClusterName"] = dt.Rows[0]["cluster_name"].ToString();
        //            Session["UserRegionCode"] = dt.Rows[0]["region_code"].ToString();
        //            Session["UserRegionName"] = dt.Rows[0]["region_name"].ToString();
        //            Session["UserAreaCode"] = dt.Rows[0]["area_code"].ToString();
        //            Session["UserAreaName"] = dt.Rows[0]["area_name"].ToString();
        //            Session["UserTerritoryCode"] = dt.Rows[0]["territory_code"].ToString();
        //            Session["UserTerritoryName"] = dt.Rows[0]["territory_name"].ToString();
        //            Session["UserThanaCode"] = dt.Rows[0]["thana_code"].ToString();
        //            Session["UserThanaName"] = dt.Rows[0]["thana_name"].ToString();
        //            if (login.CheckPasswordChangeStatus(userid))
        //            {
        //                modal_Password.Show();
        //            }
        //            else
        //            {

        //                if (dt.Rows[0]["user_level"].ToString().Equals("7"))
        //                {
        //                    Response.Redirect("ActiveAlarmEDOT.aspx");
        //                }
        //                else
        //                {
        //                    if (Session["ReturnUrl"] == null)
        //                        Response.Redirect("Dashboard.aspx");
        //                    else
        //                        Response.Redirect(Session["ReturnUrl"].ToString());

        //                }
        //            }
        //        }

        //    }

        //    //Session["UserLevel"] = UserLevel;
        //    //Session["RegCode"] = UserRegCode;
        //    //Session["RegName"] = rd.GetFieldValue("select distinct regname from tblgeocode where regcode='" + UserRegCode + "'");
        //    //Session["AreaCode"] = UserAreaCode;
        //    //Session["AreaName"] = rd.GetFieldValue("select distinct areaname from tblgeocode where areacode='" + UserAreaCode + "'");
        //    //if (Session["ReturnUrl"] == null)
        //    //    Response.Redirect("Default.aspx");
        //    //else
        //    //    Response.Redirect(Session["ReturnUrl"].ToString());

        //}

                    

                
            
        
    Finish:
        if (!string.IsNullOrEmpty(msg))
        {
            modal_msg_text.Text = msg;
            modal_Msg.Show();

        }
    }
    //protected void btnChangePassword_Click(object sender, EventArgs e)
    //{
    //    string msg = string.Empty;
    //    if (!txtNewPassword.Text.Trim().Equals(txtConfirmPassword.Text.Trim()))
    //    {
    //        msg = "Password does not match!!!";
    //        goto Finish;
    //    }
    //    if (UserName.Text.Trim().Equals(txtNewPassword.Text.Trim()))
    //    {
    //        msg = "Password and User id not same!!!";
    //        goto Finish;
    //    }
    //    if (txtNewPassword.Text.Trim().IndexOf(UserName.Text.Trim()) >= 0)
    //    {
    //        msg = "User id not contain part of password!!!";
    //        goto Finish;
    //    }
    //    string errMsg;
    //    if (login.Check_Last_2_User_Password(UserName.Text.Trim(), txtNewPassword.Text.Trim()))
    //    {
    //        if (login.Update_User_Password(UserName.Text.Trim(), Password.Text.Trim(), txtNewPassword.Text.Trim(), out errMsg))
    //        {
    //            Session.Abandon();
    //            Response.Redirect("LoginUser.aspx");
    //        }
    //        else
    //        {
    //            if (errMsg == "-1")
    //                msg = "password not updated properly!!!";
    //            else
    //                msg = errMsg;
    //        }
    //    }//end 2 times check
    //    else
    //    {
    //        msg = "new password already used last two times!!!";
    //    }

    //Finish:
    //    if (!string.IsNullOrEmpty(msg))
    //    {
    //        //modalHeaderTitle_Msg.Text = "User Registration";
    //        modal_msg_text.Text = msg;
    //        modal_Msg.Show();

    //    }
    //}
    //protected void btnForgotpassword_Click(object sender, EventArgs e)
    //{
    //    if (login.Check_User_Validity_Forget_Password(txt_user_id.Text.Trim(), txt_e_mail.Text.Trim()))
    //    {
    //        string msg = string.Empty;
    //        Durbin.RandomPasswordGenerator pass = new Durbin.RandomPasswordGenerator();
    //        string password = pass.Generate(8, 20);
    //        if (login.Check_Last_2_User_Password(txt_user_id.Text.Trim(), password))
    //        {
    //            if (login.Reset_User_Password(txt_user_id.Text.Trim(), password))
    //            {
    //                SendMail(txt_e_mail.Text.Trim(), txt_user_id.Text.Trim(), password);
    //                LogUtility.LogSuperUserActivity("Reset Password", txt_user_id.Text.Trim());
    //                modal_Forgot.Hide();
    //                msg = "Successfully reset password for User ID=" + txt_user_id.Text.Trim() + ". Please check your mail.";
    //            }
    //            else
    //            {
    //                msg = "Not Success !!!";
    //            }
    //        }//end 2 times check
    //        else
    //        {
    //            msg = "New password already used last two times. Please try again!!!";
    //        }
    //        modal_msg_text.Text = msg;
    //        modal_Msg.Show();
    //    }
    //    else
    //    {
    //        modal_msg_text.Text = "Incorrect user id or email address!!!";
    //        modal_Msg.Show();
    //    }
    //}
    //public void SendMail(string userEmail, string userID, string userPass)
    //{
    //    SmtpClient client = new SmtpClient();
    //    MailMessage message = new MailMessage();
    //    message.To.Add(userEmail);

    //    message.From = new MailAddress("durbin.oikotan@robi.com.bd", "Durbin-Oikotan");

    //    message.Subject = "Recover Password";
    //    message.SubjectEncoding = Encoding.UTF8;

    //    message.Body = UtilityMail.PasswordRecoverEmail(userID, userPass);
    //    message.BodyEncoding = Encoding.UTF8;
    //    message.IsBodyHtml = true;
    //    try
    //    {
    //        client.Send(message);
    //    }
    //    catch (Exception ex)
    //    {
    //        LogUtility.LogApplicationExceptionInfo("Mail", ex.Message);
    //    }
    //}
}