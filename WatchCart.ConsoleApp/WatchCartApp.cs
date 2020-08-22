using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using WatchCart.ConsoleApp.CustomException;
using WatchCart.Models;
using WatchCart.Models.Constants;
using WatchCart.Repository;
using WatchCart.Repository.Order;

namespace WatchCart.ConsoleApp
{
    public class WatchCartApp
    {
        static void Main(string[] args) => StartingApp();
        private static void StartingApp()
        {
            ClearScreen();
            //Account Creation or Login
            string userName = AccountCreation();
            //Get Watch By User Choice
            if (!string.IsNullOrWhiteSpace(userName) && userName != "")
            {
                bool IsOrderPlaced = GettingOrder(userName);
                if(IsOrderPlaced)
                {
                    Console.WriteLine("Your Order Successfully Processed, Press any key to continue.");
                    string success = Console.ReadLine();
                    bool isDone = GettingOrder(userName);
                    if(!isDone)
                    {
                        Logout();
                    }
                }
                else
                {
                    Console.WriteLine("Order Not Processed, Press any key to continue.");
                    string success = Console.ReadLine();
                    bool isDone = GettingOrder(userName);
                    if (!isDone)
                    {
                        Logout();
                    }
                }
            }
            else
            {
                Console.WriteLine("User name doesn't exists enter valid one, Press any key to continue");
                Console.ReadLine();
                AccountCreation();
            }
            Console.ReadLine();
        }
        /// <summary>
        /// This used will check whether user is exist or it will redirect to create account method.
        /// </summary>
        /// <returns></returns>
        public static string AccountCreation()
        {
            UserDetails userDetails = new UserDetails();
            ClearScreen();
            Console.WriteLine("Welcome to Watch Shop!!!");
            Console.WriteLine("Are you an new User? If yes enter 1 else enter your username to continue");
            string userStat = Console.ReadLine();
            if (userStat == "1")
            {
                ClearScreen();
                Console.WriteLine("Kindly enter your Username to create account");
                userDetails.Name = Console.ReadLine();
                bool isAccountCreated = CreateAccount(userDetails);
                if (isAccountCreated)
                    Console.WriteLine("Thanks {0} , Account Created Successfully, Press any key to continue!!!", userDetails.Name);
                else
                    Console.WriteLine("User Already Exists");
                Console.ReadLine();
            }
            else
            {
                ClearScreen();
                UserService userService = new UserService();
                userDetails.Name = userStat;
                bool isAccountlogin = userService.ValidateUser(userDetails);
                if (isAccountlogin)
                    Console.WriteLine("Thanks {0} , Login Successfull !!!!!, Press any key to continue!!!", userDetails.Name);
                else
                    return "";
                Console.ReadLine();
            }
            return userDetails.Name;
        }
        /// <summary>
        /// This used to update user details in DB, So that we can record their order.
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        public static bool CreateAccount(UserDetails userDetails)
        {
            UserService _watchService = new UserService();
            _watchService.CreateNewUser(userDetails);
            return true;
        }

