using Models;
string path = @"C:\Users\L.Veronezzi\AquivosJson\";
string file = "radar.json";


var lst = ReadFile.GetData(path, file);

foreach (var item in lst)
{
    Console.WriteLine(item);
}
Console.WriteLine(lst.Count());
Console.ReadKey();