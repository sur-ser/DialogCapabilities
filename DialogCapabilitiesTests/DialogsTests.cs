using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace DialogCapabilities.Tests
{
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


            form.SetForeground().SendKeys("^s");

            Dialogs.SaveFileDialog("Save As", @"d:\test.txt");

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

        //    form.SetForeground().SendKeys("^s");

        //    Dialogs.SaveFileDialog("Save As", @"d:\test.txt");

        //    Thread.Sleep(3000);

        //    Dialogs.SaveFileDialogFileOwerride("Save As", true);

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
            
            form.SetForeground().SendKeys("^o");
            
            Thread.Sleep(5000);
            
            Dialogs.OpenFileDialog("Open", @"d:\test.txt");
            
            Thread.Sleep(5000);

            form.CloseWindow();
        }

        
    }
}