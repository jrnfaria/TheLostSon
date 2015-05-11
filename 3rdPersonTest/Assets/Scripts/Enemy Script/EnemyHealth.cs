using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
	public int fullHealth;
	public int health;
	private float healthRatio;

	void Start ()
	{
		healthRatio = 1f;
	}

	void Update()
	{
	healthRatio = health / fullHealth;
	}
}

