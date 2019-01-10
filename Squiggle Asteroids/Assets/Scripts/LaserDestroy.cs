using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDestroy : MonoBehaviour {

    public GameObject asteroidExplosion;
    //public GameObject playerExplosion;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Asteroids(Clone)")
        {
            Destroy(col.gameObject);
            Instantiate(asteroidExplosion, transform.position, transform.rotation);
        }
        if (col.gameObject.name == "Asteroids (1)(Clone)")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            Instantiate(asteroidExplosion, transform.position, transform.rotation);

        }
        if (col.gameObject.name == "Asteroids (2)(Clone)")
        {
            Destroy(col.gameObject);
            Instantiate(asteroidExplosion, transform.position, transform.rotation);
        }
    }
}
