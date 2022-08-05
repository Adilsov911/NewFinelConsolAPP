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
        private DrugRepository drugRepository;

        public DrugStoreController()
        {
            durgStoreRepository = new DrugStoreRepository();
            ownerRepository = new OwnerRepository();
            drugRepository = new DrugRepository();
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
                        Helper.WriteTextWithColor(ConsoleColor.Green, $"New DrugStore Created Name {drugStore.Name} {drugStore.Adress} {drugStore.ContactNumber} Owner Name {drugStore.Owner.Name}");
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
            idd: Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter DrugStore Id");
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
                        Helper.WriteTextWithColor(ConsoleColor.Green, "Enter new Contack number");
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

                                drugStore.Name = newName;
                                drugStore.Adress = newAdress;
                                drugStore.ContactNumber = newNumber;
                                drugStore.Owner = owner;

                                durgStoreRepository.Update(drugStore);
                                Helper.WriteTextWithColor(ConsoleColor.Green, $"Drug store is updated {drugStore.Name} {drugStore.Adress}{drugStore.ContactNumber} Owner {drugStore.Owner.Name}");
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
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Name -{drugStore.Name} Owner Name {drugStore.Owner.Name} id-{drugStore.Id}");
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
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Owner - {drugStore.Owner.Name} {drugStore.Owner.Surname} Drug Stores - {drugStore.Name} ");
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any Owner and Stores");
            }
        }
        public void Sale()
        {
            GetAll();
        idd: Helper.WriteTextWithColor(ConsoleColor.Green, "Please Slecet DrugStore id");
            var id = Console.ReadLine();
            int drugStoreId;
            var results = int.TryParse(id, out drugStoreId);
            if (results)
            {
                var dbDrugStore = durgStoreRepository.Get(d => d.Id == drugStoreId);
                if (dbDrugStore != null)
                {
                    var dbDrugs = drugRepository.GetAll(d => d.DrugStore == dbDrugStore);
                    if (dbDrugs.Count > 0)
                    {
                        foreach (var drug in dbDrugs)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Green, $"Drug Id: {drug.Id} Drug name: {drug.Name} Drug price: {drug.Price} Drug Cout: {drug.Count}");
                        }
                    id: Helper.WriteTextWithColor(ConsoleColor.Green, "Please enter drug id");
                        var drugid = Console.ReadLine();
                        int DrugId;
                        results = int.TryParse(drugid, out DrugId);
                        if (results)
                        {
                            var dbDrug = drugRepository.Get(d => d.Id == DrugId);
                            if (dbDrug != null && dbDrug.Count > 0)
                            {
                            count: Helper.WriteTextWithColor(ConsoleColor.Green, $"Drug count {dbDrug.Count} please enter count");
                                var count = Console.ReadLine();
                                int dbcount;
                                results = int.TryParse(count, out dbcount);
                                if (results)
                                {
                                Nn: if (dbcount <= dbDrug.Count)
                                    {
                                        Helper.WriteTextWithColor(ConsoleColor.Green, $"Sale Price {dbcount * dbDrug.Price}");
                                        dbDrug.Count -= dbcount;
                                    }
                                    else
                                    {
                                        Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct count");
                                        goto Nn;

                                    }
                                }
                                else
                                {
                                    Helper.WriteTextWithColor(ConsoleColor.Red, "Plesae enter correct count");
                                    goto count;
                                }


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
                        Helper.WriteTextWithColor(ConsoleColor.Green, "We dont have drug ");
                    }

                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.DarkCyan, "We dont have this id Drugstore");
                    goto idd;
                }

            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please enter Correct id");
                goto idd;
            }

        }
        public void Delete()
        {
            var drugStores = durgStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, "All DrugStores");
                foreach (var drugStore in drugStores)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Drug Store Id - {drugStore.Id} Owner Name-{drugStore.Owner.Name} ");
                }
            id: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter DrugStore Id");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var drugStore = durgStoreRepository.Get(d => d.Id == chosenId);
                    if (drugStore != null)
                    {
                        string name = drugStore.Name;
                        durgStoreRepository.Delete(drugStore);
                        Helper.WriteTextWithColor(ConsoleColor.Green, $"{name} is Deleted");
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
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing any Drug Store");
            }
        }
    }
}
