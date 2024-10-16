﻿using GI_Inc.DAL;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace GI_Inc.Forms.ApptReports
{
    public partial class AppointmentsByWeek : Form
    {
        MySqlConnection conn = new MySqlConnection("server = wgudb.ucertify.com; user id = U06P8D; persistsecurityinfo = True; password =53688828432; database = U06P8D");

        public static int index = 0;

        public AppointmentsByWeek()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today.AddDays(7);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var query = "SELECT appointmentId, type, start, end FROM `appointment` WHERE `start` BETWEEN @start and @end";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@start", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@end", dateTimePicker2.Value);
            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvAppts.DataSource = dt;

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
            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }

        private void btnBackToApptRep_Click(object sender, EventArgs e)
        {
            ApptReportDashboard appts = new ApptReportDashboard();
            appts.Show();
            Hide();
        }
    }
}
