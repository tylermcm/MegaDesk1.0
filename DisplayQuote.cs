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
    public partial class DisplayQuote : Form
    {
        private MainMenu _mainMenuForm;
        private DeskQuote deskQuote;
        private decimal quoteTotal;

        internal DisplayQuote( DeskQuote deskQuote, decimal quoteTotal, MainMenu mainMenuForm)
        {
            InitializeComponent();
            _mainMenuForm = mainMenuForm;
            this.deskQuote = deskQuote;
            this.quoteTotal = quoteTotal;

            // Format the quote information as a multiline string
            string quoteInfo = $"Customer Name: {deskQuote.CustomerName}\n" +
                               $"Desk Width: {deskQuote.Desk.Width}\n" +
                               $"Desk Depth: {deskQuote.Desk.Depth}\n" +
                               $"Number of Drawers: {deskQuote.Desk.NumberOfDrawers}\n" +
                               $"Desktop Material: {deskQuote.Desk.Material}\n" +
                               $"Rush Order Option: {deskQuote.RushOrderOption}\n" +
                               $"Quote Date: {deskQuote.QuoteDate.ToShortDateString()}\n" +
                               $"Quote Total: {quoteTotal.ToString("C")}"; 

            outputLabel.Text = quoteInfo;
        }


        private void displayLabel_Resize(object sender, EventArgs e)
        {
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            _mainMenuForm.Show();
            this.Close();
        }
    }
}
