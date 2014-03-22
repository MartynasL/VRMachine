using System;
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
        private CPU cpu;
        private Memory supervisorMemory;
        private InputDevice inputDevice;
        private OutputDevice outputDevice;
        private Interpretator interpretator;
        private HDDManager hddManager;

        public Form1()
        {
            InitializeComponent();
        }

        private void updateTextBox()
        {
            AText.Text = cpu.A.getValue().ToString();
            BText.Text = cpu.B.getValue().ToString();
            ICText.Text = cpu.IC.getValue().ToString();
            RCText.Text = cpu.RC.getValue().ToString();
            CText.Text = cpu.C.getValue().ToString();
            SPText.Text = cpu.SP.getValue().ToString();
            MText.Text = cpu.M.getValue().ToString();
            PRText.Text = cpu.PR.getValue().ToString();
            PIText.Text = cpu.PI.getValue().ToString();
            SIText.Text = cpu.SI.getValue().ToString();
            IOIText.Text = cpu.IOI.getValue().ToString();
            TIText.Text = cpu.TI.getValue().ToString();
            MODEText.Text = cpu.MODE.getValue().ToString();
            TIMERText.Text = new string(cpu.TIMER.getValue());
            K1Text.Text = cpu.K1.getValue().ToString();
            K2Text.Text = cpu.K2.getValue().ToString();
            K3Text.Text = cpu.K3.getValue().ToString();
        }

        private void initializeListBox()
        {
            listView1.View = View.Details;

            listView1.Columns.Add("Address");
            listView1.Columns.Add("Value");

            updateListBox();
        }

        private void updateListBox()
        {
            listView1.Items.Clear();

            for (int i = 0; i < supervisorMemory.NUMBER_OF_BLOCKS * 10; i++)
            {
                listView1.Items.Add(new ListViewItem(new string[] {i.ToString(),
                    supervisorMemory.getWordAtAddress(i).ToString() }));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cpu = new CPU();
            supervisorMemory = new Memory(40);
            inputDevice = new InputDevice();
            outputDevice = new OutputDevice();
            hddManager = new HDDManager("hdd.txt", 100, 10);
            interpretator = new Interpretator(ref cpu, ref supervisorMemory, ref inputDevice,
                ref outputDevice, ref hddManager);

            cpu.MODE.setValue('S');
            cpu.PR.setValue(new Word("0010"));
            supervisorMemory.setWordAtAddress(0, new Word("MO99"));
            supervisorMemory.setWordAtAddress(1, new Word("/A02"));
            supervisorMemory.setWordAtAddress(2, new Word("0003"));
            supervisorMemory.setWordAtAddress(3, new Word("0010"));
            supervisorMemory.setWordAtAddress(100, new Word("0022"));
            supervisorMemory.setWordAtAddress(223, new Word("AAAA"));

            updateTextBox();
            initializeListBox();
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            cpu.execute(interpretator);
            updateTextBox();
            updateListBox();
        }
    }
}
