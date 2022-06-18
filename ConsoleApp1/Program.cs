// See https://aka.ms/new-console-template for more information
using DMS.Utils.CasingStyleConverter;

Console.WriteLine("Hello, World!");
var raw = CaseConverter.AnalyseCasing("normal text");
var camel = CaseConverter.AnalyseCasing("camelCase");
var pascal = CaseConverter.AnalyseCasing("PascalCase");
var kebab = CaseConverter.AnalyseCasing("kebab-case");
var snake = CaseConverter.AnalyseCasing("snake_case");

Console.WriteLine($"raw is {raw.Casing}");       //raw is Unknown
Console.WriteLine($"camel is {camel.Casing}");   //camel is CamelCase
Console.WriteLine($"pascal is {pascal.Casing}"); //pascal is PascalCase
Console.WriteLine($"kebab is {kebab.Casing}");   //kebab is KebabCase
Console.WriteLine($"snake is {snake.Casing}");   //snake is SnakeCase
Console.WriteLine();
Console.WriteLine(CaseConverter.Convert("camelCaseToSnakeCase", Casing.SnakeCase));              //camel_case_to_snake_case
Console.WriteLine(CaseConverter.Convert("PascalCaseToCamelCase", Casing.CamelCase));             //pascalCaseToCamelCase
Console.WriteLine(CaseConverter.Convert("snake_case_to_kebab", Casing.KebabCase));               //snake-case-to-kebab
Console.WriteLine(CaseConverter.Convert("kebab-case-to-pascal-case", Casing.PascalCase));        //KebabCaseToPascalCase
Console.WriteLine(CaseConverter.Convert("Raw normal text to camel casing", Casing.CamelCase));   //rawNormalTextToCamelCasing
Console.WriteLine(CaseConverter.Convert("RawMessed_up_text-toPascalCasing", Casing.PascalCase)); //RawMessedUpTextToPascalCasing