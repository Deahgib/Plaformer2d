using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClaw : MonoBehaviour {

  private GameObject player;
  private GameObject claw;

  private bool claw_projected = false;

	// Use this for initialization
	void Start () {
    player = GameObject.Find("Player");
    claw = GameObject.Find("Claw");
  }

  void OnGUI()
  {
    Vector3 p = new Vector3();
    Camera c = Camera.main;
    Event e = Event.current;
    Vector2 mousePos = new Vector2();

    // Get the mouse position from Event.
    // Note that the y position from Event is inverted.
    mousePos.x = e.mousePosition.x;
    mousePos.y = c.pixelHeight - e.mousePosition.y;

    p = c.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, c.nearClipPlane));

    GUILayout.BeginArea(new Rect(20, 20, 250, 120));
    GUILayout.Label("Screen pixels: " + c.pixelWidth + ":" + c.pixelHeight);
    GUILayout.Label("Mouse position: " + mousePos);
    GUILayout.Label("World position: " + p.ToString("F3"));
    GUILayout.EndArea();
  }

  // Update is called once per frame
  void Update () {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      // Project Claw.
      // Or Retract Claw.
    }

    Vector3 p = new Vector3();
    Camera c = Camera.main;
    Vector2 mousePos = Input.mousePosition;

    p = c.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, c.nearClipPlane));

    p.z = 0.0f;
    //cursor.z = player.transform.position.z;

    //claw.transform.position = p;

    Vector3 direction = p - player.transform.position;
    direction.Normalize();
    //claw.transform.position = player.transform.position + direction;
    claw.transform.SetPositionAndRotation(player.transform.position + direction, Quaternion.LookRotation(direction, Vector3.Cross(direction, new Vector3(0,0,1))));
  }
}
