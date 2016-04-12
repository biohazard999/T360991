using System;

namespace Para.ExpressApp.CommandLineLauncher.Win.Domain
{
    /// <summary>
    ///     Holds a list of arguments given to an application at startup.
    /// </summary>
    public class ArgumentsReceivedEventArgs : EventArgs
    {
        public string[] Args { get; set; }
    }
}