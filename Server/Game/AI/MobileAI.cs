using System;
using System.Collections.Generic;
using CommonClass;
using CommonClass.Game;
using SanguoshaServer.Game;
using SanguoshaServer.Package;
using static CommonClass.Game.Player;
using static SanguoshaServer.Package.FunctionCard;

namespace SanguoshaServer.AI
{
    public class MobileAI : AIPackage
    {
        public MobileAI() : base("Mobile")
        {
            events = new List<SkillEvent>
            {
                new YingjianAI(),

                new DaigongAI(),
                new ZhaoxinAI(),
                //new ZhongzuoAI(),
                new TongquAI(),
                new WanlanAI(),
                new QiaiMobileAI(),
                new ShanxiWCAI(),
                new WanweiClassicAI(),
                new YuejianClassicAI(),

                new KuangcaiAI(),
                new YixiangAI(),
                new YirangAI(),
                new RensheAI(),
                new ZhiyiAI(),
                new RangjieAI(),
                new ZhouxuanAI(),
                new ChengzhaoAI(),
                new WeifengAI(),
                new JinfanAI(),
                new ShequeAI(),
                new ZhiyanXHAI(),
                new ZhilueAI(),
                new DuojiAI(),
                new JianzhanAI(),
                new MiewuAI(),

                new WuyuanAI(),
                new ShamengAI(),
                new ShengxiClassicAI(),
                new JianyuAI(),
                new MingxuanAI(),
                new XianchouAI(),
                new QiaoshiJXAI(),
                new YanyuJXAI(),
                new TunchuJxAI(),
                new ShuliangJxAI(),

                new FenyinAI(),
                new FubiAI(),
                new ZuiciAI(),
                new DiancaiClassicAI(),
                new DiaoduClassicAI(),
                new YanjiAI(),
            };

            use_cards = new List<UseCard>
            {
                new WuyuanCardAI(),
                new YizhengCardAI(),
                new ZhiyanCardAI(),
                new ZhilueCardAI(),
                new DuojiCardAI(),
                new JianzhanCardAI(),
                new ShamengCardAI(),
                new QiaiCardAI(),
                new JianyuCardAI(),
            };
        }
    }

    public class YingjianAI : SkillEvent
    {
        public YingjianAI() : base("yingjian") { }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct(null, player, new List<Player>());
            WrappedCard card = new WrappedCard(Slash.ClassName) { Skill = Name, ShowSkill = Name, DistanceLimited = false };
            List<WrappedCard> slashes = new List<WrappedCard> { card };
            List<ScoreStruct> scores = ai.CaculateSlashIncome(player, slashes, null, false);
            if (scores.Count > 0 && scores[0].Score > 0 && scores[0].Players != null && scores[0].Players.Count > 0)
            {
                use.Card = scores[0].Card;
                use.To = scores[0].Players;
            }

