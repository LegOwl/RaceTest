using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class ReplayController : MonoBehaviour
{
    [SerializeField] private GameObject _ghostCarPrefab;
    [SerializeField] private float _replaySpeed;
    [SerializeField] private Recorder _recorder;
    
    private ReplayObject _replayObject;
    private bool _isReplayMode = false;
    
    public void StartReplay()
    {
        _isReplayMode = true;
        var ghostCar = Instantiate(_ghostCarPrefab, Vector3.zero, Quaternion.identity);
        _replayObject = ghostCar.GetComponent<ReplayObject>();
        StartCoroutine(ReplayCoroutine(_recorder.recordingQueue));
    }

    private IEnumerator ReplayCoroutine(Queue<ReplayData> replayQueue)
    {
        if (replayQueue.Count == 0)
        {
            yield break;
        }
        
        // Начальная точка
        var previousData = replayQueue.Dequeue(); 
        _replayObject.SetDataForFrame(previousData.position, previousData.rotation);
        
        while (replayQueue.Count > 0 && _isReplayMode)
        {
            // Следующая точка
            var nextData = replayQueue.Dequeue(); 
            
            // Подсчеты для интерполяции
            float elapsedTime = 0f;
            float distance = Vector3.Distance(previousData.position, nextData.position);
            float duration = distance / _replaySpeed;

            // Интерполяция между текущей и следующей точкой
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;
                Vector3 interpolatedPosition = Vector3.Lerp(previousData.position, nextData.position, t);
                Quaternion interpolatedRotation = Quaternion.Slerp(previousData.rotation, nextData.rotation, t);
                
                _replayObject.SetDataForFrame(interpolatedPosition, interpolatedRotation);
                yield return null;
            }
            
            // Переходим к следующей точке
            previousData = nextData; 
        }
        _isReplayMode = false;
    }
}