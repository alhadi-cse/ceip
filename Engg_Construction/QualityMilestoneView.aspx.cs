using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Engg_Construction_QualityMilestoneView : System.Web.UI.Page
{
    private DbAdmin dba = new DbAdmin();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Session["ReturnUrl"] = "~/Engg_Construction/QualityMilestoneView.aspx";
            Response.Redirect("~/LoginUser.aspx");
        }
        if (IsPostBack) return;

        //"select distinct package_no, concat_ws('-', 'Package', package_no) as package_name from base_tbl_polder_info order by package_no"
        dba.LoadDropDownList("select package_no, package_name from base_tbl_package_info order by package_no",
            ddlPackageNo, "package_name", "package_no", "---- all package ----", true);

        dba.LoadDropDownList("select fiscal_year_id, fiscal_year from base_tbl_fiscal_year_info order by fiscal_year_id",
            ddlQtyMilestoneYear, "fiscal_year", "fiscal_year_id", "---- all year ----", true);

        dba.LoadDropDownList("select quarter_id, quarter_name from base_tbl_fiscal_quarter_info order by quarter_id",
            ddlQtyMilestoneQuarter, "quarter_name", "quarter_id", "---- all quarter ----", true);


        LoadData();
        //ddlPolderNo.Items.Add(new ListItem("-----select polder-----", "-1"));
        //dba.LoadDropDownList("select distinct step_1 from indicator_info order by step_1", ddlMainTab, "step_1",
        //    "step_1", "-----select main tab-----", true);
    }

    protected void ddlPackageNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
        //pnlDataView.Visible = !ddlPackageNo.SelectedValue.Equals("-1");
        //dba.LoadDropDownList("select distinct polder_no from base_tbl_polder_info where package_no='" + ddlPackageNo.SelectedValue + "'  order by polder_no", ddlPolderNo, "polder_no", "polder_no", "-----select polder-----", true);
    }

    protected void ddlQtyMilestoneYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }

    protected void ddlQtyMilestoneQuarter_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }

    protected void btnRefreshData_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    protected string GetCondition()
    {
        StringBuilder sbCondition = new StringBuilder();
        StringBuilder sbDataTitle = new StringBuilder();

        if (!ddlPackageNo.SelectedValue.Equals("-1"))
        {
            sbCondition.Append("tbl_engg_construction_quality_milestone.package_no = '");
            sbCondition.Append(ddlPackageNo.SelectedValue);
            sbCondition.Append("'");

            sbDataTitle.Append("Package: ");
            sbDataTitle.Append(ddlPackageNo.SelectedItem.Text);

            gvDataView.Columns[0].Visible = false;
        }
        else
        {
            gvDataView.Columns[0].Visible = true;
        }

        if (!ddlQtyMilestoneYear.SelectedValue.Equals("-1"))
        {
            if (!string.IsNullOrEmpty(sbCondition.ToString()))
                sbCondition.Append(" AND ");
            sbCondition.Append("tbl_engg_construction_quality_milestone.qty_milestone_year_id = '");
            sbCondition.Append(ddlQtyMilestoneYear.SelectedValue);
            sbCondition.Append("'");

            if (!string.IsNullOrEmpty(sbDataTitle.ToString()))
                sbDataTitle.Append(", ");
            sbDataTitle.Append("Year: ");
            sbDataTitle.Append(ddlQtyMilestoneYear.SelectedItem.Text);

            gvDataView.Columns[1].Visible = false;
        }
        else
        {
            gvDataView.Columns[1].Visible = true;
        }

        if (!ddlQtyMilestoneQuarter.SelectedValue.Equals("-1"))
        {
            if (!string.IsNullOrEmpty(sbCondition.ToString()))
                sbCondition.Append(" AND ");
            sbCondition.Append("tbl_engg_construction_quality_milestone.qty_milestone_quarter_id = '");
            sbCondition.Append(ddlQtyMilestoneQuarter.SelectedValue);
            sbCondition.Append("'");

            if (!string.IsNullOrEmpty(sbDataTitle.ToString()))
                sbDataTitle.Append(", ");
            sbDataTitle.Append("Quarter: ");
            sbDataTitle.Append(ddlQtyMilestoneQuarter.SelectedItem.Text);

            gvDataView.Columns[2].Visible = false;
        }
        else
        {
            gvDataView.Columns[2].Visible = true;
        }

        lblDataTitle.ForeColor = Color.Navy;
        lblDataTitle.Text = string.IsNullOrEmpty(sbDataTitle.ToString()) ? "All Data" : sbDataTitle.ToString();

        return sbCondition.ToString();
    }

    private void LoadData()
    {
        string condition = GetCondition();

        StringBuilder sbSql = new StringBuilder();
        sbSql.Append("SELECT  tbl_engg_construction_quality_milestone.package_no, base_tbl_package_info.package_name, ");
        sbSql.Append("base_tbl_fiscal_year_info.fiscal_year, base_tbl_fiscal_quarter_info.quarter_name, ");
        sbSql.Append("tbl_engg_construction_quality_milestone.qty_control_manual_draft_date, tbl_engg_construction_quality_milestone.qty_control_manual_final_date, ");
        sbSql.Append("tbl_engg_construction_quality_milestone.final_handover_punchlist_date, tbl_engg_construction_quality_milestone.punchlist_satisfied_date, ");
        sbSql.Append("tbl_engg_construction_quality_milestone.remark_control_manual_draft, tbl_engg_construction_quality_milestone.remark_control_manual_final, ");
        sbSql.Append("tbl_engg_construction_quality_milestone.remark_final_handover_punchlist, tbl_engg_construction_quality_milestone.remark_punchlist_satisfied, ");
        sbSql.Append("tbl_engg_construction_quality_milestone.entry_date, tbl_engg_construction_quality_milestone.entry_user ");
        sbSql.Append("FROM ");
        sbSql.Append("public.base_tbl_fiscal_quarter_info, public.base_tbl_fiscal_year_info, ");
        sbSql.Append("public.base_tbl_package_info, public.tbl_engg_construction_quality_milestone ");
        sbSql.Append("WHERE (");
        sbSql.Append("tbl_engg_construction_quality_milestone.package_no = base_tbl_package_info.package_no AND ");
        sbSql.Append("tbl_engg_construction_quality_milestone.qty_milestone_year_id = base_tbl_fiscal_year_info.fiscal_year_id AND ");
        sbSql.Append("tbl_engg_construction_quality_milestone.qty_milestone_quarter_id = base_tbl_fiscal_quarter_info.quarter_id");
        if (!string.IsNullOrEmpty(condition))
        {
            sbSql.Append(" AND ");
            sbSql.Append(condition);
        }
        sbSql.Append(")");
        DataTable dt = dba.GetDataTable(sbSql.ToString());
        if (dt == null || dt.Rows.Count < 1)
        {
            lblDataTitle.ForeColor = Color.Red;
            lblDataTitle.Text = "Data not available !";
        }

        gvDataView.DataSource = dt;
        gvDataView.DataBind();

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


}
