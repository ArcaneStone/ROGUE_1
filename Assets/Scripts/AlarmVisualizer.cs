using UnityEngine;

public class AlarmVisualizer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _alarmSprite;

    public void SetAlarmState(bool isAlarmTriggered)
    {
        if (isAlarmTriggered)
        {
            _alarmSprite.color = Color.red;
        }
        else
        {
            _alarmSprite.color = Color.white;
        }
    }
}