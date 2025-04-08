namespace Staj2Proje.Models
{
    public class Outage
    {
        public int Id { get; set; } //Kesinti ID
        public int MyProperty { get; set; } //Bölge
        public DateTime StartTime { get; set; } //Başlangıç Zamanı
        public DateTime EndTime { get; set; } //Bitiş Zamanı
        public string Details { get; set; } //Kesinti Detayları
    }
}
