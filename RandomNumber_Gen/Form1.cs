using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RandomNumber_Gen
{
    public partial class Form1 : Form
    {
        private RandomNumberGenerator _generator;

        public Form1()
        {
            InitializeComponent();
            _generator = new RandomNumberGenerator();
            txtUrl.Text = Path.Combine(Environment.CurrentDirectory, @"..\..\output\out.txt");
        }

        private bool IsValidPath(string path)
        {
            try
            {
                Path.GetFullPath(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtValue.Text))
                {
                    MessageBox.Show("Please enter a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtValue.Text, out int count) || count <= 0)
                {
                    MessageBox.Show("Please enter a valid positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUrl.Text))
                {
                    MessageBox.Show("Please enter a file path.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidPath(txtUrl.Text))
                {
                    MessageBox.Show("Please enter a valid file path.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string filePath = txtUrl.Text;
                string directoryPath = Path.GetDirectoryName(filePath);
                
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                var numbers = _generator.Generate(count, 1000, 2000);
                File.WriteAllLines(filePath, numbers.Select(n => n.ToString()));

                lblOutput.Text = $"Generated: {string.Join(", ", numbers.Take(10))}{(count > 10 ? "..." : "")}";
                MessageBox.Show($"Successfully generated {count} random numbers to:\n{filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied. Try running as administrator or choose a different location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"I/O error: {ioEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                dialog.DefaultExt = "txt";
                dialog.FileName = "out.txt";
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtUrl.Text = dialog.FileName;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtValue.Clear();
            lblOutput.Text = "Preview: ";
            txtValue.Focus();
        }
    }

    public class RandomNumberGenerator
    {
        private readonly Random _random;

        public RandomNumberGenerator()
        {
            _random = new Random();
        }

        public List<int> Generate(int count, int min, int max)
        {
            var numbers = new List<int>(count);
            for (int i = 0; i < count; i++)
            {
                numbers.Add(_random.Next(min, max + 1));
            }
            return numbers;
        }
    }
}
