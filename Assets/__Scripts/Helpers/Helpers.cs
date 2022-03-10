using System.Collections.Generic;
using System;
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
    /// <summary>
    /// Returns all monobehaviours (casted to T)
    /// </summary>
    /// <typeparam name="T">interface type</typeparam>
    /// <param name="gObj"></param>
    /// <returns></returns>
    public static T[] GetInterfaces<T>(this GameObject gObj)
    {
        if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
        var mObjs = gObj.GetComponents<MonoBehaviour>();

        return (from a in mObjs where a.GetType().GetInterfaces().Any(k => k == typeof(T)) select (T)(object)a).ToArray();
    }

    /// <summary>
    /// Returns the first monobehaviour that is of the interface type (casted to T)
    /// </summary>
    /// <typeparam name="T">Interface type</typeparam>
    /// <param name="gObj"></param>
    /// <returns></returns>
    public static T GetInterface<T>(this GameObject gObj)
    {
        if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
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
        if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
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
        if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");

        var mObjs = gObj.GetComponentsInChildren<MonoBehaviour>();

        return (from a in mObjs where a.GetType().GetInterfaces().Any(k => k == typeof(T)) select (T)(object)a).ToArray();
    }
}
