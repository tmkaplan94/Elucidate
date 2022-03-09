/*
 * Author: Richard Fine, from Unite 2016
 * Contributors: Tyler Kaplan
 * Description: Used for customizable editor slider
 */
using System;

public class RangedFloatMinMax : Attribute
{
    // used to override default values set in RangedFloatDrawer.cs
    public RangedFloatMinMax(float min, float max)
    {
        Min = min;
        Max = max;
    }
    public float Min { get; private set; }
    public float Max { get; private set; }
}
