using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private Sprite body;
    [SerializeField] private Transform bodyGameObject;
    [SerializeField] private Sprite sail;
    [SerializeField] private Transform sailGameObject;
    [SerializeField] private HealthManager health;

    private Sprite oldSpriteBody;
    private Sprite oldSpriteSail;

    private void Awake()
    {
        oldSpriteBody = bodyGameObject.GetComponent<SpriteRenderer>().sprite;
        oldSpriteSail = sailGameObject.GetComponent<SpriteRenderer>().sprite;
    }
    private void Update()
    {
        if (health.currentHealth <= (health.maxHealth / 2))
        {
            bodyGameObject.GetComponent<SpriteRenderer>().sprite = body;
            sailGameObject.GetComponent<SpriteRenderer>().sprite = sail;
        }
        else
        {
            bodyGameObject.GetComponent<SpriteRenderer>().sprite = oldSpriteBody;
            sailGameObject.GetComponent<SpriteRenderer>().sprite = oldSpriteSail;
        }
    }
}
