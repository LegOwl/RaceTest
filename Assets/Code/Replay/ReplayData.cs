using UnityEngine;

public class ReplayData
{
    public Vector3 position {get; private set;}
    public Quaternion rotation { get; private set; }

    public ReplayData(Vector3 position, Quaternion rotation)
    {
        this.position = position;
        this.rotation = rotation;
    }
    
}
