using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using LiteDB;

namespace SharpTabs
{
    public class SessionDao
    {
        public static T[] Load<T>(string path)
        {
            using (var db = new LiteDatabase(path))
            {
                var table = db.GetCollection<T>("sessions");
                var list = new List<T>(table.FindAll());
                return list.ToArray();
            }
        }

        public static void Save(string path, object[] dtos)
        {
            BsonMapper.Global.EmptyStringToNull = false;
            using (var db = new LiteDatabase(path))
            {
                //prevent insert errors from corrupting db
                db.DropCollection("temp");
                var table = db.GetCollection<object>("temp");
                table.InsertBulk(dtos);
                db.DropCollection("sessions");
                db.RenameCollection("temp", "sessions");
            }
        }

        public static string DefaultPath(string name)
        {
#if DEBUG
            var entry = Assembly.GetEntryAssembly().Location;
            var folder = Path.GetDirectoryName(entry);
            return Path.Combine(folder, "sessions.db");
#else
            var root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var folder = Path.Combine(root, name);
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, "sessions.db");
#endif
        }
    }
}
