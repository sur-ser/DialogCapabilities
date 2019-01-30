using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogCapabilities
{
    public class DialogCapabilitiesException:Exception
    {
        public DialogCapabilitiesException(string details)
            : base(details){}
    }

    public class ProcessNotFoundException : DialogCapabilitiesException
    {
        public ProcessNotFoundException(string processTitle, int timeOutMs)
            : base($"Process cannot be found by title: {processTitle} by timeout {timeOutMs} ms")
        {}
    }

    public class ControlNotFoundException : DialogCapabilitiesException
    {
        public ControlNotFoundException(string elemName, int timeOutMs)
            : base($"Control {elemName} didn't found in proper time {timeOutMs} ms")
        { }
    }
}
