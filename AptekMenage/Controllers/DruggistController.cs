﻿using Core.Entities;
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
                if (result)
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
                    if (results)
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
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, $"Druggist Created - {druggist.Name} {druggist.Surname} {druggist.Age} Drug Store Name {druggist.DrugStore.Name}");
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
        public void GetAll()
        {
            var druggists = druggistRepository.GetAll();
            if (druggists.Count > 0)
            {

                Helper.WriteTextWithColor(ConsoleColor.Cyan, "All DrugStores");
                foreach (var driggist in druggists)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Name -{driggist.Name} {driggist.Surname} Drug Store - {driggist.DrugStore.Name} ");
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any Druggist");
            }
        }
        public void Update()
        {
            var druggists = druggistRepository.GetAll();
            if (druggists.Count > 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Cyan, "All Druggists");
                foreach (var druggist in druggists)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Id -{druggist.Id} Name -{druggist.Name} ");
                }
            idd: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Druggist Id");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var druggist = druggistRepository.Get(d => d.Id == chosenId);
                    if (druggist != null)
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Green, "Enter new Name");
                        string newName = Console.ReadLine();
                        Helper.WriteTextWithColor(ConsoleColor.Green, "Enter new Surname");
                        string newSurname = Console.ReadLine();
                    age: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter new Age");
                        string age = Console.ReadLine();
                        byte druggistAge;
                        bool results = byte.TryParse(age, out druggistAge);
                        if (results)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Green, "Enter new Experience");
                            string newExperience = Console.ReadLine();
                            Helper.WriteTextWithColor(ConsoleColor.Green, "All Drug Store");
                            var drugStores = durgStoreRepository.GetAll();

                            foreach (var drugStore in drugStores)
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Cyan, $" Id - {drugStore.Id}  Name - {drugStore.Name}");
                            }
                        id: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Drug Store Id");
                            int drugStoreid;
                            string Id = Console.ReadLine();
                            var resultss = int.TryParse(Id, out drugStoreid);
                            if (resultss)
                            {
                                var drugStore = durgStoreRepository.Get(d => d.Id == drugStoreid);
                                if (drugStore != null)
                                {
                                    Druggist druggist1 = new Druggist()
                                    {
                                        Id = druggist.Id,
                                        Name = newName,
                                        Surname = newSurname,
                                        Age = druggistAge,
                                        Experience = newExperience,
                                        DrugStore = drugStore,

                                    };
                                    var creatDruggist = druggistRepository.Create(druggist);
                                    Helper.WriteTextWithColor(ConsoleColor.Cyan, $"Druggist Updated - {druggist.Name} {druggist.Surname} {druggist.Age} Drug Store Name {druggist.DrugStore.Name}");


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
                            Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Format number");
                            goto age;
                        }
                       

                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct id");
                        goto idd;
                    }
                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct format id");
                    goto idd;
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any Druggist");

            }
        }
        public void GetAllDruggistinDrugStore()
        {
            var drugStores = druggistRepository.GetAll();
            var druggists = druggistRepository.GetAll();
            if (true)
            {
                foreach (var druggist in druggists)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, $"Store Name - {druggist.DrugStore.Name} Druggist Name {druggist.Name} {druggist.Surname} ");
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any Druggist and Stores");
            }
        }
        public void Delete()
        {
            var druggists = druggistRepository.GetAll();
            if (druggists.Count > 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, "All Druggists");
                foreach (var druggist in druggists)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, $" Id - {druggist.Id} Name-{druggist.Name} Drug Store - {druggist.DrugStore.Name}  ");
                }
            id: Helper.WriteTextWithColor(ConsoleColor.Yellow, "Enter Druggist Id");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var druggist = druggistRepository.Get(d => d.Id == chosenId);
                    if (druggist != null)
                    {
                        string name = druggist.Name;
                        druggistRepository.Delete(druggist);
                        Helper.WriteTextWithColor(ConsoleColor.Green, $"{name} is Deleted");
                    }
                    else
                    {

                        Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct format id");
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
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any Druggist");
                
            }
        }
    }
}
