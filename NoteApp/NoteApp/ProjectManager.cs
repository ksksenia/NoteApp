using Newtonsoft.Json;
using System.IO;
namespace NoteApp
{

	public static class ProjectManager
	{
		private static string _PathFile = @"";
		public static void SaveToFile(Project se, string filename)
		{
		    _PathFile = filename;
            JsonSerializer serializer = new JsonSerializer();
			//Открываем поток для записи в файл с указанием пути 
			using (StreamWriter sw = new StreamWriter(filename))
			using (JsonWriter writer = new JsonTextWriter(sw))
			{
				//Вызываем сериализацию и передаем объект, который хотим сериализовать 
				serializer.Serialize(writer, se);
			}
		}
		public static Project LoadFromFile(string filename)
		{
		    _PathFile = filename;
			Project deNote = null;
            // Если файл отсутствует, создать его и вернуть новый 
		    if (!File.Exists(filename))
		    {
		        deNote = new Project();
		        SaveToFile(deNote,filename);
		        return deNote;
		    }
			//Создаём экземпляр сериализатора 
			JsonSerializer serializer = new JsonSerializer();
			//Открываем поток для чтения из файла с указанием пути 
			using (StreamReader sr = new StreamReader(filename))
			using (JsonReader reader = new JsonTextReader(sr))
			{
				//Вызываем десериализацию и явно преобразуем результат в целевой тип данных 
				deNote = (Project)serializer.Deserialize<Project>(reader);
			}
			return deNote;
		}
	}
}
