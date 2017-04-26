using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBlock : MonoBehaviour {
    [SerializeField]
    private AudioSource source;

    public Vector3 Position {
        set {
            this.transform.position = value;
        }
    }

    public void Play(AudioClip clip, float pitch) {
        source.clip = clip;
        source.pitch = pitch;
        source.Play();
        StartCoroutine(PlayThenDestroy(clip, pitch));
    }

    private IEnumerator PlayThenDestroy(AudioClip clip, float pitch) {
        source.Play();
        while (source.isPlaying) {
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
