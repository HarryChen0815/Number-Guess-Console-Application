﻿namespace NumberGuessConsoleApplication
{
    // Options class to store configuration options
    public class SettingOptions
    {
        public int MinRange { get; }
        public int MaxRange { get; }

        public SettingOptions(int minRange, int maxRange)
        {
            MinRange = minRange;
            MaxRange = maxRange;
        }
    }
}