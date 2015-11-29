using System;
using System.IO;
using Faker;

namespace File_Operations
{
	public class StudentsBD
	{

		private StreamWriter writeFile;
		private int resultNumber = 0;
		public StudentsBD () { }

		public void CreateFile(string fileName) 
		{
			writeFile = new StreamWriter(String.Format("{0}.txt", fileName));
		}

		public void CloseFile() { writeFile.Close (); }

		public void AddStudent(Student student)
		{
			string temp = student.ToString ();
			writeFile.WriteLine (temp);
		}

		public int ReadStudents(string fileName)
		{
			foreach (string line in File.ReadLines(String.Format("{0}.txt", fileName))) 
			{
				if (line.Contains ("female") && line.Contains ("5") && line.Contains ("5.0")) 
				{
					resultNumber++;
				}
			}
			return resultNumber;
		}
	}
}

