using System;
using System.Threading;
using Seemplest.Core.Configuration;
using Seemplest.Core.ServiceObjects;

namespace Seemplest.Core.Tracing
{
    /// <summary>
    /// This interface defines the information describing a trace log item in regard
    /// of a business operation.
    /// </summary>
    public class TraceLogItem: IOperationData
    {
        /// <summary>
        /// UTC timestamp information of the operation
        /// </summary>
        /// <remarks>TraceFormatter token: {ts}</remarks>
        public DateTime? TimestampUtc { get; set; }

        /// <summary>
        /// Optional session ID of the operation
        /// </summary>
        /// <remarks>TraceFormatter token: {s}</remarks>
        public string SessionId { get; set; }

        /// <summary>
        /// Optional business transaction ID of the operation
        /// </summary>
        /// <remarks>TraceFormatter token: {b}</remarks>
        public string BusinessTransactionId { get; set; }

        /// <summary>
        /// Gets the ID of the operation instance
        /// </summary>
        /// <remarks>TraceFormatter token: {oi}</remarks>
        public string OperationInstanceId { get; set; }

        /// <summary>
        /// Gets the type of the operation
        /// </summary>
        /// <remarks>TraceFormatter token: {ot}</remarks>
        public string OperationType { get; set; }

        /// <summary>Gets or sets the ID of the tenant</summary>
        /// <remarks>TraceFormatter token: {ti}</remarks>
        public string TenantId { get; set; }

        /// <summary>Gets or sets the message of the entry</summary>
        /// <remarks>TraceFormatter token: {m}</remarks>
        public string Message { get; set; }

        /// <summary>Gets or sets the message related data of the entry</summary>
        /// <remarks>TraceFormatter token: {d}</remarks>
        public string DetailedMessage { get; set; }

        /// <summary>Gets or sets the type of the message</summary>
        /// <remarks>TraceFormatter token: {it}</remarks>
        public TraceLogItemType Type { get; set; }

        /// <summary>Gets or sets the optional server name</summary>
        /// <remarks>TraceFormatter token: {sn}</remarks>
        public string ServerName { get; set; }

        /// <summary>Gets or sets the Id of the thread raising the message</summary>
        /// <remarks>TraceFormatter token: {th}</remarks>
        public int? ThreadId { get; set; }

        /// <summary>
        /// Fills up properties that are not defined explicitly.
        /// </summary>
        public void EnsureProperties()
        {
            // --- Provide a timestamp
            if (!TimestampUtc.HasValue)
            {
                TimestampUtc = EnvironmentInfo.GetCurrentDateTimeUtc().ToLocalTime();
            }

            // --- Provide session ID from the current call context
            if (SessionId == null)
            {
                var contextItem = ServiceCallContext.Current.Get<SessionIdlContextItem>();
                if (contextItem != null) SessionId = contextItem.Value;
            }

            // --- Provide business transaction ID from the current call context
            if (BusinessTransactionId == null)
            {
                var contextItem = ServiceCallContext.Current.Get<BusinessTransactionIdContextItem>();
                if (contextItem != null) BusinessTransactionId = contextItem.Value;
            }

            // --- Provide operation instance ID from the current call context
            if (OperationInstanceId == null)
            {
                var contextItem = ServiceCallContext.Current.Get<OperationInstanceIdContextItem>();
                if (contextItem != null) OperationInstanceId = contextItem.Value;
            }

            // --- Provide tenant ID from the current call context
            if (TenantId == null)
            {
                var contextItem = ServiceCallContext.Current.Get<TenantIdContextItem>();
                if (contextItem != null) TenantId = contextItem.Value;
            }

            // --- Provide the current machine's name as server name
            if (ServerName == null)
            {
                ServerName = EnvironmentInfo.GetMachineName();
            }

            // --- Provide thread information
            if (!ThreadId.HasValue)
            {
                ThreadId = Thread.CurrentThread.ManagedThreadId;
            }
        }
    }
}