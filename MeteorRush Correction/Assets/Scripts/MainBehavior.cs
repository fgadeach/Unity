using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    //Make the ship talk
    public static float posicionX;

    float colliderHalfWidth;
    float colliderHalfHeight;

    //Referencia global del script hacia el rigidbody de la nave
    // Se utiliza para que se pueda usar update sin problema
    Rigidbody2D rb2d = new Rigidbody2D();

    public Vector2 posicion;

    //Velocidad natural del vehiculo
    public float speed = 10.0f;

    public static float Posicion
    {
        get { return posicionX; }
    }

    void Start()
    {
        //Get the game object moving
        #region rigid
        rb2d = GetComponent<Rigidbody2D>();
        #endregion

        posicion = new Vector2(rb2d.position.x,0);
        posicionX = posicion.x;


        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        colliderHalfWidth = collider.size.x / 2;
        colliderHalfWidth *= 0.05f;
        colliderHalfHeight = collider.size.y / 2;
        colliderHalfHeight *= 0.05f;
    }

    private void Update()
    {

        Vector3 position = Input.mousePosition;
        position.z = -Camera.main.transform.position.z;
        position = Camera.main.ScreenToWorldPoint(position);
        transform.position = position;
        ClampInScreen();
        //Vector2 movimiento = new Vector2();
        //movimiento.x = speed * Input.GetAxis("Horizontal");
        //movimiento.y = speed * Input.GetAxis("Vertical");

        posicion.x = rb2d.position.x;
        posicionX = posicion.x;

        //rb2d.velocity = movimiento;
    }
    void ClampInScreen()
    {
        Vector3 position = transform.position;
        
        
        if (position.x - colliderHalfWidth < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenLeft + colliderHalfWidth;
        }
        else if (position.x +colliderHalfWidth > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenRight - colliderHalfWidth;
        }
        if (position.y + colliderHalfHeight>  ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenTop - colliderHalfHeight;
        }
        else if (position.y - colliderHalfHeight < ScreenUtils.ScreenBot)
        {
            position.y = ScreenUtils.ScreenBot + colliderHalfHeight;
        }

        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
    }
}