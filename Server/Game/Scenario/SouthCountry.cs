using System;
using System.Collections.Generic;
using CommonClass;
using CommonClass.Game;
using CommonClassLibrary;
using SanguoshaServer.AI;
using SanguoshaServer.Game;
using static SanguoshaServer.Game.Skill;

namespace SanguoshaServer.Scenario
{
    public class SouthCountry : GameScenario
    {
        public SouthCountry()
        {
            mode_name = "SouthCountry";
            rule = new SouthCountryRule();
        }
        public override void Assign(Room room)
        {
            System.Threading.Thread.Sleep(1000);

            for (int i = 0; i < room.Players.Count; i++)
            {
                Player player = room.Players[i];

                player.PlayerGender = Player.Gender.Male;
                switch (i)
                {
                    case 0:
                        player.General1 = player.ActualGeneral1 = "zhangfei_jx";
                        player.Kingdom = "shu";

                        player.MaxHp = 4;
                        player.Hp = player.MaxHp;
                        break;
                    case 1:
                        player.General1 = player.ActualGeneral1 = "zhouyu";
                        player.Kingdom = "wu";

                        player.MaxHp = 4;
                        player.Hp = player.MaxHp;
                        break;
                    case 2:
                        player.General1 = player.ActualGeneral1 = "chengpu";
                        player.Kingdom = "wu";

                        player.MaxHp = 4;
                        player.Hp = player.MaxHp;
                        break;
                    case 3:
                        player.General1 = player.ActualGeneral1 = "guanyu_jx";
                        player.Kingdom = "shu";

                        player.MaxHp = 4;
                        player.Hp = player.MaxHp;
                        break;
                    case 4:
                        player.General1 = player.ActualGeneral1 = "wall";
                        player.Kingdom = "wei";

                        player.MaxHp = 4;
                        player.Hp = player.MaxHp;
                        break;
                    case 5:
                        player.General1 = player.ActualGeneral1 = "sujiang";
                        player.General2 = player.ActualGeneral2 = "sujiangf";
                        player.Kingdom = "wei";

                        player.MaxHp = 3;
                        player.Hp = player.MaxHp;
                        break;
                    case 6:
                        player.General1 = player.ActualGeneral1 = "caoren";
                        player.General2 = player.ActualGeneral2 = "niujin";
                        player.Kingdom = "wei";

                        player.MaxHp = 10;
                        player.Hp = player.MaxHp;
                        break;
                    case 7:
                        player.General1 = player.ActualGeneral1 = "sujiangf";
                        player.General2 = player.ActualGeneral2 = "sujiang";
                        player.PlayerGender = Player.Gender.Female;
                        player.Kingdom = "wei";

                        player.MaxHp = 3;
                        player.Hp = player.MaxHp;
                        break;
                    case 8:
                        player.General1 = player.ActualGeneral1 = "wall";
                        player.Kingdom = "wei";

                        player.MaxHp = 4;
                        player.Hp = player.MaxHp;
                        break;
                }
                player.General1Showed = true;
                room.BroadcastProperty(player, "General1");
                room.BroadcastProperty(player, "PlayerGender");
                room.NotifyProperty(room.GetClient(player), player, "ActualGeneral1");
                room.BroadcastProperty(player, "Kingdom");
                room.BroadcastProperty(player, "General1Showed");
                foreach (string skill in Engine.GetGeneralSkills(player.General1, Name, true))
                {
                    room.AddPlayerSkill(player, skill);
                    Skill s = Engine.GetSkill(skill);
                    if (s != null && s.SkillFrequency == Frequency.Limited && !string.IsNullOrEmpty(s.LimitMark))
                        room.SetPlayerMark(player, s.LimitMark, 1);
                }
                if (i == 6)
                {
                    foreach (string skill in Engine.GetGeneralSkills(player.General2, Name, true))
                    {
                        room.AddPlayerSkill(player, skill);
                        Skill s = Engine.GetSkill(skill);
                        if (s != null && s.SkillFrequency == Frequency.Limited && !string.IsNullOrEmpty(s.LimitMark))
                            room.SetPlayerMark(player, s.LimitMark, 1);
                    }
                    room.HandleUsedGeneral(player.General2);

                    room.BroadcastProperty(player, "General2");
                    room.NotifyProperty(room.GetClient(player), player, "ActualGeneral2");
                    room.BroadcastProperty(player, "General2Showed");
                }

                room.SendPlayerSkillsToOthers(player, true);

                //技能预亮
                player.SetSkillsPreshowed("hd");
                room.NotifyPlayerPreshow(player);
                room.HandleUsedGeneral(player.General1);

                room.BroadcastProperty(player, "MaxHp");
                room.BroadcastProperty(player, "Hp");
            }

            System.Threading.Thread.Sleep(1000);

            //为其余玩家分配武将
            List<string> shu_generals = new List<string> { "guanping", "huangyueying", "hujinding", "jianyong", "liufeng", "maliang", "sunqian", "xiahoushi", "yiji_shu", "zhoucang",
                "wolong", "pangtong", "bigfool", "zhaoyun_jx", "mizhu", "masu", "chenzhen" };
            List<string> wu_generals = new List<string> { "daqiao", "xiaoqiao", "erzhang", "ganning", "handang", "huanggai_jx", "jiangqin_sp", "kanze", "lingtong", "luotong", "lusu",
                "lvdai", "lvfan", "sunshangxiang", "taishici", "zhuzhi", "zhugejin" };
            Shuffle.shuffle(ref shu_generals);
            Shuffle.shuffle(ref wu_generals);

            Dictionary<Player, List<string>> options = new Dictionary<Player, List<string>>();
            foreach (Player player in room.Players)
            {
                List<string> choices = new List<string>();
                if (player.Kingdom == "shu")
                {
                    choices.Add(shu_generals[0]);
                    shu_generals.RemoveAt(0);
                    choices.Add(shu_generals[0]);
                    shu_generals.RemoveAt(0);
                    choices.Add(shu_generals[0]);
                    shu_generals.RemoveAt(0);
                }
                else if (player.Kingdom == "wu")
                {
                    choices.Add(wu_generals[0]);
                    wu_generals.RemoveAt(0);
                    choices.Add(wu_generals[0]);
                    wu_generals.RemoveAt(0);
                    choices.Add(wu_generals[0]);
                    wu_generals.RemoveAt(0);
                    choices.Add(wu_generals[0]);
                    wu_generals.RemoveAt(0);
                }
                else
                    continue;

                options.Add(player, choices);
            }

            //玩家选将
            List<Interactivity> receivers = new List<Interactivity>();
            List<Player> players = new List<Player>();
            foreach (Player player in options.Keys)
            {
                player.SetTag("generals", JsonUntity.Object2Json(options[player]));
                List<string> args = new List<string>
                {
                    player.Name,
                    string.Empty,
                    JsonUntity.Object2Json(options[player]),
                    true.ToString(),
                    true.ToString(),
                    false.ToString()
                };
                Interactivity client = room.GetInteractivity(player);
                if (client != null && !receivers.Contains(client))
                {
                    client.CommandArgs = args;
                    receivers.Add(client);
                }
                players.Add(player);
            }

            Countdown countdown = new Countdown
            {
                Max = room.Setting.GetCommandTimeout(CommandType.S_COMMAND_CHOOSE_GENERAL, ProcessInstanceType.S_CLIENT_INSTANCE),
                Type = Countdown.CountdownType.S_COUNTDOWN_USE_SPECIFIED
            };
            room.NotifyMoveFocus(players, countdown);
            room.DoBroadcastRequest(receivers, CommandType.S_COMMAND_CHOOSE_GENERAL);
            room.DoBroadcastNotify(CommandType.S_COMMAND_UNKNOWN, new List<string> { false.ToString() });

            //给AI和超时的玩家自动选择武将
            foreach (Player player in options.Keys)
            {
                player.RemoveTag("generals");
                if (string.IsNullOrEmpty(player.General2))
                {
                    string generalName = string.Empty;
                    List<string> reply = room.GetInteractivity(player)?.ClientReply;
                    bool success = true;
                    if (reply == null || reply.Count == 0 || string.IsNullOrEmpty(reply[0]))
                        success = false;
                    else
                        generalName = reply[0];

                    if (!success || (!options[player].Contains(generalName) && room.GetClient(player).UserRight < 3)
                        || (player.Kingdom == "shu" && Engine.GetGeneral(generalName, room.Setting.GameMode).Kingdom[0] != General.KingdomENUM.Shu)
                        || (player.Kingdom == "wu" && Engine.GetGeneral(generalName, room.Setting.GameMode).Kingdom[0] != General.KingdomENUM.Wu))
                    {
                        generalName = options[player][0];
                    }
                    player.General2 = player.ActualGeneral2 = generalName;
                    player.General2Showed = true;
                }

                room.BroadcastProperty(player, "General2");
                room.NotifyProperty(room.GetClient(player), player, "ActualGeneral2");
                room.BroadcastProperty(player, "General2Showed");

                player.SetSkillsPreshowed("hd");
                room.NotifyPlayerPreshow(player);
                List<string> names = new List<string> { player.General1, player.General2 };
                room.SetTag(player.Name, names);
                room.HandleUsedGeneral(player.General2);
            }
        }

