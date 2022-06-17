namespace Week4.AuthorizationWithJWT.Models
{
    public class Token
    {
        // Üretilecek token ve refresh token değerlerini taşıyacak olan token modeli
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
