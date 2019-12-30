﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager
{
    public class SaleService : BaseCalculateService
    {
        public override string CalcuteMoney(Employee user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("【计算公式】销售数量*每个商品提成+打底工资;\r\n");
            sb.Append("编号:" + user.Number + "\r\n");
            sb.Append("姓名:" + user.Name + "\r\n");
            sb.Append("类型:" + user.UserType + "\r\n");
            sb.Append("销售数量:" + user.SaleCount + "\r\n");
            sb.Append("个/元:" + user.SalePrice + "\r\n");
            sb.Append("工资:" + (user.SaleCount * user.SalePrice) +"\r\n");
            return sb.ToString();
        }
    }
}