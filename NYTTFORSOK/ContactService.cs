

namespace NYTTFORSOK;

public class ContactService 
{
    FileService fileService = new FileService(); ///Instansiering av klassen FileService.
    string filePath = @"C:\my-projects\NYJSONFIL.json"; ///Skapar variabel med sökväg. 
    List<Contact> contactList; ///Skapar lista.

    public ContactService()
    {
      
        contactList = fileService.GetContentFromFile(filePath); ///Hämtar innehållet från filePath till min lista contactList.
    }



    public void ShowAddContact() ///Metod som ber användaren skapa en kontakt och sparar kontakten.
    {
        
        Console.Write("Ange förnamn: ");
        string FirstName = Console.ReadLine();

        Console.Write("Ange efternamn: ");
        string LastName = Console.ReadLine();

        Console.Write("Ange email: ");
        string Email = Console.ReadLine();

        Console.Write("Ange telefonnummer: ");
        string PhoneNumber = Console.ReadLine();

        Console.Write("Ange Adress: ");
        string Adress = Console.ReadLine();

        Contact contact = new Contact(FirstName, LastName, Email, PhoneNumber, Adress); ///Skapar kontakt.

        contactList.Add(contact); ///Lägger till kontakt i listan.

        fileService.SaveContentToFile(contactList, filePath); ///Sparar lista till fil.
        Console.WriteLine();
        Console.WriteLine("Kontaken har lagts till i adressboken. Tryck på valfri knapp för att gå vidare.");
        Console.ReadKey();
    }


    public void ShowAllContacts() ///Metod som visar alla kontaker från listan.
    {
        if (contactList.Count != 0) ///Kontrollerar att listan inte är tom.
        {
            Console.Clear();
            foreach (Contact c in contactList) ///Skriver ut varje kontakt som finns i listan.
            {
                Console.WriteLine($"Förnamn: {c.FirstName}");
                Console.WriteLine($"Efternamn: {c.LastName}");
                Console.WriteLine($"Email: {c.Email}");
                Console.WriteLine();

            }
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Det finns inga kontakter i listan. Tryck på valfri knapp för att gå vidare.");
            Console.ReadKey();
        }
        
        
    }

    public void ShowGetSpecificContact() ///Metod visar all information om en specifik kontakt.
    {
        Console.Clear();
        Console.Write("Ange förnamn: ");
        string findContact = Console.ReadLine();
        Console.Clear();
        Contact showContactFromList = contactList.Find(e => e.FirstName.ToLower() == findContact.ToLower()); ///Letar efter förnamnet som matats in finns i listan.
        if (showContactFromList != null)
        {
            Console.WriteLine($"Förnamn: {showContactFromList.FirstName}");
            Console.WriteLine($"Efternamn: {showContactFromList.LastName}");
            Console.WriteLine($"Email: {showContactFromList.Email}");
            Console.WriteLine($"Telefon: {showContactFromList.PhoneNumber}");
            Console.WriteLine($"Adress: {showContactFromList.Address}");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Kontakten hittades inte. Tryck på valfri knapp för gå vidare.");
            Console.ReadKey();  
        }
    }

    public void ShowDeleteContact() ///Metod som raderar kontakt från listan
    {
        Console.Clear();
        Console.Write("Ange email: ");
        string deleteContact = Console.ReadLine();
        Contact contactToRemove = contactList.Find(e => e.Email.ToLower() == deleteContact.ToLower()); ///Kollar om mailen finns i listan eller inte.
        if (contactToRemove != null)
        {
            contactList.Remove(contactToRemove); ///Raderar kontakten från listan.
            fileService.SaveContentToFile (contactList, filePath); ///Sparar listan till fil.
            Console.Clear();
            Console.WriteLine($"{contactToRemove.FirstName} {contactToRemove.LastName} har raderats från listan.");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine($"{deleteContact} kunde inte hittas.");
            Console.ReadKey();
        }
    }

