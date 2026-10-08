using System.Collections.Generic;

public static class RunSession
{
    public static int CurrentStage;
    public static int TotalScore;
    public static int WalletScore;
    public static List<SkillData> OwnedSkills = new();
    
    public static void ResetRun()
    {
        CurrentStage = 1;
        TotalScore = 0;
        WalletScore = 0;
        OwnedSkills.Clear();

    } 

}
