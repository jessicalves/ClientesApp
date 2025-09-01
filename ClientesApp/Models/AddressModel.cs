namespace ClientesApp.Models
{
    public class AddressModel
    {
        public string Street { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Street}, {Complement}, {City} - {State}, {ZipCode}";
        }
    }
}
