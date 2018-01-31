/**
 * Project 1
 * 
 * Program asks creates a cellular automata heat map 
 * of cells. User can click on various cells to change them 
 * to red or white. They can also press the Start button to
 * begin calculating new generations of cells. The Stop button 
 * pauses this calculation, and the Reset button sets all
 * of the cells back to white, and the user can add completely
 * new heat sources.
 *
 * @author Samantha Montgomery
 * @version 1
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Project1
{
    public partial class uxForm1 : Form
    {
        Label[,] _arr;
        Label[,] _newgenarr;
        bool[,] _heatsources;
        bool startButtonPressed = false; //bool flag to keep track if the start button has been pressed at least once (true), 
        System.Timers.Timer t = new System.Timers.Timer(300); //timer to update every 300 ms
        const int Row = 20; //number of rows
        const int Col = 65; //number of columns

        //The constructor, which sets up the array of labels and places them on the GUI
        public uxForm1()
        {
            _arr = new Label[20, 65]; //array of labels that holds the current RGB values before CellUpdate() is called
            _newgenarr = new Label[20, 65]; //array that stores the RGB values of the next generation
            _heatsources = new bool[20, 65]; //bool array to keep track of which cells are heat sources0.
            InitializeComponent();
            
            BackColor = Color.Gray;

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    //formatting how the labels look on the GUI
                    _arr[i, j] = new Label();
                    _newgenarr[i, j] = new Label();
                    this.SuspendLayout();
                    _arr[i, j].AutoSize = false;
                    _arr[i, j].BackColor = Color.White;
                    _arr[i, j].Location = new Point(20 + (j * 13), 40 + (i * 13));
                    _arr[i, j].Name = "label1";
                    _arr[i, j].Size = new Size(10, 10);
                    _arr[i, j].TabIndex = 0;
                    _arr[i, j].Text = "";

                    this.Controls.Add(_arr[i, j]);
                    if (i < 1 || j < 1 || i > 19 || j > 64)
                    {
                        _arr[i, j].Visible = false;
                    }
                    else
                    {
                        _arr[i, j].Click += new EventHandler(LabelClick); //adding click event for each label
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

        /* LabelClick()
         * This method changes the colors of the labels if they are clicked.
         * It also updates the heatsource array to include any red labels.
		 *  
		 *  @param object sender: the label that was clicked
		 *  @param EventArgs e: the click event
		 *  
		 *  @return void
		*/
        public void LabelClick(object sender, EventArgs e)
        {
            Label labelle = (Label)sender;
            
            if (labelle.BackColor == Color.Red)
            {
                labelle.BackColor = Color.White;
            }
            else
            {
                labelle.BackColor = Color.Red;
            }

            //updating the heatsources array to include the new clicked label
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (_arr[i, j] == labelle)
                    {
                        _heatsources[i, j] = !_heatsources[i,j];
                    }
                }
            }
        }

        /* CellUpdate()
         * This method is called every 300ms by the timer object, and it is used 
         * to find the new colors of the next generation of cells.
		 *  
		 *  @param object obj: the timer that sent this
		 *  @param EventArgs e: 300ms have passed, so there is an event
		 *  
		 *  @return void
		*/
        public void CellUpdate(object obj, EventArgs e)
        {
       
            int redpart; //the R color aspect
            int greenpart; //the G color aspect
            int bluepart; //the B color aspect of the next color

            for (int i = 1; i < Row-1; i++)
            {
                for (int j = 1; j < Col-1; j++)
                {
                    if (_heatsources[i, j]) //if the cell is a heat source, keep it red
                    {
                        _newgenarr[i, j].BackColor = Color.Red;
                    }
                    else
                    {
                        redpart = 0;
                        greenpart = 0;
                        bluepart = 0;

                        //accessing the R, G, and B components for each of the eight cells around it
                        redpart += _arr[i - 1, j + 1].BackColor.R;
                        greenpart += _arr[i - 1, j + 1].BackColor.G;
                        bluepart += _arr[i - 1, j + 1].BackColor.B;

                        redpart += _arr[i - 1, j].BackColor.R;
                        greenpart += _arr[i - 1, j].BackColor.G;
                        bluepart += _arr[i - 1, j].BackColor.B;

                        redpart += _arr[i - 1, j - 1].BackColor.R;
                        greenpart += _arr[i - 1, j - 1].BackColor.G;
                        bluepart += _arr[i - 1, j - 1].BackColor.B;

                        redpart += _arr[i, j + 1].BackColor.R;
                        greenpart += _arr[i, j + 1].BackColor.G;
                        bluepart += _arr[i, j + 1].BackColor.B;

                        redpart += _arr[i, j - 1].BackColor.R;
                        greenpart += _arr[i, j - 1].BackColor.G;
                        bluepart += _arr[i, j - 1].BackColor.B;

                        redpart += _arr[i + 1, j + 1].BackColor.R;
                        greenpart += _arr[i + 1, j + 1].BackColor.G;
                        bluepart += _arr[i + 1, j + 1].BackColor.B;

                        redpart += _arr[i + 1, j].BackColor.R;
                        greenpart += _arr[i + 1, j].BackColor.G;
                        bluepart += _arr[i + 1, j].BackColor.B;

                        redpart += _arr[i + 1, j - 1].BackColor.R;
                        greenpart += _arr[i + 1, j - 1].BackColor.G;
                        bluepart += _arr[i + 1, j - 1].BackColor.B;

                        //adding all of the components and then dividing by 8 to get the average color
                        _newgenarr[i, j].BackColor = Color.FromArgb(redpart / 8, greenpart / 8, bluepart / 8);
                    }

                   
                }
            }


            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    _arr[i, j].BackColor = _newgenarr[i, j].BackColor;
                }
            }
        }

        /* uxStartButton_Click()
         * This method is called when the start button is clicked. 
         * If it is the first time the start button has been pressed, it 
         * creates a new timer t. Otherwise it resumes the current timer.
		 *  
		 *  @param object sender: the start button
		 *  @param EventArgs e: it was clicked
		 *  
		 *  @return void
		*/
        private void uxStartButton_Click(object sender, EventArgs e)
        {
            if (!startButtonPressed)
            {
                t.Elapsed += new ElapsedEventHandler(CellUpdate);
                t.Enabled = true;
                t.SynchronizingObject = this;
                startButtonPressed = true;
            }
            else
            {
                t.Start();
            }
        }

        /* uxStopButton_Click()
         * This method is called when the stop button is clicked. 
         * This pauses the current timer.
		 *  
		 *  @param object sender: the stop button
		 *  @param EventArgs e: it was clicked
		 *  
		 *  @return void
		*/
        private void uxStopButton_Click(object sender, EventArgs e)
        {
            t.Stop();
        }

        /* uxResetButton_Click()
         * This method is called when the reset button is clicked. 
         * It stops the current timer, sets the startButtonPressed bool flag to false,
         * and sets _heatsources to a fresh new bool array that is all false, obviously.
         * Finally, it clears all of the current label's BackColors to white.
		 *  
		 *  @param object sender: the reset button
		 *  @param EventArgs e: it was clicked
		 *  
		 *  @return void
		*/
        private void uxResetButton_Click(object sender, EventArgs e)
        {
            if (t != null)
            {
                t.Stop();
                startButtonPressed = false;
                _heatsources = new bool[20, 65];
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        _arr[i, j].BackColor = Color.White;
                    }
                }
            }
        }
    }
}
