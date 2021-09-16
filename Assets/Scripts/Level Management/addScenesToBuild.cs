using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Collections.Generic;
public class Add_Scenes
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
   
    
        
        static void OnBeforeSceneLoadRuntimeMethod()
        {
        
        List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
            List<string> SceneList = new List<string>();
            string MainFolder = "Assets/Scenes";


            DirectoryInfo d = new DirectoryInfo(@MainFolder);
            FileInfo[] Files = d.GetFiles("*.unity"); //Getting unity files

            foreach (FileInfo file in Files)
            {
                SceneList.Add(file.Name);
            }




            int i = 0;


            for (i = 0; i < SceneList.Count; i++)
            {
                string scenePath = MainFolder + "/" + SceneList[i];
                editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(scenePath, true));


            }

            EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
            Debug.Log("All new scenes added to build settings");
    }

    }


