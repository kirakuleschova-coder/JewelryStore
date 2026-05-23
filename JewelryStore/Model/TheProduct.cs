namespace JewelryStore.Model
{
    public class TheProduct : EFModel
    {
        public string Title { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Product { get; set; } = string.Empty;
        public int Test { get; set; }
        public int ProductionDate { get; set; }
    }
}
