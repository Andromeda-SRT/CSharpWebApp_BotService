using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Repository;
using WebApplication1.Repository.Entity;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")] //Путь к контроллеру 
    [ApiController]
    public class CommandsController : Controller
    {
        private readonly ICommandRepository _commandsRepository; //Репозиторий для взаимодействия с БД

        public CommandsController(ICommandRepository commandsRepository)
        {
            _commandsRepository = commandsRepository;
        }


        [HttpGet] //Метод будет реагировать на метод GET по пути /api/commands
        public IEnumerable<CommandEntity> Get()
        {
            return _commandsRepository.GetAllCommands(); //Выдает все команды
        }


        [HttpGet("find")] //Метод будет реагировать на метод GET по пути /api/commands/find? sourceName = что - то
        public IEnumerable<CommandEntity> Get(String sourceName)
        {
            return _commandsRepository.FindByCommandBySourceName(sourceName); //Ищем по названию источника
        }


        [HttpGet("{id}")] //Метод будет реагировать на метод GET по пути /api/commands/{id}, где {id}
                          //-идентификатор из базы данных (/api/commands/1, /api/commands/2, /api/commands/10 и тп)
        public CommandEntity Get(int id)
        {
            return _commandsRepository.GetCommandById(id); //Ищем в БД по ИД и возвращаем
        }


        [HttpPost] //Метод будет реагировать на метод POST по пути /api/commands
        public ActionResult<CommandEntity>
            Post1([FromBody] CommandEntity value) // С помощью [FromBody]
                                                  // сущность достанется из Body запроса (JSON)
        {

            //Обрабатываем новый, пришедший скрипт. 
            if (value.IsScript)
            {//Заполняем дефолтные значения.
                value.CommandAnswer = "-";
                value.CreateDate = DateTime.Now;
            }
            else
            {//Обрабатываем новую команду. Заполняем дефолтные значения.
                value.ScriptName = "-";
                value.Description = "-";
                value.CreateDate = DateTime.Now;
            }

            try
            {
                if (value == null)
                    return BadRequest();

                _commandsRepository.SaveCommand(value); //Сохраняем сущность
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new command save");
            }
            return Ok();


        }


        [HttpPut("{id}")] //Метод будет реагировать на метод PUT по пути /api/commands /{ id}, где { id} -идентификатор
                  //из базы данных (/api/commands/1, /api/commands/2, /api/commands/10 и тп)
        public void Put(int id, [FromBody] CommandEntity value) // С помощью [FromBody]
                                                                // сущность достанется из Body запроса (JSON)
        {
            value.CommandId = id; //Заменяем ИД в БД на пришедший нам с пути
            value.CreateDate = DateTime.Now; //Обновляем дату

            _commandsRepository.UpdateCommandEntity(value); // Обновляем сущность в БД
        }


        [HttpDelete("{id}")] //Метод будет реагировать на метод DELETE по пути /api/commands /{ id}, где
                             //{ id}-идентификатор из базы данных (/api/commands/1, /api/commands/2,
                             ///api/commands/10 и тп)
        public void Delete(int id)
        {
            _commandsRepository.DeleteCommandEntity(id); // Удаляем сущност из БД
        }
    }
}
