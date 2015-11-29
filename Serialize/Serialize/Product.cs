using System;

namespace Serialize
{
	[Serializable]
	public class Product
	{
		public string name { get; set; }
		public int code { get; set; }
		public DateTime manufactureDate { get; set; }
		public int expirationDateMonths { get; set; }

		public Product ()
		{
			name = Faker.CompanyFaker.Name ();
			code = Faker.NumberFaker.Number(1, 9999999);

			var currentDate = DateTime.Now ;
			manufactureDate = Faker.DateTimeFaker.DateTime (new DateTime(2014, 1, 1), new DateTime(currentDate.Year, currentDate.Month, currentDate.Day));

			// Product can be valid from 1 month up to 18
			expirationDateMonths = Faker.NumberFaker.Number (1, 18);
		}

		public bool IsValidProductDate()
		{
			var days = (new DateTime (2015, 11, 8) - manufactureDate).Days;
			return days >= 0;
		}

		public DateTime ExpirationDate { 
			get 
			{ 
				return manufactureDate.AddMonths (expirationDateMonths);
			} 
		}

		public override string ToString ()
		{
			return string.Format ("-> Product: name={0}, code={1}, manufactureDate={2}, expirationDateMonths={3}, ExpirationDate={4}", name, code, manufactureDate, expirationDateMonths, ExpirationDate);
		}
	}
}