    public void ShowUpdateContact() ///Metod som kan uppdatera kontakt.
    {
        if (contactList.Count == 0) 
        {
            Console.Clear();
            Console.WriteLine("Det finns inga kontakter i listan. Tryck på valfri knapp för att fortsätta.");
        }
        else
        {
            Console.Clear();
            Console.Write("Ange email: ");
            string updateContact = Console.ReadLine();
            Contact contactToUpdate = contactList.Find(e => e.Email == updateContact.ToLower()); 

            Console.Clear();
            Console.WriteLine("1. Förnamn");
            Console.WriteLine("2. Efternamn");
            Console.WriteLine("3. E-post");
            Console.WriteLine("4. Telefonnummer");
            Console.WriteLine("5. Adress");

            Console.Write("Välj vad du vill uppdatera (1-5): ");
            string updateOption = Console.ReadLine();

            switch (updateOption)
            {
                case "1":
                    {
                        Console.Write("Ange nytt förnamn: ");
                        string newFirstName = Console.ReadLine();
                        contactToUpdate.FirstName = newFirstName;
                        fileService.SaveContentToFile(contactList, filePath);
                        Console.WriteLine();
                        Console.WriteLine($"Förnamn har uppdaterats till {contactToUpdate.FirstName}.");
                        Console.ReadKey();
                        break;
                    }
                    case "2":
                    {
                        Console.Write("Ange nytt efternamn: ");
                        string newLastName = Console.ReadLine();
                        contactToUpdate.LastName = newLastName;
                        fileService.SaveContentToFile(contactList, filePath);
                        Console.WriteLine();
                        Console.WriteLine($"Efternamn har uppdaterats till {contactToUpdate.LastName}.");
                        Console.ReadKey();
                        break;
                    }
                    case "3":
                    {
                        Console.Write("Ange ny email: ");
                        string newEmail = Console.ReadLine();
                        contactToUpdate.Email = newEmail;
                        fileService.SaveContentToFile(contactList, filePath);
                        Console.WriteLine();
                        Console.WriteLine($"Emailen har uppdaterats till {contactToUpdate.Email}.");
                        Console.ReadKey();
                        break;
                    }
                case "4":
                    {
                        Console.Write("Ange nytt telefonnummer: ");
                        string newPhoneNumber = Console.ReadLine();
                        contactToUpdate.Email = newPhoneNumber;
                        fileService.SaveContentToFile(contactList, filePath);
                        Console.WriteLine();
                        Console.WriteLine($"Telefonnummer har uppdaterats till {contactToUpdate.PhoneNumber}.");
                        Console.ReadKey();
                        break;
                    }
                case "5":
                    {
                        Console.Write("Ange ny Adress: ");
                        string newAdress = Console.ReadLine();
                        contactToUpdate.Address = newAdress;
                        fileService.SaveContentToFile(contactList, filePath);
                        Console.WriteLine();
                        Console.WriteLine($"Adressen har uppdaterats till {contactToUpdate.Address}.");
                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Ogiltig inmatning. Tryck på valfri knapp för att fortsätta.");
                        Console.ReadKey();
                        break;
                    }

                   
                    
            }   
                
        }
        
        


    }

    public void ShowMainMenu() ///Start meny som börjar med att hämta data från fil.
    {
        fileService.GetContentFromFile(filePath);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("## Min Adressbok ##");
            Console.WriteLine("1. Lägg till kontakt");
            Console.WriteLine("2. Visa alla kontakter");
            Console.WriteLine("3. Visa detaljerad kontaktinformation");
            Console.WriteLine("4. Uppdatera kontakt");
            Console.WriteLine("5. Radera kontakt");
            Console.WriteLine("0. Avsluta programmet");
            Console.WriteLine();
            Console.Write("Ditt val: ");
            string option = Console.ReadLine();
            Console.Clear();

            switch (option)
            {
                case "1":
                    ShowAddContact();
                    break;

                case "2":
                    ShowAllContacts();
                    break;
                case "3":
                    ShowGetSpecificContact();
                    break;
                case "4":
                    ShowUpdateContact();
                    break;
                case "5":
                    ShowDeleteContact();
                    break;
                case "0":
                    QuitApplication();
                    break;
                default:
                    Console.WriteLine("Ogiltig inmatning. Försök igen!");
                    break;
            }



        }
    }

    public void QuitApplication() ///Metod som avslutar programmet.
    {
        Console.Clear();
        Console.Write("Vill du verkligen avsluta progammet? (y/n): ");
        var option = Console.ReadLine();
        if (option.ToLower() == "y")
        {
            Environment.Exit(0);
        }
        else
        {
            ShowMainMenu();
        }
    }


}
