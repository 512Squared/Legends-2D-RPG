using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneHandling : MonoBehaviour
{
    
    public enum SceneObjectsLoad { building, homestead, mountain, dungeon, house_h_north, house_h_south, house_h_west, house_m_north, house_m_south, house_m_west, shop1, shop2, shop3, town }
    public SceneObjectsLoad sceneObjectsLoad;

    public enum SceneObjectsUnload { building, homestead, mountain, dungeon, house_h_north, house_h_south, house_h_west, house_m_north, house_m_south, house_m_west, shop1, shop2, shop3, town }
    public SceneObjectsUnload sceneObjectsUnload;
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
