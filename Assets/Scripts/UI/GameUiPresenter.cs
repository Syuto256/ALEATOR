using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameUiPresenter : MonoBehaviour
{
    [SerializeField] private TimingBar _timingBar;
    [SerializeField] private DiceInputManager _diceInputManager;
    [SerializeField] private StageManager _stageManager;

    [SerializeField] private RectTransform _timingTrack;
    [SerializeField] private RectTransform _cursor;
    [SerializeField] private Image _cursorImage;
    [SerializeField] private Sprite[] _cursorSprites;
    [SerializeField] private RectTransform[] _hitMarkerRects;
    [SerializeField] private Image[] _hitMarkerImages;
    [SerializeField] private Sprite[] _hitMarkerSprites;

    [SerializeField] private Image[] _diceImages;
    [SerializeField] private Sprite _unsetDiceSprite;
    [SerializeField] private Sprite[] _diceValueSprites;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _targetText;
    [SerializeField] private TextMeshProUGUI _stageText;
    [SerializeField] private TextMeshProUGUI _remainingRollsText;
    [SerializeField] private TextMeshProUGUI _handText;
    [SerializeField] private TextMeshProUGUI _gainText;
    [SerializeField] private Image _scoreProgress;
    [SerializeField] private GameObject _confirmPrompt;
    [SerializeField] private GameObject _gameOverLabel;

    private void OnEnable()
    {
        _diceInputManager.DiceSelected += ShowSelectedDie;
        _diceInputManager.RollResolved += ShowResolvedRoll;
        _stageManager.StateChanged += RefreshStage;
    }

    private void OnDisable()
    {
        _diceInputManager.DiceSelected -= ShowSelectedDie;
        _diceInputManager.RollResolved -= ShowResolvedRoll;
        _stageManager.StateChanged -= RefreshStage;
    }

    private void Start()
    {
        RefreshStage();
    }

    private void LateUpdate()
    {
        float trackWidth = _timingTrack.rect.width;
        float left = trackWidth * (52f / 1248f - 0.5f);
        float right = trackWidth * (1196f / 1248f - 0.5f);
        float x = Mathf.Lerp(left, right, _timingBar.CursorProgress);
        _cursor.anchoredPosition = new Vector2(x, _cursor.anchoredPosition.y);

        int colorIndex = Mathf.Clamp(_diceInputManager.CurrentInputCount, 0, _cursorSprites.Length - 1);
        _cursorImage.sprite = _cursorSprites[colorIndex];
    }

    private void ShowSelectedDie(int inputIndex, int diceValue, float cursorProgress)
    {
        if (inputIndex == 0)
        {
            for (int i = 0; i < _diceImages.Length; i++)
            {
                _diceImages[i].sprite = _unsetDiceSprite;
            }

            for (int i = 0; i < _hitMarkerImages.Length; i++)
            {
                _hitMarkerImages[i].gameObject.SetActive(false);
            }

            _handText.text = "ROLLING";
            _gainText.text = string.Empty;
        }

        if (inputIndex < _diceImages.Length)
        {
            _diceImages[inputIndex].sprite = _diceValueSprites[Mathf.Clamp(diceValue, 0, _diceValueSprites.Length - 1)];
        }

        if (inputIndex < _hitMarkerImages.Length)
        {
            float trackWidth = _timingTrack.rect.width;
            float left = trackWidth * (52f / 1248f - 0.5f);
            float right = trackWidth * (1196f / 1248f - 0.5f);
            float x = Mathf.Lerp(left, right, cursorProgress);
            _hitMarkerRects[inputIndex].anchoredPosition = new Vector2(x, _hitMarkerRects[inputIndex].anchoredPosition.y);
            _hitMarkerImages[inputIndex].sprite = _hitMarkerSprites[inputIndex];
            _hitMarkerImages[inputIndex].gameObject.SetActive(true);
        }
    }

    private void ShowResolvedRoll(DiceJudge.DiceHand hand, int baseScore)
    {
        _handText.text = HandLabel(hand);
        _gainText.text = "+" + baseScore.ToString("N0");
    }

    private void RefreshStage()
    {
        _scoreText.text = _stageManager.CurrentScore.ToString("N0");
        _targetText.text = _stageManager.RequiredScore.ToString("N0");
        _stageText.text = _stageManager.CurrentStage.ToString("D2");
        _remainingRollsText.text = "ROLLS  " + _stageManager.RemainingRolls + " / 3";
        _scoreProgress.fillAmount = _stageManager.RequiredScore > 0
            ? Mathf.Clamp01((float)_stageManager.CurrentScore / _stageManager.RequiredScore)
            : 0f;

        _confirmPrompt.SetActive(_stageManager.CanRoll);
        _gameOverLabel.SetActive(!_stageManager.CanRoll);
    }

    private static string HandLabel(DiceJudge.DiceHand hand)
    {
        switch (hand)
        {
            case DiceJudge.DiceHand.NoHand: return "NO HAND";
            case DiceJudge.DiceHand.One: return "1 EYE";
            case DiceJudge.DiceHand.Two: return "2 EYE";
            case DiceJudge.DiceHand.Three: return "3 EYE";
            case DiceJudge.DiceHand.Four: return "4 EYE";
            case DiceJudge.DiceHand.Five: return "5 EYE";
            case DiceJudge.DiceHand.Six: return "6 EYE";
            case DiceJudge.DiceHand.Hifumi: return "HIFUMI";
            case DiceJudge.DiceHand.Shigoro: return "SHIGORO";
            case DiceJudge.DiceHand.TripleTwo: return "2-2-2";
            case DiceJudge.DiceHand.TripleThree: return "3-3-3";
            case DiceJudge.DiceHand.TripleFour: return "4-4-4";
            case DiceJudge.DiceHand.TripleFive: return "5-5-5";
            case DiceJudge.DiceHand.TripleSix: return "6-6-6";
            case DiceJudge.DiceHand.PinZoro: return "PINZORO";
            default: return hand.ToString().ToUpperInvariant();
        }
    }
}
