namespace JewelryStore.Model
{
    public class Product : EFModel
    {
        public List<TheProduct> TheProducts { get; set; } = new List<TheProduct>();
    }
}
