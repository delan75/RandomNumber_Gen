using System;
using System.IO;
using System.Windows.Forms;

namespace RandomNumber_Gen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtValue.Text == null || txtValue.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a number");
                    return;
                }

                if (txtUrl.Text == "")
                {
                    MessageBox.Show("Please enter a URL");
                    return;
                }

                int n = int.Parse(txtValue.Text);

                // Get the current directory where the app is running from (bin/Debug)
                string currentDirectory = Environment.CurrentDirectory;

                // Combine with the relative path to get the correct file path
                string filePath = Path.Combine(currentDirectory, @"..\output\out.txt");

                // Check if the directory exists
                string directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    // If directory doesn't exist, create it
                    Directory.CreateDirectory(directoryPath);
                }

                Random random = new Random();

                // Open the file for writing (it will create the file if it doesn't exist)
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    for (int i = 0; i < n; i++)
                    {
                        int randomNumber = random.Next(1000, 2001);
                        writer.WriteLine(randomNumber);
                    }
                }

                // Notify the user
                MessageBox.Show($"Successfully generated {n} random numbers to the file: {filePath}");

            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access to the specified file path is denied. Try running the app as an administrator.");
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"I/O error occurred: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }

    }
}
