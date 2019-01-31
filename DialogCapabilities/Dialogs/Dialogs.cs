namespace DialogCapabilities.Dialogs
{
    public static class Dialogs
    {
        public static void OpenFileDialog(string title, string file)
        {
            var opnFileDialog = FormController.Catch(title);
            
            opnFileDialog
                .CatchControl("ComboBoxEx32")
                .SendText(file);

            opnFileDialog
                .CatchControl("Button")
                .SendClick();
        }

        public static void OpenFileDialog(string title, string[] files)
        {
            string filesStr = "\"" + string.Join("\" \"", files) + "\"";
            
            OpenFileDialog(title, filesStr);
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

        public static void SaveFileDialogFileOwerride(string title, bool rejectOverride = false)
        {
            var fileOwerride = FormController.Catch(title);
            
            //"DirectUIHWND/CtrlNotifySink/Button";

            //owerride file logic
        }
    }
}
