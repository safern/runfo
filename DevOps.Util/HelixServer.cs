﻿using Microsoft.DotNet.Helix.Client;
using Microsoft.DotNet.Helix.Client.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Util
{
    public class HelixServer : BaseServer
    {
        public HelixServer() : base() { }

        private IHelixApi HelixApi { get; } = ApiFactory.GetAnonymous();

        public async ValueTask GetHelixPayloads(string jobId, List<string> workItems, string downloadDir)
        {
            if (!Path.IsPathFullyQualified(downloadDir))
            {
                downloadDir = Path.Combine(Environment.CurrentDirectory, downloadDir);
            }

            JobDetails jobDetails = await HelixApi.Job.DetailsAsync(jobId).ConfigureAwait(false);
            string? jobListFile = jobDetails.JobList;

            if (string.IsNullOrEmpty(jobListFile))
            {
                Console.WriteLine($"Couldn't find job list for job {jobId}");
                return;
            }

            using MemoryStream memoryStream = await DownloadFileAsync(jobListFile).ConfigureAwait(false);
            using StreamReader reader = new StreamReader(memoryStream);
            string jobListJson = await reader.ReadToEndAsync().ConfigureAwait(false);

            WorkItemInfo[] workItemsInfo = JsonConvert.DeserializeObject<WorkItemInfo[]>(jobListJson);

            if (workItemsInfo.Length > 0)
            {
                Directory.CreateDirectory(downloadDir);
                string correlationDir = Path.Combine(downloadDir, "correlation-payload");
                Directory.CreateDirectory(correlationDir);

                // download correlation payload
                JObject correlationPayload = workItemsInfo[0].CorrelationPayloadUrisWithDestinations ?? new JObject();
                foreach (JProperty property in correlationPayload.Children())
                {
                    string url = property.Name;
                    Uri uri = new Uri(url);
                    string fileName = uri.Segments[^1];
                    string destinationFile = Path.Combine(correlationDir, fileName);
                    Console.WriteLine($"Payload {fileName} => {destinationFile}");
                    await DownloadZipFileAsync(url, destinationFile).ConfigureAwait(false);
                }

                if (workItems.Count > 0)
                {
                    string workItemsDir = Path.Combine(downloadDir, "workitems");
                    Directory.CreateDirectory(workItemsDir);
                    bool downloadAll = false;

                    if (workItems[0] == "all")
                    {
                        downloadAll = true;
                    }

                    foreach (WorkItemInfo workItemInfo in workItemsInfo)
                    {
                        if (!downloadAll && !workItems.Contains(workItemInfo.WorkItemId ?? string.Empty))
                            continue;

                        if (string.IsNullOrEmpty(workItemInfo.PayloadUri))
                            continue;

                        string fileName = Path.Combine(workItemsDir, $"{workItemInfo.WorkItemId}.zip");

                        Console.WriteLine($"WorkItem {workItemInfo.WorkItemId} => {fileName}");

                        await DownloadZipFileAsync(workItemInfo.PayloadUri, fileName).ConfigureAwait(false);
                    }
                }
                else
                {
                    Console.WriteLine("No workitems specified");
                }
            }
        }

        private class WorkItemInfo
        {
            public JObject? CorrelationPayloadUrisWithDestinations { get; set; }
            public string? PayloadUri { get; set; }
            public string? WorkItemId { get; set; }
        }
    }
}
