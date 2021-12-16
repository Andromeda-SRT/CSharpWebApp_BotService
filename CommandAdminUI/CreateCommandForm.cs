using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CommandAdminUI.CreateCommand
{
    public partial class CreateCommandForm : Form
    {
        public CreateCommandForm()
        {
            InitializeComponent();
        }

        //Ссылка по которой идёт приём запросов для сущности commands
        //private string apiCommandUrl = "https://localhost:5001/api/commands";


        private void btn_create_Click(object sender, EventArgs e)
        {
            if (returnChoisedSourseString() == "Source not found")
                MessageBox.Show("PLS Choise the source", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                sendPostJsonQueryAsync();

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //event CheckedChanged() для rb В GroupBox: ConfigurationCommand
        private void configRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            clearTextBoxes();

            RadioButton radioButton = sender as RadioButton;

            if (radioButton_echo.Checked)
            {
                radioButton_word.Checked = true;
                groupBox_trigger.Enabled = false;
                richTextBox_bodyScript.Enabled = false;
                groupBox_name.Text = "Trigger msg";
                richTextBox_bodyScript.Enabled = false;
                richTextBox_answer.Enabled = true;
                btn_openFile.Enabled = false;
            }
            else if (radioButton_script.Checked)
            {
                if (groupBox_trigger.Enabled == false) groupBox_trigger.Enabled = true;
                if (radioButton_word.Checked == true) radioButton_word.Checked = false; radioButton_word.Enabled = false;
                richTextBox_bodyScript.Enabled = true;
                groupBox_name.Text = "Trigger script";
                richTextBox_bodyScript.Enabled = true;
                richTextBox_answer.Enabled = false;
                btn_openFile.Enabled = true;
            }


        }

        private void clearTextBoxes()
        {
            textBox_name.Text = "";
            richTextBox_answer.Text = "";
            richTextBox_bodyScript.Text = "";
        }

        private async Task sendPostJsonQueryAsync()
        {
            //Берём единственный активный radioButton из GroupBox_trigger
            RadioButton thisRadioButtonInTriggerGroupChecked = groupBox_trigger.Controls.OfType<RadioButton>().Single(rb => rb.Checked);


            //Собирем объект (сущность) который собираемя отправить
            var makeCommand = new CommandEntity()
            {
                //CommandId = 0,
                CommandTrigger = (radioButton_script.Checked) ? thisRadioButtonInTriggerGroupChecked.Text : textBox_name.Text, 
                SourceNames = returnChoisedSourseString(),
                CommandAnswer = (richTextBox_answer.Text == String.Empty)?"-": richTextBox_answer.Text,
                IsScript = radioButton_script.Checked,
                ScriptName = (textBox_name.Text == String.Empty)?"-": textBox_name.Text,
                Author = $"{System.Environment.UserName}",
                Description = (richTextBox_bodyScript.Text == String.Empty)?"-": richTextBox_bodyScript.Text
            };

            //Отправляем данные пост запросом
            HttpResponseMessage response = await SubmitCommandToAPIAsync(makeCommand);
            //SubmitCommandToAPIAsync(commandEntity1).Wait();

            //Проверка ответа сервера 
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Command dont save \n" +
                    $"Code: {response.StatusCode} = {response.Content.ReadAsStreamAsync()}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Done! {response.Content.ReadAsStringAsync()}", $"{response.StatusCode}",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }


        public static Task<HttpResponseMessage> SubmitCommandToAPIAsync(CommandEntity command)
        {
            //Сериализуем класс в JSON String
            string commandJson = JsonConvert.SerializeObject(command);

            //Переносим наш JSON внутрь StringContent чтобы мы могли использовать HttpClient class
            HttpContent stringContent = new StringContent(commandJson, Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            //Херачим наши данные по пост запросу
            return httpClient.PostAsync("https://localhost:5001/api/commands", stringContent);
        }



        //Функция возвращающая строку с выбранными Ресурсами (от куда могут поступать запросы)
        private string returnChoisedSourseString()
        {
            string result = "";
            if (checkBox_telegram.Checked || checkBox_vk.Checked)
            {
                if (checkBox_telegram.Checked)
                    result += "Telegram;";
                if (checkBox_vk.Checked)
                    result += "VK;";
            }
            else
            {
                result = "Source not found";
            }

            return result;
        }


        private void btn_openFile_Click(object sender, EventArgs e)
        {
            string fullPath = string.Empty;
            OpenFileDialog fd = new OpenFileDialog();

            if (fd.ShowDialog() == DialogResult.OK)
            {
                //Получаем полный путь к файлу
                fullPath = fd.FileName;
            }

            if (fullPath != string.Empty)
            {
                try
                {
                    richTextBox_bodyScript.Text = "";
                    string line = string.Empty;
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(fullPath);
                    //Read the first line of text
                    line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        richTextBox_bodyScript.Text += line;
                        richTextBox_bodyScript.Text += "\n";
                        //Read the next line
                        line = sr.ReadLine();
                    }
                    //close the file
                    sr.Close();
                    Console.ReadLine();
                }
                catch (Exception b)
                {
                    MessageBox.Show($"Exception: {b.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    MessageBox.Show("Done", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           
        }



        public partial class CommandEntity
        {
            public int CommandId { get; set; } // ИД команды
            public string CommandTrigger { get; set; } // Слово, на которое команда будет вызываться
            public string SourceNames { get; set; } // Список источников, откуда команда может приходить
            public string CommandAnswer { get; set; } // Ответ команды
            public bool IsScript { get; set; } // Является ли скриптом
            public string ScriptName { get; set; } // Название скрипта
            public string Author { get; set; } // Автор скрипта
            public string Description { get; set; } // Описание скрипта
            public DateTime CreateDate { get; set; } // Время создания скрипта
        }
    }
}
