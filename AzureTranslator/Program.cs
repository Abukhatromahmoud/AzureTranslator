using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTranslator
{
    public class Program
    {
        static void Main(string[] args)
        {

            JsonGenerator jsonGenerator = new JsonGenerator();
            BlobManager blobManager = new BlobManager(Configuration.connectionString, Configuration.inputContainerName, Configuration.inputFilePath, Configuration.outputContainerName, Configuration.outputFilePath);
            Translator translator = new Translator(Configuration.endpoint, Configuration.route, Configuration.key, jsonGenerator);

            var subMenu = new ConsoleMenu(args, level: 1)
              .Add("Translate to English", async () => { await translator.Translate("en"); Console.ReadLine(); })
              .Add("Translate to German", async () => { await translator.Translate("de"); Console.ReadLine(); })
              .Add("Translate to Italian", async () => { await translator.Translate("it"); Console.ReadLine(); })
              .Add("Translate to French", async () => { await translator.Translate("fr"); Console.ReadLine(); })
              .Add("Translate to Spanish", async () => { await translator.Translate("es"); Console.ReadLine(); })
              .Add("Translate to Serbian", async () => { await translator.Translate("sr-Latn"); Console.ReadLine(); })
              .Add("Translate to Russian", async () => { await translator.Translate("ru"); Console.ReadLine(); })
              .Add("Translate to Hungarian", async () => { await translator.Translate("hu"); Console.ReadLine(); })
              .Add("Translate to Hindi", async () => { await translator.Translate("hi"); Console.ReadLine(); })
              .Add("Translate to Japanese", async () => { await translator.Translate("ja"); Console.ReadLine(); })
              .Add("Translate to Portuguese", async () => { await translator.Translate("pt"); Console.ReadLine(); })
              .Add("Translate to Turkish", async () => { await translator.Translate("tr"); Console.ReadLine(); })
              .Add("BACK", ConsoleMenu.Close)
              .Configure(config =>
              {
                  config.Selector = "--> ";
                  config.EnableFilter = true;
                  config.Title = "Translate Options";
                  config.SelectedItemBackgroundColor = ConsoleColor.Green;
              });

            var menu = new ConsoleMenu(args, level: 0)
              .Add("Upload files to blob", () => { blobManager.UploadToBlob(); Console.ReadLine(); })
              .Add("Translate files to", subMenu.Show)
              .Add("Download files from blob", () => { blobManager.DownloadFromBlob(); Console.ReadLine(); })
              .Add("Exit", () => Environment.Exit(0))
              .Configure(config =>
              {
                  config.Selector = "--> ";
                  config.Title = "Welcome to Microsoft Azure Translator";
                  config.SelectedItemBackgroundColor = ConsoleColor.Green;
                  config.EnableBreadcrumb = true;
              });

            menu.Show();



        }
    }
}