            return use;
        }
    }

    public class DaigongAI : SkillEvent
    {
        public DaigongAI() : base("daigong") { }

        public override ScoreStruct GetDamageScore(TrustedAI ai, DamageStruct damage)
        {
            ScoreStruct score = new ScoreStruct();
            score.Score = 0;
            if (damage.From != null && damage.From != damage.To && ai.HasSkill(Name, damage.To) && !damage.To.HasFlag(Name) && !ai.IsFriend(damage.From, damage.To) && !damage.To.IsKongcheng())
            {
                if (ai.IsFriend(damage.To))
                    score.Score += 3;
                else if (ai.IsFriend(damage.From))
                    score.Score -= 3;
            }
            return score;
        }

        public override List<int> OnExchange(TrustedAI ai, Player player, string pattern, int min, int max, string pile)
        {
            Room room = ai.Room;
            if (room.GetTag(Name) is DamageStruct damage)
            {
                ScoreStruct score = ai.GetDamageScore(damage, DamageStruct.DamageStep.Done);
                if (ai.IsEnemy(damage.To))
                {
                    List<int> ids = new List<int>();
                    foreach (int id in player.GetCards("h"))
                    {
                        WrappedCard card = room.GetCard(id);
                        if (Engine.MatchExpPattern(room, pattern, player, card) && (card.Name != Peach.ClassName && card.Name != Analeptic.ClassName || damage.Damage > 1))
                            ids.Add(id);
                    }
                    if (ids.Count > 0)
                    {
                        List<double> values = ai.SortByKeepValue(ref ids, false);
                        if (values[0] < score.Score)
                            return new List<int> { ids[0] };
                        if (player == room.Current)
                        {
                            values = ai.SortByUseValue(ref ids, false);
                            if (values[0] < score.Score)
                                return new List<int> { ids[0] };
                        }
                    }
                }
            }

            return new List<int>();
        }
    }

    public class ZhaoxinAI : SkillEvent
    {
        public ZhaoxinAI() : base("zhaoxin")
        {
        }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (data is string str)
            {
                string[] strs = str.Split(':');
                Player who = ai.Room.FindPlayer(strs[1]);

                DamageStruct damage = new DamageStruct(Name, who, player);
                if (ai.IsFriend(who) || ai.GetDamageScore(damage).Score > 0)
                    return true;
            }
            else if (data is Player target)
            {
                DamageStruct damage = new DamageStruct(Name, player, target);
                if (ai.GetDamageScore(damage).Score > 0)
                    return true;
            }

            return false;
        }
    }
    /*
    public class ZhongzuoAI : SkillEvent
    {
        public ZhongzuoAI() : base("zhongzuo")
        {
            key = new List<string> { "playerChosen:zhongzuo" };
        }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (data is string choice)
            {
                string[] choices = choice.Split(':');
                if (choices[1] == Name)
                {
                    Room room = ai.Room;
                    Player target = room.FindPlayer(choices[2]);

                    if (target != null && ai.GetPlayerTendency(target) != "unknown")
                        ai.UpdatePlayerRelation(player, target, true);
                }
            }
        }

        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            List<Player> players = ai.FriendNoSelf;
            if (players.Count > 0)
            {
                ai.SortByDefense(ref players, false);
                foreach (Player p in players)
                    if (p.IsWounded())
                        return new List<Player> { p };

                players = ai.GetFriends(player);
                Room room = ai.Room;
                room.SortByActionOrder(ref players);
                foreach (Player p in players)
                {
                    if (p == room.Current || !p.FaceUp) continue;
                    return new List<Player> { p };
                }
            }
            return new List<Player> { player };
        }
    }
    */

    public class TongquAI : SkillEvent
    {
        public TongquAI() : base("tongqu")
        {
            key = new List<string> { "playerChosen:tongqu" };
        }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.ChoiceMade && data is string str && player != ai.Self)
            {
                List<string> strs = new List<string>(str.Split(':'));
                if (strs[1] == Name)
                {
                    Room room = ai.Room;
                    Player target = room.FindPlayer(strs[2]);
                    if (player != target && ai.GetPlayerTendency(target) != "unknown")
                        ai.UpdatePlayerRelation(player, target, true);
                }
            }
        }
        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            Room room = ai.Room;
            room.SortByActionOrder(ref targets);
            foreach (Player p in targets)
                if (ai.IsFriend(p) && !ai.WillSkipPlayPhase(p) && !ai.WillSkipPlayPhase(p))
                    return new List<Player> { p };

            foreach (Player p in targets)
                if (ai.IsFriend(p))
                    return new List<Player> { p };

            return new List<Player>();
        }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct(new WrappedCard(TongquCard.ClassName), player, new List<Player>());
            List<Player> targets = new List<Player>();
            Room room = ai.Room;
            List<int> ids = player.GetCards("he");
            ai.SortByKeepValue(ref ids, false);
            foreach (Player p in room.GetOtherPlayers(player))
                if (p.GetMark(Name) > 0 && ai.IsFriend(p)) targets.Add(p);

            if (targets.Count > 0)
            {
                KeyValuePair<Player, int> keys = ai.GetCardNeedPlayer(null, targets, Player.Place.PlaceHand);
                if (keys.Key != null && keys.Value > -1)
                {
                    use.Card.AddSubCard(keys.Value);
                    use.To.Add(keys.Key);
                    return use;
                }
                else
                {
                    use.Card.AddSubCard(ids[0]);
                    use.To.Add(targets[0]);
                    return use;
                }
            }

            foreach (int id in ids)
            {
                if (RoomLogic.CanDiscard(room, player, player, id))
                {
                    use.Card.AddSubCard(id);
                    break;
                }
            }

            return use;
        }
    }

    public class WanlanAI : SkillEvent
    {
        public WanlanAI() : base("wanlan")
        {
            key = new List<string> { "skillInvoke:wanlan" };
        }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.ChoiceMade && data is string str && player != ai.Self)
            {
                List<string> strs = new List<string>(str.Split(':'));
                if (strs[1] == Name && strs[2] == "yes")
                {
                    Room room = ai.Room;
                    Player target = null;
                    foreach (Player p in room.GetAlivePlayers())
                    {
                        if (p.HasFlag(Name))
                        {
                            target = p;
                            break;
                        }
                    }

                    if (player != target && ai.GetPlayerTendency(target) != "unknown")
                        ai.UpdatePlayerRelation(player, target, true);
                }
            }
        }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            Room room = ai.Room;
            if (data is Player target)
                return ai.IsFriend(target);

            return false;
        }
    }

    public class QiaiMobileAI : SkillEvent
    {
        public QiaiMobileAI() : base("qiai_mobile") { }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (!player.HasUsed(QiaiCard.ClassName))
            {
                List<int> ids = new List<int>();
                foreach (int id in player.GetCards("he"))
                {
                    FunctionCard fcard = Engine.GetFunctionCard(ai.Room.GetCard(id).Name);
                    if (!(fcard is BasicCard))
                        ids.Add(id);
                }
                if (ids.Count > 0)
                {
                    ai.SortByUseValue(ref ids, false);
                    WrappedCard qa = new WrappedCard(QiaiCard.ClassName) { Skill = Name };
                    KeyValuePair<Player, int> key = ai.GetCardNeedPlayer(ids);
                    if (key.Key != null && key.Value >= 0)
                    {
                        qa.AddSubCard(key.Value);
                        ai.Target[Name] = key.Key;
                        return new List<WrappedCard> { qa };
                    }
                    else
                    {
                        List<Player> friends = ai.FriendNoSelf;
                        if (friends.Count > 0)
                        {
                            ai.Room.SortByActionOrder(ref friends);
                            qa.AddSubCard(ids[0]);
                            ai.Target[Name] = friends[0];
                            return new List<WrappedCard> { qa };
                        }
                        else
                        {
                            List<Player> players = ai.Room.GetOtherPlayers(player);
                            qa.AddSubCard(ids[0]);
                            ai.Target[Name] = players[0];
                            return new List<WrappedCard> { qa };
                        }
                    }
                }
            }
            return null;
        }

        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            if (data is Player target)
            {
                if (ai.IsFriend(target))
                    return ai.IsWeak(target) ? "recover" : "draw";
                else
                    return ai.IsWeak(target) ? "draw" : "recover";
            }
            return "recover";
        }
    }

    public class QiaiCardAI : UseCard
    {
        public QiaiCardAI() : base(QiaiCard.ClassName)
        { }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            use.Card = card;
            use.To = new List<Player> { ai.Target["qiai_mobile"] };
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 5;
    }

    public class ShanxiWCAI : SkillEvent
    {
        public ShanxiWCAI() : base("shanxi_wc")
        {
            key = new List<string> { "playerChosen:shanxi_wc" };
        }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (ai.Self == player) return;
            if (data is string choice)
            {
                string[] choices = choice.Split(':');
                if (choices[1] == Name)
                {
                    Room room = ai.Room;
                    Player target = room.FindPlayer(choices[2]);

                    if (ai.GetPlayerTendency(target) != "unknown")
                        ai.UpdatePlayerRelation(player, target, false);
                }
            }
        }

        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            List<Player> enemies = ai.GetEnemies(player);
            if (enemies.Count > 0)
            {
                ai.SortByHp(ref enemies, false);
                foreach (Player p in enemies)
                {
                    if (player.ContainsTag("shanxi_target") && player.GetTag("shanxi_target") is string target_name && target_name == p.Name)
                        return new List<Player>();
                    else
                        return new List<Player> { p };
                }
            }
            return new List<Player>();
        }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct(null, player, new List<Player>());
            List<int> ids = player.GetCards("he");
            List<double> values = ai.SortByKeepValue(ref ids, false);
            if (values[0] + values[1] < 3)
            {
                use.Card = new WrappedCard(ShanxiWCCard.ClassName);
                use.Card.AddSubCard(ids[0]);
                use.Card.AddSubCard(ids[1]);
            }
            return use;
        }
    }

    public class WanweiClassicAI : SkillEvent
    {
        public WanweiClassicAI() : base("wanwei_classic")
        {
            key = new List<string> { "skillInvoke:wanwei_classic" };
        }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.ChoiceMade && data is string str && player != ai.Self)
            {
                List<string> strs = new List<string>(str.Split(':'));
                if (strs[1] == Name && strs[2] == "yes")
                {
                    Room room = ai.Room;
                    Player target = null;
                    foreach (Player p in room.GetAlivePlayers())
                    {
                        if (p.HasFlag(Name))
                        {
                            target = p;
                            break;
                        }
                    }

                    if (player != target && ai.GetPlayerTendency(target) != "unknown")
                        ai.UpdatePlayerRelation(player, target, true);
                }
            }
        }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            return data is Player target && ai.IsFriend(target);
        }
        
    }

    public class YuejianClassicAI : SkillEvent
    {
        public YuejianClassicAI() : base("yuejian_classic") { }
        public override List<int> OnDiscard(TrustedAI ai, Player player, List<int> ids, int min, int max, bool option)
        {
            if (ai.GetKnownCardsNums(Analeptic.ClassName, "h", player) + ai.GetKnownCardsNums(Peach.ClassName, "h", player) == 0)
            {
                List<int> cards = player.GetCards("he");
                if (cards.Count >= 2)
                {
                    ai.SortByKeepValue(ref cards, false);
                    return new List<int> { cards[0], cards[1] };
                }
            }
            return new List<int>();
        }
    }

    public class YixiangAI : SkillEvent
    {
        public YixiangAI() : base("yixiang") { }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            return true;
        }
    }

    public class YirangAI : SkillEvent
    {
        public YirangAI() : base("yirang")
        {
            key = new List<string> { "playerChosen:yirang" };
        }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (ai.Self == player) return;
            if (data is string choice)
            {
                string[] choices = choice.Split(':');
                if (choices[1] == Name)
                {
                    Room room = ai.Room;
                    Player target = room.FindPlayer(choices[2]);

                    if (ai.GetPlayerTendency(target) != "unknown")
                        ai.UpdatePlayerRelation(player, target, true);
                }
            }
        }

        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            bool equip = false, trick = false;
            Room room = ai.Room;
            List<int> ids = new List<int>();
            foreach (int id in player.GetCards("he"))
            {
                WrappedCard card = room.GetCard(id);
                CardType type = Engine.GetFunctionCard(card.Name).TypeID;
                if (type == CardType.TypeBasic) continue;
                ids.Add(id);
                if (type == CardType.TypeTrick)
                    trick = true;
                else if (type == CardType.TypeEquip)
                    equip = true;

                if (card.Name == Vine.ClassName)
                {
                    foreach (Player p in targets)
                        if (ai.IsFriend(p) && !ai.HasSkill("zishu", p) && ai.HasSkill("shixin", p))
                            return new List<Player> { p };
                }
                if (card.Name == SilverLion.ClassName)
                {
                    foreach (Player p in targets)
                        if (ai.IsFriend(p) && !ai.HasSkill("zishu", p) && ai.HasSkill("dingpan", p))
                            return new List<Player> { p };
                }
                if (card.Name == Spear.ClassName)
                {
                    foreach (Player p in targets)
                        if (ai.IsFriend(p) && !ai.HasSkill("zishu", p) && ai.HasSkill("tushe", p))
                            return new List<Player> { p };
                }
                if (card.Name == EightDiagram.ClassName)
                {
                    foreach (Player p in targets)
                        if (ai.IsFriend(p) && !ai.HasSkill("zishu", p) && ai.HasSkill("tiandu", p))
                            return new List<Player> { p };
                }
            }

            if (equip)
            {
                foreach (Player p in targets)
                    if (ai.IsFriend(p) && ai.HasSkill(TrustedAI.LoseEquipSkill, p) && !ai.WillSkipPlayPhase(p) && !ai.HasSkill("zishu", p))
                        return new List<Player> { p };
                foreach (Player p in targets)
                    if (ai.IsFriend(p) && ai.HasSkill(TrustedAI.NeedEquipSkill, p) && !ai.WillSkipPlayPhase(p) && !ai.HasSkill("zishu", p))
                        return new List<Player> { p };
            }
            if (trick)
            {
                foreach (Player p in targets)
                    if (ai.IsFriend(p) && ai.HasSkill("jizhi|jizhi_jx", p) && !ai.WillSkipPlayPhase(p) && !ai.HasSkill("zishu", p))
                        return new List<Player> { p };
            }
            foreach (Player p in targets)
                if (ai.IsFriend(p) && ai.HasSkill(TrustedAI.CardneedSkill, p) && !ai.WillSkipPlayPhase(p) && !ai.HasSkill("zishu", p))
                    return new List<Player> { p };

            if (player.MaxHp == 1)
            {
                foreach (Player p in targets)
                    if (ai.IsFriend(p) && !ai.WillSkipPlayPhase(p) && !ai.HasSkill("zishu", p))
                        return new List<Player> { p };

                foreach (Player p in targets)
                    if (ai.IsFriend(p) && !ai.HasSkill("zishu", p))
                        return new List<Player> { p };

                if (ids.Count <= 2)
                {
                    int max_hp = 0;
                    foreach (Player p in targets)
                    {
                        if (p.MaxHp > max_hp)
                            max_hp = p.MaxHp;
                    }
                    foreach (Player p in targets)
                        if (p.MaxHp == max_hp && p.MaxHp - 1 >= ids.Count) return new List<Player> { p };
                }
            }

            return new List<Player>();
        }
    }

    public class RensheAI : SkillEvent
    {
        public RensheAI() : base("renshe")
        {
            key = new List<string> { "playerChosen:renshe" };
        }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (ai.Self == player) return;
            if (data is string choice)
            {
                string[] choices = choice.Split(':');
                if (choices[1] == Name)
                {
                    Room room = ai.Room;
                    Player target = room.FindPlayer(choices[2]);

                    if (ai.GetPlayerTendency(target) != "unknown")
                        ai.UpdatePlayerRelation(player, target, true);
                }
            }
        }
    }

    public class WuyuanAI : SkillEvent
    {
        public WuyuanAI() : base("wuyuan") { }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (!player.HasUsed(WuyuanCard.ClassName))
                return new List<WrappedCard> { new WrappedCard(WuyuanCard.ClassName) { Skill = Name } };

            return null;
        }

        public override double CardValue(TrustedAI ai, Player player, WrappedCard card, bool isUse, Player.Place place)
        {
            if (card != null && !card.IsVirtualCard() && ai.HasSkill(Name, player) && card.Name.Contains(Slash.ClassName))
            {
                double value = 2;
                if (WrappedCard.IsRed(card.Suit)) value += 1;
                if (card.Name != Slash.ClassName) value += 1.5;
                return value;
            }
            return 0;
        }
    }

    public class WuyuanCardAI : UseCard
    {
        public WuyuanCardAI() : base(WuyuanCard.ClassName) { }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                Player target = use.To[0];
                if (ai.GetPlayerTendency(target) != "unknown")
                    ai.UpdatePlayerRelation(player, target, true);
            }
        }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            List<int> slashes = new List<int>();
            Room room = ai.Room;
            foreach (int id in player.GetCards("h"))
            {
                WrappedCard wrapped = room.GetCard(id);
                if (wrapped.Name.Contains(Slash.ClassName)) slashes.Add(id);
            }

            if (slashes.Count > 0)
            {
                List<Player> friends = ai.FriendNoSelf;
                room.SortByActionOrder(ref friends);
                foreach (int id in slashes)
                {
                    WrappedCard slash = room.GetCard(id);
                    if (WrappedCard.IsRed(slash.Suit) && slash.Name != Slash.ClassName)
                    {
                        foreach (Player p in friends)
                        {
                            if (p.IsWounded() && !ai.HasSkill("zishu", p) && !ai.WillSkipPlayPhase(player))
                            {
                                card.AddSubCard(id);
                                use.Card = card;
                                use.To.Add(p);
                                return;
                            }
                        }
                    }
                }

                foreach (int id in slashes)
                {
                    WrappedCard slash = room.GetCard(id);
                    if (!WrappedCard.IsRed(slash.Suit) && slash.Name != Slash.ClassName)
                    {
                        foreach (Player p in friends)
                        {
                            if (!ai.HasSkill("zishu", p) && !ai.WillSkipPlayPhase(player))
                            {
                                card.AddSubCard(id);
                                use.Card = card;
                                use.To.Add(p);
                                return;
                            }
                        }
                    }
                }

                foreach (int id in slashes)
                {
                    WrappedCard slash = room.GetCard(id);
                    if (WrappedCard.IsRed(slash.Suit))
                    {
                        foreach (Player p in friends)
                        {
                            if (p.IsWounded() && !ai.HasSkill("zishu", p))
                            {
                                card.AddSubCard(id);
                                use.Card = card;
                                use.To.Add(p);
                                return;
                            }
                        }
                    }
                }

                ai.SortByUseValue(ref slashes, false);
                {
                    foreach (Player p in friends)
                    {
                        if (!ai.HasSkill("zishu", p) && !ai.WillSkipPlayPhase(player))
                        {
                            card.AddSubCard(slashes[0]);
                            use.Card = card;
                            use.To.Add(p);
                            return;
                        }
                    }
                }
            }
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card)
        {
            return 4;
        }
    }

    public class ShamengAI : SkillEvent
    {
        public ShamengAI() : base("shameng") { }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            List<Player> friends = ai.FriendNoSelf;
            if (!player.HasUsed(ShamengCard.ClassName) && player.HandcardNum >= 2 && friends.Count > 0)
            {
                Room room = ai.Room;
                room.SortByActionOrder(ref friends);
                List<int> ids = new List<int>();
                foreach (int id in player.GetCards("h"))
                    if (RoomLogic.CanDiscard(room, player, player, id)) ids.Add(id);

                if (ids.Count > 1)
                {
                    ai.SortByUseValue(ref ids, false);
                    foreach (int id in ids)
                    {
                        foreach (int id2 in ids)
                        {
                            if (id == id2)
                                continue;
                            else if (WrappedCard.IsBlack(room.GetCard(id).Suit) == WrappedCard.IsBlack(room.GetCard(id2).Suit))
                            {
                                foreach (Player p in friends)
                                {
                                    WrappedCard sm = new WrappedCard(ShamengCard.ClassName) { Skill = Name };
                                    sm.AddSubCard(id);
                                    sm.AddSubCard(id2);
                                    ai.Target[Name] = p;
                                    return new List<WrappedCard> { sm };
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
    }

    public class ShamengCardAI : UseCard
    {
        public ShamengCardAI() : base(ShamengCard.ClassName)
        {
        }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                Player target = use.To[0];
                if (ai.GetPlayerTendency(target) != "unknown")
                    ai.UpdatePlayerRelation(player, target, true);
            }
        }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            use.Card = card;
            use.To = new List<Player> { ai.Target["shameng"] };
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 5;
    }

    public class ZhiyiAI : SkillEvent
    {
        public ZhiyiAI() : base("zhiyi") { }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct();
            if (player.GetTag(Name) is List<string> cards)
            {
                List<WrappedCard> slashes = new List<WrappedCard>();
                foreach (string card_name in cards)
                {
                    if (card_name.Contains(Slash.ClassName))
                    {
                        WrappedCard card = new WrappedCard(card_name);
                        card.Skill = "_zhiyi";
                        slashes.Add(card);
                    }
                }
                if (slashes.Count > 0)
                {
                    List<ScoreStruct> values = ai.CaculateSlashIncome(player, slashes);
                    if (values.Count > 0 && values[0].Score > 3)
                    {
                        use.From = player;
                        use.Card = values[0].Card;
                        use.To = values[0].Players;
                        return use;
                    }
                }

                if (cards.Contains(Peach.ClassName))
                {
                    WrappedCard card = new WrappedCard(Peach.ClassName);
                    card.Skill = "_zhiyi";
                    if (Peach.Instance.IsAvailable(ai.Room, player, card))
                    {
                        use.From = player;
                        use.Card = card;
                        return use;
                    }
                }
            }

            return use;
        }
    }

    public class ShengxiClassicAI : SkillEvent
    {
        public ShengxiClassicAI() : base("shengxi_classic") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data) => true;
    }

    public class JianyuAI : SkillEvent
    {
        public JianyuAI() : base("jianyu")
        {
            key = new List<string> { "skillInvoke:jianyu" };
        }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.ChoiceMade && data is string str)
            {
                List<string> strs = new List<string>(str.Split(':'));
                if (strs[1] == Name && strs[2] == "yes")
                {
                    Room room = ai.Room;
                    Player target = null;
                    foreach (Player p in room.GetAlivePlayers())
                    {
                        if (p.HasFlag(Name))
                        {
                            target = p;
                            break;
                        }
                    }

                    if (player != target && ai.GetPlayerTendency(target) != "unknown")
                        ai.UpdatePlayerRelation(player, target, true);
                }
            }
        }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (player.GetMark(Name) == 0)
            {
                return new List<WrappedCard> { new WrappedCard(JianyuCard.ClassName) { Skill = Name } };
            }
            return null;
        }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (data is Player target) return ai.IsFriend(target);
            return false;
        }
    }

    public class JianyuCardAI : UseCard
    {
        public JianyuCardAI() : base(JianyuCard.ClassName) { }
        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            Room room = ai.Room;
            List<Player> friends = ai.GetFriends(player), enemies = ai.GetEnemies(player);
            if (enemies.Count == 0)
            {
                enemies = room.GetOtherPlayers(player);
                enemies.RemoveAll(t => friends.Contains(t));
            }

            if (friends.Count > 0 && enemies.Count > 0)
            {
                ai.SortByDefense(ref friends, false);
                ai.SortByHandcards(ref enemies);
                use.Card = card;
                use.To.Add(friends[0]);
                use.To.Add(enemies[0]);
            }
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 8;
    }

    public class MingxuanAI : SkillEvent
    {
        public MingxuanAI() : base("mingxuan") { }
        public override List<int> OnExchange(TrustedAI ai, Player player, string pattern, int min, int max, string pile)
        {
            Room room = ai.Room;
            List<int> ids = new List<int>();
            foreach (int id in player.GetCards("h"))
                if (Engine.MatchExpPattern(room, pattern, player, room.GetCard(id)))
                    ids.Add(id);

            if (ids.Count == 1)
                return ids;
            else
            {
                ai.SortByUseValue(ref ids, false);
                return new List<int> { ids[0] };
            }
        }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct(null, player, new List<Player>());
            string target_name = prompt.Split(':')[1];
            Room room = ai.Room;
            Player target = room.FindPlayer(target_name);
            if (target != null && RoomLogic.CanSlash(room, player, target))
            {
                if (ai.IsFriend(target)) return use;

                List<ScoreStruct> scores = ai.CaculateSlashIncome(player, null, new List<Player> { target });
                if (scores.Count > 0 && scores[0].Score > -2 && scores[0].Card != null)
                {
                    use.Card = scores[0].Card;
                    use.To.Add(target);
                }
            }

            return use;
        }
    }

    public class XianchouAI : SkillEvent
    {
        public XianchouAI() : base("xianchou")
        {
        }

        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            Room room = ai.Room;
            Player enemy = null;
            foreach (Player p in room.GetOtherPlayers(player))
            {
                if (p.HasFlag(Name))
                {
                    enemy = p;
                    break;
                }
            }
            WrappedCard slash = new WrappedCard(Slash.ClassName);
            if (ai.GetDamageScore(new DamageStruct(slash, player, enemy)).Score > 0)
            {
                List<ScoreStruct> scores = new List<ScoreStruct>();
                foreach (Player p in targets)
                {
                    if (ai.IsFriend(p) && (ai.HasSkill("liegong_jx|tieqi_jx|wushuang|jianchu|moukui|fuqi") || (ai.HasSkill("jiedao", p) && p.IsWounded())))
                    {
                        if (RoomLogic.IsProhibited(room, p, enemy, slash) == null)
                        {
                            ScoreStruct score = new ScoreStruct
                            {
                                Players = new List<Player> { p },
                                Card = slash,
                            };

                            DamageStruct damage = new DamageStruct(slash, p, enemy);
                            if (ai.HasArmorEffect(enemy, Vine.ClassName) && slash.Name == Slash.ClassName && p.HasWeapon(Fan.ClassName))
                            {
                                WrappedCard fan = new WrappedCard(FireSlash.ClassName);
                                fan.AddSubCard(slash);
                                fan = RoomLogic.ParseUseCard(room, fan);
                                damage.Card = fan;
                            }

                            if (damage.Card.Name == FireSlash.ClassName)
                                damage.Nature = DamageStruct.DamageNature.Fire;
                            else if (damage.Card.Name == ThunderSlash.ClassName)
                                damage.Nature = DamageStruct.DamageNature.Thunder;

                            ScoreStruct damage_score = ai.GetDamageScore(damage);
                            if (damage_score.Score > 0)
                            {
                                ScoreStruct effect = ai.SlashIsEffective(damage.Card, p, enemy);
                                if (effect.Score > 0)
                                {
                                    score.Score = effect.Score;
                                    if (effect.Rate > 0)
                                    {
                                        score.Score += Math.Min(1, effect.Rate) * damage_score.Score;
                                        scores.Add(score);
                                    }
                                }
                            }
                        }
                    }
                }

                if (scores.Count > 0)
                {
                    scores.Sort((x, y) => { return x.Score > y.Score ? -1 : 1; });
                    return scores[0].Players;
                }

                scores.Clear();
                foreach (Player p in targets)
                {
                    if (ai.IsFriend(p))
                    {
                            if (RoomLogic.IsProhibited(room, p, enemy, slash) == null)
                            {
                                ScoreStruct score = new ScoreStruct
                                {
                                    Players = new List<Player> { p },
                                    Card = slash,
                                };

                                DamageStruct damage = new DamageStruct(slash, p, enemy);
                                if (ai.HasArmorEffect(enemy, Vine.ClassName) && slash.Name == Slash.ClassName && p.HasWeapon(Fan.ClassName))
                                {
                                    WrappedCard fan = new WrappedCard(FireSlash.ClassName);
                                    fan.AddSubCard(slash);
                                    fan = RoomLogic.ParseUseCard(room, fan);
                                    damage.Card = fan;
                                }

                                if (damage.Card.Name == FireSlash.ClassName)
                                    damage.Nature = DamageStruct.DamageNature.Fire;
                                else if (damage.Card.Name == ThunderSlash.ClassName)
                                    damage.Nature = DamageStruct.DamageNature.Thunder;

                                ScoreStruct damage_score = ai.GetDamageScore(damage);
                                if (damage_score.Score > 0)
                                {
                                    ScoreStruct effect = ai.SlashIsEffective(damage.Card, p, enemy);
                                    if (effect.Score > 0)
                                    {
                                        score.Score = effect.Score;
                                        if (effect.Rate > 0)
                                        {
                                            score.Score += Math.Min(1, effect.Rate) * damage_score.Score;
                                            scores.Add(score);
                                        }
                                    }
                                }
                            }
                        }
                }

                if (scores.Count > 0)
                {
                    scores.Sort((x, y) => { return x.Score > y.Score ? -1 : 1; });
                    return scores[0].Players;
                }
            }

            return new List<Player>();
        }

        public override List<int> OnDiscard(TrustedAI ai, Player player, List<int> ids, int min, int max, bool option)
        {
            Room room = ai.Room;
            DamageStruct damage = (DamageStruct)room.GetTag("CurrentDamageStruct");
            Player target = damage.From;

            WrappedCard slash = new WrappedCard(Slash.ClassName);

            List<int> discard = new List<int>();
            foreach (int id in player.GetCards("he"))
                if (RoomLogic.CanDiscard(room, player, player, id)) discard.Add(id);

            if (discard.Count > 0)
            {
                ScoreStruct score = ai.GetDamageScore(new DamageStruct(slash, player, target));
                List<double> values = ai.SortByKeepValue(ref ids, false);
                if (score.Score > 0 && RoomLogic.IsProhibited(room, player, target, slash) == null)
                {
                    if (ai.IsCardEffect(slash, target, player) && !ai.IsCancelTarget(slash, target, player))
                    {
                        if (values[0] / 2 < score.Score) return new List<int> { ids[0] };
                    }
                    else if (ai.HasArmorEffect(target, Vine.ClassName) && player.HasWeapon(Fan.ClassName))
                    {
                        slash = new WrappedCard(FireSlash.ClassName);
                        if (ai.IsCardEffect(slash, target, player) && !ai.IsCancelTarget(slash, target, player) && values[0] / 2 < score.Score)
                            return new List<int> { ids[0] };
                    }
                }
                else if (!ai.IsCardEffect(slash, target, player) || ai.IsCancelTarget(slash, target, player) || RoomLogic.IsProhibited(room, player, target, slash) != null)
                {
                    if (values[0] < 0) return new List<int> { ids[0] };
                }
            }

            return new List<int>();
        }
    }

    public class QiaoshiJXAI : SkillEvent
    {
        public QiaoshiJXAI() : base("qiaoshi_jx")
        {
        }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (data is string str)
            {
                Room room = ai.Room;
                string[] strs = str.Split(':');
                Player target = room.FindPlayer(strs[1]);
                if (ai.IsFriend(target))
                    return true;
                else
                {
                    DamageStruct damage = (DamageStruct)room.GetTag("CurrentDamageStruct");
                    if (damage.Damage == 1 && !ai.IsEnemy(target))
                        return true;
                }
            }

            return false;
        }

        public override ScoreStruct GetDamageScore(TrustedAI ai, DamageStruct damage)
        {
            Room room = ai.Room;
            ScoreStruct score = new ScoreStruct
            {
                Score = 0
            };
            if (damage.To != null && RoomLogic.PlayerHasSkill(room, damage.To, Name) && !damage.To.HasFlag(Name) && damage.To.Hp > 1 && damage.From != null && damage.From != damage.To && ai.IsFriend(damage.From, damage.To))
            {
                if (ai.IsFriend(damage.To))
                    score.Score += 1.5;
                else
                    score.Score -= 2;
            }
            return score;
        }
    }

    public class YanyuJXAI : SkillEvent
    {
        public YanyuJXAI() : base("yanyu_jx") { key = new List<string> { "playerChosen:yanyu_jx" }; }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.ChoiceMade && data is string str && player != ai.Self)
            {
                string[] strs = str.Split(':');
                if (strs[1] == Name)
                {
                    Room room = ai.Room;
                    Player target = room.FindPlayer(strs[2]);
                    if (ai.GetPlayerTendency(target) != "unknown")
                        ai.UpdatePlayerRelation(player, target, true);
                }
            }
        }
        public override double CardValue(TrustedAI ai, Player player, WrappedCard card, bool isUse, Place place) => place == Place.PlaceHand && card.Name.Contains(Slash.ClassName) ? 3 : 0;
    }

    public class TunchuJxAI : SkillEvent
    {
        public TunchuJxAI() : base("tunchu_jx") { }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            return true;
        }

        public override List<int> OnExchange(TrustedAI ai, Player player, string pattern, int min, int max, string pile)
        {
            Room room = ai.Room;
            if (ai.WillSkipPlayPhase(player))
            {
                List<int> ids = new List<int>(), cards = player.GetCards("h");
                ai.SortByKeepValue(ref cards, false);

                while (cards.Count >= player.Hp)
                {
                    ids.Add(cards[0]);
                    cards.RemoveAt(0);
                }

                if (ids.Count == 0 && cards.Count > 0)
                    return new List<int> { cards[0] };
                else
                    return ids;
            }
            if (ai is SmartAI)
            {
                if (ai.GetOverflow(player) > 0 && !ai.IsSituationClear())
                {
                    List<int> ids = new List<int>();
                    foreach (int id in player.GetCards("h"))
                        if (room.GetCard(id).Name.Contains("Slash"))
                            ids.Add(id);

                    return ids;
                }
            }

            return new List<int>();
        }
    }

    public class ShuliangJxAI : SkillEvent
    {
        public ShuliangJxAI() : base("shuliang_jx")
        {
            key = new List<string> { "cardExchange:shuliang_jx" };
        }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.ChoiceMade && data is string str)
            {
                Room room = ai.Room;
                string[] strs = str.Split(':');
                if (strs[1] == Name)
                {
                    Player target = room.Current;
                    if (ai is SmartAI && player != ai.Self)
                    {
                        if (ai.GetPlayerTendency(target) == "unknown")
                            ai.UpdatePlayerRelation(player, target, true);
                    }
                    else if (ai is StupidAI _ai)
                    {
                        if (_ai.GetPlayerTendency(target) != "unknown")
                            _ai.UpdatePlayerRelation(player, target, true);
                    }
                }
            }
        }
        public override List<int> OnExchange(TrustedAI ai, Player player, string pattern, int min, int max, string pile)
        {
            Room room = ai.Room;
            Player target = room.Current;
            if (ai.IsFriend(target))
                return new List<int> { player.GetPile("commissariat")[0] };

            return new List<int>();
        }
    }

    public class RangjieAI : SkillEvent
    {
        public RangjieAI() : base("rangjie")
        {
            key = new List<string> { "cardChosen:rangjie" };
        }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.ChoiceMade && data is string choice)
            {
                string[] choices = choice.Split(':');
                if (choices[1] == Name)
                {
                    Room room = ai.Room;
                    int id = int.Parse(choices[2]);
                    Player target = room.FindPlayer(choices[4]);

                    if (player != target && ai.GetPlayerTendency(target) != "unknown")
                    {
                        if (room.GetCardPlace(id) == Player.Place.PlaceDelayedTrick)
                            ai.UpdatePlayerRelation(player, target, true);
                        else
                        {
                            bool friend = ai.GetKeepValue(id, target, Player.Place.PlaceEquip) < 0;
                            ai.UpdatePlayerRelation(player, target, friend);
                        }
                    }
                }
            }
        }

        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            if (choice.Contains("get"))
                return "get";
            else
                return "basic";
        }
    }

    public class YizhengCardAI : UseCard
    {
        public YizhengCardAI() : base("yizheng")
        {
        }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                Player target = use.To[0];
                if (ai.GetPlayerTendency(target) != "unknown")
                    ai.UpdatePlayerRelation(player, target, false);
            }
        }
    }

    public class ZhouxuanAI : SkillEvent
    {
        public ZhouxuanAI() : base("zhouxuan")
        {
            key = new List<string> { "Yiji:zhouxuan" };
        }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.ChoiceMade && data is string str)
            {
                Room room = ai.Room;
                string[] strs = str.Split(':');
                Player target = room.FindPlayer(strs[3]);
                ai.UpdatePlayerRelation(player, target, true);
                if (player == ai.Self)
                {
                    List<string> cards = new List<string>(strs[4].Split('+'));
                    List<int> ids = JsonUntity.StringList2IntList(cards);
                    foreach (int id in ids)
                        ai.SetPrivateKnownCards(target, id);
                }
            }
        }
    }

    public class ChengzhaoAI : SkillEvent
    {
        public ChengzhaoAI() : base("chengzhao")
        {
            key = new List<string> { "playerChosen:chengzhao" };
        }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (data is string choice)
            {
                string[] choices = choice.Split(':');
                if (choices[1] == Name)
                {
                    Room room = ai.Room;
                    Player target = room.FindPlayer(choices[2]);

                    if (target != null && ai.GetPlayerTendency(target) != "unknown")
                        ai.UpdatePlayerRelation(player, target, false);
                }
            }
        }

        public override WrappedCard OnPindian(TrustedAI ai, Player requestor, List<Player> players)
        {
            return ai.GetMaxCard();
        }

        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            List<Player> enemies = ai.GetEnemies(player);
            if (enemies.Count > 0)
            {
                ai.SortByDefense(ref enemies, false);
                foreach (Player p in enemies)
                    if (targets.Contains(p))
                        return new List<Player> { p };
            }

            return new List<Player>();
        }
    }

    public class WeifengAI : SkillEvent
    {
        public WeifengAI() : base("weifeng")
        { }

        public override void DamageEffect(TrustedAI ai, ref DamageStruct damage, DamageStruct.DamageStep step)
        {
            if (damage.Card != null && damage.To.ContainsTag(Name) && damage.To.GetTag(Name) is KeyValuePair<string, string> wei)
            {
                string card = damage.Card.Name.Contains(Slash.ClassName) ? Slash.ClassName : damage.Card.Name;
                if (card == wei.Value)
                    damage.Damage++;
            }
        }

        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            ai.SortByDefense(ref targets, false);
            foreach (Player p in targets)
                if (ai.IsEnemy(p)) return new List<Player> { p };

            return new List<Player>();
        }
    }

    public class JinfanAI : SkillEvent
    {
        public JinfanAI() : base("jinfan") { }
        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct(null, player, new List<Player>());

            Room room = ai.Room;
            List<string> patterns = new List<string> { "spade", "heart", "club", "diamond" };
            foreach (int id in player.GetPile("&ring"))
                patterns.Remove(WrappedCard.GetSuitString(room.GetCard(id).Suit));

            List<int> result = new List<int>();
            List<int> hands = player.GetCards("h");
            ai.SortByKeepValue(ref hands);
            foreach (int id in hands)
            {
                string suit = WrappedCard.GetSuitString(room.GetCard(id).Suit);
                if (patterns.Contains(suit))
                {
                    patterns.Remove(suit);
                    result.Add(id);
                }
            }

            if (result.Count > 0)
            {
                WrappedCard card = new WrappedCard(JinfanCard.ClassName) { Skill = Name };
                card.AddSubCards(result);
                use.Card = card;
            }

            return use;
        }
    }

    public class ShequeAI : SkillEvent
    {
        public ShequeAI() : base("sheque") { }
        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            Room room = ai.Room;

            CardUseStruct use = new CardUseStruct(null, player, new List<Player>());
            List<Player> targets = new List<Player>();
            foreach (Player p in room.GetOtherPlayers(player))
                if (p.HasFlag("SlashAssignee")) targets.Add(p);

            List<ScoreStruct> values = ai.CaculateSlashIncome(player, null, targets);
            if (values.Count > 0 && values[0].Score > 0)
            {
                use.Card = values[0].Card;
                use.To = values[0].Players;
            }

            return use;
        }
    }

    public class ZhiyanXHAI : SkillEvent
    {
        public ZhiyanXHAI() : base("zhiyan_xh") { }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            ai.Choice[Name] = string.Empty;
            List<WrappedCard> result = new List<WrappedCard>();
            if (player.GetMark("zhiyan_used") < 2)
            {
                int mark = player.GetMark(Name);
                List<string> choices = new List<string>();
                if ((mark == 2 || mark == 0) && player.HandcardNum < player.MaxHp)
                {
                    ai.Choice[Name] = "draw";
                    result.Add(new WrappedCard(ZhiyanCard.ClassName) { Skill = Name });
                }
                else if (mark <= 1 && player.HandcardNum - player.Hp > 0)
                {
                    List<Player> friends = ai.GetFriends(player);
                    if (friends.Count > 0)
                    {
                        ai.Choice[Name] = "give";
                        result.Add(new WrappedCard(ZhiyanCard.ClassName) { Skill = Name });
                    }
                }
            }

            return result;
        }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct(null, player, new List<Player>());
            List<Player> friends = ai.GetFriends(player);
            if (friends.Count > 0)
            {
                List<int> hands = player.GetCards("h"), give = new List<int>();
                Player target = null;
                while (give.Count < player.HandcardNum - player.Hp)
                {
                    KeyValuePair<Player, int> card = ai.GetCardNeedPlayer(hands, target == null ? friends : new List<Player> { target });
                    if (card.Key != null && card.Value >= 0)
                    {
                        target = card.Key;
                        give.Add(card.Value);
                        hands.Remove(card.Value);
                    }
                    else
                    {
                        if (target == null)
                        {
                            target = friends[0];
                        }

                        int count = player.HandcardNum - player.Hp - give.Count;
                        ai.SortByKeepValue(ref hands, false);
                        for (int i = 0; i < count; i++)
                        {
                            give.Add(hands[0]);
                        }
                    }
                }
                if (give.Count > 0)
                {
                    WrappedCard card = new WrappedCard(ZhiyanCard.ClassName) { Skill = Name };
                    card.AddSubCards(give);
                    use.To.Add(target);
                    use.Card = card;
                }
            }

            return use;
        }

        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            return ai.Choice[Name];
        }
    }

    public class ZhiyanCardAI : UseCard
    {
        public ZhiyanCardAI() : base(ZhiyanCard.ClassName)
        {
        }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (data is CardUseStruct use && use.To.Count > 0 && use.Card.SubCards.Count > 0)
            {
                ai.UpdatePlayerRelation(player, use.To[0], true);
            }
        }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            if (!string.IsNullOrEmpty(ai.Choice["zhiyan_xh"]))
            {
                use.Card = card;
            }
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card)
        {
            return 0;
        }
    }

    public class ZhilueAI : SkillEvent
    {
        public ZhilueAI() : base("zhilue")
        {
        }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            List<WrappedCard> result = new List<WrappedCard>();
            if (!player.HasUsed(ZhilueCard.ClassName) && player.Hp >= 2)
            {
                result.Add(new WrappedCard(ZhilueCard.ClassName) { Skill = Name });
            }
            return result;
        }

        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            return "draw";
        }

        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            WrappedCard slash = new WrappedCard(Slash.ClassName)
            {
                Skill = Name
            };
            List<ScoreStruct> scores = ai.CaculateSlashIncome(player, new List<WrappedCard> { slash }, targets, false);
            if (scores.Count > 0 && scores[0].Players.Count == 1)
                return scores[0].Players;

            return null;
        }
    }

    public class ZhilueCardAI : UseCard
    {
        public ZhilueCardAI() : base(ZhilueCard.ClassName) { }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            use.Card = card;
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card)
        {
            return 4;
        }
    }

    public class KuangcaiAI : SkillEvent
    {
        public KuangcaiAI() : base("kuangcai") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data) => true;
    }

    public class DuojiAI : SkillEvent
    {
        public DuojiAI() : base("duoji") { }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (!player.HasUsed(DuojiCard.ClassName) && !player.IsNude())
            {
                Room room = ai.Room;
                List<int> ids = player.GetCards("he");
                int id = -1;
                List<double> values = ai.SortByKeepValue(ref ids, false);
                if (values[0] < 0)
                    id = ids[0];
                else
                {
                    values = ai.SortByUseValue(ref ids, false);
                    if (values[0] < 3)
                        id = ids[0];
                }
                if (id >= 0)
                {
                    foreach (Player p in ai.FriendNoSelf)
                    {
                        if (ai.HasSkill(TrustedAI.LoseEquipSkill, p))
                        {
                            WrappedCard dy = new WrappedCard(DuojiCard.ClassName) { Skill = Name };
                            dy.AddSubCard(id);
                            ai.Target[Name] = p;
                            return new List<WrappedCard> { dy };
                        }
                    }

                    List<Player> enemies = ai.GetEnemies(player);
                    ai.SortByDefense(ref enemies, false);
                    foreach (Player p in enemies)
                    {
                        if (!ai.HasSkill(TrustedAI.LoseEquipSkill, p))
                        {
                            WrappedCard dy = new WrappedCard(DuojiCard.ClassName) { Skill = Name };
                            dy.AddSubCard(id);
                            ai.Target[Name] = p;
                            return new List<WrappedCard> { dy };
                        }
                    }
                }
            }

            return null;
        }
    }

    public class DuojiCardAI : UseCard
    {
        public DuojiCardAI() : base(DuojiCard.ClassName) { }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                Player target = use.To[0];
                if (ai.GetPlayerTendency(target) != "unknown")
                    ai.UpdatePlayerRelation(player, target, ai.HasSkill(TrustedAI.LoseEquipSkill, target));
            }
        }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            use.Card = card;
            use.To = new List<Player> { ai.Target["duoji"] };
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 5;
    }

    public class JianzhanAI : SkillEvent
    {
        public JianzhanAI() : base("jianzhan")
        {}

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (!player.HasUsed(JianzhanCard.ClassName))
            {
                return new List<WrappedCard> { new WrappedCard(JianzhanCard.ClassName) { Skill = Name } };
            }
            return new List<WrappedCard>();
        }

        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            if (data is CardUseStruct use)
            {
                if (use.To.Count > 1)
                {
                    Player victim = use.To[1];
                    if (!ai.IsFriend(use.From) && !ai.IsFriend(victim))
                        return "slash";
                    else if (ai.IsFriend(victim) && ai.IsEnemy(use.From))
                    {
                        List<ScoreStruct> scores = ai.CaculateSlashIncome(player, new List<WrappedCard> { new WrappedCard(Slash.ClassName) }, new List<Player> { victim }, false);
                        if (scores[0].Score >= -1)
                            return "slash";
                    }
                    else if (ai.IsEnemy(victim))
                    {
                        List<ScoreStruct> scores = ai.CaculateSlashIncome(player, new List<WrappedCard> { new WrappedCard(Slash.ClassName) }, new List<Player> { victim }, false);
                        if (scores[0].Score >= 4)
                            return "slash";
                    }
                }
            }
            return "draw";
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, CardUseStruct use) => 5;
    }

    public class JianzhanCardAI : UseCard
    {
        public JianzhanCardAI() : base(JianzhanCard.ClassName) { }
        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            Room room = ai.Room;
            List<Player> enemies = ai.GetEnemies(player);
            if (enemies.Count > 0)
            {
                ai.SortByDefense(ref enemies, false);
                List<Player> friends = ai.FriendNoSelf;

                foreach (Player p in friends)
                {
                    if (RoomLogic.InMyAttackRange(room, p, enemies[0]) && enemies[0].HandcardNum < p.HandcardNum)
                    {
                        use.Card = card;
                        use.To = new List<Player> { p, enemies[0] };
                        return;
                    }
                }

                foreach (Player p in room.GetOtherPlayers(player))
                {
                    bool check = true;
                    foreach (Player p2 in room.GetOtherPlayers(p))
                    {
                        if (RoomLogic.InMyAttackRange(room, p, p2) && p2.HandcardNum < p.HandcardNum)
                        {
                            check = false;
                            break;
                        }
                    }

                    if (check)
                    {
                        use.Card = card;
                        use.To = new List<Player> { p };
                        return;
                    }
                }
            }
        }
    }

    public class MiewuAI : SkillEvent
    {
        public MiewuAI() : base("miewu") { }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            List<WrappedCard> result = new List<WrappedCard>();
            if (!player.HasFlag(Name) && player.GetMark("wuku") > 0)
            {
                Room room = ai.Room;
                List<int> ids = player.GetCards("he");
                if (ids.Count > 0)
                {
                    List<double> values = ai.SortByKeepValue(ref ids, false);
                    int sub;
                    if (values[0] < 0) sub = ids[0];
                    else
                    {
                        ai.SortByUseValue(ref ids, false);
                        sub = ids[0];
                    }

                    WrappedCard huomo = new WrappedCard(MiewuCard.ClassName) { Skill = Name };
                    huomo.AddSubCard(sub);

                    foreach (string card_name in MiewuVS.GetGuhuoCards(room, "bt"))
                    {
                        WrappedCard slash = new WrappedCard(card_name) { Skill = Name };
                        slash.AddSubCard(sub);
                        huomo.UserString = card_name;
                        slash.UserString = RoomLogic.CardToString(room, huomo);

                        result.Add(slash);
                    }
                }
            }

            return result;
        }

        public override List<WrappedCard> GetViewAsCards(TrustedAI ai, string pattern, Player player)
        {
            List<int> ids = player.GetCards("he");
            Room room = ai.Room;
            List<WrappedCard> result = new List<WrappedCard>();
            if (!player.HasFlag(Name) && player.GetMark("wuku") > 0)
            {
                if (ids.Count > 0)
                {
                    if (pattern == Slash.ClassName)
                    {
                        List<double> values = ai.SortByKeepValue(ref ids, false);
                        int sub;
                        if (values[0] < 0)
                            sub = ids[0];
                        else
                        {
                            ai.SortByUseValue(ref ids, false);
                            sub = ids[0];
                        }

                        WrappedCard huomo = new WrappedCard(MiewuCard.ClassName) { Skill = Name };
                        huomo.AddSubCard(sub);

                        WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = Name };
                        slash.AddSubCard(sub);
                        huomo.UserString = Slash.ClassName;
                        slash.UserString = RoomLogic.CardToString(room, huomo);
                        result.Add(slash);

                        WrappedCard fslash = new WrappedCard(FireSlash.ClassName) { Skill = Name };
                        fslash.AddSubCard(sub);
                        huomo.UserString = FireSlash.ClassName;
                        fslash.UserString = RoomLogic.CardToString(room, huomo);
                        result.Add(fslash);

                        WrappedCard tslash = new WrappedCard(ThunderSlash.ClassName) { Skill = Name };
                        tslash.AddSubCard(sub);
                        huomo.UserString = ThunderSlash.ClassName;
                        tslash.UserString = RoomLogic.CardToString(room, huomo);
                        result.Add(tslash);
                    }
                    else if (pattern == Analeptic.ClassName)
                    {
                        int sub;
                        List<double> values = ai.SortByKeepValue(ref ids, false);
                        if (values[0] < 0)
                            sub = ids[0];
                        else
                        {
                            ai.SortByUseValue(ref ids, false);
                            sub = ids[0];
                        }

                        WrappedCard huomo = new WrappedCard(MiewuCard.ClassName) { Skill = Name };
                        huomo.AddSubCard(sub);

                        WrappedCard slash = new WrappedCard(Analeptic.ClassName) { Skill = Name };
                        slash.AddSubCard(sub);
                        huomo.UserString = Analeptic.ClassName;
                        slash.UserString = RoomLogic.CardToString(room, huomo);

                        result.Add(slash);
                    }
                    else if (pattern == Peach.ClassName)
                    {
                        List<double> values = ai.SortByKeepValue(ref ids, false);
                        int sub;
                        if (values[0] < 0)
                            sub = ids[0];
                        else
                        {
                            ai.SortByUseValue(ref ids, false);
                            sub = ids[0];
                        }

                        WrappedCard huomo = new WrappedCard(MiewuCard.ClassName) { Skill = Name };
                        huomo.AddSubCard(sub);

                        WrappedCard slash = new WrappedCard(Peach.ClassName) { Skill = Name };
                        slash.AddSubCard(sub);
                        huomo.UserString = Peach.ClassName;
                        slash.UserString = RoomLogic.CardToString(room, huomo);

                        result.Add(slash);
                    }
                    else if (pattern == Jink.ClassName)
                    {
                        List<double> values = ai.SortByKeepValue(ref ids, false);
                        int sub;
                        if (values[0] < 0)
                            sub = ids[0];
                        else
                        {
                            ai.SortByUseValue(ref ids, false);
                            sub = ids[0];
                        }

                        WrappedCard huomo = new WrappedCard(MiewuCard.ClassName) { Skill = Name };
                        huomo.AddSubCard(sub);

                        WrappedCard slash = new WrappedCard(Jink.ClassName) { Skill = Name };
                        slash.AddSubCard(sub);
                        huomo.UserString = Jink.ClassName;
                        slash.UserString = RoomLogic.CardToString(room, huomo);

                        result.Add(slash);
                    }
                }
            }

            return result;
        }
    }


    public class FenyinAI : SkillEvent
    {
        public FenyinAI() : base("fenyin") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data) => true;
        public override double UsePriorityAdjust(TrustedAI ai, Player player, CardUseStruct use)
        {
            WrappedCard card = use.Card;
            if (!(Engine.GetFunctionCard(card.Name) is SkillCard) && player.GetMark(Name) > 0)
            {
                if ((card.Name == IronChain.ClassName || card.Name == GDFighttogether.ClassName) && use.To.Count == 0) return 0;
                int color = 1;
                if (WrappedCard.IsBlack(card.Suit))
                    color = 2;
                else if (WrappedCard.IsRed(card.Suit))
                    color = 2;

                if (color != player.GetMark(Name))
                    return 3.5;
            }

            return 0;
        }
    }

    public class FubiAI : SkillEvent
    {
        public FubiAI() : base("fubi") { key = new List<string> { "skillChoice:fubi" }; }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.ChoiceMade && data is string str && ai.Self != player)
            {
                string[] strs = str.Split(':');
                if (strs[1] == Name && strs[2] != "cancel")
                {
                    Room room = ai.Room;
                    Player target = room.Current;
                    if (ai.GetPlayerTendency(target) != "unknown")
                        ai.UpdatePlayerRelation(player, target, true);
                }
            }
        }
        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            foreach (Player p in targets)
                if (ai.IsFriend(p))
                    return new List<Player> { p };

            return new List<Player>();
        }

        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            if (data is Player target && ai.IsFriend(target))
            {
                if (ai.GetOverflow(target) > 3) return "max";
                return "extra";
            }

            return "cancel";
        }
    }

    public class ZuiciAI : SkillEvent
    {
        public ZuiciAI() : base("zuici") { }

        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            if (player.Hp == 0 && ai.GetCards(Analeptic.ClassName, player, true).Count > 0)
            {
                return "cancel";
            }
            else
            {
                string[] choices = choice.Split('+');
                return choices[choices.Length - 2];
            }
        }
    }

    public class DiancaiClassicAI : SkillEvent
    {
        public DiancaiClassicAI() : base("diancai_classic")
        {
            key = new List<string> { "playerChosen:diancai_classic" };
        }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (data is string choice)
            {
                string[] choices = choice.Split(':');
                if (choices[1] == Name)
                {
                    Room room = ai.Room;
                    foreach (string player_name in choices[2].Split('+'))
                    {
                        Player target = room.FindPlayer(player_name);
                        if (target != null && ai.GetPlayerTendency(target) != "unknown")
                            ai.UpdatePlayerRelation(player, target, true);
                    }
                }
            }
        }
        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            List<Player> result = new List<Player>();
            foreach (Player p in targets)
            {
                if (ai.IsFriend(p) && (!ai.HasSkill("zishu", p) || p.Phase != PlayerPhase.NotActive))
                {
                    result.Add(p);
                    if (result.Count >= max) break;
                }
            }
            return result;
        }
    }
    public class DiaoduClassicAI : SkillEvent
    {
        public DiaoduClassicAI() : base("diaodu_classic") { }
        Player FindTarget(TrustedAI ai, Player player)
        {
            Room room = ai.Room;
            List<Player> targets = new List<Player>();
            int result = -1;
            double best = -100;
            foreach (Player p in room.GetAlivePlayers())
            {
                foreach (int id in p.GetEquips())
                {
                    double v = ai.GetKeepValue(id, player);
                    double value = ai.IsFriend(p) ? -v : v;
                    foreach (Player _p in room.GetOtherPlayers(p))
                    {
                        if (RoomLogic.CanPutEquip(_p, room.GetCard(id)) && ai.GetSameEquip(room.GetCard(id), _p) == null)
                        {
                            double _v = ai.GetUseValue(id, _p);
                            double _value = value + (ai.IsFriend(_p) ? _v : -_v);
                            if (_value > best)
                            {
                                targets = new List<Player> { p, _p };
                                best = _value;
                                result = id;
                            }
                        }
                    }
                }
            }

            if (targets.Count == 2 && result > -1)
            {
                ai.Target[Name] = targets[1];
                ai.Choice[Name] = result.ToString();
                return targets[0];
            }

            return null;
        }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct(new WrappedCard(DiaoduCard.ClassName) { Skill = Name, ShowSkill = Name }, player, new List<Player>());
            ai.Target[Name] = null;
            ai.Choice[Name] = string.Empty;
            Player p = FindTarget(ai, player);
            if (p != null && ai.Target[Name] != null)
            {
                use.To.Add(p);
                use.To.Add(ai.Target[Name]);
                return use;
            }

            return new CardUseStruct();
        }

        public override int OnMoveStargeCard(TrustedAI ai, Player player, Player target1, Player target2, List<int> available)
        {
            if (ai.Choice.ContainsKey(Name) && !string.IsNullOrEmpty(ai.Choice[Name]) && int.TryParse(ai.Choice[Name], out int id) && available.Contains(id))
                return id;

            return -1;
        }
    }

    public class YanjiAI : SkillEvent
    {
        public YanjiAI() : base("yanji") { }
        public override string OnChoice(TrustedAI ai, Player player, string choice, object data) => "number";
    }
}