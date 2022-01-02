using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPHelper
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static int IPs(int mask)
        {
            return (int)(Math.Pow(2, 32 - mask) - 2);
        }

        public static byte[] subnet(int mask)
        {

            Byte[] bytes2 = new Byte[] { 0, 0, 0, 0 };
            int x = mask / 8;
            for (int i = 0; i < x; i++)
            {
                bytes2[i] = 255;
            }
            int mod = mask % 8;
            int bit = 0;
            for (int i = 1; i <= mod; i++)
            {
                bytes2[x] = (byte)(bytes2[x] + Math.Pow(2, (8 - i)));
            }
            return bytes2;
        }

        public static void BROADCAST(int mask, byte[] IP ,byte[] bytes3)
        {
            
            
            int[] tab2 = new int[8];
            for(int i=0; i<8; i++)
            {
               
                tab2[i] = 0;
            }
           
            int x = (mask / 8);
            for(int i=3; i>x; i--)
            {
               
                bytes3[i] = 255;
            }
            int mod = (mask % 8);
            for(int i=0;IP[x]>0; i++)
            {
                tab2[i] = (int) IP[x] % 2;
                
                
                IP[x] = (byte)(IP[x] / 2);
            }


            for(int j=0; j<8-mod; j++)
            {
                
                   
                    tab2[j] = 1;
                
            }
           
            bytes3[x] = 0;
            for (int i=0; i<8; i++)
            {
                if (tab2[i] == 1) { bytes3[x] = (byte)(bytes3[x] + Math.Pow(2, i)); }
                
                
                
            }

            
        }

        public static void NetID(int mask, byte[] IP, byte[] bytes2)
        {

            int[] tab1 = new int[8];
            
            for (int i = 0; i < 8; i++)
            {
                tab1[i] = 0;
                
            }

            int x = (mask / 8);
            int mod = (mask % 8);
            if (mod == 0)
            {
                for (int i = 3; i > x-1; i--)
                {
                    bytes2[i] = 0;

                }
            }
            else
            {
                for (int i = 3; i > x; i--)
                {
                    bytes2[i] = 0;

                }

                for (int i = 0; IP[x] > 0; i++)
                {
                    tab1[i] = (int)IP[x] % 2;


                    IP[x] = (byte)(IP[x] / 2);
                }


                for (int j = 0; j < 8 - mod; j++)
                {

                    tab1[j] = 0;


                }
                bytes2[x] = 0;

                for (int i = 0; i < 8; i++)
                {

                    if (tab1[i] == 1) { bytes2[x] = (byte)(bytes2[x] + Math.Pow(2, i)); }


                }
            }
            
            


        }

    }
}
