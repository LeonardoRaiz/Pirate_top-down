using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int _timeGame = 60;
    [SerializeField] private int _spawnGame = 2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public int timeGame
    {
        get { return _timeGame; }
        set { _timeGame = value; }
    }

    public int spawnGame
    {
        get { return _spawnGame; }
        set { _spawnGame = value; }
    }
}
