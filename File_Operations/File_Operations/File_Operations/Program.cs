using System;
using System.IO;
using System.Collections.Generic;

namespace File_Operations
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
			var list = new List<Student> ();
		
			StudentsBD students = new StudentsBD ();
			students.CreateFile ("file_operations");

			Console.WriteLine ("Getting info!");
			for (int i = 0; i < 10; i++) 
			{
				list.Add (new Student());
				Console.WriteLine ("Student #{0}", i+1);
				students.AddStudent (list [i]);
			}
			students.CloseFile();

			Console.WriteLine("Grill number:" + students.ReadStudents("file_operations"));

			//Console.ReadKey ();
		}
	}
}
