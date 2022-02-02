/*
 * Author: Loc Trinh
 * Contributors: Grant Reed
 * Description: Observer, often mistaken for pub/sub, established one-to-many relationships.
 *
 * Observer implements loose coupling of data. Less abstract and more concrete,
 * pattern is useful when systems are obviously tied together.
 * Observer is abstract class to override if there will be multiple Observer. 
 * WhenNotified is used to perform an action if a Subject goes through an interaction. 
 */

using UnityEngine;

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
 
