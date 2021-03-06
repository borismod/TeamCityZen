﻿namespace TeamCitySharp.Connection
{
    using System;
    using EasyHttp.Http;

    internal interface ITeamCityCaller
    {
        void Connect(string userName, string password, bool actAsGuest);

        T GetFormat<T>(string urlPart, params object[] parts);

        void GetFormat(string urlPart, params object[] parts);

        T PostFormat<T>(object data, string contenttype, string accept, string urlPart, params object[] parts);

        void PostFormat(object data, string contenttype, string urlPart, params object[] parts);

        void PutFormat(object data, string contenttype, string urlPart, params object[] parts);

        void DeleteFormat(string urlPart, params object[] parts);

        void GetDownloadFormat(Action<string> downloadHandler, string urlPart, params object[] parts);

        string StartBackup(string urlPart);

        T Get<T>(string urlPart);

        void Get(string urlPart);

        T Post<T>(string data, string contenttype, string urlPart, string accept);

        bool Authenticate(string urlPart);

        HttpResponse Post(object data, string contenttype, string urlPart, string accept);

        HttpResponse Put(object data, string contenttype, string urlPart, string accept);

        void Delete(string urlPart);

        string GetRaw(string urlPart);
        T GetByFullUrl<T>(string fullUrl);
    }
}