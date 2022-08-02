using AptekMenage.Controllers;
using Core.Constants;
using Core.Helpers;
using System;

namespace AptekMenage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DruggistController druggistController = new DruggistController();
            OwnerController ownerController = new OwnerController();
            AdminController admincontroller = new AdminController();
            DrugStoreController drugStoreController = new DrugStoreController();
        goadmin: var admin = admincontroller.Authenticade();

            if (admin != null)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, $"Welcome, {admin.Username}");
                Helper.WriteTextWithColor(ConsoleColor.White, "------");

                while (true)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Blue, "Main Menu:");
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, "Owner Menu - 1");
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, "DrugStore Menu - 2");
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, "Druggist Menu - 3");

                    Helper.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                    string number = Console.ReadLine();
                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);


                    if (result)
                    {
                        if (selectedNumber == 1)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Owner");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Owner");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "3 - GetAll Owner");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Delete Owner");
                            Helper.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                            number = Console.ReadLine();


                            result = int.TryParse(number, out selectedNumber);
                            if (selectedNumber >= 0 && selectedNumber <= 4)
                            {
                                switch (selectedNumber)
                                {

                                    case (int)OwnerOptions.OwnerCreat:
                                        ownerController.Creat();
                                        break;
                                    case (int)OwnerOptions.UpdateOwner:
                                        ownerController.Update();
                                        break;
                                    case (int)OwnerOptions.GetAllOwner:
                                        ownerController.GetAll();
                                        break;
                                    case (int)OwnerOptions.DeleteOwner:
                                        ownerController.Delete();
                                        break;
                                    case (int)OwnerOptions.Exit:
                                        ownerController.Exit();
                                        break;


                                }
                            }


                            else
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
                            }
                        }
                        else if (selectedNumber == 2)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create DrugStore");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update DrugStore");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "3 - GetAll DrugStore");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Delete DrugStore");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get All Owners DrugStores");
                            Helper.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                            number = Console.ReadLine();


                            result = int.TryParse(number, out selectedNumber);
                            if (selectedNumber >= 0 && selectedNumber <= 5)
                            {
                                switch (selectedNumber)
                                {

                                    case (int)DrugStoreOptions.CreatDrugStore:
                                        drugStoreController.Creat();
                                        break;
                                    case (int)DrugStoreOptions.UpdateDrugStore:
                                        drugStoreController.Update();
                                        break;
                                    case (int)DrugStoreOptions.GetAllDrugStore:
                                        drugStoreController.GetAll();
                                        break;
                                    case (int)DrugStoreOptions.GetOwnerDrugStore:
                                        drugStoreController.GetAllOwnerStore();
                                        break;



                                }
                            }
                            else
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Red, "Please, Select Correct Options...");
                            }
                        }
                        else if (selectedNumber == 3)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create DrugStore");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update DrugStore");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "3 - GetAll DrugStore");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Delete DrugStore");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get All Owners DrugStores");
                            Helper.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                            number = Console.ReadLine();

                            result = int.TryParse(number, out selectedNumber);
                            if (selectedNumber >= 0 && selectedNumber <= 5)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)DruggistOptions.DruggistCreat:
                                        druggistController.Creat();
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Red, "Please, Select Correct Options...");
                        }
                    }
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Username or Password incorrect");
                goto goadmin;

            }
        }
    }
}
