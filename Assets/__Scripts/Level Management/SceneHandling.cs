using UnityEngine;

public class SceneHandling : MonoBehaviour
{
    public SceneObjectsLoad sceneObjectsLoad;
    public SceneObjectsUnload sceneObjectsUnload;

    public void SetSceneObjects(string sceneName)
    {
        sceneObjectsLoad = sceneName switch
        {
            "Homestead" => SceneObjectsLoad.Homestead,
            "Mountains" => SceneObjectsLoad.Mountain,
            "Dungeon" => SceneObjectsLoad.Dungeon,
            "shop1" => SceneObjectsLoad.Shop1,
            "shop2" => SceneObjectsLoad.Shop2,
            "shop3" => SceneObjectsLoad.Shop3,
            "House_north" => SceneObjectsLoad.HouseHNorth,
            "House_h_south" => SceneObjectsLoad.HouseHSouth,
            "House_h_west" => SceneObjectsLoad.HouseHWest,
            "House_m_north" => SceneObjectsLoad.HouseMNorth,
            "House_m_south" => SceneObjectsLoad.HouseMSouth,
            "House_m_west" => SceneObjectsLoad.HouseMWest,
            "Town" => SceneObjectsLoad.Town,
            _ => sceneObjectsLoad
        };
    }

    public static int SceneObjectsInt(SceneObjectsLoad startScene)
    {
        return startScene switch
        {
            SceneObjectsLoad.Homestead => 1,
            SceneObjectsLoad.Mountain => 2,
            SceneObjectsLoad.Dungeon => 3,
            SceneObjectsLoad.Shop1 => 4,
            SceneObjectsLoad.Shop2 => 5,
            SceneObjectsLoad.Shop3 => 6,
            SceneObjectsLoad.HouseHNorth => 7,
            SceneObjectsLoad.HouseHSouth => 8,
            SceneObjectsLoad.HouseHWest => 9,
            SceneObjectsLoad.HouseMNorth => 10,
            SceneObjectsLoad.HouseMSouth => 11,
            SceneObjectsLoad.HouseMWest => 12,
            SceneObjectsLoad.Town => 13,
            _ => 1
        };
    }
}