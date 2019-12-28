﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager
{
    public class MonthService : BaseCalculateService
    {
        public override string CalcuteMoney(Employee user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("【计算公式】就是每个月的固定薪资;\r\n");
            sb.Append("编号:" + user.Number + "\r\n");
            sb.Append("姓名:" + user.Name + "\r\n");
            sb.Append("类型:" + user.UserType + "\r\n");
            sb.Append("工资:" + user.MonthPrice.ToString() + "\r\n");
            return sb.ToString();
        }
    }
}