        public override TrustedAI GetAI(Room room, Player player)
        {
            return new GuanduAI(room, player);
        }
        public override bool IsFriendWith(Room room, Player player, Player other)
        {
            return player.Camp == other.Camp;
        }
        public override bool WillBeFriendWith(Room room, Player player, Player other, string skill_name = null)
        {
            return IsFriendWith(room, player, other);
        }

        public override void OnChooseGeneralReply(Room room, Interactivity client)
        {
            //该模式下玩家完成选将会立即向所有人公布
            Player player = room.GetPlayers(client.ClientId)[0];
            List<string> options = JsonUntity.Json2List<string>((string)player.GetTag("generals"));
            List<string> reply = client.ClientReply;
            bool success = true;
            string generalName = string.Empty;
            if (reply == null || reply.Count == 0 || string.IsNullOrEmpty(reply[0]))
                success = false;
            else
                generalName = reply[0];

            if (!success || (!options.Contains(generalName) && room.GetClient(player).UserRight < 3)
                        || (player.Kingdom == "shu" && Engine.GetGeneral(generalName, room.Setting.GameMode).Kingdom[0] != General.KingdomENUM.Shu)
                        || (player.Kingdom == "wu" && Engine.GetGeneral(generalName, room.Setting.GameMode).Kingdom[0] != General.KingdomENUM.Wu))
            {
                generalName = options[0];
            }

            player.General2 = generalName;
            player.ActualGeneral2 = generalName;
            player.General2Showed = true;
            room.BroadcastProperty(player, "General2");
        }

