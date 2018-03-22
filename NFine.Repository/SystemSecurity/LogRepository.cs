﻿/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/

using NFine.Domain.IRepository.SystemSecurity;
using NFine.Repository.SystemSecurity;
using Nice.Data.Repository;
using Nice.Domain.Entity.SystemSecurity;


namespace NFine.Repository.SystemSecurity
{
    public class LogRepository : RepositoryBase<LogBaseEntity>, ILogRepository
    {
       
    }
}
