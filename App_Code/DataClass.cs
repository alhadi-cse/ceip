using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataClass
/// </summary>
/// 



public class DataClass
{
	public DataClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}

public class DataBillItem
{
    public string polder_no { get; set; }
    public string bill_no { get; set; }
    public string item_no { get; set; }
    public DateTime bill_date { get; set; }
    public double quantity { get; set; }
    public string comments { get; set; }
    public string entry_user { get; set; }
    public DateTime entry_date { get; set; }
}

public class DataProgress
{
    public string PackageNo { get; set; }
    public string PolderNo{ get; set; }
    public string IndicatorCode { get; set; }
    public string ProgressYear { get; set; }
    public string ProgressQuarter { get; set; }
    public DateTime ProgressDate { get; set; }
    public double ProgressValue { get; set; }
    public double TargetValue { get; set; }
    public double ProjectionValue { get; set; }
    public DateTime EntryDate { get; set; }
    public string EntryUser { get; set; }
    public string Remarks { get; set; }
}

public class DataTarget
{
    public string PackageNo { get; set; }
    public string PolderNo { get; set; }
    public string IndicatorCode { get; set; }
    public string TargetYear { get; set; }
    public string TargetQuarter { get; set; }
    public double TargetValue { get; set; }
    public string Remarks { get; set; }
    public DateTime EntryDate { get; set; }
    public string EntryUser { get; set; }
}



    //public string PolderNo { get; set; }
    //public string IndicatorCode { get; set; }
    //public string QtyControlManualDraftDate { get; set; }
    //public string QtyControlManualFinalDate { get; set; }
    //public string FinalHandoverPunchlistDate { get; set; }
    //public string PunchlistSatisfiedDate { get; set; }
    //public double QtyMilestoneValue { get; set; }
    //public string Remarks { get; set; }


//QtyControlManualDraftDate, QtyControlManualFinalDate, FinalHandoverPunchlistDate, PunchlistSatisfiedDate
public class QualityMilestone
{
    public string PackageNo { get; set; }
    public string QtyMilestoneYear { get; set; }
    public string QtyMilestoneQuarter { get; set; }
    public DateTime? QtyControlManualDraftDate { get; set; }
    public DateTime? QtyControlManualFinalDate { get; set; }
    public DateTime? FinalHandoverPunchlistDate { get; set; }
    public DateTime? PunchlistSatisfiedDate { get; set; }
    public string RemarkControlManualDraft { get; set; }
    public string RemarkControlManualFinal { get; set; }
    public string RemarkFinalHandoverPunchlist { get; set; }
    public string RemarkPunchlistSatisfied { get; set; }
    public DateTime? EntryDate { get; set; }
    public string EntryUser { get; set; }
}