# DialogCapabilities
DialogCapabilities is a library for work with OpenFileDialog and SaveFileDialog.

Main idea is simple: to give an ability to work with system dialogs like OpenFileDialog and SaveFileDialog for SeleniumWebDriver users. SeleniumWebDriver by default have no abbility to perform any actions with them as this dialogs is related to OS, but not browser-related.

_________________

# IMPORTANT 1: limits of lib
At the moment library works only with foreground dialogs. Background dialog windows supported only unofficially.

Also there can be mistakes in case of using few dialogs in the same time in one instance of OS. 

Maybe later I will add support of search dialogs related to exact window. Maybe not.

_________________

# IMPORTANT 2 : How to do not use this library

Even of this library is exist, prefer to use another ways if this is possible.
This library was created for situations when you have no ability to use another way for some reason or if you don't want to.

### Way 1: for visible file fields

**HTML**

    <input type="file" id="uploadhere" />

**Selenium Code**

    IWebElement element = driver.FindElement(By.Id("uploadhere"));
    element.SendKeys("C:\\Some_Folder\\MyFile.txt");

### Way 2: for invisible fields
If input field is invisible, need to make it visible:

	public void AttachFile(WebDriver driver, By locator, String file) {
	  WebElement input = driver.findElement(locator);
	  Unhide(driver, input);
	  input.sendKeys(file);
	}
	
	private void Unhide(WebDriver driver, WebElement element) {
	  String script = "arguments[0].style.opacity=1;"
		+ "arguments[0].style['transform']='translate(0px, 0px) scale(1)';"
		+ "arguments[0].style['MozTransform']='translate(0px, 0px) scale(1)';"
		+ "arguments[0].style['WebkitTransform']='translate(0px, 0px) scale(1)';"
		+ "arguments[0].style['msTransform']='translate(0px, 0px) scale(1)';"
		+ "arguments[0].style['OTransform']='translate(0px, 0px) scale(1)';"
		+ "return true;";
	  ((JavascriptExecutor) driver).executeScript(script, element);
	}
	
### Way 3: for any fields
Send Post request with files to the site. 

_________________

# Samples of using the Lib
Add to using block:

    using DialogCapabilities.Dialogs;

OpenFileDialog:

    // for English Windows
    DialogsEn.OpenFileDialog(@"d:\test.txt");

    //For windows with russian GUI
    Dialogs.OpenFileDialog("Открыть", @"d:\test.txt");
	
MultiFile selection in OpenFileDialog:

    var filePaths = new string[] {@"d:\test1.txt", @"d:\test2.txt", @"d:\test3.txt"};
	
    //Or for Eng windows:
    DialogsEn.OpenFileDialog(filePaths);
	
    //for russian language OS
    Dialogs.OpenFileDialog("Открыть", filePaths);
	
SaveFileDialog:

    //for eng language OS
    DialogsEn.SaveFileDialog(@"d:\test.txt");
	
    //for russian language OS
    Dialogs.SaveFileDialog("Сохранить как", @"d:\test.txt");

_________________
# Building of custom Dialogs:

    public void CustomSaveFileDialog(string title, string file)
    {
        var dialog = FormController.Catch(title);

        dialog
            .CatchControlByPath("Class1/Class2/Class3/Class4")
            .SendText(file);

        dialog
            .CatchControl("Class5")
            .SendClick();
	}
	
Path you can find using Spy++ utility built in into Visual Studio