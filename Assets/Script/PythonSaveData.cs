using UnityEditor;
using UnityEditor.Scripting.Python;
using UnityEngine;

public class MenuItem_PythonSaveData2_Class : MonoBehaviour
{
   [MenuItem("Python Scripts/PythonSaveData2")]
   public static void PythonSaveData2()
   {
       PythonRunner.RunFile("Assets/Script/PythonSaveData.py");
       }
};
