﻿#nullable disable

namespace TestUserDataConnection.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int? Typeuser { get; set; }

        public virtual UserType IdNavigation { get; set; }
    }
}
