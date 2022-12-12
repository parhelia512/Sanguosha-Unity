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
               
            };
            skill_cards = new List<FunctionCard>
            {
            };
            related_skills = new Dictionary<string, List<string>>
            {
                { "moushi", new List<string> { "#moushi-draw" } },
            };
        }
    }

    public class Wall : TriggerSkill
    {
        public Wall() : base("wall")
        {
            events = new List<TriggerEvent> { TriggerEvent.RoundStart, TriggerEvent.HpRecover };
            frequency = Frequency.Compulsory;
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
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.RoundStart)
            {
                room.SendCompulsoryTriggerLog(ask_who, Name);
                foreach (Player p in room.GetAlivePlayers())
                    if (p.Camp == Game3v3Camp.S_CAMP_WARM && !p.Removed)
                        room.Recover(p);
            }
            else
            {
                player.Removed = false;
                room.BroadcastProperty(player, "Removed");
            }

            return false;
        }
    }

    public class TianrenCR : TriggerSkill
    {
        public TianrenCR() : base("tianren_cr")
        {
            events = new List<TriggerEvent> { TriggerEvent.Dying, TriggerEvent.RoundStart, TriggerEvent.EventPhaseChanging };
            frequency = Frequency.Compulsory;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.Dying)
            {

            }
            else if (triggerEvent == TriggerEvent.RoundStart && data is int round && round > 1) //每轮开始时万箭齐发
            {
                Player ask_who = RoomLogic.FindPlayerBySkillName(room, Name);
                if (ask_who != null)
                    triggers.Add(new TriggerStruct(Name, ask_who));
            }
            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.Dying)
            {

            }
            else if (triggerEvent == TriggerEvent.RoundStart)
            {
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.Camp == Game3v3Camp.S_CAMP_NONE && p.Removed && p.General1 != "wall")
                    {

                    }
                }

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
                    WrappedCard card = new WrappedCard(ArcheryAttack.ClassName);
                    room.UseCard(new CardUseStruct(card, ask_who, new List<Player>()));
                }
            }

            return false;
        }
    }

    public class TianrenPro : ProhibitSkill
    {
        public TianrenPro() : base("#tianren_cr") { }
        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null) => from != null && to != null && card.Name == ArcheryAttack.ClassName && from.Camp == to.Camp;
    }
}