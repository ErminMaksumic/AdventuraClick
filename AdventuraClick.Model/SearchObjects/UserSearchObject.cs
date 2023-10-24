namespace AdventuraClick.Model.SearchObjects
{
    public class UserSearchObject : BaseSearchObject
    {
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public bool IncludeRole { get; set; }
    }
}
