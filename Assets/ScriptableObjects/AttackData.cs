using UnityEngine;

[CreateAssetMenu(
    fileName = "AttackData",
    menuName = "Game Data/Attack Data"
)]
public class AttackData : ScriptableObject
{
    public int damage;

    public float range;

    public float cooldown;
}
