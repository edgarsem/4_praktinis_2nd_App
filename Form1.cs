using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_praktinis_2nd_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PubKeyBox.Enabled = false;
            textBox.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void keyBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
           


        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            String data = Server.startServer(PubKeyBox.Text + '|' + textBox.Text + '|' + resultBox.Text);
            if (data == "< DATA_SENT >")
                System.Windows.Forms.MessageBox.Show("Data sent to client successfully!");
            else
            {
                placeData(data);
                System.Windows.Forms.MessageBox.Show("Data received from client successfully!");
            }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void keyWarningLabel_Click(object sender, EventArgs e)
        {

        }

        private void encryptionModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click_3(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void PubKeyGenButton_Click(object sender, EventArgs e)
        {
            
        }

        private void PrivKeyGenButton_Click(object sender, EventArgs e)
        {
            
        }

        private void resultBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            

        }

        private void placeData(String data)
        {
            int split1 = 0, split2 = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '|')
                {
                    PubKeyBox.Text = data.Substring(0, i);
                    split1 = i + 1;
                    break;
                }
            }

            int l = data.Length;
            for (int i = data.Length - 1; i > 0; i--)
            {

                if (data[i] == '|')
                {
                    resultBox.Text = data.Substring(i + 1, data.Length - i - 1);
                    split2 = i - 1;
                    break;
                }
            }
            textBox.Text = data.Substring(split1, split2 - split1 + 1);
        }
    }

}

