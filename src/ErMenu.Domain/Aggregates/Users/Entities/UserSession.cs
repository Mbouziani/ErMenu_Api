namespace ErMenu.Domain.Aggregates.Users.Entities;

public class UserSession
{


    public int OpenDate { get; private set; }
    public int Time { get; private set; }
    public int UserID { get; private set; }
    public double OpenAmount { get; private set; }
    public int CloseDate { get; private set; }
    public int SesionID { get; private set; }
    public int Statuse { get; private set; }
    public string OpenInvoiceDateTime { get; private set; } = string.Empty;
    public string? CloseInvoiceDateTime { get; private set; }
    public int BranchID { get; private set; }
    public int PosID { get; private set; }
    public double CloseAmount { get; private set; }


    private UserSession() { }

    public static UserSession Create(
        int userId, 
        int branchId,
        int sessionId
        )
    {
        var now = DateTime.Now;

        return new UserSession
        {
            UserID = userId,
            SesionID = sessionId,
            BranchID = branchId,
            PosID = 1,
            OpenAmount = 0,
            CloseAmount = 0,
            Statuse = 0,

            OpenDate = int.Parse(now.ToString("yyyyMMdd")),
            Time = int.Parse(now.ToString("HHmm")),
            CloseDate = 0,

            OpenInvoiceDateTime = now.ToString("yyyy-MM-dd HH:mm:ss"),
            CloseInvoiceDateTime = null
        };
    }


    public FormattableString BuildInsertQuery()
    {

        return $@"
            INSERT INTO Sales_Open_Cashier
            (
                OpenDate,
                [time],
                UserID,
                OpenAmount,
                CloseDate,
                SesionID,
                Statuse,
                OpenInvoiceDateTime,
                CloseInvoiceDateTime,
                BranchID,
                PosID,
                CloseAmount
            )
            VALUES
            (
                {OpenDate},
                {Time},
                {UserID},
                {OpenAmount},
                {CloseDate},
                {SesionID},
                {Statuse},
                {OpenInvoiceDateTime},
                {CloseInvoiceDateTime},
                {BranchID},
                {PosID},
                {CloseAmount}
            )";
    }

}