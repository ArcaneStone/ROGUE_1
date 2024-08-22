using UnityEngine;

public class AlarmVisualizer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;

    public void SetState(bool isTriggered)
    {
        if (isTriggered)
        {
            _sprite.color = Color.red;
        }
        else
        {
            _sprite.color = Color.white;
        }
    }
}