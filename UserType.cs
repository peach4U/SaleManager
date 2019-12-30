﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager
{
    public enum UserType
    {
        /// <summary>
        /// 销售员
        /// </summary>
        SaleUser = 1,

        /// <summary>
        /// 月薪员工
        /// </summary>
        MonthUser = 2,

        /// <summary>
        /// 钟点工
        /// </summary>
        HourUser = 3
    }
}