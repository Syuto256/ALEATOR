using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
    [FormerlySerializedAs("_noHandScore")]
    [SerializeField] private int _noHandBaseScore = 0;

    [FormerlySerializedAs("_oneScore")]
    [SerializeField] private int _oneBaseScore = 30;
    [FormerlySerializedAs("_twoScore")]
    [SerializeField] private int _twoBaseScore = 40;
    [FormerlySerializedAs("_threeScore")]
    [SerializeField] private int _threeBaseScore = 50;
    [FormerlySerializedAs("_fourScore")]
    [SerializeField] private int _fourBaseScore = 60;
    [FormerlySerializedAs("_fiveScore")]
    [SerializeField] private int _fiveBaseScore = 75;
    [FormerlySerializedAs("_sixScore")]
    [SerializeField] private int _sixBaseScore = 100;

    [FormerlySerializedAs("_hifumiScore")]
    [SerializeField] private int _hifumiBaseScore = 10;
    [FormerlySerializedAs("_shigoroScore")]
    [SerializeField] private int _shigoroBaseScore = 150;

    [FormerlySerializedAs("_tripleTwoScore")]
    [SerializeField] private int _tripleTwoBaseScore = 120;
    [FormerlySerializedAs("_tripleThreeScore")]
    [SerializeField] private int _tripleThreeBaseScore = 140;
    [FormerlySerializedAs("_tripleFourScore")]
    [SerializeField] private int _tripleFourBaseScore = 160;
    [FormerlySerializedAs("_tripleFiveScore")]
    [SerializeField] private int _tripleFiveBaseScore = 200;
    [FormerlySerializedAs("_tripleSixScore")]
    [SerializeField] private int _tripleSixBaseScore = 250;

    [FormerlySerializedAs("_pinZoroScore")]
    [SerializeField] private int _pinZoroBaseScore = 300;

    public int CalculateBaseScore(DiceJudge.DiceHand diceHand)
    {
        switch (diceHand)
        {
            case DiceJudge.DiceHand.NoHand:
                return _noHandBaseScore;
        
            case DiceJudge.DiceHand.One:
                return _oneBaseScore;
        
            case DiceJudge.DiceHand.Two:
                return _twoBaseScore;
        
            case DiceJudge.DiceHand.Three:
                return _threeBaseScore;
        
            case DiceJudge.DiceHand.Four:
                return _fourBaseScore;
        
            case DiceJudge.DiceHand.Five:
                return _fiveBaseScore;
        
            case DiceJudge.DiceHand.Six:
                return _sixBaseScore;
        
            case DiceJudge.DiceHand.Hifumi:
                return _hifumiBaseScore;
        
            case DiceJudge.DiceHand.Shigoro:
                return _shigoroBaseScore;
        
            case DiceJudge.DiceHand.TripleTwo:
                return _tripleTwoBaseScore;
        
            case DiceJudge.DiceHand.TripleThree:
                return _tripleThreeBaseScore;
        
            case DiceJudge.DiceHand.TripleFour:
                return _tripleFourBaseScore;
        
            case DiceJudge.DiceHand.TripleFive:
                return _tripleFiveBaseScore;
        
            case DiceJudge.DiceHand.TripleSix:
                return _tripleSixBaseScore;
        
            case DiceJudge.DiceHand.PinZoro:
                return _pinZoroBaseScore;
        
            default:
                return _noHandBaseScore;
        }

    }
}
