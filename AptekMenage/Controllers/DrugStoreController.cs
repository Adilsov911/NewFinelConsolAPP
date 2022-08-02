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
    public class DrugStoreController
    {
        private DrugStoreRepository durgStoreRepository;
        private OwnerRepository ownerRepository;

        public DrugStoreController()
        {
            durgStoreRepository = new DrugStoreRepository();
            ownerRepository = new OwnerRepository();
        }
        public void Creat()
        {
            
            var owners = ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                
                Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drug Store name");
                string drugName = Console.ReadLine();
                Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter DrugStore Adress");
                string drugAdress = Console.ReadLine();
                Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter DrugStore contact number");
                string drugNumber = Console.ReadLine();

                Helper.WriteTextWithColor(ConsoleColor.Green, "All Owners");
                foreach (var owner in owners)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, $"Owner Id - {owner.Id} Owner Name - {owner.Name}");
                }
                id: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Owner Id");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var owner = ownerRepository.Get(o => o.Id == chosenId);
                    if (owner != null)
                    {
                        DrugStore drugStore = new DrugStore()
                        {
                            Name = drugName,
                            Adress = drugAdress,
                            ContactNumber = drugNumber,
                            Owner = owner
                        };
                        var creatDrugstore = durgStoreRepository.Create(drugStore);
                        Helper.WriteTextWithColor(ConsoleColor.Green, $"New DrugStore Created Name {drugStore.Name} {drugStore.Adress} {drugStore.ContactNumber} Owner Name {drugStore.Owner}");
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
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any owners");
            }
        }
        public void Update()
        {
            var drugStores = durgStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {

                Helper.WriteTextWithColor(ConsoleColor.Cyan, "All DrugStores");
                foreach (var drugStore in drugStores)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Id -{drugStore.Id} Name -{drugStore.Name} ");
                }
               idd: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter DrugStore Id");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var drugStore = durgStoreRepository.Get(d => d.Id == chosenId);
                    if (drugStore != null)
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Green, "Enter new Name");
                        string newName = Console.ReadLine();
                        Helper.WriteTextWithColor(ConsoleColor.Green, "Enter new Adress");
                        string newAdress = Console.ReadLine();
                        Helper.WriteTextWithColor(ConsoleColor.Green, "enter new Contack number");
                        string newNumber = Console.ReadLine();

                        Helper.WriteTextWithColor(ConsoleColor.Green, "All Owners");
                        var owners = ownerRepository.GetAll();

                        foreach (var owner in owners)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, $"Owner Id - {owner.Id} Owner Name - {owner.Name}");
                        }
                        id: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Owner Id");
                        int ownerId;
                        string Id = Console.ReadLine();
                        var results = int.TryParse(Id, out ownerId);
                        if (results)
                        {
                            var owner = ownerRepository.Get(o => o.Id == ownerId);
                            if (owner != null)
                            {
                                DrugStore drugStore1 = new DrugStore()
                                {
                                    Name = newName,
                                    Adress = newAdress,
                                    ContactNumber = newNumber,
                                    Owner = owner
                                };
                                var creatDrugstore = durgStoreRepository.Create(drugStore);
                            }
                            else
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Red, "Enter Correct Id");
                                goto id;
                            }

                        }
                        else
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Red, "Enter Correct format Id");
                            goto id;
                        }

                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "Enter Correct Id");
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
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any DrugStore");
            }

        }
        public void GetAll()
        {
            var drugStores = durgStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {

                Helper.WriteTextWithColor(ConsoleColor.Cyan, "All DrugStores");
                foreach (var drugStore in drugStores)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Name -{drugStore.Name} Owner Name {drugStore.Owner.Name} ");
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any Drug stores");
            }

        }
        public void GetAllOwnerStore()
        {
            var drugStores = durgStoreRepository.GetAll();
            var ownerStores = ownerRepository.GetAll();
            if (true)
            {
                foreach (var drugStore in drugStores)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, $"Owner - {drugStore.Owner.Name} {drugStore.Owner.Surname} Drug Stores - {drugStore.Name} ");
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any Owner and Stores");
            }
        }
        public void Sale()
        {

        }
    }
}
