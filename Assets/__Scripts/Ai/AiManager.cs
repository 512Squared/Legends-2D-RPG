using System;
using UnityEngine;
using Pathfinding;
using Sirenix.OdinInspector;

public class AiManager : SingletonMonobehaviour<AiManager>
{
    [SerializeField] private AIPath aiPath;
    private AstarPath path;
    public bool deBugging;

    private void Start()
    {
        path = AstarPath.active;
        path.Scan();
        if (GameManager.Instance.artificialIntelligence) { Debug.Log($"Active scan completed"); }

        foreach (NavGraph t in path.data.graphs)
        {
            if (deBugging) { Debug.Log($"Graph name: {t.name} | Index: {path.data.GetGraphIndex(t)}"); }
        }
    }

    [Button(ButtonSizes.Large)]
    [GUIColor(0.282f, 0.286f, 0.556f)]
    public void ScanGraphs()
    {
        path.data.LoadFromCache();
    }

    public void SetGraphForScene(string scene)
    {
    }
}