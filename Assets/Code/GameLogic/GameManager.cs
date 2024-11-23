using Ashsvp;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private ReplayController _replayController;
    [SerializeField] private Recorder _recorder;
    
    private SimcadeVehicleController _simcadeVehicleController;
    private Rigidbody _playerRigidbody;
    private Vector3 _originalPlayerPosition;
    private int _countRace = 0;
    private Controls _controls;
    
    private void Start()
    {
        _playerRigidbody = _playerTransform.GetComponent<Rigidbody>();
        _controls = _playerTransform.GetComponent<SimcadeVehicleController>().controls;
        _originalPlayerPosition = _playerTransform.position;
        
        EventBus.Instance.onStartRace += StartRace;
        EventBus.Instance.onFinishRace += FinishRace;
        EventBus.Instance.CountdownStart();
    }
    private void StartRace()
    {
        _controls.Enable();
        
        _countRace++;
        if (_countRace == 1)
        {
            _recorder.StartRecording();
        }
        else
        {
            _replayController.StartReplay();
        }
    }
    private void FinishRace()
    {
        _controls.Disable();
        
        //Вернем игрока на старт
        _playerRigidbody.GetComponent<Rigidbody>().velocity = Vector3.zero; 
        _playerTransform.transform.position = _originalPlayerPosition;
        
        if (_countRace == 1)
        {
            _recorder.StopRecording();
            EventBus.Instance.CountdownStart();
        }

        if (_countRace == 2)
        {
            EventBus.Instance.EndGame();
        }
    }
    
    private void OnDestroy()
    {
        EventBus.Instance.onStartRace -= StartRace;
        EventBus.Instance.onFinishRace -= FinishRace;
    }
}
