using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CommandAdminUI
{
    public class CommandEntity
    {
        [JsonProperty("CommandId")]
        public int CommandId { get; set; } // ИД команды

        [JsonProperty("CommandTrigger")]
        public string CommandTrigger { get; set; } // Слово, на которое команда будет вызываться

        [JsonProperty("SourceNames")]
        public string SourceNames { get; set; } // Список источников, откуда команда может приходить

        [JsonProperty("CommandAnswer")]
        public string CommandAnswer { get; set; } // Ответ команды

        [JsonProperty("IsScript")]
        public bool IsScript { get; set; } // Является ли скриптом

        [JsonProperty("ScriptName")]
        public string ScriptName { get; set; } // Название скрипта

        [JsonProperty("Author")]
        public string Author { get; set; } // Автор скрипта

        [JsonProperty("Description")]
        public string Description { get; set; } // Описание скрипта

        [JsonProperty("CreateDate")]
        public string CreateDate { get; set; } // Время создания скрипта

    }
}
