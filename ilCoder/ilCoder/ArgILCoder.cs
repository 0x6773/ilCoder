using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ilCoder
{
	public static class ArgILCoder
	{
		private static string filePath = null;
		private static string className = null;
		private static string methodName = null;
		private static string outputFile = null;

		public static void OpenArgMode(List<string> args)
		{
			try {
				if(!args.Contains ("-f")){
					throw new ArgumentNotFoundException("File Path Not Found");
				}
				if(!args.Contains ("-c")){
					throw new ArgumentNotFoundException("Class Not Given");
				}
				if(!args.Contains ("-m")){
					throw new ArgumentNotFoundException("File Path Not Given");
				}
				setUp(args);

			} catch (ArgumentNotFoundException e) {
				Console.WriteLine (e.Message);
				Environment.Exit (1);
			}
			finally {
				
			}
		}

		public static void setUp(List<string> args)
		{
			try{
				int index = args.FindIndex(s => s == "-f");
				filePath = args [index + 1].Trim();
				index = args.FindIndex (s => s == "-c");
				className = args [index + 1].Trim();
				index = args.FindIndex (s => s == "-m");
				methodName = args [index + 1].Trim();
				if(args.Contains("-o")) {
					index = args.FindIndex (s => s == "-o");
					outputFile = args [index + 1].Trim();
				}
				Shared.setUp(filePath, className, methodName, outputFile);
				Shared.showIL();
			}
			catch (Exception) {
				Console.WriteLine ("Input Error. Please check your Input.");
				Environment.Exit (1);
			}
			finally {

			}
		}
	}
}
	