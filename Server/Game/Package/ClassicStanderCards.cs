using CommonClass.Game;
using CommonClassLibrary;
using SanguoshaServer.Game;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace SanguoshaServer.Package
{
    public class ClassicStanderCards : CardPackage
    {
        public ClassicStanderCards() : base("ClassicStanderCards")
        {
            skills = new List<Skill>
            {
                new ClassicBladeSkill(),
                new BladeTag(),
                new ClassicHalberdSkill(),
                new SaberSkill(),  //七宝刀
                new LanceSkill(),
                new LightningSummonerSkill(),
                new PosionedDaggerSkill(),
                new QuenchedKnifeSkill(),
                new QuenchedKnifeTM(),
                new WaterSwordSkill(),
                new Comb1Skill(),
                new Comb2Skill(),
                new Comb3Skill(),
                new BreachingtowerSkill(),
                new BreachingFix(),
                new TrebuchetSkill(),
                new TrebuchetTarSkill(),
            };
            cards = new List<FunctionCard> {
                new ClassicBlade(),
                new ClassicHalberd(),
                new Saber(),            //七宝刀
                new HiddenDagger(),     //笑里藏刀
                new HoneyTrap(),        //美人计
                new Lance(),            //红缎枪
                new LightningSummoner(),//天雷刃
                new PosionedDagger(),   //混毒弯匕
                new QuenchedKnife(),    //烈淬刀
                new WaterSword(),       //水波剑
                new Comb1(),
                new Comb2(),
                new Comb3(),
                new Breachingtower(),
                new Trebuchet(),
            };

            related_skills = new Dictionary<string, List<string>>
            {
                { ClassicBlade.ClassName, new List<string> { "#blade-target-mod" } },
                { QuenchedKnife.ClassName, new List<string> { "#QuenchedKnife-tm" } },
                { Breachingtower.ClassName, new List<string> { "#Breachingtower", "#Trebuchet-tar" } },
            };
        }
    }

    public class ClassicBlade : Weapon
    {
        public static string ClassName = "ClassicBlade";
        public ClassicBlade() : base(ClassName, 3) { }
    }

    public class ClassicBladeSkill : WeaponSkill
    {
        public ClassicBladeSkill() : base(ClassicBlade.ClassName)
        {
            events = new List<TriggerEvent> { TriggerEvent.SlashMissed };
            frequency = Frequency.Compulsory;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            SlashEffectStruct effect = (SlashEffectStruct)data;
            if (!effect.To.Alive || effect.To.GetMark("Equips_of_Others_nullified_to_You") > 0)
                return false;

            player.SetFlags("slashTargetFix");
            player.SetFlags("slashTargetFixToOne");
            room.SetCardFlag(player.Weapon.Key, "using");
            effect.To.SetFlags("SlashAssignee");

            WrappedCard slash = room.AskForUseCard(player, FunctionCard.RespondType.Slash, "Slash:ClassicBlade", "@blade:" + effect.To.Name, null, -1, FunctionCard.HandlingMethod.MethodUse, false);
            if (slash == null)
            {
                player.SetFlags("-slashTargetFix");
                player.SetFlags("-slashTargetFixToOne");
                effect.To.SetFlags("-SlashAssignee");
                if (player.HasWeapon(Name))
                    room.SetCardFlag(player.Weapon.Key, "-using");
            }

            return false;
        }
    }

    public class BladeTag : TargetModSkill
    {
        public BladeTag() : base("#blade-target-mod", false) {}
        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseStruct.CardUseReason reason, string pattern)
        {
            if (from.HasWeapon("ClassicBlade") && reason == CardUseStruct.CardUseReason.CARD_USE_REASON_RESPONSE_USE
                && (room.GetRoomState().GetCurrentResponseSkill() == "ClassicBlade" || pattern == "Slash:ClassicBlade"))
                return true;

            return false;
        }
    }

    public class ClassicHalberd : Weapon
    {
        public static string ClassName = "ClassicHalberd";
        public ClassicHalberd() : base(ClassName, 4) { }
    }

    public class ClassicHalberdSkill : TargetModSkill
    {
        public ClassicHalberdSkill() : base(ClassicHalberd.ClassName) { }

        public override int GetExtraTargetNum(Room room, Player from, WrappedCard card)
        {
            if (from.HasWeapon(Name) && card.SubCards.Count > 0 && from.IsLastHandCard(card, true) && !card.SubCards.Contains(from.Weapon.Key))
                return 2;

            return 0;
        }
    }

    public class Saber : Weapon
    {
        public static string ClassName = "Saber";
        public Saber() : base(ClassName, 2) { }
    }
    public class SaberSkill : WeaponSkill
    {
        public SaberSkill() : base(Saber.ClassName)
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen, TriggerEvent.DamageCaused };
            frequency = Frequency.Compulsory;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use && base.Triggerable(player, room) && use.Card.Name.Contains(Slash.ClassName) && use.To.Count > 0)
                return new TriggerStruct(Name, player, use.To);
            else if (triggerEvent == TriggerEvent.DamageCaused && data is DamageStruct damage && base.Triggerable(player, room) && !damage.To.IsWounded()
                && damage.To.Alive && damage.Card != null && damage.Card.Name.Contains(Slash.ClassName) && !damage.Chain && !damage.Transfer)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SetEmotion(ask_who, "saber");
            Thread.Sleep(400);
            return info;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player target, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use)
            {
                target.AddQinggangTag(RoomLogic.CardToString(room, use.Card));
            }
            else if (triggerEvent == TriggerEvent.DamageCaused && data is DamageStruct damage)
            {
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, damage.To.Name);
                LogMessage log = new LogMessage
                {
                    Type = "#AddDamage",
                    From = ask_who.Name,
                    To = new List<string> { damage.To.Name },
                    Arg = Name,
                    Arg2 = (++damage.Damage).ToString()
                };

                room.SendLog(log);
                data = damage;
            }

            return false;
        }
    }

    public class HiddenDagger : TrickCard
    {
        public static string ClassName = "HiddenDagger";
        public override string GetSubtype() => "single_target_trick";
        public HiddenDagger() : base(ClassName)
        {
        }

        public override void OnEffect(Room room, CardEffectStruct effect)
        {
            Player player = effect.From, target = effect.To;
            int count = target.GetLostHp();
            if (count > 0) room.DrawCards(target, new DrawCardStruct(count, player, Name));
            if (player.Alive && target.Alive)
                room.Damage(new DamageStruct(effect.Card, player, target));
        }
    }

    public class HoneyTrap : TrickCard
    {
        public static string ClassName = "HoneyTrap";
        public override string GetSubtype() => "single_target_trick";
        public HoneyTrap() : base(ClassName)
        {
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return base.TargetFilter(room, targets, to_select, Self, card) && to_select.IsMale() && !to_select.IsKongcheng();
        }

        public override void OnEffect(Room room, CardEffectStruct effect)
        {
            Player player = effect.From, target = effect.To;
            List<Player> players = new List<Player>();
            foreach (Player p in room.GetAlivePlayers())
                if (p.IsFemale()) players.Add(p);

            if (players.Count > 0)
            {
                room.SortByActionOrder(ref players);
                foreach (Player p in players)
                {
                    if (target.Alive && !target.IsKongcheng() && RoomLogic.CanGetCard(room, p, target, "h"))
                    {
                        int id = room.AskForCardChosen(p, target, "h", Name, false, HandlingMethod.MethodGet);
                        List<int> ids = new List<int> { id };
                        room.ObtainCard(p, ref ids, new CardMoveReason(MoveReason.S_REASON_EXTRACTION, p.Name, target.Name, Name, string.Empty), false);

                        if (p != player && p.Alive && player.Alive)
                        {
                            ids = p.GetCards("h");
                            if (ids.Count > 1)
                                ids = room.AskForExchange(p, Name, 1, 1, "@HoneyTrap:" + player.Name, string.Empty, ".", string.Empty);

                            if (ids.Count > 0)
                                room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, p.Name, player.Name, Name, string.Empty), false);
                        }
                    }
                }
            }

            if (player.Alive && target.Alive && player.HandcardNum != target.HandcardNum)
            {
                if (player.HandcardNum < target.HandcardNum)
                    room.Damage(new DamageStruct(effect.Card, player, target));
                else
                    room.Damage(new DamageStruct(effect.Card, target, player));
            }
        }
    }

    public class Lance : Weapon
    {
        public static string ClassName = "Lance";
        public Lance() : base(ClassName, 3) { }
        public override void OnUninstall(Room room, Player player, WrappedCard card)
        {
            player.SetFlags("-Lance");
        }
    }

    public class LanceSkill : WeaponSkill
    {
        public LanceSkill() : base(Lance.ClassName)
        {
            events= new List<TriggerEvent> { TriggerEvent.Damage, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Recover;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == Player.PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                    if (p.HasFlag(Name))
                        p.SetFlags("-Lance");
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && !player.HasFlag(Name) && data is DamageStruct damage && damage.Card != null && damage.Card.Name.Contains(Slash.ClassName))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name))
                return info;

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            player.SetFlags(Name);
            JudgeStruct judge = new JudgeStruct
            {
                Good = true,
                //Pattern = ".|red",
                PlayAnimation = false,
                Reason = Name,
                Who = player,
                Negative = false
            };
            
            room.SetCardFlag(player.Weapon.Key, "using");
            room.Judge(ref judge);
            if (player.HasWeapon(Name))
                room.SetCardFlag(player.Weapon.Key, "-using");

            if (player.Alive)
            {
                if (WrappedCard.IsRed(judge.Card.Suit))
                {
                    if (player.IsWounded())
                    {
                        RecoverStruct recover = new RecoverStruct
                        {
                            Recover = 1,
                            Who = player
                        };
                        room.Recover(player, recover, true);
                    }
                }
                else
                {
                    room.DrawCards(player, 2, Name);
                }
            }

            return false;
        }
    }

    public class LightningSummoner : Weapon
    {
        public static string ClassName = "LightningSummoner";
        public LightningSummoner() : base(ClassName, 4) { }
    }

    public class LightningSummonerSkill : WeaponSkill
    {
        public LightningSummonerSkill() : base(LightningSummoner.ClassName)
        {
            events.Add(TriggerEvent.TargetChosen);
            skill_type = SkillType.Attack;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName))
                return new TriggerStruct(Name, player, use.To);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player target, ref object data, Player ask_who, TriggerStruct info)
        {
            if (target.Alive)
            {
                bool invoke = room.AskForSkillInvoke(ask_who, Name, target);
                if (invoke) return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player target, ref object data, Player ask_who, TriggerStruct info)
        {
            if (target.Alive && ask_who.Alive)
            {
                JudgeStruct judge = new JudgeStruct
                {
                    Good = true,
                    Pattern = ".|spade#.|club",
                    PlayAnimation = true,
                    Reason = Name,
                    Who = target,
                    Negative = true
                };

                room.SetCardFlag(ask_who.Weapon.Key, "using");
                room.Judge(ref judge);
                if (ask_who.HasWeapon(Name))
                    room.SetCardFlag(ask_who.Weapon.Key, "-using");

                if (judge.IsEffected() && target.Alive)
                {
                    if (judge.Card.Suit == WrappedCard.CardSuit.Spade)
                        room.Damage(new DamageStruct(Name, null, target, 3, DamageStruct.DamageNature.Thunder));
                    else
                    {
                        room.Damage(new DamageStruct(Name, null, target, 1, DamageStruct.DamageNature.Thunder));
                        if (ask_who.Alive && ask_who.IsWounded())
                        {
                            RecoverStruct recover = new RecoverStruct
                            {
                                Recover = 1
                            };
                            room.Recover(ask_who, recover, true);
                        }
                        if (ask_who.Alive)
                            room.DrawCards(ask_who, 1, Name);
                    }
                }
            }

            return false;
        }
    }

    public class PosionedDagger : Weapon
    {
        public static string ClassName = "PosionedDagger";
        public PosionedDagger() : base(ClassName, 1) { }
        public override void OnUninstall(Room room, Player player, WrappedCard card)
        {
            player.SetMark(Name, 0);
        }
    }

    public class PosionedDaggerSkill : WeaponSkill
    {
        public PosionedDaggerSkill() : base(PosionedDagger.ClassName)
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Attack;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == Player.PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                    if (p.GetMark(Name) > 0)
                        p.SetMark(Name, 0);
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName) && player.GetMark(Name) < 5)
                return new TriggerStruct(Name, player, use.To);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player target, ref object data, Player ask_who, TriggerStruct info)
        {
            if (ask_who.GetMark(Name) < 5 && ask_who.Alive && target.Alive)
            {
                bool invoke = room.AskForSkillInvoke(ask_who, Name, target);
                if (invoke) return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player target, ref object data, Player ask_who, TriggerStruct info)
        {
            ask_who.AddMark(Name);
            if (target.Alive) room.LoseHp(target);

            return false;
        }
    }
    public class QuenchedKnife : Weapon
    {
        public static string ClassName = "QuenchedKnife";
        public QuenchedKnife() : base(ClassName, 2) { }
        public override void OnUninstall(Room room, Player player, WrappedCard card)
        {
            player.SetMark(Name, 0);
        }
    }

    public class QuenchedKnifeSkill : WeaponSkill
    {
        public QuenchedKnifeSkill() : base(QuenchedKnife.ClassName)
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageCaused, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Attack;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == Player.PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                    if (p.GetMark(Name) > 0)
                        p.SetMark(Name, 0);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.DamageCaused && base.Triggerable(player, room) && data is DamageStruct damage && damage.Card != null
                && damage.Card.Name.Contains(Slash.ClassName) && !damage.Transfer && !damage.Chain && !player.IsNude() && player.GetMark(Name) < 2)
            {
                return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                room.SetCardFlag(player.Weapon.Key, "using");
                room.SetTag(Name, data);
                //List<int> ids = room.AskForExchange(player, Name, 1, 0, "@QuenchedKnife:" + damage.To.Name, string.Empty, "Slash,Weapon!", string.Empty);
                if (room.AskForDiscard(player, Name, 1, 1, true, true, "@QuenchedKnife:" + damage.To.Name, true, null))
                {
                    room.RemoveTag(Name);
                    room.SetCardFlag(player.Weapon.Key, "-using");

                    return info;
                }
                room.SetCardFlag(player.Weapon.Key, "-using");
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            player.AddMark(Name);
            DamageStruct damage = (DamageStruct)data;
            LogMessage log = new LogMessage
            {
                Type = "#AddDamage",
                From = player.Name,
                To = new List<string> { damage.To.Name },
                Arg = Name,
                Arg2 = (++damage.Damage).ToString()
            };
            room.SendLog(log);
            data = damage;

            return false;
        }
    }

    public class QuenchedKnifeTM : TargetModSkill
    {
        public QuenchedKnifeTM() : base("#QuenchedKnife-tm", false)
        {
        }
        public override int GetResidueNum(Room room, Player from, WrappedCard card)
        {
            return from.HasWeapon("QuenchedKnife") ? 1 : 0;
        }
    }

    public class WaterSword : Weapon
    {
        public static string ClassName = "WaterSword";
        public WaterSword() : base(ClassName, 2) { }
        public override void OnUninstall(Room room, Player player, WrappedCard card)
        {
            if (player.Alive && player.HasWeapon(Name))
                player.SetFlags("WaterSwordRecover");

            player.SetMark(Name, 0);
        }
    }

    public class WaterSwordSkill : WeaponSkill
    {
        public WaterSwordSkill() : base(WaterSword.ClassName)
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging, TriggerEvent.CardTargetAnnounced, TriggerEvent.CardsMoveOneTime };
            skill_type = SkillType.Wizzard;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == Player.PlayerPhase.NotActive)
                foreach (Player p in room.GetAlivePlayers())
                    if (p.GetMark(Name) > 0)
                        p.SetMark(Name, 0);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && base.Triggerable(player, room) && player.GetMark(Name) < 2
                && data is CardUseStruct use && use.To.Count > 0 && use.Card.Name != Collateral.ClassName)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is Slash || fcard.IsNDTrick())
                    return new TriggerStruct(Name, player);
            }
            else if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null
                && move.From_places.Contains(Player.Place.PlaceEquip) && move.From.HasFlag("WaterSwordRecover"))
            {
                for (int i = 0; i < move.Card_ids.Count; i++)
                {
                    if (move.From_places[i] != Player.Place.PlaceEquip) continue;
                    WrappedCard card = Engine.GetRealCard(move.Card_ids[i]);
                    if (card.Name == Name)
                    {
                        if (!move.From.IsWounded())
                        {
                            move.From.SetFlags("-WaterSwordRecover");
                            return new TriggerStruct();
                        }
                        return new TriggerStruct(Name, move.From);
                    }
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                player.AddMark(Name);
                List<Player> targets = new List<Player>();
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (!use.To.Contains(p))
                    {
                        if (fcard.TargetFixed(use.Card) && fcard.Name == ExNihilo.ClassName)
                            targets.Add(p);
                        else if (!fcard.TargetFixed(use.Card) && fcard.TargetFilter(room, new List<Player>(), p, player, use.Card))
                            targets.Add(p);
                    }
                }

                if (targets.Count > 0)
                {
                    room.SetTag("extra_target_skill", data);
                    Player target = room.AskForPlayerChosen(player, targets, Name, string.Format("@WaterSword:::{0}", use.Card.Name), true, true, info.SkillPosition);
                    room.RemoveTag("extra_target_skill");
                    if (target != null)
                    {
                        use.To.Add(target);
                        LogMessage log = new LogMessage
                        {
                            Type = "$extra_target",
                            From = player.Name,
                            To = new List<string> { target.Name },
                            Card_str = RoomLogic.CardToString(room, use.Card),
                            Arg = Name
                        };
                        room.SendLog(log);
                        room.SortByActionOrder(ref use);
                        data = use;
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move)
            {
                for (int i = 0; i < move.Card_ids.Count; i++)
                {
                    if (move.From_places[i] != Player.Place.PlaceEquip) continue;
                    WrappedCard card = Engine.GetRealCard(move.Card_ids[i]);
                    if (card.Name == Name)
                    {
                        move.From.SetFlags("-WaterSwordRecover");

                        //room.SetEmotion(move.From, "silverlion");
                        //Thread.Sleep(400);
                        RecoverStruct recover = new RecoverStruct
                        {
                            Recover = 1,
                            Card = card
                        };
                        room.Recover(move.From, recover, true);

                        return false;
                    }
                }
            }

            return false;
        }
    }

    //琼梳

    public class Comb1 : Treasure
    {
        public static string ClassName = "Comb1";
        public Comb1() : base(ClassName) { }
        public override void OnInstall(Room room, Player player, WrappedCard card)
        {
            player.SetFlags("-Comb1");
            base.OnInstall(room, player, card);
        }
    }

    public class Comb1Skill : TreasureSkill
    {
        public Comb1Skill() : base(Comb1.ClassName)
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageInflicted };
            skill_type = SkillType.Defense;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is DamageStruct damage && player.GetCardCount(true) >= damage.Damage)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                int id = player.Treasure.Key;
                room.SetCardFlag(id, "using");
                room.SetTag("combo1", data);
                bool invoke = room.AskForDiscard(player, Name, damage.Damage, damage.Damage, true, true, "@comb1:::" + damage.Damage.ToString(), true, "head");
                room.RemoveTag("combo1");
                room.SetCardFlag(id, "-using");

                if (invoke) return info;
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            LogMessage log = new LogMessage
            {
                Type = "#damaged-prevent",
                From = player.Name,
                Arg = Name
            };
            room.SendLog(log);
            return true;
        }
    }

    //犀梳

    public class Comb2 : Treasure
    {
        public static string ClassName = "Comb2";
        public Comb2() : base(ClassName) { }
    }

    public class Comb2Skill : TreasureSkill
    {
        public Comb2Skill() : base("Comb2")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart };
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == Player.PlayerPhase.Start && (!player.IsSkipped(Player.PlayerPhase.Judge) || !player.IsSkipped(Player.PlayerPhase.Discard)))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            string choice;
            if (!player.IsSkipped(Player.PlayerPhase.Judge) && !player.IsSkipped(Player.PlayerPhase.Discard))
            {
                choice = room.AskForChoice(player, Name, "judge_phase+discard_phase+cancel", new List<string> { "@Comb2" }, null, info.SkillPosition);
                if (choice == "cancel") return new TriggerStruct();
            }
            else
            {
                choice = !player.IsSkipped(Player.PlayerPhase.Judge) ? "judge_phase" : "discard_phase";
                if (!room.AskForSkillInvoke(player, Name, "@Comb2-skip:::" + choice, info.SkillPosition))
                    return new TriggerStruct();
            }
            player.SetTag(Name, choice);
            return info;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.GetTag(Name) is string choice)
            {
                player.RemoveTag(Name);
                room.SkipPhase(player, choice == "judge_phase" ? Player.PlayerPhase.Judge : Player.PlayerPhase.Discard);
            }

            return false;
        }
    }

    //金梳

    public class Comb3 : Treasure
    {
        public static string ClassName = "Comb3";
        public Comb3() : base(ClassName) { }
    }

    public class Comb3Skill : TreasureSkill
    {
        public Comb3Skill() : base("Comb3")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseEnd };
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == Player.PlayerPhase.Play && player.HandcardNum < player.MaxHp)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            room.DrawCards(player, player.MaxHp - player.HandcardNum, Name);
            return false;
        }
    }

    //大攻车
    public class Breachingtower : Treasure
    {
        public static string ClassName = "Breachingtower";
        public Breachingtower() : base(ClassName) { }
        public override void OnUninstall(Room room, Player player, WrappedCard card)
        {
            player.SetMark("Breachingtower_draw", player.GetMark(Name));
            player.SetMark(Name, 0);
            player.SetMark("Breachingtower_target", 0);
            player.SetMark("Breachingtower_ignore", 0);
            player.SetMark("Breachingtower_discard", 0);
            room.RemovePlayerStringMark(player, Name);
            base.OnUninstall(room, player, card);
        }
    }

    public class BreachingtowerSkill : TreasureSkill
    {
        public BreachingtowerSkill() : base(Breachingtower.ClassName)
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.BeforeCardsMove,
                TriggerEvent.Damage, TriggerEvent.CardTargetAnnounced, TriggerEvent.TargetChosen };
            view_as_skill = new BreachingVS();
            frequency = Frequency.Compulsory;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.BeforeCardsMove && data is CardsMoveOneTimeStruct move)
            {
                if (move.From != null && move.From_places.Contains(Player.Place.PlaceEquip) && move.To_pile_name != "#virtual_cards")
                {
                    int catapult = -1, card_index = -1;
                    foreach (int id in move.Card_ids)
                    {
                        int index = move.Card_ids.IndexOf(id);
                        if (move.From_places[index] == Player.Place.PlaceEquip && Engine.GetRealCard(id).Name == Name)
                        {
                            catapult = id;
                            card_index = index;
                            break;
                        }
                    }

                    if (catapult > -1)
                    {
                        move.From_places.RemoveAt(card_index);
                        move.Card_ids.Remove(catapult);
                        if (move.Reason.Card != null)
                        {
                            List<int> subs = room.GetSubCards(move.Reason.Card);
                            subs.RemoveAll(t => t == catapult);
                        }
                        data = move;

                        Player holder = room.Players[0];
                        room.AddToPile(holder, "#virtual_cards", catapult, false);
                    }
                }
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent ==  TriggerEvent.EventPhaseStart && player.Phase == Player.PlayerPhase.Play && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use && use.Card.GetSkillName() == Name && player.GetMark("Breachingtower_target") > 0)
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct _use && _use.Card.GetSkillName() == Name && _use.To.Count > 0 && player.GetMark("Breachingtower_ignore") > 0)
                return new TriggerStruct(Name, player, _use.To);
            else if (triggerEvent == TriggerEvent.Damage && data is DamageStruct damage && damage.Card != null && damage.Card.GetSkillName() == Name && player.Alive && !damage.Transfer
                && !damage.Chain && damage.To.Alive && !damage.To.IsNude() && RoomLogic.CanDiscard(room, player, damage.To, "he"))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                List<Player> targets = new List<Player>();
                foreach (Player p in room.GetOtherPlayers(player))
                {
                    if (!use.To.Contains(p) && Slash.Instance.ExtratargetFilter(room, use.To, p, player, use.Card))
                        targets.Add(p);
                }

                if (targets.Count > 0)
                {
                    room.SetTag("extra_target_skill", data);                   //for AI
                    List<Player> players = room.AskForPlayersChosen(player, targets, Name, 0, player.GetMark("Breachingtower_target"),
                        string.Format("@Breachingtower-extra:::{0}:{1}", use.Card.Name, player.GetMark("Breachingtower_target")), true, info.SkillPosition);
                    room.RemoveTag("extra_target_skill");
                    if (players.Count > 0)
                    {
                        room.NotifySkillInvoked(player, Name);
                        LogMessage log = new LogMessage
                        {
                            Type = "$extra_target",
                            From = player.Name,
                            Card_str = RoomLogic.CardToString(room, use.Card),
                            Arg = Name
                        };
                        log.SetTos(players);
                        room.SendLog(log);

                        use.To.AddRange(players);
                        room.SortByActionOrder(ref use);
                        data = use;
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                WrappedCard card = room.AskForUseCard(player, FunctionCard.RespondType.Skill, "@@Breachingtower", "@Breachingtower", null, -1, FunctionCard.HandlingMethod.MethodUse);
            }
            else if (triggerEvent == TriggerEvent.Damage && data is DamageStruct damage)
            {
                int count = System.Math.Min(damage.To.GetCardCount(true), 1 + player.GetMark("Breachingtower_discard"));
                List<string> patterns = new List<string>();
                for (int i = 0; i < count; i++)
                    patterns.Add("he^false^discard");

                List<int> ids = room.AskForCardsChosen(player, damage.To, patterns, Name);
                room.ThrowCard(ref ids, new CardMoveReason(MoveReason.S_REASON_DISMANTLE, player.Name, damage.To.Name, Name, string.Empty), damage.To, player);
            }
            else if (data is CardUseStruct _use)
            {
                player.AddQinggangTag(RoomLogic.CardToString(room, _use.Card));
                return false;
            }

            return false;
        }
    }

    public class BreachingVS : ViewAsSkill
    {
        public BreachingVS() : base(Breachingtower.ClassName) { response_pattern = "@@Breachingtower"; }
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player) => false;
        public override bool IsAvailable(Room room, Player invoker, CardUseStruct.CardUseReason reason, FunctionCard.RespondType respond, string pattern, string position = null) =>
            reason == CardUseStruct.CardUseReason.CARD_USE_REASON_RESPONSE_USE && pattern == response_pattern;
        public override List<WrappedCard> GetGuhuoCards(Room room, List<WrappedCard> cards, Player player)
        {
            WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = "_Breachingtower" };
            if (player.GetMark("Breachingtower_ignore") > 0)
                slash.DistanceLimited = false;
            List<WrappedCard> result = new List<WrappedCard> { slash };
            return result;
        }
        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count == 1 && cards[0].IsVirtualCard())
                return cards[0];
            return null;
        }
    }

    public class BreachingFix : FixCardSkill
    {
        public BreachingFix() : base("#Breachingtower") { }
        public override bool IsCardFixed(Room room, Player from, Player to, string flags, FunctionCard.HandlingMethod method) => method == FunctionCard.HandlingMethod.MethodDiscard
            && to != null && to.Treasure.Value == Breachingtower.ClassName && flags.Contains("t") && to.GetMark(Breachingtower.ClassName) == 0;
    }

    //霹雳车（宝物）
    public class Trebuchet : Treasure
    {
        public static string ClassName = "Trebuchet";
        public Trebuchet() : base(ClassName) { }
    }

    public class TrebuchetSkill : TreasureSkill
    {
        public TrebuchetSkill() : base(Trebuchet.ClassName)
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsed, TriggerEvent.BeforeCardsMove, TriggerEvent.CardResponded };
            frequency = Frequency.Compulsory;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.BeforeCardsMove && data is CardsMoveOneTimeStruct move)
            {
                if (move.From != null && move.From_places.Contains(Player.Place.PlaceEquip) && move.To_pile_name != "#virtual_cards")
                {
                    int catapult = -1, card_index = -1;
                    foreach (int id in move.Card_ids)
                    {
                        int index = move.Card_ids.IndexOf(id);
                        if (move.From_places[index] == Player.Place.PlaceEquip && Engine.GetRealCard(id).Name == Name)
                        {
                            catapult = id;
                            card_index = index;
                            break;
                        }
                    }

                    if (catapult > -1)
                    {
                        move.From_places.RemoveAt(card_index);
                        move.Card_ids.Remove(catapult);
                        if (move.Reason.Card != null)
                        {
                            List<int> subs = room.GetSubCards(move.Reason.Card);
                            subs.RemoveAll(t => t == catapult);
                        }
                        data = move;

                        Player holder = room.Players[0];
                        room.SetEmotion(move.From, "catapult_broken");
                        room.AddToPile(holder, "#virtual_cards", catapult, false);
                    }
                }
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use && base.Triggerable(player, room) && Engine.GetFunctionCard(use.Card.Name) is BasicCard
                && (player.Phase == Player.PlayerPhase.NotActive || use.Card.Name != Jink.ClassName))
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.CardResponded && player.Alive && player.Phase == Player.PlayerPhase.NotActive && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            if (player.Phase == Player.PlayerPhase.NotActive)
                room.DrawCards(player, 1, Name);
            else if (data is CardUseStruct use)
            {
                use.ExDamage++;
                data = use;
            }

            return false;
        }
    }

    public class TrebuchetTarSkill : TargetModSkill
    {
        public TrebuchetTarSkill() : base("#Trebuchet-tar", false) { }
        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseStruct.CardUseReason reason, string pattern) => from.HasTreasure(Trebuchet.ClassName) && from.Phase != Player.PlayerPhase.NotActive;
    }
}