        public override void PrepareForPlayers(Room room)
        {
            foreach (Player player in room.Players)
            {
                string general2_name = player.ActualGeneral2;
                foreach (string skill in Engine.GetGeneralSkills(general2_name, Name, true))
                {
                    Skill s = Engine.GetSkill(skill);
                    if (s != null && !s.LordSkill)
                    {
                        room.AddPlayerSkill(player, skill);
                        if (s.SkillFrequency == Frequency.Limited && !string.IsNullOrEmpty(s.LimitMark))
                            room.SetPlayerMark(player, s.LimitMark, 1);
                    }
                }
                room.SendPlayerSkillsToOthers(player, true);

                //技能预亮
                player.SetSkillsPreshowed("hd");
                room.NotifyPlayerPreshow(player);
            }
        }

        public override void PrepareForStart(Room room, ref List<Player> room_players, ref List<int> game_cards, ref List<int> m_drawPile)
        {
            //生成卡牌
            game_cards = Engine.GetGameCards(room.Setting.CardPackage);
            m_drawPile = game_cards;
            Shuffle.shuffle(ref m_drawPile);

            //首先添加5位AI，不需要用到client
            for (int i = 4; i < 9; i++)
                room_players.Add(new Player { Name = string.Format("SGS{0}", i + 1), Seat = i + 1 });


            List<Client> clients = new List<Client>(room.Clients);
            Shuffle.shuffle(ref clients);
            int player_index = 0;
            int computer_index = 1;

            for (int i = 0; i < room_players.Count; i++)
            {
                Player player = room_players[i];
                player.Camp = i < 4 ? Game3v3Camp.S_CAMP_COOL : Game3v3Camp.S_CAMP_WARM;
                if (player.Camp == Game3v3Camp.S_CAMP_COOL)
                {
                    Client client = clients[player_index];
                    player_index++;
                    if (client.UserId > 0)
                        client.Status = Client.GameStatus.online;
                    player.SceenName = client.Profile.NickName;
                    player.Status = client.Status.ToString();
                    player.ClientId = client.UserId;

                    General general = Engine.GetGeneral(player.ActualGeneral2, room.Setting.GameMode);
                    int max_offset = general.DoubleMaxHp + general.Head_max_hp_adjusted_value;
                    if (max_offset > 0)
                    {
                        player.MaxHp += max_offset;
                        room.BroadcastProperty(player, "MaxHp");
                    }
                }
                else
                {
                    player.SceenName = string.Format("computer{0}", computer_index);
                    computer_index++;
                    player.Status = "bot";
                    player.ClientId = 0;
                }

                if (i == 8)
                    player.Next = room_players[0].Name;
                else
                    player.Next = room_players[i + 1].Name;

                if (i < 4)
                {
                    player.Role = "rebel";
                    player.Kingdom = i == 0 || i == 3 ? "shu" : "wu";
                }
                else if (i == 6)
                {
                    player.Role = "lord";
                    player.Kingdom = "wei";
                }
                else
                {
                    player.Role = "loyalist";
                    player.Kingdom = "wei";
                }

                //room.BroadcastProperty(player, "Camp");
                room.BroadcastProperty(player, "Role");
                room.BroadcastProperty(player, "Kingdom");
            }
        }


