using System;
using System.IO;
using System.Threading.Tasks;

namespace DialogCapabilities
{
    public static class Dialogs
    {
        public static bool OpenFileDialog(string title, string file)
        {
            var opnFileDialog = FormController.Catch(title);
            
            opnFileDialog
                .CatchControl("ComboBoxEx32")
                .SendText(file);

            opnFileDialog
                .CatchControl("Button")
                .SendClick();

            return true;
        }

        public static bool OpenFileDialog(string title, string[] files)
        {
            string filesStr = "\"" + string.Join("\" \"", files) + "\"";
            
            return OpenFileDialog(title, filesStr);
        }
        
        public static void SaveFileDialog(string title, string file)
        {
            var opnFileDialog = FormController.Catch(title);

            opnFileDialog
                .CatchControlByPath("DUIViewWndClassName/DirectUIHWND/FloatNotifySink/ComboBox")
                .SendText(file);

            opnFileDialog
                .CatchControl("Button")
                .SendClick();
        }

        public static void SaveFileDialogFileOwerride(string title, bool confirmOwerride)
        {
            var fileOwerride = FormController.Catch(title);

            //owerride file logic
        }
    }
}
