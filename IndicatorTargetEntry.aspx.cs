using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Globalization;

public partial class IndicatorTargetEntry : System.Web.UI.Page
{
    DbAdmin dba = new DbAdmin();
    BOQClass boq = new BOQClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Session["ReturnUrl"] = "IndicatorTargetEntry.aspx";
            Response.Redirect("LoginUser.aspx");
        }
        if (!IsPostBack)
        {
            dba.LoadDropDownList("select distinct package_no from base_tbl_polder_info order by package_no", ddlPackageNo , "package_no", "package_no", "---select package---", true);
            ddlPolderNo.Items.Add(new ListItem("---select polder---", "-1"));
            dba.LoadDropDownList("select distinct step_1 from indicator_info order by step_1", ddlMainTab, "step_1", "step_1", "---select main tab---", true);
        }
        
    }
    protected void ddlPackageNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        dba.LoadDropDownList("select distinct polder_no from base_tbl_polder_info where package_no='" + ddlPackageNo.SelectedValue + "'  order by polder_no", ddlPolderNo, "polder_no", "polder_no", "---select polder---", true);

    }
    protected void ddlMainTab_SelectedIndexChanged(object sender, EventArgs e)
    {
        dba.LoadDropDownList("select distinct step_2 from indicator_info where step_1='" + ddlMainTab.SelectedValue + "'  order by step_2", ddlSecondTab, "step_2", "step_2", "---select second tab---", true);


    }
    protected void ddlSecondTab_SelectedIndexChanged(object sender, EventArgs e)
    {
        dba.LoadDropDownList("select distinct step_3 from indicator_info where step_1='" + ddlMainTab.SelectedValue + "' and step_2='" + ddlSecondTab.SelectedValue + "'  order by step_3", ddlThirdTab, "step_3", "step_3", "---select third tab---", true);

    }
    protected void ddlThirdTab_SelectedIndexChanged(object sender, EventArgs e)
    {
        dba.LoadDropDownList("select indicator_code,indicator_name from indicator_info where step_1='" + ddlMainTab.SelectedValue + "' and step_2='" + ddlSecondTab.SelectedValue + "' and step_3='" + ddlThirdTab.SelectedValue + "' group by indicator_code,indicator_name", ddlIndicatorName, "indicator_name", "indicator_code", "---select indicator---", true);
        

        
    }
    protected void ddlIndicatorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlIndicatorName.SelectedValue.Equals("-1"))
        {
            PanelProgressEntry.Visible = true;
        }
    }
   
    protected void ddlPolderNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlBillNo.Items.Count > 0)
        //    ddlBillNo.Items.Clear();
        //if (ddlItemNo.Items.Count > 0)
        //    ddlItemNo.Items.Clear();
        //if (ddlPolderNo.SelectedValue.Equals("-1"))
        //{
        //    ddlBillNo.Items.Add(new ListItem("---select bill no---", "-1"));
        //}
        //else
        //{
        //    dba.LoadDropDownList("select distinct bill_no from boq_info where polder_no='" + ddlPolderNo.SelectedValue + "' order by bill_no", ddlBillNo, "bill_no", "bill_no", "---select bill no---", true);
        //}
        //ddlItemNo.Items.Add(new ListItem("---select bill item---", "-1"));


    }
    protected void ddlBillNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlItemNo.Items.Count > 0)
        //    ddlItemNo.Items.Clear();
        //if (ddlBillNo.SelectedValue.Equals("-1"))
        //{
        //    ddlItemNo.Items.Add(new ListItem("---select bill item---", "-1"));
        //}
        //else
        //{
        //    dba.LoadDropDownList("select distinct item_no from boq_info where polder_no='" + ddlPolderNo.SelectedValue + "' and bill_no='" + ddlBillNo.SelectedValue + "' order by item_no", ddlItemNo, "item_no", "item_no", "---select bill item---", true);
        //}
    }
    protected void ddlItemNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //LoadBillItem();
    }
    protected void btnRefreshData_Click(object sender, EventArgs e)
    {
        //LoadBillItem();
    }
    //public void LoadBillItem()
    //{
    //    string msg = string.Empty;
    //    if (ddlPolderNo.SelectedValue.Equals("-1"))
    //    {
    //        msg = "please select polder no";
    //        goto Finish;
    //    }
    //    if (ddlBillNo.SelectedValue.Equals("-1"))
    //    {
    //        msg = "please select bill no";
    //        goto Finish;
    //    }
    //    if (ddlItemNo.SelectedValue.Equals("-1"))
    //    {
    //        msg = "please select bill item";
    //        goto Finish;
    //    }
    //    DataTable table = dba.GetDataTable("select * from boq_info where polder_no='" + ddlPolderNo.SelectedValue + "' and bill_no='" + ddlBillNo.SelectedValue + "' and item_no='" + ddlItemNo.SelectedValue + "'");
    //    if (table != null && table.Rows.Count > 0)
    //    {
    //        lblItemCode.Text = "<b>Item Code No. : </b> " + table.Rows[0]["code_no"].ToString();
    //        lblItemDesc.Text = "<b>Item Description : </b> " + table.Rows[0]["item_desc"].ToString();
    //        lblItemUnit.Text = "<b>Item Unit : </b> " + table.Rows[0]["unit_name"].ToString();
    //        lblMaxQuantity.Text = "Maximum entered quantity : " + table.Rows[0]["quantity"].ToString();
    //        PanelBillEntry.Visible = true;
    //    }
    //Finish:
    //    if (!string.IsNullOrEmpty(msg))
    //    {
    //        PanelBillEntry.Visible = false;
    //        //modalHeaderTitle_Msg.Text = "User Registration";
    //        modal_msg_text.Text = msg;
    //        modal_Msg.Show();

    //    }

    //}


  

    
    protected void btnInsertTarget_Click(object sender, EventArgs e)
    {
        //DataProgress dataKey = new DataProgress();
        string msg = string.Empty;
        if (ddlPackageNo.SelectedValue.Equals("-1"))
        {
            msg = "Please select package";
            goto Finish;
        }
        if (ddlPolderNo.SelectedValue.Equals("-1"))
        {
            msg = "Please select polder";
            goto Finish;
        }

        if (ddlMainTab.SelectedValue.Equals("-1"))
        {
            msg = "Please select main tab";
            goto Finish;
        }

        if (ddlSecondTab.SelectedValue.Equals("-1"))
        {
            msg = "Please select second tab";
            goto Finish;
        }

        if (ddlThirdTab.SelectedValue.Equals("-1"))
        {
            msg = "Please select third tab";
            goto Finish;
        }

        if ( ddlIndicatorName.SelectedValue.Equals("-1"))
        {
            msg = "Please select indicator name";
            goto Finish;
        }

        
        if (string.IsNullOrEmpty(txtTargetValue.Text.Trim()))
        {
            msg = "Progress value not empty!!!";
            goto Finish;
        }

        DataTarget dataKey = new DataTarget();
        dataKey.PackageNo = ddlPackageNo.SelectedValue;
        dataKey.PolderNo = ddlPolderNo.SelectedValue;
        dataKey.IndicatorCode = ddlIndicatorName.SelectedValue;
        dataKey.TargetYear = ddlTargetYear.SelectedValue;
        dataKey.TargetQuarter = ddlTargetQuarter.SelectedValue;
        dataKey.TargetValue = string.IsNullOrEmpty(txtTargetValue.Text.Trim()) ? 0.0 : Double.Parse(txtTargetValue.Text.Trim());
        dataKey.Remarks = txtRemarks.Text.Trim();
        dataKey.EntryUser = Session["UserID"] != null ? Session["UserID"].ToString() : "-1";
        dataKey.EntryDate = DateTime.Now;
        if (dba.TargetInsert(dataKey))
        {
            msg = "Successfully insert target";
            goto Finish;
        }
        else
        {
            msg = "Not Success !!!";
            goto Finish;
        }
    Finish:
        if (!string.IsNullOrEmpty(msg))
        {
            //modalHeaderTitle_Msg.Text = "User Registration";
            modal_msg_text.Text = msg;
            modal_Msg.Show();

        }
    }
}