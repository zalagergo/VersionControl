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
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblLastName.Text = Resource.FullName;
            btnAdd.Text = Resource.Add;
            listUser.DataSource = users;
            listUser.ValueMember = "ID";
            listUser.DisplayMember = "FullName";
            btnWrite.Text = Resource.FileWrite;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtLastName.Text,

            };
            users.Add(u);
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            if (sf.ShowDialog() != DialogResult.OK) return;
            using (StreamWriter sw = new StreamWriter(sf.FileName, false, Encoding.UTF8))
            {
                foreach (var s in users)
                {
                    sw.Write(s.FullName);
                    sw.Write(";");
                    sw.Write(s.ID);
                    sw.Write(";");
                    sw.WriteLine();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string nev = txtLastName.Text;
            var od = from x in users where x.FullName == nev select x;
            users.Remove(od.FirstOrDefault());
        }
    }
}
