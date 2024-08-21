using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _alarmIncreaseSpeed = 2.0f;
    [SerializeField] private float _alarmDecreaseSpeed = 1.0f;
    [SerializeField] private float _alarmMaxVolume = 1.0f;
    [SerializeField] private AudioSource _alarmSound;

    private bool _isAlarmTriggered = false;
    private AlarmVisualizer _visualizer;

    private void Start()
    {
        _visualizer = GetComponent<AlarmVisualizer>();   
    }

    private void Update()
    {
        if (_isAlarmTriggered)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, _alarmMaxVolume, _alarmIncreaseSpeed * Time.deltaTime);
        }
        else
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, 0f, _alarmDecreaseSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rogue>() != null)
        {
            _isAlarmTriggered = true;
            _visualizer.SetAlarmState(_isAlarmTriggered);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent <Rogue>() != null)
        {
            _isAlarmTriggered = false;
            _visualizer.SetAlarmState(_isAlarmTriggered);
        }
    }
}
