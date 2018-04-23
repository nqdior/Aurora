﻿using System;

namespace Aurora.Data
{
    public enum Engine
    {
        SqlServer = 0,
        MySql = 1,
        PostgreSql = 2,
        MariaDB = 3,
        SQLite = 4,
        Oracle = 5
    }

    public static partial class EngineExtend
    {
        public static int ToIndex(this Engine engine) => (int)engine;

        public static Engine ToEngine(this int index) => (Engine)Enum.ToObject(typeof(Engine), index);
    }
}