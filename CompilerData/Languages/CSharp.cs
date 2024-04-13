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
        StaticWorker.AddLabal("*", new(Statics.LabalTypes.Multiply, null));
        StaticWorker.AddLabal("/", new(Statics.LabalTypes.Divide, null));
        StaticWorker.AddLabal("+", new(Statics.LabalTypes.Plus, null));
        StaticWorker.AddLabal("-", new(Statics.LabalTypes.Minus, null));
        StaticWorker.AddLabal("%", new(Statics.LabalTypes.DivideRemaining, null));
        StaticWorker.AddLabal("{", new(Statics.LabalTypes.StartBlack, null));
        StaticWorker.AddLabal("}", new(Statics.LabalTypes.EndBlock, null));
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
        /// Types
        //////////////////////////////////////////////
        StaticWorker.AddLabal("void", new(Statics.LabalTypes.FunctionType, null));
        StaticWorker.AddLabal("int", new(Statics.LabalTypes.VariableType, null));
        StaticWorker.AddLabal("int", new(Statics.LabalTypes.FunctionType, null));
        StaticWorker.AddLabal("string", new(Statics.LabalTypes.VariableType, null));
        StaticWorker.AddLabal("string", new(Statics.LabalTypes.FunctionType, null));
        //////////////////////////////////////////////
        /// Gramer
        //////////////////////////////////////////////
        // int x = 5;
        StaticWorker.AddGrammar(
            new List<Statics.LabalTypes>()
            {
                Statics.LabalTypes.VariableType, Statics.LabalTypes.Unknown, Statics.LabalTypes.Equal,
                Statics.LabalTypes.Any, Statics.LabalTypes.EndOfCode
            }, new Gramer(new(list =>
            {
                StaticWorker.AddLabal(list[1], new KeyValuePair<Statics.LabalTypes, object>(
                    Statics.LabalTypes.VariableName, new Variable()
                    {
                        Name = list[1],
                        Value = list[3]
                    }));
                return null;
            }))
        );
        // int x;
        StaticWorker.AddGrammar
        (
            new List<Statics.LabalTypes>()
            {
                Statics.LabalTypes.VariableType, Statics.LabalTypes.Unknown, Statics.LabalTypes.EndOfCode
            }, new Gramer(new(list =>
            {
                StaticWorker.AddLabal(list[1], new KeyValuePair<Statics.LabalTypes, object>(
                    Statics.LabalTypes.VariableName, new Variable()
                    {
                        Name = list[1],
                        Value = null
                    }));
                return null;
            }))
        );
        // x = 5;
        StaticWorker.AddGrammar
        (
            new List<Statics.LabalTypes>()
            {
                Statics.LabalTypes.VariableName, Statics.LabalTypes.Equal, Statics.LabalTypes.Any,
                Statics.LabalTypes.EndOfCode
            }, new Gramer(new(list =>
            {
                StaticWorker.AddLabal(list[1], new KeyValuePair<Statics.LabalTypes, object>(
                    Statics.LabalTypes.VariableName, new Variable()
                    {
                        Name = list[1],
                        Value = null
                    }));
                return null;
            }))
        );
        // Class Hello {}
        StaticWorker.AddGrammar
        (
            new List<Statics.LabalTypes>()
            {
                Statics.LabalTypes.Class, Statics.LabalTypes.Unknown, Statics.LabalTypes.StartBlack,
                Statics.LabalTypes.Any, Statics.LabalTypes.EndBlock
            }, new Gramer(new(list =>
            {
                StaticWorker.AddLabal(list[1], new KeyValuePair<Statics.LabalTypes, object>(
                    Statics.LabalTypes.Class, new Class()
                    {
                        Name = list[1]
                    }));
                return null;
            }))
        );
        // void test(){}
        StaticWorker.AddGrammar
        (
            new List<Statics.LabalTypes>()
            {
                Statics.LabalTypes.FunctionType, Statics.LabalTypes.Unknown,
                Statics.LabalTypes.StartParameter, Statics.LabalTypes.Any, Statics.LabalTypes.EndParameter,
                Statics.LabalTypes.StartBlack, Statics.LabalTypes.Any, Statics.LabalTypes.EndBlock
            }, new Gramer(new(list =>
            {
                StaticWorker.AddLabal(list[1], new KeyValuePair<Statics.LabalTypes, object>(
                    Statics.LabalTypes.FunctionName, new Function()
                    {
                        Name = list[1]
                    }));
                return null;
            }))
        );
        // 
    }
}