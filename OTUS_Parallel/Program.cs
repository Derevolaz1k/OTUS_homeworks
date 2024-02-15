using System.Diagnostics;
using System.Text;

var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var folderOfHomeWork = $"{desktopPath}/OTUS_Parallel";
Directory.CreateDirectory(folderOfHomeWork);
var filePaths = new List<string>(){$"{folderOfHomeWork}/File1.txt",$"{folderOfHomeWork}/File2.txt",$"{folderOfHomeWork}/File3.txt"};
var textInFiles = new List<string>() { "O T U S", "OT US", "O TU S" };
for (var index = 0; index < filePaths.Count; index++)
{
    using var sw = File.CreateText(filePaths[index]);
    sw.Write(textInFiles[index]);
}

var stopwatchFiles = new Stopwatch();
stopwatchFiles.Start();
var tasks = filePaths.Select(GetCountSpace).ToArray();
await Task.WhenAll(tasks);
stopwatchFiles.Stop();

foreach (var task in tasks)
{
    Console.WriteLine($"Space count: {task.Result}");
}

Console.WriteLine($"stopwatchFiles: {stopwatchFiles.ElapsedTicks}");
var stopwatchDirectory = new Stopwatch();
stopwatchDirectory.Start();
var spaceCountInDirectory = await GetCountSpaceInDirectory(folderOfHomeWork);
stopwatchDirectory.Stop();
Console.WriteLine($"Space count in Directory: {spaceCountInDirectory}");
Console.WriteLine($"stopwatchDirectory: {stopwatchDirectory.ElapsedTicks}");

async Task<int> GetCountSpace(string path)
{
    byte[] bytes;
    using (var sourceStream = File.Open(path, FileMode.Open))
    {
        bytes = new byte[sourceStream.Length];
        await sourceStream.ReadAsync(bytes, 0, (int)sourceStream.Length);
    }
    var result = Encoding.UTF8.GetString(bytes);
    const char symbol = ' ';
    return result.Count(ch => ch == symbol);
}

async Task<int> GetCountSpaceInDirectory(string path)
{
    var files = Directory.GetFiles(path);
    var txtFiles = files.Where(f => f.Contains(".txt"));
    var tasks = txtFiles.Select(GetCountSpace).ToArray();
    await Task.WhenAll(tasks);
    return tasks.Sum(t => t.Result);
}