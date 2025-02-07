
// TODO

using FalseOS.System;
using System;
using System.Data;
using System.IO;

namespace UniLua
{

	internal class  LuaIOLib
	{
		public const string LIB_NAME = "io";

		public static int OpenLib( ILuaState lua )
		{
			NameFuncPair[] define = new NameFuncPair[]
			{
				new NameFuncPair( "input", 		IO_Input ),
				new NameFuncPair( "write",      IO_Write),
				new NameFuncPair("writeLine", IO_WriteLine),
				new NameFuncPair("writeToFile", IO_WriteTextToFile),
				new NameFuncPair("readFromFile", IO_ReadTextFromFile),
				new NameFuncPair("createFile", IO_CreateFile),
				new NameFuncPair("createDirectory", IO_CreateDir)
            };

			lua.L_NewLib( define );
			return 1;
		}

		private static int IO_CreateDir(ILuaState lua)
		{ 
			Directory.CreateDirectory(lua.L_CheckString(1));
			return 1;
		}

		private static int IO_CreateFile(ILuaState lua)
		{
			File.Create(lua.L_CheckString(1));
			return 1;
		}

		private static int IO_ReadTextFromFile(ILuaState lua)
		{
			lua.PushString(File.ReadAllText(lua.L_CheckString(1)));
			return 1;
		}

		private static int IO_WriteTextToFile(ILuaState lua)
		{
			File.WriteAllText(lua.L_CheckString(1),lua.L_CheckString(2));
			return 1;
		}

		private static int IO_Write( ILuaState lua)
		{
			Console.Write(lua.L_CheckString(1));
			return 1;
		}

        private static int IO_WriteLine(ILuaState lua)
        {
            Console.WriteLine(lua.L_CheckString(1));
            return 1;
        }
        private static int IO_Input( ILuaState lua )
		{
			lua.PushString(Console.ReadLine());
			return 1;
		}
	}

}

