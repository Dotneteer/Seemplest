﻿namespace Seemplest.Core.ServiceObjects
{
    /// <summary>
    /// This class defines a context item that stores the session ID
    /// </summary>
    public class SessionIdlContextItem : ServiceCallContextItemBase<string>
    {
        /// <summary>
        /// Initializes the value of this context item
        /// </summary>
        /// <param name="itemValue">ID of the tenant</param>
        public SessionIdlContextItem(string itemValue)
            : base(itemValue)
        {
        }
    }
}