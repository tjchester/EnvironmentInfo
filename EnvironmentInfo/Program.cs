namespace EnvironmentInfo;

using System.Collections;
using System.Text;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Environment Info");

        Console.WriteLine($@"Environment.CommandLine: {Environment.CommandLine}");
        Console.WriteLine($@"Environment.CurrentDirectory: {Environment.CurrentDirectory}");
        Console.WriteLine($@"Environment.CurrentManagedThreadId: {Environment.CurrentManagedThreadId}");

        var environmentVariables = Environment.GetEnvironmentVariables()
            .Cast<DictionaryEntry>()
            .Select(x => KeyValuePair.Create(x.Key.ToString(), x.Value?.ToString()));
        foreach (var environmentVariable in environmentVariables.OrderBy(x => x.Key).ToList())
        {
            if (environmentVariable.Key!.Equals("PATH", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var path in Environment.GetEnvironmentVariable(environmentVariable.Key)!.Split(Path.PathSeparator))
                {
                    Console.WriteLine($@"Environment.EnvironmentVariable[{environmentVariable.Key}]: {path}");
                }
            }
            else
            {
                Console.WriteLine($@"Environment.EnvironmentVariable[{environmentVariable.Key}]: {Environment.GetEnvironmentVariable(environmentVariable.Key)}");
            }
        }

        var folderNames = Enum.GetNames<Environment.SpecialFolder>().OrderBy(x => x).ToList();
        foreach (var folderName in folderNames)
        {
            if (Enum.TryParse(typeof(Environment.SpecialFolder), folderName, out var folder))
            {
                Console.WriteLine($@"Environment.SpecialFolder[{folderName}]: {Environment.GetFolderPath((Environment.SpecialFolder)folder)}");
            }
        }

        Console.WriteLine($@"Environment.HasShutdownStarted: {Environment.HasShutdownStarted}");
        Console.WriteLine($@"Environment.Is64BitOperatingSystem: {Environment.Is64BitOperatingSystem}");
        Console.WriteLine($@"Environment.Is64BitProcess: {Environment.Is64BitProcess}");
        Console.WriteLine($@"Environment.IsPrivilegedProcess: {Environment.IsPrivilegedProcess}");

        foreach (var logicalDrive in Environment.GetLogicalDrives())
        {
            Console.WriteLine($@"Environment.LogicalDrive: {logicalDrive}");
        }

        Console.WriteLine($@"Environment.MachineName: {Environment.MachineName}");
        Console.WriteLine($@"Environment.NewLine: {GetHexString(Environment.NewLine)}");

        Console.WriteLine($@"Environment.OSVersion: {Environment.OSVersion}");
        Console.WriteLine($@"Environment.OSVersion.Platform: {Environment.OSVersion.Platform}");
        Console.WriteLine($@"Environment.OSVersion.ServicePack: {Environment.OSVersion.ServicePack}");
        Console.WriteLine($@"Environment.OSVersion.Version: {Environment.OSVersion.Version}");
        Console.WriteLine($@"Environment.OSVersion.VersionString: {Environment.OSVersion.VersionString}");

        Console.WriteLine($@"Environment.ProcessId: {Environment.ProcessId}");
        Console.WriteLine($@"Environment.ProcessPath: {Environment.ProcessPath}");
        Console.WriteLine($@"Environment.ProcessorCount: {Environment.ProcessorCount}");
        Console.WriteLine($@"Environment.StackTrace: {Environment.StackTrace}");
        Console.WriteLine($@"Environment.SystemDirectory: {Environment.SystemDirectory}");
        Console.WriteLine($@"Environment.SystemPageSize: {Environment.SystemPageSize} bytes");
        Console.WriteLine($@"Environment.TickCount: {Environment.TickCount}");
        Console.WriteLine($@"Environment.TickCount64: {Environment.TickCount64}");
        Console.WriteLine($@"Environment.UserDomainName: {Environment.UserDomainName}");
        Console.WriteLine($@"Environment.UserInteractive: {Environment.UserInteractive}");
        Console.WriteLine($@"Environment.UserName: {Environment.UserName}");

        Console.WriteLine($@"Environment.Version: {Environment.Version}");
        Console.WriteLine($@"Environment.Version.Build: {Environment.Version.Build}");
        Console.WriteLine($@"Environment.Version.Major: {Environment.Version.Major}");
        Console.WriteLine($@"Environment.Version.MajorRevision: {Environment.Version.MajorRevision}");
        Console.WriteLine($@"Environment.Version.Minor: {Environment.Version.Minor}");
        Console.WriteLine($@"Environment.Version.MinorRevision: {Environment.Version.MinorRevision}");
        Console.WriteLine($@"Environment.Version.Revision: {Environment.Version.Revision}");

        Console.WriteLine($@"Environment.WorkingSet: {Environment.WorkingSet} bytes");

        // OperatingSystem has static methods with info
    }

    private static string GetHexString(string input)
    {
        var byteArray = Encoding.UTF8.GetBytes(input);
        return Convert.ToHexString(byteArray);
    }
}