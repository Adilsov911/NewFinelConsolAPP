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
            DrugController drugController = new DrugController();
            DruggistController druggistController = new DruggistController();
            OwnerController ownerController = new OwnerController();
            AdminController admincontroller = new AdminController();
            DrugStoreController drugStoreController = new DrugStoreController();
        admin: var admin = admincontroller.Authenticade();

            if (admin != null)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, $"Welcome, {admin.Username}");
                Helper.WriteTextWithColor(ConsoleColor.White, "------");

               manu: while (true)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Blue, "Main Menu:");
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, "Owner Menu - 1");
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, "DrugStore Menu - 2");
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, "Druggist Menu - 3");
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, "Drug Menu - 4");
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, "Exit Admin - 0");

                    Helper.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                    string number = Console.ReadLine();
                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);


                    if (result)
                    {
                        if (selectedNumber == 1)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "1 - Create Owner");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "2 - Update Owner");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "3 - GetAll Owner");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "4 - Delete Owner");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "0 - Main Menu");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "Select Options:");
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
                                        goto manu;
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
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "1 - Create DrugStore");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "2 - Update DrugStore");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "3 - Sale Drug");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "4 - GetAll DrugStore");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "5 - Delete DrugStore");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "6 - Get All Owners DrugStores");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "0 - Main Menu");
                            Helper.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                            number = Console.ReadLine();


                            result = int.TryParse(number, out selectedNumber);
                            if (selectedNumber >= 0 && selectedNumber <= 6)
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
                                        case(int)DrugStoreOptions.DeleteDrugStore:
                                        drugStoreController.Delete();
                                        break;
                                    case (int)DrugStoreOptions.SaleDrug:
                                        drugStoreController.Sale();
                                        break;
                                    case (int)OwnerOptions.Exit:
                                        ownerController.Exit();
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
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "1 - Create Druggist");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "2 - Update Druggist");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "3 - GetAll Druggist");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "4 - Delete Druggist");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "5 - Get All Druggist in DrugStore");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "0 - Main Menu");
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
                                    case (int)DruggistOptions.GetAll:
                                        druggistController.GetAll();
                                        break;
                                    case (int)DruggistOptions.DruggistUpdate:
                                        druggistController.Update();
                                        break;
                                    case (int)DruggistOptions.GetAllDruggistinDrugStore:
                                        druggistController.GetAllDruggistinDrugStore();
                                        break;
                                    case (int)DruggistOptions.Delete:
                                        druggistController.Delete();
                                        break;
                                    case (int)OwnerOptions.Exit:
                                        goto manu;
                                        break;
                                }
                            }
                           
                        }
                        else if (selectedNumber == 4)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "1 - Create Drug");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "2 - Update Drug");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "3 - Delete Drug");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "4 - GetAll Drug");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "5 - Get All Drug from Drug Store");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "6 - Filter Drugs");
                            Helper.WriteTextWithColor(ConsoleColor.Cyan, "0 - Main Menu");
                            Helper.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                            number = Console.ReadLine();

                            result = int.TryParse(number, out selectedNumber);
                            if (selectedNumber >= 0 && selectedNumber <= 5)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)DrugOptions.DrugCreat:
                                        drugController.Creat();
                                        break;
                                    case (int)DrugOptions.DrugUpdate:
                                        drugController.Updete();
                                        break;
                                    case (int)DrugOptions.DrugDelete:
                                        drugController.Delete();
                                        break;
                                    case (int)DrugOptions.GetAllDrugs:
                                        drugController.GetAll();
                                        break;
                                    case (int)DrugOptions.GetAllDrugsDrugStore:
                                        drugController.GetAllStoresDrug();
                                        break;
                                    case (int)DrugOptions.FilterDrug:
                                        drugController.Filter();
                                        break;
                                    case (int)OwnerOptions.Exit:
                                        goto manu;
                                        break;
                                }
                            }

                        }
                        else if (selectedNumber==0)
                        {
                            goto admin;
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
                goto admin;

            }
        }
    }
}
