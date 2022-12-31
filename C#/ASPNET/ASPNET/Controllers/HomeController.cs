using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ASPNET.Controllers
{

    public class Skill
    {
        public Skill(string nameSkill, int cd)
        {
            NameSkill = nameSkill;
            this.cd = cd;
        }

        public string NameSkill { get; set; }
        public int cd { get; set; }
    }

    public class Character //Здесь тоже 
    {
        public Character(string name, string surname, string description, Skill[] skills)
        {
           Name  =  name;
           Surname = surname;
            Skills = skills;
           Description = description;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public Skill[] Skills { get; set; }

    }

    public class HomeController : Controller
    {


        public JsonResult Index()
        {
            var skills = new Skill[2] { new Skill("Bad Apple", 5), new Skill("Taboo Tears you", 7) };
            return new JsonResult(new Character("Flander", "Scarlet", "Vampire lives in big mansion",skills));

        }
        [Route("character")]
        [HttpPost]
        public string PostCharacter()
        {

            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true; //Указыаваем что мы игнорируем регистр полей 
            if (Request.HasJsonContentType()) //Если контент type json 
            {
                Character? chara = Request.ReadFromJsonAsync<Character>(options).Result; //Переводим json в класс Character
                return "Hello " + chara?.Name;
            }
            return "Content type not equals application/json";





        }

    }
}
