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
        }
        public void Creat()
        {
            var drugStores = durgStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drug Name");
                string drugName = Console.ReadLine();
            count: Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drug Count");
                string count = Console.ReadLine();
                byte drugCount;
                bool result = byte.TryParse(count, out drugCount);
                if (result)
                {
                    if (drugCount >= 0)
                    {

                    price: Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drug Price");
                        string price = Console.ReadLine();
                        double drupPrice;
                        bool results = double.TryParse(price, out drupPrice);
                        if (results == true)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "All DrugStores");
                            foreach (var drugStore in drugStores)
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Cyan, $"Drug Store Id - {drugStore.Id} Name - {drugStore.Name}");
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
                                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Drug is Created Name-{drugName} {drugCount} {drupPrice} Drug Store Name-{drug.DrugStore.Name} ");

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
                Helper.WriteTextWithColor(ConsoleColor.Cyan, "All Drug");
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
                    count: Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drug new Count");
                        string count = Console.ReadLine();
                        byte drugCount;
                        bool results = byte.TryParse(count, out drugCount);
                        if (results)
                        {
                            if (drugCount>0)
                            {

                            age: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter new Price");
                                string price = Console.ReadLine();
                                double drugPrice;
                                bool resultss = double.TryParse(price, out drugPrice);
                                if (result == true)
                                {
                                    Helper.WriteTextWithColor(ConsoleColor.Green, "All Drug Store");
                                    var drugStores = durgStoreRepository.GetAll();

                                    foreach (var drugStore in drugStores)
                                    {
                                        Helper.WriteTextWithColor(ConsoleColor.Cyan, $" Id - {drugStore.Id}  Name - {drugStore.Name}");
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
                                            Drug druggist1 = new Drug()
                                            {
                                                Id = drug.Id,
                                                Name = newName,
                                                Count = drugCount,
                                                Price = drugPrice,
                                                DrugStore = drugStore


                                            };
                                            var creatDrug = drugRepository.Create(drug);
                                            Helper.WriteTextWithColor(ConsoleColor.Cyan, $"Drug Updated - {drug.Name} Count: {drug.Count} Price: {drug.Price} Drug Store Name {drug.DrugStore.Name}");

                                        }
                                        else
                                        {
                                            Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct id");
                                        }
                                    }
                                    else
                                    {
                                        Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct format id");
                                    }

                                }
                                else
                                {
                                    Helper.WriteTextWithColor(ConsoleColor.Red, "Enter number for price");
                                }
                            }
                            else
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Count");
                            }

                        }
                        else
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Format count");
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
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any drug");
            }
        }
    }
}
