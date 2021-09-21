using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSubmission.Controllers
{
    [Route("applicationsubmission/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        Amazon.S3.IAmazonS3 client { get; set; }
        string bucketName { get; set; }

        public DocumentController()
        {
            client = new AmazonS3Client(Amazon.RegionEndpoint.APSouth1);
            bucketName = "pbloandocuments";
        }

        // GET: applicationsubmission/Document/5
        [HttpGet("{loanid}")]
        public async Task<Stream> Get(int loanid, string filename)
        {
            GetObjectResponse response = new GetObjectResponse();
            var request = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = loanid.ToString() + "/" + filename
            };
            response = await client.GetObjectAsync(request);

            return response.ResponseStream;
        }

        public async Task<string> ReadFormFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return await Task.FromResult((string)null);
            }

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                return await reader.ReadToEndAsync();
            }
        }

        private async Task<System.Net.HttpStatusCode> PutFileOnBucket(int loanid, IFormFile[] myfile)
        {
            PutObjectResponse response = null;
            foreach (IFormFile file in myfile)
            {
                string content = await ReadFormFileAsync(file);
                if (content == null)
                    return System.Net.HttpStatusCode.BadRequest;

                response = new PutObjectResponse();
                var request = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = loanid.ToString() + "/" + file.FileName,
                    ContentBody = content
                };
                response = await client.PutObjectAsync(request);
            }
            //Send the correct response return for each file.
            return response.HttpStatusCode;
        }

        // POST: applicationsubmission/Document
        [HttpPost("{loanid}")]
        public async Task<System.Net.HttpStatusCode> Post(int loanid, IFormFile[] myfile)
        {
            return await PutFileOnBucket(loanid, myfile);
        }

        // PUT: applicationsubmission/Document/5
        [HttpPut("{loanid}")]
        public async Task<System.Net.HttpStatusCode> Put(int loanid, IFormFile[] myfile)
        {
            return await PutFileOnBucket(loanid, myfile);
        }

        // DELETE: applicationsubmission/ApiWithActions/5
        [HttpDelete("{loanid}")]
        public async Task<System.Net.HttpStatusCode> Delete(int loanid, string filename)
        {
            DeleteObjectResponse response = new DeleteObjectResponse();
            DeleteObjectRequest request = new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = loanid.ToString() + "/" + filename
            };

            // Issue request
            response = await client.DeleteObjectAsync(request);
            return response.HttpStatusCode;
        }
    }
}
