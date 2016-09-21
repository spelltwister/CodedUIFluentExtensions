using System;
using System.Collections.Generic;

namespace Lib.Tests.DecomposingPageObjects.AccountRequired
{
    public class NewUserData
    {
        public string NewUsername { get; set; }
        public string NewPassword { get; set; }
    }

    public interface IRegisterResult
    {
        IAccountSettingsPageModel AccountSettingsModel { get; }
        NewUserData UserData { get; }
    }

    public class RegisterResult : IRegisterResult
    {
        public IAccountSettingsPageModel AccountSettingsModel { get; set; }
        public NewUserData UserData { get; set; }
    }

    public class NewAccountSettingsData
    {
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }
    }

    public interface IRegisterValidatedUserResult : IRegisterResult
    {
        NewAccountSettingsData AccountSettingsData { get; }
    }

    public class RegisterValidatedUserResult : RegisterResult, IRegisterValidatedUserResult
    {
        public NewAccountSettingsData AccountSettingsData { get; set; }
    }

    public interface IUserWithOrdersResult
    {
        IOrdersPageModel OrdersModel { get; }
        NewUserData UserData { get; }
        NewAccountSettingsData AccountSettingsData { get; }
        ICollection<IOrderItem> OrderData { get; }
    }

    public class UserWithOrderResult : IUserWithOrdersResult
    {
        public IOrdersPageModel OrdersModel { get; set; }
        public NewUserData UserData { get; set; }
        public NewAccountSettingsData AccountSettingsData { get; set; }
        public ICollection<IOrderItem> OrderData { get; set; }
    }

    public interface INewUserScenarios
    {
        IRegisterResult CreateUser();
        IRegisterValidatedUserResult CreateValidatedUser();
        IUserWithOrdersResult CreateUserWithOrders();
    }

    public class NewUserScenarios : INewUserScenarios
    {
        protected ILayoutPageModel Model { get; }
        public NewUserScenarios(ILayoutPageModel model)
        {
            this.Model = model;
        }

        public IRegisterResult CreateUser()
        {
            var result = new RegisterResult()
            {
                UserData = new NewUserData()
                {
                    NewPassword = "useY8$as",
                    NewUsername = Guid.NewGuid().ToString("N")
                }
            };

            result.AccountSettingsModel =
                new RegisterOrchestations(this.Model.Nav.Register.Click()).Register(result.UserData.NewUsername,
                                                                                    result.UserData.NewPassword);

            return result;
        }

        public IRegisterValidatedUserResult CreateValidatedUser()
        {
            var registerResult = CreateUser();

            var result = new RegisterValidatedUserResult()
            {
                UserData = registerResult.UserData,
                AccountSettingsData = new NewAccountSettingsData()
                {
                    NewFirstName = "Mike",
                    NewLastName = "Pav"
                }
            };

            result.AccountSettingsModel =
            registerResult.AccountSettingsModel
                          .FirstName.SetValue(result.AccountSettingsData.NewFirstName)
                          .LastName.SetValue(result.AccountSettingsData.NewLastName)
                          .Save.Click();

            return result;
        }

        public IUserWithOrdersResult CreateUserWithOrders()
        {
            var userResult = CreateValidatedUser();

            var now = DateTime.Now;
            var result = new UserWithOrderResult()
            {
                UserData = userResult.UserData,
                AccountSettingsData = userResult.AccountSettingsData,
                OrderData = new List<IOrderItem>()
                {
                    new OrderItem()
                    {
                        OrderId = Guid.NewGuid().ToString("N"),
                        Name = Guid.NewGuid().ToString("N"),
                        Quantity = now.Millisecond,
                        Price = (now.Millisecond+1) * (now.Minute+1) / 100m
                    }
                }
            };

            var orderOrchestrator = new OrdersOrchestrations(userResult.AccountSettingsModel.Nav.Orders.Click());
            foreach (IOrderItem order in result.OrderData)
            {
                orderOrchestrator.CreateOrder(order);
            }

            result.OrdersModel = orderOrchestrator.Model;
            return result;
        }
    }
}