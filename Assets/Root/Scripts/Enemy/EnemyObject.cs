using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New EnemyObject", menuName = "ScriptableObjects/EnemyObject", order = 0)]
public class EnemyObject : ScriptableObject
{
    public Enemy enemy;
    public float waitForSpawnSeconds;
}

