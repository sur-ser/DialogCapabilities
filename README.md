# DialogCapabilities
DialogCapabilities is a library for work with OpenFileDialog and SaveFileDialog.

Main idea is simple: to give an ability to work with system dialogs like OpenFileDialog and SaveFileDialog for SeleniumWebDriver users. SeleniumWebDriver by default have no abbility to perform any actions with them as this dialogs is related to OS, but not browser-related.

_________________

# IMPORTANT
At the moment library works only with foreground dialogs. Background dialog windows supported only unofficially.

Also there can be mistakes in case of using few dialogs in the same time in one instance of OS. 

Maybe later I will add support of search dialogs related to exact window. Maybe not.


_________________
# Samples
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