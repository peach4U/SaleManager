﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager
{
    public class HourUserService : BaseCalculateService
    {
        public override string CalcuteMoney(Employee user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("【计算公式】超出规定时间8小时,每小时按照当前薪资的2倍计算;\r\n");
            sb.Append("公式:  规定工时*每小时金额+(超出时间*(每小时金额*2)) ");
            sb.Append("编号:" + user.Number + "\r\n");
            sb.Append("姓名:" + user.Name + "\r\n");
            sb.Append("类型:" + user.UserType + "\r\n");
            sb.Append("小时:" + user.Hour + "\r\n");
            sb.Append("小时/元:" + user.HourPrice + "\r\n");
            sb.Append("超出:" + user.Overhour + "个小时\r\n");
            if (user.Hour <= 8)
            {
                sb.Append("工资:" + ((user.Hour * user.HourPrice) + "\r\n"));
            }
            else
            {
                sb.Append("工资:" + ((8 * user.HourPrice) + (user.Overhour * (user.HourPrice * 2))) + "\r\n");
            }

            return sb.ToString();
        }
    }
}