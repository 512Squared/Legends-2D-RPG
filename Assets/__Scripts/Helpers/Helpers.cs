using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Object = UnityEngine.Object;


public static class Helpers
{
    /// <summary>
    /// If newString is a duplicate the array will remain unchanged. 
    /// </summary>
    /// <param name="stringArray"></param>
    /// <param name="newString"></param>
    /// <returns></returns>
    public static string[] AddStringToArray(this string[] stringArray, string newString)
    {
        if (newString != null)
        {
            if (!stringArray.Contains(newString))
            {
                List<string> list = new(stringArray.ToList());
                list.Add(newString);
                stringArray = list.ToArray();
                return stringArray;
            }
            else if (stringArray.Contains(newString))
            {
                Debug.Log($"{newString} is already in the array");
                return stringArray;
            }

            else
            {
                return stringArray;
            }
        }
        else
        {
            return stringArray;
        }
    }

    /// <summary>
    /// If newString is not in the array, it will be added. If newString is a duplicate, the acceptDuplicates bool will determine if it will be added.
    /// </summary>
    /// <param name="stringArray"></param>
    /// <param name="newString"></param>
    /// <param name="acceptDuplicates"></param>
    /// <returns></returns>
    public static string[] AddStringToArray(this string[] stringArray, string newString, bool acceptDuplicates)
    {
        if (!acceptDuplicates && newString != null)
        {
            if (!stringArray.Contains(newString))
            {
                List<string> list = new(stringArray.ToList());
                list.Add(newString);
                stringArray = list.ToArray();
                return stringArray;
            }
            else if (stringArray.Contains(newString))
            {
                Debug.Log($"{newString} is already in the array");
                return stringArray;
            }

            else
            {
                return stringArray;
            }
        }

        else if (acceptDuplicates && newString != null)
        {
            List<string> list = new(stringArray.ToList());
            list.Add(newString);
            stringArray = list.ToArray();
            return stringArray;
        }

        else
        {
            return stringArray;
        }
    }

    /// <summary>
    /// If newInt is not in the array, it will be added. If newInt is a duplicate, the acceptDuplicates bool will determine if it will be added.
    /// </summary>
    /// <param name="intArray"></param>
    /// <param name="newInt"></param>
    /// <param name="acceptDuplicates"></param>
    /// <returns></returns>
    public static int[] AddIntToArray(this int[] intArray, int newInt, bool acceptDuplicates)
    {
        if (!acceptDuplicates)
        {
            if (!intArray.Contains(newInt))
            {
                List<int> list = new(intArray.ToList());
                list.Add(newInt);
                intArray = list.ToArray();
                return intArray;
            }
            else if (intArray.Contains(newInt))
            {
                Debug.Log($"{newInt} is already in the array");
                return intArray;
            }

            else
            {
                return intArray;
            }
        }

        else if (acceptDuplicates)
        {
            List<int> list = new(intArray.ToList());
            list.Add(newInt);
            intArray = list.ToArray();
            return intArray;
        }

        else
        {
            return intArray;
        }
    }

    /// <summary>
    /// Returns all monobehaviours (casted to T)
    /// </summary>
    /// <typeparam name="T">interface type</typeparam>
    /// <param name="gObj"></param>
    /// <returns></returns>
    public static T[] GetInterfaces<T>(this GameObject gObj)
    {
        if (!typeof(T).IsInterface) { throw new SystemException("Specified type is not an interface!"); }

        MonoBehaviour[] mObjs = gObj.GetComponents<MonoBehaviour>();

        return (from a in mObjs where a.GetType().GetInterfaces().Any(k => k == typeof(T)) select (T)(object)a)
            .ToArray();
    }

    /// <summary>
    /// Returns the first monobehaviour that is of the interface type (casted to T)
    /// </summary>
    /// <typeparam name="T">Interface type</typeparam>
    /// <param name="gObj"></param>
    /// <returns></returns>
    public static T GetInterface<T>(this GameObject gObj)
    {
        if (!typeof(T).IsInterface) { throw new SystemException("Specified type is not an interface!"); }

        return gObj.GetInterfaces<T>().FirstOrDefault();
    }

    /// <summary>
    /// Returns the first instance of the monobehaviour that is of the interface type T (casted to T)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gObj"></param>
    /// <returns></returns>
    public static T GetInterfaceInChildren<T>(this GameObject gObj)
    {
        if (!typeof(T).IsInterface) { throw new SystemException("Specified type is not an interface!"); }

        return gObj.GetInterfacesInChildren<T>().FirstOrDefault();
    }

    /// <summary>
    /// Gets all monobehaviours in children that implement the interface of type T (casted to T)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gObj"></param>
    /// <returns></returns>
    public static T[] GetInterfacesInChildren<T>(this GameObject gObj)
    {
        if (!typeof(T).IsInterface) { throw new SystemException("Specified type is not an interface!"); }

        MonoBehaviour[] mObjs = gObj.GetComponentsInChildren<MonoBehaviour>();

        return (from a in mObjs where a.GetType().GetInterfaces().Any(k => k == typeof(T)) select (T)(object)a)
            .ToArray();
    }

