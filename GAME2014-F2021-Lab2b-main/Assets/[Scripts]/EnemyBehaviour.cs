using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Movement")]
    private float randomSpeed;
    private float startingPoint;

    [Header("Bullets")]
    public BulletManager bulletManager;
    public Transform bulletSpawn;
    public GameObject bullet;
    public int frameDelay;

    public Bounds movementBounds;
    public Bounds startingRange;
    // Start is called before the first frame update
    void Start()
    {
        randomSpeed = Random.Range(movementBounds.min, movementBounds.max);
        startingPoint = Random.Range(startingRange.min, startingRange.max);
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, randomSpeed) + startingPoint, transform.position.y);
    }

    private void FixedUpdate()
    {
        if (Time.frameCount % frameDelay == 0)
        {
            //    var temp_Bullet = Instantiate(bullet);
            //    temp_Bullet.transform.position = bulletSpawn.transform.position;
            bulletManager.GetBullet(bulletSpawn.transform.position);
        }
    }
}
