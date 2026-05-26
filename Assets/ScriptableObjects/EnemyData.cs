using UnityEngine;

[CreateAssetMenu(
    fileName = "EnemyData",
    menuName = "Game Data/Enemy Data"
)]
public class EnemyData : ScriptableObject
{
    public int health;

    public float moveSpeed;

    public int damage;
}
