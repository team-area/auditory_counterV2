using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour {
    [SerializeField]
    private Text countText;

    [SerializeField]
    private Text threshText;

    [SerializeField]
    private UserSpecs userSpecs;

    [SerializeField]
    private Counter counter;

    private void Update() {
        countText.text = string.Format("{0} / {1}", counter.Count, userSpecs.MaxCount);
        threshText.text = "" + userSpecs.Threshold;
    }
}
