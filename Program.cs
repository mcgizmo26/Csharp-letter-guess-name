using System;

namespace letter_guess_name
{
	class MainClass
	{
		/*
		 * Create a game similar to hangman in which a player guesses letters to try to replicate a hidden word.
		 * 
		 * String Contain Method ex: string s = "Hello"; example syntax s.Contains("H");
		 * 
		 * String Remove method ex: string s = "Hello"; example syntax s = s.Remove(0, 1);
		 * 
		 *  String Insert method ex: string s = "Hello"; example syntax s = s.Insert(0, "H");
		 * 
		 */

		public static void Main(string[] args)
		{
			//Get random words Logic
			string[] words = { "jibanyan", "whisper", "komosan", "komojiro", "wazat", "hungramps", "robanyan", "happiere" };

			Random random = new Random();

			int randomIndex = random.Next(0, words.Length);

			string selectedWord = words[randomIndex];

			string hiddenWord = "";
			int guessCount = 0;

			for (int i = 0; i < selectedWord.Length; i++)
			{
				hiddenWord += "*";
			}

			//Guessing Logic
			while (hiddenWord.Contains("*"))
			{
				Console.WriteLine("Word: {0}", hiddenWord);

				Console.Write("Guess a letter >> \n");
				char letter = char.Parse(Console.ReadLine());

				guessCount++;

				bool containsLetter = false;

				for (int i = 0; i < selectedWord.Length; i++)
				{
					if (selectedWord[i] == letter)
					{
						hiddenWord = hiddenWord.Remove(i, 1);
						hiddenWord = hiddenWord.Insert(i, letter.ToString());
						containsLetter = true;
					}
				}
				if (containsLetter == true)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("\n Yes! {0} is in the word \n", letter);
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\n The letter {0} is not in the word \n", letter);
				}
				Console.ResetColor();
			}

			Console.WriteLine("You Won, it took you {0} trys. The word was {1}", guessCount, selectedWord);
		}
	}
}
