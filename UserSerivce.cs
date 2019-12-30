﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager
{
    public class UserSerivce
    {
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserTable()
        {
            var sql = "select * from Employee";
            return SqlHelper.GetDataTable(sql, CommandType.Text);
        }

        public bool CheckUserIsExite(string number)
        {
            var sql = "  SELECT * FROM Employee WHERE Number=@Number";
            SqlParameter ps = new SqlParameter("@Number", number);
            return SqlHelper.GetDataTable(sql, CommandType.Text, ps).Rows.Count > 0;
        }

        /// <summary>
        /// 销售员
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool AddSaleUser(Employee info)
        {
            string sql = "INSERT INTO Employee(Name,Number,SaleTIme,UserType,SaleCount,SalePrice)VALUES(@Name,@Number,@SaleTIme,@UserType,@SaleCount,@SalePrice)";
            SqlParameter[] ps = new SqlParameter[] {
             new SqlParameter("@Name",info.Name),
             new SqlParameter("@Number",info.Number),
             new SqlParameter("@SaleTIme",info.SaleTIme),
             new SqlParameter("@UserType",info.UserType),
             new SqlParameter("@SaleCount",info.SaleCount),
             new SqlParameter("@SalePrice",info.SalePrice)
        };

            return SqlHelper.ExecNonQuery(sql, CommandType.Text, ps) > 0;
        }

        /// <summary>
        /// 钟点工
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool AddHouseUser(Employee info)
        {
            string sql = "INSERT INTO Employee(Hour,Name,Number,Overhour,UserType,HourPrice,WorkTime)VALUES(@Hour,@Name,@Number,@Overhour,@UserType,@HourPrice,@WorkTime)";
            SqlParameter[] ps = new SqlParameter[] {
             new SqlParameter("@Hour",info.Hour),
             new SqlParameter("@Name",info.Name),
             new SqlParameter("@Number",info.Number),
             new SqlParameter("@Overhour",info.Overhour),
             new SqlParameter("@UserType",info.UserType),
             new SqlParameter("@HourPrice",info.HourPrice),
             new SqlParameter("@WorkTime",info.WorkTime)
        };
            return SqlHelper.ExecNonQuery(sql, CommandType.Text, ps) > 0;
        }

        /// <summary>
        /// 固定工资
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool AddMonthUser(Employee info)
        {
            string sql = "INSERT INTO Employee(Name,Number,UserType,MonthPrice)VALUES(@Name,@Number,@UserType,@MonthPrice)";
            SqlParameter[] ps = new SqlParameter[] {
             new SqlParameter("@Name",info.Name),
             new SqlParameter("@Number",info.Number),
             new SqlParameter("@MonthPrice",info.MonthPrice),
             new SqlParameter("@UserType",info.UserType),
        };
            return SqlHelper.ExecNonQuery(sql, CommandType.Text, ps) > 0;
        }

        public Employee GetInfoById(string Id)
        {
            var sql = "SELECT * FROM Employee WHERE Id=@Id";
            SqlParameter ps = new SqlParameter("@Id", Id);
            DataTable dt = SqlHelper.GetDataTable(sql, CommandType.Text, ps);
            if (dt != null && dt.Rows.Count > 0)
            {
                return GetModel(dt.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Update(Employee info)
        {
            string sql = "UPDATE Employee SET  @Hour=@Hour, @Name=@Name, @Number=@Number, @Overhour=@Overhour, @SaleTIme=@SaleTIme, @UserType=@UserType, @WorkTime=@WorkTime WHERE @Id=@Id";
            SqlParameter[] ps = new SqlParameter[]
            {
             new SqlParameter("@Hour",info.Hour),
             new SqlParameter("@Id",info.Id),
             new SqlParameter("@Name",info.Name),
             new SqlParameter("@Number",info.Number),
             new SqlParameter("@Overhour",info.Overhour),
             new SqlParameter("@SaleTIme",info.SaleTIme),
             new SqlParameter("@UserType",info.UserType),
             new SqlParameter("@WorkTime",info.WorkTime),
            };
            return SqlHelper.ExecNonQuery(sql, CommandType.Text, ps) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            string sql = "DELETE Employee WHERE Id=@Id";
            SqlParameter ps = new SqlParameter("@Id", Id);
            return SqlHelper.ExecNonQuery(sql, CommandType.Text, ps) > 0;
        }

        public Employee GetModel(DataRow row)
        {
            Employee info = new Employee();
            if (row["Hour"] != DBNull.Value)
                info.Hour = Convert.ToInt32(row["Hour"]);
            if (row["HourPrice"] != DBNull.Value)
                info.HourPrice = Convert.ToDecimal(row["HourPrice"]);
            if (row["Id"] != DBNull.Value)
                info.Id = Convert.ToInt32(row["Id"]);
            if (row["MonthPrice"] != DBNull.Value)
                info.MonthPrice = Convert.ToDecimal(row["MonthPrice"]);
            if (row["Name"] != DBNull.Value)
                info.Name = row["Name"].ToString();
            if (row["Number"] != DBNull.Value)
                info.Number = row["Number"].ToString();
            if (row["Overhour"] != DBNull.Value)
                info.Overhour = Convert.ToInt32(row["Overhour"]);
            if (row["SaleCount"] != DBNull.Value)
                info.SaleCount = Convert.ToInt32(row["SaleCount"]);
            if (row["SalePrice"] != DBNull.Value)
                info.SalePrice = Convert.ToDecimal(row["SalePrice"]);
            if (row["SaleTIme"] != DBNull.Value)
                info.SaleTIme = row["SaleTIme"].ToString();
            if (row["UserType"] != DBNull.Value)
                info.UserType = row["UserType"].ToString();
            if (row["WorkTime"] != DBNull.Value)
                info.WorkTime = row["WorkTime"].ToString();
            return info;
        }

        /// <summary>
        /// 月薪人员信息修改
        /// </summary>
        /// <param name="MonthPrice"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateMonth(decimal MonthPrice, string id, string Name, string Number)
        {
            var sql = "UPDATE Employee SET MonthPrice=@MonthPrice,Name=@Name,Number=@Number where Id=@Id";
            SqlParameter[] ps =
            {
                new SqlParameter("@MonthPrice",MonthPrice),
                new SqlParameter("@Id",id),
                new SqlParameter("@Name",Name),
                new SqlParameter("@Number",Number)
            };
            return SqlHelper.ExecNonQuery(sql, CommandType.Text, ps) > 0;
        }

        public bool UpdateHour(string Name, string Number, DateTime workeTime, string hour, string overhour, decimal hourprice, string id)
        {
            var sql = "UPDATE Employee SET Name=@Name,Number=@Number,WorkTime=@WorkTime,Hour=@Hour,Overhour=@Overhour,HourPrice=@HourPrice where Id=@Id";
            SqlParameter[] ps =
            {
                 new SqlParameter("@Id",id),
                new SqlParameter("@Name",Name),
                new SqlParameter("@Number",Number),
                new SqlParameter("@WorkTime",workeTime),
                new SqlParameter("@Hour",hour),
                new SqlParameter("@Overhour",overhour),
                  new SqlParameter("@HourPrice",hourprice)
            };
            return SqlHelper.ExecNonQuery(sql, CommandType.Text, ps) > 0;
        }

        public bool UpdateSale(string Name, string Number, string id, DateTime SaleTIme, string SaleCount, string SalePrice)
        {
            var sql = "UPDATE Employee SET Name=@Name,Number=@Number,SaleTIme=@SaleTIme,SaleCount=@SaleCount,SalePrice=@SalePrice where Id=@Id";

            SqlParameter[] ps =
          {
                 new SqlParameter("@Id",id),
                new SqlParameter("@Name",Name),
                new SqlParameter("@Number",Number),
                new SqlParameter("@SaleTIme",SaleTIme),
                new SqlParameter("@SaleCount",SaleCount),
                new SqlParameter("@SalePrice",SalePrice)
            };
            return SqlHelper.ExecNonQuery(sql, CommandType.Text, ps) > 0;
        }
    }
}