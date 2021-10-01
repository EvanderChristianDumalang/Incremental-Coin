using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserDataManager
{
    private const string PROGRESS_KEY = "Progress";

    public static UserProgressData Progress;

    public static void Load()
    {
        //melakukan pengecekan apakah ada data yang menggunakan key PROGRESS_KEY

        if (!PlayerPrefs.HasKey(PROGRESS_KEY)) //Jika belum ada key tersebut, buat baru
        {
            Progress = new UserProgressData();
            Save();
        }
        else //jika sudah ada, langsung ambil dari playerprefs
        {
            string json = PlayerPrefs.GetString(PROGRESS_KEY);
            Progress = JsonUtility.FromJson<UserProgressData>(json);
        }
    }

    public static void Save()
    {
        //menyimpan json ke playerprefs
        string json = JsonUtility.ToJson(Progress);
        PlayerPrefs.SetString(PROGRESS_KEY, json);
    }

    public static bool HasResources(int index)
    {
        return index + 1 <= Progress.ResourcesLevels.Count;
    }
}