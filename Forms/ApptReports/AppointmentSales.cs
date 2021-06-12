﻿using GI_Inc.DAL;
using GI_Inc.DataSources;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GI_Inc.Forms.ApptReports
{
    public partial class AppointmentSales : Form
    {
        agent currentUser;
        string startWeek;
        string endWeek;
        public static int index = 0;
        DataTable dt = new DataTable();
        public AppointmentSales()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today.AddDays(7);
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server = wgudb.ucertify.com; user id = U06P8D; persistsecurityinfo = True; password =53688828432; database = U06P8D");

            var query = "SELECT type, salesAmount, start, end FROM `appointment` WHERE (`start` BETWEEN @start and @end AND salesAmount IS NOT NULL)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@start", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@end", dateTimePicker2.Value);
            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvSales.DataSource = dt;

            if (dateTimePicker2.Value >= dateTimePicker1.Value)
            {
                return;
            }
            else
            {
                MessageBox.Show("End date cannot be equal to or before start date, please select again!");
            }
            conn.Close();
        }

        private void btnBackToDash_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }
    }
}
