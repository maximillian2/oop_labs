using System;
using System.Text; 

namespace File_Operations
{
	public class Student
	{
		public string Surname { get; set; }
		public string Name { get; set; }
		public string StudentTicket { get; set; }
		public string Gender { get; set; }
		public string ID { get; set; }
		public int Course { get; set; }
		public double AveragePTS { get; set; }

		public Student ()
		{
			Surname = Faker.NameFaker.LastName();
			Name = Faker.NameFaker.FirstName();
			StudentTicket = Faker.NumberFaker.Number(7).ToString();
			string[] array = { "male", "female" };
			Gender = array[new Random().Next(array.Length)];
			ID = Faker.NumberFaker.Number(20).ToString();
			Course = Faker.NumberFaker.Number(1, 5);
			// get maximum 5 - fraction part
			var number = Convert.ToDouble(new Random().Next(1, 6)) + new Random().NextDouble();
			AveragePTS = number > 5 ? number - (number % 5) : number;
		}

		public override string ToString ()
		{
			var strBuilder = new StringBuilder ();
			strBuilder.Append (Surname);
			strBuilder.Append (' ');
			strBuilder.Append (Name);
			strBuilder.Append (' ');
			strBuilder.Append (StudentTicket);
			strBuilder.Append (' ');
			strBuilder.Append (Gender);
			strBuilder.Append (' ');
			strBuilder.Append (ID);
			strBuilder.Append (' ');
			strBuilder.Append (Course);
			strBuilder.Append (' ');
			strBuilder.Append (String.Format("{0:0.0}", AveragePTS));

			return strBuilder.ToString ();
		}

		public void GetInfoFromConsole()
		{
			Console.WriteLine ("Enter surname: ");
			Surname = Console.ReadLine();

			Console.WriteLine ("Enter name: ");
			Name = Console.ReadLine();

			Console.WriteLine ("Enter student ticket: ");
			StudentTicket = Console.ReadLine();

			Console.WriteLine ("Enter course: ");
			Course = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine ("Enter gender: ");
			Gender = Console.ReadLine();

			Console.WriteLine ("Enter average pts: ");
			AveragePTS = Convert.ToDouble(Console.ReadLine());
		
			Console.WriteLine ("Enter id: ");
			ID = Console.ReadLine();
		}
	}
}

