using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Log4Error.Configuration;

namespace Log4Error.Utils
{
    class Log4ErrorConfigSectionReader
    {
        public static List<string> GetDllList()
        {
            var log4ErrorSection = ConfigurationManager.GetSection("Log4Error") as Log4ErrorSection;

            if(log4ErrorSection == null || log4ErrorSection.Assemblies == null)
                return new List<string>();

            return (from AssemblyElement assembly in log4ErrorSection.Assemblies select assembly.AssemblyName).ToList();
        }
    }
}
