using System;
using System.Collections.Generic;
using TelegramBot.Model;
using WebApplication1.TelegramBot;
using WebApplication1.Repository;
using WebApplication1.Repository.Entity;
using System.IO;
using NLua;

namespace WebApplication1.Service
{
    public class chatService : IChatIService
    {

        private IBot _bot = null;
        private readonly ICommandRepository _commandRepoistory;

        //Example 
        //string LuaFileDirectory = @"C:\Users\Andromeda\Documents\WebApplication\mainSolutionSPL\WebApplication1\Service\Scripts\";
        
        string specialFolderForScript = @"Service\Scripts\";
        string ExtensionFile = ".lua";

        //String containing a full path to the lua script
        string LuaFilePath = string.Empty;


        public chatService(ICommandRepository commandRepository)
        {
            this._commandRepoistory = commandRepository;
        }

        public void processMessage(ChatMessage chatMessage)
        {
            string errAsr = "Error: _bot == null by WebApplication1.Service => processMessage()";
            if (_bot != null)
            {
                LuaFilePath = string.Empty;
                //List<CommandEntity> commands = _commandRepoistory.FindByCommandByTrigger(chatMessage.Message);

                string getedMsg = chatMessage.Message;
                bool typeOfMsgIsScript = false; //||

                //Определяем запрашивается скрипт или эхо
                if (getedMsg[0] != '.' && getedMsg[0] != '/' && getedMsg[0] != '!' && getedMsg[0] != '-')
                    typeOfMsgIsScript = false; //Значит это не скрипт
                else//Иначе это скрипт
                    typeOfMsgIsScript = true;

                //Если скрипт
                if (typeOfMsgIsScript)
                {
                    string scriptName = string.Empty;
                    string inputValueForScript = string.Empty;

                    //Пытаемся разбить строку на служебные (необходимые нам) части
                    try
                    {
                        //Получим имя команды для этого:
                        //Уберём trigger 
                        string msgWithoutTrigger = getedMsg.Substring(1);
                        //Уберём всё что до пробела и тем самым получаем "пробел+inputValue"
                        inputValueForScript = msgWithoutTrigger.Substring(msgWithoutTrigger.IndexOf(' '));

                        //Узнаём название скрипта путём -> msg - "пробел+inputValue"
                        scriptName = msgWithoutTrigger.Replace(inputValueForScript, "");

                        //Убираем пробел в начале из inputValue
                        inputValueForScript = inputValueForScript.Substring(1);
                    }
                    catch
                    {
                        _bot.SendMessageToChat(new ChatMessage(chatMessage.Source, chatMessage.ChatId, "Некорректный ввод команды"));
                        return;
                    }
                    

                    //Выполняем поиск по необходимой нам команде и возвращаем её
                    List<CommandEntity> commands = _commandRepoistory.FindCommandByScript(getedMsg[0], scriptName);

                    //Если ответ (команда с таким тригером) существует
                    if (commands.Count != 0)
                    {//Исполняем скрипт и отправляем ответ в бота

                        string luaResult = string.Empty;

                        //Перезаписываем файл lua.lua добавляя в него скрипт из описания
                        //ReWriteFile(commands[0].Description) true
                        if (ReWriteFile(commands[0].Description, chatMessage.Source, chatMessage.ChatId))
                        {
                            //Исполняем скрипт и Возвращем результат
                            luaResult = exeLuaScript(inputValueForScript);
                        }

                        string resultScript = luaResult;
                        if (resultScript != string.Empty)
                        {
                            //Отправляем результат в бота
                            _bot.SendMessageToChat(new ChatMessage(chatMessage.Source, chatMessage.ChatId, resultScript));
                        }
                        else
                            _bot.SendMessageToChat(new ChatMessage(chatMessage.Source, chatMessage.ChatId, "Невозможно выполнить скрипт"));



                    }
                    else //Иначе -- отправляем ответ в виде "Неизвестная команда"
                        _bot.SendMessageToChat(new ChatMessage(chatMessage.Source, chatMessage.ChatId, "Я не знаю такой команды"));
                }
                else //Если Эхо
                {//Находим ответ из команды по тексту сообщения и отправляем его

                    //Получаем все команды которые соответствуют non skript and trigger = msg
                    List<CommandEntity> commands = _commandRepoistory.FindCommandByMsg(chatMessage.Message);

                    //Если ответ (команда с таким тригером) существует
                    if (commands.Count != 0)
                    {//Отправляем ответ из команды (поля команды commandAnswer)
                        _bot.SendMessageToChat(new ChatMessage(chatMessage.Source, chatMessage.ChatId, commands[0].CommandAnswer));
                    } 
                    else //Иначе -- отправляем ответ в виде "Неизвестная команда"
                        _bot.SendMessageToChat(new ChatMessage(chatMessage.Source, chatMessage.ChatId, "Я не знаю что тебе ответить"));
                }
            }
            else
            {
                _bot.SendMessageToChat(new ChatMessage(chatMessage.Source, chatMessage.ChatId, errAsr));
            }
        }

        public void registerBot(IBot bot)
        {
            _bot = bot;
        }


        private bool ReWriteFile(string scriptText, string source, long chatId)
        {
            bool writeIsDone = false;

            string Id = chatId.ToString();

            //@"C:\Users\Andromeda\Documents\WebApplication\mainSolutionSPL\WebApplication1
            string thisDerectory = Environment.CurrentDirectory;

            //@"C:\Users\Andromeda\Documents\WebApplication\mainSolutionSPL\WebApplication1\Service\Scripts
            string LuaFileDirectory = Path.Combine(thisDerectory, specialFolderForScript);

            //<sourse + id> + .lua        params in <> can take any value 
            string logUserExeScriptName = String.Concat(source, Id, ExtensionFile);

            //@"C:\Users\Andromeda\Documents\WebApplication\mainSolutionSPL\WebApplication1\Service\Scripts\<sourse+Id>.lua
            LuaFilePath = Path.Combine(LuaFileDirectory, logUserExeScriptName);

            try
            {
                string fullPath = LuaFilePath;

                string line = scriptText;
                //Pass the file path and file name to the StreamWriter constructor
                StreamWriter sr = new StreamWriter(fullPath, false, System.Text.Encoding.Default);
                //Write the first line of text
                sr.WriteLine(line);
                //close the file
                sr.Close();

                writeIsDone = true;
            }
            catch (Exception b)
            {
                Console.WriteLine($"Write script in script file .lua is fall: {b.Message}");
                writeIsDone = false;
            }

            return writeIsDone;
        }

        private string exeLuaScript(string inputString)
        {
            string resultScript = string.Empty;

            if (LuaFilePath != string.Empty)
            {
                using (Lua luaState = new Lua())
                {
                    //Указываем путь к скрипту
                    luaState.DoFile(LuaFilePath);

                    //Указываем функцию которую необходимо исполнить
                    LuaFunction scriptFunc = luaState["returnResult"] as LuaFunction; // Функция возвращает массив

                    //Данные которые будут отправленны в скрипт
                    string stringForLuaScript = inputString;

                    //Переменная хранящая результат вызова скрипта
                    var result = scriptFunc.Call(stringForLuaScript)[0];

                    //Переводим результат в строковый тип
                    resultScript = result.ToString();
                }
            }
            else
            {
                Console.WriteLine("Error exeLuaScript(): LuaFilePath is null");
                resultScript = "Error exeLuaScript(): LuaFilePath is null";
            }
            
            

            //Возвращаем результат
            return resultScript;
        }
    }
}
