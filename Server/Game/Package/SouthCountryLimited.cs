using CommonClass;
using CommonClass.Game;
using CommonClassLibrary;
using SanguoshaServer.Game;
using System;
using System.Collections.Generic;
using static CommonClass.Game.Player;

namespace SanguoshaServer.Package
{
    public class SountCountryLimited : GeneralPackage
    {
        public SountCountryLimited() : base("SountCountryLimited")
        {
            skills = new List<Skill> {
               new Wall(),
               new TianrenCR(),
               new TianrenPro(),
            };
            skill_cards = new List<FunctionCard>
            {
            };
            related_skills = new Dictionary<string, List<string>>
            {
                { "tianren_cr", new List<string> { "#tianren_cr", "#zhouyu-reivive" } },
            };
        }
    }

    public class Wall : TriggerSkill
    {
        public Wall() : base("wall")
        {
            events = new List<TriggerEvent> { TriggerEvent.RoundStart, TriggerEvent.HpRecover, TriggerEvent.CardsMoveOneTime, TriggerEvent.GameStart };
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.GameStart && base.Triggerable(player, room))
                room.AbolishJudgingArea(player, Name);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.RoundStart)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    if (!p.Removed)
                        return new TriggerStruct(Name, p);
            }
            else if (triggerEvent == TriggerEvent.HpRecover && player.Alive && player.Hp >= 3 && player.Removed)
            {
                return new TriggerStruct(Name, player);
            }
            else if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && base.Triggerable(move.To, room))
            {
                return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.RoundStart)
            {
                room.SendCompulsoryTriggerLog(ask_who, Name);
                foreach (Player p in room.GetAlivePlayers())
                    if (p.Camp == Game3v3Camp.S_CAMP_WARM && !p.Removed && p.ActualGeneral1 != "wall")
                        room.Recover(p);
            }
            else if (triggerEvent == TriggerEvent.HpRecover)
            {
                player.Removed = false;
                room.BroadcastProperty(player, "Removed");
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
             TriggerEvent.HpLost, TriggerEvent.PostHpReduced, TriggerEvent.EventPhaseProceeding };
            frequency = Frequency.Compulsory;
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
                Player ask_who = RoomLogic.FindPlayerBySkillName(room, Name);                       //轮次开始时恢复士兵，士兵令城墙回血
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
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player.HasFlag(Name))
            {
                triggers.Add(new TriggerStruct(Name, player));
            }
            else if (triggerEvent == TriggerEvent.PostHpReduced && player.Hp <= 0 && player.Camp == Game3v3Camp.S_CAMP_WARM && player.General1 != "caoren")
            {
                Player ask_who = RoomLogic.FindPlayerBySkillName(room, Name);
                if (ask_who != null)
                    triggers.Add(new TriggerStruct(Name, ask_who));
            }
            else if (triggerEvent == TriggerEvent.EventPhaseProceeding && base.Triggerable(player, room) && player.Phase == PlayerPhase.Draw)
            {
                triggers.Add(new TriggerStruct(Name, player));
            }

            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.Dying)      //第一次濒死时回血摸牌
            {
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

                if (player.Chained)
                    room.SetPlayerChained(player, false);

                if (!player.FaceUp)
                    room.TurnOver(player);

                if (!player.Removed)
                {
                    player.Removed = true;
                    room.BroadcastProperty(player, "Removed");
                }
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging)
            {
                if (player.Removed)      //回合结束后，重新返回游戏
                {
                    player.Removed = false;
                    room.BroadcastProperty(player, "Removed");
                }

                foreach (Player target in room.GetOtherPlayers(player))     //士兵变援军
                {
                    if (target.Camp == Game3v3Camp.S_CAMP_WARM && (target.General1 == "sujiang" || target.General1 == "sujiangf") && player.GetMark("back_up") < 4)
                    {
                        player.AddMark("back_up");
                        ChangeGeneral(room, target);
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.RoundStart)           //每轮开始时，如城墙边有未移除的士兵，回复1点体力
            {
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.Camp == Game3v3Camp.S_CAMP_WARM && p.General1 == "wall" && p.IsWounded())
                    {
                        Player last = room.GetLastAlive(p, 1, false);
                        if (last != null && (last.ActualGeneral1 == "sujiang" || last.ActualGeneral1 == "sujiangf"))
                            room.Recover(p);
                    }
                }
                foreach (Player p in room.GetAlivePlayers())            //每轮开始时，如士兵被移除，则变为援军加入
                {
                    if (p.Camp == Game3v3Camp.S_CAMP_WARM && p.Removed && (p.ActualGeneral1 == "sujiang" || p.ActualGeneral1 == "sujiangf"))
                    {
                        if (player.GetMark("back_up") < 4 && p.GetMark("reinforcement") == 0)
                        {
                            player.AddMark("back_up");
                            ChangeGeneral(room, p);
                        }
                        else if (p.FaceUp)
                        {

                            if (p.IsWounded())
                            {
                                int count = p.MaxHp - p.Hp;
                                room.Recover(p, count);
                            }

                            int draw = 4 - p.HandcardNum;
                            if (draw > 0) room.DrawCards(p, draw, Name);

                            p.SetMark("reinforcement", 0);
                            p.Removed = false;
                            room.BroadcastProperty(p, "Removed");
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

                    room.DrawCards(player, count, Name);
                }
            }
            else if (triggerEvent == TriggerEvent.PostHpReduced)
            {
                if (!player.Removed)
                {
                    player.Removed = true;
                    room.BroadcastProperty(player, "Removed");
                }

                if (player.ActualGeneral1 != "wall" && player.ActualGeneral1 != "sujiang" && player.ActualGeneral1 != "sujiangf")       //援军被击败变回士兵
                {
                    player.AddMark("reinforcement");

                    string to_general = player.ActualGeneral2 == "sujiang" ? "sujiangf" : "sujiang";
                    string from_general = player.ActualGeneral1;
                    if (!from_general.Contains("sujiang"))
                        room.DoAnimate(AnimateType.S_ANIMATE_REMOVE, player.Name, true.ToString());

                    //room.HandleUsedGeneral("guansuo");
                    player.ActualGeneral1 = player.General1 = to_general;
                    player.HeadSkinId = 0;
                    player.PlayerGender = player.ActualGeneral1 == "sujiang" ?  Gender.Male : Gender.Female;
                    room.BroadcastProperty(player, "HeadSkinId");
                    room.BroadcastProperty(player, "PlayerGender");
                    room.BroadcastProperty(player, "General1");
                    
                    player.MaxHp = 3;
                    room.BroadcastProperty(player, "MaxHp");

                    List<string> skills = player.GetSkills(true, false);
                    foreach (string skill in skills)
                    {
                        Skill _s = Engine.GetSkill(skill);
                        if (_s != null && !_s.Attached_lord_skill)
                            room.DetachSkillFromPlayer(player, skill, false, player.GetAcquiredSkills().Contains(skill), true);
                    }
                }
                room.ThrowAllCards(player);
                return true;
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

            return false;
        }

        private void ChangeGeneral(Room room, Player target)
        {
            if (target.GetMark("@duanchang") > 0)
            {
                target.DuanChang = string.Empty;
                room.BroadcastProperty(target, "DuanChang");
                room.SetPlayerMark(target, "@duanchang", 0);
            }

            List<string> wei_general = new List<string> { "xuhuang_jx", "manchong", "litong", "yuejin", "wenpin" };
            wei_general.RemoveAll(t => room.UsedGeneral.Contains(t));
            if (wei_general.Count > 1)
            {
                Shuffle.shuffle(ref wei_general);
                string to_general = wei_general[0];
                string from_general = target.ActualGeneral1;
                if (!from_general.Contains("sujiang"))
                {
                    room.DoAnimate(AnimateType.S_ANIMATE_REMOVE, target.Name, true.ToString());
                    room.HandleUsedGeneral("-" + from_general);
                }

                //room.HandleUsedGeneral("guansuo");
                target.ActualGeneral1 = target.General1 = to_general;
                target.HeadSkinId = 0;
                target.PlayerGender = Gender.Male;
                room.BroadcastProperty(target, "HeadSkinId");
                room.BroadcastProperty(target, "PlayerGender");
                room.BroadcastProperty(target, "General1");
                
                target.MaxHp = 4;
                room.BroadcastProperty(target, "MaxHp");
                if (target.IsWounded())
                {
                    int count = target.MaxHp - target.Hp;
                    room.Recover(target, count);
                }

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
                    if (!room.Skills.Contains(skill))
                    {
                        room.Skills.Add(skill);
                        Skill main = Engine.GetSkill(skill);
                        if (main is TriggerSkill tskill)
                            room.RoomThread.AddTriggerSkill(tskill);
                    }

                    foreach (Skill _skill in Engine.GetRelatedSkills(skill))
                    {
                        if (!room.Skills.Contains(_skill.Name))
                        {
                            room.Skills.Add(_skill.Name);
                            if (_skill is TriggerSkill tskill)
                                room.RoomThread.AddTriggerSkill(tskill);
                        }
                    }
                }

                foreach (string skill_name in Engine.GetGeneralSkills(to_general, room.Setting.GameMode, true))
                {
                    if (!room.Skills.Contains(skill_name))
                    {
                        room.Skills.Add(skill_name);
                        Skill main = Engine.GetSkill(skill_name);
                        if (main is TriggerSkill tskill)
                            room.RoomThread.AddTriggerSkill(tskill);
                    }

                    foreach (Skill _skill in Engine.GetRelatedSkills(skill_name))
                    {
                        if (!room.Skills.Contains(_skill.Name))
                        {
                            room.Skills.Add(_skill.Name);
                            if (_skill is TriggerSkill tskill)
                                room.RoomThread.AddTriggerSkill(tskill);
                        }
                    }

                    room.AddPlayerSkill(target, skill_name);
                }

                room.SendPlayerSkillsToOthers(target);
                room.FilterCards(target, target.GetCards("he"), true);

                if (target.Removed)
                {
                    target.Removed = false;
                    room.BroadcastProperty(target, "Removed");
                }
            }
        }
    }

    public class TianrenPro : ProhibitSkill
    {
        public TianrenPro() : base("#tianren_cr") { }
        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null)
        {
            if (from != null && to != null && card.Name == ArcheryAttack.ClassName && from.Camp == to.Camp)
                return true;
            else if (to != null && to.General1 == "wall" && (card.Name == HoardUp.ClassName || card.Name == Reinforcement.ClassName || card.Name == Peach.ClassName))
                return true;

            return false;
        }
    }

    public class Revive : TriggerSkill
    {
        public Revive() : base("#zhouyu-reivive")
        {
            events.Add(TriggerEvent.AskForPeaches);
            skill_type = SkillType.Replenish;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.AskForPeaches && player.Alive && player.Camp == Game3v3Camp.S_CAMP_COOL && !room.ContainsTag(Name))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            return base.Cost(triggerEvent, room, player, ref data, ask_who, info);
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player pangtong, ref object data, Player ask_who, TriggerStruct info)
        {
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
}