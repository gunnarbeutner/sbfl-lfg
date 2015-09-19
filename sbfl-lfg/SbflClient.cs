using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Json;
using Microsoft.CSharp.RuntimeBinder;
using System.Runtime.CompilerServices;
using Dynamitey;
using System.Globalization;

namespace sbfl_lfg {
    public struct LobbyInfo {
        public string Name;
        public Dictionary<string, PlayerInfo> Players;
    }

    public struct PlayerInfo {
        public string Name;
        public double Idle;
        public DateTime? From;
        public DateTime? To;
    }

    class SbflClient {
        public static String LfgUrl = "https://sbfl.eu/bot/lfg.php";
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private WebClient _Client;
        private object _SyncObject = new object();
   
        public SbflClient(ICredentials creds) {
            _Client = new WebClient();
            _Client.Credentials = creds;
        }

        public Json.JsonArray GetGames() {
            string response;
            lock (_SyncObject) {
                response = _Client.DownloadString(LfgUrl + "?action=games");
            }
            return Json.JsonParser.Deserialize(response);
        }

        public JsonArray GetMyGames() {
            string response;
            lock (_SyncObject) {
                response = _Client.DownloadString(LfgUrl + "?action=my-games");
            }
            return Json.JsonParser.Deserialize(response);
        }

        public Dictionary<string, LobbyInfo> GetLobbies() {
            string response;
            lock (_SyncObject) {
                response = _Client.DownloadString(LfgUrl + "?action=lobbies");
            }

            Dictionary<string, LobbyInfo> result = new Dictionary<string, LobbyInfo>();

            foreach (JsonObject lobby in JsonParser.Deserialize(response)) {
                LobbyInfo li;
                li.Name = Dynamic.InvokeGet(lobby, "name");
                li.Players = new Dictionary<string, PlayerInfo>();
                foreach (Dictionary<string, object> player in Dynamic.InvokeGet(lobby, "players")) {
                    PlayerInfo pi;
                    pi.Name = (string)player["name"];
                    pi.Idle = (double)player["idle"];
                    pi.From = UnixEpoch.AddSeconds((double)player["from"]);

                    double to = (double)player["to"];
                    if (to == 0)
                        pi.To = null;
                    else
                        pi.To = UnixEpoch.AddSeconds(to);

                    li.Players.Add(pi.Name, pi);
                }
                result.Add(li.Name, li);
            }

            return result;
        }

        public void JoinLobby(string game, DateTime? from, DateTime? to) {
            string url = LfgUrl + "?action=join-lobby&name=" + Uri.EscapeDataString(game);

            if (from.HasValue)
                url += "&from=" + from.Value.ToUniversalTime().Subtract(UnixEpoch).TotalSeconds.ToString(CultureInfo.InvariantCulture);

            if (to.HasValue)
                url += "&to=" + to.Value.ToUniversalTime().Subtract(UnixEpoch).TotalSeconds.ToString(CultureInfo.InvariantCulture);

            lock (_SyncObject) {
                _Client.DownloadString(url);
            }
        }

        public void LeaveLobby(string game) {
            lock (_SyncObject) {
                _Client.DownloadString(LfgUrl + "?action=leave-lobby&name=" + Uri.EscapeDataString(game));
            }
        }

        public void SetIdleTime(int idle) {
            lock (_SyncObject) {
                _Client.DownloadString(LfgUrl + "?action=set-idle&idle=" + idle.ToString());
            }
        }
    }
}