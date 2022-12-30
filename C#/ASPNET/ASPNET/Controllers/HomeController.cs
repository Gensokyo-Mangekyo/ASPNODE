using Microsoft.AspNetCore.Mvc;

namespace ASPNET.Controllers
{

   public  class Skill
    {
        public Skill(string nameSkill, int cd)
        {
            NameSkill = nameSkill;
            this.cd = cd;
        }

        public string NameSkill { get; set; }
        public int cd { get; set; }
    }

    public class Character
    {
        public Character(string name, string surname, string description, Skill[] skiils)
        {
            Name = name;
            Surname = surname;
            this.skills = skiils;
            Description = description;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public Skill[] skills { get; set; }

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
            return "Failed";

        }


    }
}
