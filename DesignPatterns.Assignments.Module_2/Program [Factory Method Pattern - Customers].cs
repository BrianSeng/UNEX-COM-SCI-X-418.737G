using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UCLAExtension.DesignPatterns.FactoryMethodPattern.Customers.Lab
{
	public abstract class Customer
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public int Age { get; set; }
		public int BasePoints { get; set; }

		public abstract int CalculateTotalPoints();

		// Null object implementation
		static readonly NullCustomer nullCustomer = new NullCustomer();

		public static NullCustomer NULL
		{
			get { return nullCustomer; }
		}
	}

	#region - Derived Customer Classes -
	public class GoldCustomer : Customer
	{
		public override int CalculateTotalPoints()
		{
			return BasePoints * 2;
		}
	}

	public class SilverCustomer : Customer
	{
		public override int CalculateTotalPoints()
		{
			return (int)(BasePoints * 1.5);
		}
	}

	public class BronzeCustomer : Customer
	{
		public override int CalculateTotalPoints()
		{
			return BasePoints * 1;
		}
	}

	public class NullCustomer : Customer
	{
		public NullCustomer()
		{
			ID = "<Null>";
			Name = "<Null Customer>";
			City = string.Empty;
			State = string.Empty;
			Age = 0;
			BasePoints = 0;
		}
		public override int CalculateTotalPoints()
		{
			return 0;
		}
	}
	#endregion

	public static class CustomerFactory
	{
		public static Customer CreateCustomer(string id)
		{
			if (id.StartsWith("G-"))
			{
				return new GoldCustomer()
				{
					ID = id,
					Name = "Gold Customer",
					City = "Los Angeles",
					State = "CA",
					Age = 51,
					BasePoints = 200
				};
			}
			else if (id.StartsWith("S-"))
			{
				return new SilverCustomer()
				{
					ID = id,
					Name = "Silver Customer",
					City = "Miami",
					State = "FL",
					Age = 42,
					BasePoints = 500
				};
			}
			else if (id.StartsWith("B-"))
			{
				return new BronzeCustomer()
				{
					ID = id,
					Name = "Bronze Customer",
					City = "Cleveland",
					State = "OH",
					Age = 26,
					BasePoints = 300
				};
			}
			else
			{
				return Customer.NULL;
			};
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Factory Method Pattern: Customers";
			Console.WindowHeight = (int)(Console.LargestWindowHeight * 0.75);
			Console.BufferHeight = 5000;

			Console.WriteLine(
				"\n Create and display customers using CustomerFactory.\n");

			// Request Gold Customer: G-123
			Customer customer = CustomerFactory.CreateCustomer("G-123");

			Console.WriteLine(
				"\n{0}: {1}, Age: {2}, Location: {3}, {4} Total Points: {5}",
				customer.ID, customer.Name, customer.Age, customer.City,
				customer.State, customer.CalculateTotalPoints());

			// Request Silver Customer: S-456
			customer = CustomerFactory.CreateCustomer("S-456");

			Console.WriteLine(
				"\n{0}: {1}, Age: {2}, Location: {3}, {4} Total Points: {5}",
				customer.ID, customer.Name, customer.Age, customer.City,
				customer.State, customer.CalculateTotalPoints());

			// Request Bronze Customer: B-789
			customer = CustomerFactory.CreateCustomer("B-789");

			Console.WriteLine(
				"\n{0}: {1}, Age: {2}, Location: {3}, {4} Total Points: {5}",
				customer.ID, customer.Name, customer.Age, customer.City,
				customer.State, customer.CalculateTotalPoints());

			// Request Bronze Customer: B891
			customer = CustomerFactory.CreateCustomer("B891");

			Console.WriteLine(
				"\n{0}: {1}, Age: {2}, Location: {3}, {4} Total Points: {5}",
				customer.ID, customer.Name, customer.Age, customer.City,
				customer.State, customer.CalculateTotalPoints());


			Console.WriteLine();

			Console.ReadKey();
		}

	}
}


