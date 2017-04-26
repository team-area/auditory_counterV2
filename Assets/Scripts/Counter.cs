using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour {
    [SerializeField]
    private UserSpecs specs;

    [SerializeField]
    private float pitchRange;

    [SerializeField]
    private float normalPitch;

    [SerializeField]
    private float thresholdPitch;

    [SerializeField]
    private AudioClip normal;

    [SerializeField]
    private AudioClip hitThreshold;

    [SerializeField]
    private GameObject listener;

    [SerializeField]
    private SoundBlock soundBlockPrefab;

    private int count;

    public int Count {
        get {
            return count;
        }
    }

    public void Increment(int maxCount, int threshold, float scaling) {
        if (count < maxCount) {
            count++;
            PlayRadial(count, maxCount, threshold, scaling);
        }
    }

    public void Reset() {
        count = 0;
    }

    public void PlayRadial(int number, int maxCount, int threshold, float scaling) {
        this.count = number;

        float percent = (float)number / maxCount;

        SoundBlock sb = Instantiate<SoundBlock>(soundBlockPrefab);
        sb.transform.position = new Vector3(sb.transform.position.x, sb.transform.position.y, scaling);
        sb.transform.RotateAround(listener.transform.position, Vector3.up, 360 * percent);

        if (number < threshold) {
            sb.Play(normal, Mathf.Lerp(normalPitch - pitchRange, normalPitch + pitchRange, (float)number / maxCount));
        } else if (count == threshold) {
            sb.Play(hitThreshold, 1);
        } else {
            sb.Play(normal, Mathf.Lerp(thresholdPitch - pitchRange, thresholdPitch + pitchRange, (float)number / maxCount));
        }
    }
}
