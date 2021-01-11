using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor1Behavior : MonoBehaviour
{
    // Start is called before the first frame update

    float velocity = 3f;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -velocity);
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject meteor = GameObject.FindWithTag("Meteor1");
        if (col.gameObject.tag.Equals("Meteor1"))
        {
            Destroy(col.gameObject);
        }
    }
}
