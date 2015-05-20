using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ilCoder
{
	public static class NormalILCoder
	{
		private static string filePath = null;
		private static string className = null;
		private static string methodName = null;
		private static string outputFile = null;

		public static void OpenNormalMode(){
			while (true) {
				Console.Write ("Enter path to Binary File : ");	
				filePath = Console.ReadLine ().Trim ();
				if (!File.Exists (filePath)) {
					Console.WriteLine ("There is not a file Path : {0}\n", filePath);
					continue;
				}
				if (!(Path.GetExtension (filePath) == ".exe" || Path.GetExtension (filePath) == ".dll")) {
					Console.WriteLine ("This is not a binary file Path: {0}\n", filePath);
					continue;
				}

				break;
			}

			Console.Write ("Enter the name of class : ");
			className = Console.ReadLine ().Trim ();

			Console.Write ("Enter the name of method : ");
			methodName = Console.ReadLine ().Trim ();

			Console.Write ("Enter the path to output file (leaving it will give output on screen) : ");
			outputFile = Console.ReadLine ().Trim ();

			if (outputFile == "")
				outputFile = null;

			Shared.setUp (filePath, className, methodName, outputFile);
			Shared.showIL ();
		}
	}
}
	