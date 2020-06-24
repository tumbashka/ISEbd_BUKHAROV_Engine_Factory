﻿using EngineFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EngineFactoryClientView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            LoadList();
        }
        private void LoadList()
        {
            try
            {
                dataGridView.DataSource = APIClient.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={Program.Client.Id}");           
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].Visible = false;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[4].HeaderText = "Название двигателя";
                dataGridView.Columns[5].HeaderText = "ФИО исполнителя";
                dataGridView.Columns[6].HeaderText = "Кол-во";
                dataGridView.Columns[7].HeaderText = "Сумма";
                dataGridView.Columns[8].HeaderText = "Статус";
                dataGridView.Columns[9].HeaderText = "Дата создания";
                dataGridView.Columns[10].HeaderText = "Дата выполнения";
                dataGridView.Columns[11].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void UpdateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormUpdateData();
            form.ShowDialog();
        }
        private void CreateOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCreateOrder();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }
        private void RefreshOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadList();
        }
        private void сообщенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormMessage();

            form.ShowDialog();
        }
    }
}
