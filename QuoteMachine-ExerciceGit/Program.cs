using QuoteMachine_ExerciceGit;
using System.Diagnostics.Metrics;

Console.WriteLine("Bienvenue dans QuoteMachine!");
Console.WriteLine("Ce projet est collaboratif et utilise le GitHub Flow.");
Console.WriteLine("Développez une application console pour gérer et afficher des citations inspirantes.\n");
Console.WriteLine("Prochaines étapes : implémentez les fonctionnalités dans des branches distinctes.\n");
Console.WriteLine("\n=== Menu Principal ===");
int choix = 0;
do
{
    Console.WriteLine("Veuillez choisir parmi les quatre options suivants. \n");
    Console.WriteLine("1) affichez une citation aléatoire. \n");
    Console.WriteLine("2) ajouté  une nouvelle citation . \n");
    Console.WriteLine("3) sauvegarder les citations . \n");
    Console.WriteLine("4) charger les citations du fichier. \n");
    choix = Convert.ToInt32(Console.ReadLine());
} while (choix <= 0 || choix >= 5);
var manager = new QuoteManager();

switch (choix)
{
    case 1:
        Console.WriteLine("=== La citation alétoire récupéré === \n");
        ShowRandomQuote(manager);
        break;

    case 2:
        Console.WriteLine("=== Ajout de la citation === \n");
        AddNewQuote(manager);
        break;

    case 3:
        Console.WriteLine("=== Sauvegarde de la citation === \n");
       SaveQuotesToFile(manager);
        break;

    case 4:
        Console.WriteLine("=== Chargement de la citation === \n");
        LoadQuotesFromFile(manager);
        break;
}


Console.WriteLine("Implémentez le menu du programme dans feature/menu");
Console.ReadKey(true);
string path = "citations.csv";



static void ShowRandomQuote(QuoteManager manager)
{
    Console.WriteLine("[Simulation] Une citation aléatoire s’afficherait ici.");
    Console.WriteLine(manager.GetRandomQuote());
}

static void AddNewQuote(QuoteManager manager)
{
    Console.WriteLine("Veuillez ajouter une nouvelle citation :");
         //   Exemple futur :
             Console.Write("Texte : ");
        var texte = Console.ReadLine();
        Console.Write("Auteur : ");
        var auteur = Console.ReadLine();
        manager.AddQuote(texte, auteur);
        Console.WriteLine("Citation ajoutée !");
}

static void SaveQuotesToFile(QuoteManager manager)
{
    try
    {
        Console.WriteLine("[Simulation] On sauvegarderait les citations ici.");
        // Exemple futur :
        manager.SaveToCSVFile("citations.csv");
        Console.WriteLine("Citations sauvegardées !");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur : {ex.Message}");
    }
}

static void LoadQuotesFromFile(QuoteManager manager)
{
    try
    {
        Console.WriteLine("[Simulation] On chargerait les citations ici.");
        // Exemple futur :
        string path = "citations.csv";
        manager.SaveToCSVFile(path);
        Console.WriteLine("Citations chargées !");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur : {ex.Message}");
    }
}

