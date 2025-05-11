namespace ecommerce_app.Models
{
    public class Transaction
    {
        public string Description { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty; // e.g., "$15.00" or "-$4.50"
        public bool IsCredit { get; set; } // true = credit (green), false = debit (red)
        // public string FormattedAmount => (Amount >= 0 ? "+" : "-") + "$" + Math.Abs(Amount).ToString("F2");
      
    }
}
