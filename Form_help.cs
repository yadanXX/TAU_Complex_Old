using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAU_Complex
{
    public partial class Form_help : Form
    {

        
        public Form_help()
        {

            InitializeComponent();
            switch (Data.active_value)
            {
                case 1:
                    pictureBox1.Visible = true;
                    break;
                case 2:
                    pictureBox2.Visible = true;
                    break;
                case 3:
                    pictureBox3.Visible = true;
                    break;
                case 4:
                    pictureBox4.Visible = true;
                    break;
                case 5:
                    pictureBox5.Visible = true;
                    break;
                case 6:
                    pictureBox6.Visible = true;
                    break;
                case 7:
                    pictureBox7.Visible = true;
                    break;
                case 8:
                    pictureBox8.Visible = true;
                    break;
                case 9:
                    pictureBox9.Visible = true;
                    break;
                case 10:
                    pictureBox10.Visible = true;
                    break;
                case 11:
                    pictureBox11.Visible = true;
                    break;
                case 12:
                    pictureBox11.Visible = true;
                    break;
                default:
                    break;
            }
            
        }
    }
}
