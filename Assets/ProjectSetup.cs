using UnityEngine;
using UnityEditor;
using System.IO;

public class ProjectSetup
{
    [MenuItem("Tools/Create Project Structure")]
    public static void CreateProjectStructure()
    {
        string rootPath = Application.dataPath;

        // Create main folders
        string[] folders = new string[]
        {
            "Animations",
            "Audio",
            "Materials",
            "Prefabs",
            "Scenes",
            "Scripts",
            "UI"
        };

        foreach (string folder in folders)
        {
            string path = Path.Combine(rootPath, folder);
            if (!AssetDatabase.IsValidFolder(path))
            {
                AssetDatabase.CreateFolder("Assets", folder);
            }
        }

        // Create a sample script in Scripts folder
        string scriptPath = Path.Combine(rootPath, "Scripts", "SampleScript.cs");
        if (!File.Exists(scriptPath))
        {
            File.WriteAllText(scriptPath, 
@"using UnityEngine;

public class SampleScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log(""Hello, World!"");
    }
}");
            AssetDatabase.Refresh();
        }

        // Create a sample scene in Scenes folder
        string scenePath = Path.Combine(rootPath, "Scenes", "MainScene.unity");
        if (!File.Exists(scenePath))
        {
            EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(), scenePath);
        }

        AssetDatabase.Refresh();
        Debug.Log("Project structure created successfully!");
    }
}
