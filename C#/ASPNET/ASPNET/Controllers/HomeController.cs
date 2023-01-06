using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Xml.Linq;

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


        public string Index()
        {
            XDocument xdoc = XDocument.Load("character.xml");
            // получаем корневой узел
            XElement? character = xdoc.Element("character");
            var Skills = character?.Element("Skills");
            if ((Skills?.HasElements) is not null)
            {

                //var names = Skills?.Elements("Skill").Where(x => x.Attribute("Name")?.Value == "Night Bird");
                var names = Skills?.Elements("Skill");
                if (names is not null)
                {
                    foreach (var x in names)
                    {
                        Console.WriteLine("Имя скилла " + x.Attribute("Name")?.Value + " Cd " + x.Attribute("Cd")?.Value);
                    }
                }
            }
            XDocument newxdoc = new XDocument(new XElement("character",
     new XElement("Name", "Marisa"),
      new XElement("Description", "Magic Forset"),
         new XElement("Skills",
         new XElement("Skill", new XAttribute("Name", "Master Spark"), new XAttribute("Cd", "2")),
         new XElement("Skill", new XAttribute("Name", "Final Spark"), new XAttribute("Cd", "5"))
         )
         ));
            newxdoc.Save("newcharacter.xml");
            return "Hello " + character?.Element("Name")?.Value + ". Hello " + newxdoc?.Element("character")?.Element("Name")?.Value;

        }


    }
}
