# CodedUIFluentExtensions

Coded UI Fluent Extensions consists of three parts:

**Coded UI Fluent**

A set of extensions methods to improve readability and consistency of searching for controls in your UI.  There are also several additional UI Test Control implementations for common control types include HTML5 tags, outlook email windows, and IE security warnings.  This project only extends the core Coded UI framework and does not introduct any new classes to code against.

Turn this:

    [TestInitialize]
    public void NavigateToSimpleHtmlControlExamplesPage()
    {
	    this.window = BrowserWindow.Launch("http://codeduiexamples/Examples/Example1");
    }
    [TestMethod]
    public void ManipulateTextInput()
    {
        HtmlDiv bodyContainerDiv = new HtmlDiv(this.window);
        bodyContainerDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "layoutBodyContainer");
    
        // no fieldset available
        HtmlControl fieldset = new HtmlCustom(bodyContainerDiv);
        fieldset.SearchProperties.Add(HtmlControl.PropertyNames.TagName, "fieldset");
    
        Assert.IsTrue(fieldset.TryFind());
    
        HtmlEdit userNameEdit = new HtmlEdit(fieldset);
        userNameEdit.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "usernameInput");
    
        Assert.IsTrue(string.IsNullOrWhiteSpace(userNameEdit.Text));
        userNameEdit.Text = "MyUserName";
        Assert.IsTrue(StringComparer.Ordinal.Equals(userNameEdit.Text, "MyUserName"));
    }

into this

    [TestInitialize]
    public void NavigateToSimpleHtmlControlExamplesPage()
    {
         this.window = BrowserWindow.Launch("http://codeduiexamples/Examples/Example1");
    }
    [TestMethod]
    public void ManipulateTextInput()
    {
	    var usernameEdit =
          this.window.Find<HtmlDiv>("layoutBodyContainer")
				      .Find<HtmlFieldset>()
				      .Find<HtmlEdit>("usernameInput");
			
	    Assert.IsTrue(string.IsNullOrWhiteSpace(usernameEdit.Text));
	    usernameEdit.Text = "MyUserName";
	    Assert.IsTrue(StringComparer.Ordinal.Equals(usernameEdit.Text, "MyUserName"));
    }


**Page Modeling Abstraction**

Set of platform independent interfaces to describe your UI and allow for a test driven approach to UI development.  Using abstractions like IReadWriteValuePageModel<T> for inputs which can read and write some T, you decouple your tests for testing HtmlEdit directly.  This makes your tests more robust for when that HtmlEdit changes to a table cell that requires you to first click the cell to revel the some other input.  Simply change the implementation of the test (which would have to change anyway).  This also allows you to use whatever testing framework you would like to implement the models (eg, Selenium).

**Coded UI Implementation of Page Modeling Abstraction**

An implementation of the Page Modeling Abstraction using Coded UI.  This implementation includes a complete set of extensions that convert default controls into their standard page model equivalents.

Turn this:

    [TestInitialize]
    public void NavigateToSimpleHtmlControlExamplesPage()
    {
	    this.window = BrowserWindow.Launch("http://codeduiexamples/Examples/Example1");
    }
    [TestMethod]
    public void ManipulateTextInput()
    {
        HtmlDiv bodyContainerDiv = new HtmlDiv(this.window);
        bodyContainerDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "layoutBodyContainer");
    
        // no fieldset available
        HtmlControl fieldset = new HtmlCustom(bodyContainerDiv);
        fieldset.SearchProperties.Add(HtmlControl.PropertyNames.TagName, "fieldset");
    
        Assert.IsTrue(fieldset.TryFind());
    
        HtmlEdit userNameEdit = new HtmlEdit(fieldset);
        userNameEdit.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "usernameInput");
    
        Assert.IsTrue(string.IsNullOrWhiteSpace(userNameEdit.Text));
        userNameEdit.Text = "MyUserName";
        Assert.IsTrue(StringComparer.Ordinal.Equals(userNameEdit.Text, "MyUserName"));
    }

into this:

    private ISimpleHtmlControlsPageModel model;
    [TestInitialize]
    public void NavigateToSimpleHtmlControlExamplesPage()
    {
	    //BrowserWindow.CurrentBrowser = "Chrome";
	    this.model = new SimpleHtmlControlsPageModel(BrowserWindow.Launch("http://codeduiexamples/Examples/Example1"));
    }
    [TestMethod]
    public void ManipulateTextInput()
    {
	    Assert.IsTrue(String.IsNullOrWhiteSpace(model.UserName.Value));
	    model.UserName.SetValue("MyUserName");
	    Assert.IsTrue(StringComparer.Ordinal.Equals(model.UserName.Value, "MyUserName"))
    }

----------

If you run into issues where dependent assemblies cannot be found, add a binding redirect to your app.config file.  I use this with Visual Studio 2017 15.5.6.

    <runtime>
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
        <dependentAssembly>
          <assemblyIdentity name="Microsoft.VisualStudio.TestTools.UITest.Extension" publicKeyToken="b03f5f7f11d50a3a" culture="neutral" />
          <bindingRedirect oldVersion="1.0.0.0-15.0.0.0" newVersion="15.0.0.0" />
        </dependentAssembly>
      </assemblyBinding>
  </runtime>
