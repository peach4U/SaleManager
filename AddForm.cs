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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            numericUpDown1.Visible = false;
            numericUpDown2.Visible = false;
            numericUpDown3.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label9.Visible = false;
            textBox4.Visible = false;
            numericUpDown3.Visible = false;
            dateTimePicker1.Visible = false;
            numericUpDown1.Visible = false;
            numericUpDown2.Visible = false;
            textBox3.Visible = false;

            #region 【元/个】

            label11.Visible = true;
            label11.Location = new Point(68, 182);
            textBox5.Visible = true;
            textBox5.Location = new Point(129, 179);

            #endregion 【元/个】

            #region 【销售数量】

            label10.Visible = true;
            label10.Location = new Point(68, 212);
            numericUpDown3.Visible = true;
            numericUpDown3.Location = new Point(128, 210);

            #endregion 【销售数量】

            #region 【销售时间】

            label6.Visible = true;
            label6.Location = new Point(68, 154);
            dateTimePicker2.Visible = true;
            dateTimePicker2.Location = new Point(131, 150);

            #endregion 【销售时间】

            this.button1.Visible = true;
            this.button1.Location = new Point(135, 257);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = true;
            dateTimePicker1.Visible = true;
            label8.Visible = true;
            textBox3.Visible = true;
            label5.Visible = true;
            numericUpDown2.Visible = true;
            numericUpDown2.Value = 8;
            label7.Visible = true;
            numericUpDown1.Visible = true;
            label7.Location = new Point(73, 240);
            numericUpDown1.Location = new Point(128, 237);
            label6.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            dateTimePicker2.Visible = false;
            numericUpDown3.Visible = false;
            this.button1.Visible = true;
            this.button1.Location = new Point(135, 270);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label9.Visible = true;
            textBox4.Visible = true;
            label9.Location = new Point(68, 154);
            textBox4.Location = new Point(131, 150);
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            textBox5.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            numericUpDown1.Visible = false;
            numericUpDown2.Visible = false;
            numericUpDown3.Visible = false;
            textBox3.Visible = false;
            this.button1.Visible = true;
            this.button1.Location = new Point(135, 185);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserSerivce serivce = new UserSerivce();
            Employee info = new Employee();
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("用户编码不能为空");
                return;
            }
            if (serivce.CheckUserIsExite(textBox2.Text))
            {
                MessageBox.Show("用户编码已存在,请更换");
                return;
            }
            info.Name = textBox1.Text;
            info.Number = textBox2.Text;
            if (radioButton1.Checked)
            {
                info.UserType = radioButton1.Text;
                info.SaleTIme = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                info.SaleCount = Convert.ToInt32(numericUpDown3.Value);
                int count = 0;
                if (!int.TryParse(textBox5.Text, out count))
                {
                    MessageBox.Show("请输入正确的数量");
                    return;
                }
                info.SaleCount = count;
                info.WorkTime = DateTime.Now.ToString("yyyy-MM-dd");
                if (serivce.AddSaleUser(info))
                {
                    MessageBox.Show(info.UserType + "数据添加成功");
                }
                else
                {
                    MessageBox.Show(info.UserType + "数据添加失败");
                }
            }
            else if (radioButton2.Checked)
            {
                info.UserType = radioButton2.Text;
                info.WorkTime = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                info.HourPrice = Convert.ToDecimal(textBox3.Text);
                info.Hour = Convert.ToInt32(numericUpDown2.Value);
                info.Overhour = Convert.ToInt32(numericUpDown1.Value);
                if (serivce.AddHouseUser(info))
                {
                    MessageBox.Show(info.UserType + "数据添加成功");
                }
                else
                {
                    MessageBox.Show(info.UserType + "数据添加失败");
                }
            }
            else
            {
                info.UserType = radioButton3.Text;
                info.MonthPrice = Convert.ToDecimal(textBox4.Text);
                if (serivce.AddMonthUser(info))
                {
                    MessageBox.Show(info.UserType + "数据添加成功");
                }
                else
                {
                    MessageBox.Show(info.UserType + "数据添加失败");
                }
            }
            Clearn();
        }

        private void Clearn()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}