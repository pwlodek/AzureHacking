using System;

namespace StorageDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new GettingStartedQueues();
            //demo.RunQueueStorageOperationsAsync();
            //StorageBlobDemo.CallBlobGettingStartedSamples();
            StorageTableDemo.RunSamples();
            Console.WriteLine("End demo.");
            Console.ReadKey();
        }
    }
}
