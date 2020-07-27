using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [Range(1, 10)]
    public int speed = 5;

    Vector3 movimentation;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        movimentation = new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = movimentation;
    }
}
