using System;


[Serializable]
public class ComplexGridObject
{
    public Grid<ComplexGridObject> complexGrid;
    private int x;
    private int y;

    private string letters;
    private string numbers;
    private bool booleans;
    private int integers;
    private float floatValues;


    public ComplexGridObject(Grid<ComplexGridObject> grid, int x, int y)
    {
        complexGrid = grid;
        this.x = x;
        this.y = y;
        letters = "";
        numbers = "";
        integers = 0;
        booleans = false;
        floatValues = 0f;
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

    public void AddInteger(int integer)
    {
        integers += integer;
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

    public int GetInterger()
    {
        return integers;
    }

    public ComplexGridObject[,] ReturnData(out int x, out int y)
    {
        x = this.x;
        y = this.y;
        return complexGrid.GridArray;
    }

    public override string ToString()
    {
        return letters + "\n" + numbers;
    }
}