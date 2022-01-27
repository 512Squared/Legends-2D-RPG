using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "lightingSchedule", menuName = "Scriptable Objects/LightingSchedule")]
public class LightingSchedule : ScriptableObject
{
    public LightingBrightness[] lightingBrightnessArray;
}

[System.Serializable]

public struct LightingBrightness
{
    public Seasons season;
    public int hour;
    public float lightIntensity;
}
