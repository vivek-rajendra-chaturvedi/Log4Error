using System.Configuration;

namespace Log4Error.Configuration
{
    class AssembliesCollection : ConfigurationElementCollection
    {
        protected override string ElementName { get { return "Assembly"; } }

        protected override ConfigurationElement CreateNewElement()
        {
            return new AssemblyElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return element.GetHashCode();
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }
    }
}