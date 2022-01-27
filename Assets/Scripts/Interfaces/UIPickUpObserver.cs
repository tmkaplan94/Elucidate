using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/**
 * version: 0.8
 * Date: 1/27/2022
 * Description: The UISystem is an Observer that will observe any object that it subscribes to. Then it will display UI based on
 *				that subject.
 *
 * Notes: 
 * 
 * Author: Loc Trinh
 * Contributors: Grant Reed
 * 
 */

public class UIPickUpObserver : Observer
{	
	[SerializeField]
	private GameObject text;
	
	void OnEnable()
	{
		
		// Subscribes WhenNotified function to delegate _notify
		uiSubject._notify += WhenNotified;
		
	}
	void OnDisable()
	{
		// Unsubscrube WhenNotified function to delegate _notify
		uiSubject._notify -= WhenNotified;
	}
	// When WhenNotified is called, UI actions will happen
    public override void WhenNotified(int val)
	{
		if (val == 1)
		{
			// turn on UI
			text.SetActive(true);
			
		}
		if (val == 0)
		{
			// turn off UI
			text.SetActive(false);
		}
	}
}
