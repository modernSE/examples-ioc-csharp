using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using DIContainer.Interfaces;
using Newtonsoft.Json;

namespace DIContainer
{
    class Serializer : ISerializer
    {

        public string serialize(IDocument document, ReturnTypes type)
        {
            switch (type)
            {
                case ReturnTypes.JSON:
                    return JsonConvert.SerializeObject(document.getContentDictionary());
                case ReturnTypes.XML:
                    var el = new XElement("root", document.getContentDictionary().Select(content => new XElement(content.Key.ToString(CultureInfo.InvariantCulture), content.Value)));
                    return el.ToString();
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

    }
}
