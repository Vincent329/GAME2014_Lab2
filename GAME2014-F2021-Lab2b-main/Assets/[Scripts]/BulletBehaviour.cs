using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Range(0.0f, 2.0f)]
    public BulletManager bulletManager;
    public float speed;
    public Bounds bulletBounds;

    private void Start()
    {
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= new Vector3(0.0f, speed, 0.0f);
        CheckBounds();
    }

    public void CheckBounds()
    {
        if (transform.position.y <= bulletBounds.max)
        {
            bulletManager.ReturnBullet(this.gameObject);
        }    
    }
}
