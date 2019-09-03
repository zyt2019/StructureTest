using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetTest
{
    /// <summary>
    /// 音乐播放列表类
    /// </summary>
    public class PlaylistSet
    {
        HashSet<Song> _songs;
        public int capacity { get; private set; }
        public bool premiumUser { get; private set; }//高价的优质的用户
        public bool isEmpty
        {
            get
            {
                return _songs.Count == 0;
            }
        }
        public bool isFull
        {
            get
            {
                if (this.premiumUser)
                {
                    return false;
                }
                else
                {
                    return _songs.Count == this.capacity;
                }
            }
        }
        public PlaylistSet(bool premiumUser,int capacity)
        {
            _songs = new HashSet<Song>();
            this.premiumUser = premiumUser;
            this.capacity = capacity;
        }
        /// <summary>
        /// 增加歌曲
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public bool AddSong(Song song)
        {
            if (!this.isFull)
            {
                return _songs.Add(song);
            }
            return false;
        }
        /// <summary>
        /// 移除歌曲
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public bool RemoveSong(Song song)
        {
            return _songs.Remove(song);
        }
        /// <summary>
        /// 合并歌曲列表 取并集
        /// </summary>
        /// <param name="playlist"></param>
        public void MergeWithPlayList(HashSet<Song> playlist)
        {
            _songs.UnionWith(playlist);
        }
        /// <summary>
        /// 为playList类提供了交集功能
        /// </summary>
        /// <param name="playlist"></param>
        /// <returns></returns>
        public HashSet<Song> FindSharedSongsInPlayList(HashSet<Song> playlist)
        {
            HashSet<Song> songCopy = new HashSet<Song>(_songs);//复制当前的集合列表
            songCopy.IntersectWith(playlist);
            return songCopy;
        }
        /// <summary>
        /// 为PlayList类提供了对称差的功能
        /// </summary>
        /// <param name="playlist"></param>
        /// <returns></returns>
        public HashSet<Song> FindUniqueSongs(HashSet<Song> playlist)
        {
            HashSet<Song> songCopy = new HashSet<Song>(_songs);
            songCopy.ExceptWith(playlist);
            return songCopy;
        }
        /// <summary>
        /// 判断当前对象是否是某集合的子集
        /// </summary>
        /// <param name="playlist"></param>
        /// <returns></returns>
        public bool IsSubSet(HashSet<Song> playlist)
        {
            return _songs.IsSubsetOf(playlist);
        }
        /// <summary>
        /// 判断当前对象是否是某集合的超集
        /// </summary>
        /// <param name="playlist"></param>
        /// <returns></returns>
        public bool isSuperset(HashSet<Song> playlist)
        {
            return _songs.IsSupersetOf(playlist);
        }
        /// <summary>
        /// 获取当前集合的总数
        /// </summary>
        /// <returns></returns>
        public int TotalSongs()
        {
            return _songs.Count;
        }
    }

    public class Song
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
    }
}
