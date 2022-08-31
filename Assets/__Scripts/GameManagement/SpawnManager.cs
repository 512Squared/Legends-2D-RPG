using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] SpawnEnemies spawnEnemies;

    [SerializeField] private List<Item> dropItems;

    private void OnEnable()
    {
        dropItems = new List<Item>();
    }
}