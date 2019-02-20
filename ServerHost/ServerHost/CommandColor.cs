using System;

namespace ServerHost
{
	internal class CommandColor
	{
		public static void SetBackBlack()
		{
			Console.BackgroundColor = ConsoleColor.Black;
		}

		public static void SetBackRed()
		{
			Console.BackgroundColor = ConsoleColor.Red;
		}

		public static void SetBackWhite()
		{
			Console.BackgroundColor = ConsoleColor.White;
		}

		public static void SetBlack()
		{
			Console.ForegroundColor = ConsoleColor.Black;
		}

		public static void SetGreen()
		{
			Console.ForegroundColor = ConsoleColor.Green;
		}

		public static void SetRed()
		{
			Console.ForegroundColor = ConsoleColor.Red;
		}

		public static void SetWhite()
		{
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static void SetYellow()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
		}
	}
}
