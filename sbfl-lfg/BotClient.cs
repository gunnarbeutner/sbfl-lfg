using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Json;
using Microsoft.CSharp.RuntimeBinder;
using System.Runtime.CompilerServices;

namespace sbfl_lfg {
    class BotClient {
        public static String LfgUrl = "https://sbfl.eu/bot/lfg.php";
        private WebClient _Client;
   
        public BotClient(ICredentials creds) {
            _Client = new WebClient();
            _Client.Credentials = creds;
        }

        public Json.JsonArray GetGames() {
            string response = _Client.DownloadString(LfgUrl + "?action=games");
            return Json.JsonParser.Deserialize(response);
        }

        public JsonArray GetMyGames() {
            string response = _Client.DownloadString(LfgUrl + "?action=my-games");
            return Json.JsonParser.Deserialize(response);
        }

        public JsonArray GetMyLobbies() {
            string response = _Client.DownloadString(LfgUrl + "?action=my-lobbies");
            return Json.JsonParser.Deserialize(response);
        }

        public void JoinLobby(string game) {
            _Client.DownloadString(LfgUrl + "?action=join-lobby&name=" + Uri.EscapeDataString(game));
        }

        public void LeaveLobby(string game) {
            _Client.DownloadString(LfgUrl + "?action=leave-lobby&name=" + Uri.EscapeDataString(game));
        }
    }
}