using UnityEngine;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
  /// <summary>
  /// 1 - The speed of the ship
  /// </summary>
  public Vector2 speed = new Vector2(0, 0);


  // 2 - Store the movement
  private Vector2 movement;
	void flipIfNecessary(float inputX)
	{
		bool flipLeft = inputX < 0 && transform.localScale.x > 0;
		bool flipRight = (inputX > 0 && transform.localScale.x < 0);
		if(flipLeft || flipRight)
		{
			Debug.Log("FLIP");
			GameObject myCat = GameObject.FindGameObjectWithTag("Player");
 	 		myCat.transform.localScale = new Vector2(myCat.transform.localScale.x * -1, myCat.transform.localScale.y);

			//Vector3 v = transform.localScale;
			//v.x = -1;
			//Debug.Log(transform.localScale.x);
		}
	}
  void Update()
 {
	// 3 - Retrieve axis information
    float inputX = Input.GetAxis("Horizontal");
    float inputY = Input.GetAxis("Vertical");

    // 4 - Movement per direction
    movement = new Vector2(
      speed.x * inputX,
      speed.y * inputY);
      
      flipIfNecessary(inputX);
    // ...

    // 5 - Shooting
    bool shoot = Input.GetButtonDown("Fire1");
    shoot |= Input.GetButtonDown("Fire2");
    // Careful: For Mac users, ctrl + arrow is a bad idea

    if (shoot)
    {
      WeaponScript weapon = GetComponent<WeaponScript>();
      if (weapon != null)
      {
        // false because the player is not an enemy
        weapon.Attack(false, name);
				SFXScript.Instance.MakePlayerShotSound();

      }
    }
	
	// 6 - Make sure we are not outside the camera bounds
	var dist = (transform.position - Camera.main.transform.position).z;
		
	var leftBorder = Camera.main.ViewportToWorldPoint(
		new Vector3(0, 0, dist)
		).x;
		
	var rightBorder = Camera.main.ViewportToWorldPoint(
		new Vector3(1, 0, dist)
		).x;
		
	var topBorder = Camera.main.ViewportToWorldPoint(
		new Vector3(0, 0, dist)
		).y;
		
	var bottomBorder = Camera.main.ViewportToWorldPoint(
		new Vector3(0, 1, dist)
		).y;
		
	transform.position = new Vector3(
		Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
		Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
		transform.position.z
		);

    // ...
  }

  void FixedUpdate()
  {
    // 5 - Move the game object
    rigidbody2D.velocity = movement;
  }
  
  void OnDestroy()
	{
	  // Game Over.
	  // Add the script to the parent because the current game
	  // object is likely going to be destroyed immediately.
	  transform.parent.gameObject.AddComponent<GameOverScript>();
	}

  
}
