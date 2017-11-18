using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

  public float MAX_TORQUE = 30.0f;
  public float MAX_ROTARION = 500.0f;

  private float torque;

  private GameObject player;
  private Rigidbody2D rb;
  public PhysicsMaterial2D physMat;

  struct Physics2DMaterialDefault
  {
    public float _friction;
    public float _bounciness;
  }
  private Physics2DMaterialDefault physMatDefault;

  // Use this for initialization
  void Start () {
    torque = MAX_TORQUE;

    player = GameObject.Find("Player");
    rb = player.GetComponent<Rigidbody2D>();

    physMatDefault._friction = physMat.friction;
    physMatDefault._bounciness = physMat.bounciness;

  }
	
	// Update is called once per frame
	void Update () {
    //Debug.Log( rb.angularVelocity );
    if (Input.GetKey(KeyCode.A))
    {
      if (rb.angularVelocity < MAX_ROTARION)
      {
        rb.AddTorque(torque);
      }
      
      //rb.AddForce(new Vector2(-1.0f,0.0f) * BASE_SPEED);
    }
    else if (Input.GetKey(KeyCode.D))
    {
      if (rb.angularVelocity > -MAX_ROTARION)
      {
        rb.AddTorque(-torque);
      }
      //rb.AddForce(new Vector2(1.0f, 0.0f) * BASE_SPEED);
    }
	}

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.name.Equals("Slime"))
    {
      Destroy(collision.gameObject);
      StartCoroutine("TimerWait");
    }
  }

      

  private IEnumerator TimerWait()
  {
    physMat.friction = 0;

    yield return new WaitForSeconds(10.0f); 

    physMat.friction = physMatDefault._friction;
    Debug.Log("Slime over!");
  }

}
