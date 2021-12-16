using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandAdminUI.EditCommand;
using CommandAdminUI.CreateCommand;

namespace CommandAdminUI
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        //====================================> Service <==========================================

        //Функция заполнения/обновления ListView_script и ListView_echo
        private async Task updateLVAsync()
        {
            listView_echo.Items.Clear();
            listView_scripts.Items.Clear();

            HttpClient client = new HttpClient(); //Инициализируем http client

            //Отправляем get запрос и получаем ответ
            string response = await client.GetStringAsync("https://localhost:5001/api/commands");

            //Конвертируем json формат в List
            List<CommandEntity> commands = JsonConvert.DeserializeObject<List<CommandEntity>>(response);

            //Создаём элемент списка для того что бы добалять его в нужный нам ListView
            ListViewItem itemForLV = null;
            foreach (var item in commands)
            {
                //Если это скрипт добавляем в LV_Sctipts
                if (item.IsScript)
                {
                    itemForLV = new ListViewItem(new string[]
                      { Convert.ToString(item.CommandId),
                      Convert.ToString(item.SourceNames),
                      Convert.ToString(item.ScriptName),
                      Convert.ToString(item.CommandTrigger),
                      Convert.ToString(item.Description),
                      Convert.ToString(item.Author),
                      Convert.ToString(item.CreateDate) });

                    listView_scripts.Items.Add(itemForLV);
                }
                //Иначе в LV_Echo
                else
                {
                    itemForLV = new ListViewItem(new string[]
                      { Convert.ToString(item.CommandId),
                      Convert.ToString(item.SourceNames),
                      Convert.ToString(item.CommandTrigger),
                      Convert.ToString(item.CommandAnswer),
                      Convert.ToString(item.Author),
                      Convert.ToString(item.CreateDate) });

                    listView_echo.Items.Add(itemForLV);
                }
                    
            }

            return;
        }

        //==========================================================================================

        private void mainForm_Load(object sender, EventArgs e)
        {
            updateLVAsync();
        }

        private void UpdataListToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            updateLVAsync();
        }

        private void createCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Инициализируем объект окна
            CreateCommandForm createForm = new CreateCommandForm();

            using (CreateCommandForm form = new CreateCommandForm())
            {
                //Показываем форму
                form.ShowDialog(this);
            }
            updateLVAsync();

        }

        private void deleteCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_echo.SelectedItems.Count > 0 || listView_scripts.SelectedItems.Count > 0)
            {
                if (listView_echo.SelectedItems.Count > 0 && listView_echo.Focused)
                {
                    string commandId = string.Empty;
                    //Достаём id выбранной комманды
                    commandId = listView_echo.FocusedItem.SubItems[0].Text;

                    //Удаляем выбранную команду
                    deleteThisCommand(commandId);
                }
                else if (listView_scripts.SelectedItems.Count > 0 && listView_scripts.Focused)
                {
                    string commandId = string.Empty;
                    //Достаём id выбранной комманды
                    commandId = listView_scripts.FocusedItem.SubItems[0].Text;

                    //Удаляем выбранную команду
                    deleteThisCommand(commandId);
                }
            }
            else
                MessageBox.Show("tabPage not select");
            updateLVAsync();
        }

        private void changeCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string choisedCommand = string.Empty;
            
            if (listView_echo.SelectedItems.Count > 0 || listView_scripts.SelectedItems.Count > 0)
            {
                if (listView_echo.SelectedItems.Count > 0 && listView_echo.Focused)
                {
                    string commandId = string.Empty;
                    //Достаём id выбранной комманды
                    commandId = listView_echo.FocusedItem.SubItems[0].Text;

                    choisedCommand = commandId;
                }
                else if (listView_scripts.SelectedItems.Count > 0 && listView_scripts.Focused)
                {
                    string commandId = string.Empty;
                    //Достаём id выбранной комманды
                    commandId = listView_scripts.FocusedItem.SubItems[0].Text;

                    choisedCommand = commandId;
                }

                //Инициализируем объект окна
                using (EditCommandForm form = new EditCommandForm(choisedCommand))
                {
                    //Показываем форму
                    form.ShowDialog(this);
                }
                updateLVAsync();
            }
            else
                MessageBox.Show("tabPage not select");

            
        }

        private async Task deleteThisCommand(string commandId)
        {
            string createUrl = $"https://localhost:5001/api/commands/{commandId}";

            HttpClient client = new HttpClient();

            //Удаляем комманду по id
            string deleteThisCommand = createUrl;
            var httpResponse = await client.DeleteAsync(deleteThisCommand);

            if (!(httpResponse.StatusCode == System.Net.HttpStatusCode.OK))
                MessageBox.Show("Cant delete this command", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Command has been deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            updateLVAsync();
            return;
        }



    }
}
