using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MahApps.Metro.netcoreapp30
{
    public static class AssemblyExtensions
    {
        public static string GetManifestResourceName(this Assembly assembly, string fileName)
        {
            string name = assembly.GetManifestResourceNames().SingleOrDefault(n => n.EndsWith(fileName, StringComparison.InvariantCultureIgnoreCase));

            if (string.IsNullOrEmpty(name))
            {
                throw new FileNotFoundException($"Embedded file '{fileName}' could not be found in assembly '{assembly.FullName}'.", fileName);
            }

            return name;
        }
    }

    public class AssemblyTextFileReader
    {
        private readonly Assembly _assembly;

        public AssemblyTextFileReader(Assembly assembly)
        {
            _assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
        }

        public async Task<string> ReadFileAsync(string fileName)
        {
            var resourceName = _assembly.GetManifestResourceName(fileName);

            using (var stream = _assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
    }
}