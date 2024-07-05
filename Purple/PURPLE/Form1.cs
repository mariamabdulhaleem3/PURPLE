using com.calitha.goldparser;

namespace sec5
{
    public partial class Form1 : Form
    {
        MyParser p;
        public Form1()
        {
            InitializeComponent();
            p = new MyParser("PURPLE.cgt", listBox1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            p.Parse(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}