﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoothubAPI.Models;

namespace YoothubAPI.Controllers.Songs
{
    public class SongJson
    {
        public Song Song { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public VoteType? CurrentVote { get; set; }
    }
}
