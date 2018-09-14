
// gittest2: MainPage.xaml.cs
// This file the main xaml page from the functional calculator
// This is not in the included Source, due to various git-related issues
// Sorry for any inconveniences.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gittest2
{
    public partial class MainPage : ContentPage
    {
        int savedValue = 0;
        char previousOperator = '+';

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_7_Clicked(object sender, EventArgs e)
        {
            //Button_7.BackgroundColor = Color.Red;
            String currentDisplay = Display.Text;
            if (currentDisplay == "[Output]" || currentDisplay == "0")
                Display.Text = "7";
            else
                Display.Text = currentDisplay + "7";
            //Button_7.BackgroundColor = Color.Blue;
        }

        private void Button_Clear_Clicked(object sender, EventArgs e)
        {
            //Display.TextColor = Color.Black;
            Display.Text = "0";
            savedValue = 0;
            //Display.TextColor = Color.White;
        }

            /* Known bugs:
             * - Adding after a clear will automatically set the display value to zero.
             *     (Unintended interaction)
             */
            private void Button_Add_Clicked(object sender, EventArgs e)
            {
                int currentDisplay = Int32.Parse(Display.Text);
                if (savedValue == 0) // If nothing is saved in savedValue, copy currentDisplay
                    savedValue = currentDisplay;
                else // Otherwise, add savedValue and currentDisplay together
                    savedValue = savedValue + currentDisplay;
                Display.Text = "0";
            }

            private void Button_Equals_Clicked(object sender, EventArgs e)
            {
                int currentDisplay = Int32.Parse(Display.Text);
                string newDisplay;

                if (previousOperator == '+') {
                    currentDisplay = savedValue + currentDisplay;
                }

                newDisplay = currentDisplay.ToString();
                Display.Text = newDisplay;
                savedValue = 0;
            }
        }
}
