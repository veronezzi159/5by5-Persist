using Models;
using Controller;
string path = @"C:\Users\L.Veronezzi\AquivosJson\";
string file = "radar.json";

var controller = new PersistController();   

int number = controller.InsertInSql(path, file);
