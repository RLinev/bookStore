namespace webapi
{
    public class TokenResp
    {
        public TokenResp(string token, bool isAdmin)
        {
            Token = token;
            IsAdmin = isAdmin;
        }
        public bool IsAdmin{ get; set; }

        public string Token { get; set; }
    }
}
