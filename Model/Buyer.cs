namespace JewelryStore.Model
{
    public class Buyer : EFModel
    {
        public int INN { get; set; }
        public string FIO { get; set; } = string.Empty;

    }
}
