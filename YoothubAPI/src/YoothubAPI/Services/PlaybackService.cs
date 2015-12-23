﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoothubAPI.Models;

namespace YoothubAPI.Services
{
    public class PlaybackService : IPlaybackService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Song _currentSong;
        public Queue<Song> _wishQueue = new Queue<Song>();

        public Song GetCurrentSong()
        {
            var songs = db.Songs.OrderBy(s => s.LastPlayed);

            if(_currentSong == null || _currentSong.LastPlayed.Add(_currentSong.Duration) > DateTime.Now)
            {
                _currentSong = _wishQueue.Any() ? _wishQueue.Dequeue() : songs.First();
                _currentSong.LastPlayed = DateTime.Now;
                db.Entry(_currentSong).Property(s => s.LastPlayed).IsModified = true;
                db.SaveChanges();
            } 

            return _currentSong;
        }

        public void Wish(Song s)
        {
            _wishQueue.Enqueue(s);
        }
    }
}
