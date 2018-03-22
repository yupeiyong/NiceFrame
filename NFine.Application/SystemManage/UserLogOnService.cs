using Nice.Common.Security;
using Nice.Domain.Entity.SystemManage;
using Nice.Repository.IRepository.SystemManage;
using Nice.Repository.SystemManage;


namespace Nice.Service.SystemManage
{
    public class UserLogOnService
    {
        private IUserLogOnRepository service = new UserLogOnRepository();

        public UserLogOnBaseEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void UpdateForm(UserLogOnBaseEntity userLogOnBaseEntity)
        {
            service.Update(userLogOnBaseEntity);
        }
        public void RevisePassword(string userPassword,string keyValue)
        {
            UserLogOnBaseEntity userLogOnBaseEntity = new UserLogOnBaseEntity
            {
                F_Id = keyValue,
                F_UserSecretkey = Md5.md5(Common.Common.CreateNo(), 16).ToLower()
            };
            userLogOnBaseEntity.F_UserPassword = Md5.md5(DesEncrypt.Encrypt(Md5.md5(userPassword, 32).ToLower(), userLogOnBaseEntity.F_UserSecretkey).ToLower(), 32).ToLower();
            service.Update(userLogOnBaseEntity);
        }
    }
}
