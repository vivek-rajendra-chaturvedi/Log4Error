using System.Configuration;

namespace Log4Error.Configuration
{
    class AssemblyElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = false, IsRequired = true)]
        public string AssemblyName
        {
            get
            {
                return (string) this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }
    }
}