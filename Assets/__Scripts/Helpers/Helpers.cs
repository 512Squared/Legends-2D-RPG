using System.Collections.Generic;
using UnityEngine;
using System.Linq;


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
                List<string> list = new List<string>(stringArray.ToList());
                list.Add(newString);
                stringArray = list.ToArray();
                return stringArray;
            }
            else if (stringArray.Contains(newString))
            {
                Debug.Log($"{newString} is already in the array");
                return stringArray;
            }

            else return stringArray;
        }
        else return stringArray;
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
                List<string> list = new List<string>(stringArray.ToList());
                list.Add(newString);
                stringArray = list.ToArray();
                return stringArray;
            }
            else if (stringArray.Contains(newString))
            {
                Debug.Log($"{newString} is already in the array");
                return stringArray;
            }

            else return stringArray;
        }

        else if (acceptDuplicates && newString != null)
        {
            List<string> list = new List<string>(stringArray.ToList());
            list.Add(newString);
            stringArray = list.ToArray();
            return stringArray;
        }

        else return stringArray;
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
                List<int> list = new List<int>(intArray.ToList());
                list.Add(newInt);
                intArray = list.ToArray();
                return intArray;
            }
            else if (intArray.Contains(newInt))
            {
                Debug.Log($"{newInt} is already in the array");
                return intArray;
            }

            else return intArray;
        }

        else if (acceptDuplicates)
        {
            List<int> list = new List<int>(intArray.ToList());
            list.Add(newInt);
            intArray = list.ToArray();
            return intArray;
        }

        else return intArray;
    }
}
