using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

#if DEBUG
    [assembly: AssemblyProduct("Exchange Client (Debug)")]
    [assembly: AssemblyConfiguration("Debug")]
#else
    [assembly: AssemblyProduct("Exchange Client (Release)")]
    [assembly: AssemblyConfiguration("Release")]
#endif

[assembly: ComVisible(false)]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("Developer Build")]
[assembly: InternalsVisibleToAttribute("ExchangeClientTest")]