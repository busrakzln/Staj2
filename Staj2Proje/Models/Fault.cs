namespace Staj2Proje.Models
{
    public class Fault
    {
        public int Id { get; set; } //Arıza ID
        public int CustomerId { get; set; } //Müşteri ID
        public string Description { get; set; } //Arıza Tanımı
        public DateTime ReportedDate { get; set; } //Bildirildiği Tarih
        public string Status { get; set; } //Arıza Durumu
    }
}
