using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    public int id;
    public Sprite image;
    public bool isBonus = false;
    public int speedGiven;
    public float speedDuration;
    public int jumpForceGiven;
    public float jumpForceDuration;
    public int climbSpeedGiven;
    public float climbSpeedDuration;
}
