/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Code;
using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using Nice.Common;
using Nice.Common.Security;
using Nice.Domain.Entity.SystemManage;


namespace NFine.Application.SystemManage
{
    public class UserLogOnApp
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
            UserLogOnBaseEntity userLogOnBaseEntity = new UserLogOnBaseEntity();
            userLogOnBaseEntity.F_Id = keyValue;
            userLogOnBaseEntity.F_UserSecretkey = Md5.md5(Common.CreateNo(), 16).ToLower();
            userLogOnBaseEntity.F_UserPassword = Md5.md5(DesEncrypt.Encrypt(Md5.md5(userPassword, 32).ToLower(), userLogOnBaseEntity.F_UserSecretkey).ToLower(), 32).ToLower();
            service.Update(userLogOnBaseEntity);
        }
    }
}
