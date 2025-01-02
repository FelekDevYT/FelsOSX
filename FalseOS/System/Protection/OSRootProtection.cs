namespace FalseOS.System.Protection;

public class OSRootProtection
{
    public bool isRootPermission = false;
    public bool isCanRunFShellFiles = false;
    public bool isCanRunLuaScripts = false;

    public OSRootProtection(bool isRootPermission, bool isCanRunFShellFiles, bool isCanRunLuaScript)
    {
        this.isRootPermission = isRootPermission;
        this.isCanRunFShellFiles = isCanRunFShellFiles;
        this.isCanRunLuaScripts = isCanRunLuaScript;
    }
}