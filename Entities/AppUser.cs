namespace InnovativeSoftware.Entities
{
    public class AppUser
    {
        //Entity frame work will regonize this as a database id, and will increment this for users. 
        public int Id { get; set; }
        
        public string User{ get; set; }

        public string TokenIFTT { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
        
    }
}