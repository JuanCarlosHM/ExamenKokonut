using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ExamenKokonut.View
{
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            imgCard.HeightRequest = 200; // set the height of Image to 3:2 Ratio

            //This keeps all margin as same value which given from XAML. Only changes Top Margin as Image height
            grdContentArea.Margin = new Thickness(grdContentArea.Margin.Left, imgCard.Height, grdContentArea.Margin.Right, grdContentArea.Margin.Bottom);

            //Set the content height as scrollable
           grdContentArea.HeightRequest = grdContentArea.Height > this.Height ? grdContentArea.Height : this.Height;

        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            imgCard.TranslateTo(0, -1 * (e.ScrollY / 2), 2);
            if (e.ScrollY < imgCard.Height)
            {
                imgFloatButton.TranslateTo(0, e.ScrollY / 5, 200);
            }
            else
            {
                imgFloatButton.TranslateTo(0, (this.Height / 1.5) - imgFloatButton.Height, 200);
            }

        }

        private void Fab_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
                btn.BackgroundColor = btn.BackgroundColor.Equals(Color.FromHex("#f7a902"))
                ? Color.FromHex("f7028d")
                : Color.FromHex("#f7a902");
        }



    } // end Class 
}
