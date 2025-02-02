// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Deneme d1 = new Deneme() { Id = 1, Name = "asd" };
Deneme d2 = new Deneme() { Id = 1, Name = "asd" };

DenemeRecord d3 = new DenemeRecord() { Id = 1, Name = "asd" };
DenemeRecord d4 = new DenemeRecord() { Id = 1, Name = "asd" };
Console.WriteLine(d4.Name);


Deneme2 deneme2 = new Deneme2(1, "sadasdasdasd");
Console.WriteLine(deneme2);
Deneme3 deneme3 = new Deneme3(1, "ASFSDFKJSHFKJA");
Console.WriteLine(deneme3);

//Console.WriteLine(d1==d2);
class Deneme
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString()
    {
        return $"Id: {Id} Name:{Name} ";
    }
}

record DenemeRecord
{
    public int Id { get; set; }
    public string Name { get; init; }
}


record Deneme2(int id, string Name);

record Deneme3()
{
    public Deneme3(int id, string Name)
    {
        int Id;
        string Name;
    }
}