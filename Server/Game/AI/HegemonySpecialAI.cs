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
    public class HegemonySpecialAI : AIPackage
    {
        public HegemonySpecialAI() : base("HegemonySpecial")
        {
            events = new List<SkillEvent>
            {
                new WeichengAI(),
                new DaoshuAI(),
                new QuanjinAI(),
                new ZaoyunAI(),
                new JuejueAI(),
                new FangyuanAI(),
                new DeshaoHegemonyAI(),
                new MingfaHegemonyAI(),
                
                new TunchuAI(),
                new ShuliangAI(),
                new TongduAI(),
                new QingyinAI(),
                new ZhuhaiAI(),
                new JujianHegemonyAI(),

                new GuishuAI(),
                new YuanyuAI(),
                new WukuHegemonyAI(),
                new XisheAI(),
                new GuowuHegemonyAI(),
                new ShiyongAI(),
                new YaowuHegemonyAI(),

                new DujinAI(),
                new AocaiHegemonyAI(),
                new DuwuHegemonyAI(),
                new DiaoguiAI(),
            };
            use_cards = new List<UseCard>
            {
                new GuishuCardAI(),
                new DaoshuCardAI(),
                new QuanjinCardAI(),
                new ZaoyunCardAI(),
                new QingyinCardAI(),
                new DuwuHegemonyCardAI(),
                new DiaoguiCardAI(),
                new MingfaCardAI(),
            };
        }
    }


    public class WeichengAI : SkillEvent
    {
        public WeichengAI() : base("weicheng") { }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data) => true;
    }

    public class DaoshuAI : SkillEvent
    {
        public DaoshuAI() : base("daoshu")
        {
        }
        private readonly List<string> suits = new List<string> { "spade", "heart", "club", "diamond" };
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (ai.WillShowForAttack() && !player.HasFlag(Name))
            {
                WrappedCard card = new WrappedCard(DaoshuCard.ClassName)
                {
                    Skill = Name,
                    ShowSkill = Name
                };

                return new List<WrappedCard> { card };
            }

            return new List<WrappedCard>();
        }

        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            Player target = null;
            Room room = ai.Room;
            foreach (Player p in room.GetOtherPlayers(player))
            {
                if (p.HasFlag("daoshu_target"))
                {
                    target = p;
                    break;
                }
            }

            List<int> ids = ai.GetKnownCards(target);
            List<string> suits = new List<string>(this.suits);
            if (ids.Count > 0)
            {
                Dictionary<string, int> pairs = new Dictionary<string, int>();
                foreach (string suit in suits)
                    pairs[suit] = 0;
                foreach (int id in ids)
                {
                    string suit = WrappedCard.GetSuitString(Engine.GetRealCard(id).Suit);
                    pairs[suit]++;
                }

                suits.Sort((x, y) => { return pairs[x] > pairs[y] ? -1 : 1; });
                return suits[0];
            }
            else
            {
                Shuffle.shuffle(ref suits);
                return suits[0];
            }
        }

        public override List<int> OnExchange(TrustedAI ai, Player player, string pattern, int min, int max, string pile)
        {
            List<int> ids = new List<int>();
            Room room = ai.Room;
            foreach (int id in player.GetCards("h"))
            {
                if (Engine.MatchExpPattern(room, pattern, player, room.GetCard(id)))
                    ids.Add(id);
            }
            ai.SortByUseValue(ref ids, false);
            return new List<int> { ids[0] };
        }
    }

    public class DaoshuCardAI : UseCard
    {
        public DaoshuCardAI() : base(DaoshuCard.ClassName)
        {
        }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            Room room = ai.Room;
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                if (ai is SmartAI && ai.Self != player)
                {
                    if (!player.HasShownOneGeneral())
                    {
                        string role = (Scenario.Hegemony.WillbeRole(room, player) != "careerist" ? player.Kingdom : "careerist");
                        ai.UpdatePlayerIntention(player, role, 100);
                    }
                    foreach (Player p in use.To)
                        ai.UpdatePlayerRelation(player, p, false);
                }
                else if (ai is StupidAI)
                {
                    foreach (Player p in use.To)
                        if (ai.GetPlayerTendency(p) != "unknown")
                            ai.UpdatePlayerRelation(player, p, false);
                }
            }
        }
        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card)
        {
            return 5;
        }
        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            List<Player> targets = ai.GetEnemies(player);
            ai.SortByDefense(ref targets, false);
            foreach (Player p in targets)
            {
                if (!p.IsKongcheng())
                {
                    use.Card = card;
                    use.To.Add(p);
                    return;
                }
            }
        }
    }

    public class QuanjinAI : SkillEvent
    {
        public QuanjinAI() : base("quanjin")
        { }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (!player.HasUsed(QuanjinCard.ClassName) && !player.IsKongcheng())
            {
                Room room = ai.Room;
                foreach (Player p in room.GetOtherPlayers(player))
                {
                    if (p.HasFlag(Name))
                        return new List<WrappedCard> { new WrappedCard(QuanjinCard.ClassName) { Skill = Name, ShowSkill = Name } };
                }
            }
            return new List<WrappedCard>();
        }
    }

    public class QuanjinCardAI : UseCard
    {
        public QuanjinCardAI() : base(QuanjinCard.ClassName) { }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            if (player.HandcardNum < 5)
            {
                Room room = ai.Room;
                List<Player> targets = new List<Player>();
                foreach (Player p in room.GetOtherPlayers(player))
                    if (p.HasFlag(Name)) targets.Add(p);

                List<int> ids = player.GetCards("h");
                if (targets.Count > 0 && ids.Count > 0)
                {
                    foreach (Player p in targets)
                    {
                        if (ai.IsFriend(p))
                        {
                            KeyValuePair<Player, int> pair = ai.GetCardNeedPlayer(ids, new List<Player> { p });
                            if (pair.Key != null && pair.Value >= 0)
                            {
                                card.AddSubCard(pair.Value);
                                use.Card = card;
                                use.To.Add(p);
                                return;
                            }
                        }
                    }

                    ai.SortByUseValue(ref ids, false);
                    card.AddSubCard(ids[0]);
                    use.Card = card;
                    foreach (Player p in targets)
                    {
                        if (ai.IsEnemy(p))
                        {
                            use.To.Add(p);
                            return;
                        }
                    }

                    use.To.Add(targets[0]);
                }
            }
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 6;
    }

    public class ZaoyunAI : SkillEvent
    {
        public ZaoyunAI() : base("zaoyun") { }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (!player.HasUsed(ZaoyunCard.ClassName))
                return new List<WrappedCard> { new WrappedCard(ZaoyunCard.ClassName) { Skill = Name, ShowSkill = Name } };
            return new List<WrappedCard>();
        }
    }

    public class ZaoyunCardAI : UseCard
    {
        public ZaoyunCardAI() : base(ZaoyunCard.ClassName) { }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            List<Player> enemies = ai.GetEnemies(player);
            Room room = ai.Room;
            List<int> ids = new List<int>();
            foreach (int id in player.GetCards("h"))
                if (RoomLogic.CanDiscard(room, player, player, id)) ids.Add(id);
            List<Player> targets = new List<Player>();
            foreach (Player p in enemies)
            {
                if (!RoomLogic.WillBeFriendWith(room, player, p))
                {
                    int distance = RoomLogic.DistanceTo(room, player, p);
                    if (distance < 3 && distance >= 1 && distance - 1 <= ids.Count)
                        targets.Add(p);
                }
            }
            if (targets.Count > 0)
            {
                List<ScoreStruct> scores = new List<ScoreStruct>();
                foreach (Player p in targets)
                {
                    ScoreStruct score = ai.GetDamageScore(new DamageStruct("zaoyun", player, p));
                    score.Players = new List<Player> { p };
                    scores.Add(score);
                }

                ai.CompareByScore(ref scores);
                if (scores[0].Score > 1)
                {
                    ai.SortByUseValue(ref ids, false);
                    Player target = scores[0].Players[0];
                    int count = RoomLogic.DistanceTo(room, player, target) - 1;
                    for (int i = 0; i < count; i++)
                        card.AddSubCard(ids[i]);
                    use.Card = card;
                    use.To.Add(target);
                }
            }
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 5;
    }

    public class JuejueAI : SkillEvent
    {
        public JuejueAI() : base("juejue") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (player.Hp > 1 && ai.WillShowForAttack())
            {
                Room room = ai.Room;
                int MaxCards = RoomLogic.GetMaxCards(room, player);
                if (player.HandcardNum >= MaxCards)
                    return true;
            }
            return false;
        }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct(null, player, new List<Player>());
            Room room = ai.Room;
            Player target = room.Current;
            int count = target.GetMark(Name);

            ScoreStruct score = ai.GetDamageScore(new DamageStruct(Name, target, player));
            if (score.Score < 0)
            {
                List<int> hands = player.GetCards("h");
                List<double> values = ai.SortByKeepValue(ref hands, false);
                if (hands.Count >= count)
                {
                    double points = 0;
                    for (int i = 0; i < count; i++)
                        points += values[i];

                    if (points / 2 < -score.Score)
                    {
                        use.Card = new WrappedCard(JuejueCard.ClassName);
                        for (int i = 0; i < count; i++)
                            use.Card.AddSubCard(hands[i]);
                    }
                }
            }

            return use;
        }
    }

    public class FangyuanAI : SkillEvent
    {
        public FangyuanAI() : base("fangyuan")
        {
        }

        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            WrappedCard slash = new WrappedCard(Slash.ClassName) { DistanceLimited = false };
            List<ScoreStruct> scores = ai.CaculateSlashIncome(player, new List<WrappedCard> { slash }, targets, false);
            if (scores.Count > 0)
                return scores[0].Players;
            else
                return new List<Player>();
        }
    }

    public class DeshaoHegemonyAI : SkillEvent
    {
        public DeshaoHegemonyAI() : base("deshao_hegemony") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (ai.WillShowForDefence() && data is Player target && ai.IsEnemy(target)) return true;
            return false;
        }
    }

    public class MingfaHegemonyAI : SkillEvent
    {
        public MingfaHegemonyAI() : base("mingfa_hegemony") { }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (!player.HasUsed(MingfaCard.ClassName))
                return new List<WrappedCard> { new WrappedCard(MingfaCard.ClassName) { Skill = Name, ShowSkill = Name } };
            return new List<WrappedCard>();
        }
    }

    public class MingfaCardAI : UseCard
    {
        public MingfaCardAI() : base(MingfaCard.ClassName) { }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            Room room = ai.Room;
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use && ai.Self != player)
            {
                if (!player.HasShownOneGeneral())
                {
                    string role = (Scenario.Hegemony.WillbeRole(room, player) != "careerist" ? player.Kingdom : "careerist");
                    ai.UpdatePlayerIntention(player, role, 100);
                }
                foreach (Player p in use.To)
                    ai.UpdatePlayerRelation(player, p, false);
            }
        }
        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            List<Player> targets = ai.GetEnemies(player);
            if (targets.Count > 0)
            {
                ai.SortByDefense(ref targets);
                use.Card = card;
                use.To.Add(targets[0]);
            }
        }
        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 0;
    }

    public class TunchuAI : SkillEvent
    {
        public TunchuAI() : base("tunchu") { }

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

    public class ShuliangAI : SkillEvent
    {
        public ShuliangAI() : base("shuliang")
        {
            key = new List<string> { "cardExchange:shuliang" };
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

    public class TongduAI : SkillEvent
    {
        public TongduAI() : base("tongdu") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data) => true;
    }

    public class QingyinAI : SkillEvent
    {
        public QingyinAI() : base("qingyin") { }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (player.GetMark("@qingyin") > 0)
            {
                if (player.Hp == 1 && ai.GetCards(Peach.ClassName, player, true).Count == 0)
                    return new List<WrappedCard> { new WrappedCard(QingyinCard.ClassName) { Skill = Name, ShowSkill = Name } };

                int count = 0;
                Room room = ai.Room;
                foreach (Player p in room.GetAlivePlayers())
                    if (RoomLogic.WillBeFriendWith(room, player, p) && !p.Removed)
                        count += p.GetLostHp();
                if (count > 3)
                    return new List<WrappedCard> { new WrappedCard(QingyinCard.ClassName) { Skill = Name, ShowSkill = Name } };
            }
            return new List<WrappedCard>();
        }
    }

    public class QingyinCardAI : UseCard
    {
        public QingyinCardAI() : base(QingyinCard.ClassName) { }
        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            use.Card = card;
        }
        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 6;
    }


    public class ZhuhaiAI : SkillEvent
    {
        public ZhuhaiAI() : base("zhuhai") { }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            Room room = ai.Room;

            CardUseStruct use = new CardUseStruct(null, player, new List<Player>());
            List<Player> targets = new List<Player> { room.Current };            
            List<ScoreStruct> values = ai.CaculateSlashIncome(player, null, targets);
            if (values.Count > 0 && values[0].Score > 0)
            {
                use.Card = values[0].Card;
                use.To = values[0].Players;
            }

            return use;
        }
    }

    public class JujianHegemonyAI : SkillEvent
    {
        public JujianHegemonyAI() : base("jujian_hegemony")
        {
        }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct(null, player, new List<Player>());
            List<int> ids = new List<int>();
            Room room = ai.Room;
            foreach (int id in player.GetCards("he"))
            {
                WrappedCard card = room.GetCard(id);
                if (!(Engine.GetFunctionCard(card.Name) is BasicCard) && RoomLogic.CanDiscard(room, player, player, id))
                    ids.Add(id);
            }

            if (ids.Count > 0)
            {
                List<Player> friends = ai.FriendNoSelf;
                if (friends.Count > 0)
                {
                    ai.SortByKeepValue(ref ids, false);
                    ai.SortByDefense(ref friends, false);
                    foreach (Player p in friends)
                    {
                        if (!p.FaceUp)
                        {
                            use.Card = new WrappedCard(JujianHCard.ClassName) { Skill = Name };
                            use.Card.AddSubCard(ids[0]);
                            use.To.Add(p);
                            return use;
                        }
                    }

                    foreach (Player p in friends)
                    {
                        use.Card = new WrappedCard(JujianHCard.ClassName) { Skill = Name };
                        use.Card.AddSubCard(ids[0]);
                        use.To.Add(friends[0]);
                        return use;
                    }
                }
            }

            return use;
        }

        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            if (player.IsWounded() && ai.IsWeak(player))
                return "recover";

            return "draw";
        }
    }

    public class GuishuAI : SkillEvent
    {
        public GuishuAI() : base("guishu") { }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            Room room = ai.Room;
            List<int> ids = player.GetCards("h");
            ids.AddRange(player.GetHandPile());
            List<int> spades = new List<int>();
            foreach (int id in ids)
                if (room.GetCard(id).Suit == WrappedCard.CardSuit.Spade)
                    spades.Add(id);

            List<WrappedCard> result = new List<WrappedCard>();
            if (spades.Count > 0)
            {
                ai.SortByUseValue(ref spades, false);
                WrappedCard card = new WrappedCard(GuishuCard.ClassName)
                {
                    Skill = Name,
                    ShowSkill = Name
                };
                card.AddSubCard(spades[0]);

                if (player.GetMark(Name) == 0 || player.GetMark(Name) == 1)
                {
                    card.UserString = BefriendAttacking.ClassName;
                    WrappedCard ba = new WrappedCard(BefriendAttacking.ClassName)
                    {
                        Skill = Name,
                        ShowSkill = Name,
                    };
                    ba.AddSubCard(card);
                    ba = RoomLogic.ParseUseCard(room, ba);
                    ba.UserString = RoomLogic.CardToString(room, card);
                    result.Add(ba);
                }
                else if (spades.Count > 1)
                {
                    card.UserString = KnownBoth.ClassName;
                    result.Add(card);
                }
            }
            return result;
        }

        public override double CardValue(TrustedAI ai, Player player, WrappedCard card, bool isUse, Player.Place place)
        {
            if (ai.HasSkill(Name, player) && card.Id >= 0 && place == Player.Place.PlaceHand && !isUse && card.Suit == WrappedCard.CardSuit.Spade)
                return 1;

            return 0;
        }
    }

    public class GuishuCardAI : UseCard
    {
        public GuishuCardAI() : base(GuishuCard.ClassName) { }
        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            if (player.GetMark("guishu") == 2)
            {
                WrappedCard kb = new WrappedCard(KnownBoth.ClassName)
                {
                    Skill = Name,
                    ShowSkill = Name,
                };
                kb.AddSubCard(card);
                kb = RoomLogic.ParseUseCard(ai.Room, kb);

                UseCard e = Engine.GetCardUsage(KnownBoth.ClassName);
                if (e != null)
                {
                    CardUseStruct dummy = new CardUseStruct(null, player, new List<Player>())
                    {
                        IsDummy = true
                    };
                    e.Use(ai, player, ref dummy, kb);
                    if (dummy.Card == kb && dummy.To.Count > 0)
                    {
                        use.Card = card;
                        use.To = dummy.To;
                        return;
                    }
                }

                Room room = ai.Room;
                List<Player> targets = ai.Exclude(room.GetOtherPlayers(player), kb);
                if (targets.Count > 0)
                {
                    use.Card = card;
                    use.To.Add(targets[0]);
                }
            }
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card)
        {
            return 9;
        }
    }

    public class YuanyuAI : SkillEvent
    {
        public YuanyuAI() : base("yuanyu") { }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            return true;
        }
    }

    public class WukuHegemonyAI : SkillEvent
    {
        public WukuHegemonyAI() : base("wuku_hegemony") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data) => true;
    }

    public class XisheAI : SkillEvent
    {
        public XisheAI() : base("xishe") { }

        public override List<int> OnExchange(TrustedAI ai, Player player, string pattern, int min, int max, string pile)
        {
            if (ai.WillShowForAttack())
            {
                Room room = ai.Room;
                WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = "_xishe", DistanceLimited = false };
                List<ScoreStruct> scores = ai.CaculateSlashIncome(player, new List<WrappedCard> { slash }, new List<Player> { room.Current }, false);
                if (scores.Count > 0 && scores[0].Score > 5)
                {
                    List<string> strs = new List<string>(pattern.Split('#'));
                    if (strs.Count > 0)
                    {
                        List<int> ids = JsonUntity.StringList2IntList(strs);
                        ai.SortByKeepValue(ref ids, false);
                        return new List<int> { ids[0] };
                    }
                }
            }

            return new List<int>();
        }
    }

    public class GuowuHegemonyAI :SkillEvent
    {
        public GuowuHegemonyAI() : base("guowu_hegemony") { }
        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            Room room = ai.Room;
            if (room.GetTag("extra_target_skill") is CardUseStruct use)
            {
                List<Player> result = new List<Player>();
                if (use.Card.Name == Peach.ClassName)
                {
                    foreach (Player p in targets)
                        if (ai.IsFriend(p) && p.IsWounded())
                        {
                            result.Add(p);
                            if (result.Count >= 2) break;
                        }
                }
                else if (use.Card.Name == ExNihilo.ClassName)
                {
                    foreach (Player p in targets)
                        if (ai.IsFriend(p) && (!ai.HasSkill("zishu", p) || p.Phase != PlayerPhase.NotActive))
                        {
                            result.Add(p);
                            if (result.Count >= 2) break;
                        }
                }
                else if (use.Card.Name.Contains(Slash.ClassName))
                {
                    foreach (Player p in targets)
                    {
                        List<ScoreStruct> scores = ai.CaculateSlashIncome(player, new List<WrappedCard> { use.Card }, new List<Player> { p }, false);
                        if (scores.Count > 0 && scores[0].Score > 2)
                        {
                            result.Add(p);
                            if (result.Count >= 2) break;
                        }
                    }
                }
                else if (use.Card.Name == Snatch.ClassName)
                {
                    foreach (Player p in targets)
                    {
                        if (ai.FindCards2Discard(player, p, use.Card.Name, "hej", HandlingMethod.MethodGet).Score > 0)
                        {
                            result.Add(p);
                            if (result.Count >= 2) break;
                        }
                    }
                }
                else if (use.Card.Name == Dismantlement.ClassName)
                {
                    foreach (Player p in targets)
                    {
                        if (ai.FindCards2Discard(player, p, use.Card.Name, "hej", HandlingMethod.MethodDiscard).Score > 0)
                        {
                            result.Add(p);
                            if (result.Count >= 2) break;
                        }
                    }
                }

                return result;
            }

            return new List<Player>();
        }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data) => ai.WillShowForAttack();
    }

    public class YaowuHegemonyAI : SkillEvent
    {
        public YaowuHegemonyAI() : base("yaowu_hegemony") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data) => player.Hp <= 2;
    }

    public class ShiyongAI : SkillEvent
    {
        public ShiyongAI() : base("shiyong") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data) => ai.WillShowForMasochism();
    }

    public class DujinAI : SkillEvent
    {
        public DujinAI() : base("dujin") { }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            return ai.WillShowForAttack();
        }
        public override double CardValue(TrustedAI ai, Player player, WrappedCard card, bool isUse, Player.Place place)
        {
            if (!isUse && place == Player.Place.PlaceEquip)
            {
                return 4;
            }

            if (isUse && card.IsVirtualCard())
            {
                foreach (int id in card.SubCards)
                {
                    if (ai.Room.GetCardPlace(id) == Player.Place.PlaceEquip)
                        return -3;
                }
            }

            return 0;
        }
    }

    public class AocaiHegemonyAI : SkillEvent
    {
        public AocaiHegemonyAI() : base("aocai_hegemony") { }

        public override List<WrappedCard> GetViewAsCards(TrustedAI ai, string pattern, Player player)
        {
            List<WrappedCard> result = new List<WrappedCard>();
            Room room = ai.Room;
            if (player.Phase == PlayerPhase.NotActive && player.GetPile("#aocai").Count > 0
                && (room.GetRoomState().GetCurrentCardUseReason() == CardUseStruct.CardUseReason.CARD_USE_REASON_RESPONSE
                || room.GetRoomState().GetCurrentCardUseReason() == CardUseStruct.CardUseReason.CARD_USE_REASON_RESPONSE_USE)
                && (pattern == Slash.ClassName || pattern == Peach.ClassName || pattern == Jink.ClassName || pattern == Analeptic.ClassName))
            {
                foreach (int id in player.GetPile("#aocai"))
                {
                    if (Engine.MatchExpPattern(room, pattern, player, room.GetCard(id)))
                    {
                        WrappedCard card = Engine.CloneCard(room.GetCard(id));
                        card.Skill = Name;
                        card.UserString = id.ToString();
                        result.Add(card);
                    }
                }
            }

            return result;
        }

        public override double UseValueAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card)
        {
            return 20;
        }
    }

    public class DuwuHegemonyAI : SkillEvent
    {
        public DuwuHegemonyAI() : base("duwu_hegemony") { }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (player.GetMark("@duwu_hegemony") > 0 && ai.WillShowForAttack())
            {
                Room room = ai.Room;
                int count = 0;
                foreach (Player p in room.GetOtherPlayers(player))
                    if (RoomLogic.InMyAttackRange(room, player, p) && !RoomLogic.WillBeFriendWith(room, player, p)) count++;

                if (count * 2 >= ai.GetEnemies(player).Count)
                    return new List<WrappedCard> { new WrappedCard(DuwuHegemonyCard.ClassName) { Skill = Name, ShowSkill = Name } };
            }

            return new List<WrappedCard>();
        }
    }

    public class DuwuHegemonyCardAI : UseCard
    {
        public DuwuHegemonyCardAI() : base(DuwuHegemonyCard.ClassName) { }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            use.Card = card;
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 5;
    }

    public class DiaoguiAI : SkillEvent
    {
        public DiaoguiAI() : base("diaogui") { }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (!player.HasUsed(DiaoguiCard.ClassName))
            {
                Room room = ai.Room;
                List<int> ids = player.GetCards("he"), can_use = new List<int>(), equips = new List<int>();
                ids.AddRange(player.GetHandPile());
                foreach (int id in ids)
                {
                    WrappedCard card = room.GetCard(id);
                    Place place = room.GetCardPlace(id);
                    if (Engine.GetFunctionCard(card.Name) is BasicCard && RoomLogic.IsCardLimited(room, player, card, FunctionCard.HandlingMethod.MethodUse, place == Place.PlaceHand))
                    {
                        if (place == Place.PlaceEquip)
                            equips.Add(id);
                        else
                            can_use.Add(id);
                    }
                }

                double value = 0;
                int sub = -1;
                if (equips.Count > 0)
                {
                    List<double> values = ai.SortByKeepValue(ref equips, false);
                    value = values[0];
                    sub = equips[0];
                }
                if ((sub == -1 || value >= 0) && can_use.Count > 0)
                {
                    List<double> values = ai.SortByUseValue(ref can_use, false);
                    double _value = values[0];
                    if (_value < value || sub == -1)
                    {
                        sub = can_use[0];
                        value = _value;
                    }
                }

                WrappedCard lt = new WrappedCard(LureTiger.ClassName);
                lt.AddSubCard(sub);
                lt = RoomLogic.ParseUseCard(room, lt);
                if (room.AliveCount() >= 4)
                {
                    List<Player> targets = room.AliveCount() >= 4 ? RoomLogic.GetFormation(room, player) : new List<Player>();
                    int count_right = 0, count_left = 0, use = 2 + Engine.CorrectCardTarget(room, TargetModSkill.ModType.ExtraMaxTarget, player, lt);
                    for (int i = 0; i < room.AliveCount() - 1; i++)
                    {
                        Player target = room.GetNextAlive(player, i, false);
                        if (!target.Removed)
                        {
                            if (RoomLogic.WillBeFriendWith(room, player, target))
                            {
                                count_right++;
                            }
                            else if (use > 0 && RoomLogic.IsProhibited(room, player, target, lt) == null && !ai.IsCancelTarget(lt, target, player) && ai.IsCardEffect(lt, target, player))
                            {
                                use--;
                            }
                            else
                                break;
                        }
                    }
                    if (count_right > 0 && count_right + 1 > targets.Count)
                    {
                        WrappedCard huomo = new WrappedCard(DiaoguiCard.ClassName) { Skill = Name, ShowSkill = Name };
                        huomo.AddSubCard(sub);
                        return new List<WrappedCard> { huomo };
                    }
                    else
                    {
                        use = 2 + Engine.CorrectCardTarget(room, TargetModSkill.ModType.ExtraMaxTarget, player, lt);
                        for (int i = 0; i < room.AliveCount() - 1; i++)
                        {
                            Player target = room.GetLastAlive(player, i, false);
                            if (!target.Removed)
                            {
                                if (RoomLogic.WillBeFriendWith(room, player, target))
                                {
                                    count_left++;
                                }
                                else if (use > 0 && RoomLogic.IsProhibited(room, player, target, lt) == null && !ai.IsCancelTarget(lt, target, player) && ai.IsCardEffect(lt, target, player))
                                {
                                    use--;
                                }
                                else
                                    break;
                            }
                        }
                        if (count_left > 0 && count_left + 1 > targets.Count)
                        {
                            WrappedCard huomo = new WrappedCard(DiaoguiCard.ClassName) { Skill = Name, ShowSkill = Name };
                            huomo.AddSubCard(sub);
                            return new List<WrappedCard> { huomo };
                        }
                    }
                }

                if (sub >= 0)
                {
                    if (ai.GetUseValue(lt, player) > value)
                    {
                        WrappedCard huomo = new WrappedCard(DiaoguiCard.ClassName) { Skill = Name, ShowSkill = Name };
                        huomo.AddSubCard(sub);
                        lt.UserString = RoomLogic.CardToString(room, huomo);
                        return new List<WrappedCard> { lt };
                    }
                }
            }

            return new List<WrappedCard>();
        }
    }

    public class DiaoguiCardAI : UseCard
    {
        public DiaoguiCardAI() : base(DiaoguiCard.ClassName)
        {
        }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            WrappedCard lt = new WrappedCard(LureTiger.ClassName);
            lt.AddSubCards(card.SubCards);
            Room room = ai.Room;
            lt = RoomLogic.ParseUseCard(room, lt);
            List<Player> targets = room.AliveCount() >= 4 ? RoomLogic.GetFormation(room, player) : new List<Player>();
            List<Player> targets_right = new List<Player>(), targets_left = new List<Player>();
            int count_right = 0, count_left = 0, target_count = 2 + Engine.CorrectCardTarget(room, TargetModSkill.ModType.ExtraMaxTarget, player, lt);
            for (int i = 0; i < room.AliveCount() - 1; i++)
            {
                Player target = room.GetNextAlive(player, i, false);
                if (!target.Removed)
                {
                    if (RoomLogic.WillBeFriendWith(room, player, target))
                    {
                        count_right++;
                    }
                    else if (target_count > 0 && RoomLogic.IsProhibited(room, player, target, lt) == null && !ai.IsCancelTarget(lt, target, player) && ai.IsCardEffect(lt, target, player))
                    {
                        target_count--;
                        targets_right.Add(target);
                    }
                    else
                        break;
                }
            }


            target_count = 2 + Engine.CorrectCardTarget(room, TargetModSkill.ModType.ExtraMaxTarget, player, lt);
            for (int i = 0; i < room.AliveCount() - 1; i++)
            {
                Player target = room.GetLastAlive(player, i, false);
                if (!target.Removed)
                {
                    if (RoomLogic.WillBeFriendWith(room, player, target))
                    {
                        count_left++;
                    }
                    else if (target_count > 0 && RoomLogic.IsProhibited(room, player, target, lt) == null && !ai.IsCancelTarget(lt, target, player) && ai.IsCardEffect(lt, target, player))
                    {
                        target_count--;
                        targets_left.Add(target);
                    }
                    else
                        break;
                }
            }
            use.Card = card;
            if (count_left > count_right)
                use.To = targets_left;
            else
                use.To = targets_right;
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 6;
    }
}