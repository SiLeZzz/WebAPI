namespace WebAPI.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Settlement?> Settlements { get; set; }
    }
}
