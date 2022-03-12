using UnityEngine;

public class MoveTransform : MonoBehaviour
{

    [SerializeField] private int moveSpeed;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.forward * -moveSpeed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += transform.right * -moveSpeed * Time.deltaTime;
        }

    }

}