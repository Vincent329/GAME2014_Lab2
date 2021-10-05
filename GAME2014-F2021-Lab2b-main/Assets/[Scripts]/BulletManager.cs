using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> bulletPool;
    public int maxBullets;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>();
        BuildBulletPool();
    }

  
    public void BuildBulletPool()
    {
        for (int i = 0; i < maxBullets; i++)
        {
            var temp_bullet = Instantiate(bulletPrefab);
            temp_bullet.SetActive(false);
            temp_bullet.transform.parent = transform; // game controller itself will be inside the parent transform
            bulletPool.Enqueue(temp_bullet);
        }
    }

    public GameObject GetBullet(Vector2 position)
    {
        var temp_bullet = bulletPool.Dequeue(); // stores as a reference to the temp bullet
        temp_bullet.transform.position = position;
        temp_bullet.SetActive(true);
        return temp_bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
