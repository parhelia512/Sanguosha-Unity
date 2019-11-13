﻿using CommonClass;
using CommonClass.Game;
using CommonClassLibrary;
using SanguoshaServer.Game;
using System;
using System.Collections.Generic;
using static CommonClass.Game.CardUseStruct;
using static CommonClass.Game.Player;

namespace SanguoshaServer.Package
{
    public class ClassicYing : GeneralPackage
    {
        public ClassicYing() : base("ClassicYing")
        {
            skills = new List<Skill>
            {
                new Chenglue(),
                new ChenglueTar(),
                new ShicaiJX(),
                new Cunmu(),
                new Tushe(),
                new Limu(),
                new LimuTar(),

                new Zuilun(),
                new Fuyin(),

                new Kongsheng(),
                new KongshengClear(),
                new Liangyin(),
                new Qianjie(),
                new Jueyan(),
                new JueyanTar(),
                new JueyanMax(),
                new Poshi(),
                new Huairou(),
                new Kuizhu(),
                new Chezheng(),
                new ChezhengProhibit(),
                new Lijun(),
                new Huaiju(),
                new HuaijuDetach(),
                new Yili(),
                new Zhenglun(),
            };

            skill_cards = new List<FunctionCard>
            {
                new ChenglueCard(),
                new LimuCard(),
                new JueyanCard(),
                new HuairouCard(),
                new KuizhuCard(),
            };

            related_skills = new Dictionary<string, List<string>>
            {
                { "chenglue", new List<string>{ "#chenglue-tar" } },
                { "limu", new List<string>{ "#limu-tar" } },
                { "jueyan", new List<string>{ "#jueyan-target", "#jueyan-max" } },
                { "kongsheng", new List<string>{ "#kongsheng-clear" } },
                { "chezheng", new List<string>{ "#chezheng-pro" } },
                { "huaiju", new List<string>{ "#huaiju-clear" } },
            };
        }
    }

    public class Chenglue : TriggerSkill
    {
        public Chenglue() : base("chenglue")
        {
            events.Add(TriggerEvent.EventPhaseChanging);
            frequency = Frequency.Turn;
            view_as_skill = new ChenglueVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player.ContainsTag(Name))
            {
                player.RemoveTag(Name);
                room.RemovePlayerStringMark(player, Name);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class ChenglueVS : ZeroCardViewAsSkill
    {
        public ChenglueVS() : base("chenglue")
        {
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.HasUsed(ChenglueCard.ClassName);
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            WrappedCard cl = new WrappedCard(ChenglueCard.ClassName)
            {
                Skill = Name
            };
            return cl;
        }
    }

    public class ChenglueTar : TargetModSkill
    {
        public ChenglueTar() : base("#chenglue-tar", false)
        {
            pattern = "BasicCard,TrickCard";
        }

        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            if (from != null && from.ContainsTag("chenglue") && from.GetTag("chenglue") is List<WrappedCard.CardSuit> suits && suits.Contains(RoomLogic.GetCardSuit(room, card)))
            {
                return true;
            }

            return false;
        }

        public override int GetResidueNum(Room room, Player from, WrappedCard card)
        {
            if (from != null && from.ContainsTag("chenglue") && from.GetTag("chenglue") is List<WrappedCard.CardSuit> suits && suits.Contains(RoomLogic.GetCardSuit(room, card)))
            {
                return 999;
            }

            return 0;
        }
    }

    public class ChenglueCard : SkillCard
    {
        public static string ClassName = "ChenglueCard";
        public ChenglueCard() : base(ClassName)
        {
            will_throw = true;
            target_fixed = true;
        }

        private readonly Dictionary<WrappedCard.CardSuit, string> suits = new Dictionary<WrappedCard.CardSuit, string> {
            { WrappedCard.CardSuit.Club, "♠" },
            { WrappedCard.CardSuit.Spade, "♣" },
            { WrappedCard.CardSuit.Heart, "♥" },
            { WrappedCard.CardSuit.Diamond, "♦" },
        };
        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            int count = player.GetMark("chenglue") == 0 ? 1 : 2;
            player.SetMark("chenglue", count == 1 ? 1 : 0);

            List<string> arg = new List<string> {
                GameEventType.S_GAME_EVENT_SKILL_TURN.ToString(),
                player.Name,
                "chenglue",
                count == 1 ? true.ToString() : false.ToString(),
                card_use.Card.SkillPosition
            };
            room.DoBroadcastNotify(CommandType.S_COMMAND_LOG_EVENT, arg);

