using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandling : MonoBehaviour
{
    
    public enum SceneLoad { building, homestead, mountain, dungeon, house_h_north, house_h_south, house_h_west, house_m_north, house_m_south, house_m_west, shop1, shop2, shop3, town }
    public SceneLoad sceneLoad;

    public enum SceneUnload { building, homestead, mountain, dungeon, house_h_north, house_h_south, house_h_west, house_m_north, house_m_south, house_m_west, shop1, shop2, shop3, town }
    public SceneUnload sceneUnload;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