    /// <summary>
    /// Gets Components of type T at positionToCheck.  Returns true if at least one found and the found components are returned in componentAtPositionList
    /// </summary>
    public static bool GetComponentsAtCursorLocation<T>(out List<T> componentsAtPositionList, Vector3 positionToCheck)
    {
        bool found = false;

        List<T> componentList = new();

        Collider2D[] collider2DArray = Physics2D.OverlapPointAll(positionToCheck);

        // Loop through all colliders to get an object of type T

        T tComponent = default;

        for (int i = 0; i < collider2DArray.Length; i++)
        {
            tComponent = collider2DArray[i].gameObject.GetComponentInParent<T>();
            if (tComponent != null)
            {
                found = true;
                componentList.Add(tComponent);
            }
            else
            {
                tComponent = collider2DArray[i].gameObject.GetComponentInChildren<T>();
                if (tComponent != null)
                {
                    found = true;
                    componentList.Add(tComponent);
                }
            }
        }

        componentsAtPositionList = componentList;

        return found;
    }


    /// <summary>
    /// Gets Components of type T at box with centre point and size and angle.  Returns true if at least one found and the found components are returned in the list
    /// </summary>
    public static bool GetComponentsAtBoxLocation<T>(out List<T> listComponentsAtBoxPosition, Vector2 point,
        Vector2 size, float angle)
    {
        bool found = false;
        List<T> componentList = new();

        Collider2D[] collider2DArray = Physics2D.OverlapBoxAll(point, size, angle);

        // Loop through all colliders to get an object of type T
        for (int i = 0; i < collider2DArray.Length; i++)
        {
            T tComponent = collider2DArray[i].gameObject.GetComponentInParent<T>();
            if (tComponent != null)
            {
                found = true;
                componentList.Add(tComponent);
            }
            else
            {
                tComponent = collider2DArray[i].gameObject.GetComponentInChildren<T>();
                if (tComponent != null)
                {
                    found = true;
                    componentList.Add(tComponent);
                }
            }
        }

        listComponentsAtBoxPosition = componentList;

        return found;
    }

    /// <summary>
    /// Returns array of components of type T at box with centre point and size and angle. The numberOfCollidersToTest for is passed as a parameter. Found components are returned in the array.
    /// </summary>
    public static T[] GetComponentsAtBoxLocationNonAlloc<T>(int numberOfCollidersToTest, Vector2 point, Vector2 size,
        float angle)
    {
        Collider2D[] collider2DArray = new Collider2D[numberOfCollidersToTest];

        Physics2D.OverlapBoxNonAlloc(point, size, angle, collider2DArray);

        T tComponent = default;

        T[] componentArray = new T[collider2DArray.Length];

        for (int i = collider2DArray.Length - 1; i >= 0; i--)
        {
            if (collider2DArray[i] != null)
            {
                tComponent = collider2DArray[i].gameObject.GetComponent<T>();

                if (tComponent != null) { componentArray[i] = tComponent; }
            }
        }

        return componentArray;
    }

    /// <summary>
    /// Gets a component of a child object that has siblings based on the Index number as a parameter.
    /// </summary>
    public static T GetComponentInChildren<T>(this GameObject gameObject, int index)
    {
        return gameObject.transform.GetChild(index).GetComponent<T>();
    }

    /// <summary>
    /// Resets the polygon colliders shape path to match the sprite image.
    /// </summary>
    public static void TryUpdateShapeToAttachedSprite(this PolygonCollider2D collider)
    {
        collider.UpdateShapeToSprite(collider.GetComponentInChildren<SpriteRenderer>().sprite);
    }

    /// <summary>
    /// Resets the polygon colliders shape path to match the sprite image.
    /// </summary>
    public static void UpdateShapeToSprite(this PolygonCollider2D collider, Sprite sprite)
    {
        // ensure both valid
        if (collider != null && sprite != null)
        {
            // update count
            collider.pathCount = sprite.GetPhysicsShapeCount();

            // new paths variable
            List<Vector2> path = new();

            // loop path count
            for (int i = 0; i < collider.pathCount; i++)
            {
                // clear
                path.Clear();
                // get shape
                sprite.GetPhysicsShape(i, path);
                // set path
                collider.SetPath(i, path.ToArray());
            }
        }
    }

    public static void DestroyAllChildObjects(this Transform transform)
    {
        while (transform.childCount > 0) { Object.DestroyImmediate(transform.GetChild(0).gameObject); }
    }

