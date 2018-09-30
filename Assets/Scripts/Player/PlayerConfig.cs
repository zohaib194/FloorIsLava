using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="PlayerConfig")]
public class PlayerConfig : ScriptableObject {

	public Vector2 velocity;
	public float mana;
	public float hp;
}
