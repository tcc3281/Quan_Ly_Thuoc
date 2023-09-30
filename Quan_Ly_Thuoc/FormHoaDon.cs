﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Thuoc
{
    public partial class FormHoaDon : Form
    {
        private List<string> lChucNangThuoc = new List<string>();
        private List<string> lThuoc = new List<string>();
        public FormHoaDon()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        //search chức năng thuốc
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var newList = new List<string>(lChucNangThuoc.Cast<string>());
            var itemsToRemove = new List<string>();
            string searchText = txtSearchChucNang.Text;

            foreach (string s in newList)
            {
                if (!s.Contains(searchText))
                {
                    itemsToRemove.Add(s);
                }
            }

            foreach (string item in itemsToRemove)
            {
                newList.Remove(item);
            }

            listChucNang.Items.Clear();
            listChucNang.Items.AddRange(newList.ToArray());
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            lChucNangThuoc.Add("aaaaaaaaaaa");
            lChucNangThuoc.Add("abbbbbbbbbb");
            lChucNangThuoc.Add("abccccccccc");
            lChucNangThuoc.Add("acccccccccc");
            lChucNangThuoc.Add("bcccdcccccc");

            foreach (string s in lChucNangThuoc)
            {
                listChucNang.Items.Add(s);
            }

            txtSearchChucNang.TextChanged += textBox1_TextChanged;


            lThuoc.Add("aaaaaaaaaaa");
            lThuoc.Add("abbbbbbbbbb");
            lThuoc.Add("abccccccccc");
            lThuoc.Add("acccccccccc");
            lThuoc.Add("bcccdcccccc");

            foreach (string s in lThuoc)
            {
                listThuoc.Items.Add(s);
            }

            txtSearchThuoc.TextChanged += txtSreachThuoc_TextChanged;
        }

        private void txtSreachThuoc_TextChanged(object sender, EventArgs e)
        {
            var newList = new List<string>(lThuoc.Cast<string>());
            var itemsToRemove = new List<string>();
            string searchText = txtSearchThuoc.Text;

            foreach (string s in newList)
            {
                if (!s.Contains(searchText))
                {
                    itemsToRemove.Add(s);
                }
            }

            foreach (string item in itemsToRemove)
            {
                newList.Remove(item);
            }

            listThuoc.Items.Clear();
            listThuoc.Items.AddRange(newList.ToArray());
        }
    }
}
