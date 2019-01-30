namespace DialogCapabilities
{
    public static class Dialogs
    {
        private static string _fileNameFldName = "ComboBoxEx32";
        private static string _okBtnName = "Button";

        public static bool OpenFileDialog(string title, string file)
        {
            var opnFileDialog = BaseDialog.Catch(title);
            
            var fileNameFld = BaseDialog.CatchControlIn(opnFileDialog, _fileNameFldName);
            BaseDialog.SendText(fileNameFld, file);

            var okBtn = BaseDialog.CatchControlIn(opnFileDialog, _okBtnName);
            
            BaseDialog.SendClick(okBtn);

            return true;
        }

        public static bool OpenFileDialog(string title, string[] files)
        {
            string filesStr = "\"" + string.Join("\" \"", files) + "\"";
            
            return OpenFileDialog(title, filesStr);
        }
    }
}
