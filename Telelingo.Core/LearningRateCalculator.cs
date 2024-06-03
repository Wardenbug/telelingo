namespace Telelingo.Core
{
    public class LearningRateCalculator
    {
        public static readonly int MaxRate = 100;

        int CalculateNextLearningRate(int learningRate, Commands command)
        {
            switch (command)
            {
                case Commands.None:
                    return 0;
                case Commands.Hard:
                    return learningRate;
                case Commands.Good:
                    if(learningRate < 4)
                    {
                        return learningRate + 1;
                    }
                    return learningRate + 2;
                case Commands.Easy:
                    if(learningRate < 10)
                    {
                        return learningRate + 4;
                    }
                    return learningRate * 2;
                default:
                    return learningRate;
            }
        }
    }
}
