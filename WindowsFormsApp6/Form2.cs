using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Form1 form1 = null;

        public Form2(Form1 form1Obj)
        {
            form1 = form1Obj;
            InitializeComponent();

            label2.Text += form1.getMovieName();
            label3.Text += form1.getMovieId();
            label4.Text += form1.getReview();
            label5.Text += form1.getDirector();
            label6.Text += form1.getEmail();
            label7.Text += form1.getProductionCompany();

        }
    }
}
