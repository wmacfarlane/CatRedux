using UnityEngine;
using System.Collections;

public class SFXScript : MonoBehaviour {


	public static SFXScript Instance;
	
	public AudioClip deathSound;
	public AudioClip playerShotSound;
	public AudioClip enemyDeathSound;
	public AudioClip enemyShotSound;
	
	void Awake()
	{

		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SFXScript");
		}
		Instance = this;
	}
	
	public void MakeDeathSound()
	{
		MakeSound(deathSound);
	}
	
	public void MakePlayerShotSound()
	{
		MakeSound(playerShotSound);
	}
	
	public void MakeEnemyShotSound()
	{
		MakeSound(enemyShotSound);
	}

	public void MakeEnemyDeathSound()
	{
		MakeSound(enemyDeathSound);
	}
	

	/// Play a given sound


	private void MakeSound(AudioClip originalClip)
	{
		// As it is not 3D audio clip, position doesn't matter.
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}
