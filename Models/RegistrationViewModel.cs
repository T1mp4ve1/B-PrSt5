namespace Hotel.Models
{
    public class RegistrationViewModel
    {
        public List<ClienteModel> Utenti { get; set; }
        public Dictionary<string, IList<string>> Ruoli { get; set; }
        public RegistrationModel NuovoDipendente { get; set; }

    }
}
