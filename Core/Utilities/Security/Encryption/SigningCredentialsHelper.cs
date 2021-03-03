using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)//web apinin kullanabileceği jtw nin ulaşabilmesi için kullanabileceğimiz değerler
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);//security key olarak security key kullan ve hmcha512 algoirtmasını kullan
        }


    }
}
