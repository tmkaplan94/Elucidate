using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingShards : MonoBehaviour
{
    public float desiredAlpha;
    public float currAlpha;
    public float timeRemaining = 1.2f;
    Material[] currMaterial;
    float disappearTime;

    private Color currColor1;
    private Color currColor2;

    // Start is called before the first frame update
    void Start()
    {
        currMaterial = GetComponent<Renderer>().materials;
        currColor1 = currMaterial[0].color;
        currColor2 = currMaterial[1].color;
        disappearTime = timeRemaining - .1f;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            destroyParent();
        }
        if (timeRemaining <= disappearTime )
        {
            GetComponent<MeshCollider>().isTrigger = true;
        }
        currAlpha = Mathf.MoveTowards(currAlpha, desiredAlpha, 1.0f * Time.deltaTime);
        currColor1.a = currAlpha;
        currColor2.a = currAlpha;
        currMaterial[0].color = currColor1;
        currMaterial[1].color = currColor2;
    }

    void destroyParent()
    {
        Destroy(transform.parent.gameObject);
    }
}
