namespace Staj2Proje.Models
{
    public class Invoice
    {
        public int Id { get; set; } //Fatura ID
        public int CustomerID { get; set; } //Müşteri ID
        public decimal Amount { get; set; } //Tutar
        public DateTime DueDate { get; set; } // Ödeme Tarihi
        public  bool  IsPaid { get; set; } // Ödeme Durumu
        public decimal Consumption { get; set; } //Tüketim miktarı
    }
}
