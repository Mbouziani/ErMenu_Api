namespace ErMenu.Domain.Aggregates.Orders.Entities;


public class Sales_SalesInvoiceDetails
{
    public int GroupID { get; set; }
    public int ID { get; set; }
    public int InvoiceID { get; set; }
    public string BarCode { get; set; } = string.Empty;
    public int ItemID { get; set; }
    public string ArbItemName { get; set; } = string.Empty;
    public string AdditionalName { get; set; } = string.Empty;
    public string EngItemName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int SizeID { get; set; }


    public string ArbSizeName { get; set; } = string.Empty;
    public string EngSizeName { get; set; } = string.Empty;
    public string ExpiryDate { get; set; } = string.Empty;
    public decimal QTY { get; set; }
    public decimal SalePrice { get; set; }
    public decimal Bones { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }
    public decimal AdditionalValue { get; set; }
    public decimal Net { get; set; }
    public bool HavVat { get; set; }
    public decimal CostPrice { get; set; }

    public int TheCount { get; set; }
    public decimal Caliber { get; set; }
    public decimal Equivalen { get; set; }
    public decimal BAGET_W { get; set; }
    public decimal STONE_W { get; set; }
    public decimal DIAMOND_W { get; set; }
    public decimal PackingQty { get; set; }

    public double Height { get; set; }
    public double Width { get; set; }
    public string Serials { get; set; } = string.Empty;


    public int Cancel { get; set; }

    public int StoreID { get; set; }
    public int BranchID { get; set; }
    public int FacilityID { get; set; }
    public long ExpiryDateStr { get; set; }
    public float RemainQty { get; set; }
    public byte[] ItemImage { get; set; } = [];



    public static Sales_SalesInvoiceDetails Create(
        int itemId,
        int sizeId,
        int branchId,
        string barcode,
        decimal quantity,
        decimal unitPriceNet,
        decimal taxAmount,
        decimal NetAmount,
        decimal totalAmount,
        decimal totalDiscount,
        string additionalInfo = "")
    {
        return new Sales_SalesInvoiceDetails
        {

            ID = 0,
            ItemID = itemId,
            InvoiceID = 0,
            BarCode = barcode,
            EngItemName = "",
            ArbItemName = "",
            SizeID = sizeId,
            ArbSizeName = "",
            EngSizeName = "",
            QTY = quantity,
            AdditionalName = additionalInfo,
            PackingQty = 1,
            Bones = 0,
            Height = 0,
            Width = 0,
            TheCount = 1,
            Serials = "",
            SalePrice = unitPriceNet,
            CostPrice = 0,
            Equivalen = 0,
            Caliber = 0,
            Total = NetAmount,
            Discount = totalDiscount,
            AdditionalValue = taxAmount,
            Net = totalAmount,
            BAGET_W = 0,
            STONE_W = 0,
            DIAMOND_W = 0,
            FacilityID = 1,
            StoreID =4,
            Cancel = 0,
            HavVat = true,
            Description = "",
            ExpiryDate = "20240101",
            ExpiryDateStr = 20240101,
            RemainQty = 0,
            ItemImage = [],
            BranchID= branchId

            
        };

    } 
}
