﻿namespace AdventuraClick.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName}{LastName}";
        public int? RoleId { get; set; }
        public byte[] Image { get; set; }
        public virtual Role Role { get; set; }
    }
}
