// See https://aka.ms/new-console-template for more information
using DMS.Utils.CasingStyleConverter;

Console.WriteLine("Hello, World!");
var raw = CaseConverter.AnalyseCasing("normal text");
var camel = CaseConverter.AnalyseCasing("camelCase");
var pascal = CaseConverter.AnalyseCasing("PascalCase");
var kebab = CaseConverter.AnalyseCasing("kebab-case");
var snake = CaseConverter.AnalyseCasing("snake_case");

Console.WriteLine($"raw is {raw.Casing}");
Console.WriteLine($"camel is {camel.Casing}");
Console.WriteLine($"pascal is {pascal.Casing}");
Console.WriteLine($"kebab is {kebab.Casing}");
Console.WriteLine($"snake is {snake.Casing}");
Console.WriteLine();
Console.WriteLine(CaseConverter.Convert("camelCaseToSnakeCase", Casing.SnakeCase));
Console.WriteLine(CaseConverter.Convert("PascalCaseToCamelCase", Casing.CamelCase));
Console.WriteLine(CaseConverter.Convert("snake_case_to_kebab", Casing.KebabCase));
Console.WriteLine(CaseConverter.Convert("kebab-case-to-pascal-case", Casing.PascalCase));

Console.WriteLine(CaseConverter.Convert("Raw normal text to camel casing", Casing.CamelCase));

Console.WriteLine(CaseConverter.Convert("RawMessed_up_text-toPascalCasing", Casing.PascalCase));
