using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Policy;
using CommonClass;
using CommonClass.Game;
using SanguoshaServer.Game;
using SanguoshaServer.Package;

namespace SanguoshaServer.AI
{
    public class NaturefourAI : AIPackage
    {
        public NaturefourAI() : base("Naturefour")
        {
            events = new List<SkillEvent>
            {
                new LeijiJXAI(),
                new ShuangxiongJXAI(),
                new GuhuoAI(),
                new JiuchiAI(),
                new BaonueAI(),
                new HuangtianVSAI(),
                new BeigeJXAI(),
                new WeimuJXAI(),
                new LuanwuJXAI(),

                new FangquanJXAI(),
                new LiegongJXAI(),
                new KuangguJXAI(),
                new QimouAI(),
                new ZaiqiJXAI(),
                new LierenJXAI(),
                new TiaoxinJXAI(),
                new KanpoJXAI(),
                new HuojiJXAI(),
                new LianhuanJXAI(),
                new NiepanJXAI(),

                new FenjiJXAI(),
                new JiangJxAI(),
                new ZhibaAI(),
                new ZhibaVSAI(),
                new TianxiangJXAI(),
                new PoluSJAI(),
                new ZhijianJXAI(),
                new HanzhanAI(),
                new HaoshiClassicAI(),
                new DimengClassicAI(),

                new QiangxiJXAI(),
                new TuntianJXAI(),
                new ShensuJXAI(),
                new ShebianAI(),
                new QiaobianJXAI(),
                new SongweiAI(),
            };

            use_cards = new List<UseCard>
            {
                new ZhibaCardAI(),
                new QimouCardAI(),
                new QiangxiJXCardAI(),
                new HuangtianCardAI(),
                new TiaoxinJXCardAI(),
                new DimengCCardAI(),
                new LuanwuJXCardAI(),
            };
        }
    }
    public class LeijiJXAI : SkillEvent
    {
        public LeijiJXAI() : base("leiji_jx")
        {
            key = new List<string> { "playerChosen:leiji_jx" };
        }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (ai.Self == player) return;
            if (data is string choice && ai.Self != player)
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

        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> target, int min, int max)
        {
            if (!ai.WillShowForAttack() || !ai.WillShowForDefence()) return new List<Player>();

            Room room = ai.Room;
            List<Player> enemies = ai.GetEnemies(player);
            ai.SortByDefense(ref enemies, false);
            List<ScoreStruct> scores = new List<ScoreStruct>();
            foreach (Player p in enemies)
            {
                if (ai.HasSkill("hongyan", p)) continue;
                DamageStruct damage = new DamageStruct(Name, player, p, 2, DamageStruct.DamageNature.Thunder);
                ScoreStruct score = ai.GetDamageScore(damage);
                if (score.Score > 0 && score.DoDamage)
                    score.Score += ai.ChainDamage(damage);
                scores.Add(score);
            }

            if (scores.Count > 0)
            {
                ai.CompareByScore(ref scores);
                if (scores[0].Score > 0)
                    return new List<Player> { scores[0].Damage.To };
            }

            return new List<Player>();
        }
    }
    public class FangquanJXAI : SkillEvent
    {
        public FangquanJXAI() : base("fangquan_jx")
        {
        }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            ai.Target[Name] = null;

            Room room = ai.Room;
            if (ai.HasSkill("rende|jili")) return false;
            if (ai.HasSkill("jizhi|jizhi_jx"))
            {
                foreach (int id in player.GetCards("h"))
                {
                    WrappedCard card = room.GetCard(id);
                    FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                    if (fcard is TrickCard && !(fcard is DelayedTrick) && !(fcard is Nullification))
                        return false;
                }
            }

            if (ai.FriendNoSelf.Count > 0 && player.HandcardNum > 0)
            {
                List<ScoreStruct> scores = ai.CaculateSlashIncome(player, null, null, false);
                if (scores.Count > 0 && scores[0].Card != null && scores[0].Score > 6) return false;

                List<int> cards = new List<int>();
                foreach (int id in player.GetCards("h"))
                    if (RoomLogic.CanDiscard(room, player, player, id))
                        cards.Add(id);

                if (cards.Count > 0)
                {
                    foreach (Player p in ai.FriendNoSelf)
                    {
                        if (!ai.WillSkipPlayPhase(p, player))
                        {
                            if (ai.HasSkill("jizhi|jizhi_jx|jili|rende", p) || player.HandcardNum >= player.HandcardNum)
                            {
                                ai.Target[Name] = p;
                                break;
                            }
                        }
                    }

                    if (ai.Target[Name] != null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct
            {
                From = player
            };

            if (ai.Target[Name] != null)
            {
                List<int> cards = new List<int>();
                foreach (int id in player.GetCards("h"))
                    if (RoomLogic.CanDiscard(ai.Room, player, player, id))
                        cards.Add(id);

                ai.SortByKeepValue(ref cards, false);

                use.Card = new WrappedCard(FangquanCard.ClassName)
                {
                    Skill = Name
                };
                use.Card.AddSubCard(cards[0]);
                use.To = new List<Player> { ai.Target[Name] };
            }

            return use;
        }
    }
    public class LiegongJXAI : SkillEvent
    {
        public LiegongJXAI() : base("liegong_jx")
        {
        }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (data is Player target && ai.IsEnemy(target))
                return true;

            return false;
        }

        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            if (choice.Contains("nojink"))
                return "nojink";
            else if (choice.Contains("damage"))
                return "damage";

            return base.OnChoice(ai, player, choice, data);
        }
    }
    public class KuangguJXAI : SkillEvent
    {
        public KuangguJXAI() : base("kuanggu_jx")
        {}
        
        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            if (ai.HasCrossbowEffect(player))
            {
                foreach (Player p in ai.GetEnemies(player))
                    if (RoomLogic.InMyAttackRange(ai.Room, player, p))
                        return "draw";
            }

            return "recover";
        }

        public override ScoreStruct GetDamageScore(TrustedAI ai, DamageStruct damage)
        {
            Player from = damage.From;
            Player to = damage.To;
            Room room = ai.Room;
            ScoreStruct score = new ScoreStruct();
            if (from != null && ai.HasSkill(Name, from) && (to == from && from.Hp > damage.Damage || RoomLogic.DistanceTo(room, from, to) == 1))
            {
                double value = 0;
                if (to == from)
                    value = damage.Damage * 4;
                else
                {
                    int heal = Math.Min(from.GetLostHp(), damage.Damage);
                    value = heal * 4 + (damage.Damage - heal) * 1.5;
                }
                if (ai.IsFriend(from))
                    score.Score = value;
                else if (ai.IsEnemy(from))
                    score.Score = -value;
            }

            return score;
        }
    }
    public class QimouAI : SkillEvent
    {
        public QimouAI() : base("qimou") { }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (player.GetMark("@mou") > 0 && player.Hp >= 2)
            {
                Room room = ai.Room;
                if (player.IsWounded() && ai.GetKnownCardsNums(Peach.ClassName, "he", player) > 0) return new List<WrappedCard>();
                double value = 0.6 * room.GetOtherPlayers(player).Count
                    * (ai.GetKnownCardsNums(SavageAssault.ClassName, "he", player) + ai.GetKnownCardsNums(ArcheryAttack.ClassName, "he", player));
                if (ai.GetEnemies(player).Count > 1 || ai.IsSituationClear())
                    value += ai.GetKnownCardsNums(Slash.ClassName, "he", player);
                if (value > 3.5)
                    return new List<WrappedCard> { new WrappedCard(QimouCard.ClassName) { Skill = Name, Mute = true } };
            }

            return new List<WrappedCard>();
        }

        public override double CardValue(TrustedAI ai, Player player, WrappedCard card, bool isUse, Player.Place place)
        {
            if (player.GetMark("@mou") > 0 && (card.Name.Contains(Slash.ClassName) || card.Name == SavageAssault.ClassName || card.Name == ArcheryAttack.ClassName))
                return 1.5;
            if (player.GetMark("@mou") > 0 && card.Name == Peach.ClassName && player.IsWounded())
                return 2;

            return 0;
        }

        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            return (player.Hp - 1).ToString();
        }
    }

    public class QimouCardAI : UseCard
    {
        public QimouCardAI() : base(QimouCard.ClassName) { }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            use.Card = card;
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card)
        {
            return 5;
        }
    }

    public class ZaiqiJXAI : SkillEvent
    {
        public ZaiqiJXAI() : base("zaiqi_jx")
        {
            key = new List<string> { "playerChosen:zaiqi_jx" };
        }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (data is string choice && ai.Self != player)
            {
                string[] choices = choice.Split(':');
                if (choices[1] == Name)
                {
                    Room room = ai.Room;
                    List<Player> targets = new List<Player>();
                    foreach (string general in choices[2].Split('+'))
                        targets.Add(room.FindPlayer(general, true));

                    foreach (Player p in targets)
                    {
                        if (p != player && ai.GetPlayerTendency(p) != "unknown")
                            ai.UpdatePlayerRelation(player, p, true);
                    }
                }
            }
        }
        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            List<Player> result = new List<Player> { player };
            ai.SortByDefense(ref targets, false);
            if (result.Count < max)
            {
                foreach (Player p in targets)
                {
                    if (ai.IsFriend(p) && !result.Contains(p))
                        result.Add(p);

                    if (result.Count >= max) break;
                }
            }

            return result;
        }

        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            if (data is Player target && ai.IsFriend(target) && ai.IsWeak(target))
                return "heal";

            return "draw";
        }
    }

    public class LierenJXAI : SkillEvent
    {
        public LierenJXAI() : base("lieren_jx")
        {
            key = new List<string> { "skillInvoke:lieren_jx:yes" };
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
                        if (p.HasFlag("lieren_target"))
                        {
                            target = p;
                            break;
                        }
                    }

                    if (ai.GetPlayerTendency(target) != "unknown")
                        ai.UpdatePlayerRelation(player, target, false);
                }
            }
        }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (data is Player target && ai.IsEnemy(target))
            {
                bool can_pindian = false;
                if (target.HandcardNum != 1 || !ai.NeedKongcheng(target))
                {
                    if (target.HandcardNum == 1)
                    {
                        foreach (int id in target.GetEquips())
                        {
                            if (RoomLogic.CanGetCard(ai.Room, player, target, id) && ai.GetKeepValue(id, target, Player.Place.PlaceEquip) > 0)
                            {
                                can_pindian = true;
                                break;
                            }
                        }
                    }
                }

                Room room = ai.Room;
                if (can_pindian)
                {
                    List<int> ids = new List<int>();
                    if (ai.Room.Current == player)
                    {
                        foreach (int id in player.GetCards("h"))
                        {
                            if (ai.GetUseValue(id, player, Player.Place.PlaceHand) < 6 || room.GetCard(id).Number > 11)
                                ids.Add(id);
                        }
                    }
                    else
                    {
                        foreach (int id in player.GetCards("h"))
                        {
                            if (ai.GetKeepValue(id, player, Player.Place.PlaceHand) < 5 || room.GetCard(id).Number > 11)
                                ids.Add(id);
                        }
                    }

                    if (ids.Count > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override double TargetValueAdjust(TrustedAI ai, WrappedCard card, Player from, List<Player> targets, Player to)
        {
            if (card.Name.Contains(Slash.ClassName) && from != null && to != null && !ai.IsFriend(from, to) && ai.HasSkill("lieren_jx", from) && !from.IsKongcheng()
                && RoomLogic.CanBePindianBy(ai.Room, to, from))
                return 1.5;

            return 0;
        }

        public override WrappedCard OnPindian(TrustedAI ai, Player requestor, List<Player> player)
        {
            if (ai.Self == requestor)
            {
                List<int> ids = new List<int>();
                if (ai.Room.Current == requestor)
                {
                    foreach (int id in requestor.GetCards("h"))
                    {
                        if (ai.GetUseValue(id, requestor, Player.Place.PlaceHand) < 6)
                            ids.Add(id);
                    }
                }
                else
                {
                    foreach (int id in requestor.GetCards("h"))
                    {
                        if (ai.GetKeepValue(id, requestor, Player.Place.PlaceHand) < 5)
                            ids.Add(id);
                    }
                }

                if (ids.Count > 0)
                {
                    return ai.GetMaxCard(requestor, ids);
                }
                else
                {
                    if (player[0].GetCards("he").Count > 1)
                        return ai.GetMaxCard(requestor);
                    else
                    {
                        ids = requestor.GetCards("h");
                        if (ai.Room.Current == requestor)
                        {
                            ai.SortByUseValue(ref ids, false);
                        }
                        else
                        {
                            ai.SortByKeepValue(ref ids, false);
                        }

                        return ai.Room.GetCard(ids[0]);
                    }
                }
            }
            else
            {
                return ai.GetMaxCard(ai.Self);
            }
        }
    }
    public class TiaoxinJXAI : SkillEvent
    {
        public TiaoxinJXAI() : base("tiaoxin_jx")
        {
        }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (player.UsedTimes(TiaoxinJXCard.ClassName) <= (player.HasFlag(Name) ? 1 : 0))
                return new List<WrappedCard> { new WrappedCard(TiaoxinJXCard.ClassName) { Skill = Name, ShowSkill = Name } };

            return null;
        }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct(null, player, new List<Player>());
            string target_name = prompt.Split(':')[1];
            Room room = ai.Room;
            Player target = room.FindPlayer(target_name);
            if (target != null && RoomLogic.CanSlash(room, player, target))
            {
                if (ai.IsFriend(target))
                    return use;
                else
                {
                    List<ScoreStruct> scores = ai.CaculateSlashIncome(player, null, new List<Player> { target });
                    if (scores.Count > 0 && scores[0].Score > 0 && scores[0].Card != null)
                    {
                        use.Card = scores[0].Card;
                        use.To.Add(target);
                    }
                }
            }

            return use;
        }
    }

    public class TiaoxinJXCardAI : UseCard
    {
        public TiaoxinJXCardAI() : base(TiaoxinJXCard.ClassName)
        {
        }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            Room room = ai.Room;
            List<ScoreStruct> scores = new List<ScoreStruct>();
            foreach (Player p in room.GetOtherPlayers(player))
            {
                if (p.IsNude() || !RoomLogic.CanSlash(room, p, player)) continue;
                ScoreStruct score = ai.FindCards2Discard(player, p, string.Empty, "he", FunctionCard.HandlingMethod.MethodDiscard);
                score.Players = new List<Player> { p };
                if (ai.IsEnemy(p))
                {
                    if (p.HandcardNum + p.GetPile("wooden_ox").Count < 3 || ai.IsLackCard(p, Slash.ClassName))
                    {
                        score.Score += 3;
                    }
                    else
                    {
                        bool armor_ignore = false;
                        if (p.HasWeapon(QinggangSword.ClassName) || p.HasWeapon(Saber.ClassName) || (ai.HasSkill("jianchu|moukui", p) && player.GetArmor()))
                            armor_ignore = true;
                        else if (ai.HasSkill("paoxiao|paoxiao_fz", p))
                        {
                            Player lord = ai.FindPlayerBySkill("shouyue");
                            if (lord != null && RoomLogic.PlayerHasShownSkill(room, lord, "shouyue") && RoomLogic.WillBeFriendWith(room, p, lord))
                                armor_ignore = true;
                        }

                        if (!armor_ignore && ai.HasArmorEffect(player, RenwangShield.ClassName))
                            score.Score += 0.5;
                        if (!armor_ignore && ai.HasArmorEffect(player, EightDiagram.ClassName))
                            score.Score += 0.5;
                        if (ai.HasSkill("wushang", p))
                            score.Score -= 0.5;
                        if (p.HasWeapon(DragonPhoenix.ClassName))
                            score.Score -= 0.5;
                        if (ai.HasSkill("jianchu", p))
                            score.Score = -0.5;
                        if (ai.HasSkill("tieqi|tieqi_fz", p))
                            score.Score = 1;
                        if (ai.GetKnownCardsNums(Jink.ClassName, "he", player) == 0)
                            score.Score -= 2;
                    }
                }
                scores.Add(score);
            }

            if (scores.Count > 0)
            {
                ai.CompareByScore(ref scores);
                if (scores[0].Score > 2)
                {
                    use.Card = card;
                    use.To = new List<Player>(scores[0].Players);
                }
            }
        }
    }

    public class KanpoJXAI : SkillEvent
    {
        public KanpoJXAI() : base("kanpo_jx")
        {
        }

        public override WrappedCard ViewAs(TrustedAI ai, Player player, int id, bool current, Player.Place place)
        {
            Room room = ai.Room;
            WrappedCard card = room.GetCard(id);
            if (card != null && WrappedCard.IsBlack(card.Suit) && (player.GetHandPile().Contains(id)))
            {
                WrappedCard nulli = new WrappedCard(Nullification.ClassName)
                {
                    Skill = Name,
                    ShowSkill = Name
                };
                nulli.AddSubCard(id);
                nulli = RoomLogic.ParseUseCard(room, nulli);
                return nulli;
            }

            return null;
        }

        public override double CardValue(TrustedAI ai, Player player, WrappedCard card, bool isUse, Player.Place place)
        {
            if (!isUse && ai.HasSkill(Name, player) && !card.IsVirtualCard())
            {
                if (WrappedCard.IsBlack(ai.Room.GetCard(card.GetEffectiveId()).Suit))
                    return 1.5;
            }

            return 0;
        }

        public override double UseValueAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card)
        {
            int id = card.GetEffectiveId();
            Room room = ai.Room;
            List<WrappedCard> cards = ai.GetViewAsCards(player, id);
            double value = 0;
            foreach (WrappedCard c in cards)
            {
                if (c.Skill == Name) continue;
                double card_value = ai.GetUseValue(c, player, room.GetCardPlace(id));
                if (card_value > value)
                    value = card_value;
            }

            return Math.Min(0, 4 - value);
        }
    }

    public class HuojiJXAI : SkillEvent
    {
        public HuojiJXAI() : base("huoji_jx")
        {
        }
        public override double UseValueAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card)
        {
            return -2;
        }
        public override double UsePriorityAdjust(TrustedAI ai, Player player, CardUseStruct use)
        {
            if (use.Card.Name == FireAttack.ClassName && use.Card.Skill == Name)
                return -2;

            return 0;
        }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            Room room = ai.Room;
            List<int> ids = player.GetCards("he");
            ids.AddRange(player.GetHandPile());

            foreach (int id in ids)
            {
                WrappedCard card = ai.Room.GetCard(id);
                if (WrappedCard.IsRed(card.Suit) && card.Name != FireAttack.ClassName)
                {
                    WrappedCard slash = new WrappedCard(FireAttack.ClassName)
                    {
                        Skill = Name,
                        ShowSkill = Name
                    };
                    slash.AddSubCard(card);
                    slash = RoomLogic.ParseUseCard(room, slash);
                    return new List<WrappedCard> { slash };
                }
            }

            return null;
        }
    }

    public class NiepanJXAI : SkillEvent
    {
        public NiepanJXAI() : base("niepan_jx")
        {
        }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            Room room = ai.Room;
            int count = 0;
            List<WrappedCard> analeptics = ai.GetCards(Analeptic.ClassName, player, true);
            analeptics.AddRange(ai.GetCards(Peach.ClassName, player, true));
            foreach (WrappedCard card in analeptics)
                if (!RoomLogic.IsCardLimited(room, player, card, FunctionCard.HandlingMethod.MethodUse) && RoomLogic.IsProhibited(room, player, player, card) == null)
                    count++;

            if (count >= 1 - player.Hp)
                return false;

            return true;
        }
    }

    public class LianhuanJXAI : SkillEvent
    {
        public LianhuanJXAI() : base("lianhuan_jx")
        {
        }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (!ai.WillShowForAttack()) return null;
            Room room = ai.Room;
            List<int> ids = player.GetCards("he");
            ids.AddRange(player.GetHandPile());
            ai.SortByUseValue(ref ids, false);
            foreach (int id in ids)
            {
                WrappedCard card = room.GetCard(id);
                if (card.Suit == WrappedCard.CardSuit.Club)
                {
                    List<WrappedCard> cards = ai.GetViewAsCards(player, id);
                    double value = 0;
                    WrappedCard _card = null;
                    foreach (WrappedCard _c in cards)
                    {
                        double card_value = ai.GetUseValue(_c, player, room.GetCardPlace(id));
                        if (card_value > value)
                        {
                            value = card_value;
                            _card = _c;
                        }
                    }

                    if (_card != null && _card.Name == IronChain.ClassName && _card.Skill == Name) return new List<WrappedCard> { _card };
                }
            }

            return null;
        }

        public override WrappedCard ViewAs(TrustedAI ai, Player player, int id, bool current, Player.Place place)
        {
            Room room = ai.Room;
            WrappedCard card = room.GetCard(id);
            if (card != null && card.Suit == WrappedCard.CardSuit.Club)
            {
                WrappedCard ic = new WrappedCard(IronChain.ClassName)
                {
                    Skill = Name,
                    ShowSkill = Name
                };
                ic.AddSubCard(card);
                ic = RoomLogic.ParseUseCard(room, ic);
                return ic;
            }

            return null;
        }
    }


    public class FenjiJXAI : SkillEvent
    {
        public FenjiJXAI() : base("fenji_jx")
        {
            key = new List<string> { "skillInvoke:fenji_jx:yes" };
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
                        if (p.HasFlag("fenji_target"))
                        {
                            target = p;
                            break;
                        }
                    }

                    if (ai.GetPlayerTendency(target) != "unknown")
                        ai.UpdatePlayerRelation(player, target, true);
                }
            }
        }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (data is Player target && ai.IsFriend(target) && (player.Hp > 1 || player.GetPile("buqu_jx").Count <= 4))
                return true;

            return false;
        }
    }
    public class JiangJxAI : SkillEvent
    {
        public JiangJxAI() : base("jiang_jx") { }

        public override double TargetValueAdjust(TrustedAI ai, WrappedCard card, Player from, List<Player> targets, Player to)
        {
            double value = 0;
            if ((card.Name.Contains(Slash.ClassName) && WrappedCard.IsRed(card.Suit) || card.Name == Duel.ClassName) && ai.HasSkill(Name, to))
                value += ai.IsFriend(to) ? 2 : -2;

            return value;
        }

        public override double CardValue(TrustedAI ai, Player player, WrappedCard card, bool isUse, Player.Place place)
        {
            if (ai.HasSkill(Name, player) && (card.Name.Contains(Slash.ClassName) && WrappedCard.IsRed(card.Suit) || card.Name == Duel.ClassName) && isUse)
                return 1.5;

            return 0;
        }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data) => true;
        public override List<int> OnExchange(TrustedAI ai, Player player, string pattern, int min, int max, string pile)
        {
            if (!ai.WillSkipPlayPhase(player))
            {
                List<int> ids = player.GetPile("#jiang_jx");
                if (player.Hp > 1)
                {
                    foreach (int id in ids)
                    {
                        WrappedCard card = ai.Room.GetCard(id);
                        if (card.Name == Duel.ClassName)
                            return new List<int> { id };
                    }
                    return new List<int> { ids[0] };
                }
            }
            return new List<int>();
        }
    }

    public class ZhibaAI : SkillEvent
    {
        public ZhibaAI() : base("zhiba")
        {
        }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            Room room = ai.Room;
            if (!player.HasUsed(ZhibaCard.ClassName) && !player.IsKongcheng())
                return new List<WrappedCard> { new WrappedCard(ZhibaCard.ClassName) { Skill = Name } };

            return new List<WrappedCard>();
        }

        public override WrappedCard OnPindian(TrustedAI ai, Player requestor, List<Player> players)
        {
            Room room = ai.Room;
            if (ai.Self == requestor)
            {
                if (ai.Number[Name] >= 0)
                    return ai.GetMaxCard();

                return ai.GetMaxCard();
            }
            else
            {
                if (ai.IsFriend(requestor))
                    return ai.GetMinCard();
                else
                    return ai.GetMaxCard();
            }
        }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (data is string str)
            {
                if (str != "@zhiba")
                {
                    Room room = ai.Room;
                    string[] strs = str.Split(':');
                    Player target = room.FindPlayer(strs[1]);
                    if (!ai.IsFriend(target) && ai.GetMaxCard(player).Number < 12)
                        return false;
                }
            }

            return true;
        }
    }

    public class ZhibaVSAI : SkillEvent
    {
        public ZhibaVSAI() : base("zhibavs")
        {
            key = new List<string> { "pindian:zhibavs" };
        }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            Room room = ai.Room;
            Player lord = RoomLogic.FindPlayerBySkillName(room, "zhiba");
            if (lord != null && player.Kingdom == "wu" && !player.HasUsed(ZhibaCard.ClassName) && !player.IsKongcheng()
                && RoomLogic.CanBePindianBy(room, lord, player) && (ai.IsFriend(lord) || ai.IsEnemy(lord)))
                return new List<WrappedCard> { new WrappedCard(ZhibaCard.ClassName) { Skill = Name } };

            return new List<WrappedCard>();
        }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (data is string str && ai.Self != player)
            {
                string[] strs = str.Split(':');

                Room room = ai.Room;
                int from_card = int.Parse(strs[3]);
                Player lord = room.FindPlayer(strs[4]);
                WrappedCard from = room.GetCard(from_card);
                if (from.Number > 10)
                    ai.UpdatePlayerRelation(player, lord, false);
                if (from.Number < 6)
                    ai.UpdatePlayerRelation(player, lord, true);
            }
        }

        public override WrappedCard OnPindian(TrustedAI ai, Player requestor, List<Player> players)
        {
            Player lord = players[0];
            Room room = ai.Room;
            if (ai.Self == requestor)
            {
                if (ai.Number[Name] >= 0)
                    return room.GetCard((int)ai.Number[Name]);
                else if (ai.IsFriend(lord))
                    return ai.GetMinCard();
                else
                    return ai.GetMinCard();
            }
            else
                return ai.GetMaxCard();
        }
    }

    public class ZhibaCardAI : UseCard
    {
        public ZhibaCardAI() : base(ZhibaCard.ClassName)
        {
        }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            Room room = ai.Room;
            if (card.Skill == "zhibavs")
            {
                Player lord = RoomLogic.FindPlayerBySkillName(room, "zhiba");
                ai.Number["zhibavs"] = -1;
                ai.Number[Name] = 1;

                int max = 7;
                if (ai.IsFriend(lord))
                {
                    if (lord.HandcardNum == 1)
                        max = 5;
                }
                else
                    max = 11;

                List<int> knowns = ai.GetKnownCards(lord);
                if (knowns.Count == lord.HandcardNum) max = 0;
                foreach (int id in knowns)
                {
                    WrappedCard wrapped = room.GetCard(id);
                    if (wrapped.Number > max)
                        max = wrapped.Number;
                }

                if (ai.IsFriend(lord))
                {
                    KeyValuePair<Player, int> pair = ai.GetCardNeedPlayer(null, new List<Player> { lord }, Player.Place.PlaceHand);
                    if (pair.Key != null && room.GetCard(pair.Value).Number <= max)
                    {
                        use.Card = card;
                        ai.Number["zhibavs"] = pair.Value;
                    }

                    if (ai.GetOverflow(player) > 0)
                    {
                        WrappedCard min = ai.GetMinCard();
                        if (min.Number <= max)
                        {
                            use.Card = card;
                            ai.Number["zhibavs"] = min.GetEffectiveId();
                        }
                    }
                }
                else
                {
                    WrappedCard max_self = ai.GetMaxCard();
                    if (max_self.Number > max)
                    {
                        use.Card = card;
                        ai.Number["zhibavs"] = max_self.GetEffectiveId();
                        if (ai.GetOverflow(player) > 0)
                            ai.Number[Name] = 3;
                    }
                }
            }
            else
            {
                List<Player> enemies = ai.GetEnemies(player);
                ai.SortByDefense(ref enemies, false);
                WrappedCard max_self = ai.GetMaxCard();
                foreach (Player p in enemies)
                {
                    if (p.Kingdom == "wu" && RoomLogic.CanBePindianBy(room, p, player))
                    {
                        int max = 11;

                        List<int> knowns = ai.GetKnownCards(p);
                        if (knowns.Count == p.HandcardNum) max = 0;
                        foreach (int id in knowns)
                        {
                            WrappedCard wrapped = room.GetCard(id);
                            if (wrapped.Number > max)
                                max = wrapped.Number;
                        }

                        if (max_self.Number >= max)
                        {
                            ai.Number[Name] = 3;
                            ai.Number["zhiba"] = max_self.GetEffectiveId();
                            use.Card = card;
                            use.To = new List<Player> { p };
                            return;
                        }
                    }
                }

                if (ai.GetOverflow(player) > 1)
                {
                    List<int> ids = player.GetCards("h");
                    ai.SortByKeepValue(ref ids, false);
                    foreach (Player p in enemies)
                    {
                        if (p.Kingdom == "wu" && RoomLogic.CanBePindianBy(room, p, player))
                        {
                            ai.Number[Name] = 0;
                            ai.Number["zhiba"] = ids[0];
                            use.Card = card;
                            use.To = new List<Player> { p };
                            return;
                        }
                    }
                }
            }
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card)
        {
            return ai.Number[Name];
        }
    }

    public class TianxiangJXAI : SkillEvent
    {
        public TianxiangJXAI() : base("tianxiang_jx")
        { }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct(null, player, new List<Player>());
            Room room = ai.Room;
            if (room.GetTag("TianxiangDamage") is DamageStruct damage)
            {
                if (ai.GetDamageScore(damage, DamageStruct.DamageStep.Done).Score < 0 && !ai.NeedToLoseHp(damage, false, false, DamageStruct.DamageStep.Done))
                {
                    List<int> ids = new List<int>();
                    foreach (int id in player.GetCards("h"))
                        if (RoomLogic.CanDiscard(room, player, player, id) && room.GetCard(id).Suit == WrappedCard.CardSuit.Heart)
                            ids.Add(id);

                    ai.SortByKeepValue(ref ids, false);
                    if (ids.Count > 0)
                    {
                        WrappedCard tianxiangCard = new WrappedCard("TianxiangCard")
                        {
                            Skill = Name
                        };
                        tianxiangCard.AddSubCard(ids[0]);

                        foreach (Player p in ai.FriendNoSelf)
                        {
                            if (ai.HasSkill("buqu_jx", p) && p.GetPile("buqu_jx").Count < 3 && p.Hp <= 2)
                            {
                                use.Card = tianxiangCard;
                                use.To.Add(p);
                                return use;
                            }

                            if (ai.HasSkill("hunzi", p) && p.GetMark("hunzi") == 0 && p.Hp == 2)
                            {
                                use.Card = tianxiangCard;
                                use.To.Add(p);
                                return use;
                            }

                            if (ai.HasSkill("zhaxiang", p) && !ai.WillSkipPlayPhase(p) && p.Hp > 1)
                            {
                                use.Card = tianxiangCard;
                                use.To.Add(p);
                                return use;
                            }
                        }

                        List<Player> enemies = ai.GetPrioEnemies();
                        ai.SortByDefense(ref enemies, false);
                        foreach (Player p in enemies)
                        {
                            DamageStruct _damage = new DamageStruct(Name, damage.From, p, 1);
                            if (ai.GetDamageScore(_damage).Score > 6 && !ai.CanResist(p, _damage.Damage))
                            {
                                use.Card = tianxiangCard;
                                use.To.Add(p);
                                return use;
                            }
                        }

                        foreach (Player p in enemies)
                        {
                            if (!p.Removed && p.Hp <= 2)
                            {
                                use.Card = tianxiangCard;
                                use.To.Add(p);
                                return use;
                            }
                        }

                        enemies = ai.GetEnemies(player);
                        if (enemies.Count > 0)
                        {
                            ai.SortByDefense(ref enemies, false);
                            foreach (Player p in enemies)
                            {
                                if (!p.Removed)
                                {
                                    use.Card = tianxiangCard;
                                    use.To.Add(p);
                                    return use;
                                }
                            }
                        }
                    }
                }
            }

            return use;
        }

        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            Room room = ai.Room;
            Player target = room.FindPlayer((string)player.GetTag("tianxiang_target"));
            if (room.GetTag("TianxiangDamage") is DamageStruct damage)
            {
                DamageStruct _damage = new DamageStruct(Name, damage.From, target);
                if (ai.IsFriend(target))
                {
                    if (ai.HasSkill("zhaxiang", target) && !ai.WillSkipPlayPhase(target) && target.Hp > 1)
                        return "losehp";

                    return "damage";
                }
                else
                {
                    if (ai.GetDamageScore(_damage).Score > 6 && !ai.CanResist(target, _damage.Damage))
                        return "damage";
                }
            }

            return "losehp";
        }
    }

    public class PoluSJAI : SkillEvent
    {
        public PoluSJAI() : base("polu_sj")
        { }

        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            List<Player> result = new List<Player>();
            ai.SortByDefense(ref targets, false);
            foreach (Player p in targets)
                if (ai.IsFriend(p)) result.Add(p);

            return result;
        }
    }

    public class ZhijianJXAI : SkillEvent
    {
        public ZhijianJXAI() : base("zhijian_jx")
        {
        }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            List<WrappedCard> ids = new List<WrappedCard>();
            foreach (int id in player.GetCards("h"))
            {
                FunctionCard fcard = Engine.GetFunctionCard(ai.Room.GetCard(id).Name);
                if (fcard.Name == CrossBow.ClassName)
                {
                    List<WrappedCard> slashes = ai.GetCards(Slash.ClassName, player, true);
                    if (slashes.Count >= 4)
                    {
                        List<ScoreStruct> scores = ai.CaculateSlashIncome(player, slashes);
                        if (scores.Count > 0 && scores[0].Score > 0)
                            continue;
                    }
                }
                if (fcard is EquipCard)
                {
                    WrappedCard card = new WrappedCard("ZhijianCard") { Skill = Name, ShowSkill = Name };
                    card.AddSubCard(id);
                    ids.Add(card);
                }
            }

            return ids;
        }
        public override double CardValue(TrustedAI ai, Player player, WrappedCard card, bool isUse, Player.Place place)
        {
            if (card.Id >= 0 && ai.HasSkill(Name, player) && !isUse && place == Player.Place.PlaceHand)
            {
                FunctionCard fcard = Engine.GetFunctionCard(ai.Room.GetCard(card.GetEffectiveId()).Name);
                if (fcard is EquipCard)
                    return 1;
            }

            return 0;
        }
    }

    public class HanzhanAI : SkillEvent
    {
        public HanzhanAI() : base("hanzhan")
        {
            key = new List<string> { "skillInvoke:hanzhan" };
        }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.ChoiceMade && data is string str)
            {
                List<string> strs = new List<string>(str.Split(':'));
                if (strs[1] == Name)
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

                    if (target != null)
                    {
                        bool friendly = strs[2] == "no";
                        if (ai.GetPlayerTendency(target) != "unknown")
                            ai.UpdatePlayerRelation(player, target, friendly);
                    }
                }
            }
        }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (data is Player target)
                return !ai.IsFriend(target);

            return true;
        }
    }

    public class ShuangxiongJXAI : SkillEvent
    {
        public ShuangxiongJXAI() : base("shuangxiong_jx")
        {
        }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (ai.GetEnemies(player).Count == 0 || !ai.WillShowForAttack() || ai.WillSkipPlayPhase(player) || player.HandcardNum + player.GetPile("wooden_ox").Count < 3)
                return false;

            return true;
        }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (player.GetMark(Name) > 0)
            {
                Room room = ai.Room;
                List<int> ids = player.GetCards("h");
                ids.AddRange(player.GetHandPile());
                ai.SortByUseValue(ref ids, false);
                foreach (int id in ids)
                {
                    WrappedCard card = room.GetCard(id);
                    if ((player.GetMark(Name) == 1 && WrappedCard.IsBlack(card.Suit)) || (player.GetMark(Name) == 2 && WrappedCard.IsRed(card.Suit)))
                    {
                        WrappedCard duel = new WrappedCard(Duel.ClassName);
                        duel.AddSubCard(card);
                        duel.Skill = Name;
                        duel.ShowSkill = Name;
                        duel = RoomLogic.ParseUseCard(room, duel);
                        return new List<WrappedCard> { duel };
                    }
                }
            }

            return null;
        }

        public override double CardValue(TrustedAI ai, Player player, WrappedCard card, bool isUse, Player.Place place)
        {
            if (card.Id <= 0) return 0;
            if (player.GetMark(Name) == 1)
                return WrappedCard.IsBlack(RoomLogic.GetCardSuit(ai.Room, card)) ? 1 : 0;
            if (player.GetMark(Name) == 2)
                return WrappedCard.IsRed(RoomLogic.GetCardSuit(ai.Room, card)) ? 1 : 0;

            if (ai.HasSkill(Name, player))
                return 0.5;

            return 0;
        }

        public override AskForMoveCardsStruct OnMoveCards(TrustedAI ai, Player player, List<int> ups, List<int> downs, int min, int max)
        {
            AskForMoveCardsStruct result = new AskForMoveCardsStruct
            {
                Top = new List<int>(),
                Bottom = new List<int>(),
                Success = true
            };
            Room room = ai.Room;
            int red = 0, black = 0;
            foreach (int id in player.GetCards("h"))
            {
                WrappedCard card = room.GetCard(id);
                if (WrappedCard.IsBlack(card.Suit))
                    black++;
                else
                    red++;
            }
            List<int> wanted = new List<int>();
            if (red > black)
            {
                foreach (int id in ups)
                {
                    WrappedCard card = room.GetCard(id);
                    if (!WrappedCard.IsBlack(card.Suit))
                        wanted.Add(id);
                }
            }
            else if (red < black)
            {
                foreach (int id in ups)
                {
                    WrappedCard card = room.GetCard(id);
                    if (WrappedCard.IsBlack(card.Suit))
                        wanted.Add(id);
                }
            }

            if (wanted.Count == 0) wanted = new List<int>(ups);
            if (wanted.Count > 1) ai.SortByUseValue(ref wanted);

            result.Bottom.Add(wanted[0]);
            foreach (int id in ups)
                if (!result.Bottom.Contains(id))
                    result.Top.Add(id);

            return result;
        }
    }

    public class GuhuoAI : SkillEvent
    {
        public GuhuoAI() : base("guhuo")
        {
        }

        public override string OnChoice(TrustedAI ai, Player player, string choice, object data)
        {
            if (data is Player yuji && ai.IsEnemy(yuji))
            {
                if (player.HasFlag("guhuo_doubt")) return "doubt";
                string card_name = yuji.GetTag(Name).ToString();
                int count = 0;
                Room room = ai.Room;
                foreach (int id in room.DiscardPile)
                    if (room.GetCard(id).Name == card_name)
                        count++;

                List<int> ids = player.GetCards("h");
                ids.AddRange(player.GetHandPile());
                foreach (int id in ids)
                    if (Engine.GetRealCard(id).Name == card_name)
                        count++;

                if (ai.CardCounts[card_name] == count)
                    return "doubt";
            }

            return "cancel";
        }
    }

    public class JiuchiAI : SkillEvent
    {
        public JiuchiAI() : base("jiuchi")
        { }

        public override double TargetValueAdjust(TrustedAI ai, WrappedCard card, Player from, List<Player> targets, Player to)
        {
            if (card != null && card.Name == Analeptic.ClassName && ai.HasSkill(Name, to))
                return 1;

            return 0;
        }

        public override WrappedCard ViewAs(TrustedAI ai, Player player, int id, bool current, Player.Place place)
        {
            if ((ai.Room.GetCard(id).Suit) == WrappedCard.CardSuit.Spade && place == Player.Place.PlaceHand)
            {
                WrappedCard dismantlement = new WrappedCard(Analeptic.ClassName)
                {
                    Skill = Name,
                    ShowSkill = Name
                };
                dismantlement.AddSubCard(id);
                dismantlement = RoomLogic.ParseUseCard(ai.Room, dismantlement);
                return dismantlement;
            }

            return null;
        }

        public override double CardValue(TrustedAI ai, Player player, WrappedCard card, bool isUse, Player.Place place)
        {
            if (ai.HasSkill(Name, player) && !card.IsVirtualCard() && place != Player.Place.PlaceEquip)
                return RoomLogic.GetCardSuit(ai.Room, card) == WrappedCard.CardSuit.Spade ? 0.5 : 0;

            return 0;
        }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (!ai.WillShowForAttack()) return null;
            Room room = ai.Room;
            List<int> ids = player.GetCards("h");
            ids.AddRange(player.GetHandPile());
            ai.SortByKeepValue(ref ids, false);
            foreach (int id in ids)
            {
                WrappedCard card = room.GetCard(id);
                if (WrappedCard.IsBlack(card.Suit))
                {
                    double keep = ai.GetKeepValue(id, player);
                    if (keep < 0)
                    {
                        WrappedCard dismantlement = new WrappedCard(Analeptic.ClassName)
                        {
                            Skill = Name,
                            ShowSkill = Name
                        };
                        dismantlement.AddSubCard(card);
                        dismantlement = RoomLogic.ParseUseCard(room, dismantlement);
                        return new List<WrappedCard> { dismantlement };
                    }

                    List<WrappedCard> cards = ai.GetViewAsCards(player, id);
                    double value = 0;
                    WrappedCard _card = null;
                    foreach (WrappedCard _c in cards)
                    {
                        double card_value = ai.GetUseValue(_c, player, room.GetCardPlace(id));
                        if (card_value > value)
                        {
                            value = card_value;
                            _card = _c;
                        }
                    }

                    if (_card != null && _card.Name == Analeptic.ClassName && _card.Skill == Name) return new List<WrappedCard> { _card };
                }
            }

            return null;
        }
    }

    public class BaonueAI : SkillEvent
    {
        public BaonueAI() : base("baonue")
        {
            key = new List<string> { "skillInvoke:baonue:yes" };
        }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.ChoiceMade && data is string str && player != ai.Self)
            {
                List<string> strs = new List<string>(str.Split(':'));
                if (strs[1] == Name)
                {
                    Room room = ai.Room;
                    Player target = RoomLogic.FindPlayerBySkillName(room, Name);
                    bool friendly = strs[2] == "yes";
                    if (ai.GetPlayerTendency(target) != "unknown")
                        ai.UpdatePlayerRelation(player, target, friendly);
                }
            }
        }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            Room room = ai.Room;
            Player dz = RoomLogic.FindPlayerBySkillName(room, Name);
            if (ai.IsFriend(dz))
                return true;
            if (player.GetRoleEnum() == Player.PlayerRole.Renegade && !ai.IsEnemy(dz) && dz.Hp == 1)
                return true;

            return false;
        }
    }

    public class HuangtianVSAI : SkillEvent
    {
        public HuangtianVSAI() : base("huangtianvs") { }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            Room room = ai.Room;
            Player lord = RoomLogic.FindPlayerBySkillName(room, "huangtian");
            if (lord != null && ai.IsFriend(lord) && player.Kingdom == "qun" && !player.HasUsed(HuangtianCard.ClassName) && !player.IsKongcheng())
            {
                if (lord.HandcardNum < 4 || ai.IsLackCard(lord, Jink.ClassName) || ai.IsWeak(lord))
                {
                    foreach (int id in player.GetCards("h"))
                    {
                        WrappedCard card = room.GetCard(id);
                        if (card.Name == Jink.ClassName)
                        {
                            WrappedCard ht = new WrappedCard(HuangtianCard.ClassName);
                            ht.AddSubCard(id);

                            return new List<WrappedCard> { ht };
                        }
                    }
                }

                List<int> ids = new List<int>();
                foreach (int id in player.GetCards("h"))
                {
                    WrappedCard card = room.GetCard(id);
                    if (card.Suit == WrappedCard.CardSuit.Spade)
                        ids.Add(id);
                }
                if (ids.Count > 0)
                {
                    KeyValuePair<Player, int> keys = ai.GetCardNeedPlayer(ids, new List<Player> { lord });
                    if (keys.Key != null && ids.Contains(keys.Value))
                    {
                        WrappedCard ht = new WrappedCard(HuangtianCard.ClassName);
                        ht.AddSubCard(keys.Value);
                        return new List<WrappedCard> { ht };
                    }
                }
            }

            return new List<WrappedCard>();
        }
    }

    public class HuangtianCardAI : UseCard
    {
        public HuangtianCardAI() : base(HuangtianCard.ClassName) { }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && ai.Self != player)
            {
                Room room = ai.Room;
                Player lord = RoomLogic.FindPlayerBySkillName(room, "huangtian");
                ai.UpdatePlayerRelation(player, lord, true);
            }
        }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            use.Card = card;
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card)
        {
            return 4;
        }
    }

    public class BeigeJXAI : SkillEvent
    {
        public BeigeJXAI() : base("beige_jx")
        {
            key = new List<string> { "cardDiscard:beige_jx" };
        }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (ai.Self == player) return;
            if (data is string choice)
            {
                string[] choices = choice.Split(':');
                Room room = ai.Room;
                if (choices[1] == Name && room.GetTag("beige_data") is DamageStruct damage)
                {
                    if (ai.GetPlayerTendency(damage.To) != "unknown" && ai.Self != damage.To)
                        ai.UpdatePlayerRelation(player, damage.To, true);
                }
            }
        }

        public override List<int> OnDiscard(TrustedAI ai, Player player, List<int> cards, int min, int max, bool option)
        {
            Room room = ai.Room;
            if (room.GetTag("beige_data") is DamageStruct damage && ai.IsFriend(damage.To) && damage.From != null && damage.From.Alive && !ai.IsFriend(damage.From))
            {
                List<int> ids = new List<int>();
                foreach (int id in player.GetCards("he"))
                    if (RoomLogic.CanDiscard(room, player, player, id))
                        ids.Add(id);

                if (ids.Count > 0)
                {
                    if (room.Current == player)
                        ai.SortByUseValue(ref ids, false);
                    else
                        ai.SortByKeepValue(ref ids, false);

                    int result = -1;
                    if (room.Current == player && ai.GetUseValue(ids[0], player) < 6)
                        result = ids[0];
                    else if (room.Current != player && ai.GetKeepValue(ids[0], player) < 6)
                        result = ids[0];

                    if (result >= 0)
                        return new List<int> { ids[0] };
                }
            }

            return new List<int>();
        }
    }

    public class QiangxiJXAI : SkillEvent
    {
        public QiangxiJXAI() : base("qiangxi_jx")
        {
        }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            List<WrappedCard> result = new List<WrappedCard>();
            if (player.UsedTimes(QiangxiJXCard.ClassName) < 2)
            {
                WrappedCard card = new WrappedCard(QiangxiJXCard.ClassName)
                {
                    Skill = Name,
                    ShowSkill = Name
                };
                result.Add(card);
            }
            return result;
        }
    }

    public class QiangxiJXCardAI : UseCard
    {
        public QiangxiJXCardAI() : base(QiangxiJXCard.ClassName)
        {
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card)
        {
            return player.GetWeapon() ? 3 : 0;
        }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (ai.Self == player) return;
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                foreach (Player p in use.To)
                    ai.UpdatePlayerRelation(player, p, false);
            }
        }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            Room room = ai.Room;
            List<Player> enemies = ai.GetEnemies(player);
            ai.SortByDefense(ref enemies, false);


            List<int> weapons = new List<int>();
            bool peach = false;
            foreach (int id in player.GetCards("he"))
            {
                WrappedCard _card = room.GetCard(id);
                FunctionCard fcard = Engine.GetFunctionCard(_card.Name);
                if (fcard is Weapon) weapons.Add(id);
                if (!peach && (player.Hp == 1 && fcard is Analeptic || fcard is Peach)) peach = true;
            }

            List<ScoreStruct> scores = new List<ScoreStruct>();
            foreach (Player enemy in enemies)
            {
                if (player.HasFlag(string.Format("qiangxi-{0}", enemy.Name))) continue;
                if (ai.PlayersLevel[enemy] > 3)
                {
                    DamageStruct damage = new DamageStruct("qiangxi_jx", player, enemy);
                    ScoreStruct score = ai.GetDamageScore(damage);
                    score.Players = new List<Player> { enemy };
                    scores.Add(score);
                }
            }
            if (scores.Count > 0)
            {
                scores.Sort((x, y) => { return x.Score > y.Score ? -1 : 1; });
                if (scores[0].Score >= 3 && (weapons.Count > 0 || player.Hp > 1 || peach))
                {
                    use.Card = card;
                    use.To = scores[0].Players;
                    if (weapons.Count > 0)
                    {
                        ai.SortByKeepValue(ref weapons);
                        use.Card.AddSubCard(weapons[0]);
                    }
                }
            }
        }
    }

    public class WeimuJXAI : SkillEvent
    {
        public WeimuJXAI() : base("weimu_jx") { }
        public override void DamageEffect(TrustedAI ai, ref DamageStruct damage, DamageStruct.DamageStep step)
        {
            if (damage.To != null && damage.To.Phase != Player.PlayerPhase.NotActive && RoomLogic.PlayerHasSkill(ai.Room, damage.To, Name))
                damage.Damage = 0;
        }

        public override ScoreStruct GetDamageScore(TrustedAI ai, DamageStruct damage)
        {
            ScoreStruct score = new ScoreStruct();
            if (damage.To != null && damage.To.Phase != Player.PlayerPhase.NotActive && RoomLogic.PlayerHasSkill(ai.Room, damage.To, Name))
                score.Score = damage.Damage * 2 * 2;
            return score;
        }
    }

    public class LuanwuJXAI : SkillEvent
    {
        public LuanwuJXAI() : base("luanwu_jx")
        {
        }

        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (ai.WillShowForAttack() && player.GetMark("@chaos") > 0)
            {
                Room room = ai.Room;
                double good = 0, bad = 0;
                if (RoomLogic.PlayerHasShownSkill(room, player, "baoling"))
                    good += 0.8;
                foreach (Player p in room.GetOtherPlayers(player))
                {
                    if (!p.Removed && ai.IsWeak(p))
                    {
                        if (ai.IsFriend(p)) bad += 1.5;
                        else if (p.HasShownOneGeneral()) good += 0.8;
                        else good += 0.4;
                    }
                }

                if (good < ((double)room.AliveCount() / 4)) return null;

                foreach (Player p in room.GetOtherPlayers(player))
                {
                    if (p.Removed) continue;

                    int hp = Math.Max(p.Hp, 1);
                    if (ai.GetKnownCardsNums(Analeptic.ClassName, "he", p, player) > 0)
                    {
                        if (ai.IsFriend(p))
                            good += 1 / hp;
                        else
                            bad += 1 / hp;
                    }
                    bool slash = ai.GetKnownCardsNums(Slash.ClassName, "he", p, player) > 0;
                    bool can_slash = false;
                    foreach (Player _p in room.GetOtherPlayers(p))
                    {
                        if (RoomLogic.InMyAttackRange(room, p, _p))
                        {
                            can_slash = true;
                            break;
                        }
                    }

                    if (!slash || !can_slash)
                    {
                        if (ai.IsFriend(p))
                            good += Math.Max(ai.GetKnownCardsNums(Peach.ClassName, "he", p, player), 1);
                        else
                            bad += Math.Max(ai.GetKnownCardsNums(Peach.ClassName, "he", p, player), 1);
                    }

                    if (ai.GetKnownCardsNums(Jink.ClassName, "he", p, player) > 0)
                    {
                        double lost_value = 0;
                        if (ai.HasSkill(TrustedAI.MasochismSkill, p))
                            lost_value = p.Hp / 2;
                        hp = Math.Max(p.Hp, 1);
                        if (ai.IsFriend(p))
                            bad += (lost_value + 1) / hp;
                        else
                            good += (lost_value + 1) / hp;

                    }
                }

                if (good > bad)
                    return new List<WrappedCard> { new WrappedCard(LuanwuJXCard.ClassName) { Skill = Name, ShowSkill = Name, Mute = true } };
            }

            return null;
        }
        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct(null, player, new List<Player>());
            Room room = ai.Room;
            List<Player> targets = new List<Player>();
            foreach (Player p in room.GetOtherPlayers(player))
                if (p.HasFlag("SlashAssignee"))
                    targets.Add(p);

            if (targets.Count > 0)
            {
                List<ScoreStruct> scores = ai.CaculateSlashIncome(player, null, targets);
                if (scores.Count > 0 && scores[0].Score > -2 && scores[0].Card != null)
                {
                    use.Card = scores[0].Card;
                    use.To = scores[0].Players;
                }
            }

            return use;
        }

        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = "_luanwu_jx", DistanceLimited = false };
            List<ScoreStruct> scores = ai.CaculateSlashIncome(player, new List<WrappedCard> { slash }, targets, false);
            if (scores.Count > 0)
            {
                scores.Sort((x, y) => { return x.Score > y.Score ? -1 : 1; });
                if (scores[0].Score > 0) return scores[0].Players;
            }
            return new List<Player>();
        }
    }

    public class LuanwuJXCardAI : UseCard
    {
        public LuanwuJXCardAI() : base(LuanwuJXCard.ClassName)
        { }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            use.Card = card;
        }
    }

    public class TuntianJXAI : SkillEvent
    {
        public TuntianJXAI() : base("tuntian_jx")
        { }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            return true;
        }
    }

    public class ShensuJXAI : SkillEvent
    {
        public ShensuJXAI() : base("shensu_jx")
        {
        }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct(null, player, new List<Player>());
            Room room = ai.Room;

            if (prompt.EndsWith("1"))
            {
                if (!ai.WillShowForAttack()) return use;
                if (RoomLogic.PlayerContainsTrick(room, player, Lightning.ClassName) && player.JudgingArea.Count == 1)
                {
                    Player wizzard = ai.GetWizzardRaceWinner(Lightning.ClassName, player);
                    if (wizzard == null || !ai.IsEnemy(wizzard))
                        return use;
                }
                if (!RoomLogic.PlayerContainsTrick(room, player, Indulgence.ClassName) && !RoomLogic.PlayerContainsTrick(room, player, SupplyShortage.ClassName))
                {
                    if (player.HasTreasure(JadeSeal.ClassName) || player.GetPile("yijipile").Count > 0) return use;
                }

                WrappedCard slash = new WrappedCard(Slash.ClassName)
                {
                    Skill = "_shensu_jx",
                    DistanceLimited = false
                };
                List<WrappedCard> cards = new List<WrappedCard> { slash };
                List<ScoreStruct> scores = ai.CaculateSlashIncome(player, cards, null, false);
                if (scores.Count > 0)
                {
                    foreach (Player p in scores[0].Players)
                    {
                        if (ai.IsEnemy(p) && scores[0].Score > 4)
                        {
                            if (p.Hp <= 1 && (!RoomLogic.InMyAttackRange(room, player, p) || ai.GetCards(Slash.ClassName, player).Count == 0 || RoomLogic.PlayerContainsTrick(room, player, Indulgence.ClassName)))
                            {
                                use.Card = new WrappedCard(ShensuCard.ClassName) { Skill = Name };
                                use.To = scores[0].Players;
                                return use;
                            }
                        }
                    }
                }
                bool Nullification = false;
                foreach (Player p in ai.GetFriends(player))
                {
                    if (ai.GetKnownCardsNums("Nullification", "he", p) > 0)
                    {
                        Nullification = true;
                        break;
                    }
                }

                if (RoomLogic.PlayerContainsTrick(room, player, Indulgence.ClassName))
                {
                    Player wizzard = ai.GetWizzardRaceWinner(Indulgence.ClassName, player);
                    if (!Nullification && (wizzard == null || ai.IsEnemy(wizzard)))
                    {
                        if (scores.Count > 0 && scores[0].Score > 3)
                        {
                            use.Card = new WrappedCard(ShensuCard.ClassName) { Skill = Name };
                            use.To = scores[0].Players;
                            return use;
                        }
                        else
                        {
                            double value = 0;
                            foreach (int id in player.GetCards("h"))
                                value += ai.GetUseValue(id, player);

                            foreach (int id in player.GetHandPile())
                                value += ai.GetUseValue(id, player);

                            if (value > 16 || ai.GetOverflow(player) > 0)
                            {
                                if (scores.Count > 0 && scores[0].Score > 0)
                                {
                                    use.Card = new WrappedCard(ShensuCard.ClassName) { Skill = Name };
                                    use.To = scores[0].Players;
                                    return use;
                                }
                                else
                                {
                                    FunctionCard fcard = Slash.Instance;
                                    foreach (Player p in room.GetOtherPlayers(player))
                                    {
                                        if (fcard.TargetFilter(room, new List<Player>(), p, player, slash)
                                            && (!ai.IsFriend(p) || ai.IsCancelTarget(slash, p, player) || !ai.IsCardEffect(slash, p, player)))
                                        {
                                            use.Card = new WrappedCard(ShensuCard.ClassName) { Skill = Name };
                                            use.To.Add(p);
                                            return use;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (prompt.EndsWith("2"))
            {
                if (!ai.WillShowForAttack()) return use;
                double value = 0;
                List<WrappedCard> cards = ai.GetCards(Slash.ClassName, player, true);
                List<ScoreStruct> scores = ai.CaculateSlashIncome(player, cards, null, false);
                if (scores.Count > 0 && scores[0].Score > 0)
                {
                    if (ai.GetCards(CrossBow.ClassName, player).Count > 0 && cards.Count > 0)
                        return use;
                    value = scores[0].Score;
                }

                List<WrappedCard> slashes = new List<WrappedCard>();
                foreach (int id in player.GetCards("he"))
                {
                    FunctionCard fcard = Engine.GetFunctionCard(room.GetCard(id).Name);
                    if (fcard is EquipCard && RoomLogic.CanDiscard(room, player, player, id))
                    {
                        WrappedCard slash = new WrappedCard(Slash.ClassName)
                        {
                            Skill = "_shensu_jx",
                            DistanceLimited = false,
                        };
                        slash.AddSubCard(id);
                    }
                }
                if (slashes.Count > 0)
                {
                    scores.Clear();
                    scores = ai.CaculateSlashIncome(player, slashes, null, false);
                    if (scores.Count > 0)
                    {
                        for (int i = 0; i < scores.Count; i++)
                        {
                            ScoreStruct score = scores[i];
                            WrappedCard equip = room.GetCard(score.Card.SubCards[0]);
                            if (equip.Name == SilverLion.ClassName && player.HasArmor(equip.Name) && player.IsWounded())
                                score.Score += 2.5;
                            else if (player.HasEquip(equip.Name) || ai.GetSameEquip(equip, player) == null)
                                score.Score -= 2;
                        }

                        ai.CompareByScore(ref scores);
                        if (scores[0].Score > value && scores[0].Score > 4)
                        {
                            use.Card = new WrappedCard(ShensuCard.ClassName) { Skill = Name };
                            use.Card.AddSubCards(scores[0].Card.SubCards);
                            use.To = scores[0].Players;
                            return use;
                        }
                    }
                }
            }
            else if (prompt.EndsWith("3"))
            {
                List<WrappedCard> slashes = new List<WrappedCard>();
                WrappedCard slash = new WrappedCard(Slash.ClassName)
                {
                    Skill = "_shensu_jx",
                    DistanceLimited = false
                };
                slashes.Add(slash);

                if (slashes.Count > 0)
                {
                    List<ScoreStruct> scores = ai.CaculateSlashIncome(player, slashes, null, false);
                    if (scores.Count > 0 && scores[0].Score >= 0)
                    {
                        double value = 0;
                        List<int> ids = player.GetCards("he");
                        int over = ai.GetOverflow(player);
                        if (over > 0)
                        {
                            List<double> values = ai.SortByKeepValue(ref ids, false);
                            for (int i = 0; i < over; i++)
                                value += values[0];
                        }
                        value += scores[0].Score;
                        if (value >= 8)
                        {
                            use.Card = new WrappedCard(ShensuCard.ClassName) { Skill = Name };
                            use.To = scores[0].Players;
                            return use;
                        }
                    }
                }
            }

            return use;
        }
    }

    public class ShebianAI : SkillEvent
    {
        public ShebianAI() : base("shebian") { }

        public static KeyValuePair<int, Player> CardForQiaobian(TrustedAI ai, Player who)
        {
            int result_id = -1;
            Player player = ai.Self;
            Room room = ai.Room;
            if (ai.IsFriend(who))
            {
                if (ai.HasSkill(TrustedAI.LoseEquipSkill, who, true) && who.HasEquip())
                {
                    List<int> equips = player.GetEquips();
                    if (who.GetArmor() && ai.GetKeepValue(who.Armor.Key, who) < 0)
                        result_id = who.Armor.Key;
                    if (result_id < 0 && who.GetSpecialEquip())
                        result_id = who.Special.Key;
                    if (result_id < 0 && who.GetOffensiveHorse())
                        result_id = who.OffensiveHorse.Key;
                    if (result_id < 0 && who.GetDefensiveHorse() && !ai.IsWeak(who))
                        result_id = who.DefensiveHorse.Key;
                    if (result_id < 0 && who.GetArmor() && !ai.IsWeak(who))
                        result_id = who.Armor.Key;

                    if (result_id >= 0)
                    {
                        WrappedCard equip = room.GetCard(result_id);
                        foreach (Player p in room.GetOtherPlayers(who))
                        {
                            if (ai.GetSameEquip(equip, p) == null && (ai.HasSkill(TrustedAI.NeedEquipSkill, who) || ai.HasSkill(TrustedAI.LoseEquipSkill, who))
                                && RoomLogic.CanPutEquip(p, equip))
                                return new KeyValuePair<int, Player>(result_id, p);
                        }
                        List<Player> friends = ai.GetFriends(player);
                        ai.SortByDefense(ref friends, false);
                        foreach (Player p in room.GetOtherPlayers(who))
                        {
                            if (p != who && ai.GetSameEquip(equip, p) == null && RoomLogic.CanPutEquip(p, equip))
                                return new KeyValuePair<int, Player>(result_id, p);
                        }
                    }
                }
            }
            else
            {
                if (!who.HasEquip() || (ai.HasSkill(TrustedAI.LoseEquipSkill, who) && !who.GetTreasure())) return new KeyValuePair<int, Player>(-1, null);

                int id = ai.AskForCardChosen(who, "e", Snatch.ClassName, FunctionCard.HandlingMethod.MethodNone, new List<int>());
                if (id >= 0 && who.GetEquips().Contains(id))
                {
                    List<Player> friends = ai.GetFriends(player);
                    result_id = id;
                    WrappedCard card = room.GetCard(id);
                    FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                    if (fcard is Armor || fcard is DefensiveHorse)
                    {
                        ai.SortByDefense(ref friends, false);
                        foreach (Player p in friends)
                        {
                            if (ai.GetSameEquip(card, p) == null && (ai.HasSkill(TrustedAI.LoseEquipSkill, p) || ai.HasSkill(TrustedAI.NeedEquipSkill, p)))
                                return new KeyValuePair<int, Player>(result_id, p);
                        }

                        foreach (Player p in friends)
                        {
                            if (ai.GetSameEquip(card, p) == null)
                                return new KeyValuePair<int, Player>(result_id, p);
                        }
                    }
                    else if (fcard is Treasure || fcard is Weapon)
                    {
                        foreach (Player p in friends)
                        {
                            if (ai.GetSameEquip(card, p) == null && (ai.HasSkill(TrustedAI.LoseEquipSkill, p) || ai.HasSkill(TrustedAI.NeedEquipSkill, p)))
                                return new KeyValuePair<int, Player>(result_id, p);
                        }

                        foreach (Player p in friends)
                        {
                            if (ai.GetSameEquip(card, p) == null)
                                return new KeyValuePair<int, Player>(result_id, p);
                        }
                    }
                }
            }

            return new KeyValuePair<int, Player>(-1, null);
        }
        public override List<int> OnCardsChosen(TrustedAI ai, Player from, Player to, string flags, int min, int max, List<int> disable_ids)
        {
            List<int> result = new List<int>();
            if (flags == "e")
            {
                int id = CardForQiaobian(ai, to).Key;
                if (id >= 0)
                    result.Add(id);
            }

            return null;
        }

        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> target, int min, int max)
        {
            List<Player> result = new List<Player>();
            if (ai.Room.GetTag("MouduanTarget") != null && ai.Room.GetTag("MouduanTarget") is Player from)
            {
                Player to = CardForQiaobian(ai, from).Value;
                if (to != null)
                    result.Add(to);
                else
                    ai.Room.Debug("AI出错");
            }
            else
            {
                foreach (Player friend in ai.FriendNoSelf)
                {
                    if (friend.HasEquip() && ai.HasSkill(TrustedAI.LoseEquipSkill, friend) && CardForQiaobian(ai, friend).Key >= 0)
                    {
                        return new List<Player> { friend };
                    }
                }

                List<Player> enemies = ai.GetEnemies(player);
                ai.SortByDefense(ref enemies, false);
                foreach (Player p in enemies)
                {
                    if (QiaobianAI.CardForQiaobian(ai, p).Key >= 0)
                    {
                        return new List<Player> { p };
                    }
                }
            }

            return result;
        }
    }

    public class QiaobianJXAI : SkillEvent
    {
        public QiaobianJXAI() : base("qiaobian_jx")
        {
            key = new List<string> { "stageCard:qiaobian_jx" };
        }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (data is string choice)
            {
                string[] choices = choice.Split(':');
                if (choices[1] == Name)
                {
                    Room room = ai.Room;
                    int id = int.Parse(choices[2]);
                    Player target = room.FindPlayer(choices[3]);

                    if (player != target)
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

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            ai.Number[Name] = -1;
            ai.Number["qiaobian3"] = -1;
            ai.Target["qiaobian3"] = null;

            List<int> cards = player.GetCards("he");
            List<double> values = ai.SortByKeepValue(ref cards, false);
            Room room = ai.Room;
            Player stealer = null;

            foreach (Player ap in room.GetOtherPlayers(player))
            {
                if (ai.HasSkill("tuxi|tuxi_jx", ap) && ai.IsEnemy(ap))
                {
                    stealer = ap;
                    break;
                }
            }
            int card = -1;
            for (int i = 0; i < cards.Count; i++)
            {
                if (ai.IsCard(cards[i], Peach.ClassName, player))
                {
                    if (stealer != null && player.HandcardNum <= 2 && player.Hp > 2 && !RoomLogic.PlayerContainsTrick(room, stealer, SupplyShortage.ClassName))
                    {
                        card = cards[i];
                        break;
                    }
                    bool to_discard_peach = true;
                    foreach (Player fd in ai.GetFriends(player))
                    {
                        if (fd.Hp <= 2 && (!ai.HasSkill("niepan", fd) || fd.GetMark("@nirvana") == 0))
                        {
                            to_discard_peach = false;
                            break;
                        }
                    }
                    if (to_discard_peach)
                    {
                        card = cards[i];
                        break;
                    }
                }
                else
                {
                    card = cards[i];
                    break;
                }
            }

            if ((card == -1 || values.Count == 0) && player.GetMark(Name) == 0)
                return false;

            ai.Number[Name] = card;
            if ((values.Count == 0 || values[0] > 3) && player.GetMark(Name) > 0)
                ai.Number[Name] = -1;
            
            Player.PlayerPhase phase = (Player.PlayerPhase)player.GetMark("qiaobianPhase");

            if (phase == Player.PlayerPhase.Judge && !player.IsSkipped(Player.PlayerPhase.Judge))
            {
                if (RoomLogic.PlayerContainsTrick(room, player, Lightning.ClassName))
                {
                    Player wizzard = ai.GetWizzardRaceWinner(Lightning.ClassName, player);
                    if ((wizzard != null && ai.IsEnemy(wizzard)) || ai.GetFriends(player).Count > ai.GetEnemies(player).Count)
                        return true;
                }
                else if (RoomLogic.PlayerContainsTrick(room, player, SupplyShortage.ClassName))
                {
                    if (player.Hp > player.HandcardNum) return true;
                    List<Player> targets = TuxiAI.FindTuxiTargets(ai, player);
                    if (targets.Count == 2) return true;
                }
                else if (RoomLogic.PlayerContainsTrick(room, player, Indulgence.ClassName))
                {
                    if (player.HandcardNum > 3 || player.HandcardNum > player.Hp - 1) return true;
                    foreach (Player friend in ai.FriendNoSelf)
                        if (RoomLogic.PlayerContainsTrick(room, player, Indulgence.ClassName) || RoomLogic.PlayerContainsTrick(room, player, SupplyShortage.ClassName))
                            return true;
                }
            }
            else if (phase == Player.PlayerPhase.Draw && !player.IsSkipped(Player.PlayerPhase.Draw) && !ai.HasSkill("tuxi|tuxi_jx"))
            {
                ai.Target["qiaobian1"] = null;
                ai.Target["qiaobian2"] = null;

                if (player.HasFlag("jieyue_draw") || player.HasTreasure(JadeSeal.ClassName) || player.GetMark("@tangerine") > 0)
                    return false;
                List<Player> targets = TuxiAI.FindTuxiTargets(ai, player);
                if (targets.Count == 2)
                {
                    ai.Target["qiaobian1"] = targets[0];
                    ai.Target["qiaobian2"] = targets[1];
                    return true;
                }
            }
            else if (phase == Player.PlayerPhase.Play && !player.IsSkipped(Player.PlayerPhase.Play))
            {
                foreach (Player friend in ai.GetFriends(player))
                {
                    if (friend.JudgingArea.Count > 0)
                    {
                        int id = QiaobianAI.CardForQiaobian(ai, friend).Key;
                        if (id >= 0)
                        {
                            ai.Number["qiaobian3"] = id;
                            ai.Target["qiaobian3"] = friend;
                            return true;
                        }
                    }
                }

                foreach (Player friend in ai.FriendNoSelf)
                {
                    if (friend.HasEquip() && ai.HasSkill(TrustedAI.LoseEquipSkill, friend))
                    {
                        int id = QiaobianAI.CardForQiaobian(ai, friend).Key;
                        if (id >= 0)
                        {
                            ai.Number["qiaobian3"] = id;
                            ai.Target["qiaobian3"] = friend;
                            return true;
                        }
                    }
                }

                cards = player.GetCards("h");
                ai.SortByKeepValue(ref cards, false);
                //to_discard = new List<int>(cards[0]);
                double top_value = 0;
                foreach (int id in cards)
                {
                    if (!ai.IsCard(id, Jink.ClassName, player))
                    {
                        double value = ai.GetUseValue(id, player);
                        if (value > top_value)
                            top_value = value;
                    }
                }

                if (top_value >= 3.7 && ai.GetTurnUse().Count > 0) return false;
                foreach (Player p in ai.GetEnemies(player))
                {
                    int id = QiaobianAI.CardForQiaobian(ai, p).Key;
                    if (id > 0)
                    {
                        ai.Number["qiaobian3"] = id;
                        ai.Target["qiaobian3"] = p;
                        return true;
                    }
                }
            }
            else if (phase == Player.PlayerPhase.Discard && !player.IsSkipped(Player.PlayerPhase.Discard) && player.HandcardNum > RoomLogic.GetMaxCards(room, player) + 1)
            {
                player.SetFlags("AI_ConsideringQiaobianSkipDiscard");
                return true;
            }

            return false;
        }

        public override List<int> OnDiscard(TrustedAI ai, Player player, List<int> ids, int min, int max, bool option)
        {
            int id = (int)ai.Number[Name];
            if (id >= 0) return new List<int> { id };
            return new List<int>();
        }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            Player.PlayerPhase phase = (Player.PlayerPhase)player.GetMark("qiaobianPhase");
            CardUseStruct use = new CardUseStruct { From = player, Card = new WrappedCard(QiaobianCard.ClassName) { Mute = true, Skill = Name }, To = new List<Player>() };
            if (prompt == "@qiaobian-2" && ai.Target["qiaobian1"] != null && ai.Target["qiaobian2"] != null)
            {
                use.To.Add(ai.Target["qiaobian1"]);
                use.To.Add(ai.Target["qiaobian2"]);
                return use;
            }
            else
            {
                if (ai.Number["qiaobian3"] >= 0 && ai.Target["qiaobian3"] != null)
                {
                    Player to = QiaobianAI.CardForQiaobian(ai, ai.Target["qiaobian3"]).Value;
                    if (to != null)
                    {
                        use.To.Add(ai.Target["qiaobian3"]);
                        use.To.Add(to);
                        return use;
                    }
                }
            }

            return new CardUseStruct();
        }
        public override int OnMoveStargeCard(TrustedAI ai, Player player, Player target1, Player target2, List<int> available) => ai.Number["qiaobian3"] >= 0 ? (int)ai.Number["qiaobian3"] : -1;
    }



    public class HaoshiClassicAI : SkillEvent
    {
        public HaoshiClassicAI() : base("haoshi_classic")
        {
        }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            Room room = ai.Room;
            int draw = (int)data;
            int count = player.HandcardNum + draw + 2;
            if (player.HasTreasure(JadeSeal.ClassName))
                count++;
            if (player.GetMark("@tangerine") > 0) count++;
            if (player.GetMark("duliang") > 0) count++;
            if (player.GetMark("@rob") > 0) count++;
            if (ai.HasSkill("dujin")) count += player.GetEquips().Count / 2 + 1;

            if (count > 5)
            {
                int least = 1000;
                foreach (Player p in room.GetOtherPlayers(player))
                    least = Math.Min(p.HandcardNum, least);


                foreach (Player p in room.GetOtherPlayers(player))
                    if (p.HandcardNum == least && ai.IsFriend(p))
                        return true;

                return false;
            }
            else
                return true;
        }

        public override List<int> OnExchange(TrustedAI ai, Player player, string pattern, int min, int max, string pile)
        {
            Room room = ai.Room;
            if (room.GetTag(Name) is Player target && ai.IsFriend(target))
            {
                KeyValuePair<Player, int> pair = ai.GetCardNeedPlayer(player.GetCards("h"), new List<Player> { target }, Player.Place.PlaceHand);
                if (pair.Key != null && pair.Value >= 0)
                    return new List<int> { pair.Value };
            }

            return new List<int>();
        }

        public override CardUseStruct OnResponding(TrustedAI ai, Player player, string pattern, string prompt, object data)
        {
            CardUseStruct use = new CardUseStruct
            {
                From = player,
                To = new List<Player>()
            };

            Room room = ai.Room;
            int least = 1000;
            foreach (Player p in room.GetOtherPlayers(player))
                least = Math.Min(p.HandcardNum, least);

            List<Player> targets = new List<Player>();
            foreach (Player p in ai.FriendNoSelf)
                if (p.HandcardNum == least)
                    targets.Add(p);

            if (targets.Count > 0)
            {
                ai.SortByDefense(ref targets, false);
                use.Card = new WrappedCard(HaoshiCard.ClassName)
                {
                    Skill = "_haoshi_classic",
                    Mute = true
                };
                List<int> ids = player.GetCards("h");
                ai.SortByUseValue(ref ids, false);
                for (int i = 0; i < player.HandcardNum / 2; i++)
                    use.Card.AddSubCard(ids[i]);

                use.To.Add(targets[0]);
            }

            return use;
        }
    }

    public class HaoshiCCardAI : UseCard
    {
        public HaoshiCCardAI() : base(HaoshiCCard.ClassName)
        {
        }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                Player target = use.To[0];
                if (ai is StupidAI && ai.GetPlayerTendency(target) != "unknown")
                    ai.UpdatePlayerRelation(player, target, true);
            }
        }
    }
    public class DimengClassicAI : SkillEvent
    {
        public DimengClassicAI() : base("dimeng_classic")
        { }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (ai.FriendNoSelf.Count > 0 && !player.HasUsed(DimengCCard.ClassName))
                return new List<WrappedCard> { new WrappedCard(DimengCCard.ClassName) { Skill = Name, ShowSkill = Name } };

            return null;
        }
    }

    public class DimengCCardAI : UseCard
    {
        public DimengCCardAI() : base(DimengCCard.ClassName)
        { }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                Player target1 = use.To[0];
                Player target2 = use.To[1];
                Player target = null;
                Player enemy = null;
                if (ai.HasSkill("zishu", target1)) enemy = target1;
                if (ai.HasSkill("zishu", target2)) enemy = target2;
                if (target1.HandcardNum > target2.HandcardNum)
                {
                    if (enemy != target2)
                        target = target2;
                    if (enemy == null) enemy = target1;
                }
                else if (target2.HandcardNum > target1.HandcardNum)
                {
                    if (enemy != target1)
                        target = target1;
                    if (enemy == null) enemy = target2;
                }

                if (ai is StupidAI && target != null && ai.GetPlayerTendency(target) != "unknown")
                {
                    ai.UpdatePlayerRelation(player, target, true);
                    if (enemy != null) ai.UpdatePlayerRelation(player, enemy, false);
                }
            }
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card)
        {
            return 2.8;
        }
        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            Room room = ai.Room;
            List<Player> targets = new List<Player>();
            double best = 0;
            List<Player> enemies = ai.GetEnemies(player);
            int hands = player.GetCardCount(true);
            foreach (Player enemy in enemies)
            {
                foreach (Player friend in ai.FriendNoSelf)
                {
                    if (ai.HasSkill("zishu", friend)) continue;
                    int count = enemy.HandcardNum - friend.HandcardNum;
                    if (count >= 0)
                    {
                        double good = count * 2;
                        if (ai.HasSkill("lianying", enemy))
                            good -= 1.5 * Math.Min(enemy.HandcardNum, enemies.Count);
                        if (ai.HasSkill("diancai_classic", enemy))
                            good -= 1.5 * Math.Min(enemy.HandcardNum, enemies.Count);

                        if (ai.HasSkill("lianying", friend))
                            good += 1.5 * Math.Min(friend.HandcardNum, ai.GetFriends(player).Count);
                        if (ai.HasSkill("diancai_classic", friend))
                            good += 1.5 * Math.Min(friend.HandcardNum, ai.GetFriends(player).Count);
                        if (ai.HasSkill("zishu", enemy)) good += 1.5 * friend.HandcardNum;

                        if (hands >= count)
                        {
                            double v = good;
                            if (v > best)
                            {
                                best = v;
                                targets = new List<Player> { enemy, friend };
                            }
                        }
                    }
                }
            }

            foreach (Player friend in ai.FriendNoSelf)
            {
                if (ai.HasSkill("lianying", friend) || ai.HasSkill("diancai_classic", friend))
                {
                    foreach (Player p in room.GetOtherPlayers(player))
                    {
                        if (friend == p) continue;
                        int count = Math.Abs(p.HandcardNum - friend.HandcardNum);
                        double good = 1.5 * Math.Min(friend.HandcardNum, ai.GetFriends(player).Count);
                        if (!ai.IsFriend(p)) good -= (friend.HandcardNum - p.HandcardNum) * 1.5;

                        if (hands >= count)
                        {
                            double v = good;
                            if (v > best)
                            {
                                best = v;
                                targets = new List<Player> { p, friend };
                            }
                        }
                    }
                }
            }

            if (targets.Count > 0)
            {
                use.Card = card;
                use.To = targets;
            }
        }
    }

    public class SongweiAI : SkillEvent
    {
        public SongweiAI() : base("songwei")
        {
            key = new List<string> { "skillInvoke:songwei" };
        }

        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.ChoiceMade && data is string str && ai.Self != player)
            {
                Room room = ai.Room;
                List<string> strs = new List<string>(str.Split(':'));
                if (strs[1] == Name)
                {
                    Player target = null;
                    foreach (Player p in room.GetOtherPlayers(player))
                    {
                        if (p.HasFlag("songwei_target"))
                        {
                            target = p;
                            break;
                        }
                    }
                    if (ai.GetPlayerTendency(target) != "unknown") ai.UpdatePlayerRelation(player, target, strs[2] == "yes");
                }
            }
        }

        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (data is Player target && ai.IsFriend(target))
                return true;
            return false;
        }
    }
}