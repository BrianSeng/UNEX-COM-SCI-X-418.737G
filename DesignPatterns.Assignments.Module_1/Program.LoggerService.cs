using System;
using System.IO;

namespace DesignPatterns.Assignments.Module_1
{
	public interface ILoggerService
	{
		void LogInfo(string msg, params object[] args);
		void LogError(string msg, params object[] args);
	}

	public class ConsoleLogger : ILoggerService
	{
		public void LogInfo(string msg, params object[] args)
		{
			Console.WriteLine(
				"{0} INFO: {1}"
				, DateTime.Now
				, string.Format(msg, args));
		}
		public void LogError(string msg, params object[] args)
		{
			Console.WriteLine(
				"{0} ERROR: {1}"
				, DateTime.Now
				, string.Format(msg, args));
		}
	}

	public class FileLogger : ILoggerService
	{
		private readonly string _fileName;

		// public constructor
		public FileLogger(string fileName)
		{
			_fileName = fileName;

			// Create a file to write to if it doesn't exist
			if (!File.Exists(_fileName))
			{
				string createText = "File Logger Test" + Environment.NewLine;
				File.WriteAllText(_fileName, createText);
			}
		}

		public void LogInfo(string msg, params object[] args)
		{
			string appendText = string.Format(msg, args) + Environment.NewLine;
			File.AppendAllText(_fileName, appendText);
		}
		public void LogError(string msg, params object[] args)
		{
			string appendText = string.Format(msg, args) + Environment.NewLine;
			File.AppendAllText(_fileName, appendText);
		}
	}

	public class BankAccount
	{
		private ILoggerService _logger;

		// public constructor
		public BankAccount(string id, ILoggerService logger)
		{
			_logger = logger;
			ID = id;

			logger.LogInfo("Creating Bank Account {0}", ID);
		}

		public string ID { get; private set; }

		public decimal Balance { get; private set; }

		public void Deposit(decimal amount)
		{
			_logger.LogInfo("Deposit requested: {0:c}", amount);

			if (amount <= 0)
			{
				_logger.LogError("Deposit rejected: must be positive");
				return;
			}

			_logger.LogInfo("Old Balance: {0:c}", Balance);
			Balance += amount;
			_logger.LogInfo("New Balance: {0:c}", Balance);
		}

		public void Withdraw(decimal amount)
		{
			_logger.LogInfo("Withdrawal requested: {0:c}", amount);

			if (amount <= 0)
			{
				_logger.LogError("Withdrawal rejected: must be positive");
				return;
			}

			_logger.LogInfo("Old Balance: {0:c}", Balance);
			Balance += amount;
			_logger.LogInfo("New Balance: {0:c}", Balance);
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Dependency Injection: Logger Example";
			Console.WindowHeight = (int)(Console.LargestWindowHeight * 0.75);
			Console.BufferHeight = 5000;

			// Test the Console Logger
			ILoggerService cLogger = new ConsoleLogger();
			BankAccount bAcct1 = new BankAccount("56782-04513", cLogger);
			bAcct1.Deposit(250m);
			bAcct1.Withdraw(100m);
			bAcct1.Withdraw(160m);

			// Test the File Logger
			ILoggerService fLogger = new FileLogger("acct-56283-92465.txt");
			BankAccount bAcct2 = new BankAccount("56283-92465", fLogger);
			bAcct2.Deposit(1000m);
			bAcct2.Withdraw(300m);
			bAcct2.Withdraw(170m);
			bAcct2.Deposit(200m);

			Console.ReadLine();
		}
	}
}
