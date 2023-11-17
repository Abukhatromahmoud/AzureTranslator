using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTranslator
{
    public class Configuration
    {
        // because we want to translate all the files from blob
        static public readonly string route = "/batches";

        // endpoint url will be found in azure. Translator endpoint(2 ver, string or document based) + translator/text/batch/v1.0
        // Home -> ResourceName(TranlatorName) -> Keys and Endpoint -> Web API -> Document Tranlation endpoint 
        static public readonly string endpoint = $"https://translatorforcloudproject2.cognitiveservices.azure.com/translator/text/batch/v1.0";

        // Home -> ResourceName(TranlatorName) -> Keys and Endpoint -> KEY 1 -> copy key
        // one of translators keys -> key1
        static public readonly string key = "263c4f5c21dd480ba8dc3953d37e757e";

        // Storage Accounts -> AccountName -> Security + networking -> Access keys -> key1 -> copy connection string 
        static public readonly string connectionString = "DefaultEndpointsProtocol=https;AccountName=mystorgeforcloudproject;AccountKey=HiwugOB3lCi8Ieilk7WsQWT34ywGlJgwAp2UXOll1uhtzwoANnf+xs+smarTFYLdBu5sUXO7aH7b+ASt9n71uQ==;EndpointSuffix=core.windows.net";

        // Storage Accounts -> AccountName -> Blob Containers -> ContainerName -> copy name of desired container
        static public readonly string inputContainerName = "inputdocuments";
        static public readonly string outputContainerName = "outputdocuments";

        // desired locations on your system where we want to store the files
        // consider placing it on specily locations for easier naviagation and redistribution of program accross different PCs
        static public readonly string inputFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\input\";
        static public readonly string outputFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\output\";
        //static public readonly string inputFilePath = @"C:\Users\capet\Documents\input";
        //static public readonly string outputFilePath = @"C:\Users\capet\Documents\output";
    }
}
