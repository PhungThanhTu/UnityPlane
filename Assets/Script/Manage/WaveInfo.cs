using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WaveInfo",menuName ="WaveData")]
public class WaveInfo:ScriptableObject
{
    public WaveData data;


    public string toJson()
    {
        return JsonUtility.ToJson(data);
    }
    public void fromJson(string jsonData)
    {
        this.data = JsonUtility.FromJson<WaveData>(jsonData);
    }
}
[System.Serializable]
public class SwarnInfo
{
  public  int EnemyId;
    public int count;
}
[System.Serializable]
public class Wave
{
    public SwarnInfo[] swarns;
}
[System.Serializable]
public class WaveList
{
    public Wave[] waves;
}
[System.Serializable]
public class WaveData
{
    public WaveList data;
}
