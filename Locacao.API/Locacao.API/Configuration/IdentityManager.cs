using Locacao.API.Extensions;
using Locacao.Domain.Entity;
using Locacao.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Locacao.API.Configuration
{
    public class IdentityManager : IIdentityManager
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly AppSettings _appSettings;
        public IdentityManager(
            UserManager<Usuario> userManager,
            IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        public async Task<LoginDto> GenerateJwt(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));            
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.ValidOn,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = identityClaims
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginDto
            {
                AccessToken = encodedToken,
                ExpiresIn = (int)TimeSpan.FromHours(_appSettings.ExpirationTime).TotalSeconds,
                UserToken = new UserTokenDto
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                    Claims = claims.Select(e => new ClaimDto { Type = e.Type, Value = e.Value }),
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
