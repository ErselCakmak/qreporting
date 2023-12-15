
using System.Reflection;
using Microsoft.Extensions.Localization;

namespace qreporting.Services
{

    public class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer _localizer;
        private Dictionary<string, string> _allLocalizedValues;


        public LocalizationService(IStringLocalizerFactory factory, Type resourceType)
        {
            AssemblyName assemblyName = new(resourceType.GetTypeInfo().Assembly.FullName ?? string.Empty);
            _localizer = factory.Create(resourceType.Name, assemblyName.Name ?? string.Empty);
            _allLocalizedValues = GetAllLocalizedValues();
        }

        public Dictionary<string, string> GetAllLocalizedValues()
        {
            var localizedStrings = _localizer.GetAllStrings();
            _allLocalizedValues = localizedStrings.ToDictionary(item => item.Name, item => item.Value);
            return _allLocalizedValues;
        }

        public Dictionary<string, string> GetSubsetLocalizedValues(List<string> keys)
        {
            return keys.ToDictionary(key => key, key => GetLocalizedValue(key));
        }

        private string GetLocalizedValue(string key)
        {
            return _allLocalizedValues.TryGetValue(key, out string? value) ? value : key;
        }
    }
}

public interface ILocalizationService
{
    Dictionary<string, string> GetAllLocalizedValues();
    Dictionary<string, string> GetSubsetLocalizedValues(List<string> keys);
}