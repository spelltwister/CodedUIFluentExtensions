namespace Lib.Tests.DecomposingPageObjects.AccountRequired
{
    public interface IRegisterOrchestrations
    {
        IAccountSettingsPageModel Register(string username, string password);
    }

    public class RegisterOrchestations : IRegisterOrchestrations
    {
        public IRegisterPageModel Model { get; }

        public RegisterOrchestations(IRegisterPageModel registerModel)
        {
            this.Model = registerModel;
        }

        public IAccountSettingsPageModel Register(string username, string password)
        {
            return
                this.Model
                    .Username.SetValue(username)
                    .Password.SetValue(password)
                    .ConfirmPassword.SetValue(password)
                    .Register.Click();
        }
    }
}