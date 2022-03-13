// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;


Person person = new(10, "bnaya");
byte[] utf8Json = JsonSerializer.SerializeToUtf8Bytes(person, PersonContext.Default.Person);
Person person1 = JsonSerializer.Deserialize(utf8Json, PersonContext.Default.Person);
Console.WriteLine(person1);

utf8Json = JsonSerializer.SerializeToUtf8Bytes(person, EmployeeContext.Default.Person);
Person person2 = JsonSerializer.Deserialize(utf8Json, EmployeeContext.Default.Person);
Console.WriteLine(person2);


Employee employee = new(person, "cto");
utf8Json = JsonSerializer.SerializeToUtf8Bytes(employee, EmployeeContext.Default.Employee);
Employee? employee1 = JsonSerializer.Deserialize(utf8Json, EmployeeContext.Default.Employee);
Console.WriteLine(employee1);


public record struct Person (int Id, string Name);

public record Employee (Person Person, string Role);

[JsonSerializable(typeof(Person))]
internal partial class PersonContext : JsonSerializerContext
{ 
}


[JsonSerializable(typeof(Employee))]
internal partial class EmployeeContext : JsonSerializerContext
{ 
}