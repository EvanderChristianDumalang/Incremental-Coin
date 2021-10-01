using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Analytics;

public static class AnalyticsManager
{
    private static void LogEvent(string eventName, params Parameter[] parameters)
    {
        //tuliskan event di firebase
        FirebaseAnalytics.LogEvent(eventName, parameters);
    }

    public static void LogUpgradeEvent(int resourceIndex, int level)
    {
        //simpan event dengan resource index sebagai ID nya, yang diconvert jadi string
        LogEvent(FirebaseAnalytics.EventLevelUp,
            new Parameter(FirebaseAnalytics.ParameterIndex, resourceIndex.ToString()),
            new Parameter(FirebaseAnalytics.ParameterLevel, level)
            );
    }

    public static void LogUnlockEvent(int resourceIndex)
    {
        //simpan event unlock dengan resource index sebagai ID nya, yang diconvert jadi string
        LogEvent(FirebaseAnalytics.EventUnlockAchievement,
            new Parameter(FirebaseAnalytics.ParameterIndex, resourceIndex.ToString())
            );

    }

    public static void SetUserProperties(string name, string value)
    {
        FirebaseAnalytics.SetUserProperty(name, value);
    }
}