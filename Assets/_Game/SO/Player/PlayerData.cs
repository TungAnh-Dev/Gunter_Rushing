using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    [SerializeField] float moveSpeed;
    [SerializeField] float hp;

    public float MoveSpeed { get => moveSpeed;}
    public float Hp { get => hp;}
}