using System.Collections.Generic;

[System.Serializable]
public class SceneSave
{
    public Dictionary<string, int> IntDictionary;
    public Dictionary<string, bool> BoolDictionary;    // string key is an identifier name we choose for this list
    public Dictionary<string, string> StringDictionary;
    public Dictionary<string, Vector3Serializable> Vector3Dictionary;
    public Dictionary<string, int[]> IntArrayDictionary;
    public List<SceneItem> listSceneItem;
    public List<ItemsManager>[] listInvItemArray;
}
