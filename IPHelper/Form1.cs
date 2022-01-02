using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPHelper
{
    public partial class Form1 : Form
    {
        public IPAddress ip;
        public int mask;
        public string add,prefix;
        string test;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
            add = textBox3.Text;
           

        }
        
        private void calculate_Click(object sender, EventArgs e)
        {
            try { ip = IPAddress.Parse(add); }


            catch (Exception)
            {
                textBox3.Clear();
                textBox3.Text = "Invalid IP Address";
            }

            try { mask = int.Parse(textBox5.Text); }
            catch (Exception)
            {
                
                textBox5.Clear();
                textBox5.Text = "Invalid Subnet";
            }
            if (mask >= 32 || mask < 8) { textBox5.Clear(); textBox5.Text = "Invalid Subnet"; }
            else if(textBox3.Text!="Invalid IP Address")
            {


                Byte[] bytes = ip.GetAddressBytes();
                test = bytes[0].ToString();


                textBox6.Text = Program.IPs(mask).ToString();
                Byte[] bytessubnet = Program.subnet(mask);
                String subnettext = bytessubnet[0].ToString();

                for (int i = 1; i < bytessubnet.Length; i++)
                {
                    subnettext = subnettext + "." + bytessubnet[i];
                }
                textBox9.Text = subnettext.ToString();
                Byte[] bytes2 = bytes;
                Byte[] bytes3 = bytes;
                Program.BROADCAST(mask, bytes, bytes3);
                string Broadcasttext = bytes3[0].ToString();

                for (int i = 1; i < bytes3.Length; i++)
                {
                    Broadcasttext = Broadcasttext + "." + bytes3[i];
                }
                textBox11.Text = Broadcasttext.ToString();
                if (mask < 31)
                {
                    Byte[] lastbytes = bytes3;
                    lastbytes[3] -= 1;
                    String LastIDtext = lastbytes[0].ToString();

                    for (int i = 1; i < lastbytes.Length; i++)
                    {
                        LastIDtext = LastIDtext + "." + lastbytes[i];
                    }
                    textBox2.Text = LastIDtext.ToString();
                }
                bytes2 = bytes;
                Program.NetID(mask, bytes, bytes2);
                String NetIDtext = bytes2[0].ToString();

                for (int i = 1; i < bytes2.Length; i++)
                {
                    NetIDtext = NetIDtext + "." + bytes2[i];
                }
                textBox10.Text = NetIDtext.ToString();
                if (mask < 31)
                {
                    Byte[] firstbytes = bytes2;
                    firstbytes[3] += 1;
                    String FirstIDtext = firstbytes[0].ToString();

                    for (int i = 1; i < bytes2.Length; i++)
                    {
                        FirstIDtext = FirstIDtext + "." + firstbytes[i];
                    }
                    textBox1.Text = FirstIDtext.ToString();
                }
                
            }
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
            
            prefix = textBox5.Text;
            

            
            
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
