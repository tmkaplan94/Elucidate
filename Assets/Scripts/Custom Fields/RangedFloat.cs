/*
 * Author: Richard Fine, from Unite 2016
 * Contributors: Tyler Kaplan
 * Description: Struct to hold min and max values of an float type.
 */
using System;

[Serializable]
public struct RangedFloat
{
    public float minValue; 
    public float maxValue;
}