using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Nice.Data.Repository;
using Nice.Domain.Entity.SystemManage;
using Nice.Repository.IRepository.SystemManage;


namespace Nice.Repository.SystemManage
{
    public class ItemsDetailRepository : RepositoryBase<ItemsDetailBaseEntity>, IItemsDetailRepository
    {
        public List<ItemsDetailBaseEntity> GetItemList(string enCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  d.*
                            FROM    Sys_ItemsDetail d
                                    INNER  JOIN Sys_Items i ON i.F_Id = d.F_ItemId
                            WHERE   1 = 1
                                    AND i.F_EnCode = @enCode
                                    AND d.F_EnabledMark = 1
                                    AND d.F_DeleteMark = 0
                            ORDER BY d.F_SortCode ASC");
            DbParameter[] parameter = 
            {
                 new SqlParameter("@enCode",enCode)
            };
            return this.FindList(strSql.ToString(), parameter);
        }
    }
}
