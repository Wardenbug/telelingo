namespace Telelingo.Core
{
    public static class LearningRateCalculator
    {
        public static readonly int MaxRate = 100;

        public static DateTime GetNextShowOnDate(DateTime currentDate, int learningRate)
        {
            if (learningRate < 4)
            {
                return currentDate;
            }

            if (learningRate >= MaxRate)
            {
                return currentDate.AddDays(360);
            }

            return currentDate.AddDays(learningRate);
        }
        public static int CalculateNextLearningRate(int learningRate, Commands command)
        {
            switch (command)
            {
                case Commands.None:
                    return 0;
                case Commands.Hard:
                    return learningRate;
                case Commands.Good:
                    if (learningRate < 4)
                    {
                        return learningRate + 1;
                    }
                    return learningRate + 2;
                case Commands.Easy:
                    if (learningRate < 10)
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
