using AdventureGame.Player;
using System;
using System.Data.SQLite;
using System.IO;

namespace AdventureGame.SqliteStuff
{
    public static class SqliteHelper
    {
        private static string cs = $@"URI=file:C:\Users\Shain\source\repos\AdventureGame\AdventureGame\AdventureGameDB.db";
        private static SQLiteConnection con;

        public static Adventurer GetPlayerByName(string name)
        {
            Adventurer player;
            using (con = new SQLiteConnection(cs))
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
                            player = new Adventurer()
                            {
                                Name = rdr["Name"].ToString(),
                                HP = Convert.ToInt32(rdr["HP"]),
                                CurrentQuest = rdr["Quest"].ToString(),
                                Weapon = rdr["Weapon"].ToString()
                                
                            };
                            
                        }
                        else
                        {
                            player = new Adventurer()
                            {
                                Name = name,
                                HP = 100,
                                CurrentQuest = "Start"
                            };
                            Add_New_Player(player);
                            
                        }

                        con.Close();
                        return player;
                    }
                }
            }
        }

        public static void Set_Class(string playerclass, Adventurer adv)
        {
            
            switch (playerclass)
            {
                case "Archer":
                    adv.HP = 100;
                    adv.Class = playerclass;
                    break;
                case "Sorcerer":
                    adv.HP = 150;
                    adv.Class = playerclass;
                    break;
                case "Knight":
                    adv.HP = 250;
                    adv.Class = playerclass;
                    break;
                default:
                    Console.WriteLine("Try Again...");
                    break;
            }
        }

        public static void Update_Player(Adventurer adv)
        {
            using (con = new SQLiteConnection(cs))
            {
                con.Open();
                string query = "UPDATE Player SET Class = @class,HP = @hp, Quest = @quest  WHERE Name = @name";

                using(SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@class", adv.Class);
                    cmd.Parameters.AddWithValue("@hp", adv.HP);
                    cmd.Parameters.AddWithValue("@quest", adv.CurrentQuest);
                    cmd.Parameters.AddWithValue("@name", adv.Name);

                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        private static void Add_New_Player(Adventurer adv)
        {
            using (con = new SQLiteConnection(cs))
            {
                con.Open();
                string query = "INSERT INTO Player (Name,HP,Quest) VALUES (@name,@hp,@quest)";
                using(var cmd = new SQLiteCommand(query, con))
                {
                    
                    cmd.Parameters.AddWithValue("@name", adv.Name);
                    cmd.Parameters.AddWithValue("@hp", adv.HP);
                    cmd.Parameters.AddWithValue("@quest", adv.CurrentQuest);

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }



        public static void Count_Players()
        {
            using (con)
            {
                con.Open();
                string query = "Select * FROM Player";
                using(var cmd = new SQLiteCommand(query, con))
                {
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Name"]);
                    }
                }
            }
        }
    }
}