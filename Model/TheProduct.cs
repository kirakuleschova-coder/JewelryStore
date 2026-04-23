using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JewelryStore.Model
{
    public class TheProduct : EFModel
    {
        [Required(ErrorMessage = "Требуется название.")]
        [JsonIgnore]
        public string Title { get; set; } = string.Empty;
        [Range(1, 1000000, ErrorMessage = "Цена должна быть от 1 до 1000000")]
        public int Price { get; set; }
        public string Product { get; set; } = string.Empty;
        [Range(1, 5, ErrorMessage = "Проба должна быть от 1 до 5")]
        public int Test { get; set; }
        public int ProductionDate { get; set; }
    }
}
