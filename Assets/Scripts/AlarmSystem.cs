using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _volumeIncreaseSpeed = 2.0f;
    [SerializeField] private float _volumeDecreaseSpeed = 1.0f;
    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private AudioSource _sound;

    public bool IsTriggered { get; private set; } = false;

    private void Start()
    {
        StartCoroutine(ChangeVolume(_sound.volume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        float minTargetValue = 0.01f;
        float speed;

        if (IsTriggered)       
            speed = _volumeIncreaseSpeed;       
        else      
            speed = _volumeDecreaseSpeed;

        while (Mathf.Abs(_sound.volume - targetVolume) > minTargetValue)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, targetVolume, speed * Time.deltaTime);
            yield return null;
        }

        yield break;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rogue>() != null)
        {
            IsTriggered = true;
            StartCoroutine(ChangeVolume(_maxVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent <Rogue>() != null)
        {
            IsTriggered = false;
            StartCoroutine(ChangeVolume(0f));
        }
    }
}
