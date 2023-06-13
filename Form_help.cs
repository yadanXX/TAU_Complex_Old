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
                    pictureBox.Image = Properties.Resources.Идеальное_усилительное;
                    break;
                case 2:
                    pictureBox.Image = Properties.Resources.Апериодическое_инерционное;
                    break;
                case 3:
                    pictureBox.Image = Properties.Resources.Апериодическое_второго_порядка;
                    break;
                case 4:
                    pictureBox.Image = Properties.Resources.Колебательное;
                    break;
                case 5:
                    pictureBox.Image = Properties.Resources.Идеальное_интегрирующие;
                    break;
                case 6:
                    pictureBox.Image = Properties.Resources.инерционное_реальное_интегрирующие;
                    break;
                case 7:
                    pictureBox.Image = Properties.Resources.Инерционное_дифферинцирующие;
                    break;
                case 8:
                    pictureBox.Image = Properties.Resources.Михайлов;
                    break;
                case 9:
                    pictureBox.Image = Properties.Resources.найквист;
                    break;
                case 10:
                    pictureBox.Image = Properties.Resources.запаздывание;
                    break;
                case 11:
                    pictureBox.Image = Properties.Resources.точность;
                    break;
                case 12:
                    pictureBox.Image = Properties.Resources.Инвариантность;
                    break;
                case 13:
                    pictureBox.Image = Properties.Resources.Улучшение_САР;
                    break;
                case 14:
                    pictureBox.Image = Properties.Resources.лабораторная_2;
                    break;
                case 15:
                    pictureBox.Image = Properties.Resources.Лабораторная_3;
                    break;
                case 16:
                    pictureBox.Image = Properties.Resources.Лабораторная_4;
                    break;
                case 17:
                    pictureBox.Image = Properties.Resources.Лабораторная_4;//!!!!!!!!
                    break;
                case 18:
                    pictureBox.Image = Properties.Resources.Лабораторная_4;//!!!!!!!!
                    break;
                default:
                    break;
            }
            pictureBox.Height = pictureBox.Image.Height;


        }
    }
}
