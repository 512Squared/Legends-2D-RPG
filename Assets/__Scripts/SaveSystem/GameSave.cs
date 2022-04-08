using System.Collections.Generic;

[System.Serializable]
public class GameSave
{
    // string key = GUID gameobject ID
    public Dictionary<string, GameItemsSave> GameItemsData;

    public GameSave()
    {
        GameItemsData = new Dictionary<string, GameItemsSave>();
    }
}