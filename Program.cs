//Episod 1,2

using MrX.DynamicCompiler;
using MrX.DynamicCompiler.Compile;
using MrX.DynamicCompiler.CompilerData;

new Configuration(args);
new ReadFile(Statics.MainFilePath);
new Tokenizer();
new ChackTheTokensByGramer();

var t = Statics.L_Tokens;
Console.WriteLine(Statics.Grammar);
Console.WriteLine(Statics.Labals);
Console.WriteLine(Statics.L_Splits);
Console.WriteLine(Statics.L_Tokens);