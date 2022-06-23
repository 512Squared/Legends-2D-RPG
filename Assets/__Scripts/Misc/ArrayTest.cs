using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;


public class ArrayTest : MonoBehaviour, ISaveable
{
    private const int X = 1;
    private const int Y = 1;
    private int[,] testArray = new int[X, Y];
    private static int[,] multiArray = new int[X,Y];
    private int[] oneDimensional = new int[X * Y];
    private List<int> toList = new ();
    private bool listSaved;

    private void Start()
    {
        CreateNewArray();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P)) { CreateNewArray(); }
        
        //if (Input.GetKeyDown(KeyCode.K)) { Flatten(); }
    }

    private void CreateNewArray()
    {
        StringBuilder sb = new();
        for (int i = 0; i < testArray.GetLength(0); i++)
        {
            for (int j = 0; j < testArray.GetLength(1); j++)
            {
                SetValue(i, j);
                sb.Append(testArray[i, j]);
                sb.Append(", ");
            }

            sb.AppendLine();
        }

        //Debug.Log(sb.ToString());
    }

    private void SetValue(int x, int y)
    {
        int value = Random.Range(1, 20);
        testArray[x, y] = value;
    }

    private void Flatten()
    {
        oneDimensional = Helpers.Flatten(testArray);
        Helpers.SingleArrayToConsole(oneDimensional);
    }


    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        listSaved = true;
        a_SaveData.gridData.isSaved = listSaved;
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        listSaved = a_SaveData.gridData.isSaved;

        if (listSaved)
        {
            // oneDimensional = a_SaveData.gridData.intArray2;
            // //toList = oneDimensional.ToList();
            // Debug.Log("ArrayList = " + string.Join("", toList.ConvertAll(i => i + ",")
            //     .ToArray()));
            // testArray = Helpers.SingleToMulti(oneDimensional, X, Y);
            // Helpers.MultiArrayToConsole(testArray);
        }
    }

    #endregion
}