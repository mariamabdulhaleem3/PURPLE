using com.calitha.goldparser;

namespace PURple
{
    public partial class Form1 : Form
    {
        MyParser P;
        public Form1()
        {
            InitializeComponent();
            P = new MyParser ("D:\\source\\repos\\PURple\\PURple\\bin\\Debug\\net6.0-windows", listBox1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            P.Parse(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}