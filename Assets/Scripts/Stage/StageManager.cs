using UnityEngine;

public class StageManager : MonoBehaviour
{
    public event System.Action StateChanged;

    [SerializeField] private SceneTransitionManager _sceneTransitionManager;
    [SerializeField] private int _maxRollCount = 3;
    [SerializeField] private int _currentRollCount;
    [SerializeField] private int _currentScore;
    [SerializeField] private int _requiredScore = 100;
    [SerializeField] private bool _canRoll = true;
    public bool CanRoll => _canRoll;

    public int CurrentStage => RunSession.CurrentStage;
    public int CurrentScore => _currentScore;
    public int RequiredScore => _requiredScore;
    public int RemainingRolls => Mathf.Max(0, _maxRollCount - _currentRollCount);


    private void Start()
    {
        _requiredScore = 100 * Mathf.RoundToInt(Mathf.Pow(2, RunSession.CurrentStage - 1));
    }

    public void AddRoll()
    {
        _currentRollCount++;
        if(_currentRollCount >= _maxRollCount)
        {
            _canRoll = false;
            
            CheckStageResult();
            
        }

        StateChanged?.Invoke();
    }

    public void AddScore(int earnedScore)
    {
        _currentScore += earnedScore;
        RunSession.TotalScore += earnedScore;
        RunSession.WalletScore += earnedScore;
        StateChanged?.Invoke();
    }

    
    private void CheckStageResult()
    {
        if(_currentScore >= _requiredScore)
        {
            Debug.Log("ステージクリア");
            Debug.Log("現在のステージ：" + RunSession.CurrentStage);
            bool shouldOpenShop = RunSession.CurrentStage % 3 == 0;
            RunSession.CurrentStage++;
            _requiredScore *= 2;
            _currentScore = 0;
            _currentRollCount = 0;
            _canRoll = true;
            if(shouldOpenShop == true)
            {
                _sceneTransitionManager.GoToShop();
            }
            
        }
        else
        {
            Debug.Log("ゲームオーバー");
            RunResult._finalScore = RunSession.TotalScore;
            RunResult._finalStage = RunSession.CurrentStage;
            _sceneTransitionManager.GoToResult();

        }

    }

   
}
