using General;
using System;
using UnityEngine;

public class Lightning : SceneSingletone<Lightning>, IBrokable
{
    [SerializeField] private Light[] _lights;

    public bool IsBroken { get; private set; }

    public void Broke()
    {
        if (Application.isPlaying == false)
            return;

        if (IsBroken)
            return;

        Array.ForEach(_lights, light => light.enabled = false);
        IsBroken = true;
    }

    public void Fix()
    {
        if (Application.isPlaying == false)
            return;

        if (IsBroken == false)
            return;

        Array.ForEach(_lights, light => light.enabled = true);
        IsBroken = false;
    }
}