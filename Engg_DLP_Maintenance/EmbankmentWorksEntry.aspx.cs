using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Engg_DLP_Maintenance_EmbankmentWorksEntry : System.Web.UI.Page
{
    private DbAdmin dba = new DbAdmin();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Session["ReturnUrl"] = "~/Engg_DLP_Maintenance/EmbankmentWorksEntry.aspx";
            Response.Redirect("~/LoginUser.aspx");
        }
        if (IsPostBack) return;

        //"select distinct package_no, concat_ws('-', 'Package', package_no) as package_name from base_tbl_polder_info order by package_no"
        dba.LoadDropDownList(
            "select package_no, package_name from base_tbl_package_info order by package_no",
            ddlPackageNo, "package_name", "package_no", "---- select package ----", true);

        dba.LoadDropDownList(
            "select fiscal_year_id, fiscal_year from base_tbl_fiscal_year_info order by fiscal_year_id",
            ddlQtyMilestoneYear, "fiscal_year", "fiscal_year_id", "---- select year ----", true);

        dba.LoadDropDownList(
            "select quarter_id, quarter_name from base_tbl_fiscal_quarter_info order by quarter_id",
            ddlQtyMilestoneQuarter, "quarter_name", "quarter_id", "---- select quarter ----", true);

        //ddlPolderNo.Items.Add(new ListItem("-----select polder-----", "-1"));
        //dba.LoadDropDownList("select distinct step_1 from indicator_info order by step_1", ddlMainTab, "step_1",
        //    "step_1", "-----select main tab-----", true);
    }

    protected void ddlPackageNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlDataEntry.Visible = !ddlPackageNo.SelectedValue.Equals("-1");

        //dba.LoadDropDownList("select distinct polder_no from base_tbl_polder_info where package_no='" + ddlPackageNo.SelectedValue + "'  order by polder_no", ddlPolderNo, "polder_no", "polder_no", "-----select polder-----", true);
    }

    protected void btnRefreshData_Click(object sender, EventArgs e)
    {

    }

    //qtyMilestone.QtyControlManualDraftDate = txtQtyControlManualDraftDate.Text.Trim();
    //qtyMilestone.QtyControlManualFinalDate = txtQtyControlManualFinalDate.Text.Trim();
    //qtyMilestone.FinalHandoverPunchlistDate = txtFinalHandoverPunchlistDate.Text.Trim();
    //qtyMilestone.PunchlistSatisfiedDate = txtPunchlistSatisfiedDate.Text.Trim();

    //txtQtyControlManualDraftDate, txtQtyControlManualFinalDate, txtFinalHandoverPunchlistDate, txtPunchlistSatisfiedDate
    //QtyControlManualDraftDate, QtyControlManualFinalDate, FinalHandoverPunchlistDate, PunchlistSatisfiedDate 
    // string.IsNullOrEmpty(txtQtyControlManualDraftDate.Text.Trim()) ? null :

    //DateTime realDate;
    //if (!DateTime.TryParseExact(txtQtyControlManualDraftDate.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture,
    //    DateTimeStyles.AdjustToUniversal, out realDate)) realDate = (DateTime?)null;

    protected void btnInsertQtyMilestone_Click(object sender, EventArgs e)
    {
        //DataProgress dataKey = new DataProgress();
        string msg = string.Empty;
        modal_msg_text.ForeColor = Color.Red;
        if (ddlPackageNo.SelectedValue.Equals("-1"))
        {
            msg = "Please select package";
        }
        else if (ddlQtyMilestoneYear.SelectedValue.Equals("-1"))
        {
            msg = "Please select quality milestone year";
        }
        else if (ddlQtyMilestoneQuarter.SelectedValue.Equals("-1"))
        {
            msg = "Please select quality milestone quarter";
        }

        if (string.IsNullOrEmpty(msg))
        {
            QualityMilestone qtyMilestone = new QualityMilestone();

            qtyMilestone.PackageNo = ddlPackageNo.SelectedValue;
            qtyMilestone.QtyMilestoneYear = ddlQtyMilestoneYear.SelectedValue;
            qtyMilestone.QtyMilestoneQuarter = ddlQtyMilestoneQuarter.SelectedValue;

            qtyMilestone.QtyControlManualDraftDate = dba.CheckDateFormat(txtQtyControlManualDraftDate.Text);
            qtyMilestone.QtyControlManualFinalDate = dba.CheckDateFormat(txtQtyControlManualFinalDate.Text);
            qtyMilestone.FinalHandoverPunchlistDate = dba.CheckDateFormat(txtFinalHandoverPunchlistDate.Text);
            qtyMilestone.PunchlistSatisfiedDate = dba.CheckDateFormat(txtPunchlistSatisfiedDate.Text);

            qtyMilestone.RemarkControlManualDraft = txtRemarkControlManualDraft.Text;
            qtyMilestone.RemarkControlManualFinal = txtRemarkControlManualFinal.Text;
            qtyMilestone.RemarkFinalHandoverPunchlist = txtRemarkFinalHandoverPunchlist.Text;
            qtyMilestone.RemarkPunchlistSatisfied = txtRemarkPunchlistSatisfied.Text;

            qtyMilestone.EntryUser = (string) Session["UserID"] ?? "-1";
            qtyMilestone.EntryDate = DateTime.Now;

            if (dba.QualityMilestoneInsert(qtyMilestone))
            {
                modal_msg_text.ForeColor = Color.Green;
                msg = "Successfully insert quality milestone.";
            }
            else
            {
                msg = "Failed to insert quality milestone !!!";
            }
        }

        if (string.IsNullOrEmpty(msg)) return;

        modal_msg_text.Text = msg;
        modal_Msg.Show();
    }

}
