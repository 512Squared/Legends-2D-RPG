using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string ToJson()
    {
        return JsonUtility.ToJson(this, true);
    }

    public void LoadFromJson(string a_Json)
    {
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }

    [System.Serializable]
    public struct SceneData
    {
        public string currentScene;
        public int sceneObjects;
    }

    public SceneData sceneData;


    [System.Serializable]
    public struct QuestData
    {
    }

    public QuestData questData;


    [System.Serializable]
    public struct ItemsData
    {
    }

    public ItemsData itemsData = new();

    [System.Serializable]
    public struct CharacterData
    {
    }

    public CharacterData characterData;


    [System.Serializable]
    public struct ThulgranData
    {
        public int hitPoints;
        public Vector3 position;
    }

    public ThulgranData thulgranData;
}