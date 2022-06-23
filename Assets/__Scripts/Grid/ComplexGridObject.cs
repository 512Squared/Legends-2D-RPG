using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ComplexGridObject
{
    public static UnityEvent OnSceneChange = new();

    public Grid<ComplexGridObject> complexGrid;
    private int x;
    private int y;
    private string guid;

    private string letters;
    private string numbers;
    private bool booleans;
    private int integers;
    private float floatValues;


    public ComplexGridObject(Grid<ComplexGridObject> grid, int x, int y)
    {
        guid = Guid.NewGuid().ToString();
        complexGrid = grid;
        this.x = x;
        this.y = y;
        letters = "";
        numbers = "";
        integers = 0;
        booleans = false;
        floatValues = 0f;
        //OnSceneChange.AddListener(PopulateSaveData());
    }


    public void AddLetter(string letter)
    {
        letters += letter;
        complexGrid.TriggerGridObjectChanged(x, y);
    }

    public void SetBool(bool setBool)
    {
        booleans = setBool;
        complexGrid.TriggerGridObjectChanged(x, y);
    }

    public void AddFloat(float value)
    {
        floatValues = value;
        complexGrid.TriggerGridObjectChanged(x, y);
    }

    public void AddNumber(string number)
    {
        numbers += number;
        complexGrid.TriggerGridObjectChanged(x, y);
    }

    public string GetLetters()
    {
        return letters;
    }

    public string GetNumbers()
    {
        return numbers;
    }

    public bool GetBool()
    {
        return booleans;
    }

    public float GetFloat()
    {
        return floatValues;
    }


    public void RebuildComplexArray(int width, int row, int col, IReadOnlyList<string> lettersArray, IReadOnlyList<string> 
    numbersArray, IReadOnlyList<bool> booleansArray, IReadOnlyList<float> floatsArray)
    {
        complexGrid.gridArray[row, col].AddLetter(lettersArray[width * row + col]);
        complexGrid.gridArray[row, col].AddNumber(numbersArray[width * row + col]);
        complexGrid.gridArray[row, col].SetBool(booleansArray[width * row + col]);
        complexGrid.gridArray[row, col].AddFloat(floatsArray[width * row + col]);
    }


    public ComplexGridObject[,] ReturnData(out int x, out int y)
    {
        x = this.x;
        y = this.y;
        return complexGrid.gridArray;
    }

    public override string ToString()
    {
        return letters + "\n" + numbers;
    }
}