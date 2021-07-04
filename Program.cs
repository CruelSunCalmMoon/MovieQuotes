using System;

namespace MovieQuotes
{
    class Program
    {
        static QuoteRepository repository = new QuoteRepository();
        static void Main(string[] args)
        {
            string optionUser = ObtainOptionUser();

            while (optionUser.ToUpper() != "X")
            {
                switch (optionUser)
                {
                    case "1":
                        ListQuotes();
                        break;                    
                    case "2":
                        InsertQuote();
                        break;
                    case "3":
                        UpdateQuote();
                        break;
                    case "4":
                        ExcludeQuote();
                        break;
                    case "5":
                        VisualizeQuote();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default: 
                        throw new ArgumentOutOfRangeException();
                }

                optionUser = ObtainOptionUser();
            }

            Console.WriteLine("GOODBYE O WISE ONE!");
            Console.ReadLine();
        }

        private static void ExcludeQuote()
        {
            Console.Write("Type in the Quote's ID: ");
            int indiceQuote = int.Parse(Console.ReadLine());

            repository.Exclude(indiceQuote);
        }

        private static void VisualizeQuote()
        {
            Console.Write("Type in the Quote's ID: ");
            int indiceQuote = int.Parse(Console.ReadLine());

            var quote = repository.BringBackId(indiceQuote);

            Console.WriteLine(quote);
        }

        private static void UpdateQuote()
        {
            Console.Write("Type in the Quote's ID: ");
            int indiceQuote = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}-{1}", i , Enum.GetName(typeof(Gender), i));
            }
            Console.Write("where did you find this Quote? ");
            int enterGender = int.Parse(Console.ReadLine());

            Console.Write("What is the Title? ");
			string enterTitle = Console.ReadLine();

			Console.Write("WHAT IS THE QUOTE??? ");
			string enterQuote = Console.ReadLine();

			Console.Write("Who was this wise one? ");
			string enterAuthor = Console.ReadLine();

            Quote updateQuote = new Quote(id: indiceQuote,
                                    gender: (Gender)enterGender,
                                    title: enterTitle,
                                    description: enterQuote,
                                    author: enterAuthor);
            repository.Update(indiceQuote, updateQuote);
        }

        private static void ListQuotes()
		{
			Console.WriteLine("List Quotes");

			var list = repository.Lista();

			if (list.Count == 0)
			{
				Console.WriteLine("Nothing here, yet.");
				return;
			}

			foreach (var serie in list)
			{
                var exclude = serie.bringBackExcluded();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.bringBackId(), serie.bringBackQuote(), (exclude ? "*Excluded*" : ""));
			}
		}

        private static void InsertQuote()
		{
			Console.WriteLine("Insert new Quote: ");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Gender)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
			}
			Console.Write("where did you find this Quote? Choose from option above. ");
            int enterGender = int.Parse(Console.ReadLine());

            Console.Write("What is the Title? ");
			string enterTitle = Console.ReadLine();

			Console.Write("WHAT IS THE QUOTE??? ");
			string enterQuote = Console.ReadLine();

			Console.Write("Who was this wise one? ");
			string enterAuthor = Console.ReadLine();

            Quote newQuote = new Quote(id: repository.NextId(),
                                    gender: (Gender)enterGender,
                                    title: enterTitle,
                                    description: enterQuote,
                                    author: enterAuthor);
            repository.Insert(newQuote);
		}

        private static string ObtainOptionUser()
		{
			Console.WriteLine();
			Console.WriteLine("Quotes to inspire!!!");
			Console.WriteLine("What do you wish, summoner:");

			Console.WriteLine("1- Show Quotes");
			Console.WriteLine("2- Insert new Quote");
			Console.WriteLine("3- Update Quote");
			Console.WriteLine("4- Exclude Quote");
			Console.WriteLine("5- Quote's Info");
			Console.WriteLine("C- Clear screen");
			Console.WriteLine("X- Exit");
			Console.WriteLine();

			string optionUser = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return optionUser;
		}
    }
}
