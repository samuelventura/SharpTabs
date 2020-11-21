using System;
using System.IO;
using System.Collections.Generic;
using LiteDB;

namespace SharpTabs
{
    public class SessionDao
    {
        public static string DefaultPath(string name)
        {
            var folder = TabsTools.DefaultFolder(name);
            return Path.Combine(folder, "sessions.db");
        }

        public static string NewName()
        {
            var now = DateTime.Now;
            var id = now.ToString("HHmmss.fff");
            return $"Session {id}";
        }

        public static void Exec(string path, Action<LiteDatabase> callback)
        {
            using (var db = new LiteDatabase(path))
            {
                callback(db);
            }
        }

        public static T[] Load<T>(string path) where T : SessionDto
        {
            using (var db = new LiteDatabase(path))
            {
                var table = db.GetCollection<T>("sessions");
                var list = new List<T>(table.FindAll());
                foreach(var dto in list)
                {
                    dto.Id = 0;
                }
                return list.ToArray();
            }
        }

        public static void Save(string path, SessionDto[] dtos)
        {
            var index = 0;
            foreach (var dto in dtos)
            {
                dto.Id = ++index;
            }
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

        public static void Retype(string path, ushort version, Type type)
        {
            Exec(path, (db) =>
            {
                if (TabsTools.IsDebug())
                {
                    //force migration
                    //db.Engine.UserVersion = 0;
                }
                //migration
                if (db.Engine.UserVersion < version)
                {
                    var typeName = type.FullName;
                    var assyName = type.Assembly.FullName;
                    db.Engine.Run($"db.sessions.update _type='{typeName}, {assyName}'");
                    db.Engine.UserVersion = version;
                }
            });
        }
    }
}
