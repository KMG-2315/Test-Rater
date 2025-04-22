using LoginService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utilities
{
    public class BaseUtility
    {
        public async Task<LoginReturn> GenerateIMSToken()
        {
            UserLogin userLogin = new UserLogin();
            userLogin.Username = "GBhalla";
            userLogin.Password = "vgVv3ZI3nT5M1rAMRLI2lg==";
            LogonSoapClient logonSoapClient = new LogonSoapClient(LogonSoapClient.EndpointConfiguration.LogonSoap);
            LoginReturn IMSToken = await logonSoapClient.LoginIMSUserAsync(userLogin.Username, userLogin.Password);
            return IMSToken;

        }
    }
}
