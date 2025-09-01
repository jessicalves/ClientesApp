namespace ClientesApp.Models
{
    public class ClienteModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public int Age { get; set; }
        public AddressModel Address { get; set; } = new AddressModel();

        public string FullName => $"{Name} {Lastname}";
    }
}
