public interface ISaveable
{
    string SaveableUniqueID { get; set; }

    GameItemsSave GameItemsSave { get; set; }

    void SaveableRegister();

    void SaveableDeregister();

    GameItemsSave SaveableSave();

    void SaveableLoad(GameSave gameSave);

    void SaveableStoreScene(string sceneName);

    void SaveableRestoreScene(string sceneName);
}