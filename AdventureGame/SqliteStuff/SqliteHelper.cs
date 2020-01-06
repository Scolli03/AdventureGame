using AdventureGame.Player;
using System;
using System.Data.SQLite;

namespace AdventureGame.SqliteStuff
{
    public static class SqliteHelper
    {
        private static string cs = @"URI=file:C:\Users\Shain\Source\Repos\AdventureGame\AdventureGame\AdventureGameDB.db";
        private static SQLiteConnection con = new SQLiteConnection(cs);

        public static Adventurer GetPlayerByName(string name)
        {
            using (con)
            {
                con.Open();
                string stm = "SELECT * FROM Player WHERE Name = @name";

                using (var cmd = new SQLiteCommand(stm, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            Adventurer player = new Adventurer()
                            {
                                Name = rdr["Name"].ToString(),
                                HP = Convert.ToInt32(rdr["HP"]),
                                CurrentQuest = rdr["Quest"].ToString()
                            };

                            return player;
                        }
                        else
                        {
                            Adventurer player = new Adventurer()
                            {
                                Name = name,
                                HP = 100,
                                CurrentQuest = "Start"
                            };
                            Add_New_Player(player);
                            return player;
                        }
                    }
                }
            }
        }

        private static void Add_New_Player(Adventurer adv)
        {
            using (con)
            {
                //con.Open();
                string query = "INSERT INTO Player (Name,HP,Quest) VALUES (@name,@hp,@quest)";
                using(var cmd = new SQLiteCommand(query, con))
                {
                    
                    cmd.Parameters.AddWithValue("@name", adv.Name);
                    cmd.Parameters.AddWithValue("@hp", adv.HP);
                    cmd.Parameters.AddWithValue("@quest", adv.CurrentQuest);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}