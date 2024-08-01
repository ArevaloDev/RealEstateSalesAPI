namespace RealStateAPI.Models
{
    public class HousingLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Photo { get; set; }
        public int AvailableUnits { get; set; }
        public bool Wifi { get; set; }
        public bool Laundry { get; set; }
    }
}
