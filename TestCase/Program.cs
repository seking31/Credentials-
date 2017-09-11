using System;
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

            using (client = new AmazonS3Client(Amazon.RegionEndpoint.USWest2))
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName
                };

                using (GetObjectResponse response = client.GetObject(request))
                {
                    Console.WriteLine(response);
                   
                }
            }
            Console.WriteLine(client);
            Console.ReadLine();
        }
    }
}
