

namespace NYTTFORSOK;

public class ContactService
{
    FileService fileService = new FileService();
    string filePath = @"C:\my-projects\NYJSONFIL.json";
    List<Contact> contactList;

    public ContactService()
    {
      
        contactList = fileService.GetContentFromFile(filePath);
    }



    public void ShowAddContact()
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

        Contact contact = new Contact(FirstName, LastName, Email, PhoneNumber, Adress);

        contactList.Add(contact);

        fileService.SaveContentToFile(contactList, filePath);
        Console.WriteLine();
        Console.WriteLine("Kontaken har lagts till i adressboken. Tryck på valfri knapp för att gå vidare.");
        Console.ReadKey();
    }

    public void ShowAllContacts()
    {
        if (contactList.Count != 0)
        {
            Console.Clear();
            foreach (Contact c in contactList)
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

    public void ShowGetSpecificContact()
    {
        Console.Clear();
        Console.Write("Ange förnamn: ");
        string findContact = Console.ReadLine();
        Console.Clear();
        Contact showContactFromList = contactList.Find(e => e.FirstName.ToLower() == findContact.ToLower());
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

    public void ShowDeleteContact()
    {
        Console.Clear();
        Console.Write("Ange email: ");
        string deleteContact = Console.ReadLine();
        Contact contactToRemove = contactList.Find(e => e.Email.ToLower() == deleteContact.ToLower());
        if(contactToRemove != null)
        {
            contactList.Remove(contactToRemove);
            fileService.SaveContentToFile (contactList, filePath);
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

    public void ShowUpdateContact()
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
            Console.WriteLine("3. Adress");

            Console.Write("Välj vad du vill uppdatera: ");
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

    public void ShowMainMenu()
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

    public void QuitApplication()
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
