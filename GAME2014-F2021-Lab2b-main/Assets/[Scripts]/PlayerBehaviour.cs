using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D m_rb;

    [Header("PlayerMovement")]
    [SerializeField]
    private float speedForce;

    public Bounds bounds;

    [SerializeField]
    [Range(0.0f, 0.99f)]
    private float decay; 

    private float xInput;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        CheckBounds();
    }
    private void Move()
    {
        m_rb.AddForce(new Vector2(xInput * speedForce, 0.0f));
        m_rb.velocity *= (1.0f - decay);
    }


       private void CheckBounds()
    {
        if (transform.position.x < bounds.min)
        {
            transform.position = new Vector2(bounds.min, transform.position.y);
        }
        else if (transform.position.x > bounds.max)
        {
            transform.position = new Vector2(bounds.max, transform.position.y);
        }
    }
}
