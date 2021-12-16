using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminUI.Create
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {






            string getedMsg = richTextBox1.Text;

            //Получим имя команды для этого:
            //Уберём trigger 
            string msgWithoutTrigger = getedMsg.Substring(1);
            //Уберём всё что до пробела и тем самым получаем "пробел+inputValue"
            string inputValue = msgWithoutTrigger.Substring(msgWithoutTrigger.IndexOf(' '));

            //Узнаём название скрипта путём -> msg - "пробел+inputValue"
            string scriptName = msgWithoutTrigger.Replace(inputValue, "");

            //Убираем пробел в начале из inputValue
            inputValue = inputValue.Substring(1);


            textBox1.Text = scriptName;
            textBox2.Text = inputValue;




            //sendPostJsonQueryAsync();
        }

        private async Task sendPostJsonQueryAsync()
        {

            var testCommand = new CommandEntity()
            {
                //CommandId = 0,
                CommandTrigger = (textBox1.Text == String.Empty) ? "-" : richTextBox1.Text,
                SourceNames = "FromTestUI",
                CommandAnswer = (textBox2.Text == String.Empty) ? "-" : textBox2.Text,
                IsScript = radioButton_Script.Checked,
                ScriptName = "Test",
                Author = "TestAdminUI",
                Description = (richTextBox1.Text == String.Empty) ? "-" : richTextBox1.Text
            };

            //Отправляем данные пост запросом
            HttpResponseMessage response = await SubmitCommandToAPIAsync(testCommand);
            //SubmitCommandToAPIAsync(commandEntity1).Wait();

            //Проверка ответа сервера 
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Command dont save \n" +
                    $"Code: {response.StatusCode} = {response.Content.ReadAsStreamAsync()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Done!");
        }


        public static Task<HttpResponseMessage> SubmitCommandToAPIAsync(CommandEntity command)
        {
            //Сериализуем класс в JSON String
            string commandJson = JsonConvert.SerializeObject(command);

            //Переносим наш JSON внутрь StringContent чтобы мы могли использовать HttpClient class
            HttpContent stringContent = new StringContent(commandJson, Encoding.UTF8, "application/json");

            //Инициализируем клиент
            HttpClient httpClient = new HttpClient();

            //Херачим наши данные по пост запросу
            return httpClient.PostAsync("https://localhost:5001/api/commands", stringContent);
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
