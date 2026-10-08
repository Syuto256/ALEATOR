using UnityEngine;
using TMPro;

public class ResultUiPresenter : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _finalScoreText;
   [SerializeField] private TextMeshProUGUI _finalStageText;

    

    private void Start()
    {
        _finalScoreText.text = RunResult._finalScore.ToString();
        _finalStageText.text = RunResult._finalStage.ToString();
    }

    
}
