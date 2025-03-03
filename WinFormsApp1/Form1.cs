
using System.IO;
using System.Media;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setLabel();
         
            
            setPath();
        }

        private static Random rand = new Random();

        private static string[] path = Directory.GetFiles(@"C:\Users\maks\source\repos\WinFormsApp1\WinFormsApp1\images");
       private static string[] getPath = checkPath();
        private string text = RandomLabel();
        public PictureBox[] getPic()
        {
            return new PictureBox[] { pictureBox1, pictureBox2, pictureBox3 };
        }
       
        private static string RandomLabel()
        {

            return getPath[rand.Next(0, getPath.Length)];
        }
        private void setLabel()
        {
            string text = this.text;
            string[] pathArr = text.Split('\\');
            string[] fileArr = pathArr.Last().Split('.');
            string fileName = fileArr.GetValue(0).ToString();
            fileName = fileName.Replace("som", " сом");
            label1.Text = "Выберите " + fileName;
        }

        public static string[] checkPath()
        {
            string[] arr = randomPath();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    else
                    {
                        if (arr[i] == arr[j])
                        {
                            arr[i] = path[rand.Next(0, path.Length)];
                        }
                    }
                }
            }
            return arr;

        }

        private static string[] randomPath()
        {
            string[] arr = [path[rand.Next(0, path.Length)], path[rand.Next(0, path.Length)], path[rand.Next(0, path.Length)]];
            return arr;
        }
        private void setPath()
        {
            var pic = getPic();



            var path = getPath;
            for (int i = 0; i < pic.Length; i++)
            {
                pic[i].Image = new Bitmap(path[i]);

            }
        }
        private void checkRaioButtons(int i)
        {
            if (getPath[i] == text)
            {
                SoundPlayer sp = new SoundPlayer(@"C:\Users\maks\source\repos\WinFormsApp1\WinFormsApp1\sound\correct.wav");
                sp.Play();
                MessageBox.Show("Правильно!");
            }
            else
            {
                SoundPlayer sp = new SoundPlayer(@"C:\Users\maks\source\repos\WinFormsApp1\WinFormsApp1\sound\wrong.wav");
                sp.Play();
                MessageBox.Show("Неправильно!");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                checkRaioButtons(0);
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                checkRaioButtons(1);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                checkRaioButtons(2);
            }
        }

     
    }
}
