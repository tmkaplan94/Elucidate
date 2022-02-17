using UnityEngine;

[RequireComponent(typeof (PlayAudioSource))]
public class PlayOnStart : MonoBehaviour
{
    private PlayAudioSource _sound;
    // Start is called before the first frame update
    void Start()
    {
        _sound = GetComponent<PlayAudioSource>();
        _sound.Play();
    }

}
