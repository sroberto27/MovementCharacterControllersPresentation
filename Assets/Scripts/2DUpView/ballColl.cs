
using UnityEngine;

public class ballColl : MonoBehaviour
{
    

    public Transform ball;
    public float force;
    Transform startPos;
    private void Awake()
    {
        startPos = ball;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "GoalLeft")
        {
            Debug.Log("goalazooooo!!!!!!!! LEFT");

        }
        else
        {
            if(collision.name == "GoalRight")
            {
                Debug.Log("goalazooooo!!!!!!!! RIGHT");

            }
           // else
          //  {
               // if (collision.name == "Catto")
              //  {
             //       Vector2 direction = ball.position - collision.GetComponent<Transform>().position;
               //     ball.GetComponent<Rigidbody2D>().AddForce(direction.normalized * force);
             //   }
               // else
               // {
                 //   Vector2 direction = collision.GetComponent<Transform>().position;
                //    ball.GetComponent<Rigidbody2D>().AddForce(direction.normalized * force);
              //  }
          //  }
           
        }
        Vector2 direction = ball.position - collision.GetComponent<Transform>().position;
        ball.GetComponent<Rigidbody2D>().AddForce(direction.normalized * force);



    }
}
