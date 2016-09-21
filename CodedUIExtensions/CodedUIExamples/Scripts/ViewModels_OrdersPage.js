var UsernamePasswordViewModel = (function () {
    function UsernamePasswordViewModel(initialValue) {
        var _this = this;
        this.username = ko.observable(initialValue && initialValue.username);
        this.password = ko.observable(initialValue && initialValue.password);
        this.hasCredentials = ko.pureComputed(function () { return _this.username() && _this.password() && true; });
    }
    return UsernamePasswordViewModel;
}());
var LoginViewModel = (function () {
    function LoginViewModel(credentialsVM) {
        var _this = this;
        this.credentialsVM = credentialsVM || new UsernamePasswordViewModel();
        this.canLogin = ko.pureComputed(function () { return _this.credentialsVM.hasCredentials(); });
    }
    LoginViewModel.prototype.login = function () {
        if (!this.canLogin()) {
            return null;
        }
        // call out to API
        var user = UserDataStore.instance.findByUsername(this.credentialsVM.username());
        if (user && user.password === this.credentialsVM.password()) {
            return user.settings;
        }
    };
    return LoginViewModel;
}());
var RegistrationViewModel = (function () {
    function RegistrationViewModel(initialValue) {
        var _this = this;
        this.credentialsVM = initialValue && initialValue.credentialsVM || new UsernamePasswordViewModel();
        this.confirmPassword = ko.observable(initialValue && initialValue.confirmPassword);
        this.canRegister = ko.pureComputed(function () { return _this.credentialsVM.hasCredentials() && _this.credentialsVM.password() === _this.confirmPassword(); });
    }
    RegistrationViewModel.prototype.register = function () {
        if (!this.canRegister()) {
            return null;
        }
        // call out to API
        if (UserDataStore.instance.findByUsername(this.credentialsVM.username())) {
            throw 'Duplicate username';
        }
        var newUser = {
            username: this.credentialsVM.username(),
            password: this.credentialsVM.password(),
            settings: { username: this.credentialsVM.username(), firstName: null, lastName: null }
        };
        UserDataStore.instance.users.push(newUser);
        return newUser.settings;
    };
    return RegistrationViewModel;
}());
var AccountSettingsViewModel = (function () {
    function AccountSettingsViewModel(initialValue) {
        this.firstName = ko.observable(null);
        this.lastName = ko.observable(null);
        this.loadSettings(initialValue || {});
    }
    AccountSettingsViewModel.prototype.loadSettings = function (settings) {
        this.username = settings.username;
        this.firstName(settings.firstName);
        this.lastName(settings.lastName);
    };
    AccountSettingsViewModel.prototype.save = function () {
        UserDataStore.instance.findByUsername(this.username).settings = this.getSettings();
    };
    AccountSettingsViewModel.prototype.getSettings = function () {
        return {
            username: this.username,
            firstName: this.firstName(),
            lastName: this.lastName()
        };
    };
    return AccountSettingsViewModel;
}());
var OrdersViewModel = (function () {
    function OrdersViewModel(initialValue) {
        var _this = this;
        this.orderId = ko.observable(initialValue && initialValue.orderId);
        this.name = ko.observable(initialValue && initialValue.name);
        this.price = ko.observable(initialValue && initialValue.price);
        this.isCompleteOrder = ko.pureComputed(function () { return _this.orderId() && _this.name() && _this.price() > 0; });
        this.orders = OrderDataStore.instance.orders;
    }
    OrdersViewModel.prototype.save = function () {
        OrderDataStore.instance.orders.push({ orderId: this.orderId(), name: this.name(), price: this.price() });
        this.orderId(null);
        this.name(null);
        this.price(null);
    };
    return OrdersViewModel;
}());
var AppViewModel = (function () {
    function AppViewModel() {
        var _this = this;
        this.currentPanel = ko.observable(AppViewModel.PANEL_LOGIN);
        this.isLoginVisible = ko.pureComputed(function () { return _this.currentPanel() === AppViewModel.PANEL_LOGIN; });
        this.isRegisterVisible = ko.pureComputed(function () { return _this.currentPanel() === AppViewModel.PANEL_REGISTER; });
        this.isAccountSettingsVisible = ko.pureComputed(function () { return _this.currentPanel() === AppViewModel.PANEL_ACCOUNT_SETTINGS; });
        this.isOrdersVisible = ko.pureComputed(function () { return _this.currentPanel() === AppViewModel.PANEL_ORDERS; });
        this.registerVM = new RegistrationViewModel();
        this.registerErrorMessage = ko.observable(null);
        this.loginVM = new LoginViewModel();
        this.loginErrorMessage = ko.observable(null);
        this.accountSettingsVM = new AccountSettingsViewModel();
        this.ordersVM = new OrdersViewModel();
        this.currentUser = ko.observable(null);
    }
    AppViewModel.prototype.navLogin = function () {
        this.currentPanel(AppViewModel.PANEL_LOGIN);
    };
    AppViewModel.prototype.navRegister = function () {
        this.currentPanel(AppViewModel.PANEL_REGISTER);
    };
    AppViewModel.prototype.navAccountSettings = function () {
        this.currentPanel(AppViewModel.PANEL_ACCOUNT_SETTINGS);
    };
    AppViewModel.prototype.navOrders = function () {
        if (!this.currentUser())
            return;
        this.currentPanel(AppViewModel.PANEL_ORDERS);
    };
    AppViewModel.prototype.login = function () {
        this.loginErrorMessage(null);
        var user = this.loginVM.login();
        if (!user) {
            this.loginErrorMessage("Login failed.  Please try again.");
            return;
        }
        this.accountSettingsVM.loadSettings(user);
        this.currentUser(user);
        this.currentPanel(AppViewModel.PANEL_ACCOUNT_SETTINGS);
    };
    AppViewModel.prototype.register = function () {
        this.registerErrorMessage(null);
        var user;
        try {
            user = this.registerVM.register();
        }
        catch (e) {
            this.registerErrorMessage("Username already exists.  Please try a different one.");
            return;
        }
        this.accountSettingsVM.loadSettings(user);
        this.currentUser(user);
        this.currentPanel(AppViewModel.PANEL_ACCOUNT_SETTINGS);
    };
    AppViewModel.prototype.saveAccountSettings = function () {
        this.accountSettingsVM.save();
    };
    AppViewModel.PANEL_LOGIN = "Login";
    AppViewModel.PANEL_REGISTER = "Register";
    AppViewModel.PANEL_ACCOUNT_SETTINGS = "Account Settings";
    AppViewModel.PANEL_ORDERS = "Orders";
    return AppViewModel;
}());
var UserDataStore = (function () {
    function UserDataStore(users) {
        this.users = ko.observableArray(users);
    }
    UserDataStore.prototype.findByUsername = function (username) {
        if (!username) {
            throw 'Must specify username';
        }
        return this.users().filter(function (user) { return user.username === username; })[0];
    };
    UserDataStore.instance = new UserDataStore();
    return UserDataStore;
}());
var OrderDataStore = (function () {
    function OrderDataStore(orders) {
        this.orders = ko.observableArray(orders);
    }
    OrderDataStore.prototype.findByOrderId = function (orderId) {
        if (!orderId) {
            throw 'Must specify order id';
        }
        return this.orders().filter(function (order) { return order.orderId === orderId; })[0];
    };
    OrderDataStore.instance = new OrderDataStore();
    return OrderDataStore;
}());
