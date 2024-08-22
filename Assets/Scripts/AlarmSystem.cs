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
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        bool isWork = true;

        while (isWork)
        {
            if (IsTriggered)
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
            IsTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent <Rogue>() != null)
        {
            IsTriggered = false;
        }
    }
}
