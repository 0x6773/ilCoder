using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ilCoder
{
	public static class Shared
	{
		private static string filePath = null;
		private static string className = null;
		private static string methodName = null;
		private static string outputFile = null;

		public static void setUp(string _filePath, string _className,
			string _methodName, string _outputFile)
		{
			filePath = _filePath;
			className = _className;
			methodName = _methodName;
			outputFile = _outputFile;
		}

		public static void showIL()
		{
			try {
				StringBuilder ilCode = new StringBuilder ("");

				AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly (filePath);

				int i = 0, j = 0;
				foreach (TypeDefinition typedef in assembly.MainModule.Types) {
					if (typedef.Name == className) {
						j = i;
					}
					i++;
				}

				TypeDefinition type = assembly.MainModule.Types [j];

				i = 0;
				j = 0;

				foreach (MethodDefinition md in type.Methods) {
					if (md.Name == methodName) {
						j = i;
					}
					i++;
				}

				MethodDefinition fmd = type.Methods [j];

				foreach (Instruction instr in fmd.Body.Instructions) {
					//if(instr.OpCode.ToString().Length > 12)
					//	ilCode.AppendFormat ("{0}\t{1}\t{2}\n", instr.Offset, instr.OpCode, instr.Operand);
					if(instr.OpCode.ToString().Length >= 8)
						ilCode.AppendFormat ("{0}\t{1}\t{2}\n", instr.Offset, instr.OpCode, instr.Operand);
					else
						ilCode.AppendFormat ("{0}\t{1}\t\t{2}\n", instr.Offset, instr.OpCode, instr.Operand);
				}

				if (outputFile == null)
					Console.WriteLine (ilCode.ToString ());
				else {
					using (var sr = new StreamWriter (outputFile)) {
						sr.Write (ilCode.ToString ());
					}
				}
			}
			catch { 
				Console.WriteLine ("Class Name or Method Name not Found!");
				Environment.Exit (1);
			}
		}
	}
}
