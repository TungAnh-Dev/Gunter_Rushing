using UnityEngine;

public interface IWaveObserver 
{
    public abstract void OnWaveStart();
    public abstract void OnWaveEnd();
}