using UnityEngine;
using System.Collections;

public class QuicknDirtyMovement : MonoBehaviour {

  public float speed = 1f;
  float x;
  float y;
  bool grounded = true;
	// Update is called once per frame
	void Update () {
    x = Input.GetAxisRaw ("Horizontal");
    y = Input.GetAxisRaw ("Vertical");

    if(x > 0)
      transform.Translate (speed + x *Time.deltaTime, 0, 0);
    else if(x < 0)
      transform.Translate (x-speed *Time.deltaTime, 0, 0);

    if (y > 0)
      transform.Translate (0, y + speed * Time.deltaTime, 0);
    else if (y < 0)
      transform.Translate (0, y - speed * Time.deltaTime, 0);
	}
}
