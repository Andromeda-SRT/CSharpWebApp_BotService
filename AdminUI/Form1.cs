using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminUI.Create;
using NLua;

namespace AdminUI
{
    public partial class TEST : Form
    {
        public TEST()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string resultScript = string.Empty;

            string LuaFilePath = @"C:\Users\Andromeda\Desktop\scripts\hello.lua";
            LuaFilePath = @"C:\Users\Andromeda\Documents\WebApplication\mainSolutionSPL\WebApplication1\Service\Scripts\lua.lua";
            using (Lua luaState = new Lua())
            {
                //Указываем путь к скрипту
                luaState.DoFile(LuaFilePath);

                //Указываем функцию которую необходимо исполнить
                LuaFunction scriptFunc = luaState["returnResult"] as LuaFunction; // Функция возвращает массив

                //Данные которые будут отправленны в скрипт
                string strWithTestValues = textBox1.Text;

                //Переменная хранящая результат вызова скрипта
                var result = scriptFunc.Call(strWithTestValues)[0];

                //Переводим результат в строковый тип
                resultScript = result.ToString();
            }

            //Отображаем результат
            textBox2.Text = resultScript;

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

        private void button2_Click(object sender, EventArgs e)
        {
            using (Form2 form = new Form2())
            {
                //Отображаем окно
                form.ShowDialog(this);

                if (form.DialogResult == DialogResult.OK)
                {
                    
                }
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
