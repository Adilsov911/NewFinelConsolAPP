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
    public class DruggistController
    {
        private DrugStoreRepository durgStoreRepository;
        private OwnerRepository ownerRepository;
        private DruggistRepository druggistRepository;

        public DruggistController()
        {
            durgStoreRepository = new DrugStoreRepository();
            ownerRepository = new OwnerRepository();
            druggistRepository = new DruggistRepository();
        }
        public void Creat()
        {
            var drugStores = durgStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Druggist Name");
                string druggistName = Console.ReadLine();
                Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Druggist Surname");
                string druggistSurname = Console.ReadLine();
                age: Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Druggist Age");
                string age = Console.ReadLine();
                byte druggistAge;
                bool result = byte.TryParse(age, out druggistAge);
                if (result != null)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Druggist Experince");
                    string drugExperience = Console.ReadLine();
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, "All DrugStores");
                    foreach (var drugStore in drugStores)
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Cyan, $"Drug Store Id - {drugStore.Id} Name - {drugStore.Name}");
                    }
                id: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter DrugStore Id");
                    int chosenId;
                    string id = Console.ReadLine();
                    var results = int.TryParse(id, out chosenId);
                    if (results != null)
                    {
                        var drugStore = durgStoreRepository.Get(o => o.Id == chosenId);
                        if (drugStore != null)
                        {
                            Druggist druggist = new Druggist
                            {
                                Name = druggistName,
                                Surname = druggistSurname,
                                Age = druggistAge,
                                DrugStore = drugStore
                            };
                            var creatDruggist = druggistRepository.Create(druggist);
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, $"Druggist Created - {druggist.Name} {druggist.Surname} {druggist.Age} Drug Store Name {druggist.DrugStore}");
                        }
                        else
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct id");
                            goto id;
                        }

                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct format id");
                        goto id;

                    }
                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct age");
                    goto age;
                }

            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any DrugStore");
            }

        }
    }
}
