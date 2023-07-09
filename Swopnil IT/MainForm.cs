using System;
using System.Drawing;
using System.Windows.Forms;

namespace Swopnil_IT
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MprintDocument1.Print();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NewCustomerBtn_Click(object sender, EventArgs e)
        {
            ClearBtn();

        }

        private void ClearBtn()
        {
            CustomerNameTxt.Clear();
            PhoneTxt.Clear();
            ProductComb1.SelectedIndex = -1;
            QuantityComb1.SelectedIndex = -1;
            PriceTxt.Clear();
            
            PayablePrice.Text = "00";
            DispMess.Text = "All Data Reset";
            TotalDueTxt.Clear();    
            DiscountTxt.Clear();
            TotalPrice.Text = "00";
        }

        private void CancleBtn_Click(object sender, EventArgs e)
        {
            ClearBtn();
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This software is developed by Aminul islam Niloy");
        }

        private void DuePriceTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void PriceTxt_TextChanged(object sender, EventArgs e)
        {
            PriceCount();

        }

        private void PriceCount()
        {
            try
            {
               
                

                if (PriceTxt.Text != "" && QuantityComb1.SelectedIndex != -1 )
                {
                   decimal totalPrice = Convert.ToInt64(PriceTxt.Text) * Convert.ToInt64(QuantityComb1.Text);

                    if (DiscountTxt.Text != "" )
                    {
                        decimal SoPrice = totalPrice;
                        decimal AfterTotal = (Convert.ToInt64(DiscountTxt.Text) * SoPrice) / 100;
                        decimal nowTotal = totalPrice - AfterTotal;


                        TotalPrice.Text = nowTotal.ToString();

                        if (TotalDueTxt.Text == "")
                        {
                            PayablePrice.Text = nowTotal.ToString();


                        }

                         else
                        {

                            decimal TotalDue = Convert.ToInt64(TotalDueTxt.Text);

                            decimal FinalPayable = (nowTotal - TotalDue);
                            PayablePrice.Text = FinalPayable.ToString();
                        }


                    }
                    else if(TotalDueTxt.Text != "" && DiscountTxt.Text != "")
                    {
                        decimal SoPrice = totalPrice;
                        decimal AfterTotal = (Convert.ToInt64(DiscountTxt.Text) * SoPrice) / 100;
                        decimal nowTotal = totalPrice - AfterTotal;

                        TotalPrice.Text = nowTotal.ToString();

                        decimal TotalDue = Convert.ToInt64(TotalDueTxt.Text);

                        decimal FinalPayable = (nowTotal - TotalDue);
                        PayablePrice.Text = FinalPayable.ToString();
                        

                    }


                    else
                    {
                        if( TotalDueTxt.Text != "")
                        {

                            decimal TotalDue = Convert.ToInt64(TotalDueTxt.Text);

                            decimal FinalPayable = (totalPrice - TotalDue);
                            PayablePrice.Text = FinalPayable.ToString();
                            TotalPrice.Text = totalPrice.ToString();
                        }
                        else
                        {
                            PayablePrice.Text = totalPrice.ToString();

                            TotalPrice.Text = totalPrice.ToString();

                        }

                    }

                }

            } catch(Exception ex)
            {
                DispMess.Text= ex.Message;
            }
        }

        private void IfDuePresent(decimal totalPrice)
        {
        }

        private void DueCount(decimal totalPrice)
        {
            if (TotalDueTxt.Text != "")
            {

                decimal TotalDue = Convert.ToInt64(TotalDueTxt.Text);
                decimal FinalPayable = (totalPrice - TotalDue);
                PayablePrice.Text = FinalPayable.ToString();
            }
            else
            {
                PayablePrice.Text = totalPrice.ToString();
            }
        }

        private void DiscountTxt_TextChanged(object sender, EventArgs e)
        {
            PriceCount();
        }

        private void QuantityComb1_TextChanged(object sender, EventArgs e)
        {
            PriceCount();
        }

        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            MprintPreviewDialog1.Document = MprintDocument1;
            MprintPreviewDialog1.ShowDialog();
        }

        private void TotalDueTxt_TextChanged(object sender, EventArgs e)
        {
            PriceCount();
        }

        private void MprintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bitmap = Properties.Resources.swopnil;
            Image image = bitmap;

            string Deshline = "___________________________________________________________________";
            e.Graphics.DrawImage(image, 250, 30,400,140);

            e.Graphics.DrawString("Customer Name   :  " + CustomerNameTxt.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(40, 240));
            e.Graphics.DrawString("Date: " + DateTime.Now, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(550, 280));
            e.Graphics.DrawString("Mobile   Number :  " + PhoneTxt.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(40, 280));
           
            e.Graphics.DrawString(Deshline, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(40, 320));

            
            e.Graphics.DrawString("Name of Product   ", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(40, 345));
            e.Graphics.DrawString("Quantity" , new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(340, 345));
            e.Graphics.DrawString("Price", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(700, 345));
            e.Graphics.DrawString("Discount % " , new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(480, 345));
            
            e.Graphics.DrawString(Deshline, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(40, 360));


            e.Graphics.DrawString( ProductComb1.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(60, 400));
            e.Graphics.DrawString( QuantityComb1.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(368, 400));
            e.Graphics.DrawString("TK", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(650, 400));
            e.Graphics.DrawString( PriceTxt.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(700, 400));
            e.Graphics.DrawString(DiscountTxt.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(510, 400));


            e.Graphics.DrawString(Deshline, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(40, 650));

            e.Graphics.DrawString("Total Price of products  " , new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(40, 680));
            e.Graphics.DrawString("TK", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(650, 680));
            e.Graphics.DrawString(TotalPrice.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(700, 680));

            e.Graphics.DrawString("Total Due is " , new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(40, 720));
            e.Graphics.DrawString("TK", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(650, 720));
            e.Graphics.DrawString(TotalDueTxt.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(700, 720));
            e.Graphics.DrawString(Deshline, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(40, 740));


            e.Graphics.DrawString("Total Payable Price is ", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(40, 780));
            e.Graphics.DrawString("TK", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(650, 780));
            e.Graphics.DrawString( PayablePrice.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(700, 780));
            e.Graphics.DrawString(Deshline, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(40, 790));
           
            
            string des = "All Types of electronics products are avalable hare.  Phone: 015876543.";
            e.Graphics.DrawString(des, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(110, 1050));
           
            string CustomerSig = "Customer Signature with date....";
            e.Graphics.DrawString(CustomerSig, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(90, 970));

            string ManagerSig = "Manager Signature with date....";
            e.Graphics.DrawString(ManagerSig, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(480, 970));


        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            MprintDocument1.Print();
        }

        private void SaveAsPdf_Click(object sender, EventArgs e)
        {
            MprintDocument1.Print();
        }
    }
}
