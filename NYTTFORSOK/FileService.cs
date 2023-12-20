

using Newtonsoft.Json;

namespace NYTTFORSOK;

public class FileService
{
    public List<Contact> GetContentFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Contact>>(jsonContent) ?? new List<Contact>();
            }
            else
            {
                Console.WriteLine("Filen finns inte. Skapar en ny fil...");
                return new List<Contact>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fel vid läsning av JSON-fil: {ex.Message}");
            return new List<Contact>();
        }
    }

    public void SaveContentToFile(List<Contact> list, string filePath)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                string jsonContent = JsonConvert.SerializeObject(list);
                sw.Write(jsonContent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fel vid skrivning till JSON-fil: {ex.Message}");
        }
    }
}
