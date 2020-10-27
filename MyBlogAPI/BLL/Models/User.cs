namespace BLL.Models
{
    public class User
    {
        public int Id { get; set; }
        public byte Role { get; set; }
        public string Username { get; set; }
        public string EMail { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordKey { get; set; }
        public string Address { get; set; }
    }
}
