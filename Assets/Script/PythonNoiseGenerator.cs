using UnityEditor;
using UnityEditor.Scripting.Python;

public class MenuItem_PythonNoiseGenerator_Class
{
   [MenuItem("Python Scripts/PythonNoiseGenerator")]
   public static void PythonNoiseGenerator()
   {
       PythonRunner.RunFile("Assets/Script/PythonNoiseGenerator.py");
       }
};
