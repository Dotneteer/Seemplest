﻿using System;
using System.Data;

namespace Seemplest.Core.DataAccess.DataServices
{
    /// <summary>
    /// This interface defines the operations available for a data access object
    /// </summary>
    public interface IDataAccessOperation : IDisposable
    {
        /// <summary>
        /// Sets the operation mode of the service object
        /// </summary>
        /// <param name="mode"></param>
        void SetOperationMode(SqlOperationMode mode);

        /// <summary>
        /// Starts a new transaction
        /// </summary>
        /// <param name="level">Transaction isolation level</param>
        void BeginTransaction(IsolationLevel? level = null);

        /// <summary>
        /// Aborts the current transaction
        /// </summary>
        void AbortTransaction();

        /// <summary>
        /// Sign the operation as ready to commit
        /// </summary>
        void Complete();
    }
}