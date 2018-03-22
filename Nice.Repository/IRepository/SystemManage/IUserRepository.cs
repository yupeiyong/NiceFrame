using Nice.Data.Repository;
using Nice.Domain.Entity.SystemManage;


namespace Nice.Repository.IRepository.SystemManage
{
    public interface IUserRepository : IRepositoryBase<UserBaseEntity>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(UserBaseEntity userBaseEntity, UserLogOnBaseEntity userLogOnBaseEntity, string keyValue);
    }
}
