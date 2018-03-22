using Nice.Data.Repository;
using Nice.Domain.Entity.SystemSecurity;

namespace Nice.Repository.IRepository.SystemSecurity
{
    public interface IDbBackupRepository : IRepositoryBase<DbBackupBaseEntity>
    {
        void DeleteForm(string keyValue);
        void ExecuteDbBackup(DbBackupBaseEntity dbBackupBaseEntity);
    }
}
