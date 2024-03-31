namespace Lab16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int degree1 = int.Parse(textBox1.Text);
            string[] coefficientsString1 = textBox2.Text.Split(' ');

            double[] coefficients = new double[coefficientsString1.Length];
            for (int i = 0; i < coefficientsString1.Length; i++)
            {
                coefficients[i] = double.Parse(coefficientsString1[i]);
            }


            int degree2 = int.Parse(textBox3.Text);
            string[] coefficientsString2 = textBox4.Text.Split(' ');

            double[] coefficients1 = new double[coefficientsString2.Length];
            for (int i = 0; i < coefficientsString2.Length; i++)
            {
                coefficients1[i] = double.Parse(coefficientsString2[i]);
            }

            Polynomial polynomial1 = new Polynomial(degree1, coefficients);
            Polynomial polynomial2 = new Polynomial(degree2, coefficients1);

            double x = double.Parse(textBox8.Text);

            double result1 = polynomial1.Evaluate(x);
            double result2 = polynomial2.Evaluate(x);

            textBox5.Text = result1.ToString();
            textBox6.Text = result2.ToString();

            Polynomial sum = polynomial1 + polynomial2;
            Polynomial difference = polynomial1 - polynomial2;
            Polynomial product = polynomial1 * polynomial2;

            textBox7.Text = sum.ToString();
            textBox9.Text = difference.ToString();
            textBox10.Text = product.ToString();
        }

       
    }



}
