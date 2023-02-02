namespace RentApp.Enums
{
    using System.ComponentModel;
    public enum CarStatusColor
    {
        //
        [Description("secondary")]
        secondary,
        [Description("primary")]
        primary,
        [Description("success")]
        success,
        [Description("warning")]
        warning,
        [Description("orange")]
        orange,
        [Description("danger")]
        danger,
        [Description("white")]
        white
    }
}