// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.HDInsight.Job
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System;
    using Microsoft.Azure.HDInsight.Job.Models;
    using Microsoft.Rest.Azure;
    using System.Collections.Generic;

    /// <summary>
    /// Operations for managing jobs against HDInsight clusters.
    /// </summary>
    public partial interface IJobOperations
    {
        /// <summary>
        /// Submits a Hive job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. Hive job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        Task<AzureOperationResponse<JobSubmissionJsonResponse>> SubmitHiveJobWithHttpMessagesAsync(HiveJobSubmissionParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Submits a MapReduce job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. MapReduce job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        Task<AzureOperationResponse<JobSubmissionJsonResponse>> SubmitMapReduceJobWithHttpMessagesAsync(MapReduceJobSubmissionParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Submits a MapReduce streaming job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. MapReduce job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        Task<AzureOperationResponse<JobSubmissionJsonResponse>> SubmitMapReduceStreamingJobWithHttpMessagesAsync(MapReduceStreamingJobSubmissionParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Submits a Pig job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. Pig job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        Task<AzureOperationResponse<JobSubmissionJsonResponse>> SubmitPigJobWithHttpMessagesAsync(PigJobSubmissionParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Submits a Sqoop job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. Sqoop job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        Task<AzureOperationResponse<JobSubmissionJsonResponse>> SubmitSqoopJobWithHttpMessagesAsync(SqoopJobSubmissionParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the output from the execution of an individual jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="storageAccess">
        /// Required. The storage account object of type IStorageAccess.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// The output of an individual jobDetails by jobId.
        /// </returns>
        Task<Stream> GetJobOutputAsync(string jobId, IStorageAccess storageAccess, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the error logs from the execution of an individual jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="storageAccess">
        /// Required. The storage account object of type IStorageAccess.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// The error logs of an individual jobDetails by jobId.
        /// </returns>
        Task<Stream> GetJobErrorLogsAsync(string jobId, IStorageAccess storageAccess, CancellationToken cancellationToken);

        /// <summary>
        /// Wait for completion of a Job.
        /// </summary>
        /// <param name='jobId'>
        /// Required. The id of the job.
        /// </param>
        /// <param name='duration'>
        /// Optional. The maximum duration to wait for completion of job before returning to client. If not passed then wait till job is completed.
        /// </param>
        /// <param name='waitInterval'>
        /// Optional. The interval to poll for job status. The default value is set from DefaultPollInterval property of HDInsight job management client.
        /// </param>
        /// <exception cref="TimeoutException">
        /// Thrown when waiting for job completion exceeds the maximum duration specified by parameter duration.
        /// </exception>
        Task<AzureOperationResponse<JobDetailRootJsonObject>> WaitForJobCompletionWithHttpMessagesAsync(string jobId, TimeSpan? duration, TimeSpan? waitInterval);
    }
}
