using Nice.Common.Security;
using Nice.Data.Repository;
using Nice.Domain.Entity.SystemManage;
using Nice.Repository.IRepository.SystemManage;


namespace Nice.Repository.SystemManage
{
    public class UserRepository : RepositoryBase<UserBaseEntity>, IUserRepository
    {
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<UserBaseEntity>(t => t.F_Id == keyValue);
                db.Delete<UserLogOnBaseEntity>(t => t.F_UserId == keyValue);
                db.Commit();
            }
        }
        public void SubmitForm(UserBaseEntity userBaseEntity, UserLogOnBaseEntity userLogOnBaseEntity, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Update(userBaseEntity);
                }
                else
                {
                    userLogOnBaseEntity.F_Id = userBaseEntity.F_Id;
                    userLogOnBaseEntity.F_UserId = userBaseEntity.F_Id;
                    userLogOnBaseEntity.F_UserSecretkey = Md5.md5(Nice.Common.Common.CreateNo(), 16).ToLower();
                    userLogOnBaseEntity.F_UserPassword = Md5.md5(DesEncrypt.Encrypt(Md5.md5(userLogOnBaseEntity.F_UserPassword, 32).ToLower(), userLogOnBaseEntity.F_UserSecretkey).ToLower(), 32).ToLower();
                    db.Insert(userBaseEntity);
                    db.Insert(userLogOnBaseEntity);
                }
                db.Commit();
            }
        }
    }
}
