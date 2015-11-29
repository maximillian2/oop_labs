using System;

namespace Delegates
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var sc = new SymbolsCounter ();
			sc.PrintValues ();
			sc.RemoveSeveralRandomSymbols (3);
			sc.PrintValues ();
			sc.AddSeveralRandomSymbols (5);
			sc.PrintValues ();

			sc.onClean += sc.CleanSuccess;
			sc.onPopulate += sc.PopulateSuccess;

			sc.CleanList ();
			sc.PrintValues ();
		}
	}
}
