using UnityEngine;

[RequireComponent (typeof(AlarmSystem))]
public class AlarmVisualizer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    private AlarmSystem _volumeSystem;

    private void Awake()
    {
        _volumeSystem = GetComponent<AlarmSystem>();
    }

    private void Update()
    {
        SetState();
    }

    private void SetState()
    {
        if (_volumeSystem.IsTriggered)
        {
            _sprite.color = Color.red;
        }
        else
        {
            _sprite.color = Color.white;
        }
    }
}