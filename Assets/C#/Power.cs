using General;
using NaughtyAttributes;
using Ordering;
using UnityEngine;

public class Power : SceneSingletone<Power>, IBrokable
{
    [SerializeField, Range(0, 1)] private float _brokeChance;
    public bool IsBroken { get; private set; }

    [Button("Broke")]
    public void Broke()
    {
        if (Application.isPlaying == false)
            return;

        if (IsBroken)
            return;

        IsBroken = true;
        Terminal.Instance.Broke();
        Lightning.Instance.Broke();
    }

    [Button("Fix")]
    public void Fix()
    {
        if (Application.isPlaying == false)
            return;

        if (IsBroken == false)
            return;

        IsBroken = false;
        Lightning.Instance.Fix();
    }

    private void Update()
    {
        if (IsBroken == false && Random.value < _brokeChance)
            Broke();
    }

    private void OnMouseDown()
    {
        Fix();
    }
}
