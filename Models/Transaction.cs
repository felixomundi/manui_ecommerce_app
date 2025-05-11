namespace ecommerce_app.Models
{
    public class Transaction
    {
        public string Description { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty; 
        public bool IsCredit { get; set; }
      
    }
}
