using UnityEngine;
using TMPro;

/*
 * Author: Loc Trinh
 * Contributors: Grant Reed
 * Description: The UISystem is an Observer that will observe any object that it subscribes to. Then it will display UI based on
 *				that subject.
 */

public class UIPickUpObserver : MonoBehaviour
{
	[SerializeField] private GameObject textObj;
	[SerializeField] private TMP_Text text;
	[SerializeField] private PickUpSystem pickup;

	void OnEnable()
	{
		pickup.TriggeredUI += ToggleUI;
	}
	void OnDisable()
	{
		pickup.TriggeredUI -= ToggleUI;
	}
	// When WhenNotified is called, UI actions will happen
	private void ToggleUI(string objName)
	{
		print(objName);
		if(textObj.activeInHierarchy)
			textObj.SetActive(false);
		else
        {
			text.text = "Pick up " + objName;
			textObj.SetActive(true);
        }
	}
}
