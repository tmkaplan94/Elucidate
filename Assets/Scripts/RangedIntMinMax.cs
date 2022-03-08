/*
 * Author: Richard Fine, from Unite 2016
 * Contributors: Tyler Kaplan
 * Description: Used for customizable editor slider
 */
using System;

public class RangedIntMinMax : Attribute
{
    public RangedIntMinMax(int min, int max)
    {
        Min = min;
        Max = max;
    }
    public int Min { get; private set; }
    public int Max { get; private set; }
}
