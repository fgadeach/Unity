using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys meteorites
public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    int finalAltitude;
    const int spawnBorderSize = 100;
    void Start()
    {
        finalAltitude =  -6;
    }

    // Update is called once per frame
    void Update()
    {
        //Look for asteroid
        GameObject meteor = GameObject.FindWithTag("Meteor");
        if (meteor != null)
        {
            if (meteor.GetComponent<Rigidbody2D>().position.y <= finalAltitude)
            {
                Destroy(meteor);
            }
        }

        GameObject meteor1 = GameObject.FindWithTag("Meteor1");
        if (meteor1 != null)
        {
            if (meteor1.GetComponent<Rigidbody2D>().position.y <= finalAltitude)
            {
                Destroy(meteor1);
            }
        }
    }
}
