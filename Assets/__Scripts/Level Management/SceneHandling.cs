using UnityEngine;

public class SceneHandling : MonoBehaviour
{
    public SceneObjectsLoad sceneObjectsLoad;
    public SceneObjectsUnload sceneObjectsUnload;

    public void SetSceneObjects(string sceneName)
    {
        sceneObjectsLoad = sceneName switch
        {
            "Homestead" => SceneObjectsLoad.homestead,
            "Mountains" => SceneObjectsLoad.mountain,
            "Dungeon" => SceneObjectsLoad.dungeon,
            "shop1" => SceneObjectsLoad.shop1,
            "shop2" => SceneObjectsLoad.shop2,
            "shop3" => SceneObjectsLoad.shop3,
            "House_north" => SceneObjectsLoad.house_h_north,
            "House_h_south" => SceneObjectsLoad.house_h_south,
            "House_h_west" => SceneObjectsLoad.house_h_west,
            "House_m_north" => SceneObjectsLoad.house_m_north,
            "House_m_south" => SceneObjectsLoad.house_m_south,
            "House_m_west" => SceneObjectsLoad.house_m_west,
            "Town" => SceneObjectsLoad.town,
            _ => sceneObjectsLoad
        };
    }

    public static int SceneObjectsInt(SceneObjectsLoad startScene)
    {
        return startScene switch
        {
            SceneObjectsLoad.homestead => 1,
            SceneObjectsLoad.mountain => 2,
            SceneObjectsLoad.dungeon => 3,
            SceneObjectsLoad.shop1 => 4,
            SceneObjectsLoad.shop2 => 5,
            SceneObjectsLoad.shop3 => 6,
            SceneObjectsLoad.house_h_north => 7,
            SceneObjectsLoad.house_h_south => 8,
            SceneObjectsLoad.house_h_west => 9,
            SceneObjectsLoad.house_m_north => 10,
            SceneObjectsLoad.house_m_south => 11,
            SceneObjectsLoad.house_m_west => 12,
            SceneObjectsLoad.town => 13,
            _ => 1
        };
    }
}