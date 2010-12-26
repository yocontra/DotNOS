using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace GIOR.Util
{
    public static class Cecil
    {
        //These extend AssemblyDefinition and allow me to assembly.hasStrongName() instead of Cecil.hasStrongName(assembly)
        public static bool HasStrongName(this AssemblyDefinition asm)
        {
            return asm.Name.HasPublicKey;
        }

        public static void RemoveStrongName(this AssemblyDefinition asm)
        {
            asm.Name.PublicKey = new byte[0];
            asm.Name.PublicKeyToken = new byte[0];
            asm.Name.IsSideBySideCompatible = true;
        }
        public static int ReplaceInvalids(this MethodDefinition method)
        {
            List<Instruction> InstToNop = new List<Instruction>();
            foreach (Instruction t in method.Body.Instructions)
            {
                switch (t.OpCode.Code)
                {
                    case Code.Invalid:
                        InstToNop.Add(t);
                        break;
                }
            }
            foreach (Instruction t in InstToNop)
            {
                method.Body.CilWorker.Replace(t, method.Body.CilWorker.Create(OpCodes.Nop));
            }
            return InstToNop.Count;
        }
        public static MethodDefinition AppendMethod(this MethodDefinition inputMethod, MethodDefinition appendMethod)
        {
            int count = inputMethod.Body.Instructions.Count;
            if (count > 0)
            {
                inputMethod.Body.CilWorker.Remove(inputMethod.Body.Instructions[count - 1]);
            }
            for (int x = 0; x < appendMethod.Body.Instructions.Count; x++)
            {
                inputMethod.Body.CilWorker.Append(appendMethod.Body.Instructions[x]);
            }
            return inputMethod;
        }
    }
}