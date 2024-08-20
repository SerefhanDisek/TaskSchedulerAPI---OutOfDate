namespace TaskSchedulerAPI.Core.Entities
{
    public class User
    {
        public int Id { get; set; }  // User ID, primary key
        public string Username { get; set; }  // Kullanıcı adı
        public string Email { get; set; }  // Email adresi
        public string PasswordHash { get; set; }  // Şifre hash'i
        public ICollection<UserTask> UserTasks { get; set; }  // Kullanıcının task'ları ile ilişkisi
    }

}
