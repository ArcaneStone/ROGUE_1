using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AlarmVisualizer))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _volumeIncreaseSpeed = 2.0f;
    [SerializeField] private float _volumeDecreaseSpeed = 1.0f;
    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private AudioSource _sound;

    private AlarmVisualizer _visualizer;
    private bool _isTriggered = false;

    private void Awake()
    {
        _visualizer = GetComponent<AlarmVisualizer>();     
    }

    private void Start()
    {
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        bool isWork = true;

        while (isWork)
        {
            if (_isTriggered)
            {
                _sound.volume = Mathf.MoveTowards(_sound.volume, _maxVolume, _volumeIncreaseSpeed * Time.deltaTime);
            }
            else
            {
                _sound.volume = Mathf.MoveTowards(_sound.volume, 0f, _volumeDecreaseSpeed * Time.deltaTime);
            }

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rogue>() != null)
        {
            _isTriggered = true;
            _visualizer.SetState(_isTriggered);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent <Rogue>() != null)
        {
            _isTriggered = false;
            _visualizer.SetState(_isTriggered);
        }
    }
}
