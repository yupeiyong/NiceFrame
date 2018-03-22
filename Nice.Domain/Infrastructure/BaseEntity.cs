using System;
using Nice.Common.Operator;


namespace Nice.Domain.Infrastructure
{
    public class BaseEntity
    {
        public void Create()
        {
            var entity = this as ICreationAudited;
            entity.F_Id = Common.Common.GuId();
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                entity.F_CreatorUserId = LoginInfo.UserId;
            }
            entity.F_CreatorTime = DateTime.Now;
        }
        public void Modify(string keyValue)
        {
            var entity = this as IModificationAudited;
            entity.F_Id = keyValue;
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                entity.F_LastModifyUserId = LoginInfo.UserId;
            }
            entity.F_LastModifyTime = DateTime.Now;
        }
        public void Remove()
        {
            var entity = this as IDeleteAudited;
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                entity.F_DeleteUserId = LoginInfo.UserId;
            }
            entity.F_DeleteTime = DateTime.Now;
            entity.F_DeleteMark = true;
        }
    }
}
