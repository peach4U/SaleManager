﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager
{
    public class Employee
    {
        /// <summary>
        ///小时
        /// </summary>
        public int Hour { get; set; }

        /// <summary>
        ///主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 超时
        /// </summary>
        public int Overhour { get; set; }

        /// <summary>
        /// 销售时间
        /// </summary>
        public string SaleTIme { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserType { get; set; }

        /// <summary>
        /// 工作时间
        /// </summary>
        public string WorkTime { get; set; }

        /// <summary>
        /// 小时/元
        /// </summary>
        public decimal HourPrice { get; set; }

        /// <summary>
        /// 月薪
        /// </summary>
        public decimal MonthPrice { get; set; }

        /// <summary>
        /// 销售数量
        /// </summary>
        public int SaleCount { get; set; }

        /// <summary>
        /// 元/个
        /// </summary>
        public decimal SalePrice { get; set; }
    }
}