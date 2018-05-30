namespace Lesson3.State.PlayerPrefs
{
    public class PlayerPrefsBadStateManager : IApplicationStateManager
    {
        public void SaveState(UserState user)
        {
            UnityEngine.PlayerPrefs.SetString("userName", user.userName);
            UnityEngine.PlayerPrefs.SetInt("playedGames", user.playedGames);
            UnityEngine.PlayerPrefs.SetInt("bestScore", user.bestScore);
            UnityEngine.PlayerPrefs.SetInt("lastScore", user.lastScore);
            UnityEngine.PlayerPrefs.Save();
        }

        public UserState GetState()
        {
            var user = new UserState();
            user.bestScore = UnityEngine.PlayerPrefs.GetInt("bestScore");
            user.userName = UnityEngine.PlayerPrefs.GetString("userName");
            user.lastScore = UnityEngine.PlayerPrefs.GetInt("lastScore");
            user.playedGames = UnityEngine.PlayerPrefs.GetInt("playedGames");
            return user;
        }
    }
}