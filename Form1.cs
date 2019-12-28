﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManager
{
    public partial class Form1 : Form
    {
        private UserSerivce service = new UserSerivce();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm add = new AddForm();
            add.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loads();
        }

        private void loads()
        {
            this.dataGridView1.DataSource = service.GetUserTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var data = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (DialogResult.Yes == MessageBox.Show("您确定删除选中记录?", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (service.Delete(data))
                {
                    MessageBox.Show("删除成功");
                    loads();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loads();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var data = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            UpdateForm up = new UpdateForm(data);
            up.Show();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            BusinessHelper.InitData();
            var data = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            var user = service.GetInfoById(data);
            if (user != null)
            {
                BaseCalculateService baseservice = null;
                if (user.UserType == "月薪人员")
                {
                    var month = DateTime.Now.Month;
                    var day = DateTime.Now.Day;
                    if (!BusinessHelper.IsEndDay(day, month))
                    {
                        baseservice = new MonthService();
                        var result = baseservice.CalcuteMoney(user);
                        CalcultarForm c = new CalcultarForm(result);
                        c.Show();
                    }
                    else
                    {
                        MessageBox.Show("不是最后一天,无法计算");
                    }
                }
                else if (user.UserType == "小时工")
                {
                    if (!BusinessHelper.IsFiveDay())
                    {
                        baseservice = new HourUserService();
                        var result = baseservice.CalcuteMoney(user);
                        CalcultarForm c = new CalcultarForm(result);
                        c.Show();
                    }
                    else
                    {
                        MessageBox.Show("不是周五,无法计算");
                    }
                }
                else
                {
                    baseservice = new SaleService();
                    var result = baseservice.CalcuteMoney(user);
                    CalcultarForm c = new CalcultarForm(result);
                    c.Show();
                }
            }
        }
    }
}