namespace RentApp.Enums
{
    public static class DriverStatusColor
    {
        static readonly string onLease = "onLease";
        static readonly string free = "onLease";
        static readonly string freeSoon = "onLease";
        static readonly string onLeaseSoon = "onLease";

        static Dictionary<string, Color> Color = new Dictionary<string, Color>() {
             { "", Enums.Color.primary },
             { "", Enums.Color.secondary },
             { "", Enums.Color.success },
             { "", Enums.Color.danger },
             { "", Enums.Color.warning },
             { "", Enums.Color.info },
             { "", Enums.Color.light },
             { "", Enums.Color.dark },
             { "", Enums.Color.muted },
             { "", Enums.Color.white }
        };
    }
}
