namespace Registrasi
{
    public class REgistrasi
    {
        
        public class user
        {
            public string username { get; set; }
            public string password { get; set; }
            public string email { get; set; }
            public user(string username, string password, string email)
            {
                this.username = username;
                this.password = password;
                this.email = email;
            }
        }
    }
}
