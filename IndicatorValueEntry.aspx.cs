using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Globalization;

public partial class IndicatorValueEntry : System.Web.UI.Page
{
    DbAdmin dba = new DbAdmin();
    BOQClass boq = new BOQClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Session["ReturnUrl"] = "IndicatorValueEntry.aspx";
            Response.Redirect("LoginUser.aspx");
        }
        if (!IsPostBack)
        {
            Page.Header.DataBind();
            LoadPackageNo();
            
            LoadMainTab();
           
        }

    }
    private void LoadPackageNo()
    {
        if (ddlPackageNo.Items.Count > 0)
            ddlPackageNo.Items.Clear();
        if (ddlPolderNo.Items.Count > 0)
            ddlPolderNo.Items.Clear();
        dba.LoadDropDownList("select package_no from base_tbl_polder_info group by package_no order by package_no", ddlPackageNo, "package_no", "package_no", "---select package---", true);
        ddlPolderNo.Items.Add(new ListItem("---select polder---", "-1"));
    }
    private void LoadPolderNo()
    {
        if (ddlPolderNo.Items.Count > 0)
            ddlPolderNo.Items.Clear();
        if (ddlPackageNo.SelectedValue.Equals("-1"))
        {
            ddlPolderNo.Items.Add(new ListItem("---select polder---", "-1"));
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select polder_no from base_tbl_polder_info where package_no='");
            sb.Append(ddlPackageNo.SelectedValue);
            sb.Append("' group by polder_no order by polder_no");
            dba.LoadDropDownList(sb.ToString(), ddlPolderNo, "polder_no", "polder_no", "---select polder---", true);
        }
    }
    private void LoadMainTab()
    {
        if (ddlMainTab.Items.Count > 0)
            ddlMainTab.Items.Clear();
        if (ddlSecondTab.Items.Count > 0)
            ddlSecondTab.Items.Clear();
        if (ddlThirdTab.Items.Count > 0)
            ddlThirdTab.Items.Clear();
        if (ddlIndicatorName.Items.Count > 0)
            ddlIndicatorName.Items.Clear();

        dba.LoadDropDownList("select step_1 from indicator_info group by step_1 order by step_1", ddlMainTab, "step_1", "step_1", "---select main tab---", true);
        ddlSecondTab.Items.Add(new ListItem("---select second tab---", "-1"));
        ddlThirdTab.Items.Add(new ListItem("---select third tab---", "-1"));
        ddlIndicatorName.Items.Add(new ListItem("---select indicator---", "-1"));
    }
    private void LoadSecondTab()
    {
        if (ddlSecondTab.Items.Count > 0)
            ddlSecondTab.Items.Clear();
        if (ddlThirdTab.Items.Count > 0)
            ddlThirdTab.Items.Clear();
        if (ddlIndicatorName.Items.Count > 0)
            ddlIndicatorName.Items.Clear();

        if (ddlMainTab.SelectedValue.Equals("-1"))
        {
            ddlSecondTab.Items.Add(new ListItem("---select second tab---", "-1"));
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select step_2 from indicator_info where step_1='");
            sb.Append(ddlMainTab.SelectedValue);
            sb.Append("' group by step_2 order by step_2");
            dba.LoadDropDownList(sb.ToString(), ddlSecondTab, "step_2", "step_2", "---select second tab---", true);
        }

        ddlThirdTab.Items.Add(new ListItem("---select third tab---", "-1"));
        ddlIndicatorName.Items.Add(new ListItem("---select indicator---", "-1"));

        //dba.LoadDropDownList("select distinct step_2 from indicator_info where step_1='" + ddlMainTab.SelectedValue + "'  order by step_2", ddlSecondTab, "step_2", "step_2", "---select second tab---", true);

    }
    private void LoadThirdTab()
    {
        if (ddlThirdTab.Items.Count > 0)
            ddlThirdTab.Items.Clear();
        if (ddlIndicatorName.Items.Count > 0)
            ddlIndicatorName.Items.Clear();

        if (ddlSecondTab.SelectedValue.Equals("-1"))
        {
            ddlThirdTab.Items.Add(new ListItem("---select next---", "-1"));
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select step_3 from indicator_info where step_1='");
            sb.Append(ddlMainTab.SelectedValue);
            sb.Append("' and step_2='");
            sb.Append(ddlSecondTab.SelectedValue);
            sb.Append("' group by step_3 order by step_3");
            dba.LoadDropDownList(sb.ToString(), ddlThirdTab, "step_3", "step_3", "---select next---", true);
        }

        ddlIndicatorName.Items.Add(new ListItem("---select indicator---", "-1"));



        //dba.LoadDropDownList("select distinct step_3 from indicator_info where step_1='" + ddlMainTab.SelectedValue + "' and step_2='" + ddlSecondTab.SelectedValue + "'  order by step_3", ddlThirdTab, "step_3", "step_3", "---select third tab---", true);

    }
    private void LoadIndicator()
    {
        if (ddlIndicatorName.Items.Count > 0)
            ddlIndicatorName.Items.Clear();

        if (ddlThirdTab.SelectedValue.Equals("-1"))
        {
            ddlIndicatorName.Items.Add(new ListItem("---select indicator---", "-1"));
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select indicator_code,indicator_name from indicator_info where step_1='");
            sb.Append(ddlMainTab.SelectedValue);
            sb.Append("' and step_2='");
            sb.Append(ddlSecondTab.SelectedValue);
            sb.Append("' and step_3='");
            sb.Append(ddlThirdTab.SelectedValue);
            sb.Append("' group by indicator_code,indicator_name order by indicator_name");
            dba.LoadDropDownList(sb.ToString(), ddlIndicatorName, "indicator_name", "indicator_code", "---select indicator---", true);
        }

        //ddlIndicatorName.Items.Add(new ListItem("---select indicator---", "-1"));

        //dba.LoadDropDownList("select indicator_code,indicator_name from indicator_info where step_1='" + ddlMainTab.SelectedValue + "' and step_2='" + ddlSecondTab.SelectedValue + "' and step_3='" + ddlThirdTab.SelectedValue + "' group by indicator_code,indicator_name", ddlIndicatorName, "indicator_name", "indicator_code", "---select indicator---", true);
    
    }
    protected void ddlPackageNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadPolderNo();
    }
    protected void ddlMainTab_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSecondTab();
    }
    protected void ddlSecondTab_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadThirdTab();
    }
    protected void ddlThirdTab_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadIndicator();
    }
    protected void ddlIndicatorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIndicatorName.SelectedValue.Equals("-1"))
        {
            PanelProgressEntry.Enabled = false;
           
        }
        else
        {
            PanelProgressEntry.Enabled = true;
            LoadProgress();
        }

    }

    protected void btnInsertProgress_Click(object sender, EventArgs e)
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

        if (ddlIndicatorName.SelectedValue.Equals("-1"))
        {
            msg = "Please select indicator name";
            goto Finish;
        }

        //if (string.IsNullOrEmpty(txtProgressDate.Text.Trim()))
        //{
        //    msg = "Progress date not empty!!!";
        //    goto Finish;
        //}
        //if (string.IsNullOrEmpty(txtProgressValue.Text.Trim()))
        //{
        //    msg = "Progress value not empty!!!";
        //    goto Finish;
        //}

        DataProgress dataKey = new DataProgress();
        dataKey.PackageNo = ddlPackageNo.SelectedValue;
        dataKey.PolderNo = ddlPolderNo.SelectedValue;
        dataKey.IndicatorCode = ddlIndicatorName.SelectedValue;
        dataKey.ProgressYear = ddlProgressYear.SelectedValue;
        dataKey.ProgressQuarter = ddlProgressQuarter.SelectedValue;
        dataKey.ProgressDate = DateTime.ParseExact(UtilityClass.QuarterDate(dataKey.ProgressYear, dataKey.ProgressQuarter), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
        dataKey.TargetValue = string.IsNullOrEmpty(txtTargetValue.Text.Trim()) ? 0.0 : Double.Parse(txtTargetValue.Text.Trim());
        dataKey.ProjectionValue = string.IsNullOrEmpty(txtProjectionValue.Text.Trim()) ? 0.0 : Double.Parse(txtProjectionValue.Text.Trim());
        dataKey.ProgressValue = string.IsNullOrEmpty(txtProgressValue.Text.Trim()) ? 0.0 : Double.Parse(txtProgressValue.Text.Trim());
        dataKey.Remarks = txtRemarks.Text.Trim();
        dataKey.EntryUser = Session["UserID"] == null ? "-1" : Session["UserID"].ToString();
        dataKey.EntryDate = DateTime.Now;
        if (dba.ProgressAvailable(dataKey))
        {
            msg = "Data available in this quarter";
            goto Finish;
        }

        if (dba.ProgressInsert(dataKey))
        {
            LoadProgress();
            msg = "Successfully insert progress";
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
    private void LoadProgress()
    {
        //gridViewProgress.EditIndex = 0;
        StringBuilder sb = new StringBuilder();
        sb.Append("select progress_year,progress_quarter,target_value,projection_value,progress_value from indicator_progress");
        sb.Append(" where ");
        sb.Append("package_no='");
        sb.Append(ddlPackageNo.SelectedValue);
        sb.Append("' and polder_no='");
        sb.Append(ddlPolderNo.SelectedValue);
        //sb.Append("'");
        sb.Append("' and indicator_code='");
        sb.Append(ddlIndicatorName.SelectedValue);
        sb.Append("'");
        DataTable table = dba.GetDataTable(sb.ToString());
        if (table != null && table.Rows.Count > 0)
        {

            gridViewProgress.DataSource = table;
            gridViewProgress.DataBind();
        }
        else
        {
            gridViewProgress.DataSource = null;
            gridViewProgress.DataBind();
        }
    }
    protected void btnViewProgress_Click(object sender, EventArgs e)
    {
        LoadProgress();
    }
    protected void gridViewProgress_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridViewProgress.EditIndex = e.NewEditIndex;
        LoadProgress();
    }
    protected void gridViewProgress_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridViewProgress.EditIndex = -1;
        LoadProgress();
    }
    protected void gridViewProgress_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string msg = string.Empty;
        DataProgress dataKey = new DataProgress();
        dataKey.PackageNo = ddlPackageNo.SelectedValue;
        dataKey.PolderNo = ddlPolderNo.SelectedValue;
        dataKey.IndicatorCode = ddlIndicatorName.SelectedValue;
        dataKey.ProgressYear = gridViewProgress.DataKeys[e.RowIndex].Values["progress_year"].ToString();
        dataKey.ProgressQuarter = gridViewProgress.DataKeys[e.RowIndex].Values["progress_quarter"].ToString();
        dataKey.TargetValue = double.Parse((gridViewProgress.Rows[e.RowIndex].FindControl("gridViewProgressTextTarget") as TextBox).Text.Trim());
        dataKey.ProjectionValue = double.Parse((gridViewProgress.Rows[e.RowIndex].FindControl("gridViewProgressTextProjection") as TextBox).Text.Trim());
        dataKey.ProgressValue = double.Parse((gridViewProgress.Rows[e.RowIndex].FindControl("gridViewProgressTextProgress") as TextBox).Text.Trim());
        //dataKey.Remarks = txtRemarks.Text.Trim();
        //dataKey.EntryUser = Session["UserID"] == null ? "-1" : Session["UserID"].ToString();
        //dataKey.EntryDate = DateTime.Now;
        if (dba.ProgressUpdate(dataKey))
        {
            gridViewProgress.EditIndex = -1;
            LoadProgress();
            msg = "Indicator value has been updated.";
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
            modal_msg_text.Text = msg;
            modal_Msg.Show();
        }
    }
    protected void gridViewProgress_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string msg = string.Empty;
        DataProgress dataKey = new DataProgress();
        dataKey.PackageNo = ddlPackageNo.SelectedValue;
        dataKey.PolderNo = ddlPolderNo.SelectedValue;
        dataKey.IndicatorCode = ddlIndicatorName.SelectedValue;
        dataKey.ProgressYear = gridViewProgress.DataKeys[e.RowIndex].Values["progress_year"].ToString();
        dataKey.ProgressQuarter = gridViewProgress.DataKeys[e.RowIndex].Values["progress_quarter"].ToString();
        //dataKey.EntryDate = DateTime.Now;
        if (dba.ProgressDelete(dataKey))
        {
            LoadProgress();
            msg = "Indicator value has been deleted.";
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
            modal_msg_text.Text = msg;
            modal_Msg.Show();
        }
    }
    protected void btnPackageNoRefresh_Click(object sender, EventArgs e)
    {
        LoadPackageNo();
    }
    protected void btnPolderNoRefresh_Click(object sender, EventArgs e)
    {
        LoadPolderNo();
    }
    protected void btnMainTabRefresh_Click(object sender, EventArgs e)
    {
        LoadMainTab();
    }
    protected void btnSecondTabRefresh_Click(object sender, EventArgs e)
    {
        LoadSecondTab();
    }
    protected void btnThirdTabRefresh_Click(object sender, EventArgs e)
    {
        LoadThirdTab();
    }
    protected void btnIndicatorNameRefresh_Click(object sender, EventArgs e)
    {
        LoadIndicator();
    }
}