        /// <summary>
        /// Getting order based on catalog
        /// </summary>
        /// <returns></returns>
        public static bool GettingOrder(string userName)
        {
            try
            {
                ClearScreen();
                GettingWatchList(userName);
                WatchCatalog watchCatalog = new WatchCatalog();
                Console.WriteLine($"Hi {userName}, Choose your catalog here. Press 1 - Analog Watch, 2 - Digital Watch, For Exit press any key...!!!");
                string catalogType = Console.ReadLine();
                if (catalogType == "1")
                {
                    var AnalogList = watchCatalog.AnalogCatalog();
                    Console.WriteLine("Here your available analog watches!!!!!!");
                    foreach (var item in AnalogList)
                    {
                        Console.WriteLine($"Id - {item.WatchId}, Brand - {item.BrandName}, StrapType - {item.StrapType}, StrapColor - {item.StrapColor}, Price - {item.Price}, Segment - {item.Segment}, No.of.Hands - {item.NumberOfHands.ToString()}, HasCalendar - {item.HasCalender.ToString()}\n");
                    }
                    Console.WriteLine("Select Watch Id to Process Order!!!");
                    int id = 0;
                    string WatchId = Console.ReadLine();
                    var newId = int.TryParse(WatchId, out id);
                    bool isPlaced = ProcessOrder(id, userName, 1);
                    if (!isPlaced)
                        return false;
                }
                else if (catalogType == "2")
                {
                    var DigitalList = watchCatalog.DigitalCatalog();
                    Console.WriteLine("Here your available digital watches!!!!!!");
                    foreach (var item in DigitalList)
                    {
                        Console.WriteLine($"Id - {item.WatchId}, Brand - {item.BrandName}, StrapType - {item.StrapType}, StrapColor - {item.StrapColor}, Price - {item.Price}, Segment - {item.Segment}, DisplayMode - {item.DisplayMode.ToString()}, HasBackLight - {item.HasBackLight.ToString()}\n");
                    }
                    Console.WriteLine("Select Watch Id to Process Order!!!");
                    int id = 0;
                    string WatchId = Console.ReadLine();
                    var newId = int.TryParse(WatchId, out id);
                    bool isPlaced = ProcessOrder(id, userName, 2);
                    if (!isPlaced)
                        return false;
                }
                else
                {
                    throw new InvalidCatalogTypeException(catalogType);
                }
                return true;
            }
            catch(InvalidCatalogTypeException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static void Logout()
        {
            Console.WriteLine("Thank you for your valuable time !!!");
            Console.ReadLine();
            Environment.Exit(0);
        }
        public static void GettingWatchList(string userName)
        {
            WatchService watchService = new WatchService();
            var lstWatches = watchService.GetWatchDetails(userName);
            if(lstWatches != null && lstWatches.Any())
            {
                Console.WriteLine("*******Your Previous Orders*******");
                foreach(var item in lstWatches)
                {
                    Console.WriteLine($"WatchDetails - {item.WatchDetails} , Order Date - {item.CreatedTime.ToString()}");
                }
            }
            else
            {
                Console.WriteLine("*******You don't have any Previous Orders*******");
            }
        }
        public static string ReturnWatchString(int WatchId, int WatchType)
        {
            WatchCatalog watchCatalog = new WatchCatalog();
            if (WatchType == 1)
            {
                var item = watchCatalog.GetAnalogWatchById(WatchId);
                if (item == null)
                {
                    return "";
                }
                return $"Id - {item.WatchId}, Brand - {item.BrandName}, StrapType - {item.StrapType}, StrapColor - {item.StrapColor}, Price - {item.Price}, Segment - {item.Segment}, No.of.Hands - {item.NumberOfHands.ToString()}, HasCalendar - {item.HasCalender.ToString()}\n";
            }
            else if (WatchType == 2)
            {
                var item = watchCatalog.GetDigitalWatchById(WatchId);
                if(item == null)
                {
                    return "";
                }
                return $"Id - {item.WatchId}, Brand - {item.BrandName}, StrapType - {item.StrapType}, StrapColor - {item.StrapColor}, Price - {item.Price}, Segment - {item.Segment}, DisplayMode - {item.DisplayMode.ToString()}, HasBackLight - {item.HasBackLight.ToString()}\n";
            }
            
            return "";
        }

        /// <summary>
        /// This method used to save the order in db based on user selection
        /// </summary>
        /// <param name="watchId"></param>
        /// <param name="userName"></param>
        public static bool ProcessOrder(int watchId, string userName, int WatchType)
        {
            try
            {
                Watch watch = new Watch();
                //Custom Exception
                if (WatchType != 1 && WatchType != 2)
                    throw new InvalidWatchTypeException(WatchType.ToString());
                watch.UserName = userName;
                watch.WatchDetails = ReturnWatchString(watchId, WatchType);
                OrderRepository orderRepository = new OrderRepository();
                bool isPlaced = orderRepository.PlaceOrder(watch);
                return isPlaced;
            }
            catch(InvalidWatchTypeException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static void ClearScreen()
        {
            Console.Clear();
        }
    }
}
