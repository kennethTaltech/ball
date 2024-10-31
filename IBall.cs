namespace Exc1
{

    public interface IBall
    {
        float CalculateAverageSpeed(float start, float end, float time);
        bool IsGoal(float pos);
        int CountGoals(float[] pos);
        void PrintKineticEnergy(float velocity);
        string GenerateUniqueCode();
    }

}