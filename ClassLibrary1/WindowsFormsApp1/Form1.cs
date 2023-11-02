using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        IntArray array1, array2;
        public Form1()
        {
            InitializeComponent();
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                button1.Enabled = false;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton3.Checked)            
                numericUpDown1.Enabled = false;            
            else 
                numericUpDown1.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            IntArray array = new IntArray(new int[0]);
            int length = ((int)numericUpDown1.Value);            
            if (radioButton5.Checked)           
                array = new IntArray(random, length);           
            else if (radioButton4.Checked)
            {
                int min = int.Parse(textBox1.Text);
                int max = int.Parse(textBox2.Text);
                array = new IntArray(random, min, max, length);
            }
            else if (radioButton3.Checked)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        array = new IntArray(new FileInfo(openFileDialog.FileName));
                    }
                    catch
                    {
                        MessageBox.Show("Поврежденный файл.");
                        return;
                    }
                }
            }
            else return;
            if (radioButton1.Checked)
            {
                array1 = new IntArray(array);
                array1.FillInTable(dataGridView1);
                button10.Enabled = true;
                button2.Enabled = true; 
                button3.Enabled = true;              
                textBox3.Enabled = true;
            }
            else
            {
                array2 = new IntArray(array);
                array2.FillInTable(dataGridView2);
                button11.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                textBox4.Enabled = true;
            }
            if(array1 != null && array2 != null)
            {
                button12.Enabled = true;
                button13.Enabled = true;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') 
                return;
            else if (e.KeyChar == '-' && ((TextBox)sender).Text.Length == 0) 
                return;
            else if (e.KeyChar == (char)Keys.Back)  
                return;
            else
                e.KeyChar = '\0';
        }
        private void button2_Click(object sender, EventArgs e)
        {
            array1++;
            array1.FillInTable(dataGridView1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            array1--;
            array1.FillInTable(dataGridView1);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            array1 += int.Parse(textBox3.Text);
            array1.FillInTable(dataGridView1);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text.Length != 0)
            {
                button4.Enabled = true;
                button5.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
                button5.Enabled = false;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            array1 -= int.Parse(textBox3.Text);
            array1.FillInTable(dataGridView1);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            array2++;
            array2.FillInTable(dataGridView2);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            array2--;
            array2.FillInTable(dataGridView2);
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length != 0)
            {
                button6.Enabled = true;
                button7.Enabled = true;
            }
            else
            {
                button6.Enabled = false;
                button7.Enabled = false;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            array2 += int.Parse(textBox4.Text);
            array2.FillInTable(dataGridView2);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            array2 -= int.Parse(textBox4.Text);
            array2.FillInTable(dataGridView2);
        }
        private void button13_Click(object sender, EventArgs e)
        {
            IntArray result = array1 + array2;
            result.FillInTable(dataGridView3);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            IntArray result = array1 - array2;
            result.FillInTable(dataGridView3);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            IntArray result = new IntArray(array1.FindIndexesNearAvg().ToArray());
            result.FillInTable(dataGridView3);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            IntArray result = new IntArray(array2.FindIndexesNearAvg().ToArray());
            result.FillInTable(dataGridView3);
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "-")
                ((TextBox)sender).Text = "0";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0)
                    button1.Enabled = true;
                else
                    button1.Enabled = false;
            }              
        }
    }
}
