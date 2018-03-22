using System.Collections.Generic;
using Nice.Data.Repository;
using Nice.Domain.Entity.SystemManage;
using Nice.Repository.IRepository.SystemManage;


namespace Nice.Repository.SystemManage
{
    public class ModuleButtonRepository : RepositoryBase<ModuleButtonBaseEntity>, IModuleButtonRepository
    {
        public void SubmitCloneButton(List<ModuleButtonBaseEntity> entitys)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                foreach (var item in entitys)
                {
                    db.Insert(item);
                }
                db.Commit();
            }
        }
    }
}
