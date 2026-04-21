using UnityEditor;
using UnityEditor.Scripting.Python;
using UnityEngine;

public class MenuItem_NewPythonScript2_Class : MonoBehaviour
{
   [MenuItem("Python Scripts/PythonTestLog")]
   public static void NewPythonScript2()
   {
       PythonRunner.RunFile("Assets/Script/PythonTestLog.py");
       }
};
