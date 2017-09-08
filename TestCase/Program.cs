﻿using System;
using System.IO;
using Amazon.S3;
using Amazon.S3.Model;

namespace TestCase
{
    class GetObject
    {
        static string bucketName = "doc-store-documents";
        static string keyName = "Document1.docx";
        static IAmazonS3 client;
 
    

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Retrieving (GET) an object");
                string data = ReadObjectData();
            }
            catch (AmazonS3Exception s3Exception)
            {
                Console.WriteLine(s3Exception.Message,
                                  s3Exception.InnerException);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static string ReadObjectData()
        {
            string responseBody = "";

             using (client = new AmazonS3Client(Amazon.RegionEndpoint.USWest2))
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName
                };

                using (GetObjectResponse response = client.GetObject(request))
                using (Stream responseStream = response.ResponseStream)
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    string title = response.Metadata["x-amz-meta-title"];
                    Console.WriteLine("The object's title is {0}", title);

                    responseBody = reader.ReadToEnd();
                }
            }
            return responseBody;
        }
    }
}
