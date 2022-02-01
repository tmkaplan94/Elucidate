using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrokenBox : MonoBehaviour
{
    public float timeRemaining = 2f;
    /*
    public float desiredAlpha = 0;
    public float currAlpha = 1;
    Transform[] currChildren;
    Material[] currMaterial;
    Color color1;
    Color color2;
    */
    // Start is called before the first frame update
    void Start()
    {
        /*
        currChildren = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < currChildren.Length; i++)
        {
            //Debug.Log(currChildren[i].name);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0.0f)
        {
            Destroy(gameObject);
        }

        /*
        currAlpha = Mathf.MoveTowards(currAlpha, desiredAlpha, 1.0f * Time.deltaTime);
        for (int i = 0; i < currChildren.Length; i++)
        {
            currMaterial = currChildren[i].GetComponent<Renderer>().materials;
            color1 = currMaterial[0].color;
            color2 = currMaterial[1].color;
            color1.a = currAlpha;
            color2.a = currAlpha;
            currMaterial[0].color = color1;
            currMaterial[1].color = color2;
        }
        */
    }
}
