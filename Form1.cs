using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FFTA2_Quest_editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        string fpath;
        

        public String[] ReadMethod(UInt32 target, int Amount) {

            using (var stream = new FileStream(fpath, FileMode.Open, FileAccess.ReadWrite))
            {
                string[] readoutput = new string[Amount];
                stream.Position = target;
                for (int i = 0; i < Amount; i++) {
                    int check = stream.ReadByte();

                    //makes sure that int retrieved from readbyte is in hexformat and doesn't skip left 0's
                    readoutput[i] = check.ToString("X").PadLeft(2, '0');
                    stream.Position = target + 0x01;
                }
                return readoutput;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {



            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fpath = openFileDialog1.FileName;
                MessageBox.Show("The file opened succesfully  " + fpath);
                textBox1.Visible = true;
                textBox2.Visible = true;
                button2.Visible = true;
            }
            else { MessageBox.Show("File failed to open"); }



        }

        private void button2_Click(object sender, EventArgs e)
        {
                UInt32 curr = Convert.ToUInt32(textBox1.Text, 16);
                string[] readoutput = ReadMethod(curr, 2);
                textBox2.Text = readoutput[0] + "" + readoutput[1];
                MessageBox.Show("this seems to have worked  " + readoutput[0] + "" + readoutput[1]);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
