using System.Collections.Generic;
using Nice.Data.Repository;
using Nice.Domain.Entity.SystemManage;


namespace Nice.Repository.IRepository.SystemManage
{
    public interface IModuleButtonRepository : IRepositoryBase<ModuleButtonBaseEntity>
    {
        void SubmitCloneButton(List<ModuleButtonBaseEntity> entitys);
    }
}
