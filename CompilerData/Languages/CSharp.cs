//Episod 2,4

using MrX.DynamicCompiler.CompilerData.NeadClasss;
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
                StaticWorker.AddLabal(list[1].Key, new KeyValuePair<Statics.LabalTypes, object>(
                    Statics.LabalTypes.VariableName, new Variable()
                    {
                        Name = list[1].Key,
                        Value = list[3].Key
                    }));

                foreach (var VARIABLE in Statics.L_Tokens.Where(p => p.Key == list[1].Key))
                {
                    VARIABLE.Value = Statics.LabalTypes.VariableName;
                }


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
                StaticWorker.AddLabal(list[1].Key, new KeyValuePair<Statics.LabalTypes, object>(
                    Statics.LabalTypes.VariableName, new Variable()
                    {
                        Name = list[1].Key,
                        Value = null
                    }));
                foreach (var VARIABLE in Statics.L_Tokens.Where(p => p.Key == list[1].Key))
                {
                    VARIABLE.Value = Statics.LabalTypes.VariableName;
                }

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
                StaticWorker.AddLabal(list[0].Key, new KeyValuePair<Statics.LabalTypes, object>(
                    Statics.LabalTypes.VariableName, new Variable()
                    {
                        Name = list[0].Key,
                        Value = null
                    }));
                foreach (var VARIABLE in Statics.L_Tokens.Where(p => p.Key == list[0].Key))
                {
                    VARIABLE.Value = Statics.LabalTypes.VariableName;
                }

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
                StaticWorker.AddLabal(list[1].Key, new KeyValuePair<Statics.LabalTypes, object>(
                    Statics.LabalTypes.Class, new Class()
                    {
                        Name = list[1].Key
                    }));
                return null;
            }))
        );
        // void test()
        // {
        // dghdghgfh
        // hdfhfghf
        // }
        StaticWorker.AddGrammar
        (
            new List<Statics.LabalTypes>()
            {
                Statics.LabalTypes.FunctionType, Statics.LabalTypes.Unknown,
                Statics.LabalTypes.StartParameter, Statics.LabalTypes.Any, Statics.LabalTypes.EndParameter,
                Statics.LabalTypes.StartBlack, Statics.LabalTypes.Any, Statics.LabalTypes.EndBlock,
            }, new Gramer(new(list =>
            {
                int OpenPram = 0, ClosePram = 0, OpenBlack = 0, CloseBlack = 0;
                int IndexOpenPram = -1, IndexOpenBlock = -1;
                List<KeyValue<string, Statics.LabalTypes>> Pram = new List<KeyValue<string, Statics.LabalTypes>>();
                List<KeyValue<string, Statics.LabalTypes>> Black = new List<KeyValue<string, Statics.LabalTypes>>();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Key == "(")
                    {
                        if (OpenPram == 0)
                            IndexOpenPram = i;
                        OpenPram++;
                    }

                    if (list[i].Key == ")")
                        ClosePram++;
                    if (list[i].Key == "{")
                    {
                        if (OpenBlack == 0)
                            IndexOpenBlock = i;
                        OpenBlack++;
                    }

                    if (list[i].Key == "}")
                        CloseBlack++;

                    if (OpenPram > 0 && OpenPram == ClosePram)
                    {
                        for (int j = IndexOpenPram; j > i; j++)
                        {
                            Pram.Add(list[j]);
                        }
                    }

                    if (OpenBlack > 0 && OpenBlack == CloseBlack)
                    {
                        for (int j = IndexOpenBlock; j > i; j++)
                        {
                            Black.Add(list[j]);
                        }
                    }
                }

                StaticWorker.AddLabal(list[1].Key, new KeyValuePair<Statics.LabalTypes, object>(
                    Statics.LabalTypes.FunctionName, new Function()
                    {
                        Name = list[1].Key,
                        Code = Black,
                        Prameter = Pram
                    }));
                return null;
            }))
        );
        // 
    }
}