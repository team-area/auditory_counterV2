using UnityEngine;
using UnityEngine.UI;

public class UserSpecs : MonoBehaviour {
    [SerializeField]
    private InputField maxCount;

    [SerializeField]
    private InputField threshold;

    [SerializeField]
    private InputField initial;

    [SerializeField]
    private Counter counter;

    [SerializeField]
    private float scaling;

    public int MaxCount {
        get {
            return int.Parse(maxCount.text);
        }
    }

    public int Threshold {
        get {
            return int.Parse(threshold.text);
        }
    }

    public int Initial {
        get {
            return int.Parse(initial.text);
        }
    }

    public void Set() {
        counter.PlayRadial(Initial, MaxCount, Threshold, scaling);
    }

    public void Increment() {
        counter.Increment(MaxCount, Threshold, scaling);
    }
}
