#nullable disable

namespace TestUserDataConnection.Models
{
    public partial class UserType
    {
        public int Id { get; set; }
        public string Typename { get; set; }

        public virtual User User { get; set; }
    }
}
