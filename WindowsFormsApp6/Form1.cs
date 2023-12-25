using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2 viewForm = null;
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (ValidateMovieDetails())
            {
                MessageBox.Show("Successfully added!");
                /*
                 * ClearTextboxes();
                 */
            }
        }
        private bool ValidateMovieDetails()
        {
            Regex alphabetsOnly = new Regex("^[a-zA-Z ]+$");
            Regex movieIdFormat = new Regex(@"^\d{4}/[a-zA-Z]{4}-\d{1,3}$");
            Regex singleDigit = new Regex(@"^\d$");
            bool isView = true;

            errorProvider.Clear();

            if (!alphabetsOnly.IsMatch(movieName.Text) || string.IsNullOrEmpty(movieName.Text))
            {
                errorProvider.SetError(movieName, "Invalid movie name");
                isView = false;
                return false;
            }

            if (!movieIdFormat.IsMatch(movieId.Text) || string.IsNullOrEmpty(movieId.Text))
            {
                errorProvider.SetError(movieId, "Invalid movie ID format");
                isView = false;
                return false;
            }

            if (!singleDigit.IsMatch(review.Text) || string.IsNullOrEmpty(review.Text))
            {
                errorProvider.SetError(review, "Review must have 1 digit");
                isView = false;
                return false;
            }

            if (!alphabetsOnly.IsMatch(director.Text) || string.IsNullOrEmpty(director.Text))
            {
                errorProvider.SetError(director, "Invalid director name");
                isView = false;
                return false;
            }

            if (!email.Text.Contains("@") || !email.Text.Contains(".") || string.IsNullOrEmpty(email.Text))
            {
                errorProvider.SetError(email, "Invalid email address");
                isView = false;
                return false;
            }

            if (!alphabetsOnly.IsMatch(productionCompany.Text) || string.IsNullOrEmpty(productionCompany.Text))
            {
                errorProvider.SetError(productionCompany, "Invalid production company name");
                isView = false;
                return false;
            }

            ClearErrorMessages();
            if (isView == true)
            {
                viewBtn.Enabled = true;
            }
            return true;
        }
        private void ClearErrorMessages()
        {
            errorProvider.SetError(movieName, "");
            errorProvider.SetError(movieId, "");
            errorProvider.SetError(review, "");
            errorProvider.SetError(director, "");
            errorProvider.SetError(email, "");
            errorProvider.SetError(productionCompany, "");
        }

        private void ClearTextboxes()
        {
            movieName.Text = "";
            movieId.Text = "";
            review.Text = "";
            director.Text = "";
            email.Text = "";
            productionCompany.Text = "";
        }

        public string getMovieName()
        {
            return movieName.Text;
        }

        public string getMovieId()
        {
            return movieId.Text;
        }

        public string getReview()
        {
            return review.Text;
        }

        public string getEmail()
        {
            return email.Text;
        }

        public string getDirector()
        {
            return director.Text;
        }

        public string getProductionCompany()
        {
            return productionCompany.Text;
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            if ((viewForm == null) || (viewForm.IsDisposed)){
                viewForm = new Form2(this);
            }
            viewForm.ShowDialog();
        }
    }
}
