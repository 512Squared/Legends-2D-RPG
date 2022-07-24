using System;
using System.IO;
using UnityEngine;

public static class FileManager
{
    public static bool WriteToFile(string a_FileName, string a_FileContents)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, a_FileName);

        try
        {
            File.WriteAllText(fullPath, a_FileContents);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to write to {fullPath} with exception {e}");
            return false;
        }
    }

    public static bool LoadFromFile(string a_FileName, out string result)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, a_FileName);

        try
        {
            result = File.ReadAllText(fullPath);
            return true;
        }
        catch (Exception)
        {
            SaveDataManager.GetInitialData();
            WriteToFile("SaveData.dat", SaveDataManager.InitialData);
            result = File.ReadAllText(fullPath);
            return true;
        }
    }

    public static void DeleteFile(string a_Filename)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, a_Filename);
        File.Delete(fullPath);
    }
}