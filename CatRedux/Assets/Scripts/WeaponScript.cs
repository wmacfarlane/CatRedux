using UnityEngine;
using System;
/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{

  public Transform shotPrefab;


  public float shootingRate;


  private float shootCooldown;

  void Start()
  {
    shootCooldown = 0f;
    //shootingRate = 2.5f * UnityEngine.Random.Range(.8f, 1.2f);
  }

  void Update()
  {
    if (shootCooldown > 0)
    {
      shootCooldown -= Time.deltaTime;
    }
  }



  /// Create a new projectile if possible

  public void Attack(bool isEnemy, string name)
  {
  	if(isEnemy)
  	    shootingRate = 2.5f * UnityEngine.Random.Range(.8f, 1.2f);
    if (CanAttack)
    {
		GameObject creature = GameObject.Find(name);


		shootCooldown = shootingRate;

		      // Create a new shot
		var shotTransform = Instantiate(shotPrefab) as Transform;
			
		      // Assign position
      shotTransform.position = transform.position;
	  
	        // The is enemy property
      ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
      if (shot != null)
      {
        shot.isEnemyShot = isEnemy;
      }

      // Make the weapon shot always towards it
      MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();






		//move.direction = script.direction;
		float coefficient = (float) Math.Sqrt( 1 / (move.direction.x * move.direction.x + move.direction.y * move.direction.y));
		move.direction.x *= coefficient;
		move.direction.y *= coefficient;
		Vector2 ls = creature.transform.localScale;
		float x = ls.x * -1;
		move.direction.x *= (x * 10);
		

	  
// Kept these as a result of a merge
//      	Transform enemy = GameObject.Find(enemyName).GetComponent<Transform>();

//			move.direction =  enemy.forward; // Should give you the Vector3 position in the forward direction of the player
		
		//move.direction = this.transform.direction;

      
    }
  }

  /// <summary>
  /// Is the weapon ready to create a new projectile?
  /// </summary>
  public bool CanAttack
  {
    get
    {
      return shootCooldown <= (0f);
    }
  }
}
