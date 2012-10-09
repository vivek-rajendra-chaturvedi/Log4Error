using System.Configuration;

namespace Log4Error.Configuration
{
    class Log4ErrorSection : ConfigurationSection
    {
        [ConfigurationProperty("Assemblies", IsDefaultCollection = true, IsKey = false, IsRequired = false)]
        public AssembliesCollection Assemblies
        {
            get
            {
                return (AssembliesCollection)this["Assemblies"];
            }
            set
            {
                this["Assemblies"] = value;
            }
        }
    }
}