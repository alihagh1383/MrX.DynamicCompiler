//Episod 2

using MrX.DynamicCompiler.CompilerData.Types;
using MrX.DynamicCompiler.Static;

namespace MrX.DynamicCompiler.CompilerData.Languages;

public class CSharp
{
    public CSharp()
    {
        //////////////////////////////////////////////
        /// Other
        //////////////////////////////////////////////
        StaticWorker.AddLabal("=", new(Statics.LabalTypes.Equal, null));
        StaticWorker.AddLabal("(", new(Statics.LabalTypes.StartParameter, null));
        StaticWorker.AddLabal(")", new(Statics.LabalTypes.EndParameter, null));
        //////////////////////////////////////////////
        /// end Of Code
        //////////////////////////////////////////////
        StaticWorker.AddLabal(";", new(Statics.LabalTypes.EndOfCode, null));
        //////////////////////////////////////////////
        /// Classs & Functions
        //////////////////////////////////////////////
        StaticWorker.AddLabal(
            "Console",
            new(
                Statics.LabalTypes.Class,
                new Class()
                {
                    Name = "Console",
                    ChildFunctions = new()
                    {
                        new Function()
                        {
                            Name = "Write"
                        },
                        new Function()
                        {
                            Name = "WriteLine"
                        }
                    }
                }));
        //////////////////////////////////////////////
        /// VariableTypes
        //////////////////////////////////////////////
        StaticWorker.AddLabal("int", new(Statics.LabalTypes.VariableType, null));
        //////////////////////////////////////////////
        /// Gramer
        //////////////////////////////////////////////
        StaticWorker.AddGrammar(
            new List<Statics.LabalTypes>()
            {
                Statics.LabalTypes.VariableType, Statics.LabalTypes.Unknown, Statics.LabalTypes.Equal,
                Statics.LabalTypes.Number, Statics.LabalTypes.EndOfCode
            },
            new Gramer(
                new(list =>
                {
                    StaticWorker.AddLabal(list[1], new KeyValuePair<Statics.LabalTypes, object>(
                        Statics.LabalTypes.VariableName, new Variable()
                        {
                            Name = list[1],
                            Value = list[3]
                        }));
                    return null;
                })
            )
        );
    }
}