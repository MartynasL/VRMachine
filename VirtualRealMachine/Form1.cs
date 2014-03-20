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

        private void Form1_Load(object sender, EventArgs e)
        {
            cpu = new CPU();
            supervisorMemory = new Memory(40);
            inputDevice = new InputDevice();
            outputDevice = new OutputDevice();
            hddManager = new HDDManager("C:\\Users\\Martynas\\Desktop\\hdd.txt", 100, 10);
            interpretator = new Interpretator(ref cpu, ref supervisorMemory, ref inputDevice,
                ref outputDevice, ref hddManager);
            updateTextBox();
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            cpu.A.setValue(new Word("00AA"));
            updateTextBox();
        }
    }
}
