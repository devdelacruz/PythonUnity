using UnityEditor;
using UnityEditor.Scripting.Python;
using UnityEngine;

public class MenuItem_NewPythonScript2_Class : MonoBehaviour
{
   [MenuItem("Python Scripts/New Python Script2")]
   public static void NewPythonScript2()
   {
       PythonRunner.RunFile("Assets/Script/new_python_script2.py");
       }
};
