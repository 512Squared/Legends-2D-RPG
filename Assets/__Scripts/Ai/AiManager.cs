using System;
using UnityEngine;
using Pathfinding;
using Sirenix.OdinInspector;

public class AiManager : SingletonMonobehaviour<AiManager>
{
    private string path;
   
    private void Start()
    {
        AstarPath.active.Scan();
        Debug.Log($"Active scan completed");   
    }

    [Button(ButtonSizes.Large)]
    [GUIColor(0.282f, 0.286f, 0.556f)]
    public void ScanGraphs()
    {
       AstarPath.active.data.LoadFromCache();
    }
    
}