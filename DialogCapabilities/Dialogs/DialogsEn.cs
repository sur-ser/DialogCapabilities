namespace DialogCapabilities.Dialogs
{
    public static class DialogsEn
    {
        public static void OpenFileDialog(string file)=>
            Dialogs.OpenFileDialog("Open", file);

        public static void OpenFileDialog(string[] files)=>
            Dialogs.OpenFileDialog("Open", files);

        public static void SaveFileDialog(string file) =>
            Dialogs.SaveFileDialog("Save As", file);

        public static void SaveFileDialogFileOwerride(bool rejectOverride = false) =>
            Dialogs.SaveFileDialogFileOwerride("File owerride", rejectOverride);

    }
}
