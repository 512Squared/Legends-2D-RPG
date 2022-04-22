public interface ISaveable
{
    void PopulateSaveData(SaveData a_SaveData);
    void LoadFromSaveData(SaveData a_SaveData);

    // this is different from the SaveJsonData and LoadJsonData that sits on the GameManager - that writes to file
    // these two interface methods write the data to Json
}