using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private Transform[] shotPrefabs;
    [SerializeField] private Transform[] firePoints;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private float bulletForce = 40f;

    private float shotTime;

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= shotTime)
            {
                Rigidbody2D bullet = GetBullet(firePoints[0], shotPrefabs[0]);
                bullet.AddForce(firePoints[0].up * bulletForce, ForceMode2D.Impulse);
                shotTime = Time.time + timeBetweenShots;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time >= shotTime)
            {
                Rigidbody2D bullet = GetBullet(firePoints[1], shotPrefabs[1]);
                Rigidbody2D bullet1 = GetBullet(firePoints[2], shotPrefabs[1]);
                bullet.AddForce(firePoints[1].up * bulletForce, ForceMode2D.Impulse);
                bullet1.AddForce(firePoints[2].up * bulletForce, ForceMode2D.Impulse);
                shotTime = Time.time + (timeBetweenShots * 2);
            }
        }
    }

    private Rigidbody2D GetBullet(Transform firePoint, Transform colorPrefab)
    {
        Transform bullet = Instantiate(colorPrefab, firePoint.position, transform.rotation);
        Rigidbody2D theRB = bullet.GetComponent<Rigidbody2D>();
        return theRB;
    }
}
