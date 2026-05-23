namespace JewelryStore.Model
{
    public class Manufacturer : EFModel
    {
        public string Title { get; set; } = string.Empty;
        public int INN { get; set; }
        public string FIO { get; set; } = string.Empty;
    }
}
