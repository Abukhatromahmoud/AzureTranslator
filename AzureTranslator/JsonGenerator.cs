using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTranslator
{
    public class JsonGenerator
    {
        /*
         Json file contains all the information needed for translate operation to be completed
        inputs --> specify the url of input container of our blob
        targets --> specify the output blob container location on cloud
        storageSource --> specify what type of storage it is
        language --> it will be added depended on what language we want to translate our files to
            in inputs we leave it empty since the Translator can auto detect the language
            but in target we will specify what language we want it to be translated to.
         */

        /*
         SAS tolken could be found in Storage Explorer 
        Storage Accounts -> AccountName -> Blob Containers -> ContainerName
        Right click -> Get Shared Access Signature (SAS tolken)
        Edit:
        1) Duration of accesablity (start time, expiry time)
        2) Permisions
            2.1) For input we need LIST and READ checked
            2.2) For output we need LIST and WRITE/CREATE
        It will generate URL that will be used in json config file
         */
        private string json = ("" +
            "{\"inputs\": " +
                "[{\"source\": " +
                    "{\"sourceUrl\": \"https://mystorgeforcloudproject.blob.core.windows.net/inputdocuments?sp=rl&st=2023-05-02T20:02:52Z&se=2023-05-03T04:02:52Z&sv=2021-12-02&sr=c&sig=hKRn3JSyGvFTB%2BAGc5U8Y%2FF3bX%2F6lBJUKAWyjhC%2FOnY%3D\"," +
                      "\"storageSource\": \"AzureBlob\"" +
                "}," +
            "\"targets\": " +
                "[{\"targetUrl\": \"https://mystorgeforcloudproject.blob.core.windows.net/outputdocuments?sp=cwl&st=2023-05-02T20:11:13Z&se=2023-05-03T04:11:13Z&sv=2021-12-02&sr=c&sig=lL2RGPAoYVqev8arbUaOF3nvCNMSHZE4TEnMDjCrfZY%3D\"," +
                   "\"storageSource\": \"AzureBlob\",");



        public string GenerateJsonString(string language)
        {
            switch (language)
            {
                // language codes can be found on
                // https://docs.microsoft.com/en-us/azure/cognitive-services/translator/language-support

                case "en": return json + "\"language\": \"en\"}]}]}"; break;
                case "de": return json + "\"language\": \"de\"}]}]}"; break;
                case "it": return json + "\"language\": \"it\"}]}]}"; break;
                case "fr": return json + "\"language\": \"fr\"}]}]}"; break;
                case "es": return json + "\"language\": \"es\"}]}]}"; break;
                case "sr ": return json + "\"language\": \"sr-Latn\"}]}]}"; break;
                case "ru": return json + "\"language\": \"ru\"}]}]}"; break;
                case "hu": return json + "\"language\": \"hu\"}]}]}"; break;
                case "hi": return json + "\"language\": \"hi\"}]}]}"; break;
                case "ja": return json + "\"language\": \"ja\"}]}]}"; break;
                case "pt ": return json + "\"language\": \"pt\"}]}]}"; break;
                case "tr": return json + "\"language\": \"tr\"}]}]}"; break;

                default:
                    return json + "\"language\": \"en\"}]}]}";
                    break;
            }
        }
    }
}
