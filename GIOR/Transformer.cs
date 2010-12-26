using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GIOR.Util;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace GIOR
{
    class Transformer
    {
        public LogHandler Logger { get; set; }
        public string OriginalLocation { get; set; }
        public string NewLocation { get; set; }
        public AssemblyDefinition OriginalAssembly { get; set; }
        public AssemblyDefinition WorkingAssembly { get; set; }
        public bool HasIssue { get; set; }

        public Transformer(string fileLoc)
        {
            Logger = new LogHandler(GetType().Name);
            Logger.Log(Logger.Identifier + " Initialized.");
            OriginalLocation = fileLoc;
            NewLocation = OriginalLocation.Replace(".exe", "-new.exe");
        }
        public void Load()
        {
            try
            {
                OriginalAssembly = AssemblyFactory.GetAssembly(OriginalLocation);
                WorkingAssembly = OriginalAssembly;
            }
            catch
            {
                Logger.Log("Error Loading Assembly!");
                HasIssue = true;
                return;
            }
            if (WorkingAssembly.HasStrongName())
            {
                Logger.Log("Strongname found, removing...");
                WorkingAssembly.RemoveStrongName();
            }
            Logger.Log("Assembly Loaded.");
        }
        public void Transform()
        {
            Logger.Log("Starting Transformer");
            foreach (TypeDefinition type in WorkingAssembly.MainModule.Types)
            {
                foreach (MethodDefinition method in type.Methods)
                {
                    if (!method.HasBody) continue;
                    int replaced = method.ReplaceInvalids();
                    if (replaced > 0)
                    {
                        Logger.Log(replaced + " Invalid OpCodes replaced in " + method.Name);
                    }
                }
                foreach (MethodDefinition method in type.Constructors)
                {
                    if (!method.HasBody) continue;
                    int replaced = method.ReplaceInvalids();
                    if (replaced > 0)
                    {
                        Logger.Log(replaced + " Invalid OpCodes replaced in constructor " + method.Name);
                    }
                }
            }
        }
        public void Save()
        {
            Logger.Log("Saving Assembly");
            AssemblyFactory.SaveAssembly(WorkingAssembly, NewLocation);
        }
    }
}
