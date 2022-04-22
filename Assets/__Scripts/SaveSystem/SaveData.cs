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

    public struct QuestData
    {
        
    }

    public struct ItemsData
    {
        
    }

    public struct CharacterData
    {
        
    }

    [System.Serializable]
    public struct ThulgranData
    {
        public int hitPoints;
        public Vector3 position;
    }
    
    public ThulgranData thulgranData = new ThulgranData();


}