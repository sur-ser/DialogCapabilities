using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogCapabilities
{
    public static class OpenFileDialog
    {
        public static bool SetValues(string Title, string filePath, string[] fileNames)
        {
            var intPtr = BaseDialog.Catch(Title);

            var command = new DialogCommand().Tab().Text("someString").Tab().Enter();

            return BaseDialog.PerformAction(intPtr, command);
        }
    }
}
