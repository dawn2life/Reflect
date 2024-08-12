namespace LearnString.Serializer
{
    public static class BasicDeserializer
    {
         private static readonly HashSet<Type> TypeSet = new HashSet<Type>()
         {
             typeof(int),
             typeof(string),
             typeof(bool),
             typeof(double)
         };

        public static T Deserialize<T>(string data) where T : new()
        {
            T obj = new T();
            
            var properties = obj.GetType().GetProperties();

            var parts = data.Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                var keyValue = part.Split('=');
                var propertyName = keyValue[0];
                var value = keyValue[1];

                var property = properties.FirstOrDefault(p => p.Name == propertyName);

                if (property is not null)
                {
                    if (TypeSet.Contains(property.PropertyType))
                    {
                        try
                        {
                            property.SetValue(obj, CanConvertTo(value, property.PropertyType), null);
                        }
                        catch (Exception ex) 
                        {
                            Console.WriteLine($"Error converting value '{value}' to type '{property.PropertyType}': {ex.Message}");
                        }
                    }
                }
            }

            return obj;
        }

        public static object CanConvertTo(string value, Type targetType) => Convert.ChangeType(value, targetType);
    }
}
