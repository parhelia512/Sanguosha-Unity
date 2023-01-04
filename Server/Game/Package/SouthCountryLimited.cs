using CommonClass;
using CommonClass.Game;
using CommonClassLibrary;
using SanguoshaServer.Game;
using System;
using System.Collections.Generic;
using static CommonClass.Game.CardUseStruct;
using static CommonClass.Game.Player;

namespace SanguoshaServer.Package
{
    public class SouthCountryLimited : GeneralPackage
    {
        public SouthCountryLimited() : base("SouthCountryLimited")
        {
            skills = new List<Skill> {
               new Wall(),
               new TianrenCR(),
               new TianrenPro(),
               new TianrenTar(),
               new Revive(),
               new Cuirui(),
               new Liewei(),
            };
            skill_cards = new List<FunctionCard>
            {
                new CuiruiCard(),
            };
            related_skills = new Dictionary<string, List<string>>
            {
                { "tianren_cr", new List<string> { "#tianren_cr", "#tianren-tar", "#zhouyu-reivive" } },
            };
        }
    }

    public class Wall : TriggerSkill
    {
        public Wall() : base("wall")
        {
            events = new List<TriggerEvent> { TriggerEvent.RoundStart, TriggerEvent.CardsMoveOneTime, TriggerEvent.GameStart, TriggerEvent.PostHpReduced };
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.GameStart && base.Triggerable(player, room))
                player.JudgingAreaAvailable = false;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.RoundStart)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    if (!p.Removed)
                        return new TriggerStruct(Name, p);
            }
            else if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && base.Triggerable(move.To, room))
            {
                return new TriggerStruct(Name, move.To);
            }
            else if (triggerEvent == TriggerEvent.PostHpReduced && base.Triggerable(player, room) && player.Hp <= 0)
            {
                return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.RoundStart)
            {
                foreach (Player p in room.GetAlivePlayers())
                    if (p.ActualGeneral1 == "caoren") room.Speak(p, "城池坚固，各单位速速开展整备");
                room.SendCompulsoryTriggerLog(ask_who, Name);
                foreach (Player p in room.GetAlivePlayers())
                    if (p.Camp == Game3v3Camp.S_CAMP_WARM && !p.Removed && p.ActualGeneral1 != "wall")
                        room.Recover(p);
            }
            else if (triggerEvent == TriggerEvent.PostHpReduced)
            {
                if (!player.Removed)
                {
                    if (player.Chained) room.SetPlayerChained(player, false);
                    player.Removed = true;
                    room.BroadcastProperty(player, "Removed");
                }
                return true;
            }
            else
            {
                room.ThrowAllCards(ask_who);
            }

            return false;
        }
    }

    public class TianrenCR : TriggerSkill
    {
        public TianrenCR() : base("tianren_cr")
        {
            events = new List<TriggerEvent> { TriggerEvent.Dying, TriggerEvent.RoundStart, TriggerEvent.EventPhaseChanging, TriggerEvent.EventPhaseStart, TriggerEvent.DamageInflicted,
                TriggerEvent.EventPhaseProceeding, TriggerEvent.HpChanging, TriggerEvent.Death, TriggerEvent.EventPhaseEnd };
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                    p.SetMark("tianren_invalid", 0);
            }
            else if (triggerEvent ==  TriggerEvent.EventPhaseEnd && player.Alive && player.Phase == PlayerPhase.Judge && player.ActualGeneral1.Contains("sujiang") && !player.IsSkipped(PlayerPhase.Play))
            {
                if (player.Name == "SGS6")
                {
                    Player wall = room.GetLastAlive(player, 1, false);
                    if (wall.IsWounded())
                    {
                        foreach (Player p in room.GetAlivePlayers())
                            if (p.ActualGeneral1 == "caoren") room.Speak(p, "城墙修复为第一要务，加紧作业！");

                        room.SkipPhase(player, PlayerPhase.Play);
                        int count = Math.Min(wall.GetLostHp(), Shuffle.random(1, 2) ? 1 : 2);
                        wall.Hp += count;
                        room.BroadcastProperty(wall, "Hp");
                        room.SetEmotion(wall, "recover");
                        if (wall.Hp >= 3 && wall.Removed)
                        {
                            wall.Removed = false;
                            room.BroadcastProperty(wall, "Removed");

                            room.Speak(player, "报告将军，城墙修复完毕");
                        }
                    }
                }
                else if (player.Name == "SGS8")
                {
                    Player wall = room.GetNextAlive(player, 1, false);
                    if (wall.IsWounded())
                    {
                        foreach (Player p in room.GetAlivePlayers())
                            if (p.ActualGeneral1 == "caoren") room.Speak(p, "士兵，城墙修复为第一要务");

                        room.SkipPhase(player, PlayerPhase.Play);
                        int count = Math.Min(wall.GetLostHp(), Shuffle.random(1, 2) ? 1 : 2);
                        wall.Hp += count;
                        room.BroadcastProperty(wall, "Hp");
                        room.SetEmotion(wall, "recover");
                        if (wall.Hp >= 3 && wall.Removed)
                        {
                            wall.Removed = false;
                            room.BroadcastProperty(wall, "Removed");

                            room.Speak(player, "报告将军，城墙修复完毕");
                        }
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart && player != null && player.Phase == PlayerPhase.RoundStart && player.Alive && (player.ActualGeneral1 == "wall" || player.Removed))
            {
                for (int i = player.PhasesIndex; i < player.PhasesState.Count; i++)
                {
                    if (player.PhasesState[i].Phase == PlayerPhase.Draw)
                    {
                        player.PhasesState[i] = new PhaseStruct { Phase = PlayerPhase.Draw, Skipped = false, Finished = true };
                    }
                    else if (player.PhasesState[i].Phase == PlayerPhase.Play)
                    {
                        player.PhasesState[i] = new PhaseStruct { Phase = PlayerPhase.Play, Skipped = false, Finished = true };
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.Death && player.Camp == Game3v3Camp.S_CAMP_WARM)
            {
                List<string> skills = player.GetSkills(true, false);
                foreach (string skill in skills)
                {
                    Skill _s = Engine.GetSkill(skill);
                    if (_s != null && !_s.Attached_lord_skill)
                        room.DetachSkillFromPlayer(player, skill, false, player.GetAcquiredSkills().Contains(skill), true);
                }
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.Dying && base.Triggerable(player, room) && player.GetMark(Name) == 0)      //第一次濒死时回血摸牌
            {
                triggers.Add(new TriggerStruct(Name, player));
            }
            else if (triggerEvent == TriggerEvent.RoundStart)
            {
                Player ask_who = RoomLogic.FindPlayerBySkillName(room, Name);                       //轮次开始时恢复士兵
                if (ask_who != null)
                    triggers.Add(new TriggerStruct(Name, ask_who));
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Start)            //准备阶段万箭齐发
                    triggers.Add(new TriggerStruct(Name, player));
                else if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Finish)     //结束阶段返回游戏，添加援军
                    triggers.Add(new TriggerStruct(Name, player));
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                    if (p.HasFlag(Name))
                        triggers.Add(new TriggerStruct(Name, p));
            }
            else if (triggerEvent == TriggerEvent.EventPhaseProceeding && base.Triggerable(player, room) && player.Phase == PlayerPhase.Draw)
            {
                triggers.Add(new TriggerStruct(Name, player));
            }
            else if (triggerEvent == TriggerEvent.HpChanging && base.Triggerable(player, room) && data is int count && count < 0)
            {
                triggers.Add(new TriggerStruct(Name, player));
            }

            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.Dying)      //第一次濒死时回血摸牌
            {
                room.Speak(player, "贼军势大，暂且后退");
                room.SendCompulsoryTriggerLog(player, Name);
                player.AddMark(Name);
                player.SetFlags(Name);
                RecoverStruct recover = new RecoverStruct
                {
                    Recover = Math.Min(10, player.MaxHp) - player.Hp
                };
                room.Recover(player, recover);

                int count = 10 - player.HandcardNum;
                if (count > 0)
                    room.DrawCards(player, count, Name);
                
                if (!player.FaceUp) room.TurnOver(player);
                if (player.Chained) room.SetPlayerChained(player, false);
                if (!player.Removed)
                {
                    player.Removed = true;
                    room.BroadcastProperty(player, "Removed");
                }

                if (player.Phase != PlayerPhase.NotActive)
                    player.SetFlags("Global_PlayPhaseTerminated");
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging)
            {
                if (ask_who.Removed)      //回合结束后，重新返回游戏
                {
                    room.SetPlayerMark(ask_who, "@cuirui", 1);
                    ask_who.Removed = false;
                    room.BroadcastProperty(ask_who, "Removed");
                }

                foreach (Player target in room.GetOtherPlayers(ask_who))     //士兵变援军
                {
                    if (target.Camp == Game3v3Camp.S_CAMP_WARM && (target.General1 == "sujiang" || target.General1 == "sujiangf") && player.GetMark("back_up") < 4)
                    {
                        ask_who.AddMark("back_up");
                        ChangeGeneral(room, target);
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.RoundStart)
            {
                bool speak = false;
                foreach (Player p in room.Players)            //每轮开始时，如士兵阵亡，则变为援军加入
                {
                    if (p.Camp == Game3v3Camp.S_CAMP_WARM && !p.Alive)
                    {
                        if (ask_who.GetMark("back_up") < 4 && (p.ActualGeneral1 == "sujiang" || p.ActualGeneral1 == "sujiangf"))
                        {
                            ask_who.AddMark("back_up");
                            ChangeGeneral(room, p);
                        }
                        else
                        {
                            speak = true;
                        }
                    }
                }
                if (speak)
                {
                    room.Speak(ask_who, "坚持住，援军即刻就到");
                    foreach (Player p in room.Players)            //每轮开始时，如士兵阵亡，则变为援军加入
                    {
                        if (p.Camp == Game3v3Camp.S_CAMP_WARM && !p.Alive)
                        {
                            if (!p.ActualGeneral1.Contains("sujiang"))
                            {
                                p.ActualGeneral1 = p.General1 = p.Name.EndsWith("6") ? "sujiang" : "sujiangf";
                                p.HeadSkinId = 0;
                                p.PlayerGender = p.Name.EndsWith("6") ? Gender.Male : Gender.Female;
                                room.BroadcastProperty(p, "HeadSkinId");
                                room.BroadcastProperty(p, "PlayerGender");
                                room.BroadcastProperty(p, "General1");

                                p.MaxHp = 3;
                                room.BroadcastProperty(p, "MaxHp");
                            }
                            room.RevivePlayer(p);
                            room.Recover(p, 3);
                            room.DrawCards(p, 4, Name);
                        }
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                if (player.Phase == PlayerPhase.Start)
                {
                    bool archer = false;
                    foreach (Player p in RoomLogic.FindPlayersBySkillName(room, "wall"))
                    {
                        if (!p.Removed)
                        {
                            archer = true;
                            break;
                        }
                    }

                    if (archer)
                    {
                        room.Speak(player, "万箭齐发！！");
                        WrappedCard card = new WrappedCard(ArcheryAttack.ClassName) { Skill = Name };
                        room.UseCard(new CardUseStruct(card, ask_who, new List<Player>()));
                    }
                }
                else
                {
                    room.SendCompulsoryTriggerLog(player, Name);
                    int count = 0;
                    foreach (Player p in room.GetOtherPlayers(player))
                        if (p.Camp == Game3v3Camp.S_CAMP_COOL)
                            count++;

                    room.Speak(player, "吾等守城，无人可破！");
                    int first = 1;
                    List<Player> targets = new List<Player>();
                    foreach (Player p in room.GetAlivePlayers())
                        if (p.Camp == Game3v3Camp.S_CAMP_WARM && p.ActualGeneral1 != "wall")
                            targets.Add(p);

                    if (count > targets.Count)
                        first = count - targets.Count + 1;
                    room.SortByActionOrder(ref targets);
                    foreach (Player p in targets)
                    {
                        int draw = p == player ? first : 1;
                        if (p.Alive) room.DrawCards(p, draw, Name);
                        count -= draw;
                        if (count <= 0) break;
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.EventPhaseProceeding && data is int count)
            {
                foreach (Player p in room.GetOtherPlayers(player))
                {
                    if (p.Camp == Game3v3Camp.S_CAMP_WARM && !p.Removed && p.ActualGeneral1 != "wall" && p.ActualGeneral1 != "sujiang" && p.ActualGeneral1 != "sujiangf")
                    {
                        count++;
                        room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, p.Name, player.Name);
                    }
                }
                data = count;
            }
            else if (triggerEvent == TriggerEvent.HpChanging && data is int hp && hp < 0)
            {
                if (player.GetMark("tianren_invalid") >= 3)
                {
                    room.Speak(player, "哈哈！金刚不坏！");
                    return true;
                }
                if (player.GetMark("tianren_invalid") - hp > 3)
                    hp = player.GetMark("tianren_invalid") - 3;
                player.AddMark("tianren_invalid", -hp);
                if (hp == 0)
                {
                    room.Speak(player, "哈哈！金刚不坏！");
                    return true;
                }
                data = hp;
            }

            return false;
        }

        private void ChangeGeneral(Room room, Player target)
        {
            room.RevivePlayer(target);
            if (!string.IsNullOrEmpty(target.DuanChang))
            {
                target.DuanChang = string.Empty;
                room.BroadcastProperty(target, "DuanChang");
            }

            List<string> wei_general = new List<string> { "xuhuang_jx", "manchong", "litong", "yuejin", "wenpin" };
            wei_general.RemoveAll(t => room.UsedGeneral.Contains(t));
            if (wei_general.Count > 1)
            {
                Shuffle.shuffle(ref wei_general);
                string to_general = wei_general[0];
                string from_general = target.ActualGeneral1;

                room.HandleUsedGeneral(to_general);
                target.ActualGeneral1 = target.General1 = to_general;
                target.HeadSkinId = 0;
                target.PlayerGender = Gender.Male;
                room.BroadcastProperty(target, "HeadSkinId");
                room.BroadcastProperty(target, "PlayerGender");
                room.BroadcastProperty(target, "General1");

                target.MaxHp = 4;
                room.BroadcastProperty(target, "MaxHp");
                room.Recover(target, 4);

                if (Shuffle.random(1, 2))
                    room.Speak(target, "将军莫慌，援军来也!");
                else
                    room.Speak(target, "吾等前来助将军一臂之力");

                int draw = 4 - target.HandcardNum;
                if (draw > 0) room.DrawCards(target, draw, Name);

                List<string> skills = target.GetSkills(true, false);
                foreach (string skill in skills)
                {
                    Skill _s = Engine.GetSkill(skill);
                    if (_s != null && !_s.Attached_lord_skill)
                        room.DetachSkillFromPlayer(target, skill, false, target.GetAcquiredSkills().Contains(skill), true);
                }

                foreach (string skill in Engine.GetGeneralRelatedSkills(to_general, room.Setting.GameMode))
                {
                    room.AddSkill2Game(skill);
                }

                foreach (string skill_name in Engine.GetGeneralSkills(to_general, room.Setting.GameMode, true))
                {
                    room.AddSkill2Game(skill_name);
                    room.AddPlayerSkill(target, skill_name);
                }

                room.SendPlayerSkillsToOthers(target);
                room.FilterCards(target, target.GetCards("he"), true);
            }
        }
    }

    public class TianrenPro : ProhibitSkill
    {
        public TianrenPro() : base("#tianren_cr") { }
        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null)
        {
            if (room.Setting.GameMode == "SouthCountry")
            {
                if (from != null && to != null && card.Name == ArcheryAttack.ClassName && from.Camp == to.Camp)
                    return true;
                else if (to != null && to.General1 == "wall" && (card.Name == HoardUp.ClassName || card.Name == Reinforcement.ClassName || card.Name == Peach.ClassName || card.Name == IronChain.ClassName || card.Name == GDFighttogether.ClassName))
                    return true;
            }

            return false;
        }
    }

    public class TianrenTar : TargetModSkill
    {
        public TianrenTar() : base("#tianren-tar", false) { }
        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            if (room.Setting.GameMode == "SouthCountry" && from != null && from.Camp == Game3v3Camp.S_CAMP_WARM && card.Name.Contains(Slash.ClassName) && !card.IsVirtualCard())
            {
                foreach (Player p in room.GetAlivePlayers())
                    if (p.Camp == Game3v3Camp.S_CAMP_WARM && RoomLogic.PlayerHasSkill(room, p, "tianren_cr"))
                        return true;
            }
            return false;
        }
    }

    public class Revive : TriggerSkill
    {
        public Revive() : base("#zhouyu-reivive")
        {
            events.Add(TriggerEvent.AskForPeaches);
            skill_type = SkillType.Replenish;
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.AskForPeaches && data is DyingStruct dying && dying.Who == player && player.Alive && player.Camp == Game3v3Camp.S_CAMP_COOL && !room.ContainsTag(Name))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }
        
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player pangtong, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(pangtong, Name);
            room.SetTag(Name, true);
            room.Recover(pangtong, pangtong.MaxHp - pangtong.Hp);
            if (pangtong.Chained)
                room.SetPlayerChained(pangtong, false);

            if (!pangtong.FaceUp)
                room.TurnOver(pangtong);

            foreach (Player p in room.GetAlivePlayers())
                if (p.Alive && p.Camp == pangtong.Camp)
                    room.DrawCards(p, 3, Name);

            return false;
        }
    }

    public class Cuirui : ZeroCardViewAsSkill
    {
        public Cuirui() : base("cuirui")
        {
            limit_mark = "@cuirui";
            skill_type = SkillType.Attack;
            frequency = Frequency.Limited;
        }
        public override bool IsEnabledAtPlay(Room room, Player player) => player.GetMark(limit_mark) > 0;
        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(CuiruiCard.ClassName) { Skill = Name };
    }

    public class CuiruiCard : SkillCard
    {
        public static string ClassName = "CuiruiCard";
        public CuiruiCard() : base(ClassName) { }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
            => targets.Count < Self.Hp && to_select != Self && !to_select.IsKongcheng() && RoomLogic.CanGetCard(room, Self, to_select, "h");
        public override void OnUse(Room room, CardUseStruct card_use)
        {
            room.SetPlayerMark(card_use.From, "@cuirui", 0);
            room.BroadcastSkillInvoke("cuirui", card_use.From, card_use.Card.SkillPosition);
            room.DoSuperLightbox(card_use.From, card_use.Card.SkillPosition, "cuirui");
            base.OnUse(room, card_use);
        }

        public override void OnEffect(Room room, CardEffectStruct effect)
        {
            int id = room.AskForCardChosen(effect.From, effect.To, "h", "cuirui", false, HandlingMethod.MethodGet);
            room.ObtainCard(effect.From, id, false);
        }
    }

    public class Liewei : TriggerSkill
    {
        public Liewei() : base("liewei")
        {
            events.Add(TriggerEvent.Dying);
            skill_type = SkillType.Replenish;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                if (p.Phase != PlayerPhase.NotActive)
                    triggers.Add(new TriggerStruct(Name, p));
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(ask_who, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.DrawCards(ask_who, 1, Name);
            return false;
        }
    }
}