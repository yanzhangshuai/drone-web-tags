using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static System.String;

var package =  File.ReadAllText("package.json");
var regex = new Regex("\"version\":[ ]*\"(.+)\"");
var env = Environment.GetEnvironmentVariable("PLUGIN_TAGS",
    RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
        ? EnvironmentVariableTarget.Machine
        : EnvironmentVariableTarget.Process);

var tags = new List<string>();
if (!IsNullOrEmpty(env))
    tags = env.Split(",").ToList();

var match = regex.Match(package);
if (match.Success)
    if(!IsNullOrWhiteSpace(match.Groups[1].Value)) tags.Add(match.Groups[1].Value);

Console.WriteLine($"tags:{Join(',', tags)}");

File.WriteAllText(".tags", Join(',', tags));
