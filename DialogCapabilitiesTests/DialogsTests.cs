using DialogCapabilities.Dialogs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;

namespace DialogCapabilities.Tests
{
    /// <summary>
    /// Tests must be runned on English version of windows
    /// </summary>
    [TestClass()]
    public class DialogsTests
    {
        [TestMethod()]
        public void SaveFileDialogTest()
        {
            Process.Start("notepad.exe");

            var form = FormController
                .Catch("Untitled - Notepad")
                .SetForeground();

            form.CatchControl("Edit")
                .SendText("This is the new Text!!!");
            
            form.SetForeground().SendKeys("^s");//Ctrl + S

            DialogsEn.SaveFileDialog(@"d:\test.txt");

            Thread.Sleep(5000);

            form.CloseWindow();
        }

        //[TestMethod()]
        //public void SaveFileDialogFileOwerrideTest()
        //{
        //    Process.Start("notepad.exe");

        //    var form = FormController
        //        .Catch("Untitled - Notepad")
        //        .SetForeground();

        //    form.CatchControl("Edit")
        //        .SendText("--");

        //    form.SetForeground().SendKeys("^s");//Ctrl + S

        //    Dialogs.DialogsEn(@"d:\test.txt");

        //    Thread.Sleep(3000);

        //    DialogsEn.SaveFileDialogFileOwerride();

        //    Thread.Sleep(3000);

        //    form.CloseWindow();

        //    string contents = File.ReadAllText(@"d:\test.txt");

        //    Assert.AreEqual(contents, "--");
        //}


        [TestMethod()]
        public void OpenFileDialogTest()
        {
            Process.Start("notepad.exe");

            var form = FormController
                .Catch("Untitled - Notepad")
                .SetForeground();
            
            form.SetForeground().SendKeys("^o");//Ctrl + O
            
            Thread.Sleep(5000);
            
            DialogsEn.OpenFileDialog(@"d:\test.txt");
            
            Thread.Sleep(5000);

            form.CloseWindow();
        }

        
    }
}