using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour, IDamageable <float>
{
    public GameObject wallShattered;
    public float currHealth = 1;
    public float maxHealth = 1;
    public float minHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        //get a random number from 20 to 35 for wall health
        maxHealth = Random.Range(minHealth, maxHealth);
        currHealth = maxHealth;
    }


    public void TakeDamage(float dmg)
    {
        currHealth -= dmg;
        if (currHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        Vector3 temp = transform.position;
        Vector3 boxScale = transform.localScale;
        Vector3 scaleFactor = new Vector3(.5f, .5f, .5f);
        wallShattered.transform.localScale = Vector3.Scale(boxScale, scaleFactor);
        temp.y -= .15f;
        Instantiate(wallShattered, temp, transform.rotation);
        GetComponent<Rigidbody>().AddExplosionForce(50f,temp, 4f);
        Destroy(gameObject);
    }
}
