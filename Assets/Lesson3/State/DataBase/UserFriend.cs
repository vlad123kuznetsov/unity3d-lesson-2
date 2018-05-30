using System;
using System.Collections.Generic;
using System.Linq;
using SQLite4Unity3d;
using UnityEngine;

namespace Lesson3.State.DataBase
{
    [Table("user_friends")]
    public class UserFriend
    {
        [PrimaryKey, Column("_id")]
        public string userSnId { get; set; }
	
        [MaxLength(30)]
        public string userName { get; set; }
	
        public string userEmail { get; set; }
	
        public bool receivedGift { get; set; }
    }

    public class DataBaseManager : IDisposable
    {
        private SQLiteConnection _connection;

        public DataBaseManager()
        {
            Connect();
        }
        
        private void Connect()
        {
            _connection = new SQLiteConnection("Assets/StreamingAssets/tempDataBase.db", SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            if (!UnityEngine.PlayerPrefs.HasKey("user_friends"))
            {
                _connection.CreateTable<UserFriend>();
            }
        }

        public void AddFriend(UserFriend friend)
        {
            _connection.Insert(friend);
        }

        public List<UserFriend> GetFriends()
        {
            return _connection.Table<UserFriend>().ToList();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }    
}