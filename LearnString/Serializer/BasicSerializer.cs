using LearnString.Models;
using System.Runtime.CompilerServices;
using System.Text;

namespace LearnString.Serializer
{
    public static class BasicSerializer
    {
        public static string Serialize<T>(T obj) 
        {
            var properties = obj.GetType().GetProperties();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var property in properties) 
            {
                stringBuilder.Append($"{property.Name}={property.GetValue(obj, null)};");
            }

            // Basic string format: Name=Aayush;Age=30
            var convertedString = stringBuilder.ToString();
            return convertedString;
        } 
    }
}
