namespace EcommerceWebAPI.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        //public User? User { get; set; }
        //public int? UserId { get; set; }
        public ICollection<UserRole>? UserRoles { get; set; }
    }
    //public enum Roles
    //{
    //    User,
    //    Admin
    //}
}
