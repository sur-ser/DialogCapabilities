namespace DialogCapabilities
{
    public class DialogCommand
    {
        public string Command { get; private set; }

        public DialogCommand Text(string str)
        {
            Command += str;
            return this;
        }

        public DialogCommand Tab()
        {
            Command += "{TAB}";
            return this;
        }

        public DialogCommand Enter()
        {
            Command += "{ENTER}";
            return this;
        }

        public DialogCommand Down()
        {
            Command += "{DOWN}";
            return this;
        }

        public DialogCommand End()
        {
            Command += "{END}";
            return this;

        }

        public DialogCommand CtrlS()
        {
            Command += "{^S}";
            return this;
        }

        // all other needed commands here: 
        // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys?redirectedfrom=MSDN&view=netframework-4.7.2
    }
}
