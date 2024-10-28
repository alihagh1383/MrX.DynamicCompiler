//Episod 2

using MrX.DynamicCompiler.CompilerData.Types;
using MrX.DynamicCompiler.Static;

namespace MrX.DynamicCompiler.CompilerData.Languages;

public class Python
{
    public Python()
    {
        //////////////////////////////////////////////
        /// Other
        //////////////////////////////////////////////
        StaticWorker.AddLabal("=", new(Statics.LabalTypes.Equal, null));
        StaticWorker.AddLabal("(", new(Statics.LabalTypes.StartParameter, null));
        StaticWorker.AddLabal(")", new(Statics.LabalTypes.EndParameter, null));
        StaticWorker.AddLabal("*", new(Statics.LabalTypes.Multiply, null));
        StaticWorker.AddLabal("/", new(Statics.LabalTypes.Divide, null));
        StaticWorker.AddLabal("+", new(Statics.LabalTypes.Plus, null));
        StaticWorker.AddLabal("-", new(Statics.LabalTypes.Minus, null));
        //////////////////////////////////////////////
        /// end Of Code
        //////////////////////////////////////////////
        StaticWorker.AddLabal("\n", new(Statics.LabalTypes.EndOfCode, null));
        //////////////////////////////////////////////
        /// Classs & Functions
        //////////////////////////////////////////////
        StaticWorker.AddLabal(
            "print",
            new(
                Statics.LabalTypes.FunctionName,
                new Function()
                {
                    Name = "Print"
                }
            ));
        //////////////////////////////////////////////
        /// Gramer
        //////////////////////////////////////////////
        // x = 5
        StaticWorker.AddGrammar(
            new List<Statics.LabalTypes>()
            {
                Statics.LabalTypes.Unknown, Statics.LabalTypes.Equal,
                Statics.LabalTypes.Any, Statics.LabalTypes.EndOfCode
            }, new Gramer(new(list =>
            {
                StaticWorker.AddLabal(list[1].Key, new KeyValuePair<Statics.LabalTypes, object>(
                    Statics.LabalTypes.VariableName, new Variable()
                    {
                        Name = list[1].Key,
                        Value = list[3].Key
                    }));
                return null;
            }))
        );
    }
}