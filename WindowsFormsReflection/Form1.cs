using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsReflection
{
    public partial class Form1 : Form
    {
        Assembly assembly = null;
        Type[] type = null;
        public Form1()
        {
            type = GetTypes();
            InitializeComponent();
        }

        private Type[] GetTypes()
        {
            assembly = Assembly.Load("TemperatureLibrary");
            var type = assembly.GetTypes();
            return type;
        }
        DataTable table = new DataTable();
        private void AddColumns()
        {
            table.Columns.Add("Assambly");
            table.Columns.Add("Properties");
            table.Columns.Add("Methods");

            dataGridView1.DataSource = table;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AddColumns();
            foreach (var item in type)
            {

                MethodInfo[] methods = item.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
                if (methods != null)
                {
                    foreach (MethodInfo method in methods)
                    {
                        table.Rows.Add(assembly.GetName(), method.Name);
                        var prop = item.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
                        foreach (var pr in prop)
                        {

                            if (prop != null)
                            {
                                table.Rows.Add(assembly.FullName, method.Name, pr.Name);
                            }
                        }

                    }
                }

                dataGridView1.DataSource = table;
            }
        }    

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text += "Assambly - " + assembly.FullName + Environment.NewLine + Environment.NewLine;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            foreach (var item in type)
            {
                        var prop = item.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
                        foreach (var pr in prop)
                        {
                           string property = "Properties: " + pr.Name + "\n";
                            if (prop != null)
                            {
                             
                              textBox1.Text += property;
                            }
                        }

                    }
                }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            foreach (var item in type)
            {
                var methods = item.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
                foreach (var method in methods)
                {
                    string meth = "Methods: " + method.Name + "\n";
                    if (method != null)
                    {

                        textBox1.Text += meth;
                    }
                }

            }
        }

    }
}
        
    


