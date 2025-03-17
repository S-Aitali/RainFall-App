using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectSA
{
    /* Sara Ait Ali 
     * Develop a windows desktop application that is capable of reading a text file, processing the rows according
     * to my business rules, and writing a new file containing only the processed rows.
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double[] values;
        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            txtInputFile.BackColor = Color.White;
            

            int rowCount = 0;
            int goodRowCount = 0;
            double sum = 0;
            double min = double.MaxValue;
            double max = double.MinValue;

            List<double> tempValues = new List<double>();

            string inputFilePath = txtInputFile.Text;
            if (txtInputFile.Text == "")
            {
                MessageBox.Show("Please Enter a Filename!", "Empty");
                txtInputFile.BackColor = Color.IndianRed;
                txtInputFile.Focus();

            }
            else if (!File.Exists(inputFilePath))
            {
                MessageBox.Show("The input file does not exist.", "Error");
            }
            else
            {

                try
                {

                    using (StreamReader reader = new StreamReader(inputFilePath))
                    {

                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            int sentinelValue = 99999;
                            double value;

                            if (double.TryParse(line, out value))
                            {
                                if (value == sentinelValue)
                                {
                                    break;
                                }

                                rowCount++;

                                if (value >= 0)
                                {
                                    goodRowCount++;
                                    sum += value;
                                    min = Math.Min(min, value);
                                    max = Math.Max(max, value);

                                    tempValues.Add(value);

                                }
                            }
                        }
                    }

                    values = tempValues.ToArray();

                    double average = goodRowCount > 0 ? sum / goodRowCount : 0;

                    txtRowsAffected.Text = rowCount.ToString();
                    txtRowsProcessed.Text = goodRowCount.ToString();
                    txtMinRainfall.Text = min.ToString();
                    txtMaxRainfall.Text = max.ToString();
                    txtAvgRainfall.Text = average.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while reading the file: {ex.Message}", "Error");
                }
            }
        }


        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileChooser = new OpenFileDialog();

            fileChooser.Filter = "Text Files (*.txt)|*.txt";
            fileChooser.Title = "Select an input file";

            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                
                txtInputFile.Text = fileChooser.FileName;
            }
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = "Text Files (*.txt)|*.txt";
            saveFile.Title = "Select an output file";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                
                string outputFilePath = saveFile.FileName;

                try
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        foreach (double value in values)
                        {
                            writer.WriteLine(value);
                        }
                    }

                    txtOutputFile.Text = outputFilePath;
                    MessageBox.Show("Your File was successfully created and saved.", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while writing to the file: {ex.Message}", "Error");
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInputFile.Text = "";
            txtRowsAffected.Text = "";
            txtRowsProcessed.Text = "";
            txtMinRainfall.Text = "";
            txtMaxRainfall.Text = "";
            txtAvgRainfall.Text = "";
            txtOutputFile.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

        }

      
  
