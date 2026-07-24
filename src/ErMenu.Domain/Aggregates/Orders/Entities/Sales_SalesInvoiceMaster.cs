namespace ErMenu.Domain.Aggregates.Orders.Entities;

public class Sales_SalesInvoiceMaster
{


    public int TypeAccount { get; set; } = 1;
    public int InvoiceID { get; set; }
    public int InvoiceCode { get; set; }
    public int BranchID { get; set; }
    public int PosID { get; set; }
    public int FacilityID { get; set; }
    public string CustomerMobile { get; set; } = string.Empty;
    public string AddressCustomer { get; set; } = string.Empty;
    public string InvoiceDate { get; set; } = string.Empty;
    public string LastPrintDate { get; set; } = string.Empty;
    public int MethodeID { get; set; }
    public double CustomerID { get; set; }
    public int CurencyID { get; set; }
    public int PrintCount { get; set; } = 1;
    public int CostCenterID { get; set; }
    public int SellerID { get; set; }
    public int StoreID { get; set; }
    public double DelegateID { get; set; }
    public string Notes { get; set; } = string.Empty;
    public decimal DiscountOnTotal { get; set; }
    public double DebitAccount { get; set; }
    public double CreditAccount { get; set; }
    public double DiscountDebitAccount { get; set; }
    public double AdditionalAccount { get; set; }

    public int FromCashierScreen { get; set; }
    public int CloseCashier { get; set; }
    public double CloseCashierDate { get; set; }
    public string NetProcessID { get; set; } = string.Empty;
    public string CheckID { get; set; } = string.Empty;
    public double CheckAccount { get; set; }

    public string CheckSpendDate { get; set; } = string.Empty;
    public string WarningDate { get; set; } = string.Empty;
    public string ReceiveDate { get; set; } = string.Empty;
    public DateTime InvoiceDateTime { get; set; }

    public int DailyID { get; set; }
    public string OrderType { get; set; } = string.Empty;
    public int SectionID { get; set; }
    public int TableID { get; set; }
    public int NeedReview { get; set; }
    public string ReviewType { get; set; } = string.Empty;
    public int IsSendReview { get; set; }
    public string WorkDetails { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int DocumentID { get; set; }
    public int UserID { get; set; }
    public int CurentSesionID { get; set; } = 0;
    public double RegDate { get; set; }
    public double RegTime { get; set; }
    public double RegTimeHour { get; set; }
    public double RegTimeMintes { get; set; }
    public int EditUserID { get; set; }
    public double EditTime { get; set; }
    public double EditDate { get; set; }
    public string ComputerInfo { get; set; } = string.Empty;
    public string EditComputerInfo { get; set; } = string.Empty;
    public int Cancel { get; set; }
    public double EmployeeID { get; set; }
    public double PateintID { get; set; }
    public double TempInvoiceID { get; set; }
    public double EnduranceRatio { get; set; }
    public Nullable<double> NetAmount { get; set; }
    public Nullable<double> NetAccount { get; set; }
    public int RegistrationNo { get; set; }

    public string VATID { get; set; } = string.Empty;
    public double NetType { get; set; }
    public decimal AdditionaAmountTotal { get; set; }
    public decimal InvoiceTotal { get; set; }
    public decimal InsuranceAmmount { get; set; }


    public string CostCenterName { get; set; } = string.Empty;
    public string StoreName { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public double Total { get; set; }
    public double Vat { get; set; }
    public decimal Descount { get; set; }
    public double Net { get; set; }
    public string SaleMethod { get; set; } = string.Empty;
    public decimal NetBalance { get; set; }
    public List<Sales_SalesInvoiceDetails> SaleDatails { get; set; } = [];

    public string OperationTypeName { get; set; } = string.Empty;
    public decimal RemaindAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public int LenID { get; set; }
    public int BrandID { get; set; }



   
    public static Sales_SalesInvoiceMaster Create(
      int branchId,
      int methodeId,
      double cardPaymentAmount,
      decimal netAmount,
      decimal taxAmount,
      decimal totalAmount,
      decimal totalDiscount,
      int userId,
      int sessionId,
    List<Sales_SalesInvoiceDetails> saleDetails)
    {
        return new Sales_SalesInvoiceMaster
        {
            TypeAccount = 1,
            InvoiceID = 1,
            InvoiceCode = 1,
            BranchID = branchId,
            PosID = 1,
            FacilityID = 1,
            CustomerMobile = "",
            AddressCustomer = "",
            InvoiceDate = DateTime.Now.ToString("yyyyMMdd"),
            LastPrintDate = DateTime.Now.ToString("yyyyMMdd"),
            MethodeID = methodeId,
            CustomerID = 1,
            CurencyID = 13,
            PrintCount = 0,
            CostCenterID = 1,
            StoreID=4,//------------------
            SellerID = 4,//------------------
            DelegateID = 1,
            Notes = "",
            DiscountOnTotal = 0,
            DebitAccount = 12010000001,
            CreditAccount = 41010000001,
            DiscountDebitAccount = 31030000001,
            AdditionalAccount = 23020000001,
            FromCashierScreen = 0,//------------------
            CloseCashier = 0,
            CloseCashierDate = 0,
            NetProcessID = "0",
            CheckID = "0",
            CheckAccount = 12020000001,
            CheckSpendDate = "0",
            WarningDate = "0",
            ReceiveDate = "0",
            InvoiceDateTime = DateTime.Now,
            DailyID = 0,
            OrderType = "0",//------------------
            SectionID = 1,
            TableID = 0,
            NeedReview = 0,
            ReviewType = "",
            IsSendReview = 0,
            WorkDetails = "",
            Status = "0",
            DocumentID = 0,//------------------
            UserID = userId,
            CurentSesionID = sessionId,
            RegDate = double.TryParse(DateTime.Now.ToString("yyyyMMdd"), out double regDate) ? regDate : 0,
            RegTime = double.TryParse(DateTime.Now.ToString("HHmm"), out double regtime) ? regtime : 0,
            RegTimeHour = double.TryParse(DateTime.Now.ToString("HH"), out double regtimehour) ? regtimehour : 0,
            RegTimeMintes = double.TryParse(DateTime.Now.ToString("mm"), out double regTimeMintes) ? regTimeMintes : 0,
            EditUserID = userId,
            EditTime = 0,
            EditDate = 0,
            ComputerInfo = "Desktop-cf58pjf",//------------------
            EditComputerInfo = "",
            Cancel = 0,
            EmployeeID = 0,//------------------
            PateintID = 0,
            TempInvoiceID = 0,
            EnduranceRatio = 0,
            NetAmount = cardPaymentAmount,
            NetAccount = 12020000001,
            RegistrationNo = 0,
            VATID = "0",
            NetType = 1,
            AdditionaAmountTotal = taxAmount,
            InvoiceTotal = netAmount,
            InsuranceAmmount = 0,
            CostCenterName = "",
            StoreName = "",
            CustomerName = "",
            Total = 0,
            Vat = 0,
            Descount = totalDiscount,
            Net = 0,
            SaleMethod = "",
            NetBalance = totalAmount,//------------------
            OperationTypeName = "",
            RemaindAmount = 0,
            PaidAmount = 0,
            LenID = 0,
            BrandID = branchId,
            SaleDatails = saleDetails,
           
            
        };
    }





} 