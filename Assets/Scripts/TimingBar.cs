using UnityEngine;
using UnityEngine.Serialization;

public class TimingBar : MonoBehaviour
{
    
    [SerializeField] private Transform _cursorTransform;
    [FormerlySerializedAs("_speed")]
    [SerializeField] private float _cursorSpeed = 5;
    [FormerlySerializedAs("_nowMovingRight")]
    [SerializeField] private bool _isMovingRight = true;
    [FormerlySerializedAs("_leftPoint")]
    [SerializeField] private Transform _leftBoundary;
    [FormerlySerializedAs("_rightPoint")]
    [SerializeField] private Transform _rightBoundary;
    [FormerlySerializedAs("_width")]
    [SerializeField] private float _segmentWidth;
    [FormerlySerializedAs("_diceValues")]
    [SerializeField] private int[] _segmentDiceValues = {0,6,5,4,3,2,1,2,3,4,5,6,0};
    [FormerlySerializedAs("_diceRoll")]
    [SerializeField] private int _currentDiceValue;
    public int CurrentDiceValue => _currentDiceValue;

    public float CursorProgress => Mathf.InverseLerp(
        _leftBoundary.position.x,
        _rightBoundary.position.x,
        _cursorTransform.position.x);

    private void Start()
    {
        float barWidth = _rightBoundary.position.x - _leftBoundary.position.x;
        _segmentWidth = barWidth / 13;
        
    }

    private void Update()
    {
        if(_isMovingRight == true)
        {
            _cursorTransform.Translate(Vector2.right*_cursorSpeed*Time.deltaTime);   
        }
        else
        {
             _cursorTransform.Translate(Vector2.left*_cursorSpeed*Time.deltaTime);
        }

        if(_cursorTransform.position.x >= _rightBoundary.position.x)
        {
            Vector3 fixedPosition = _cursorTransform.position;
            fixedPosition.x = _rightBoundary.position.x;
            _cursorTransform.position = fixedPosition;
            _isMovingRight = false;
        }

        if(_cursorTransform.position.x <= _leftBoundary.position.x)
        {
            Vector3 fixedPosition = _cursorTransform.position;
            fixedPosition.x = _leftBoundary.position.x;
            _cursorTransform.position = fixedPosition;
            _isMovingRight = true;
        }

        float distanceFromLeft = _cursorTransform.position.x - _leftBoundary.position.x;
        int segmentIndex = Mathf.FloorToInt(distanceFromLeft / _segmentWidth);
        segmentIndex = Mathf.Clamp(segmentIndex,0,12);
        _currentDiceValue = _segmentDiceValues[segmentIndex];
        
        
    }


}
