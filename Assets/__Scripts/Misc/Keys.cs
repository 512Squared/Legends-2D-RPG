using Sirenix.OdinInspector;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [SerializeField] public string[] keysList =
    {
        "<color=#eb0505>red</color>", "<color=#ECF005>yellow</color>", "<color=#2FD0F9>blue</color>",
        "<color=#3FA30F>green</color>", "<color=#7B48EA>purple</color>", "<color=#3FA30F>green</color>"
    };

    [SerializeField] public string[] multiKeyLock =
    {
        "<color=#eb0505>red</color>", "<color=#3FA30F>green</color>", "<color=#ECF005>yellow</color>"
    };

    public bool isUnlocked;
    public bool debugMain;
    public bool debugMissing;

    // "red", "blue", "purple"

    private void Start()
    {
        //TestKeysInLock();
    }


    [Button("Test Keys")]
    private bool TestKeysInLock()
    {
        // if just one key is missing for one lock, then return false
        // check one lock at a time. If key doesn't fit, try next key y++
        // If no keys fit, then return false
        // if key fits, then move to next lock. i++

        isUnlocked = false;

        int locksOpened = 0;
        bool lockDuplicates = false;

        for (int i = 0; i < multiKeyLock.Length; i++)
        {
            for (int y = 0; y < keysList.Length; y++)
            {
                if (debugMain)
                {
                    Debug.Log($"Try Key {y + 1}: {keysList[y].ToUpper()} on Lock {i + 1}: {multiKeyLock[i].ToUpper()}");
                }

                if (multiKeyLock[i] == keysList[y] && !isUnlocked)
                {
                    Debug.Log(
                        $"SUCCESS! Key {y + 1}: {keysList[y].ToUpper()} fits LOCK {i + 1}: {multiKeyLock[i].ToUpper()}");
                    if (!lockDuplicates)
                    {
                        locksOpened++;
                        lockDuplicates = true;
                    }
                }

                if (locksOpened == multiKeyLock.Length && !isUnlocked)
                {
                    isUnlocked = true;
                    Debug.Log($"WELL DONE! You've found all the necessary keys to open the lock:");
                    for (int j = 0; j < multiKeyLock.Length; j++) { Debug.Log($"-- {multiKeyLock[j]} key"); }

                    return true;
                }
            }

            lockDuplicates = false;
        }

        if (locksOpened != multiKeyLock.Length)
        {
            Debug.Log(
                $":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Debug.Log($"You are missing some keys:");
            Debug.Log($"MISSING KEYS: ");
            for (int l = 0; l < multiKeyLock.Length; l++)
            {
                bool hasKey = false;
                for (int k = 0; k < keysList.Length; k++)
                {
                    if (debugMissing)
                    {
                        Debug.Log(
                            $"Try Key {k + 1}: {keysList[k].ToUpper()} on Lock {l + 1}: {multiKeyLock[l].ToUpper()}");
                    }

                    hasKey = multiKeyLock[l] == keysList[k];
                    if (hasKey) { break; }
                }

                if (!hasKey)
                {
                    Debug.Log($"-----{multiKeyLock[l].ToUpper()}");
                }
            }

            Debug.Log($"Check completed....");
            return false;
        }

        return false;
    }
}