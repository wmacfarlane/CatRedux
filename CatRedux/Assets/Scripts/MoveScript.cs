using UnityEngine;
using System;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour
{
  // 1 - Designer variables

  /// <summary>
  /// Object speed
  /// </summary>
  public Vector2 speed = new Vector2(10, 10);

  /// <summary>
  /// Moving direction
  /// </summary>
  public Vector2 direction = new Vector2(-1, 0);

  private Vector2 movement;

  void Update()
  {
  		double dirCoefficient = Math.Sqrt(1/(direction.x * direction.x + direction.y * direction.y));
    	Vector2 newDir = new Vector2((float) (direction.x * dirCoefficient), (float) (direction.y * dirCoefficient));
    // 2 - Movement
    movement = new Vector2(
      speed.x * newDir.x,
      speed.y * newDir.y);
  }

  void FixedUpdate()
  {
    // Apply movement to the rigidbody
    rigidbody2D.velocity = movement;
  }
}
