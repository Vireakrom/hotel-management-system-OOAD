using HotelManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var db = DatabaseManager.Instance;
            if (db.TestConnection())
            {
                MessageBox.Show("Database connected successfully!");
            }
            else
            {
                MessageBox.Show("Database connection failed!");
            }
        }
    }
}
