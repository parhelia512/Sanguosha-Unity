using CommonClass;
using CommonClass.Game;
using CommonClassLibrary;
using SanguoshaServer.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static CommonClass.Game.CardUseStruct;
using static CommonClass.Game.Player;
using static SanguoshaServer.Package.FunctionCard;

namespace SanguoshaServer.Package
{
    public class Strategy : GeneralPackage
    {
        public Strategy() : base("Strategy")
        {
            skills = new List<Skill>
            {


                new Qiao(),
                new Chengshang(),
                new JianliangHegemony(),
                new WeimengHegemony(),
                new WeimengStrategy(),

                new Zhente(),
                new Zhiwei(),

                new KuangcaiHegemony(),
                new KuangcaiHegemonyMax(),
                new KuangcaiHegemonyTar(),
                new ShejianHegemony(),
            };

            skill_cards = new List<FunctionCard>
            {
                new WeimengHCard(),
                new WeimengSCard(),
            };

            related_skills = new Dictionary<string, List<string>>
            {
                { "kuangcai_hegemony", new List<string> { "#kuangcai_hegemony", "#kuangcai_hegemony-max" } },
            };
        }
    }



    //zongyu
    public class Qiao : TriggerSkill
    {
        public Qiao() : base("qiao")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging, TriggerEvent.TargetConfirmed };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                foreach (Player p in room.GetAlivePlayers())
                    if (p.GetMark(Name) > 0) p.SetMark(Name, 0);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TargetConfirmed && base.Triggerable(player, room) && data is CardUseStruct use && use.From != null && use.From != player && use.From.Alive
                && !RoomLogic.WillBeFriendWith(room, player, use.From) && !use.From.IsAllNude() && RoomLogic.CanDiscard(room, player, use.From, "he") && player.GetMark(Name) < 2)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (!(fcard is SkillCard))
                    return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use && room.AskForSkillInvoke(player, Name, use.From, info.SkillPosition))
            {
                player.AddMark(Name);
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, use.From.Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                List<int> ids = new List<int> { room.AskForCardChosen(player, use.From, "he", Name, false, HandlingMethod.MethodDiscard) };
                room.ThrowCard(ref ids,
                    new CardMoveReason(MoveReason.S_REASON_DISMANTLE, player.Name, use.From.Name, Name, string.Empty) { General = RoomLogic.GetGeneralSkin(room, player, Name, info.SkillPosition) }
                    , use.From, player);
                if (player.Alive && !player.IsNude() && RoomLogic.CanDiscard(room, player, player, "he"))
                    room.AskForDiscard(player, Name, 1, 1, false, true, "@qiao", false, info.SkillPosition);
            }

            return false;
        }
    }

    public class Chengshang : TriggerSkill
    {
        public Chengshang() : base("chengshang")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardFinished, TriggerEvent.Damage };
            skill_type = SkillType.Replenish;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Damage && data is DamageStruct damage && player.Phase == PlayerPhase.Play && base.Triggerable(player, room)
                && !player.HasFlag(Name) && damage.Card != null && damage.Card.Suit != WrappedCard.CardSuit.NoSuit && damage.Card.Number != 0)
                damage.Card.SetFlags(Name);
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is CardUseStruct use && use.Card.Suit != WrappedCard.CardSuit.NoSuit && use.Card.Number != 0 && !player.HasFlag(Name)
                && player.Phase == PlayerPhase.Play && !use.Card.HasFlag(Name))
            {
                bool diff = false;
                foreach (Player p in use.To)
                {
                    if (!RoomLogic.WillBeFriendWith(room, player, p))
                    {
                        diff = true;
                        break;
                    }
                }
                if (diff)
                {
                    foreach (int id in room.DrawPile)
                    {
                        WrappedCard card = room.GetCard(id);
                        if (card.Suit == use.Card.Suit && card.Number == use.Card.Number)
                        {
                            return new TriggerStruct(Name, player);
                        }
                    }
                }
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                player.SetFlags(Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                List<int> ids = new List<int>();
                foreach (int id in room.DrawPile)
                {
                    WrappedCard card = room.GetCard(id);
                    if (card.Suit == use.Card.Suit && card.Number == use.Card.Number)
                    {
                        ids.Add(id);
                    }
                }
                if (ids.Count > 0)
                {
                    foreach (int id in ids)
                    {
                        room.MoveCardTo(room.GetCard(id), player, Place.PlaceTable, new CardMoveReason(MoveReason.S_REASON_TURNOVER, player.Name, Name, null), false);
                        Thread.Sleep(200);
                    }
                    CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_GOTBACK, player.Name, Name, string.Empty);
                    room.ObtainCard(player, ref ids, reason, true);
                }
            }
            return false;
        }
    }


    //dengzhi
    public class JianliangHegemony : TriggerSkill
    {
        public JianliangHegemony() : base("jianliang_hegemony")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            skill_type = SkillType.Replenish;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Draw)
            {
                int max = 1000;
                foreach (Player p in room.GetAlivePlayers())
                    if (p.HandcardNum < max)
                        max = p.HandcardNum;

                if (player.HandcardNum == max)
                    return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, "@jianliang_hegemony", info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<Player> targets = new List<Player>();
            foreach (Player p in room.GetAlivePlayers())
                if (RoomLogic.IsFriendWith(room, player, p))
                    targets.Add(p);

            foreach (Player p in targets)
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, p.Name);

            foreach (Player p in targets)
            {
                if (p.Alive)
                    room.DrawCards(p, new DrawCardStruct(1, player, Name));
            }

            return false;
        }
    }


    public class WeimengHegemony : ZeroCardViewAsSkill
    {
        public WeimengHegemony() : base("weimeng_hegemony") { }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(WeimengHCard.ClassName);

        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(WeimengHCard.ClassName) { Skill = Name, ShowSkill = Name };
    }

    public class WeimengHCard : SkillCard
    {
        public static string ClassName = "WeimengHCard";
        public WeimengHCard() : base(ClassName) { }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && Self != to_select && !to_select.IsKongcheng() && RoomLogic.CanGetCard(room, Self, to_select, "h");
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            List<string> patterns = new List<string>();
            for (int i = 0; i < Math.Max(1, Math.Min(player.Hp, target.HandcardNum)); i++)
                patterns.Add("h^false^get");

            List<int> ids = room.AskForCardsChosen(player, target, patterns, "weimeng_hegemony");
            CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_EXTRACTION, player.Name);
            room.ObtainCard(player, ref ids, reason, false);

            if (player.Alive && target.Alive)
            {
                int min = Math.Min(player.GetCardCount(true), ids.Count);
                List<int> give = room.AskForExchange(player, "weimeng_hegemony", min, min, string.Format("@weimeng:{0}::{1}", target.Name, min), string.Empty, "..", card_use.Card.SkillPosition);
                room.ObtainCard(target, ref give, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, "weimeng_hegemony", string.Empty), false);
                if (target.Alive)
                    room.HandleAcquireDetachSkills(target, "weimeng_strategy", true);
            }
        }
    }

    public class WeimengStrategy : TriggerSkill
    {
        public WeimengStrategy() : base("weimeng_strategy")
        {
            events.Add(TriggerEvent.EventPhaseChanging);
            view_as_skill = new WeimengStrategyVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                room.HandleAcquireDetachSkills(player, "-weimeng_strategy", true);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data) => new List<TriggerStruct>();
    }

    public class WeimengStrategyVS : ZeroCardViewAsSkill
    {
        public WeimengStrategyVS() : base("weimeng_strategy") { }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(WeimengSCard.ClassName);
        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(WeimengSCard.ClassName) { Skill = Name };
    }

    public class WeimengSCard : SkillCard
    {
        public static string ClassName = "WeimengSCard";
        public WeimengSCard() : base(ClassName) { }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && Self != to_select && !to_select.IsKongcheng() && RoomLogic.CanGetCard(room, Self, to_select, "h");
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            List<string> patterns = new List<string>();

            int id = room.AskForCardChosen(player, target, "h", "weimeng_strategy", false, HandlingMethod.MethodGet);
            CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_EXTRACTION, player.Name);
            room.ObtainCard(player, room.GetCard(id), reason, false);

            if (player.Alive && target.Alive)
            {
                List<int> give = room.AskForExchange(player, "weimeng_strategy", 1, 1, string.Format("@weimeng:{0}::{1}", target.Name, 1), string.Empty, "..", card_use.Card.SkillPosition);
                room.ObtainCard(target, ref give, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, "weimeng_strategy", string.Empty), false);
            }
        }
    }

    public class Zhente : TriggerSkill
    {
        public Zhente() : base("zhente")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging, TriggerEvent.TargetConfirmed, TriggerEvent.Death };
            skill_type = SkillType.Defense;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            bool clear = false;
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                    if (p.HasFlag(Name))
                        p.SetFlags("-zhente");

                if (player.HasFlag("ZhenteTarget"))
                    clear = true;
            }

            if (triggerEvent == TriggerEvent.Death && player.HasFlag("ZhenteTarget"))
                clear = true;

            if (clear)
            {
                RoomLogic.RemovePlayerCardLimitation(player, Name);
                room.SetPlayerMark(player, "@qianxi_black", 0);
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TargetConfirmed && base.Triggerable(player, room) && data is CardUseStruct use && use.To.Contains(player)
                && !player.HasFlag(Name) && use.From != null && use.From != player && use.From.Alive)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if ((fcard is BasicCard || fcard.IsNDTrick()) && WrappedCard.IsBlack(use.Card.Suit))
                    return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                player.SetFlags(Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player liushan, ref object data, Player ask_who, TriggerStruct info)
        {
            CardUseStruct use = (CardUseStruct)data;

            int index = 0, i;
            for (i = 0; i < use.EffectCount.Count; i++)
            {
                CardBasicEffect effect = use.EffectCount[i];
                if (effect.To == liushan)
                {
                    index++;
                    if (index == info.Times)
                    {
                        use.From.SetTag(Name, i);
                        break;
                    }
                }
            }

            if (room.AskForChoice(use.From, Name, "use+nulli", new List<string> { "@to-player:" + liushan.Name }, data) == "nulli")
            {
                CardBasicEffect effect = use.EffectCount[i];
                effect.Nullified = true;

                data = use;
            }
            else
            {
                string color = "black";
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, liushan.Name, use.From.Name);

                string pattern = string.Format(".|{0}|.|hand$0", color);
                use.From.SetFlags("ZhenteTarget");
                room.AddPlayerMark(use.From, "@qianxi_" + color);
                RoomLogic.SetPlayerCardLimitation(use.From, Name, "use", pattern, false);

                LogMessage log = new LogMessage
                {
                    Type = "#NoColor",
                    From = use.From.Name,
                    Arg = "no_suit_" + color,
                    Arg2 = Name
                };
                room.SendLog(log);
            }

            use.From.RemoveTag(Name);

            return false;
        }
    }

    public class Zhiwei : TriggerSkill
    {
        public Zhiwei() : base("zhiwei")
        {
            events = new List<TriggerEvent> { TriggerEvent.GeneralShown, TriggerEvent.Damage, TriggerEvent.Damaged, TriggerEvent.Death,
                TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseEnd };
            frequency = Frequency.Compulsory;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null && move.From.Phase == PlayerPhase.Discard
                && move.From == room.Current && (move.Reason.Reason & MoveReason.S_MASK_BASIC_REASON) == MoveReason.S_REASON_DISCARD && base.Triggerable(move.From, room))
            {
                if (move.From.ContainsTag(Name) && move.From.GetTag(Name) is string target_name)
                {
                    Player target = room.FindPlayer(target_name);
                    if (target != null)
                    {
                        List<int> guzhengToGet = move.From.ContainsTag("zhiwei_give") ? (List<int>)move.From.GetTag("zhiwei_give") : new List<int>();
                        foreach (int card_id in move.Card_ids)
                        {
                            if (!guzhengToGet.Contains(card_id))
                                guzhengToGet.Add(card_id);
                        }

                        move.From.SetTag("zhiwei_give", guzhengToGet);
                    }
                }
            }
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.GeneralShown)
            {
                if (base.Triggerable(player, room) && !player.ContainsTag(Name))
                {
                    bool head = (bool)data;
                    if (head && RoomLogic.InPlayerHeadSkills(player, Name))
                    {
                        TriggerStruct trigger = new TriggerStruct(Name, player)
                        {
                            SkillPosition = "head"
                        };
                        triggers.Add(trigger);
                    }
                    else if (!head && RoomLogic.InPlayerDeputykills(player, Name))
                    {
                        TriggerStruct trigger = new TriggerStruct(Name, player)
                        {
                            SkillPosition = "deputy"
                        };
                        triggers.Add(trigger);
                    }
                }
            }
            else if ((triggerEvent == TriggerEvent.Damage || triggerEvent == TriggerEvent.Damaged) && player.ContainsTag("zhiwei_from")
                && player.GetTag("zhiwei_from") is List<string> froms)
            {
                foreach (string name in froms)
                {
                    Player p = room.FindPlayer(name);
                    if (p != null && RoomLogic.PlayerHasShownSkill(room, p, Name))
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }
            else if (triggerEvent == TriggerEvent.Death && player.ContainsTag("zhiwei_from")
                && player.GetTag("zhiwei_from") is List<string> _froms)
            {
                foreach (string name in _froms)
                {
                    Player p = room.FindPlayer(name);
                    if (p != null)
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }
            else if (triggerEvent == TriggerEvent.EventPhaseEnd && player.Phase == PlayerPhase.Discard && player.ContainsTag("zhiwei_give"))
                triggers.Add(new TriggerStruct(Name, player));

            return triggers;
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.GeneralShown)
            {
                Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@zhiwei-choose", false, true, info.SkillPosition);
                player.SetTag(Name, target.Name);
                List<string> zhiwei = new List<string>();
                if (target.ContainsTag("zhiwei_from")) zhiwei = (List<string>)target.GetTag("zhiwei_from");
                if (!zhiwei.Contains(player.Name)) zhiwei.Add(player.Name);
                target.SetTag("zhiwei_from", zhiwei);
            }
            else if (triggerEvent == TriggerEvent.Damaged && !ask_who.IsKongcheng())
            {
                List<int> ids = new List<int>();
                foreach (int id in ask_who.GetCards("h"))
                {
                    if (RoomLogic.CanDiscard(room, ask_who, ask_who, id))
                        ids.Add(id);
                }

                if (ids.Count > 0)
                {
                    Shuffle.shuffle(ref ids);
                    List<int> discard = new List<int> { ids[0] };
                    room.ThrowCard(ref discard,
                        new CardMoveReason(MoveReason.S_REASON_THROW, ask_who.Name, Name, string.Empty) { General = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition) },
                        ask_who, ask_who);
                }
            }
            else if (triggerEvent == TriggerEvent.Damage)
            {
                room.DrawCards(ask_who, 1, Name);
            }
            else if (triggerEvent == TriggerEvent.Death)
            {
                ask_who.RemoveTag(Name);
                if (ask_who.HasShownAllGenerals() && RoomLogic.PlayerHasShownSkill(room, ask_who, Name))
                    room.HideGeneral(ask_who, RoomLogic.InPlayerHeadSkills(ask_who, Name));
            }
            else if (triggerEvent == TriggerEvent.EventPhaseEnd && ask_who.ContainsTag(Name) && ask_who.GetTag(Name) is string target_name)
            {
                Player target = room.FindPlayer(target_name);
                if (base.Triggerable(player, room) && target != null && player.GetTag("zhiwei_give") is List<int> guzhengToGet)
                {
                    guzhengToGet.RemoveAll(t => room.GetCardPlace(t) != Place.DiscardPile);
                    if (guzhengToGet.Count > 0)
                    {
                        room.ObtainCard(target, ref guzhengToGet, new CardMoveReason(MoveReason.S_REASON_RECYCLE, player.Name, target.Name, Name, string.Empty));
                    }
                }
                player.RemoveTag("zhiwei_give");
            }

            return false;
        }
    }



    public class KuangcaiHegemony : TriggerSkill
    {
        public KuangcaiHegemony() : base("kuangcai_hegemony")
        {
            frequency = Frequency.Compulsory;
            events = new List<TriggerEvent> { TriggerEvent.DamageDone, TriggerEvent.CardUsedAnnounced };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardUsedAnnounced && data is CardUseStruct use && player.Phase != PlayerPhase.NotActive && !player.HasFlag(Name))
                player.SetFlags("kuangcai_use");
            else if (triggerEvent == TriggerEvent.DamageDone && data is DamageStruct damage && damage.From != null && damage.From.Phase != PlayerPhase.NotActive)
                damage.From.SetFlags(Name);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data) => new List<TriggerStruct>();
    }

    //miheng
    public class KuangcaiHegemonyTar : TargetModSkill
    {
        public KuangcaiHegemonyTar() : base("#kuangcai_hegemony", true)
        {
            pattern = "BasicCard#TrickCard";
        }

        public override int GetResidueNum(Room room, Player from, WrappedCard card)
        {
            if (RoomLogic.PlayerHasShownSkill(room, from, "kuangcai_hegemony"))
                return 1000;
            else
                return 0;
        }

        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            if (to != null && RoomLogic.PlayerHasShownSkill(room, from, "kuangcai_hegemony") && from.Phase != PlayerPhase.NotActive)
                return true;

            return false;
        }
    }

    public class KuangcaiHegemonyMax : MaxCardsSkill
    {
        public KuangcaiHegemonyMax() : base("#kuangcai_hegemony-max") { }
        public override int GetExtra(Room room, Player target)
        {
            if (RoomLogic.PlayerHasShownSkill(room, target, "kuangcai_hegemony"))
            {
                if (!target.HasFlag("kuangcai_use"))
                    return 1;
                else if (!target.HasFlag("kuangcai_hegemony"))
                    return -1;
            }

            return 0;
        }
    }

    public class ShejianHegemony : TriggerSkill
    {
        public ShejianHegemony() : base("shejian_hegemony")
        {
            events.Add(TriggerEvent.TargetConfirmed);
            skill_type = SkillType.Attack;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardUseStruct use && use.To.Count == 1 && base.Triggerable(player, room) && !player.IsKongcheng() && use.From != null && use.From.Alive
                && use.From != player && RoomLogic.CanDiscard(room, player, player, "h"))
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is BasicCard || fcard is TrickCard)
                    return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use && room.AskForSkillInvoke(player, Name, "@shejian_hegemony:" + use.From.Name, info.SkillPosition))
            {
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, use.From.Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);

                List<int> ids = room.ForceToDiscard(player, player.GetCards("h"), player.GetCardCount(false), true);
                room.ThrowCard(ref ids,
                    new CardMoveReason(MoveReason.S_REASON_THROW, player.Name, Name, string.Empty) { General = RoomLogic.GetGeneralSkin(room, player, Name, info.SkillPosition) },
                    player, null, Name);
                player.SetMark(Name, ids.Count);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use && use.From.Alive)
            {
                List<string> choices = new List<string>();
                if (RoomLogic.CanDiscard(room, player, use.From, "he"))
                    choices.Add("discard");

                bool check = true;
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.HasFlag("Global_Dying"))
                    {
                        check = false;
                        break;
                    }
                }
                if (check) choices.Add("damage");
                if (choices.Count > 0)
                {
                    string choice = room.AskForChoice(player, Name, string.Join("+", choices), new List<string> { "@to-player:" + use.From.Name }, use.From);
                    if (choice == "discard")
                    {
                        List<string> patterns = new List<string>();
                        for (int i = 0; i < Math.Min(player.GetMark(Name), use.From.GetCardCount(true)); i++)
                            patterns.Add("he^false^none");
                        List<int> ids = room.AskForCardsChosen(player, use.From, patterns, Name);
                        room.ThrowCard(ref ids, new CardMoveReason(MoveReason.S_REASON_DISMANTLE, player.Name, use.From.Name, Name, string.Empty), use.From, player);
                    }
                    else
                        room.Damage(new DamageStruct(Name, player, use.From));
                }
            }
            return false;
        }
    }

}