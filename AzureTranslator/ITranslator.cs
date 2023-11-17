using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTranslator
{
    public interface ITranslator
    {
        public Task Translate(string lang);
    }
}
