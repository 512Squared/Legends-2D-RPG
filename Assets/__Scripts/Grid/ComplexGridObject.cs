using System;


[Serializable]
public class ComplexGridObject
{
    public Grid<ComplexGridObject> complexGrid;
    private int x;
    private int y;

    private string gCost;
    private string hCost;
    private string fCost;
    private bool booleans;
    private int integers;
    private float floatValues;


    public ComplexGridObject(Grid<ComplexGridObject> grid, int x, int y)
    {
        complexGrid = grid;
        this.x = x;
        this.y = y;
        gCost = "";
        hCost = "";
        fCost = "";
        integers = 0;
        booleans = false;
        floatValues = 0f;
    }


    public void AddGCost(string letter)
    {
        gCost += letter;
        complexGrid.TriggerGridObjectChanged(x, y);
    }

    public void AddFCost(string letter)
    {
        fCost += letter;
        complexGrid.TriggerGridObjectChanged(x, y);
    }

    public void AddHCost(string letter)
    {
        hCost += letter;
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
        hCost += number;
        complexGrid.TriggerGridObjectChanged(x, y);
    }

    public void AddInteger(int integer)
    {
        integers += integer;
        complexGrid.TriggerGridObjectChanged(x, y);
    }

    public string GetGCost()
    {
        return gCost;
    }

    public string GetHCost()
    {
        return hCost;
    }

    public string GetFCost()
    {
        return fCost;
    }

    public bool GetBool()
    {
        return booleans;
    }

    public float GetFloat()
    {
        return floatValues;
    }

    public int GetInteger()
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
        return gCost + "\n" + fCost + "\n" + hCost;
    }
}