using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestDropboxApi.Helpers
{
    public static class ContextHelper
    {
        public static void AddToContext<T>(string key, T value, bool overwrite = true)
        {
            if (!ScenarioContext.Current.ContainsKey(key))
                ScenarioContext.Current.Add(key, value);
            else if (overwrite)
            {
                ScenarioContext.Current[key] = value;
            }
        }

        public static T GetFromContext<T>(string key)
        {
            if (ScenarioContext.Current.ContainsKey(key))
                return ScenarioContext.Current.Get<T>(key);
            throw new KeyNotFoundException($"Given key {key} was not found in Scenario Context");
        }
    }
}
