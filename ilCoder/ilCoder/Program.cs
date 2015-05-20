using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ilCoder
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (args.Length == 0) 
			{
				NormalILCoder.OpenNormalMode ();			
			} 
			else 
			{
				List<string> argss = new List<string>();

				foreach (var arg in args) 
				{
					if(arg.Length > 0)
						argss.Add (arg.Trim());
				}

				ArgILCoder.OpenArgMode (argss);
			}
		}
	}

	class ArgumentNotFoundException : Exception {

		public ArgumentNotFoundException(string Message) : base(Message){
			
		}

		public override string Message {
			get {
				return base.Message;
			}
		}
	}
}
