using System;
using System.Collections.Generic;
using Nice.Common.Extend;
using Nice.Common.Security;
using Nice.Common.Web;
using Nice.Domain.Entity.SystemManage;
using Nice.Repository.IRepository.SystemManage;
using Nice.Repository.SystemManage;


namespace Nice.Service.SystemManage
{
    public class UserService
    {
        private IUserRepository service = new UserRepository();
        private UserLogOnService _userLogOnService = new UserLogOnService();

        public List<UserBaseEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<UserBaseEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_Account.Contains(keyword));
                expression = expression.Or(t => t.F_RealName.Contains(keyword));
                expression = expression.Or(t => t.F_MobilePhone.Contains(keyword));
            }
            expression = expression.And(t => t.F_Account != "admin");
            return service.FindList(expression, pagination);
        }
        public UserBaseEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
        }
        public void SubmitForm(UserBaseEntity userBaseEntity, UserLogOnBaseEntity userLogOnBaseEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                userBaseEntity.Modify(keyValue);
            }
            else
            {
                userBaseEntity.Create();
            }
            service.SubmitForm(userBaseEntity, userLogOnBaseEntity, keyValue);
        }
        public void UpdateForm(UserBaseEntity userBaseEntity)
        {
            service.Update(userBaseEntity);
        }
        public UserBaseEntity CheckLogin(string username, string password)
        {
            UserBaseEntity userBaseEntity = service.FindEntity(t => t.F_Account == username);
            if (userBaseEntity != null)
            {
                if (userBaseEntity.F_EnabledMark == true)
                {
                    UserLogOnBaseEntity userLogOnBaseEntity = _userLogOnService.GetForm(userBaseEntity.F_Id);
                    string dbPassword = Md5.md5(DesEncrypt.Encrypt(password.ToLower(), userLogOnBaseEntity.F_UserSecretkey).ToLower(), 32).ToLower();
                    if (dbPassword == userLogOnBaseEntity.F_UserPassword)
                    {
                        DateTime lastVisitTime = DateTime.Now;
                        int LogOnCount = (userLogOnBaseEntity.F_LogOnCount).ToInt() + 1;
                        if (userLogOnBaseEntity.F_LastVisitTime != null)
                        {
                            userLogOnBaseEntity.F_PreviousVisitTime = userLogOnBaseEntity.F_LastVisitTime.ToDate();
                        }
                        userLogOnBaseEntity.F_LastVisitTime = lastVisitTime;
                        userLogOnBaseEntity.F_LogOnCount = LogOnCount;
                        _userLogOnService.UpdateForm(userLogOnBaseEntity);
                        return userBaseEntity;
                    }
                    else
                    {
                        throw new Exception("密码不正确，请重新输入");
                    }
                }
                else
                {
                    throw new Exception("账户被系统锁定,请联系管理员");
                }
            }
            else
            {
                throw new Exception("账户不存在，请重新输入");
            }
        }
    }
}
