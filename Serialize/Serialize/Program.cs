using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialize
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			const int MAX_PRODUCTS = 5; 

			var list = new List<Product> ();

			// filling list with objects
			for (int i = 0; i < MAX_PRODUCTS; i++) {
				var product =  new Product();
				list.Add (product);
				Console.WriteLine ("~~~");
				Console.WriteLine ($"Product validation: {product.IsValidProductDate()}");
				Console.WriteLine ($"Product expiration date: {product.ExpirationDate}");
				Console.WriteLine (product.ToString());
				Console.WriteLine ("~~~");
			}
				
			// JSON serialization

			// serializing list with JSON library
			Console.Write ("Serializing JSON: ");
			string serializedObjects = JsonConvert.SerializeObject (list);
			Console.WriteLine ("Done!");

			var writeFile = new StreamWriter ("json_serialized.txt");
			writeFile.WriteLine (serializedObjects);
			writeFile.Close ();

			var readFile = new StreamReader ("json_serialized.txt");
			var line = readFile.ReadLine ();
			readFile.Close ();

			var restoredList = new List<Product> ();
			Console.Write ("Deserializing JSON: ");
			restoredList = JsonConvert.DeserializeObject<List<Product>> (line);
			Console.WriteLine ("Done!");

			// formatting output
			Console.WriteLine ("Restored list:");
			foreach (var i in restoredList) { Console.WriteLine (i); }

			// Binary serialization

			// writing to file
			FileStream binaryStream = File.Create ("binary_serialized");
			var formatter = new BinaryFormatter ();
			Console.Write ("Serializing binary: ");
			formatter.Serialize (binaryStream, list);
			Console.WriteLine ("Done!");
			binaryStream.Close ();

			// reading from file
			binaryStream = File.OpenRead ("binary_serialized");
			Console.Write ("Deserializing binary: ");
			var binaryRestoredList = formatter.Deserialize (binaryStream) as List<Product>;
			Console.WriteLine ("Done!");
			binaryStream.Close ();

			Console.WriteLine ("Output from file:");
			foreach (var i in binaryRestoredList) { Console.WriteLine (i); }

			Console.ReadKey ();
		}
	}
}
