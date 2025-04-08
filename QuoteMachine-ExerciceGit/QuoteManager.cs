using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteMachine_ExerciceGit
{
    public class QuoteManager
    {
        private List<Quote> _quotes;

        public QuoteManager()
        {
            _quotes = new List<Quote>
            {
                new Quote { Text = "Le succès, c’est d’aller d’échec en échec sans perdre son enthousiasme.", Author = "Winston Churchill" },
                new Quote { Text = "Soyez vous-même, tous les autres sont déjà pris.", Author = "Oscar Wilde" },
                new Quote { Text = "La vie, c’est comme une bicyclette, il faut avancer pour ne pas perdre l’équilibre.", Author = "Albert Einstein" }
            };
        }

        public Quote GetRandomQuote()
        {
            //Avant de commencer, décommenter le test suivant:
            //GetRandomQuote_ShouldReturnNonNullQuote

            //Avant de créer votre PR, faites un git rebase sur main pour vous assurer que vous avez la dernière version du code.
           Random rnd = new Random();

           Quote rndQuote = _quotes[rnd.Next(_quotes.Count)];

           return rndQuote;
        }

        public void AddQuote(string text, string author)
        {
            //Avant de commencer, décommenter le test suivant:
            //AddQuote_ShouldIncreaseQuoteCount

            //Avant de créer votre PR, faites un git rebase sur main pour vous assurer que vous avez la dernière version du code.
            throw new NotImplementedException("À implémenter dans feature/add-quote");
        }

        public void SaveToCSVFile(string path)
        {
            //Avant de commencer, décommenter les tests suivants:
            //SaveToFile_ShouldCreateFile
            //SaveToFile_ShouldThrowIfNotInCSVExtension

            if (path.EndsWith(".csv"))
            {
                StreamWriter streamWriter = new StreamWriter(path, false);
                foreach (Quote quote in _quotes)
                {
                    streamWriter.WriteLine(quote);
                }

                streamWriter.Close();
            } else
            {
                throw new QuoteFileException(String.Format("Erreur lors de la sauvegarde : le fichier doit avoir l'extension .csv"));
            }

            //Avant de créer votre PR, faites un git rebase sur main pour vous assurer que vous avez la dernière version du code.
        }

        public void LoadFromCSVFile(string path)
        {
            //Avant de commencer, décommenter les tests suivants:
            //LoadFromFile_ShouldAppendQuotesToList
            //LoadFromFile_ShouldThrowIfFileMissing

            //Avant de créer votre PR, faites un git rebase sur main pour vous assurer que vous avez la dernière version du code.

            if (!IsCSVFile(path))
            {
                throw new QuoteFileException("Erreur lors de la sauvegarde : le fichier doit avoir l'extension .csv");
            }

            try
            {
                StreamReader streamReader = new StreamReader(path);
                string[] quotesImporter = streamReader.ReadToEnd().Replace("\n", "").Split("\r");

                foreach (string fQuote in quotesImporter)
                {
                    if (!string.IsNullOrEmpty(fQuote))
                    {
                        string[] infoQuote = fQuote.Split(",");
                        Quote nouvelleQuote = new Quote() { Text = infoQuote[0] , Author = infoQuote[1] };
                        _quotes.Add(nouvelleQuote);
                    }
                }

                streamReader.Close();
            }
            catch (FileNotFoundException)
            {
                throw new QuoteFileException("\"Erreur lors du chargement : le fichier n'existe pas\"");
            }

        }

        public List<Quote> GetAllQuotes()
        {
            return _quotes; // Pas besoin d'ajouter de test pour cette méthode
        }

        private bool IsCSVFile(string path)
        {
            return path.EndsWith(".csv");
        }
    }
}
