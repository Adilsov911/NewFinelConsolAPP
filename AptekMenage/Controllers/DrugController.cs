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
    public class DrugController
    {
        private DrugStoreRepository durgStoreRepository;
        private OwnerRepository ownerRepository;
        private DruggistRepository druggistRepository;
        private DrugRepository drugRepository;

        public DrugController()
        {
            durgStoreRepository = new DrugStoreRepository();
            ownerRepository = new OwnerRepository();
            druggistRepository = new DruggistRepository();
            drugRepository = new DrugRepository();
        }
        public void Creat()
        {
            var drugStores = durgStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Drug Name");
                string drugName = Console.ReadLine();
            count: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Drug Count");
                string count = Console.ReadLine();
                byte drugCount;
                bool result = byte.TryParse(count, out drugCount);
                if (result)
                {
                    if (drugCount >= 0)
                    {

                    price: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Drug Price");
                        string price = Console.ReadLine();
                        double drupPrice;
                        bool results = double.TryParse(price, out drupPrice);
                        if (results == true)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Green, "All DrugStores");
                            foreach (var drugStore in drugStores)
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Green, $"Drug Store Id - {drugStore.Id} Name - {drugStore.Name}");
                            }
                        id: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter DrugStore Id");
                            string id = Console.ReadLine();
                            int chosenId;
                            var resultss = int.TryParse(id, out chosenId);
                            if (results)
                            {
                                var drugStore = durgStoreRepository.Get(o => o.Id == chosenId);
                                if (drugStore != null)
                                {
                                    Drug drug = new Drug()
                                    {
                                        Name = drugName,
                                        Count = drugCount,
                                        Price = drupPrice,
                                        DrugStore = drugStore,
                                    };
                                    var creatDrug = drugRepository.Create(drug);
                                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Drug is Created Name: {drugName} Drug Count: {drugCount} Drug Price: {drupPrice} Drug Store Name: {drug.DrugStore.Name} ");

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
                            Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Price");
                            goto price;
                        }
                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Count");
                        goto count;
                    }
                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct format Count");
                    goto count;
                }

            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing anu stores...");

            }
        }
        public void Updete()
        {
            var drugs = drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, "All Drug");
                foreach (var drug in drugs)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Id -{drug.Id} Name -{drug.Name} Store {drug.DrugStore.Name}");
                }
            idd: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Drug Id");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var drug = drugRepository.Get(d => d.Id == chosenId);
                    if (drug != null)
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Green, "Enter new Name");
                        string newName = Console.ReadLine();
                    count: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Drug new Count");
                        string count = Console.ReadLine();
                        byte drugCount;
                        bool results = byte.TryParse(count, out drugCount);
                        if (results)
                        {
                            if (drugCount > 0)
                            {

                            price: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter new Price");
                                string price = Console.ReadLine();
                                double drugPrice;
                                bool resultss = double.TryParse(price, out drugPrice);
                                if (result == true)
                                {
                                    Helper.WriteTextWithColor(ConsoleColor.Green, "All Drug Store");
                                    var drugStores = durgStoreRepository.GetAll();

                                    foreach (var drugStore in drugStores)
                                    {
                                        Helper.WriteTextWithColor(ConsoleColor.Green, $" Id - {drugStore.Id}  Name - {drugStore.Name}");
                                    }
                                id: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Drug Store Id");
                                    int drugStoreid;
                                    string Id = Console.ReadLine();
                                    var resultsss = int.TryParse(Id, out drugStoreid);
                                    if (resultsss)
                                    {
                                        var drugStore = durgStoreRepository.Get(d => d.Id == drugStoreid);
                                        if (drugStore != null)
                                        {
                                            drug.DrugStore = drugStore;
                                            drug.Price = int.Parse(price);
                                            drug.Count = int.Parse(count);
                                            drug.Name = newName;


                                            drugRepository.Update(drug);
                                            Helper.WriteTextWithColor(ConsoleColor.Green, $"Drug Updated : {drug.Name} Count: {drug.Count} Price: {drug.Price} Drug Store Name {drug.DrugStore.Name}");

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
                                    Helper.WriteTextWithColor(ConsoleColor.Red, "Enter number for price");
                                    goto price;
                                }
                            }
                            else
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Count");
                                goto count;
                            }

                        }
                        else
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Format count");
                            goto count;
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
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any drug");
            }
        }
        public void Delete()
        {
            var drugs = drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, "All Drug");
                foreach (var drug in drugs)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, $" Id - {drug.Id} Name-{drug.Name} Drug Store - {drug.DrugStore.Name}  ");
                }
            id: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Drug Id");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var drug = drugRepository.Get(d => d.Id == chosenId);
                    if (drug != null)
                    {
                        string name = drug.Name;
                        drugRepository.Delete(drug);
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
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any Drugs");

            }
        }
        public void GetAll()
        {
            var drugs = drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, "All Drug");
                foreach (var drug in drugs)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, $" Id - {drug.Id} Name: {drug.Name} Price: {drug.Price} Count:{drug.Count} Drug Store - {drug.DrugStore.Name}  ");
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing Any Drugs");
            }
        }
        public void GetAllStoresDrug()
        {

            var drugStores = durgStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, "All Drug Stores");
                foreach (var drugStore in drugStores)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Drug Store: {drugStore.Id} Drugs Name {drugStore.Name}");
                }
            idd: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Drug Store Id");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var drugStore = durgStoreRepository.Get(d => d.Id == chosenId);
                    if (drugStore != null)
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Green, $"Drug Store Name:{drugStore.Name} Drug Name:{drugStore.Drugs}");
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
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing Any Drugs");
            }
        }
        public void Filter()
        {
            var drugs = drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, "Please enter filter price");
                string filterprice = Console.ReadLine();
                double price;
                bool result = double.TryParse(filterprice, out price);
                if (result)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, "All Drugs List:");
                    foreach (var drug in drugs)
                    {
                        if (drug.Price <= price)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Green, $"Id: {drug.Id}, Name: {drug.Name}, Price: {drug.Price}, Count: {drug.Count}");
                        }
                    }
                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, "Enter price in correct format");
                }
            }
            else
            {

                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any drugs");
            }
        }


    }
}
