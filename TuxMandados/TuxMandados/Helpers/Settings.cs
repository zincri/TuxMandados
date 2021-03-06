﻿namespace TuxMandados.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;
    using System;

    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants
        private const string token = "Token";
        private const string tokenType = "TokenType";
        private const string _IDUsuario = "IDUsuario";
        private const string _IDCOR = "IDCOR";
        private static readonly string SettingsDefault = string.Empty;
        #endregion

        public static string Token
        {
            get
            {
                return AppSettings.GetValueOrDefault(token, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(token, value);
            }
        }
        public static string TokenType
        {
            get
            {
                return AppSettings.GetValueOrDefault(tokenType, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(tokenType, value);
            }
        }
        public static string IDUsuario
        {
            get
            {
                return AppSettings.GetValueOrDefault(_IDUsuario, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(_IDUsuario, value);
            }
        }

        public static string IDCOR
        {
            get
            {
                return AppSettings.GetValueOrDefault(_IDCOR, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(_IDCOR, value);
            }
        }


    }
}
