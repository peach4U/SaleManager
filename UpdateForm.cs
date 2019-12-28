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
    public partial class UpdateForm : Form
    {
        private string _id;

        public UpdateForm(string id)
        {
            _id = id;
            InitializeComponent();
        }

        private UserSerivce service = new UserSerivce();

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = 10000M;
            numericUpDown2.Maximum = 10000M;
            numericUpDown3.Maximum = 10000M;
            label12.Visible = false;
            label12.Text = _id;
            var user = service.GetInfoById(_id);
            if (user != null)
            {
                switch (user.UserType)
                {
                    case "销售":
                        label4.Visible = false;
                        label8.Visible = false;
                        label5.Visible = false;
                        label9.Visible = false;
                        textBox4.Visible = false;
                        numericUpDown2.Visible = false;
                        textBox3.Visible = false;
                        dateTimePicker1.Visible = false;
                        label7.Visible = false;
                        numericUpDown1.Visible = false;
                        label10.Visible = true;
                        label10.Location = new Point(68, 212);
                        numericUpDown3.Visible = true;
                        numericUpDown3.Location = new Point(128, 210);
                        label6.Visible = true;
                        label6.Location = new Point(68, 154);
                        dateTimePicker2.Visible = true;
                        dateTimePicker2.Location = new Point(131, 150);
                        label11.Visible = true;
                        label11.Location = new Point(68, 182);
                        textBox5.Visible = true;
                        textBox5.Location = new Point(129, 179);
                        this.button1.Visible = true;
                        this.button1.Location = new Point(135, 257);
                        textBox1.Text = user.Name;
                        textBox2.Text = user.Number;
                        radioButton1.Checked = true;
                        dateTimePicker2.Value = Convert.ToDateTime(user.SaleTIme);
                        numericUpDown3.Value = Convert.ToDecimal(user.SaleCount);
                        textBox5.Text = user.SalePrice.ToString();
                        radioButton3.Enabled = false;
                        radioButton2.Enabled = false;
                        break;

                    case "小时工":
                        label9.Visible = false;
                        textBox4.Visible = false;
                        label6.Visible = false;
                        dateTimePicker2.Visible = false;
                        label10.Visible = false;
                        numericUpDown3.Visible = false;
                        label11.Visible = false;
                        textBox5.Visible = false;
                        label7.Visible = true;
                        label7.Location = new Point(70, 230);
                        numericUpDown1.Location = new Point(130, 230);
                        radioButton1.Enabled = false;
                        radioButton3.Enabled = false;
                        textBox1.Text = user.Name;
                        textBox2.Text = user.Number;
                        radioButton2.Checked = true;
                        dateTimePicker1.Value = Convert.ToDateTime(user.WorkTime);
                        textBox3.Text = user.HourPrice.ToString();
                        numericUpDown2.Value = Convert.ToDecimal(user.Hour);
                        numericUpDown1.Value = Convert.ToDecimal(user.Overhour);
                        button1.Location = new Point(143, 260);
                        break;

                    case "月薪人员":
                        label9.Visible = true;
                        textBox4.Visible = true;
                        label6.Visible = false;
                        dateTimePicker2.Visible = false;
                        label10.Visible = false;
                        numericUpDown3.Visible = false;
                        label11.Visible = false;
                        textBox5.Visible = false;
                        label7.Visible = false;
                        label5.Visible = false;
                        label8.Visible = false;
                        label4.Visible = false;
                        label7.Location = new Point(70, 230);
                        numericUpDown1.Location = new Point(130, 230);
                        radioButton1.Enabled = false;
                        radioButton2.Enabled = false;
                        textBox1.Text = user.Name;
                        textBox2.Text = user.Number;
                        radioButton3.Checked = true;
                        dateTimePicker1.Visible = false;
                        textBox3.Visible = false;
                        numericUpDown2.Visible = false;
                        numericUpDown1.Visible = false;
                        label9.Location = new Point(92, 140);
                        textBox4.Location = new Point(135, 140);
                        button1.Location = new Point(143, 180);
                        textBox4.Text = user.MonthPrice.ToString();
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                //销售
                if (service.UpdateSale(textBox1.Text, textBox2.Text, label12.Text, dateTimePicker2.Value, numericUpDown3.Value.ToString(), textBox5.Text))
                {
                    MessageBox.Show("销售员信息修改成功");
                }
                else
                {
                    MessageBox.Show("销售员信息修改失败");
                }
            }
            else if (radioButton2.Checked)
            {
                //钟点工
                if (service.UpdateHour(textBox1.Text, textBox2.Text, dateTimePicker1.Value, numericUpDown2.Value.ToString(), numericUpDown1.Value.ToString(), ToDecial(textBox3.Text), label12.Text))
                {
                    MessageBox.Show("钟点工信息修改成功");
                }
                else
                {
                    MessageBox.Show("钟点工信息修改失败");
                }
            }
            else
            {
                //月薪
                if (service.UpdateMonth(ToDecial(textBox4.Text), label12.Text, textBox1.Text, textBox2.Text))
                {
                    MessageBox.Show("月薪人员信息修改成功");
                }
                else
                {
                    MessageBox.Show("月薪人员信息修改失败");
                }
            }
        }

        private decimal ToDecial(string data)
        {
            return Convert.ToDecimal(data);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}