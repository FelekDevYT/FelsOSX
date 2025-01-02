
using System;
using FalseOS;

namespace UniLua
{
    using System.Diagnostics;

    internal class LuaOSLib
    {
        public const string LIB_NAME = "os";

        public static int OpenLib(ILuaState lua)
        {
            NameFuncPair[] define = new NameFuncPair[]
            {
                new NameFuncPair("getTime",OS_GetTime),
                new NameFuncPair("getVersion",OS_GetVersion),
                new NameFuncPair("getPath",OS_GetPath),
                new NameFuncPair("reboot",OS_Reboot),
                new NameFuncPair("shutdown",OS_Shutdown)
            };

            lua.L_NewLib(define);
            return 1;
        }

        private static int OS_Reboot(ILuaState lua)
        {
            Cosmos.System.Power.Reboot();
            return 1;
        }

        private static int OS_Shutdown(ILuaState lua)
        {
            Cosmos.System.Power.Shutdown();
            return 1;
        }

        private static int OS_GetPath(ILuaState lua)
        {
            lua.PushString(Kernel.Path);
            return 1;
        }

        private static int OS_GetVersion(ILuaState lua)
        {
            lua.PushString(Kernel.ver);
            return 1;
        }

        private static int OS_GetTime(ILuaState lua)
        {
            try
            {
                switch (lua.L_CheckString(1))
                {
                    case "DAY":
                        lua.PushString(DateTime.Now.Day.ToString());
                        return 1;
                    case "DAYOFWEEK":
                        lua.PushString(DateTime.Now.DayOfWeek.ToString());
                        return 1;
                    case "DATE":
                        lua.PushString(DateTime.Now.Date.ToString());
                        return 1;
                    case "HOUR":
                        lua.PushString(DateTime.Now.Hour.ToString());
                        return 1;
                    case "KIND":
                        lua.PushString(DateTime.Now.Kind.ToString());
                        return 1;
                    case "SECOND":
                        lua.PushString(DateTime.Now.Second.ToString());
                        return 1;
                    case "MILLISECOND":
                        lua.PushString(DateTime.Now.Millisecond.ToString());
                        return 1;
                    case "YEAR":
                        lua.PushString(DateTime.Now.Year.ToString());
                        return 1;
                    case "MONTH":
                        lua.PushString(DateTime.Now.Month.ToString());
                        return 1;
                    case "MINUTE":
                        lua.PushString(DateTime.Now.Minute.ToString());
                        break;
                }
            }
            catch (Exception ex)
            {
                lua.PushString(DateTime.Now.ToString());
            }
            return 1;
        }
    }
}

