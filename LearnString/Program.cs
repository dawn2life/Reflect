using LearnString.Models;
using LearnString.Serializer;

var person = new Person()
{
    Name = "Aayush",
    Age = 25,
    CanVote = true
};

string serializedData = BasicSerializer.Serialize(person);
Console.WriteLine(serializedData);

Person deserializedPerson = BasicDeserializer.Deserialize<Person>(serializedData);
Console.WriteLine($"Deserialized Person: Name={deserializedPerson.Name}, Age={deserializedPerson.Age}, CanVote={deserializedPerson.CanVote}");