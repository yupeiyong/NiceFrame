/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Code;
using NFine.Domain.IRepository.SystemSecurity;
using NFine.Repository.SystemSecurity;
using System;
using System.Collections.Generic;
using Nice.Common;
using Nice.Common.Extend;
using Nice.Common.Json;
using Nice.Common.Net;
using Nice.Common.Operator;
using Nice.Common.Web;
using Nice.Domain.Entity.SystemSecurity;


namespace NFine.Application.SystemSecurity
{
    public class LogApp
    {
        private ILogRepository service = new LogRepository();

        public List<LogBaseEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<LogBaseEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyword = queryParam["keyword"].ToString();
                expression = expression.And(t => t.F_Account.Contains(keyword));
            }
            if (!queryParam["timeType"].IsEmpty())
            {
                string timeType = queryParam["timeType"].ToString();
                DateTime startTime = DateTime.Now.ToString("yyyy-MM-dd").ToDate();
                DateTime endTime = DateTime.Now.ToString("yyyy-MM-dd").ToDate().AddDays(1);
                switch (timeType)
                {
                    case "1":
                        break;
                    case "2":
                        startTime = DateTime.Now.AddDays(-7);
                        break;
                    case "3":
                        startTime = DateTime.Now.AddMonths(-1);
                        break;
                    case "4":
                        startTime = DateTime.Now.AddMonths(-3);
                        break;
                    default:
                        break;
                }
                expression = expression.And(t => t.F_Date >= startTime && t.F_Date <= endTime);
            }
            return service.FindList(expression, pagination);
        }
        public void RemoveLog(string keepTime)
        {
            DateTime operateTime = DateTime.Now;
            if (keepTime == "7")            //保留近一周
            {
                operateTime = DateTime.Now.AddDays(-7);
            }
            else if (keepTime == "1")       //保留近一个月
            {
                operateTime = DateTime.Now.AddMonths(-1);
            }
            else if (keepTime == "3")       //保留近三个月
            {
                operateTime = DateTime.Now.AddMonths(-3);
            }
            var expression = ExtLinq.True<LogBaseEntity>();
            expression = expression.And(t => t.F_Date <= operateTime);
            service.Delete(expression);
        }
        public void WriteDbLog(bool result, string resultLog)
        {
            LogBaseEntity logBaseEntity = new LogBaseEntity();
            logBaseEntity.F_Id = Common.GuId();
            logBaseEntity.F_Date = DateTime.Now;
            logBaseEntity.F_Account = OperatorProvider.Provider.GetCurrent().UserCode;
            logBaseEntity.F_NickName = OperatorProvider.Provider.GetCurrent().UserName;
            logBaseEntity.F_IPAddress = Net.Ip;
            logBaseEntity.F_IPAddressName = Net.GetLocation(logBaseEntity.F_IPAddress);
            logBaseEntity.F_Result = result;
            logBaseEntity.F_Description = resultLog;
            logBaseEntity.Create();
            service.Insert(logBaseEntity);
        }
        public void WriteDbLog(LogBaseEntity logBaseEntity)
        {
            logBaseEntity.F_Id = Common.GuId();
            logBaseEntity.F_Date = DateTime.Now;
            logBaseEntity.F_IPAddress = "117.81.192.182";
            logBaseEntity.F_IPAddressName = Net.GetLocation(logBaseEntity.F_IPAddress);
            logBaseEntity.Create();
            service.Insert(logBaseEntity);
        }
    }
}
