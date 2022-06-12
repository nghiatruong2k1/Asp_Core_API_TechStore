using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helper
{
    public class JwtService
    {
        private string secureKey = "You_Need_To_Provide_A_Longer_Secret_Key_Here";
        protected string getKey()
        {
            return this.secureKey + "_" + DateTime.Now.ToShortDateString();
        }
        public string Generate(DateTime id)
        {
            return Generate(id.ToString());
        }
        public string Generate(int id)
        {
            return Generate(id.ToString());
        }
        public string Generate(String id)
        {
            var synKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(getKey()));
            var credentials = new SigningCredentials(synKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(id, null, null, null, DateTime.Today.AddDays(1));
            var synToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(synToken);
        }
        public JwtSecurityToken Verify(string jwt)
        {
            var header = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(getKey());
            var issuerKey = new SymmetricSecurityKey(key);

            header.ValidateToken(jwt,
                new TokenValidationParameters()
                {
                    IssuerSigningKey = issuerKey,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validateToken);

            return (JwtSecurityToken)validateToken;

        }
    }
}
