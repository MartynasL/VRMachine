﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualRealMachine
{
    public partial class Form1 : Form
    {
        private Machine machine;

        public Form1()
        {
            InitializeComponent();
        }

        private void updateTextBox()
        {
            AText.Text = machine.cpu.A.getValue().ToString();
            BText.Text = machine.cpu.B.getValue().ToString();
            ICText.Text = machine.cpu.IC.getValue().ToString();
            RCText.Text = machine.cpu.RC.getValue().ToString();
            CText.Text = machine.cpu.C.getValue().ToString();
            SPText.Text = machine.cpu.SP.getValue().ToString();
            MText.Text = machine.cpu.M.getValue().ToString();
            PRText.Text = machine.cpu.PR.getValue().ToString();
            PIText.Text = machine.cpu.PI.getValue().ToString();
            SIText.Text = machine.cpu.SI.getValue().ToString();
            IOIText.Text = machine.cpu.IOI.getValue().ToString();
            TIText.Text = machine.cpu.TI.getValue().ToString();
            MODEText.Text = machine.cpu.MODE.getValue().ToString();
            TIMERText.Text = new string(machine.cpu.TIMER.getValue());
            K1Text.Text = machine.cpu.K1.getValue().ToString();
            K2Text.Text = machine.cpu.K2.getValue().ToString();
            K3Text.Text = machine.cpu.K3.getValue().ToString();
        }

        private void initializeListViews()
        {
            listView1.View = View.Details;
            listView2.View = View.Details;

            listView1.Columns.Add("Address");
            listView1.Columns.Add("Value");

            listView2.Columns.Add("Address");
            listView2.Columns.Add("Value");

            updateListViews();
        }

        private void updateListViews()
        {
            listView1.Items.Clear();
            listView2.Items.Clear();

            for (int i = 0; i < machine.supervisorMemory.NUMBER_OF_BLOCKS * 10; i++)
            {
                listView1.Items.Add(new ListViewItem(new string[] {i.ToString(),
                    machine.supervisorMemory.getWordAtAddress(i).ToString() }));
            }

            for (int i = 0; i < machine.memory.NUMBER_OF_BLOCKS * 10; i++)
            {
                listView2.Items.Add(new ListViewItem(new string[] {i.ToString(),
                    machine.memory.getWordAtAddress(i).ToString() }));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            machine = new Machine();

            updateTextBox();
            initializeListViews();
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            machine.cpu.execute(machine.interpretator);

            updateTextBox();
            updateListViews();
        }
    }
}
