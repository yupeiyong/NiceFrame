/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/

using System.Data.Entity.ModelConfiguration;
using Nice.Domain.Entity.SystemSecurity;


namespace NFine.Mapping.SystemSecurity
{
    public class FilterIPMap : EntityTypeConfiguration<FilterIpBaseEntity>
    {
        public FilterIPMap()
        {
            this.ToTable("Sys_FilterIP");
            this.HasKey(t => t.F_Id);
        }
    }
}
