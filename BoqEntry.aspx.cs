using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Globalization;

public partial class BoqEntry : System.Web.UI.Page
{
    private DbAdmin dba = new DbAdmin();
    private BOQClass boq = new BOQClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Session["ReturnUrl"] = "BoqEntry.aspx";
            Response.Redirect("LoginUser.aspx");
        }
        if (!IsPostBack)
        {
            dba.LoadDropDownList("select distinct polder_no from boq_info order by polder_no", ddlPolderNo, "polder_no",
                "polder_no", "---select polder---", true);
            ddlBillNo.Items.Add(new ListItem("---select bill no---", "-1"));
            ddlItemNo.Items.Add(new ListItem("---select bill item---", "-1"));
        }

    }

    protected void ddlPolderNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBillNo.Items.Count > 0)
            ddlBillNo.Items.Clear();
        if (ddlItemNo.Items.Count > 0)
            ddlItemNo.Items.Clear();
        if (ddlPolderNo.SelectedValue.Equals("-1"))
        {
            ddlBillNo.Items.Add(new ListItem("---select bill no---", "-1"));
        }
        else
        {
            dba.LoadDropDownList(
                "select distinct bill_no from boq_info where polder_no='" + ddlPolderNo.SelectedValue +
                "' order by bill_no", ddlBillNo, "bill_no", "bill_no", "---select bill no---", true);
        }
        ddlItemNo.Items.Add(new ListItem("---select bill item---", "-1"));


    }

    protected void ddlBillNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlItemNo.Items.Count > 0)
            ddlItemNo.Items.Clear();
        if (ddlBillNo.SelectedValue.Equals("-1"))
        {
            ddlItemNo.Items.Add(new ListItem("---select bill item---", "-1"));
        }
        else
        {
            dba.LoadDropDownList(
                "select distinct item_no from boq_info where polder_no='" + ddlPolderNo.SelectedValue +
                "' and bill_no='" + ddlBillNo.SelectedValue + "' order by item_no", ddlItemNo, "item_no", "item_no",
                "---select bill item---", true);
        }
    }

    protected void ddlItemNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadBillItem();
    }

    protected void btnRefreshData_Click(object sender, EventArgs e)
    {
        LoadBillItem();
    }

    public void LoadBillItem()
    {
        string msg = string.Empty;
        if (ddlPolderNo.SelectedValue.Equals("-1"))
        {
            msg = "please select polder no";
            goto Finish;
        }
        if (ddlBillNo.SelectedValue.Equals("-1"))
        {
            msg = "please select bill no";
            goto Finish;
        }
        if (ddlItemNo.SelectedValue.Equals("-1"))
        {
            msg = "please select bill item";
            goto Finish;
        }
        DataTable table =
            dba.GetDataTable("select * from boq_info where polder_no='" + ddlPolderNo.SelectedValue + "' and bill_no='" +
                             ddlBillNo.SelectedValue + "' and item_no='" + ddlItemNo.SelectedValue + "'");
        if (table != null && table.Rows.Count > 0)
        {
            lblItemCode.Text = "<b>Item Code No. : </b> " + table.Rows[0]["code_no"].ToString();
            lblItemDesc.Text = "<b>Item Description : </b> " + table.Rows[0]["item_desc"].ToString();
            lblItemUnit.Text = "<b>Item Unit : </b> " + table.Rows[0]["unit_name"].ToString();
            lblMaxQuantity.Text = "Maximum entered quantity : " + table.Rows[0]["quantity"].ToString();
            PanelBillEntry.Visible = true;
        }
        Finish:
        if (!string.IsNullOrEmpty(msg))
        {
            PanelBillEntry.Visible = false;
            //modalHeaderTitle_Msg.Text = "User Registration";
            modal_msg_text.Text = msg;
            modal_Msg.Show();

        }

    }


    protected void btnSaveBillEntry_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        if (string.IsNullOrEmpty(txtBillDate.Text.Trim()))
        {
            msg = "Bill date not empty!!!";
            goto Finish;
        }
        if (string.IsNullOrEmpty(txtQuantity.Text.Trim()))
        {
            msg = "Bill quantity not empty!!!";
            goto Finish;
        }

        DataBillItem dataKey = new DataBillItem();
        dataKey.polder_no = ddlPolderNo.SelectedValue;
        dataKey.bill_no = ddlBillNo.SelectedValue;
        dataKey.item_no = ddlItemNo.SelectedValue;
        dataKey.bill_date = DateTime.ParseExact(txtBillDate.Text.Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
        dataKey.quantity = string.IsNullOrEmpty(txtQuantity.Text.Trim()) ? 0.0 : Double.Parse(txtQuantity.Text.Trim());
        dataKey.comments = txtComments.Text.Trim();
        dataKey.entry_user = Session["UserID"] == null ? "-1" : Session["UserID"].ToString();
        dataKey.entry_date = DateTime.Now;
        if (boq.BillItemInsert(dataKey))
        {
            msg = "Successfully insert bill item";
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