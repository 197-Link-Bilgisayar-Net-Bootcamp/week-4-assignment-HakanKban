using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace Week4.AuthorizationWithJWT.Models
{
    public class TokenHandler
    {
        public IConfiguration Configuration { get; set; }

        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //Token üretecek metod
        public Token CreateAccessToken(User user)
        {
            Token tokenInstance = new Token();
            //Security Key'in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Oluşturulacak olan tokenin ayarlarını veriyoruz.

            tokenInstance.Expiration = DateTime.Now.AddMinutes(5);
            JwtSecurityToken securityToken = new JwtSecurityToken
                (
            issuer: Configuration["Token:Issuer"],
            audience: Configuration["Token:Audience"],
            expires: tokenInstance.Expiration,//Token süresini 5 dk olarak belirliyorum
            notBefore: DateTime.Now,//Token üretildikten ne kadar süre sonra devreye girsin ayarlıyouz.
            signingCredentials: signingCredentials
                );
            // Token oluşturucu sınıfından bir örnek alıyoruz
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            //Token üretiyoruz
            tokenInstance.AccessToken = tokenHandler.WriteToken(securityToken);

            //refresh token üretiyoruz
            tokenInstance.RefreshToken = CreateRefreshToken();
            return tokenInstance;
        }
        //Refresh token üretecek metod
        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random= RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
