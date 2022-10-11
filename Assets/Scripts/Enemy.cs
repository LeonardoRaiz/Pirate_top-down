using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _timeBetweenAttacks;
    [SerializeField] private int _damageAmount;
    private Transform _player;

    [SerializeField] private int pickupChance;
    [SerializeField] private Transform[] pickups;
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public float speedRotation
    {
        get { return _speedRotation; }
        set { _speedRotation = value; }
    }

    public Transform player
    {
        get { return _player; }
        set { _player = value; }
    }

    public float timeBetweenAttacks
    {
        get { return _timeBetweenAttacks; }
        set { _timeBetweenAttacks = value; }
    }

    public int damageAmount
    {
        get { return _damageAmount; }
        set { _damageAmount = value; }
    }


    private void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Player")[0].transform)
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        } else {
            return;
        }
        
    }
    
    public void Drop()
    {
        int randomNumber = Random.Range(0, 101);
        if (randomNumber < pickupChance)
        {
            Instantiate(pickups[0], transform.position, Quaternion.identity);
        }
    }
}
