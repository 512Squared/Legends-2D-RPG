using Sirenix.OdinInspector;
using UnityEngine;


public class GridDebugSwitch : MonoBehaviour
{
    [SerializeField] private GameObject heatMapBool;
    [SerializeField] private GameObject testScript;
    [SerializeField] private GameObject gridParent;

    [Button(ButtonSizes.Large)] [GUIColor(0.682f, 0.686f, 0.156f)]
    public void DebugToggle()
    {
        GridLines();
        HeatBool();
        TestScript();
    }

    private void GridLines()
    {
        if (gridParent != null)
        { switch (heatMapBool.activeInHierarchy)
        { case true:
                gridParent.transform.DisableAllChildObjects();
                break;
            case false:
                gridParent.transform.EnableAllChildObjects();
                break; } }
    }

    private void HeatBool()
    {
        if (heatMapBool != null)
        {
            switch (heatMapBool.activeInHierarchy)
            {
                case true:
                    heatMapBool.SetActive(false);
                    return;
                case false:
                    heatMapBool.SetActive(true);
                    break;
            }
        }
    }

    private void TestScript()
    {
        if (testScript != null)
        {
            switch (testScript.activeInHierarchy)
            {
                case true:
                    testScript.SetActive(false);
                    return;
                case false:
                    testScript.SetActive(true);
                    break;
            }
        }
    }
}