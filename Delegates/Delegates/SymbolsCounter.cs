using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{
	public class SymbolsCounter
	{
		const int DEFAULT_NUMBER_OF_CHARS = 10;
		public List<string> symbolsList { get; set; }  

		// all funcs with void (void) prototype
		public delegate void MessageContainer ();
		public event MessageContainer onClean;
		public event MessageContainer onPopulate;

		private string GetRandomStringWithLength(int length)
		{
			return Guid.NewGuid().ToString("n").Substring(0, length);
		}

		private List<string> PopulateListWithString(string input)
		{
			return input.Select (c => c.ToString ()).ToList ();
		}
			
		public SymbolsCounter ()
		{
			var randomString = GetRandomStringWithLength(DEFAULT_NUMBER_OF_CHARS);
			symbolsList = PopulateListWithString(randomString);
		}

		public void CleanList()
		{
			symbolsList.Clear ();

			// check if anything 'subscribed' to event
			if (onClean != null) 
				onClean ();

			// populating list again
			symbolsList = PopulateListWithString(GetRandomStringWithLength(DEFAULT_NUMBER_OF_CHARS));

			if (onPopulate != null)
				onPopulate ();
		}

		// onClean event reaction
		public void CleanSuccess()
		{
			Console.WriteLine ("List cleared! (onClean event triggered)");
		}

		// onPopulate event reaction
		public void PopulateSuccess()
		{
			Console.WriteLine ("List populated! (onPopulate event triggered)");
		}

		public void PrintValues()
		{
			foreach (var i in symbolsList) { Console.Write (i); }
			Console.WriteLine ();
		}
			
		public void RemoveSeveralRandomSymbols(int number)
		{
			for (int i = 0; i < number; i++) 
			{
				symbolsList.RemoveAt (new Random().Next(0, symbolsList.Count()));
			}
		}

		public void AddSeveralRandomSymbols(int number)
		{
			for (int i = 0; i < number; i++) 
			{
				symbolsList.Add (GetRandomStringWithLength(1));
			}	
		}
	}
}

