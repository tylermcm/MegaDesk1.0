using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk
{
    public partial class AddQuote : Form
    {

        public AddQuote()
        {
            InitializeComponent();
            materialComboBox.DataSource = Enum.GetValues(typeof(MegaDesk.DesktopMaterials));
            materialComboBox.SelectedIndex = -1;
            rushOrderComboBox.Items.Add("None");
            rushOrderComboBox.Items.Add("3");
            rushOrderComboBox.Items.Add("5");
            rushOrderComboBox.Items.Add("7");
            rushOrderComboBox.SelectedIndex = 0;
        }
        //Remove these events once designer is done
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

        }        
        private void textBox1_Validated(object sender, EventArgs e)
        {

        }
        private void widthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void widthTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!int.TryParse(widthTextBox.Text, out int width) || width < Desk.MINWIDTH || width > Desk.MAXWIDTH)
                {
                    e.Cancel = true;
                    widthTextBox.BackColor = Color.Red;
                    errorProviderApp.SetError(widthTextBox, $"Width must be an integer between {Desk.MINWIDTH} and {Desk.MAXWIDTH}");
                }
                else
                {
                    widthTextBox.BackColor = SystemColors.Window;
                    errorProviderApp.SetError(widthTextBox, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while validating width: {ex.Message}");
            }
        }

        private void depthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        private void depthTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(depthTextBox.Text, out int depth) || depth < Desk.MINWIDTH || depth > Desk.MAXWIDTH)
            {
                e.Cancel = true;
                depthTextBox.BackColor = Color.Red; // Visual clue for the user
                errorProviderApp.SetError(depthTextBox, $"Depth must be an integer between {Desk.MINWIDTH}  and  {Desk.MAXWIDTH}");
            }
            else
            {
                depthTextBox.BackColor = SystemColors.Window;
                errorProviderApp.SetError(depthTextBox, "");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }


        private void DrawersTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void DrawersTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(DrawersTextBox.Text, out int depth) || depth < Desk.MINDRAWER || depth > Desk.MAXDRAWER)
            {
                e.Cancel = true;
                DrawersTextBox.BackColor = Color.Red;
                errorProviderApp.SetError(DrawersTextBox, $"Depth must be an integer between {Desk.MINDRAWER}  and  {Desk.MAXDRAWER}");
            }
            else
            {
                DrawersTextBox.BackColor = SystemColors.Window;
                errorProviderApp.SetError(DrawersTextBox, "");
            }

        }


        private void CloseButton_Click(object sender, EventArgs e)
        {
            MainMenu viewMainMenu = (MainMenu)Tag;
            viewMainMenu.Show();
            Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string customerName = nameTextBox.Text;
            int width = int.Parse(widthTextBox.Text);
            int depth = int.Parse(depthTextBox.Text);
            int numberOfDrawers = int.Parse(DrawersTextBox.Text);
            MegaDesk.DesktopMaterials desktopMaterial = (MegaDesk.DesktopMaterials)materialComboBox.SelectedItem;
            string rushOrder = (string)rushOrderComboBox.SelectedItem;

            Desk desk = new Desk
            {
                Width = width,
                Depth = depth,
                NumberOfDrawers = numberOfDrawers,
                Material = desktopMaterial
            };

            DeskQuote deskQuote = new DeskQuote(customerName, desk, rushOrder, DateTime.Now);


            decimal quoteTotal = deskQuote.CalculateQuoteTotal();




            MainMenu mainMenuForm = (MainMenu)Tag;
            DisplayQuote displayQuoteForm = new DisplayQuote(deskQuote, quoteTotal, mainMenuForm);
            displayQuoteForm.Show();
            this.Hide();
        }
    }
}