            room.DrawCards(player, count, "chenglue");
            if (player.Alive)
            {
                List<int> ids = room.AskForExchange(player, "chenglue", count == 1 ? 2 : 1, count == 1 ? 2 : 1,
                    string.Format("@chenglue-discard:::{0}", count == 1 ? 2 : 1), string.Empty, ".!", card_use.Card.SkillPosition);
                room.ThrowCard(ref ids, player);

                string mark = string.Empty;
                List<WrappedCard.CardSuit> discards = new List<WrappedCard.CardSuit>();
                foreach (int id in ids)
                {
                    WrappedCard.CardSuit suit = room.GetCard(id).Suit;
                    string suit_string = suits[suit];
                    if (!mark.Contains(suit_string)) mark += suit_string;
                    if (!discards.Contains(suit)) discards.Add(suit);
                }

                if (player.Alive && !string.IsNullOrEmpty(mark))
                {
                    player.SetTag("chenglue", discards);
                    room.SetPlayerStringMark(player, "chenglue", mark);
                }
            }
        }
    }

    public class ShicaiJX : TriggerSkill
    {
        public ShicaiJX() : base("shicai_jx")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging, TriggerEvent.CardFinished, TriggerEvent.TargetConfirmed };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.ContainsTag(Name))
                        p.RemoveTag(Name);
                }
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardFinished && data is CardUseStruct use && base.Triggerable(player, room))
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (!(fcard is SkillCard))
                {
                    bool dis = false;
                    foreach (int id in use.Card.SubCards)
                    {
                        if (room.GetCardPlace(id) == Place.DiscardPile)
                        {
                            dis = true;
                            break;
                        }
                    }

                    FunctionCard.CardType type = fcard.TypeID;
                    List<FunctionCard.CardType> types = player.ContainsTag(Name) ? (List<FunctionCard.CardType>)player.GetTag(Name) : new List<FunctionCard.CardType>();
                    if (dis && !types.Contains(type))
                        return new TriggerStruct(Name, player);
                }
            }
            else if (triggerEvent == TriggerEvent.TargetConfirmed && data is CardUseStruct _use && base.Triggerable(player, room))
            {
                FunctionCard fcard = Engine.GetFunctionCard(_use.Card.Name);
                List<FunctionCard.CardType> types = player.ContainsTag(Name) ? (List<FunctionCard.CardType>)player.GetTag(Name) : new List<FunctionCard.CardType>();
                if (fcard is EquipCard && !types.Contains(FunctionCard.CardType.TypeEquip) && room.GetCardPlace(_use.Card.GetEffectiveId()) == Place.PlaceTable)
                    return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                FunctionCard.CardType type = fcard.TypeID;
                List<FunctionCard.CardType> types = player.ContainsTag(Name) ? (List<FunctionCard.CardType>)player.GetTag(Name) : new List<FunctionCard.CardType>();
                if (!types.Contains(type))
                {
                    types.Add(type);
                    player.SetTag(Name, types);
                }

                List<int> dis = new List<int>();
                foreach (int id in use.Card.SubCards)
                    if ((room.GetCardPlace(id) == Place.DiscardPile && triggerEvent == TriggerEvent.CardFinished) ||
                        (triggerEvent == TriggerEvent.TargetConfirmed && room.GetCardPlace(id) == Place.PlaceTable))
                        dis.Add(id);

                if (dis.Count > 0 && room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
                {
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    CardMoveReason reason = new CardMoveReason(CardMoveReason.MoveReason.S_REASON_PUT, player.Name, Name, string.Empty);
                    CardsMoveStruct move = new CardsMoveStruct(dis, null, Place.DrawPile, reason)
                    {
                        To_pile_name = string.Empty,
                        From = null
                    };

                    List<CardsMoveStruct> moves = new List<CardsMoveStruct> { move };
                    room.MoveCardsAtomic(moves, true);

                    return info;
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.DrawCards(player, 1, Name);
            return false;
        }
    }

    public class Cunmu : TriggerSkill
    {
        public Cunmu() : base("cunmu")
        {
            events.Add(TriggerEvent.CardDrawing);
            skill_type = SkillType.Replenish;
            frequency = Frequency.Compulsory;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            if (data is List<int> ids)
            {
                int count = ids.Count;
                ids.Clear();
                for (int i = 0; i < count; i++)
                    ids.Add(room.DrawPile[room.DrawPile.Count - 1 - i]);

                data = ids;
            }

            return false;
        }
    }

    public class Tushe : TriggerSkill
    {
        public Tushe() : base("tushe")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen };
            skill_type = SkillType.Replenish;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is CardUseStruct use && use.Card != null)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (!(fcard is EquipCard) && !(fcard is SkillCard))
                {
                    bool check = true;
                    foreach (int id in player.GetCards("h"))
                    {
                        WrappedCard card = room.GetCard(id);
                        if (Engine.GetFunctionCard(card.Name) is BasicCard)
                        {
                            check = false;
                            break;
                        }
                    }
                    if (check)
                        return new TriggerStruct(Name, player);
                }
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            bool check = true;
            foreach (int id in player.GetCards("h"))
            {
                WrappedCard card = room.GetCard(id);
                if (Engine.GetFunctionCard(card.Name) is BasicCard)
                {
                    check = false;
                    break;
                }
            }
            if (check && room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use)
                room.DrawCards(player, use.To.Count, Name);

            return false;
        }
    }

    public class Limu : OneCardViewAsSkill
    {
        public Limu() : base("limu")
        {
            filter_pattern = ".|diamond";
            response_or_use = true;
            skill_type = SkillType.Alter;
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            WrappedCard card = new WrappedCard(Indulgence.ClassName);
            return !RoomLogic.PlayerContainsTrick(room, player, Indulgence.ClassName) && RoomLogic.IsProhibited(room, player, player, card) == null;
        }

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard indulgence = new WrappedCard(LimuCard.ClassName);
            indulgence.AddSubCard(card);
            return indulgence;
        }

        public override void GetEffectIndex(Room room, Player player, WrappedCard card, ref int index, ref string skill_name, ref string general_name, ref int skin_id)
        {
            index = 1;
        }
    }

    public class LimuCard : SkillCard
    {
        public static string ClassName = "LimuCard";
        public LimuCard() : base(ClassName)
        {
            will_throw = false;
            target_fixed = true;
        }

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            WrappedCard indulgence = new WrappedCard(Indulgence.ClassName)
            {
                Skill = "limu",
                ShowSkill = "limu"
            };
            indulgence.AddSubCard(card_use.Card.GetEffectiveId());
            indulgence = RoomLogic.ParseUseCard(room, indulgence);
            room.UseCard(new CardUseStruct(indulgence, player, player));

            if (player.IsWounded())
            {
                RecoverStruct recover = new RecoverStruct
                {
                    Who = player,
                    Recover = 1
                };
                room.Recover(player, recover, true);
            }
        }
    }

    public class LimuTar : TargetModSkill
    {
        public LimuTar() : base("#limu-tar")
        {
            pattern = "BasicCard,TrickCard";
        }

        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            if (from != null && to != null && RoomLogic.PlayerHasShownSkill(room, from, "limu") && RoomLogic.InMyAttackRange(room, from, to, card)
                && from.JudgingArea.Count > 0)
                return true;

            return false;
        }

        public override bool CheckSpecificAssignee(Room room, Player from, Player to, WrappedCard card)
        {
            if (from != null && to != null && RoomLogic.PlayerHasShownSkill(room, from, "limu") && RoomLogic.InMyAttackRange(room, from, to, card)
                && from.JudgingArea.Count > 0)
                return true;

            return false;
        }

        public override void GetEffectIndex(Room room, Player player, WrappedCard card, ModType type, ref int index, ref string skill_name, ref string general_name, ref int skin_id)
        {
            index = -2;
        }
    }

    public class Zuilun : TriggerSkill
    {
        public Zuilun() : base("zuilun")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageComplete, TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseStart };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.DamageComplete && data is DamageStruct damage && damage.From != null && room.Current == damage.From && damage.From.Alive)
                damage.From.SetFlags("zuilun_damage");
            else if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null && move.From == room.Current && move.From.Alive
                && (move.Reason.Reason & CardMoveReason.MoveReason.S_MASK_BASIC_REASON) == CardMoveReason.MoveReason.S_REASON_DISCARD)
                move.From.SetFlags("zuilun_discard");
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.Phase == PlayerPhase.Finish)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, null, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player zhuge, ref object data, Player ask_who, TriggerStruct info)
        {
            List<int> ids = room.GetNCards(3, true);
            int count = 0;
            if (zhuge.HasFlag("zuilun_damage")) count++;
            if (!zhuge.HasFlag("zuilun_discard")) count++;
            int hand = 1000;
            foreach (Player p in room.GetAlivePlayers())
                if (p.HandcardNum < hand) hand = p.HandcardNum;
            if (zhuge.HandcardNum == hand) count++;

            if (count == 3)
            {
                room.ObtainCard(zhuge, ref ids, new CardMoveReason(CardMoveReason.MoveReason.S_REASON_GOTCARD, zhuge.Name, Name, string.Empty), false);
            }
            else
            {
                LogMessage log = new LogMessage
                {
                    Type = "$ViewDrawPile",
                    From = zhuge.Name,
                    Card_str = string.Join("+", JsonUntity.IntList2StringList(ids))
                };
                room.SendLog(log, zhuge);
                log.Type = "$ViewDrawPile2";
                log.Arg = ids.Count.ToString();
                log.Card_str = null;
                room.SendLog(log, new List<Player> { zhuge });

                AskForMoveCardsStruct result = room.AskForMoveCards(zhuge, ids, new List<int>(), true, Name, count, count, false, true, new List<int>(), info.SkillPosition);
                List<int> top_cards = new List<int>(), bottom_cards = new List<int>();
                if (result.Success && result.Bottom.Count == count)
                {
                    top_cards = result.Top;
                    bottom_cards = result.Bottom;
                }
                else
                {
                    for (int i = 0; i < ids.Count; i++)
                    {
                        if (i < count)
                            bottom_cards.Add(ids[i]);
                        else
                            top_cards.Add(ids[i]);
                    }
                }

                if (bottom_cards.Count > 0)
                    room.ObtainCard(zhuge, ref bottom_cards, new CardMoveReason(CardMoveReason.MoveReason.S_REASON_GOTCARD, zhuge.Name, Name, string.Empty), false);

                if (top_cards.Count > 0)
                {
                    LogMessage log1 = new LogMessage
                    {
                        Type = "$GuanxingTop",
                        From = zhuge.Name,
                        Card_str = string.Join("+", JsonUntity.IntList2StringList(top_cards))
                    };
                    room.SendLog(log1, zhuge);
                }

                room.ReturnToDrawPile(top_cards, false, zhuge);

                if (count == 0)
                {
                    Player target = room.AskForPlayerChosen(zhuge, room.GetOtherPlayers(zhuge), Name, "@zuilun", false, true, info.SkillPosition);
                    room.LoseHp(zhuge);
                    if (target.Alive)
                        room.LoseHp(target);
                }
            }

            return false;
        }
    }

    public class Fuyin : TriggerSkill
    {
        public Fuyin() : base("fuyin")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetConfirmed, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Defense;
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.HasFlag(Name)) p.SetFlags("-fuyin");
                    if (p.GetMark(Name) > 0) p.SetMark(Name, 0);
                }
            }
            else if (triggerEvent == TriggerEvent.TargetConfirmed && data is CardUseStruct use)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is Slash || fcard is Duel)
                    player.AddMark(Name);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is CardUseStruct use && use.From != null && use.From.Alive
                && use.From != player && player.GetMark(Name) == 1 && player.HandcardNum < use.From.HandcardNum)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is Slash || fcard is Duel)
                    return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.Alive && data is CardUseStruct use)
            {
                room.SendCompulsoryTriggerLog(player, Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                int index = 0;
                for (int i = 0; i < use.EffectCount.Count; i++)
                {
                    CardBasicEffect effect = use.EffectCount[i];
                    if (effect.To == player)
                    {
                        index++;
                        if (index == info.Times)
                        {
                            effect.Nullified = true;
                            use.EffectCount[i] = effect;
                            data = use;
                            break;
                        }
                    }
                }
            }

            return false;
        }
    }


    public class Liangyin : TriggerSkill
    {
        public Liangyin() : base("liangyin")
        {
            events.Add(TriggerEvent.CardsMoveOneTime);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (data is CardsMoveOneTimeStruct move)
            {
                if ((move.To_place == Place.PlaceSpecial && !move.From_places.Contains(Place.PlaceSpecial)) ||
                    (move.To != null && move.To_place == Place.PlaceHand && move.From_places.Contains(Place.PlaceSpecial)))
                {
                    List<Player> zhoufeis = RoomLogic.FindPlayersBySkillName(room, Name);
                    foreach (Player p in zhoufeis)
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }

            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move)
            {
                List<Player> targets = new List<Player>();
                string prompt = "@liangyin-discard";

                if (move.To_place == Place.PlaceSpecial)
                {
                    prompt = "@liangyin-draw";
                    foreach (Player p in room.GetOtherPlayers(ask_who))
                    {
                        if (p.HandcardNum > ask_who.HandcardNum)
                            targets.Add(p);
                    }
                }
                else
                {
                    foreach (Player p in room.GetOtherPlayers(ask_who))
                    {
                        if (p.HandcardNum < ask_who.HandcardNum && RoomLogic.CanDiscard(room, ask_who, p, "he"))
                            targets.Add(p);
                    }
                }

                if (targets.Count > 0)
                {
                    Player target = room.AskForPlayerChosen(ask_who, targets, Name, prompt, true, true, info.SkillPosition);
                    if (target != null)
                    {
                        ask_who.SetTag(Name, target.Name);
                        room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                        return info;
                    }
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.FindPlayer(ask_who.GetTag(Name).ToString());
            ask_who.RemoveTag(Name);
            if (data is CardsMoveOneTimeStruct move)
            {
                if (move.To_place == Place.PlaceSpecial)
                {
                    room.DrawCards(target, new DrawCardStruct(1, ask_who, Name));
                }
                else
                {
                    int id = room.AskForCardChosen(ask_who, target, "he", Name, false, FunctionCard.HandlingMethod.MethodDiscard);
                    room.ThrowCard(id, target, ask_who);
                }
            }

            return false;
        }
    }

    public class Kongsheng : PhaseChangeSkill
    {
        public Kongsheng() : base("kongsheng")
        {
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && ((player.Phase == PlayerPhase.Start && !player.IsNude()) || (player.Phase == PlayerPhase.Finish && player.GetPile(Name).Count > 0)))
            {
                return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            bool invoke = false;
            if (player.Phase == PlayerPhase.Start && !player.IsNude())
            {
                List<int> ids = room.AskForExchange(player, Name, player.GetCardCount(true), 0, "@kongsheng", string.Empty, "..", info.SkillPosition);
                if (ids.Count > 0)
                {
                    invoke = true;
                    player.SetTag(Name, ids);
                }
            }
            else if (player.Phase == PlayerPhase.Finish)
                invoke = true;

            if (invoke)
            {
                room.NotifySkillInvoked(player, Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillName);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool OnPhaseChange(Room room, Player player, TriggerStruct info)
        {
            if (player.Phase == PlayerPhase.Start)
            {
                List<int> ids = (List<int>)player.GetTag(Name);
                player.RemoveTag(Name);
                room.AddToPile(player, Name, ids);
            }
            else
            {
                List<int> ids = new List<int>();
                foreach (int id in player.GetPile(Name))
                {
                    WrappedCard card = room.GetCard(id);
                    FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                    if (fcard is EquipCard && fcard.IsAvailable(room, player, card))
                        ids.Add(id);
                }

                while (ids.Count > 0)
                {
                    if (ids.Count == 1)
                    {
                        room.UseCard(new CardUseStruct(room.GetCard(ids[0]), player, new List<Player>()));
                        ids.Clear();
                    }
                    else
                    {
                        List<int> used = room.AskForExchange(player, Name, 1, 1, "@kongsheng-use", Name, string.Format("{0}|.|.|{1}", string.Join("#", ids), Name), info.SkillPosition);
                        ids.RemoveAll(t => used.Contains(t));
                        room.UseCard(new CardUseStruct(room.GetCard(used[0]), player, new List<Player>()));
                    }
                }

                ids = player.GetPile(Name);
                room.ObtainCard(player, ref ids, new CardMoveReason(CardMoveReason.MoveReason.S_REASON_EXCHANGE_FROM_PILE, player.Name, Name, string.Empty));
            }

            return false;
        }
    }

    public class KongshengClear : DetachEffectSkill
    {
        public KongshengClear() : base("kongsheng", "kongsheng") { }
    }

    public class Qianjie : ProhibitSkill
    {
        public Qianjie() : base("qianjie") { }
        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null)
        {
            if (to != null && RoomLogic.PlayerHasSkill(room, to, Name))
            {
                FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                if (fcard is DelayedTrick)
                    return true;
            }

            return false;
        }
        public override bool IsProhibited(Room room, Player from, Player to, ProhibitType type)
        {
            if (RoomLogic.PlayerHasSkill(room, to, Name))
                return true;

            return false;
        }
    }
    
    public class Jueyan : TriggerSkill
    {
        public Jueyan() : base("jueyan")
        {
            view_as_skill = new JueyanVS();
            events.Add(TriggerEvent.EventPhaseChanging);
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player.HasFlag("jueyan_skill"))
                room.HandleAcquireDetachSkills(player, "-jizhi_jx", true);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class JueyanVS : ZeroCardViewAsSkill
    {
        public JueyanVS() : base("jueyan") { }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            if (!player.HasUsed(JueyanCard.ClassName))
            {
                for (int i = 0; i < 5; i++)
                    if (!player.EquipIsBaned(i))
                        return true;
            }

            return false;
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(JueyanCard.ClassName) { Skill = Name };
        }
    }

    public class JueyanCard : SkillCard
    {
        public static string ClassName = "JueyanCard";
        public JueyanCard() : base(ClassName)
        {
            target_fixed = true;
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            List<string> choices = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                if (!player.EquipIsBaned(i))
                {
                    switch (i)
                    {
                        case 0:
                            choices.Add("Weapon");
                            break;
                        case 1:
                            choices.Add("Armor");
                            break;
                        case 2:
                            choices.Add("Horse");
                            break;
                        case 3:
                            if (!choices.Contains("Horse"))
                                choices.Add("Horse");
                            break;
                        case 4:
                            choices.Add("Treasure");
                            break;
                    }
                }
            }

            string choice = room.AskForChoice(player, "jueyan", string.Join("+", choices));
            switch (choice)
            {
                case "Weapon":
                    room.AbolisheEquip(player, 0, "jueyan");
                    player.SetFlags("jueyan_slash");
                    player.SetMark("jueyan", 3);
                    break;
                case "Armor":
                    room.AbolisheEquip(player, 1, "jueyan");
                    player.SetFlags("jueyan_max");
                    player.SetMark("jueyan", 3);
                    room.DrawCards(player, 3, "jueyan");
                    break;
                case "Horse":
                    room.AbolisheEquip(player, 2, "jueyan");
                    room.AbolisheEquip(player, 3, "jueyan");
                    player.SetFlags("jueyan_distance");
                    break;
                case "Treasure":
                    room.AbolisheEquip(player, 4, "jueyan");
                    room.HandleAcquireDetachSkills(player, "jizhi_jx", true);
                    player.SetFlags("jueyan_skill");
                    break;
            }
        }
    }

    public class JueyanTar : TargetModSkill
    {
        public JueyanTar() : base("#jueyan-target", false)
        {
            pattern = "^SkillCard";
        }

        public override int GetResidueNum(Room room, Player from, WrappedCard card)
        {
            if (card.Name.Contains(Slash.ClassName) && from.HasFlag("jueyan_slash"))
                return from.GetMark("jueyan");

            return 0;
        }

        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            return from.HasFlag("jueyan_distance");
        }
    }

    public class JueyanMax : MaxCardsSkill
    {
        public JueyanMax() : base("#jueyan-max") { }

        public override int GetExtra(Room room, Player target)
        {
            return target.HasFlag("jueyan_max") ? target.GetMark("jueyan") : 0;
        }
    }

    public class Poshi : PhaseChangeSkill
    {
        public Poshi() : base("poshi")
        {
            frequency = Frequency.Wake;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Start && base.Triggerable(player, room) && player.GetMark(Name) == 0)
            {
                bool check = true;
                for (int i = 0; i < 5; i++)
                {
                    if (!player.EquipIsBaned(i))
                    {
                        check = false;
                        break;
                    }
                }

                if (player.Hp == 1 || check)
                    return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override bool OnPhaseChange(Room room, Player player, TriggerStruct info)
        {
            room.SetPlayerMark(player, Name, 1);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.DoSuperLightbox(player, info.SkillPosition, Name);

            room.LoseMaxHp(player);
            if (player.Alive)
            {
                if (player.HandcardNum < player.MaxHp)
                    room.DrawCards(player, player.MaxHp - player.HandcardNum, Name);

                room.HandleAcquireDetachSkills(player, "-jueyan", false);
                room.HandleAcquireDetachSkills(player, "huairou", true);
            }

            return false;
        }
    }

    public class HuairouCard : SkillCard
    {
        public static string ClassName = "HuairouCard";
        public HuairouCard() : base(ClassName)
        {
            will_throw = false;
            handling_method = HandlingMethod.MethodRecast;
            target_fixed = true;
        }

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            DoRecast(room, card_use);
        }
    }

    public class Huairou : OneCardViewAsSkill
    {
        public Huairou() : base("huairou")
        {
        }

        public override bool ViewFilter(Room room, WrappedCard to_select, Player player)
        {
            FunctionCard fcard = Engine.GetFunctionCard(to_select.Name);
            return fcard is EquipCard && !RoomLogic.IsCardLimited(room, player, to_select, FunctionCard.HandlingMethod.MethodRecast, true);
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.IsNude();
        }

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard yy = new WrappedCard(HuairouCard.ClassName)
            {
                Skill = Name
            };
            yy.AddSubCard(card);
            return yy;
        }
    }

    public class Kuizhu : TriggerSkill
    {
        public Kuizhu() : base("kuizhu")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseEnd, TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseChanging };
            view_as_skill = new KuizhuVS();
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && base.Triggerable(move.From, room) && move.From.Phase == PlayerPhase.Discard
                && move.From == room.Current && (move.Reason.Reason & CardMoveReason.MoveReason.S_MASK_BASIC_REASON) == CardMoveReason.MoveReason.S_REASON_DISCARD)
            {
                move.From.AddMark(Name, move.Card_ids.Count);
                room.SetPlayerStringMark(move.From, Name, move.From.GetMark(Name).ToString());
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player.GetMark(Name) > 0)
            {
                player.SetMark(Name, 0);
                room.RemovePlayerStringMark(player, Name);
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseEnd && player.Phase == PlayerPhase.Discard && base.Triggerable(player, room) && player.GetMark(Name) > 0)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player erzhang, TriggerStruct info)
        {
            room.AskForUseCard(player, "@@kuizhu", string.Format("@kuizhu:::{0}", player.GetMark(Name)), -1, FunctionCard.HandlingMethod.MethodUse, true, info.SkillPosition);
            return new TriggerStruct();
        }
    }

    public class KuizhuVS : ZeroCardViewAsSkill
    {
        public KuizhuVS() : base("kuizhu") { response_pattern = "@@kuizhu"; }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return false;
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(KuizhuCard.ClassName) { Skill = Name };
        }
    }

    public class KuizhuCard : SkillCard
    {
        public static string ClassName = "KuizhuCard";
        public KuizhuCard() : base(ClassName)
        {
        }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            int count = Self.GetMark("kuizhu");
            int hp = 0;
            foreach (Player p in targets)
                hp += p.Hp;
            return targets.Count < count || hp + to_select.Hp <= count;
        }

        public override bool TargetsFeasible(Room room, List<Player> targets, Player Self, WrappedCard card)
        {
            int count = Self.GetMark("kuizhu");
            int hp = 0;
            foreach (Player p in targets)
                hp += p.Hp;
            return targets.Count <= count || count == hp;
        }
        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            int count = player.GetMark("kuizhu");
            int hp = 0;
            foreach (Player p in card_use.To)
                hp += p.Hp;

            bool draw = card_use.To.Count <= count;
            if (draw && hp == count)
                draw = room.AskForChoice(player, "kuizhu", "draw+damage") == "draw";

            foreach (Player p in card_use.To)
            {
                if (p.Alive)
                {
                    if (draw)
                        room.DrawCards(p, new DrawCardStruct(1, player, "kuizhu"));
                    else
                        room.Damage(new DamageStruct("kuizhu", player, p));
                }
            }

            if (!draw && player.Alive && card_use.To.Count > 1)
                room.Damage(new DamageStruct("kuizhu", null, player));
        }
    }

    public class Chezheng : TriggerSkill
    {
        public Chezheng() : base("chezheng")
        {
            skill_type = SkillType.Attack;
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseEnd, TriggerEvent.CardUsedAnnounced, TriggerEvent.EventPhaseChanging, TriggerEvent.CardResponded };
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardUsedAnnounced && player.Phase == PlayerPhase.Play && data is CardUseStruct use)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard.TypeID != FunctionCard.CardType.TypeSkill)
                {
                    player.AddMark(Name);
                }
            }
            else if (triggerEvent == TriggerEvent.CardResponded && data is CardResponseStruct resp && resp.Use && player.Phase == PlayerPhase.Play)
            {
                player.AddMark(Name);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player.GetMark(Name) > 0)
                player.SetMark(Name, 0);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseEnd && player.Phase == PlayerPhase.Play && base.Triggerable(player, room))
            {
                int count = 0;
                foreach (Player p in room.GetOtherPlayers(player))
                    if (!RoomLogic.InMyAttackRange(room, p, player))
                        count++;

                if (player.GetMark(Name) < count)
                    return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<Player> targets = new List<Player>();
            foreach (Player p in room.GetOtherPlayers(player))
                if (!RoomLogic.InMyAttackRange(room, p, player) && RoomLogic.CanDiscard(room, player, p, "he"))
                    targets.Add(p);
            if (targets.Count > 0)
            {
                Player target = room.AskForPlayerChosen(player, targets, Name, "@chezheng", false, true, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);

                int id = room.AskForCardChosen(player, target, "he", Name, false, FunctionCard.HandlingMethod.MethodDiscard);
                room.ThrowCard(id, target, player);
            }

            return false;
        }
    }

    public class ChezhengProhibit : ProhibitSkill
    {
        public ChezhengProhibit() : base("#chezheng-pro") { }

        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null)
        {
            if (from != null && to != null && card != null && RoomLogic.PlayerHasSkill(room, from, "chezheng") && !RoomLogic.InMyAttackRange(room, to, from))
            {
                FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                if (fcard.TypeID != FunctionCard.CardType.TypeSkill) return true;
            }

            return false;
        }
    }

    public class Lijun : TriggerSkill
    {
        public Lijun() : base("lijun")
        {
            events.Add(TriggerEvent.CardFinished);
            lord_skill = true;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName) && player != null && player.Alive && player.Kingdom == "wu"
                && !player.HasFlag(Name) &&  player.Phase == PlayerPhase.Play)
            {
                if (RoomLogic.FindPlayerBySkillName(room, Name) != null)
                    foreach (int id in use.Card.SubCards)
                        if (room.GetCardPlace(id) == Place.DiscardPile)
                            return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player lord = RoomLogic.FindPlayerBySkillName(room, Name);
            if (room.AskForSkillInvoke(player, Name, lord))
            {
                room.NotifySkillInvoked(lord, Name);
                room.BroadcastSkillInvoke(Name, lord);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                List<int> ids = new List<int>();
                foreach (int id in use.Card.SubCards)
                    if (room.GetCardPlace(id) == Place.DiscardPile)
                        ids.Add(id);

                if (ids.Count > 0)
                {
                    Player lord = RoomLogic.FindPlayerBySkillName(room, Name);
                    room.ObtainCard(lord, ref ids, new CardMoveReason(CardMoveReason.MoveReason.S_REASON_RECYCLE, player.Name, lord.Name, Name, string.Empty));

                    if (lord.Alive && player.Alive && room.AskForSkillInvoke(lord, Name, "@lijun:" + player.Name, info.SkillPosition))
                        room.DrawCards(player, new DrawCardStruct(1, lord, Name));
                }
            }

            return false;
        }
    }

    public class Huaiju : TriggerSkill
    {
        public Huaiju() : base("huaiju")
        {
            events = new List<TriggerEvent> { TriggerEvent.GameStart, TriggerEvent.DamageInflicted, TriggerEvent.EventPhaseProceeding };
            frequency = Frequency.Compulsory;
        }
        
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseProceeding && player.GetMark("@tangerine") > 0 && player.Phase == Player.PlayerPhase.Draw && (int)data >= 0)
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.DamageInflicted && player.GetMark("@tangerine") > 0)
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.GameStart && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.EventPhaseProceeding && data is int count)
            {
                Player luji = RoomLogic.FindPlayerBySkillName(room, Name);
                room.SendCompulsoryTriggerLog(luji, Name);
                count++;
                data = count;
            }
            else if (triggerEvent == TriggerEvent.DamageInflicted)
            {
                Player luji = RoomLogic.FindPlayerBySkillName(room, Name);
                room.SendCompulsoryTriggerLog(luji, Name);
                room.RemovePlayerMark(player, "@tangerine");

                LogMessage log = new LogMessage
                {
                    Type = "#damage-prevent",
                    From = player.Name
                };
                room.SendLog(log);

                return true;
            }
            else if (triggerEvent == TriggerEvent.GameStart)
            {
                room.SendCompulsoryTriggerLog(player, Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.AddPlayerMark(player, "@tangerine", 3);
            }

            return false;
        }
    }

    public class HuaijuDetach : DetachEffectSkill
    {
        public HuaijuDetach() : base("huaiju", string.Empty) { }
        public override void OnSkillDetached(Room room, Player player, object data)
        {
            foreach (Player p in room.GetAlivePlayers())
                if (p.GetMark("@tangerine") > 0)
                    room.SetPlayerMark(p, "@tangerine", 0);
        }
    }

    public class Yili : PhaseChangeSkill
    {
        public Yili() : base("yili")
        {
        }

        public override bool Triggerable(Player target, Room room)
        {
            return target.Phase == PlayerPhase.Play && base.Triggerable(target, room) && (target.Hp > 0 || target.GetMark("@tangerine") > 0);
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@yili", true, true, info.SkillPosition);
            if (target != null)
            {
                room.SetTag(Name, target);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool OnPhaseChange(Room room, Player player, TriggerStruct info)
        {
            Player target = (Player)room.GetTag(Name);
            room.RemoveTag(Name);

            List<string> choice = new List<string>();
            if (player.Hp > 0) choice.Add("losehp");
            if (player.GetMark("@tangerine") > 0) choice.Add("remove");

            if (room.AskForChoice(player, Name, string.Join("+", choice)) == "losehp")
                room.LoseHp(player);
            else
                room.AddPlayerMark(player, "@tangerine", -1);

            if (player.Alive && target.Alive)
                room.AddPlayerMark(target, "@tangerine", 1);

            return false;
        }
    }

    public class Zhenglun : TriggerSkill
    {
        public Zhenglun() : base("zhenglun")
        {
            events.Add(TriggerEvent.EventPhaseStart);// << EventPhaseProceeding;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player lidian, ref object data, Player ask_who)
        {
            return (base.Triggerable(lidian, room) && lidian.Phase == PlayerPhase.Draw && lidian.GetMark("@tangerine") == 0) ? new TriggerStruct(Name, lidian) : new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player lidian, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(lidian, Name, null, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, lidian, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.AddPlayerMark(player, "@tangerine", 1);
            return true;
        }
    }
}