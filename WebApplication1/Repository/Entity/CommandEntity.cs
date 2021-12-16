using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Repository.Entity
{
    public partial class CommandEntity
    {
        [Key] //Следующее поле/свойство будет первичным ключом в таблице
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
