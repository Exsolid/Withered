using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HugAction : MonoBehaviour
{
    [SerializeField] private string _interactionActionName;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private MovementBase _movement;
    [SerializeField] private BooAnimator _booAnimator;
    [SerializeField] private LayerMask _levelEntryMask;
    private LevelEntryInfo _levelEntryInfo;
    private bool _mayHug;

    // Update is called once per frame
    void Update()
    {
        if (_input.actions[_interactionActionName].triggered && _mayHug)
        {
            _booAnimator.HugAnimation(_movement, _levelEntryInfo.SceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((1 << other.gameObject.layer).Equals(_levelEntryMask))
        {
            _levelEntryInfo = other.GetComponent<LevelEntryInfo>();
            _mayHug = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((1 << other.gameObject.layer).Equals(_levelEntryMask))
        {
            _mayHug = false;
        }
    }
}
