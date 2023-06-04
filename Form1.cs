using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        List<string> list = new List<string>();
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            bs.DataSource = list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void button14_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            listBox1.BeginUpdate();

            string[] strings = richTextBox1.Text.Split(new char[] { '\n', '\t',' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string s in strings)
            {
                string str = s.Trim();

                if (str == String.Empty) continue;
                if (radioButton1.Checked) listBox1.Items.Add(str);
                if (radioButton2.Checked)
                {
                    if (Regex.IsMatch(str, @"\d"))
                    {
                        listBox1.Items.Add(str);
                    }
                }
                if (radioButton3.Checked)
                {
                    if (Regex.IsMatch(str, @"\w+@\w+\.\w+"))
                    {
                        listBox1.Items.Add(str);
                    }
                }
                listBox1.EndUpdate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();//exit
        }

        private void button1_Click(object sender, EventArgs e)//сброс
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            richTextBox1.Clear();
            textBox1.Clear();
        }

        private void сохраниьCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(sfd.FileName);
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    writer.WriteLine((string)listBox1.Items[i]);
                }
                writer.Close();
            }
            sfd.Dispose();
        }

        private void открытьCntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(ofd.FileName, Encoding.Default);
                richTextBox1.Text = reader.ReadToEnd();
                reader.Close();
            }
            ofd.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();

            string Find = textBox1.Text;

            if (checkBox1.Checked)
            {
                foreach (string String in listBox1.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }

            if (checkBox2.Checked)
            {
                foreach (string String in listBox2.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();

            AddRec.Owner = this;
            AddRec.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i)) listBox1.Items.RemoveAt(i);
            }
            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
            {
                if (listBox2.GetSelected(i)) listBox2.Items.RemoveAt(i);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox2.BeginUpdate();
            
            foreach (object Item in listBox1.SelectedItems)
            {
                listBox2.Items.Add(Item);
            }

            listBox2.EndUpdate();
        }
        private void button3_Click(object sender, EventArgs e)
        {

            string selectedSortType = comboBox1.SelectedItem.ToString();
            List<string> items = new List<string>();

            foreach (var item in listBox1.Items)
            { items.Add(item.ToString()); }

            switch (selectedSortType)
            {
                case "Алфавит (по возрастанию)": items.Sort(); break;
                case "Алфавиту (по убыванию)": items.Sort(); items.Reverse(); break;
                case "Длине слов (по возрастанию)": items.Sort((x, y) => x.Length.CompareTo(y.Length)); break;
                case "Длине слов (по убыванию)": items.Sort((x, y) => y.Length.CompareTo(x.Length)); break;
            }
            listBox1.Items.Clear();

            foreach (var item in items)
            { listBox1.Items.Add(item); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string selectedSortType = comboBox2.SelectedItem.ToString();
            List<string> items = new List<string>();

            foreach (var item in listBox2.Items)
            { items.Add(item.ToString()); }

            switch (selectedSortType)
            {
                case "Алфавит (по возрастанию)": items.Sort(); break;
                case "Алфавиту (по убыванию)": items.Sort(); items.Reverse(); break;
                case "Длине слов (по возрастанию)": items.Sort((x, y) => x.Length.CompareTo(y.Length)); break;
                case "Длине слов (по убыванию)": items.Sort((x, y) => y.Length.CompareTo(x.Length)); break;
            }
            listBox2.Items.Clear();

            foreach (var item in items)
            { listBox2.Items.Add(item); }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.BeginUpdate();

            foreach (object Item in listBox2.SelectedItems)
            {
                listBox1.Items.Add(Item);
            }

            listBox1.EndUpdate();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox2.BeginUpdate();

            foreach (object Item in listBox1.Items)
            {
                listBox2.Items.Add(Item);
            }

            listBox2.EndUpdate();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.BeginUpdate();

            foreach (object Item in listBox2.Items)
            {
                listBox1.Items.Add(Item);
            }

            listBox1.EndUpdate();
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
