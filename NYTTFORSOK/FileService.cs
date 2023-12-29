

using Newtonsoft.Json;

namespace NYTTFORSOK;

public class FileService
{
    public List<Contact> GetContentFromFile(string filePath) ///Metod som hämtar innehållet från filePath i parametern.
    {
        try 
        {
            if (File.Exists(filePath)) ///Kollar om filen finns.
            {
                string jsonContent = File.ReadAllText(filePath); ///Spar innehållet till variabeln JsonContent.
                return JsonConvert.DeserializeObject<List<Contact>>(jsonContent) ?? new List<Contact>();  ///Gör om listan från Json-format till "vanligt format".
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

    public void SaveContentToFile(List<Contact> list, string filePath) ///Metod som tar emot en lista och sökväg. Listan görs om till Json format och sedan sparas till filePath.
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
