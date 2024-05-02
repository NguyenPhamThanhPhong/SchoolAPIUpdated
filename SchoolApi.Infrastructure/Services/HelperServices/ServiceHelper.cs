using Microsoft.AspNetCore.Http;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.Services.AzureBlobServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Services.HelperServices
{
    public class ServiceHelper
    {
        private AzureBlobHandler _azureBlobHandler;
        public ServiceHelper(AzureBlobHandler azureBlobHandler)
        {
            _azureBlobHandler = azureBlobHandler;
        }
        public Dictionary<string,string> GenerateFileDictFromRequest(
            Dictionary<string,string> currentUrlsDict,IEnumerable<string> comingUrls,
            IEnumerable<IFormFile> files)
        {
            var keepfilesDict = new Dictionary<string, string>();
            var deleteTask = new List<Task<bool>>();
            if(comingUrls!=null)
            {
                foreach (var comingUrl in comingUrls)
                {
                    if (currentUrlsDict.ContainsKey(comingUrl))
                        keepfilesDict.Add(comingUrl, currentUrlsDict[comingUrl]);
                    else
                        deleteTask.Add(_azureBlobHandler.DeleteBlob(comingUrl));
                }
                if (deleteTask.Count > 0)
                    Task.WhenAll(deleteTask).Wait();
            }
            var comingFileDict = _azureBlobHandler.UploadMultipleBlobs(files).Result;
            return keepfilesDict.Concat(comingFileDict).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
