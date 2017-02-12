using Newtonsoft.Json;
using System.IO;

namespace RustNotifierBot.Configuration
{
    public class Configuration
    {
        public ulong[] Owners { get; set; }
        public string Token { get; set; }
        public string BotName { get; set; }

        public Configuration()
        {
            Owners = new ulong[] {};
            Token = "";
            BotName = "RustNotifierBot";
        }

        public string getBotName()
        {
            return BotName;
        }

        /// <summary> Save the configuration to the specified file location. </summary>
        public void Save(string dir = "data/configuration.json")
        {
            File.WriteAllText(dir, ToJson());
        }

        /// <summary> Load the configuration from the specified file location. </summary>
        public static Configuration Load(string dir = "data/configuration.json")
            => JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(dir));

        /// <summary> Convert the configuration to a json string. </summary>
        public string ToJson()
            => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}