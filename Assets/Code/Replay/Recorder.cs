using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _recordFrequancy;
    private float _timer;
    private bool _isRecording = false;
    public Queue<ReplayData> recordingQueue {get; private set;}

    private void Awake()
    {
        recordingQueue = new Queue<ReplayData>();
    }
    
    public void StartRecording()
    {
        if (recordingQueue.Count > 0)
        {
            ResetRecording();
        }
        _isRecording = true;
    }

    public void StopRecording()
    {
        _isRecording = false;
    }
    
    private void ResetRecording()
    {
        recordingQueue.Clear();
        _timer = 0;
    }
    
    private void RecordByFrame(ReplayData data)
    {
        recordingQueue.Enqueue(data);
    }

    private void LateUpdate() // Запись объекта с указанной частотой
    {
        _timer += Time.unscaledDeltaTime;
        if (_timer >= 1 / _recordFrequancy && _isRecording)
        {
            ReplayData data = new ReplayData(_playerTransform.position, _playerTransform.rotation);
            RecordByFrame(data);
            _timer = 0;
        }
    }
}
