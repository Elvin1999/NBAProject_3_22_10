using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAProject.Helpers
{
    public class JsonHelper<T> where T : class
    {
        public static Task SerializeAsync(object values,string filename)
        {
            return Task.Run(() => {
                var serializer = new JsonSerializer();
                using (var sw=new StreamWriter(filename))
                {
                    using (var jw=new JsonTextWriter(sw))
                    {
                        jw.Formatting = Formatting.Indented;
                        serializer.Serialize(jw, values);
                    }
                }
            });
        }

        public static Task<T> DeserializeAsync(string filename)
        {
            return Task.Run(() =>
            {
                var serializer=new JsonSerializer();
                using (var sr=new StreamReader(filename))
                {
                    using (var jr=new JsonTextReader(sr))
                    {
                        return serializer.Deserialize<T>(jr);
                    }
                }
            });
        }
    }


}
