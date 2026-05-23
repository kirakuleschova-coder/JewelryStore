namespace JewelryStore.Model
{
    public class AuthUser : EFModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}