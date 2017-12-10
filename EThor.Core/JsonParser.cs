using System.Web.Script.Serialization;

namespace EThor.Core
{
    public class JsonParser
    {
        public static T ConvertTo<T>(string json)
        {
            T obj = default(T);
            if(!string.IsNullOrEmpty(json))
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                obj = serializer.Deserialize<T>(json);
            }
            return obj;
        }
    }
}
