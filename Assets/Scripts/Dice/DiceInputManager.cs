using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class DiceInputManager : MonoBehaviour
{
    public event System.Action<int, int, float> DiceSelected;
    public event System.Action<DiceJudge.DiceHand, int> RollResolved;

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private DiceJudge _diceJudge;
    [SerializeField] private TimingBar _timingBar;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private StageManager _stageManager;
    [SerializeField] private SkillManager _skillManager;
    [FormerlySerializedAs("_diceRoll")]
    [SerializeField] private int _currentDiceValue;
    [FormerlySerializedAs("_diceNumber")]
    [SerializeField] private int[] _rollValues = new int[3];
    [FormerlySerializedAs("_swingsNumber")]
    [SerializeField] private int _maxInputCount = 3;
    [FormerlySerializedAs("_nowSwings")]
    [SerializeField] private int _currentInputCount = 0;
    [FormerlySerializedAs("_diceHand")]
    [SerializeField] private DiceJudge.DiceHand _currentHand;
    [FormerlySerializedAs("_diceScore")]
    [SerializeField] private int _baseScore;
    [SerializeField] private int _finalScore;

    public int CurrentInputCount => _currentInputCount;
    

    private void Update()
    {
        if(_stageManager.CanRoll)
        {
            if(_playerInput.actions["Roll"].WasPressedThisFrame())
            {
                if(_maxInputCount > _currentInputCount)
                {
                    _currentDiceValue = _timingBar.CurrentDiceValue;
                    _rollValues[_currentInputCount] = _currentDiceValue;
                    DiceSelected?.Invoke(_currentInputCount, _currentDiceValue, _timingBar.CursorProgress);
                    _currentInputCount++;
                    if(_maxInputCount == _currentInputCount)
                    {
                        _currentHand = _diceJudge.JudgeHand(_rollValues);
                        Debug.Log(_currentHand);
                        _baseScore = _scoreManager.CalculateBaseScore(_currentHand);
                        _finalScore = _skillManager.ApplyScoreEffects(_baseScore);
                        Debug.Log("スコアは"+_finalScore);
                        _stageManager.AddScore(_finalScore);
                        _stageManager.AddRoll();
                        RollResolved?.Invoke(_currentHand, _finalScore);
                        ResetRoll();
                    }

                }


    
            }
        }
    }

    private void ResetRoll()
    {
        _currentInputCount = 0;
        System.Array.Clear(_rollValues, 0, _rollValues.Length);
        
    }
}
