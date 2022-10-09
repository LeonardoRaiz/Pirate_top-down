using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
