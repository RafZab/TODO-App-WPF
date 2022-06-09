using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using TodoApp.Models;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace TodoApp.Services
{
    public class DataProvider
    {
        private const string fileName = "data.json";

        private DataProvider()
        {
        }

        private static DataProvider _instance;

        public static DataProvider Instance => _instance ??= new DataProvider();

        public List<TaskGroup> LoadTaskGroups()
        {
            var json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<List<TaskGroup>>(json);
        }

        public void SaveTaskGroups(List<TaskGroup> taskGroups)
        {
            var json = JsonConvert.SerializeObject(taskGroups);
            File.WriteAllText(fileName, json);
        }
    }
}
