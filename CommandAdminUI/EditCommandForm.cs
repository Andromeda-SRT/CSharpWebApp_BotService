using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandAdminUI.EditCommand
{
    public partial class EditCommandForm : Form
    {
        private string cmmadId;

        //Обявляем сущность с которой работаем
        private CommandEntity workingEntity = new CommandEntity();

        public EditCommandForm(string _commandId)
        {
            cmmadId = _commandId;
            InitializeComponent();
            LoadCommandAsync();
        }

        private async Task LoadCommandAsync()
        {

            HttpClient client = new HttpClient(); //Инициализируем http client

            //Отправляем get запрос по ID и получаем ответ
            string response = await client.GetStringAsync("https://localhost:5001/api/commands/"+ cmmadId);

            //Помещяем полученные данные в коллекцию
            workingEntity = JsonConvert.DeserializeObject<CommandEntity>(response);


            if (workingEntity.IsScript)
            {
                string triggerThisCommand = workingEntity.CommandTrigger;
                RadioButton thisRbMustBeCheked = groupBox_trigger.Controls.OfType<RadioButton>().Single(rb => rb.Text == triggerThisCommand);

                groupBox_trigger.Enabled = true;
                thisRbMustBeCheked.Checked = true; radioButton_word.Enabled = false;

                richTextBox_bodyScript.Enabled = true;
                richTextBox_bodyScript.Text = workingEntity.Description;
                btn_openFile.Enabled = true;

                groupBox_name.Text = "Script Name (Kay after trigger: . / ! - )";
                textBox_name.Text = workingEntity.ScriptName;

                richTextBox_answer.Enabled = false;
            }
            else
            {
                radioButton_word.Checked = true;
                groupBox_trigger.Enabled = false;

                richTextBox_bodyScript.Enabled = false;
                btn_openFile.Enabled = false;

                groupBox_name.Text = "Trigger msg";
                textBox_name.Enabled = true;
                textBox_name.Text = workingEntity.CommandTrigger;

                richTextBox_answer.Enabled = true;
                richTextBox_answer.Text = workingEntity.CommandAnswer;
            }



            return;
        }


        //Запрашиваем объект по Id
        public static Task<HttpResponseMessage> GetCommandByIdToAPIAsync(string id)
        {
            //Инициализируем http client
            HttpClient httpClient = new HttpClient();

            //Херачим наши данные по пост запросу
            return httpClient.GetAsync($"https://localhost:5001/api/commands/{id}");
        }

        //Конвертируем json формат в List
        //List<CommandEntity> commands = JsonConvert.DeserializeObject<List<CommandEntity>>(response);


        //Обработка нажания на кнопку Updata
        private void btn_updata_Click(object sender, EventArgs e)
        {
            if ( !(checkBox_telegram.Checked || checkBox_vk.Checked))
            {
                MessageBox.Show("Pls choise source", "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
                sendPullJsonQueryAsync();

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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



        private async Task sendPullJsonQueryAsync()
        {
            //Берём единственный активный radioButton из GroupBox_trigger
            RadioButton thisRadioButtonInTriggerGroupChecked = groupBox_trigger.Controls.OfType<RadioButton>().Single(rb => rb.Checked);


            //Собирем объект (сущность) который собираемя отправить
            var makeCommand = new CommandEntity()
            {
                //CommandId = 0,
                CommandTrigger = (workingEntity.IsScript) ? thisRadioButtonInTriggerGroupChecked.Text : textBox_name.Text, 
                SourceNames = returnChoisedSourseString(),
                CommandAnswer = (richTextBox_answer.Text == String.Empty)?"-": richTextBox_answer.Text,
                IsScript = workingEntity.IsScript,
                ScriptName = (textBox_name.Text == String.Empty)?"-": textBox_name.Text,
                Author = $"{System.Environment.UserName}",
                Description = (richTextBox_bodyScript.Text == String.Empty)?"-": richTextBox_bodyScript.Text
            };

            workingEntity = makeCommand;
            workingEntity.CommandId = Convert.ToInt32(cmmadId);

            //Отправляем данные put запросом
            HttpResponseMessage response = await PullCommandToAPIAsync(cmmadId, workingEntity);
            //SubmitCommandToAPIAsync(commandEntity1).Wait();

            //Проверка ответа сервера 
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Command dont update \n" +
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


        public static Task<HttpResponseMessage> PullCommandToAPIAsync(string idCommand, CommandEntity updateCommand)
        {
            //Сериализуем класс в JSON String
            string commandJson = JsonConvert.SerializeObject(updateCommand);

            //Переносим наш JSON внутрь StringContent чтобы мы могли использовать HttpClient class
            HttpContent stringContent = new StringContent(commandJson, Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            string urlByCommand = "https://localhost:5001/api/commands/" + idCommand;
            //Херачим наши данные по put запросу
            return httpClient.PutAsync(urlByCommand, stringContent);
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
