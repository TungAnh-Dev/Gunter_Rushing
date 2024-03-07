using UnityEngine;

[CreateAssetMenu(fileName = "WaveSO", menuName = "ScriptableObjects/WaveSO", order = 1)]
public class WaveSO : ScriptableObject
{
    public Enemy[] enemisInWave;
    public float timeDelayAppearWave;
    public float numberToSpawn;
}