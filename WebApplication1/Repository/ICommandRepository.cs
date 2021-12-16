using System;
using System.Collections.Generic;
using WebApplication1.Repository.Entity;

namespace WebApplication1.Repository
{
    public interface ICommandRepository
    {
        public void SaveCommand(CommandEntity commandEntity); //Сохранение сущности команды
        public CommandEntity GetCommandById(int id); //Поиск сущности команд по ИД
        public List<CommandEntity> GetAllCommands(); //Получение всех сущеностей
        public void UpdateCommandEntity(CommandEntity commandEntity); //Обновление сущности команд
        public void DeleteCommandEntity(int id); //Удаление сущности по id
        public List<CommandEntity> FindByCommandBySourceName(string sourceName); //Поиск списка сущностей
        //public List<CommandEntity> FindByCommandByAuthor(string sourcename); //Поиск списка авторов 
        //public List<CommandEntity> FindByCommandByTrigger(string triggername);
        public List<CommandEntity> FindCommandByMsg(string msg); //Поиск по обычному сообщению (не скрипту)
        public List<CommandEntity> FindCommandByScript(char trigger, string partMsgAfterTrigger); //Поиск по названию скрипта
        }
}
