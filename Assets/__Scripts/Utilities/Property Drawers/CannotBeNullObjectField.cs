using System;
using UnityEngine;
 
/// <summary> Cannot Be Null will red-flood the field if the reference is null. </summary>
[AttributeUsage(AttributeTargets.Field)]
public class CannotBeNullObjectField : PropertyAttribute { }
