using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTranslator
{
    public interface IBlobManager
    {
        public void UploadToBlob();
        public void DownloadFromBlob();
    }
}
