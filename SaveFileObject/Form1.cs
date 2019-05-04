using SaveFileObject.objs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SaveFileObject
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            
            MyRow row = new MyRow(textBox1.Text, textBox2.Text);
            //row.id = textBox1.Text;
            //row.name = textBox2.Text;
            RowsInfo.Instance().add(row);
            RowsInfo.Instance().save();
            reloadListView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reloadListView();
        }

        private void reloadListView()
        {
            lsvData.Items.Clear();
            foreach (MyRow row in RowsInfo.Instance().rows)
            {
                ListViewItem item = new ListViewItem(row.id);
                item.SubItems.Add(row.name);
                lsvData.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var baseAddress = "http://dummy.restapiexample.com/api/v1/create";
            using (var client = new WebClient())
            {
                var dataString = "{\"name\":\"testxx11\",\"salary\":\"123\",\"age\":\"23\"}";
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                string content = client.UploadString(new Uri(baseAddress), "POST", dataString);

                MessageBox.Show(content);
            }

            //Set up a request object
            
            
        }
    }
}
