 /*
 * Copyright 2012 - Adam Haile
 * http://adamhaile.net
 *
 * This file is part of PandoraSharp.
 * PandoraSharp is free software: you can redistribute it and/or modify 
 * it under the terms of the GNU General Public License as published by 
 * the Free Software Foundation, either version 3 of the License, or 
 * (at your option) any later version.
 * 
 * PandoraSharp is distributed in the hope that it will be useful, 
 * but WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License 
 * along with PandoraSharp. If not, see http://www.gnu.org/licenses/.
*/

using System.Collections.Generic;

namespace PandoraSharp
{
    public enum SongRating
    {
        ban = 0,
        love = 1,
        none = 2
    }

    public static class PAudioFormat
    {
        //AAC+, 64Kbps
        public static readonly string AACPlus = "aacplus";
        //MP3, VBR 128Kbps
        public static readonly string MP3 = "mp3";
        //MP3, CBR 192Kbps - Pandora One users only.
        //Will default back to MP3 if selected without a One account. (enforced on server)
        public static readonly string MP3_HIFI = "mp3-hifi";
    }

    internal class Const
    {
        public static readonly string RPC_URL = @"tuner.pandora.com/services/json/";
        public static readonly int HTTP_TIMEOUT = 30;
        public static readonly string AUDIO_FORMAT = PAudioFormat.AACPlus;

        public static readonly int PLAYLIST_VALIDITY_TIME = (int)(60*60*0.5);


        public static readonly string CRYPT_IN_KEY = @"R=U!LH$O2B#";
        public static readonly string CRYPT_OUT_KEY = @"6#26FRL$ZWD";
    }

    public class PDict : Dictionary<string, object>
    {
    }
}