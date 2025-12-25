using Avalonia;
using System;

namespace CopyUserAction;

class Program
{
    // Initialization code. Don't use any Visual, System.Drawing or dotnet libraries from here, as it will break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}