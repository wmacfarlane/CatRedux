using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public float xMargin = 1f;		// Distance in the x axis the player can move before the camera follows.
	public float yMargin = 1f;		// Distance in the y axis the player can move before the camera follows.
	public float xSmooth = 800f;		// How smoothly the camera catches up with it's target movement in the x axis.
	public float ySmooth = 8f;		// How smoothly the camera catches up with it's target movement in the y axis.
	public Vector3 maxXAndY;		// The maximum x and y coordinates the camera can have.
	public Vector3 minXAndY;		// The minimum x and y coordinates the camera can have.


	private Transform player;		// Reference to the player's transform.


	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
		maxXAndY = new Vector3((float)28.3212, (float)100);
		minXAndY = new Vector3((float)-0.4984117, (float)1.36408);
	}


	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}

	void FixedUpdate ()
	{
		TrackPlayer();
	}


	void update()
	{

	}
	
	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;
		
		/*
		// If the player has moved beyond the x margin...
		if(CheckXMargin()){
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
		}
		*/


		
		/*
		Vector3 point = camera.WorldToViewportPoint(target.position);
      Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
      Vector3 destination = transform.position + delta;
      Vector3 result = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		*/
		
		targetX = player.position.x;

		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
		
		
		
		
		// Set the camera's position to the target position with the same z component.
		
		
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
