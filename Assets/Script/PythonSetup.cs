using UnityEditor;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class PythonSetup
{
    [MenuItem("Tools/Python/Install Dependencies")]
    public static void InstallDependencies()
    {
        string pythonExe = FindPythonExecutable();
        string requirementsPath = Path.GetFullPath("Python/requirements.txt");

        if (string.IsNullOrEmpty(pythonExe))
        {
            UnityEngine.Debug.Log("Python not found on this machine.");
            return;
        }

        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = pythonExe;
        start.Arguments = $"-m pip install -r \"{requirementsPath}\"";
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        start.RedirectStandardError = true;
        start.CreateNoWindow = true;

        using (Process proc = Process.Start(start))
        {
            string output = proc.StandardOutput.ReadToEnd();
            string error = proc.StandardError.ReadToEnd();
            proc.WaitForExit();

            UnityEngine.Debug.Log(output);

            if (!string.IsNullOrEmpty(error))
                UnityEngine.Debug.Log(error);
        }

        UnityEngine.Debug.Log("Python dependencies installed.");
    }

    private static string FindPythonExecutable()
    {
#if UNITY_EDITOR_WIN
        // common Windows install locations
        string[] candidates =
        {
            @"python",
            @"py",
            @"C:\Python311\python.exe",
            @"C:\Python310\python.exe",
            @"C:\Users\" + System.Environment.UserName + @"\AppData\Local\Programs\Python\Python311\python.exe",
            @"C:\Users\" + System.Environment.UserName + @"\AppData\Local\Programs\Python\Python310\python.exe",
        };
#else
        string[] candidates =
        {
            "python3",
            "python"
        };
#endif

        foreach (var c in candidates)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = c,
                    Arguments = "--version",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var p = Process.Start(psi))
                {
                    p.WaitForExit();
                    if (p.ExitCode == 0)
                        return c;
                }
            }
            catch { }
        }

        return null;
    }
}