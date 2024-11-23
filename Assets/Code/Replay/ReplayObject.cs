using UnityEngine;

public class ReplayObject : MonoBehaviour
{
    public void SetDataForFrame(Vector3 position, Quaternion rotation)
    {  
        transform.position = position;
        transform.rotation = rotation;
    }
}