    public static void DisableAllChildObjects(this Transform transform)
    {
        Transform[] allChildren = transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren) { child.gameObject.SetActive(false); }
    }

    public static void EnableAllChildObjects(this Transform transform)
    {
        Transform[] allChildren = transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren) { child.gameObject.SetActive(true); }
    }

    /// <summary>
    /// Expand a flattened 1D array into a 2D multidimensional array [,]
    /// </summary>
    public static T[,] SingleToMulti<T>(IReadOnlyList<T> array, int x, int y)
    {
        int index = 0;
        T[,] multi = new T[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if (index >= 0 && array.Count > index) { multi[i, j] = array[index]; }

                index++;
            }
        }

        return multi;
    }


    /// <summary>
    /// string to a 2D multidimensional array [,]
    /// </summary>
    // public static void StringToGrid(Grid<ComplexGridObject> inputGrid, string oneD, int width, int height)
    // {
    //     string[] separator = {"_,"};
    //     string[] newArray = oneD.Split(separator, StringSplitOptions.None);
    //     int index = 0;
    //     for (int i = 0; i < width; i++)
    //     { for (int j = 0; j < height; j++)
    //       { inputGrid.GridArray[i, j].AddGCost(newArray[index]);
    //         inputGrid.GridArray[i, j].AddNumber(newArray[index + 1]);
    //         index += 2; } }
    // }


    /// <summary>
    /// Print multi-dimensional array to console
    /// </summary>
    public static void MultiArrayToConsole<T>(T[,] inputArray)
    {
        Debug.Log($"MultiArrayToConsole called");

        StringBuilder sb = new();
        for (int i = 0; i < inputArray.GetLength(0); i++)
        {
            for (int j = 0; j < inputArray.GetLength(1); j++)
            {
                sb.Append(inputArray[i, j]);
                sb.Append(", ");
            }

            sb.AppendLine();
        }

        Debug.Log($"ArrayList:\n{sb}");
    }

    /// <summary>
    /// Print one-dimensional array to console
    /// </summary>
    public static void SingleArrayToConsole<T>(IEnumerable<T> inputArray)
    {
        StringBuilder sb = new();
        foreach (T data in inputArray)
        {
            sb.Append(data);
            sb.Append(",");
        }

        Debug.Log($"ArrayList:\n{sb}");
    }

    /// <summary>
    /// Print one-dimensional array to console on one line
    /// </summary>
    public static void DebugArrayOneLine<T>(IEnumerable<T> inputArray)
    {
        string cleaned = string.Join("_,", inputArray);
        cleaned = Regex.Replace(cleaned, @"[\r\n]+", "_,");
        Debug.Log(cleaned);
    }

    /// <summary>
    /// Create a string from an array
    /// </summary>
    public static string ArrayToString<T>(IEnumerable<T> inputArray)
    {
        string cleaned = string.Join("_,", inputArray);
        cleaned = Regex.Replace(cleaned, @"[\r\n]+", "_,");
        return cleaned;
    }

    /// <summary>
    /// Print one-dimensional array to console on one line
    /// </summary>
    public static string[] StringToArray(string savedString)
    {
        string[] outputArray = savedString.Split("_,");
        return outputArray;
    }


    /// <summary>
    /// Flatten a 2D array
    /// </summary>
    public static T[] Flatten<T>(T[,] inputArray)
    {
        List<T> oneD = new();
        for (int i = 0; i < inputArray.GetLength(0); i++)
        {
            for (int j = 0; j < inputArray.GetLength(1); j++) { oneD.Add(inputArray[i, j]); }
        }

        return oneD.ToArray();
    }


    /// <summary>
    /// Flatten a 2D array to string
    /// </summary>
    public static string FlattenMultiToString<T>(T[,] inputArray, bool debug)
    {
        List<T> oneD = new();
        for (int i = 0; i < inputArray.GetLength(0); i++)
        {
            for (int j = 0; j < inputArray.GetLength(1); j++) { oneD.Add(inputArray[i, j]); }
        }

        T[] oneArray = oneD.ToArray();
        string cleaned = string.Join("_,", oneArray);
        cleaned = Regex.Replace(cleaned, @"[\r\n]+", "_,");
        if (debug) { Debug.Log(cleaned); }

        return cleaned;
    }


    /// <summary>
    /// Flatten a 2D array to 1D List
    /// </summary>
    public static List<T> FlattenToList<T>(T[,] inputArray)
    {
        List<T> oneD = new();
        for (int i = 0; i < inputArray.GetLength(0); i++)
        {
            for (int j = 0; j < inputArray.GetLength(1); j++) { oneD.Add(inputArray[i, j]); }
        }

        return oneD;
    }

    /*public static string ObjectToString(Array ar)
    {
        using MemoryStream ms = new();
        SoapFormatter formatter = new();
        formatter.Serialize(ms, ar);
        return Encoding.UTF8.GetString(ms.ToArray());
    }

    public static object ObjectFromString(string s)
    {
        using MemoryStream ms = new(Encoding.UTF8.GetBytes(s));
        SoapFormatter formatter = new();
        return formatter.Deserialize(ms) as Array;
    }

    public static T ObjectFromString<T>(string s)
    {
        return (T) ObjectFromString(s);
    }*/
}