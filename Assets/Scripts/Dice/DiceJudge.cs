using UnityEngine;

public class DiceJudge : MonoBehaviour
{
    public enum DiceHand
    {
        NoHand,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Hifumi,
        Shigoro,
        TripleTwo,
        TripleThree,
        TripleFour,
        TripleFive,
        TripleSix,
        PinZoro
    }

    public DiceHand JudgeHand(int[] diceRolls)
    {
        int[] sortedDiceValues = (int[])diceRolls.Clone();
        System.Array.Sort(sortedDiceValues);


        if(sortedDiceValues[0] == 0)
        {
            return DiceHand.NoHand;
        }
        if(diceRolls[0] == diceRolls[1] && diceRolls[1] == diceRolls[2])
        {
            

            switch(diceRolls[0])
            {
                case 1:
                return DiceHand.PinZoro;

                case 2:
                return DiceHand.TripleTwo;

                case 3:
                return DiceHand.TripleThree;

                case 4:
                return DiceHand.TripleFour;

                case 5:
                return DiceHand.TripleFive;

                case 6:
                return DiceHand.TripleSix;

                
            }
        }
        
        if(sortedDiceValues[0] == 1 && sortedDiceValues[1] == 2 && sortedDiceValues[2] == 3)
        {
            return DiceHand.Hifumi;
        }
        if(sortedDiceValues[0] == 4 && sortedDiceValues[1] == 5 && sortedDiceValues[2] == 6)
        {
            return DiceHand.Shigoro;
        }
        
        if(sortedDiceValues[0] == sortedDiceValues[1])
        {
            switch(sortedDiceValues[2])
            {
                

                case 1:
                return DiceHand.One;

                case 2:
                return DiceHand.Two;

                case 3:
                return DiceHand.Three;

                case 4:
                return DiceHand.Four;

                case 5:
                return DiceHand.Five;

                case 6:
                return DiceHand.Six;

                
            }
        }
        else if(sortedDiceValues[1] == sortedDiceValues[2])
        {
            switch(sortedDiceValues[0])
            {
                

                case 1:
                return DiceHand.One;

                case 2:
                return DiceHand.Two;

                case 3:
                return DiceHand.Three;

                case 4:
                return DiceHand.Four;

                case 5:
                return DiceHand.Five;

                case 6:
                return DiceHand.Six;

                
            }

        }


        return DiceHand.NoHand;
        
    }

}
