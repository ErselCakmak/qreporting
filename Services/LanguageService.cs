using System.Reflection;
using Microsoft.Extensions.Localization;

namespace qreporting.Services
{
	
	public class LanguageService
	{
		private readonly IStringLocalizer _localizer;
        private Dictionary<string, string> _allLocalizedValues;

        public LanguageService(IStringLocalizerFactory factory)
		{
            Type type = typeof(SharedResource);
            
            AssemblyName assemblyName = new(type.GetTypeInfo().Assembly.FullName ?? string.Empty);
            _localizer = factory.Create(
                nameof(SharedResource),
                assemblyName.Name ?? string.Empty);

            _allLocalizedValues = GetAllLocalizedValues();
        }

        public Dictionary<string, string> GetAllLocalizedValues()
        {
            _allLocalizedValues = _localizer.GetAllStrings().ToDictionary(item => item.Name, item => item.Value);
            return _allLocalizedValues;
        }

        public Dictionary<string, string> GetSubsetLocalizedValues(params string[] keys)
        {
            return keys.ToDictionary(key => key, key => _allLocalizedValues.TryGetValue(key, out string? value) ? value : key);
        }
    }
}