        public override string GetPreWinner(Room room, Client client)
        {
            Player surrender = room.GetPlayers(client.UserId)[0];
            List<string> winners = new List<string>();
            Game3v3Camp dead_camp = surrender.Camp;
            foreach (Player p in room.Players)
            {
                if (p.Camp != dead_camp)
                    winners.Add(p.Name);
            }

            return string.Join("+", winners);
        }

        public override List<Interactivity> CheckSurrendAvailable(Room room)
        {
            List<Interactivity> clients = new List<Interactivity>();
            int cool = 0;
            Interactivity cool_lord = null;
            foreach (Player p in room.GetAlivePlayers())
            {
                if (p.Camp == Game3v3Camp.S_CAMP_COOL && p.ClientId > 0)
                {
                    cool_lord = room.GetInteractivity(p.ClientId);
                    cool++;
                }
            }
            
            if (cool == 1 && cool_lord != null)
                clients.Add(cool_lord);

            return clients;
        }
    }

    public class SouthCountryRule : GameRule
    {
        public SouthCountryRule() : base("southcountry_rule")
        {
        }
        protected override void OnGameStart(Room room, ref object data)
        {
            foreach (Player player in room.Players)
            {
                foreach (string skill_name in player.GetSkills())
                {
                    Skill skill = Engine.GetSkill(skill_name);
                    if (skill.SkillFrequency == Frequency.Limited && !string.IsNullOrEmpty(skill.LimitMark))
                        room.SetPlayerMark(player, skill.LimitMark, 1);
                }
            }
            foreach (Player p in room.Players)
                if (p.General1 != "wall") room.DrawCards(p, 4, "gamerule");

            room.AskForLuckCard(2);

            //游戏开始动画
            room.DoBroadcastNotify(CommandType.S_COMMAND_GAME_START, new List<string>());
            System.Threading.Thread.Sleep(2000);
        }

        //胜利条件
        public override string GetWinner(Room room)
        {
            if (!string.IsNullOrEmpty(room.PreWinner)) return room.PreWinner;

            List<string> winners = new List<string>();
            List<Player> players = room.GetAlivePlayers();
            Game3v3Camp dead_camp = Game3v3Camp.S_CAMP_NONE;
            foreach (Player p in room.Players)
            {
                if (p.GetRoleEnum() == Player.PlayerRole.Lord && !p.Alive)
                {
                    dead_camp = p.Camp;
                    break;
                }
            }

            if (dead_camp == Game3v3Camp.S_CAMP_WARM)
            {
                foreach (Player p in room.Players)
                    if (p.Camp == Game3v3Camp.S_CAMP_COOL)
                        winners.Add(p.Name);
            }
            else if (dead_camp == Game3v3Camp.S_CAMP_COOL)
            {
                foreach (Player p in room.Players)
                    if (p.Camp == Game3v3Camp.S_CAMP_WARM)
                        winners.Add(p.Name);
            }

            return string.Join("+", winners);
        }

        public override void CheckBigKingdoms(Room room)
        {
        }
        protected override void OnBuryVictim(Room room, Player player, ref object data)
        {
            DeathStruct death = (DeathStruct)data;
            Player killer = death.Damage.From;
            room.BuryPlayer(player);

            if (room.ContainsTag("SkipNormalDeathProcess") && (bool)room.GetTag("SkipNormalDeathProcess"))
                return;

            if (killer != null)
            {
                killer.SetMark("multi_kill_count", killer.GetMark("multi_kill_count") + 1);
                int kill_count = killer.GetMark("multi_kill_count");
                if (kill_count > 1 && kill_count < 8)
                    room.SetEmotion(killer, string.Format("kill{0}", kill_count));
                else if (kill_count > 7)
                    room.SetEmotion(killer, "zylove");

                RewardAndPunish(room, killer, player);
            }
        }
        protected override void OnDeath(Room room, Player player, ref object data)
        {
        }

        protected override void RewardAndPunish(Room room, Player killer, Player victim)
        {
            //杀死同阵营惩罚
            object data = victim;
            if (!room.RoomThread.Trigger(TriggerEvent.RewardPunish, room, killer, ref data))
            {
                if (killer.Alive && victim.Camp == Game3v3Camp.S_CAMP_COOL && victim.Camp == killer.Camp)
                    room.ThrowAllHandCardsAndEquips(killer);
            }
        }
    }
}
