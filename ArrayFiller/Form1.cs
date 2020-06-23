using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArrayFiller
{
    public partial class Form1 : Form
    {
        static Random random = new Random();
        public int range;
        public int min;
        public int max;
        public int totalIterations = 0;
        public int totalCount = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Main();
        }

        //Returns a random number between the min and max
        private int GetRandomNumber()
        {
            try
            {
                return random.Next(min, max);
            }
            catch
            {
                throw;
            }
        }

        private void Main()
        {
            try
            {
                //=======Set initial values from Textboxes  ============
                int iterations = Convert.ToInt32(txtIterations.Text);
                min = Convert.ToInt32(txtMin.Text);
                max = Convert.ToInt32(txtMax.Text) + 1;

                //===The Range is how many numbers it will have to "fill"  =========
                range = max - min;

                //------ for/next loop that will fill the array as many times as iterations 
                for (int x = 0; x < iterations; x++)
                {
                    //Keeps track of total iterations. Reset only on Reset button click
                    totalIterations++;

                    //Create a new list to contain the numbers
                    List<int> myList = new List<int>();

                    //Start the counter at 1 at each "GO!" button press
                    int counter = 1;

                    //Do Loop will continue until the List<int> is filled
                    do
                    {
                        //Get random number
                        int valueToAdd = GetRandomNumber();

                        //if the List doesn't contain the number...
                        if (!myList.Contains(valueToAdd))
                        {
                            //add the number to the list, increase the counter and total count
                            myList.Add(valueToAdd);
                            counter++;
                            totalCount++;
                        }
                        else
                        {
                            //Do not add, but increase both counters
                            counter++;
                            totalCount++;
                        }
                    } while (myList.Count < this.range);

                    //create the string to display in the ListBox for each Iteration
                    string lines = String.Format("{0} attempts to get {1} unique numbers", counter - 1, myList.Count);

                    //Add the summary string to the listbox
                    listBox1.Items.Add(lines);

                    //Display the running average
                    lblAverage.Text = (totalCount / totalIterations).ToString();
                }
            }
            catch
            {
                //Just a generic error handler that catches any errors
                string error = "You did something wrong";
                listBox1.Items.Add(error);
            }
        }

        //=======Clear Button==================================
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            lblAverage.Text = "0";
            totalIterations = 0;
            totalCount = 0;
        }
    }
}
