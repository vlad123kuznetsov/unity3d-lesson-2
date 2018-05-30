using System.IO;
using UnityEngine;

namespace Lesson3.State.File
{
    public class FileStateManager : IApplicationStateManager
    {
        private string GetFilePath()
        {
            return Path.Combine(Application.persistentDataPath, "user.txt");
        }
	
        public void SaveState(UserState user)
        {
            var json = JsonUtility.ToJson(user);
            System.IO.File.WriteAllText(GetFilePath(), json);
        }

        public UserState GetState()
        {
            var json = System.IO.File.ReadAllText(GetFilePath());
            return JsonUtility.FromJson<UserState>(json);
        }
    }
}