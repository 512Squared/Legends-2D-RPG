using System;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class IconTagAttribute : Attribute
{
    public string Icon;

    public IconTagAttribute(string icon)
    {
        this.Icon = icon;
    }
}