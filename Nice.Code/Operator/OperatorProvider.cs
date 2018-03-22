using NFine.Code;
using Nice.Common.Json;
using Nice.Common.Security;
using Nice.Common.Web;


namespace Nice.Common.Operator
{
    public class OperatorProvider
    {
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }
        private string LoginUserKey = "nfine_loginuserkey_2016";
        private string LoginProvider = Nice.Common.Configs.Configs.GetValue("LoginProvider");

        public OperatorModel GetCurrent()
        {
            OperatorModel operatorModel = new OperatorModel();
            if (LoginProvider == "Cookie")
            {
                operatorModel = DesEncrypt.Decrypt(WebHelper.GetCookie(LoginUserKey).ToString()).ToObject<OperatorModel>();
            }
            else
            {
                operatorModel = DesEncrypt.Decrypt(WebHelper.GetSession(LoginUserKey).ToString()).ToObject<OperatorModel>();
            }
            return operatorModel;
        }
        public void AddCurrent(OperatorModel operatorModel)
        {
            if (LoginProvider == "Cookie")
            {
                WebHelper.WriteCookie(LoginUserKey, DesEncrypt.Encrypt(operatorModel.ToJson()), 60);
            }
            else
            {
                WebHelper.WriteSession(LoginUserKey, DesEncrypt.Encrypt(operatorModel.ToJson()));
            }
            WebHelper.WriteCookie("nfine_mac", Md5.md5(Net.Net.GetMacByNetworkInterface().ToJson(), 32));
            //WebHelper.WriteCookie("nfine_licence", Licence.GetLicence());
        }
        public void RemoveCurrent()
        {
            if (LoginProvider == "Cookie")
            {
                WebHelper.RemoveCookie(LoginUserKey.Trim());
            }
            else
            {
                WebHelper.RemoveSession(LoginUserKey.Trim());
            }
        }
    }
}
