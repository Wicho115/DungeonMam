using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Wave", menuName = "ScriptableObjects/Wave", order = 0)]
public class Wave : ScriptableObject
{
	public float waveTime;

	public EnemyObject[] enemies;
}

