using UnityEngine;

namespace Lesson3.State.DataBase
{
    public class PlayerPrefsStateManager : IApplicationStateManager
    {	
        public void SaveState(UserState user)
        {
            var json = JsonUtility.ToJson(user);
            UnityEngine.PlayerPrefs.SetString("userState", json);
            UnityEngine.PlayerPrefs.Save();
        }

        public UserState GetState()
        {
            var json = UnityEngine.PlayerPrefs.GetString("userState");
            return JsonUtility.FromJson<UserState>(json);
        }
    }
}