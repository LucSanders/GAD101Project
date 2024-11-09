using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public string playerName;
    public int health;
    public int attackPower;
    public Vector2Int currentPosition;

    void Start()
    {
        health = 100;
        attackPower = 20;
        currentPosition = new Vector2Int(0, 0);
    }

    // Player logic for attacking, moving, etc. goes here
}
