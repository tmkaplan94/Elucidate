using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * version: 1.0
 * Date: 1/27/2022
 * Description: Observer abstract class to override if there will be multiple Observer. 
 *			    WhenNotified is used to perform an action if a Subject goes through an interaction. 
 *          
 * Notes: Using delegates to implement Observer Pattern. 
 *        
 * 
 * Author: Loc Trinh
 * Contributors: Grant Reed
 * 
 */

public abstract class Observer : MonoBehaviour
{
	// Serialize a field in the inspector for Subject objects to subcribe to them.
	[SerializeField] 
	public Subject uiSubject;
	// This function gets called whenever a Subject notify.
	public abstract void WhenNotified(int val);
}

public class Subject : MonoBehaviour
{
	public delegate void NotifyDelegate(int val);
	public NotifyDelegate _notify;
	
	// Function for subject to communicate to observer when something happen
	public void Notify(int val)
	{
		if (_notify != null)
		{
			_notify(val);
		}
		
	}
}
 
