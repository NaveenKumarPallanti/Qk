using System.IO;
using NUnit.Framework;

namespace UnitTests
{
    [SetUpFixture]
    public class TestFixture
    {

        // Path to the Web Root
        public static string DataWebRootPath = "./wwwroot";

        // Path to the data folder for the content
        public static string DataContentRootPath = "./data/";

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {

            // Run this code once when the test harness starts up.

            // This will copy over the latest version of the database files

            // holds the data web path to reach the data folder
            var DataWebPath = "../../../../src/wwwroot/data";

            // holdes name of wwwroot folder
            var DataUTDirectory = "wwwroot";

            // holdes name of data folder
            var DataUTPath = DataUTDirectory + "/data";

            // Delete the Detination folder
            if (Directory.Exists(DataUTDirectory))
            {
                Directory.Delete(DataUTDirectory, true);
            }

            // Make the directory
            Directory.CreateDirectory(DataUTPath);

            // Copy over all data files
            var filePaths = Directory.GetFiles(DataWebPath);

            foreach (var filename in filePaths)
            {

                // Copy the file
                string OriginalFilePathName = filename.ToString();

                // Replace the path
                var newFilePathName = OriginalFilePathName.Replace(DataWebPath, DataUTPath);

                File.Copy(OriginalFilePathName, newFilePathName);
            }
        }

        // attribute to ensure this function is run after all other tests have been run
        [OneTimeTearDown]
        
        /// <summary>
        /// This test is run after all other tests
        /// </summary>
        public void RunAfterAnyTests()
        {
        }

    }

}