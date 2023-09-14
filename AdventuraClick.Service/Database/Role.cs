namespace AdventuraClick.Service.Database
{
<<<<<<< Updated upstream
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
=======
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
>>>>>>> Stashed changes
}

