using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace TextTyper
{
    public class Program : Form
    {
        private TextBox inputBox;
        private Button typeButton;
        private Button loadFileButton;

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Program());
        }

        public Program()
        {
            // Criar os componentes da interface
            inputBox = new TextBox() { Multiline = true, Width = 400, Height = 200 };
            typeButton = new Button() { Text = "Digitar Texto", Top = 210, Width = 200 };
            loadFileButton = new Button() { Text = "Carregar de Arquivo", Top = 210, Left = 210, Width = 200 };

            typeButton.Click += TypeButton_Click;
            loadFileButton.Click += LoadFileButton_Click;

            Controls.Add(inputBox);
            Controls.Add(typeButton);
            Controls.Add(loadFileButton);

            Text = "Simulador de Digitação";
            Width = 450;
            Height = 300;
        }

        private void TypeButton_Click(object sender, EventArgs e)
        {
            string textToType = inputBox.Text;
            SimulateTyping(textToType);
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivo de texto (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileText = File.ReadAllText(filePath);
                inputBox.Text = fileText;
            }
        }

        private void SimulateTyping(string text)
        {
            foreach (char c in text)
            {
                SendKeys.SendWait(c.ToString());
                Thread.Sleep(50); // Controla a velocidade da "digitação"
            }
        }
    }
}
