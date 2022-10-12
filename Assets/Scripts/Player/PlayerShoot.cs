using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private Transform[] shotPrefabs;
    [SerializeField] private Transform[] firePoints;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private float bulletForce = 40f;
    [SerializeField] private Transform smokeEffect;

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
                FindObjectOfType<AudioManager>().Play("BulletFront");
                Rigidbody2D bullet = GetBullet(firePoints[0], shotPrefabs[0]);
                bullet.AddForce(firePoints[0].up * bulletForce, ForceMode2D.Impulse);
                shotTime = Time.time + timeBetweenShots;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time >= shotTime)
            {
                CallEffectSmoke();
                FindObjectOfType<AudioManager>().Play("BulletSide");
                for (int i = 1; i < firePoints.Length; i++)
                {
                    Rigidbody2D bullet = GetBullet(firePoints[i], shotPrefabs[1]);
                    bullet.AddForce(firePoints[i].up * bulletForce, ForceMode2D.Impulse);
                }
                shotTime = Time.time + (timeBetweenShots * 2);


            }
        }
    }
    
    
    private Rigidbody2D GetBullet(Transform firePoint, Transform colorPrefab)
    {
        Transform bullet = Instantiate(colorPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D theRB = bullet.GetComponent<Rigidbody2D>();
        return theRB;
    }

    private void CallEffectSmoke()
    {
        var smoke1 = Instantiate(smokeEffect, firePoints[1].position, firePoints[1].rotation);
        var smoke2 = Instantiate(smokeEffect, firePoints[4].position, firePoints[4].rotation);
        smoke1.transform.parent = gameObject.transform;
        smoke2.transform.parent = gameObject.transform;
        Destroy(smoke1.gameObject, 1);
        Destroy(smoke2.gameObject, 1);
    }
}
