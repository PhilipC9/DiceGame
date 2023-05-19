using System;
using System.Collections.Generic;

class Game
{

    // 3st Generiska Klasser!
    static Queue<string> playerQueue = new Queue<string>();
    static List<string> playerList = new List<string>();
    static Dictionary<string, int> playerScores = new Dictionary<string, int>();

    static void Main()
    {
        string ascii = @".d88888b  dP               dP                              oo                   
88.    ""' 88    88         88    88 88                                             
`Y88888b. 88 .d8888b.    d8888P .d8888b. 88d888b. 88d888b. dP 88d888b. .d8888b. 
      `8b 88 88'  `88      88   88'  `88 88'  `88 88'  `88 88 88'  `88 88'  `88 
d8'   .8P 88 88.  .88      88   88.  .88 88       88    88 88 88    88 88.  .88 
 Y88888P  dP `88888P8      dP   `88888P8 dP       dP    dP dP dP    dP `8888P88 
                                                                            .88 
                                                                        d8888P  ";


        Console.WriteLine(ascii);

        // Lägg till spelare i kön
        EnqueuePlayers();

        // Starta spelet
        StartGame();

        Console.WriteLine("Spelet är slut.");

        // Hitta vinnaren
        string winner = Winner();
        Console.WriteLine($"Vinnaren är: {winner}");

        Console.WriteLine("Tryck på valfri tangent för att avsluta.");
        Console.ReadKey();
    }

    // Inmatning av spelarnamn
    static void EnqueuePlayers()
    {
        Console.WriteLine("Ange spelarnas namn (tryck enter för att avsluta):");
        while (true)
        {
            // lägger till angivet spelarnamn i en kö
            string playerName = Console.ReadLine();
            if (string.IsNullOrEmpty(playerName))
                break;

            playerQueue.Enqueue(playerName);
            //
        }
    }

    static void StartGame()
    {
        Random random = new Random();

        // Kö för spelare som ska slå tärning
        while (playerQueue.Count > 0)
        {
            string currentPlayer = playerQueue.Dequeue();

            Console.WriteLine($"Det är {currentPlayer}s tur. Tryck på valfri tangent för att slå tärningen.");
            Console.ReadKey();

            // Slå tärningen (generera ett slumpmässigt tal mellan 1 och 6)
            int rollDice = random.Next(1, 7);

            // Lägg till spelaren i listan om de inte redan finns där
            if (!playerList.Contains(currentPlayer))
                playerList.Add(currentPlayer);

            // Uppdatera spelarens poäng i dictionary
            if (playerScores.ContainsKey(currentPlayer))
                playerScores[currentPlayer] += rollDice;
            else
                playerScores.Add(currentPlayer, rollDice);

            Console.WriteLine($"{currentPlayer} slog {rollDice} på tärningen.");
            Console.WriteLine();
        }
    }


    static string Winner()
    {
        string winner = string.Empty; // Variabel för att lagra vinnarens namn
        int highestScore = 0; // Variabel för att lagra högsta poängen

        // Loopa genom spelarpoängen i dictionary
        foreach (var amount in playerScores)
        {
            // Kontrollera om spelarens poäng är högre än den tidigare högsta poängen
            if (amount.Value > highestScore)
            {
                highestScore = amount.Value; // Uppdatera högsta poäng
                winner = amount.Key; // Uppdatera vinnarens namn
            }
        }

        return winner; // Returnera vinnarens namn
    }
}
