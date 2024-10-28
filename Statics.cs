//Episod 1,2,4

using MrX.DynamicCompiler.CompilerData;
using MrX.DynamicCompiler.CompilerData.NeadClasss;

namespace MrX.DynamicCompiler;

public class Statics
{
    public static string MainFilePath { get; set; }
    public static List<string> L_Splits { get; } = new();
    public static List<KeyValue< string,LabalTypes>> L_Tokens { get; set; } = new();
    public static Dictionary<List<LabalTypes>, Gramer> Grammar { get; set; } = new();
    public static Dictionary<string, KeyValuePair<LabalTypes, object>> Labals { get; set; } = new();

    public enum LabalTypes
    {
        Any,
        Plus,
        Minus,
        Multiply,
        Divide,
        DivideRemaining,
        Power,
        StartBlack,
        EndBlock,
        Unknown,
        FunctionType,
        FunctionName,
        VariableType,
        VariableName,
        Class,
        Dot,
        Equal,
        Comment,
        Number,
        EndOfCode,
        StartParameter,
        EndParameter,
        Parameter,
    }
}