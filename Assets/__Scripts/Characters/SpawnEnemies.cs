using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemies : SingletonMonobehaviour<SpawnEnemies>, ISaveable
{
    public Transform[] homesteadSpawnPoints;
    [Space] public Transform[] mountainsSpawnPoints;
    [Space] public Transform[] dungeonSpawnPoints;
    [Space] public Transform[] shop1SpawnPoints;
    [Space] public Transform[] shop2SpawnPoints;
    [Space] public Transform[] shop3SpawnPoints;
    [Space] public Transform[] houseHNorthSpawnPoints;
    [Space] public Transform[] houseHSouthSpawnPoints;
    [Space] public Transform[] houseHWestSpawnPoints;
    [Space] public Transform[] houseMNorthSpawnPoints;
    [Space] public Transform[] houseMSouthSpawnPoints;
    [Space] public Transform[] houseMWestSpawnPoints;
    [Space] public Transform[] townSpawnPoints;

    private List<GameObject> spawnedZombies;
    private List<GameObject> spawnedSkellies;
    private List<GameObject> spawnedGoblins;

    public List<Transform[]> sceneSpawnArrays;

    private int index;


    private void Start()
    {
        spawnedZombies = new List<GameObject>();
        spawnedSkellies = new List<GameObject>();
        spawnedGoblins = new List<GameObject>();
        sceneSpawnArrays = new List<Transform[]>
        {
            homesteadSpawnPoints,
            mountainsSpawnPoints,
            dungeonSpawnPoints,
            shop1SpawnPoints,
            shop2SpawnPoints,
            shop3SpawnPoints,
            houseHNorthSpawnPoints,
            houseHSouthSpawnPoints,
            houseHWestSpawnPoints,
            houseMNorthSpawnPoints,
            houseMSouthSpawnPoints,
            houseMWestSpawnPoints,
            townSpawnPoints
        };
    }


    public void SpawnZombie(float chaseRange, int hitPoints)
    {
        Transform zombieRandomSpawnPoint = GetRandomSpawnPoint();
        GameObject newZombie = Instantiate(GameAssets.Fetch.zombie, zombieRandomSpawnPoint, true);
        newZombie.transform.position = zombieRandomSpawnPoint.position;
        newZombie.transform.SetParent(SpawnPoints()[index]);
        spawnedZombies.Add(newZombie);
        newZombie.GetComponent<ZombieController>().homeScene = FindObjectOfType<LevelManager>().scene;
        newZombie.GetComponent<GenerateGUID>().CreateNewGUID();
        Debug.Log($"Zombie spawned at {SpawnPoints()[index].name} | ");
        newZombie.GetComponent<ZombieController>().chaseRange = chaseRange;
        newZombie.GetComponent<ZombieController>().hitPoints = hitPoints;
    }

    public void SpawnSkelly()
    {
        Transform skellyRandomSpawnPoint = GetRandomSpawnPoint();
        GameObject newSkelly = Instantiate(GameAssets.Fetch.skelly, skellyRandomSpawnPoint);
        newSkelly.transform.position = skellyRandomSpawnPoint.position;
        newSkelly.transform.SetParent(SpawnPoints()[index]);
        spawnedSkellies.Add(newSkelly);
        newSkelly.GetComponent<ZombieController>().homeScene = FindObjectOfType<LevelManager>().scene;
        newSkelly.GetComponent<GenerateGUID>().CreateNewGUID();
        Debug.Log($"Skelly spawned at {SpawnPoints()[index].name}");
    }


    public void SpawnGoblin()
    {
        Transform goblinRandomSpawnPoint = GetRandomSpawnPoint();
        GameObject newGoblin = Instantiate(GameAssets.Fetch.skelly, goblinRandomSpawnPoint);
        newGoblin.transform.position = goblinRandomSpawnPoint.position;
        newGoblin.transform.SetParent(SpawnPoints()[index]);
        spawnedGoblins.Add(newGoblin);
        newGoblin.GetComponent<ZombieController>().homeScene = FindObjectOfType<LevelManager>().scene;
        newGoblin.GetComponent<GenerateGUID>().CreateNewGUID();
        Debug.Log($"Goblin spawned at {SpawnPoints()[index].name}");
    }


    private Transform GetRandomSpawnPoint()
    {
        index = Random.Range(0, SpawnPoints().Length);
        Transform randomSpawnPoint = SpawnPoints()[index];
        Debug.Log($"Random spawn point: {randomSpawnPoint.name}");
        return randomSpawnPoint;
    }

    private Transform[] SpawnPoints() // scene specific
    {
        Transform[] currentSceneSpawnArray = sceneSpawnArrays[SceneManager.GetActiveScene().buildIndex];
        return currentSceneSpawnArray;
    }


    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        SaveData.EnemySpawnData enemySpawnData = new(spawnedZombies, spawnedSkellies, spawnedGoblins);

        a_SaveData.enemySpawnData.Add(enemySpawnData);
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
    }

    #endregion
}