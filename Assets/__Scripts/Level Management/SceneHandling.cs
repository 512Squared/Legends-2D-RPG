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
            "Mountains" => SceneObjectsLoad.Mountains,
            "Dungeon" => SceneObjectsLoad.Dungeon,
            "Shop1" => SceneObjectsLoad.Shop1,
            "Shop2" => SceneObjectsLoad.Shop2,
            "Shop3" => SceneObjectsLoad.Shop3,
            "HouseHNorth" => SceneObjectsLoad.HouseHNorth,
            "HouseHSouth" => SceneObjectsLoad.HouseHSouth,
            "HouseHWest" => SceneObjectsLoad.HouseHWest,
            "HouseMNorth" => SceneObjectsLoad.HouseMNorth,
            "HouseMSouth" => SceneObjectsLoad.HouseMSouth,
            "HouseMWest" => SceneObjectsLoad.HouseMWest,
            "Town" => SceneObjectsLoad.Town,
            _ => sceneObjectsLoad
        };
    }

    public static int SceneObjectsInt(SceneObjectsLoad startScene)
    {
        return startScene switch
        {
            SceneObjectsLoad.Homestead => 1,
            SceneObjectsLoad.Mountains => 2,
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