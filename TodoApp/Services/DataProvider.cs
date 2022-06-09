using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TodoApp.Models;

namespace TodoApp.Services
{
    public class DataProvider
    {
        private const string fileName = "data.json";
        private const string settingsFileName = "settings.json";

        private DataProvider()
        {
        }

        private static DataProvider _instance;

        public static DataProvider Instance => _instance ??= new DataProvider();

        public List<TaskGroup> LoadTaskGroups()
        {
            try
            {
                var json = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<List<TaskGroup>>(json);
            }
            catch
            {
                return null; //dont to that kids, wiem ze tak nie mozna ale malo czasi
            }
            
        }

        public void SaveTaskGroups(List<TaskGroup> taskGroups)
        {
            var json = JsonConvert.SerializeObject(taskGroups);
            File.WriteAllText(fileName, json);
        }

        public AppSettings LoadAppSettings()
        {
            try
            {
                var json = File.ReadAllText(settingsFileName);
                return JsonConvert.DeserializeObject<AppSettings>(json);
            }
            catch
            {
                return null;
            }
        }

        public void SaveAppSettings(AppSettings settings)
        {
            var json = JsonConvert.SerializeObject(settings);
            File.WriteAllText(settingsFileName, json);
        }
    }
}
