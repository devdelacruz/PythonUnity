using UnityEditor;
using UnityEditor.Scripting.Python;
using UnityEngine;

public class MenuItem_PythonNoiseGenerator_Class : MonoBehaviour
{
   [MenuItem("Python Scripts/PythonNoiseGenerator")]
   public static void PythonNoiseGenerator()
   {
       PythonRunner.RunFile("Assets/Script/PythonNoiseGenerator.py");
       }
};
