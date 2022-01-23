using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * version 1.0
 * Date: 1/13/2022
 * Description: This class currently just damages idamageable objects.
 * 
 * Notes: I presume this script will be completely overhalled. For now, it works.
 * Author: Grant Reed
 * Contributors:
 * 
 */
public class bullet : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IDamageable<float>>().TakeDamage(damage);
        Destroy(gameObject);
    }

    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            bulletLight();
        }
    }
    
    private void bulletLight()
    {
        GameObject lightGO = new GameObject("Bullet Light");
        Light light = lightGO.AddComponent<Light>();
        light.type = LightType.Point;
        light.range = 10.0f;
        light.intensity = 1.0f;
        lightGO.transform.position = gameObject.transform.position;
        Destroy(lightGO);
    }

}
