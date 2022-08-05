using Core.Entities;
using Core.Helpers;
using DataAcces.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekMenage.Controllers
{
    public class OwnerController
    {
        private OwnerRepository ownerRepository;

        public OwnerController()
        {
            ownerRepository = new OwnerRepository();
        }

        public void Creat()
        {
            Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Owner name:");
            string name = Console.ReadLine();
            Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Owner surname:");
            string surname = Console.ReadLine();
            Owner owner = new Owner()
            {
                Name = name,
                Surname = surname
            };
            var creatOwner = ownerRepository.Create(owner);
            Helper.WriteTextWithColor(ConsoleColor.Green, $"Owner is created {name} {surname} ");
        }
        public void GetAll()
        {
            var owners = ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Cyan, "All Owners");
                foreach (var owner in owners)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, $"{owner.Name} {owner.Surname} {owner.DrugStores}");
                }

            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any Owners");
            }
        }
        public void Update()
        {
            var owners = ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, "All owners");

                foreach (var dbowner in owners)
                {
                    Console.WriteLine($"Id - {dbowner.Id}, Name - {dbowner.Name}, {dbowner.Surname}");
                }
               id: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter group id:");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var owner = ownerRepository.Get(o => o.Id == chosenId);
                    if (owner != null)
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Green, "Enter new owner name");
                        string newName = Console.ReadLine();
                        Helper.WriteTextWithColor(ConsoleColor.Green, "Enter new owner surname");
                        string newSurname = Console.ReadLine();
                        var newOwner = new Owner
                        {
                            Id = chosenId,
                            Name = newName,
                            Surname = newSurname,

                        };
                        ownerRepository.Update(newOwner);
                        Helper.WriteTextWithColor(ConsoleColor.Green, $"Name:{newName}, Surname:{newSurname} updated ");

                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "Enter Correct id");
                        goto id;
                    }


                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, "Enter id correct format");
                    goto id;
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any Owner");
            }
        }
        public void Delete()
        {
            var owners = ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, "All Owners");
                foreach (var dbOwner in owners)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Id - {dbOwner.Id}, Name - {dbOwner.Name} Surname-{dbOwner.Surname}");
                }
                id: Helper.WriteTextWithColor(ConsoleColor.Yellow, "Enter Owner Id");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var owner = ownerRepository.Get(o => o.Id == chosenId);
                    if (owner != null)
                    {
                        string name = owner.Name;
                        string surname = owner.Surname;
                        ownerRepository.Delete(owner);
                        Helper.WriteTextWithColor(ConsoleColor.Green, $"{name} {surname} is Deleted");
                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Id");
                        goto id;
                    }
                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct format Id");
                    goto id;
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any Owner");

            }
        }
        public void Exit()
        {

            Helper.WriteTextWithColor(ConsoleColor.Green, "Thanks Using our Aplication");

        }
    }
}
