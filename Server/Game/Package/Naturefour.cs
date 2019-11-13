﻿using CommonClass;
using CommonClass.Game;
using CommonClassLibrary;
using SanguoshaServer.Game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using static CommonClass.Game.CardUseStruct;
using static CommonClass.Game.Player;
using static SanguoshaServer.Package.FunctionCard;

namespace SanguoshaServer.Package
{
    public class Naturefour : GeneralPackage
    {
        public Naturefour() : base("Naturefour")
        {
            skills = new List<Skill>
            {
                new LuanjiJX(),
                new Xueyi(),
                new XueyiMax(),
                new WeimuJX(),
                new LeijiJX(),
                new Huangtian(),
                new HuangtianVS(),
                new Jiuchi(),
                new JiuchiInvalid(),
                new Roulin(),
                new Baonue(),
                new DuanchangJX(),
                new Guhuo(),
                new Canyuan(),
                new ShuangxiongJX(),
                new ShuangxiongJXGet(),
                new ShuangxiongJXVH(),
                new Huashen(),
                new HuashenClear(),
                new Xinsheng(),

                new LiegongJX(),
                //new LiegongRecord(),
                new LiegongTar(),
                new KuangguJX(),
                new Qimou(),
                new QimouTar(),
                new QimouDistance(),
                new Ruoyu(),
                new Zhiji(),
                new LierenJX(),
                new ZaiqiJX(),

                new Songwei(),
                new DuanliangJX(),
                new DuanliangJXTargetMod(),
                new Jiezhi(),
                new JushouJX(),
                new Jiewei(),
                new JiemingJX(),
                new Zaoxian(),
                new QiangxiJX(),

                new BuquJX(),
                new BuquJXClear(),
                new BuquMax(),
                new FenjiJX(),
                new TianxiangJX(),
                new TianxiangSecond(),
                new Hunzi(),
                new Zhiba(),
                new ZhibaVS(),
                new PoluSJ(),

                new Wushen(),
                new WushenTar(),
                new Wuhun(),
                new Qinyin(),
                new QinyinClear(),
                new Yeyan(),
                new Qixing(),
                new Kuangfeng(),
                new KuangfengDamage(),
                new Dawu(),
                new DawuDamage(),
                new Guixin(),
                new Juejing(),
                new JuejingMax(),
                new Longhun(),
                new Wuqian(),
                new Wumou(),
                new Kuangbao(),
                new Shenfen(),
                new Renjie(),
                new Lianpo(),
                new LianpoClear(),
                new Baiyin(),
                new Jilue(),
            };
            skill_cards = new List<FunctionCard>
            {
                new QimouCard(),
                new HuangtianCard(),
                new ZhibaCard(),
                new GuhuoCard(),
                new YeyanCard(),
                new KuangfengCard(),
                new DawuCard(),
                new WuqianCard(),
                new ShenfenCard(),
                new JilueCard(),
                new QiangxiJXCard(),
            };
            related_skills = new Dictionary<string, List<string>>
            {
                { "xueyi", new List<string>{ "#xueyi-max" } },
                { "qimou", new List<string>{ "#qimou-tar", "#qimou-distance" } },
                { "duanliang_jx", new List<string>{ "#jxduanliang-target" } },
                { "buqu_jx", new List<string>{ "#buqu_jx-clear", "#buqu-max" } },
                { "tianxiang_jx", new List<string>{ "#tianxian-second" } },
                { "jiuchi", new List<string>{ "#jiuchi-invalid" } },
                { "wushen", new List<string>{ "#wushen-target" } },
                { "qinyin", new List<string>{ "#qinyin-clear" } },
                { "kuangfeng", new List<string>{ "#kuangfeng" } },
                { "dawu", new List<string>{ "#dawu" } },
                { "shuangxiong_jx", new List<string>{ "#shuangxiong_jx-get" } },
                { "juejing", new List<string>{ "#juejing-max" } },
                { "hushen", new List<string>{ "#huashen-clear" } },
                { "lianpo", new List<string>{ "#lianpo" } },
            };
        }
    }
    //袁绍
    public class LuanjiJX : ViewAsSkill
    {
        public LuanjiJX() : base("luanji_jx")
        {
            response_or_use = true;
            skill_type = SkillType.Alter;
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return true;
        }

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            if (selected.Count > 1 || room.GetCardPlace(to_select.Id) == Player.Place.PlaceEquip) return false;
            if (selected.Count == 1)
                return selected[0].Suit == to_select.Suit;

            return true;
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count < 2) return null;
            WrappedCard aa = new WrappedCard(ArcheryAttack.ClassName) { Skill = Name };
            aa.AddSubCards(cards);
            return aa;
        }
    }

    public class Xueyi : TriggerSkill
    {
        public Xueyi() : base("xueyi")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging };
            frequency = Frequency.Compulsory;
            lord_skill = true;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change
                && change.To == PlayerPhase.Discard && RoomLogic.GetMaxCards(room, player) > player.Hp && player.HandcardNum > player.Hp)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.NotifySkillInvoked(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            return new TriggerStruct();
        }
    }

    public class XueyiMax : MaxCardsSkill
    {
        public XueyiMax() : base("#xueyi-max")
        {
        }

        public override int GetExtra(Room room, Player target)
        {
            int count = 0;
            if (RoomLogic.PlayerHasShownSkill(room, target, "xueyi"))
            {
                foreach (Player p in room.GetOtherPlayers(target))
                    if (p.Kingdom == "qun")
                        count += 2;
            }

            return count;
        }
    }

    public class WeimuJX : ProhibitSkill
    {
        public WeimuJX() : base("weimu_jx")
        {
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Defense;
        }

        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null)
        {
            if (card != null && to != null && RoomLogic.PlayerHasShownSkill(room, to, Name))
            {
                FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                return fcard is TrickCard && WrappedCard.IsBlack(RoomLogic.GetCardSuit(room, card));
            }

            return false;
        }
    }

    public class LeijiJX : TriggerSkill
    {
        public LeijiJX() : base("leiji_jx")
        {
            events.Add(TriggerEvent.CardResponded);
            skill_type = SkillType.Attack;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> skill_list = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.CardResponded && base.Triggerable(player, room) && data is CardResponseStruct resp)
            {
                WrappedCard card_star = resp.Card;
                if (card_star.Name == Jink.ClassName)
                    skill_list.Add(new TriggerStruct(Name, player));
            }

            return skill_list;
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.AskForPlayerChosen(player, room.GetAlivePlayers(), Name, "leiji-invoke", true, true, info.SkillPosition);
            if (target != null)
            {
                player.SetTag("leiji-target", target.Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            else
            {
                player.RemoveTag("leiji-target");
                return new TriggerStruct();
            }
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player zhangjiao, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.FindPlayer((string)zhangjiao.GetTag("leiji-target"));
            zhangjiao.RemoveTag("leiji-target");
            if (target != null)
            {
                JudgeStruct judge = new JudgeStruct
                {
                    Pattern = ".|black",
                    Good = true,
                    Negative = true,
                    Reason = Name,
                    Who = target
                };

                room.Judge(ref judge);

                if (!judge.IsGood())
                {
                    if (judge.Card.Suit == WrappedCard.CardSuit.Spade)
                    {
                        if (target.Alive)
                            room.Damage(new DamageStruct(Name, zhangjiao, target, 2, DamageStruct.DamageNature.Thunder));
                    }
                    else
                    {
                        if (zhangjiao.Alive && zhangjiao.GetLostHp() > 0)
                        {
                            RecoverStruct recover = new RecoverStruct
                            {
                                Recover = 1,
                                Who = zhangjiao
                            };
                            room.Recover(zhangjiao, recover, true);
                        }
                        if (target.Alive)
                            room.Damage(new DamageStruct(Name, zhangjiao, target, 1, DamageStruct.DamageNature.Thunder));
                    }
                }
            }

            return false;
        }
    }

    public class Huangtian : TriggerSkill
    {
        public Huangtian() : base("huangtian")
        {
            lord_skill = true;
            frequency = Frequency.Compulsory;
            events.Add(TriggerEvent.GameStart);
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (base.Triggerable(player, room))
            {
                if (!room.Skills.Contains("huangtianvs"))
                    room.Skills.Add("huangtianvs");
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.GetRoleEnum() != PlayerRole.Lord && p.Kingdom == "qun")
                    {
                        room.HandleAcquireDetachSkills(p, "huangtianvs", true);
                    }
                }
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            return new TriggerStruct();
        }
    }

    public class HuangtianVS : OneCardViewAsSkill
    {
        public HuangtianVS() : base("huangtianvs")
        {
            attached_lord_skill = true;
            frequency = Frequency.Compulsory;
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            List<Player> jiaozhu = RoomLogic.FindPlayersBySkillName(room, "huantian");
            return jiaozhu.Count > 0 && player.Kingdom == "qun" && !player.HasUsed(HuangtianCard.ClassName);
        }

        public override bool ViewFilter(Room room, WrappedCard to_select, Player player)
        {
            return to_select.Name == Jink.ClassName || to_select.Name == Lightning.ClassName;
        }

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard ht = new WrappedCard(HuangtianCard.ClassName);
            ht.AddSubCard(card);
            return ht;
        }
    }

    public class HuangtianCard : SkillCard
    {
        public static string ClassName = "HuangtianCard";
        public HuangtianCard() : base(ClassName)
        {
            handling_method = HandlingMethod.MethodNone;
            will_throw = false;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            List<Player> jiaozhu = RoomLogic.FindPlayersBySkillName(room, "huantian");
            if (jiaozhu.Count < 2) return false;

            return targets.Count == 0 && jiaozhu.Contains(to_select);
        }

        public override bool TargetsFeasible(Room room, List<Player> targets, Player Self, WrappedCard card)
        {
            List<Player> jiaozhu = RoomLogic.FindPlayersBySkillName(room, "huantian");
            return (jiaozhu.Count == 1 && targets.Count == 0) || (targets.Count == 1 && jiaozhu.Contains(targets[0]));
        }

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            List<Player> jiaozhu = RoomLogic.FindPlayersBySkillName(room, "huantian");
            Player target = null, player = card_use.From;
            if (jiaozhu.Count == 1 && card_use.To.Count == 0)
                target = jiaozhu[0];
            else if (card_use.To.Count == 1 && jiaozhu.Contains(card_use.To[0]))
                target = card_use.To[0];

            if (RoomLogic.PlayerHasSkill(room, target, "weidi_jx"))
            {
                room.BroadcastSkillInvoke("weidi_jx", target);
                room.NotifySkillInvoked(target, "weidi_jx");
            }
            else
            {
                room.BroadcastSkillInvoke("huangtian", target);
                room.NotifySkillInvoked(target, "huangtian");
            }
            room.ObtainCard(target, card_use.Card, new CardMoveReason(CardMoveReason.MoveReason.S_REASON_GIVE, player.Name, target.Name, "huangtian", string.Empty));
        }
    }

    public class Jiuchi : TriggerSkill
    {
        public Jiuchi() : base("jiuchi")
        {
            events.Add(TriggerEvent.DamageComplete);
            skill_type = SkillType.Alter;
            view_as_skill = new JiuchiVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is DamageStruct damage && damage.Card != null && damage.Card.Name.Contains(Slash.ClassName) && damage.Drank && base.Triggerable(damage.From, room)
                && room.Current == damage.From && !damage.From.HasFlag(Name) && damage.Damage > 0)
            {
                damage.From.SetFlags(Name);

                LogMessage log = new LogMessage
                {
                    Type = "#jiuchi",
                    From = damage.From.Name
                };
                room.SendLog(log);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class JiuchiInvalid : InvalidSkill
    {
        public JiuchiInvalid() : base("#jiuchi-invalid") { }

        public override bool Invalid(Room room, Player player, string skill)
        {
            if (player.HasFlag("jiuchi") && skill == "benghuai")
                return true;

            return false;
        }
    }

    public class JiuchiVS : OneCardViewAsSkill
    {
        public JiuchiVS() : base("jiuchi")
        {
            response_or_use = true;
        }
        public override bool ViewFilter(Room room, WrappedCard to_select, Player player)
        {
            return to_select.Suit == WrappedCard.CardSuit.Spade && room.GetCardPlace(to_select.Id) != Place.PlaceEquip
                && !RoomLogic.IsCardLimited(room, player, to_select, HandlingMethod.MethodUse);
        }
        public override bool IsEnabledAtResponse(Room room, Player player, string pattern)
        {
            if (room.GetRoomState().GetCurrentCardUseReason() == CardUseReason.CARD_USE_REASON_RESPONSE_USE)
            {
                WrappedCard card = new WrappedCard(Analeptic.ClassName);
                if (Engine.MatchExpPattern(room, pattern, player, card)) return true;
            }
            return false;
        }
        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard dismantlement = new WrappedCard(Analeptic.ClassName);
            dismantlement.AddSubCard(card);
            dismantlement.Skill = Name;
            dismantlement.ShowSkill = Name;
            dismantlement = RoomLogic.ParseUseCard(room, dismantlement);
            return dismantlement;
        }
    }

    public class Roulin : TriggerSkill
    {
        public Roulin() : base("roulin")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen, TriggerEvent.TargetConfirmed };
            skill_type = SkillType.Wizzard;
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            CardUseStruct use = (CardUseStruct)data;
            if (triggerEvent == TriggerEvent.TargetChosen && use.Card != null && use.Card.Name.Contains(Slash.ClassName) && base.Triggerable(player, room))
            {
                List<Player> targets = new List<Player>();
                foreach (Player p in use.To)
                    if (p.IsFemale()) targets.Add(p);
                if (targets.Count > 0)
                    return new TriggerStruct(Name, player, targets);

            }
            else if (triggerEvent == TriggerEvent.TargetConfirmed && use.Card != null && use.Card.Name.Contains(Slash.ClassName) && base.Triggerable(player, room)
                && use.From.Alive && use.From.IsFemale())
            {
                return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player target, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);

            CardUseStruct use = (CardUseStruct)data;
            if (triggerEvent == TriggerEvent.TargetChosen)
            {
                int index = 0;
                for (int i = 0; i < use.EffectCount.Count; i++)
                {
                    CardBasicEffect effect = use.EffectCount[i];
                    if (effect.To == target)
                    {
                        index++;
                        if (index == info.Times)
                        {
                            if (effect.Effect2 == 1)
                                effect.Effect2 = 2;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < use.EffectCount.Count; i++)
                {
                    CardBasicEffect effect = use.EffectCount[i];
                    if (effect.To == ask_who && !effect.Triggered)
                    {
                        if (effect.Effect2 == 1)
                            effect.Effect2 = 2;
                        break;
                    }
                }
            }

            data = use;

            return false;
        }
    }

    public class Baonue : TriggerSkill
    {
        public Baonue() : base("baonue")
        {
            events.Add(TriggerEvent.DamageComplete);
            lord_skill = true;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            Player dongzhuo = RoomLogic.FindPlayerBySkillName(room, Name);
            if (dongzhuo != null && dongzhuo.IsWounded() && data is DamageStruct damage && damage.From != null && damage.From.Alive
                && damage.From.Kingdom == "qun" && damage.From != dongzhuo && damage.Damage > 0)
            {
                return new TriggerStruct(Name, damage.From);
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player dongzhuo = RoomLogic.FindPlayerBySkillName(room, Name);
            if (room.AskForSkillInvoke(ask_who, Name, dongzhuo))
            {
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, dongzhuo.Name);
                room.NotifySkillInvoked(dongzhuo, Name);
                room.BroadcastSkillInvoke(Name, player);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player dongzhuo = RoomLogic.FindPlayerBySkillName(room, Name);
            JudgeStruct judge = new JudgeStruct
            {
                Who = ask_who,
                Pattern = ".|spade",
                Good = true,
                PlayAnimation = true,
                Reason = Name,
                Negative = false
            };

            room.Judge(ref judge);
            if (judge.IsGood() && dongzhuo.Alive && dongzhuo.IsWounded())
            {
                RecoverStruct recover = new RecoverStruct
                {
                    Who = ask_who,
                    Recover = 1
                };
                room.Recover(dongzhuo, recover, true);
            }

            return false;
        }
    }

    public class DuanchangJX : TriggerSkill
    {
        public DuanchangJX() : base("duanchang_jx")
        {
            events.Add(TriggerEvent.Death);
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Wizzard;
        }
        public override bool CanPreShow() => false;
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player != null && RoomLogic.PlayerHasSkill(room, player, Name) && data is DeathStruct death && death.Damage.From != null)
            {


                Player target = death.Damage.From;
                if (!target.General1.Contains("sujiang"))
                    return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            return info;
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.NotifySkillInvoked(player, Name);

            DeathStruct death = (DeathStruct)data;
            Player target = death.Damage.From;

            List<string> skills = target.GetSkills(true, false);
            foreach (string skill in skills)
            {
                Skill _s = Engine.GetSkill(skill);
                if (_s != null && !_s.Attached_lord_skill)
                    room.DetachSkillFromPlayer(target, skill, false, player.GetAcquiredSkills().Contains(skill), true);
            }

            if (death.Damage.From.Alive)
            {
                target.DuanChang = "head";
                room.BroadcastProperty(target, "DuanChang");
                room.SetPlayerMark(target, "@duanchang", 1);
            }

            return false;
        }
    }
    public class Guhuo : TriggerSkill
    {
        public Guhuo() : base("guhuo")
        {
            events.Add(TriggerEvent.EventPhaseChanging);
            skill_type = SkillType.Wizzard;
            view_as_skill = new GuhuoVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                    if (p.HasFlag(Name))
                        p.SetFlags("-guhuo");
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }
    public class GuhuoVS : ViewAsSkill
    {
        public GuhuoVS() : base("guhuo")
        {
            response_or_use = true;
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.HasFlag(Name);
        }

        public override bool IsEnabledAtResponse(Room room, Player player, string pattern)
        {
            return !player.HasFlag(Name);
        }

        public override bool IsEnabledAtNullification(Room room, Player player)
        {
            return !player.HasFlag(Name) && (!player.IsKongcheng() || player.GetHandPile().Count > 0);
        }

        public override List<WrappedCard> GetGuhuoCards(Room room, List<WrappedCard> cards, Player player)
        {
            List<WrappedCard> all_cards = new List<WrappedCard>();
            if (cards.Count == 1)
            {
                string pattern = room.GetRoomState().GetCurrentCardUsePattern(player);
                List<string> names = GetGuhuoCards(room, "bt");
                foreach (string name in names)
                {
                    WrappedCard card = new WrappedCard(name);
                    card.AddSubCard(cards[0]);
                    card = RoomLogic.ParseUseCard(room, card);
                    if (string.IsNullOrEmpty(pattern) || Engine.MatchExpPattern(room, pattern, player, card))
                        all_cards.Add(card);
                }
            }

            return all_cards;
        }

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            HandlingMethod method = HandlingMethod.MethodUse;
            if (room.GetRoomState().GetCurrentCardUseReason() == CardUseReason.CARD_USE_REASON_RESPONSE)
                method = HandlingMethod.MethodResponse;
            return selected.Count == 0 && room.GetCardPlace(to_select.Id) != Place.PlaceEquip && !RoomLogic.IsCardLimited(room, player, to_select, method);
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count == 1 && RoomLogic.IsVirtualCard(room, cards[0]))
            {
                WrappedCard gh = new WrappedCard(GuhuoCard.ClassName) { Skill = Name, UserString = cards[0].Name };
                gh.AddSubCard(cards[0].GetEffectiveId());
                return gh;
            }

            return null;
        }
    }

    public class GuhuoCard : SkillCard
    {
        public static string ClassName = "GuhuoCard";
        public GuhuoCard() : base(ClassName)
        {
            will_throw = false;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            WrappedCard real = new WrappedCard(card.UserString);
            real.AddSubCard(card);
            real = RoomLogic.ParseUseCard(room, real);
            FunctionCard fcard = Engine.GetFunctionCard(real.Name);
            return fcard.TargetFilter(room, targets, to_select, Self, real);
        }
        public override bool TargetsFeasible(Room room, List<Player> targets, Player Self, WrappedCard card)
        {
            WrappedCard real = new WrappedCard(card.UserString);
            real.AddSubCard(card);
            real = RoomLogic.ParseUseCard(room, real);
            FunctionCard fcard = Engine.GetFunctionCard(real.Name);
            return fcard.TargetsFeasible(room, targets, Self, real);
        }

        public override WrappedCard Validate(Room room, CardUseStruct use)
        {
            Player player = use.From;
            room.NotifySkillInvoked(player, "guhuo");
            room.BroadcastSkillInvoke("guhuo", player, use.Card.SkillPosition);
            player.SetFlags("guhuo");

            LogMessage log = new LogMessage
            {
                Type = "#guhuo",
                From = player.Name,
                Arg = "guhuo",
                Arg2 = use.Card.UserString
            };
            room.SendLog(log);

            WrappedCard guhuo = new WrappedCard(use.Card.UserString);

            CardMoveReason reason = new CardMoveReason(CardMoveReason.MoveReason.S_REASON_ANNOUNCE, player.Name, null, "guhuo", null)
            {
                CardString = RoomLogic.CardToString(room, guhuo),
                General = RoomLogic.GetGeneralSkin(room, player, "guhuo", use.Card.SkillPosition)
            };
            if (use.To.Count == 1)
                reason.TargetId = use.To[0].Name;
            CardsMoveStruct move = new CardsMoveStruct(use.Card.GetEffectiveId(), null, Place.PlaceTable, reason);
            room.MoveCardsAtomic(new List<CardsMoveStruct> { move }, false);

            WrappedCard real = room.GetCard(use.Card.GetEffectiveId());
            foreach (Player p in room.GetOtherPlayers(player))
            {
                if (!RoomLogic.PlayerHasSkill(room, p, "canyuan"))
                {
                    player.SetTag("guhuo", use.Card.UserString);
                    string choice = room.AskForChoice(p, "guhuo", "doubt+cancel", new List<string> { string.Format("@guhuo:{0}::{1}", player.Name, use.Card.UserString) }, player);
                    player.RemoveTag("guhuo");
                    if (choice == "doubt")
                    {
                        log = new LogMessage
                        {
                            Type = "#guhuo-doubt",
                            From = p.Name
                        };
                        room.SendLog(log);

                        CardsMoveStruct _move = new CardsMoveStruct(use.Card.GetEffectiveId(), null, player, Place.DrawPile,
                            Place.PlaceTable, new CardMoveReason(CardMoveReason.MoveReason.S_REASON_DEMONSTRATE, player.Name, "guhuo", string.Empty));
                        room.NotifyMoveCards(true, new List<CardsMoveStruct> { _move }, true);
                        room.NotifyMoveCards(false, new List<CardsMoveStruct> { _move }, true);

                        if (real.Name != use.Card.UserString)
                        {
                            LogMessage log1 = new LogMessage
                            {
                                Type = "#guhuo-false",
                                From = p.Name
                            };
                            room.SendLog(log1);

                            List<int> table_cardids = room.GetCardIdsOnTable(use.Card);
                            reason = new CardMoveReason(CardMoveReason.MoveReason.S_REASON_DEMONSTRATE, player.Name, "guhuo", string.Empty);
                            if (table_cardids.Count > 0)
                            {
                                CardsMoveStruct move1 = new CardsMoveStruct(table_cardids, player, null, Place.PlaceTable, Place.DiscardPile, reason);
                                room.MoveCardsAtomic(new List<CardsMoveStruct> { move1 }, true);
                            }

                            return null;
                        }
                        else
                        {
                            LogMessage log1 = new LogMessage
                            {
                                Type = "#guhuo-true",
                                From = p.Name
                            };
                            room.SendLog(log1);

                            room.HandleAcquireDetachSkills(p, "canyuan", true);
                        }

                        break;
                    }
                    else
                    {
                        log = new LogMessage
                        {
                            Type = "#guhuo-undoubt",
                            From = p.Name
                        };
                        room.SendLog(log);
                    }
                }
            }
            guhuo.Skill = "_guhuo";
            guhuo.AddSubCard(use.Card);
            guhuo = RoomLogic.ParseUseCard(room, guhuo);

            reason = new CardMoveReason(CardMoveReason.MoveReason.S_REASON_USE, player.Name, null, "_guhuo", null)
            {
                CardString = RoomLogic.CardToString(room, guhuo),
                General = RoomLogic.GetGeneralSkin(room, player, "_guhuo", use.Card.SkillPosition)
            };
            move = new CardsMoveStruct(use.Card.GetEffectiveId(), null, Place.PlaceTable, reason)
            {
                From_place = Place.PlaceUnknown,
                From = player.Name,
                Is_last_handcard = false,
            };
            room.NotifyUsingVirtualCard(RoomLogic.CardToString(room, guhuo), move);

            return guhuo;
        }

        public override WrappedCard ValidateInResponse(Room room, Player player, WrappedCard card)
        {
            room.NotifySkillInvoked(player, "guhuo");
            room.BroadcastSkillInvoke("guhuo", player, card.SkillPosition);
            player.SetFlags("guhuo");

            LogMessage log = new LogMessage
            {
                Type = "#guhuo",
                From = player.Name,
                Arg = "guhuo",
                Arg2 = card.UserString
            };
            room.SendLog(log);

            WrappedCard guhuo = new WrappedCard(card.UserString);

            CardMoveReason reason = new CardMoveReason(CardMoveReason.MoveReason.S_REASON_ANNOUNCE, player.Name, null, "guhuo", null)
            {
                CardString = RoomLogic.CardToString(room, guhuo),
                General = RoomLogic.GetGeneralSkin(room, player, "guhuo", card.SkillPosition)
            };

            CardsMoveStruct move = new CardsMoveStruct(card.GetEffectiveId(), null, Place.PlaceTable, reason);
            room.MoveCardsAtomic(new List<CardsMoveStruct> { move }, false);

            WrappedCard real = room.GetCard(card.GetEffectiveId());
            foreach (Player p in room.GetOtherPlayers(player))
            {
                if (!RoomLogic.PlayerHasSkill(room, p, "canyuan"))
                {
                    player.SetTag("guhuo", card.UserString);
                    string choice = room.AskForChoice(p, "guhuo", "doubt+cancel", new List<string> { string.Format("@guhuo:{0}::{1}", player.Name, card.UserString) }, player);
                    player.RemoveTag("guhuo");
                    if (choice ==  "doubt")
                    {
                        log = new LogMessage
                        {
                            Type = "#guhuo-doubt",
                            From = p.Name
                        };
                        room.SendLog(log);

                        CardsMoveStruct _move = new CardsMoveStruct(card.GetEffectiveId(), null, player, Place.DrawPile,
                            Place.PlaceTable, new CardMoveReason(CardMoveReason.MoveReason.S_REASON_DEMONSTRATE, player.Name, "guhuo", string.Empty));
                        room.NotifyMoveCards(true, new List<CardsMoveStruct> { _move }, true);
                        room.NotifyMoveCards(false, new List<CardsMoveStruct> { _move }, true);

                        if (real.Name != card.UserString)
                        {
                            LogMessage log1 = new LogMessage
                            {
                                Type = "#guhuo-false",
                                From = p.Name
                            };
                            room.SendLog(log1);

                            List<int> table_cardids = room.GetCardIdsOnTable(card);
                            reason = new CardMoveReason(CardMoveReason.MoveReason.S_REASON_NATURAL_ENTER, player.Name, "guhuo", string.Empty);
                            if (table_cardids.Count > 0)
                            {
                                CardsMoveStruct move1 = new CardsMoveStruct(table_cardids, player, null, Place.PlaceTable, Place.DiscardPile, reason);
                                room.MoveCardsAtomic(new List<CardsMoveStruct> { move1 }, true);
                            }

                            return null;
                        }
                        else
                        {
                            LogMessage log1 = new LogMessage
                            {
                                Type = "#guhuo-true",
                                From = p.Name
                            };
                            room.SendLog(log1);

                            room.HandleAcquireDetachSkills(p, "canyuan", true);
                        }

                        break;
                    }
                    else
                    {
                        log = new LogMessage
                        {
                            Type = "#guhuo-undoubt",
                            From = p.Name
                        };
                        room.SendLog(log);
                    }
                }
            }

            guhuo.Skill = "_guhuo";
            guhuo.AddSubCard(card);
            guhuo = RoomLogic.ParseUseCard(room, guhuo);

            reason = new CardMoveReason(CardMoveReason.MoveReason.S_REASON_RESPONSE, player.Name, null, "_guhuo", null)
            {
                CardString = RoomLogic.CardToString(room, guhuo),
                General = RoomLogic.GetGeneralSkin(room, player, "_guhuo", card.SkillPosition)
            };
            if (room.GetRoomState().GetCurrentCardUseReason() == CardUseReason.CARD_USE_REASON_RESPONSE_USE)
                reason.Reason = CardMoveReason.MoveReason.S_REASON_LETUSE;
            move = new CardsMoveStruct(card.GetEffectiveId(), player, Place.PlaceTable, reason)
            {
                From_place = Place.PlaceUnknown,
                From = player.Name,
                Is_last_handcard = false,
            };
            room.NotifyUsingVirtualCard(RoomLogic.CardToString(room, guhuo), move);

            return guhuo;
        }
    }

    public class Canyuan : InvalidSkill
    {
        public Canyuan() : base("canyuan")
        {
        }

        public override bool Invalid(Room room, Player player, string skill)
        {
            Skill s = Engine.GetSkill(skill);
            if (s == null || s.Attached_lord_skill || player.Hp != 1) return false;
            if (player.HasEquip(skill)) return false;
            if (player.GetAcquiredSkills().Contains(Name) && skill != Name)
                return true;

            return false;
        }
    }

    public class ShuangxiongVS : OneCardViewAsSkill
    {
        public ShuangxiongVS() : base("shuangxiong_jx")
        {
            response_or_use = true;
        }
        public override bool IsAvailable(Room room, Player player, CardUseReason reason, string pattern, string position = null)
        {
            return reason == CardUseReason.CARD_USE_REASON_PLAY && RoomLogic.PlayerHasSkill(room, player, Name)
                && player.HasFlag("shuangxiong_jx_" + position) && player.GetMark("shuangxiong_jx") != 0;
        }
        public override bool ViewFilter(Room room, WrappedCard card, Player player)
        {
            if (player.HasEquip(card.Name))
                return false;

            int value = player.GetMark(Name);
            if (value == 1)
                return WrappedCard.IsBlack(card.Suit);
            else if (value == 2)
                return WrappedCard.IsRed(card.Suit);

            return false;
        }
        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard duel = new WrappedCard(Duel.ClassName);
            duel.AddSubCard(card);
            duel.Skill = Name;
            duel.ShowSkill = Name;
            duel = RoomLogic.ParseUseCard(room, duel);
            return duel;
        }
    }
    public class ShuangxiongJX : TriggerSkill
    {
        public ShuangxiongJX() : base("shuangxiong_jx")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.EventPhaseChanging, TriggerEvent.CardFinished, TriggerEvent.CardResponded };
            view_as_skill = new ShuangxiongVS();
            skill_type = SkillType.Attack;
        }
        public override bool CanPreShow() => true;

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player.GetMark(Name) > 0)
                player.SetMark(Name, 0);
            else if (triggerEvent == TriggerEvent.CardFinished && data is CardUseStruct use && use.Card.Name == Duel.ClassName
                && use.Card.Skill == Name && use.From.ContainsTag(RoomLogic.CardToString(room, use.Card)))
                use.From.RemoveTag(RoomLogic.CardToString(room, use.Card));
            else if (triggerEvent == TriggerEvent.CardResponded && data is CardResponseStruct resp && resp.Card.Name.Contains(Slash.ClassName) && resp.Card.SubCards.Count > 0
                && resp.Data is CardEffectStruct effect && effect.Card != null && effect.Card.Name == Duel.ClassName && effect.Card.Skill == Name && player != effect.From)
            {
                string str = RoomLogic.CardToString(room, effect.Card);
                List<int> ids = effect.From.ContainsTag(str) ? (List<int>)effect.From.GetTag(str) : new List<int>();
                ids.AddRange(resp.Card.SubCards);
                effect.From.SetTag(str, ids);
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Draw && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player shuangxiong, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(shuangxiong, Name, null, info.SkillPosition))
            {
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, shuangxiong, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                return info;
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<int> card_ids = room.GetNCards(2);
            foreach (int id in card_ids)
            {
                room.MoveCardTo(room.GetCard(id), player, Place.PlaceTable, new CardMoveReason(CardMoveReason.MoveReason.S_REASON_TURNOVER, player.Name, Name, null), false);
                Thread.Sleep(400);
            }
            AskForMoveCardsStruct result = room.AskForMoveCards(player, card_ids, new List<int>(), true, Name, 1, 1, false, true, card_ids, info.SkillPosition);
            List<int> get = new List<int>(), drop = new List<int>();
            if (result.Success)
            {
                get = result.Bottom;
                drop = result.Top;
            }
            else
            {
                get.Add(card_ids[0]);
                drop.Add(card_ids[1]);
            }

            room.SetPlayerFlag(player, "shuangxiong_jx_" + info.SkillPosition);

            room.MoveCards(new List<CardsMoveStruct>
            {
                new CardsMoveStruct(get, player, Place.PlaceHand, new CardMoveReason(CardMoveReason.MoveReason.S_REASON_GOTBACK, player.Name, Name, null)) },
                true);

            player.SetMark(Name, WrappedCard.IsRed(room.GetCard(get[0]).Suit) ? 1 : 2);

            room.MoveCards(new List<CardsMoveStruct>
            {
                new CardsMoveStruct(drop, null, Place.DiscardPile, new CardMoveReason(CardMoveReason.MoveReason.S_REASON_NATURAL_ENTER, null, Name, null)) },
                true);

            return true;
        }

        public override void GetEffectIndex(Room room, Player player, WrappedCard card, ref int index, ref string skill_name, ref string general_name, ref int skin_id)
        {
            index = 2;
        }
    }

    public class ShuangxiongJXVH : ViewHasSkill
    {
        public ShuangxiongJXVH() : base("#shuangxiong-vs") { viewhas_skills.Add("shuangxiong_jx"); }
        public override bool ViewHas(Room room, Player player, string skill_name)
        {
            if (skill_name == "shuangxiong_jx" && (player.HasFlag("shuangxiong_jx_head") || player.HasFlag("shuangxiong_jx_deputy")) && player.GetMark("shuangxiong_jx") != 0)
                return true;

            return false;
        }
    }

    public class ShuangxiongJXGet : TriggerSkill
    {
        public ShuangxiongJXGet() : base("#shuangxiong_jx-get")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damaged };
            frequency = Frequency.Compulsory;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.Damaged && data is DamageStruct damage && damage.Card != null && damage.Card.Name == Duel.ClassName
                && damage.Card.Skill == "shuangxiong_jx" && player.ContainsTag(RoomLogic.CardToString(room, damage.Card))
                && player.GetTag(RoomLogic.CardToString(room, damage.Card)) is List<int> ids && ids.Count > 0)
            {
                return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage && player.GetTag(RoomLogic.CardToString(room, damage.Card)) is List<int> ids)
            {
                List<int> get = new List<int>();
                foreach (int id in ids)
                {
                    if (room.GetCardPlace(id) == Place.DiscardPile)
                        get.Add(id);
                }

                if (get.Count > 0)
                    room.ObtainCard(player, ref get, new CardMoveReason(CardMoveReason.MoveReason.S_REASON_GOTBACK, player.Name, Name, string.Empty));
            }

            return false;
        }
    }

    public class Huashen : TriggerSkill
    {
        public Huashen() : base("huashen")
        {
            events = new List<TriggerEvent> { TriggerEvent.GameStart, TriggerEvent.EventPhaseStart, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Wizzard;
        }

        public static void Acquiregenerals(Room room, Player zuoci, int n)
        {
            List<string> huashens = zuoci.ContainsTag("huashen") ? (List<string>)zuoci.GetTag("huashen") : new List<string>();
            List<string> acquired = GetavailableGenerals(room, zuoci, n);

            if (acquired.Count == 0) return;

            foreach (string general in acquired)
                room.HandleUsedGeneral(general);

            huashens.AddRange(acquired);
            zuoci.SetTag("huashen", huashens);

            List<Player> others = new List<Player>();
            List<Client> clients = new List<Client>();
            foreach (Player p in room.GetOtherPlayers(zuoci))
            {
                Client c = room.GetClient(p);
                if (c != room.GetClient(zuoci) && !clients.Contains(c))
                {
                    others.Add(p);
                    clients.Add(c);
                }
            }
            LogMessage log = new LogMessage
            {
                Type = "#gethuashendetail",
                From = zuoci.Name,
                Arg = "huashen",
                Arg2 = string.Join("\\, \\", acquired),
            };

            LogMessage log1 = new LogMessage
            {
                Type = "#gethuashen",
                From = zuoci.Name,
                Arg = "huashen",
                Arg2 = acquired.Count.ToString()
            };

            room.SendLog(log, zuoci);
            room.SendLog(log1, new List<Player> { zuoci });

            List<string> unkonwns = new List<string>();
            for (int i = 0; i < acquired.Count; i++)
                unkonwns.Add("-1");

            room.DoAnimate(AnimateType.S_ANIMATE_HUASHEN, string.Join("+", acquired), string.Format("null+{0}+huashen", zuoci.Name), new List<Player> { zuoci });
            room.DoAnimate(AnimateType.S_ANIMATE_HUASHEN, string.Join("+", unkonwns), string.Format("null+{0}", zuoci.Name), others);
            Thread.Sleep(1500);
            room.SetPlayerStringMark(zuoci, "huashen", huashens.Count.ToString(), room.GetClient(zuoci));
        }

        public static void RemoveHuashen(Room room, Player zuoci, List<string> generals)
        {
            List<string> huashens = zuoci.ContainsTag("huashen") ? (List<string>)zuoci.GetTag("huashen") : new List<string>();
            List<string> remove = new List<string>();
            foreach (string name in generals)
            {
                if (huashens.Contains(name))
                {
                    remove.Add(name);
                    room.HandleUsedGeneral("-" + name);
                }
            }
            if (remove.Count == 0) return;

            huashens.RemoveAll(t => remove.Contains(t));
            zuoci.SetTag("spirit", huashens);

            LogMessage log = new LogMessage
            {
                Type = "#drophuashendetail",
                From = zuoci.Name,
                Arg = "huashen",
                Arg2 = string.Join("\\, \\", remove)
            };
            room.SendLog(log);

            room.DoAnimate(AnimateType.S_ANIMATE_HUASHEN, string.Join("+", remove), string.Format("{0}+null+huashen", zuoci.Name));
            Thread.Sleep(1500);
            if (huashens.Count == 0)
                room.RemovePlayerStringMark(zuoci, "huashen");
            else
                room.SetPlayerStringMark(zuoci, "huashen", huashens.Count.ToString(), room.GetClient(zuoci));
        }

        public static List<string> GetavailableGenerals(Room room, Player zuoci, int n)
        {
            List<string> available = new List<string>(), ban = Engine.GetHuashenBanList();
            foreach (string name in room.Generals)
            {
                General general = Engine.GetGeneral(name, room.Setting.GameMode);
                if (!room.UsedGeneral.Contains(name) && general.Kingdom != "god" && !ban.Contains(name)
                    && general.Package != "ClassicSpecial" && general.Package != "ClassicYing" && general.Package != "Anniversary")
                    available.Add(name);
            }
            List<string> result = new List<string>();
            Shuffle.shuffle(ref available);
            for (int i = 0; i < Math.Min(available.Count, n); i++)
                result.Add(available[i]);

            return result;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.GameStart && base.Triggerable(player, room))
                Acquiregenerals(room, player, 2);
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.GameStart && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            else if ((triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.Phase == PlayerPhase.Start)
                || (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && base.Triggerable(player, room)))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.GameStart)
            {
                room.NotifySkillInvoked(player, Name);
                return info;
            }
            else if (room.AskForSkillInvoke(player, Name, null, info.SkillPosition))
            {
                string general = player.ContainsTag("huashen_general") ? player.GetTag("huashen_general").ToString() : string.Empty;
                if (!string.IsNullOrEmpty(general))
                {
                    List<string> args = new List<string>
                    {
                        GameEventType.S_GAME_EVENT_HUASHEN.ToString(),
                        player.Name,
                        string.Empty
                    };
                    room.DoBroadcastNotify(CommandType.S_COMMAND_LOG_EVENT, args);
                }
                player.RemoveTag("huashen_general");

                string skill = player.ContainsTag("huashen_skill") ? player.GetTag("huashen_skill").ToString() : string.Empty;
                if (!string.IsNullOrEmpty(skill))
                    room.HandleAcquireDetachSkills(player, string.Format("-{0}", skill), true);
                player.RemoveTag("huashen_skill");

                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);

            List<string> huashens = player.ContainsTag("huashen") ? (List<string>)player.GetTag("huashen") : new List<string>();
            if (huashens.Count > 0)
            {
                string general = room.AskForGeneral(player, huashens, null);
                General g = Engine.GetGeneral(general, room.Setting.GameMode);
                if (g != null)
                {
                    player.PlayerGender = g.GeneralGender;
                    player.Kingdom = g.Kingdom;
                    room.BroadcastProperty(player, "PlayerGender");
                    room.BroadcastProperty(player, "Kingdom");

                    List<string> args = new List<string>
                    {
                        GameEventType.S_GAME_EVENT_HUASHEN.ToString(),
                        player.Name,
                        general
                    };
                    room.DoBroadcastNotify(CommandType.S_COMMAND_LOG_EVENT, args);

                    player.SetTag("huashen_general", general);

                    List<string> skills = new List<string>();
                    foreach (string skill_name in Engine.GetGeneralSkills(general, room.Setting.GameMode, true))
                    {
                        Skill s = Engine.GetSkill(skill_name);
                        if (s != null && s.SkillFrequency != Frequency.Limited && s.SkillFrequency != Frequency.Wake && !s.LordSkill && !s.Attached_lord_skill)
                            skills.Add(skill_name);
                    }

                    if (skills.Count > 0)
                    {
                        string skill = room.AskForChoice(player, Name, string.Join("+", skills));
                        player.SetTag("huashen_skill", skill);
                        room.HandleAcquireDetachSkills(player, skill, true);
                        room.FilterCards(player, player.GetCards("he"), true);
                    }
                }
            }

            return false;
        }
    }

    public class HuashenClear : DetachEffectSkill
    {
        public HuashenClear() : base("huashen", string.Empty)
        {
        }
        public override void OnSkillDetached(Room room, Player zuoci, object data)
        {
            List<string> huashens = zuoci.ContainsTag("huashen") ? (List<string>)zuoci.GetTag("huashen") : new List<string>();
            Huashen.RemoveHuashen(room, zuoci, huashens);

            string general = zuoci.ContainsTag("huashen_general") ? zuoci.GetTag("huashen_general").ToString() : string.Empty;
            if (!string.IsNullOrEmpty(general))
            {
                List<string> args = new List<string>
                    {
                        GameEventType.S_GAME_EVENT_HUASHEN.ToString(),
                        zuoci.Name,
                        string.Empty
                    };
                room.DoBroadcastNotify(CommandType.S_COMMAND_LOG_EVENT, args);
            }
            zuoci.RemoveTag("huashen_general");

            string skill = zuoci.ContainsTag("huashen_skill") ? zuoci.GetTag("huashen_skill").ToString() : string.Empty;
            if (!string.IsNullOrEmpty(skill))
                room.HandleAcquireDetachSkills(zuoci, string.Format("-{0}", skill), true);
            zuoci.RemoveTag("huashen_skill");

            zuoci.PlayerGender = Gender.Male;
            zuoci.Kingdom = "qun";
            room.BroadcastProperty(zuoci, "PlayerGender");
            room.BroadcastProperty(zuoci, "Kingdom");
        }
    }

    public class Xinsheng : MasochismSkill
    {
        public Xinsheng() : base("xinsheng")
        {
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is DamageStruct damage)
            {
                TriggerStruct trigger = new TriggerStruct(Name, player)
                {
                    Times = damage.Damage
                };
                return trigger;
            }

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }

        public override void OnDamaged(Room room, Player target, DamageStruct damage, TriggerStruct info)
        {
            Huashen.Acquiregenerals(room, target, 1);
        }
    }

    //caopi
    public class Songwei : TriggerSkill
    {
        public Songwei() : base("songwei")
        {
            events.Add(TriggerEvent.FinishJudge);
            skill_type = SkillType.Replenish;
            lord_skill = true;
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> result = new List<TriggerStruct>();
            if (player.Kingdom == "wei" && data is JudgeStruct judge && player.Alive && WrappedCard.IsBlack(judge.Card.Suit))
            {
                List<Player> caopis = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in caopis)
                {
                    if (player != p)
                        result.Add(new TriggerStruct(Name, player, p));
                }
            }

            return result;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player caopi = room.FindPlayer(info.SkillOwner);
            if (ask_who.Alive && caopi.Alive && room.AskForSkillInvoke(ask_who, Name, caopi))
            {
                room.NotifySkillInvoked(caopi, Name);
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, info.SkillOwner);
                room.BroadcastSkillInvoke(Name, caopi, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player caopi = room.FindPlayer(info.SkillOwner);
            room.DrawCards(player, new DrawCardStruct(1, ask_who, Name));
            return false;
        }
    }

    //徐晃
    public class DuanliangJX : OneCardViewAsSkill
    {
        public DuanliangJX() : base("duanliang_jx")
        {
            filter_pattern = "BasicCard,EquipCard|black";
            response_or_use = true;
            skill_type = SkillType.Alter;
        }
        public override bool IsEnabledAtPlay(Room room, Player player) => true;
        public override bool IsEnabledAtResponse(Room room, Player player, string pattern)
        {
            if (room.GetRoomState().GetCurrentCardUseReason() == CardUseStruct.CardUseReason.CARD_USE_REASON_RESPONSE_USE)
            {
                WrappedCard card = new WrappedCard(SupplyShortage.ClassName);
                if (Engine.MatchExpPattern(room, pattern, player, card)) return true;
            }
            return false;
        }
        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard shortage = new WrappedCard(SupplyShortage.ClassName)
            {
                Skill = Name,
                ShowSkill = Name
            };
            shortage.AddSubCard(card);
            shortage = RoomLogic.ParseUseCard(room, shortage);

            return shortage;
        }
    }

    public class DuanliangJXTargetMod : TargetModSkill
    {
        public DuanliangJXTargetMod() : base("#jxduanliang-target")
        {
            pattern = "SupplyShortage";
        }
        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            if (to != null && RoomLogic.PlayerHasSkill(room, from, "duanliang_jx") && to.HandcardNum >= from.HandcardNum)
                return true;
            else
                return false;
        }
    }

    public class Jiezhi : TriggerSkill
    {
        public Jiezhi() : base("jiezhi")
        {
            events.Add(TriggerEvent.EventPhaseSkipping);
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Replenish;
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (data is PhaseChangeStruct change && change.To == Player.PlayerPhase.Draw && player.Alive)
            {
                List<Player> xuhuangs = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in xuhuangs)
                    if (p != player)
                        triggers.Add(new TriggerStruct(Name, p));
            }

            return triggers;
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name, true);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            room.DrawCards(ask_who, 1, Name);
            return false;
        }
    }

    //曹仁
    public class JieweiVS : OneCardViewAsSkill
    {
        public JieweiVS() : base("jiewei")
        {
            filter_pattern = ".|.|.|equipped";
            response_pattern = "Nullification";
            skill_type = SkillType.Alter;
        }
        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard ncard = new WrappedCard(Nullification.ClassName) { Skill = Name };
            ncard.AddSubCard(card);
            ncard = RoomLogic.ParseUseCard(room, ncard);
            return ncard;
        }
        public override bool IsEnabledAtNullification(Room room, Player player)
        {
            return player.HasEquip();
        }
    }
    public class JushouJXVS : OneCardViewAsSkill
    {
        public JushouJXVS() : base("jushou_jx")
        {
            response_pattern = "@@jushou_jx";
        }

        public override bool ViewFilter(Room room, WrappedCard to_select, Player player)
        {
            FunctionCard fcard = Engine.GetFunctionCard(to_select.Name);
            return room.GetCardPlace(to_select.Id) == Place.PlaceHand && (fcard is EquipCard && fcard.IsAvailable(room, player, to_select)
                || RoomLogic.CanDiscard(room, player, player, to_select.Id));
        }

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard jushou = new WrappedCard(JushouCard.ClassName)
            {
                Mute = true,
                Skill = Name
            };
            jushou.AddSubCard(card);
            return jushou;
        }
    }
    public class JushouJX : PhaseChangeSkill
    {
        public JushouJX() : base("jushou_jx")
        {
            view_as_skill = new JushouJXVS();
            frequency = Frequency.Frequent;
            skill_type = SkillType.Defense;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            return base.Triggerable(player, room) && player.Phase == PlayerPhase.Finish ?
                new TriggerStruct(Name, player) : new TriggerStruct(); ;
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }
        public override bool OnPhaseChange(Room room, Player caoren, TriggerStruct info)
        {
            room.TurnOver(caoren);
            room.DrawCards(caoren, 4, Name);

            List<int> ids = caoren.GetCardCount(false) == 1 ? caoren.GetCards("h") : new List<int>();
            if (ids.Count == 0)
            {
                WrappedCard use = room.AskForUseCard(caoren, "@@jushou_jx", "@jushou", -1, FunctionCard.HandlingMethod.MethodUse, true, info.SkillPosition);
                if (use != null)
                    ids = new List<int>(use.SubCards);
                else
                    ids = room.ForceToDiscard(caoren, caoren.GetCards("h"), 1);
            }

            if (ids.Count == 1)
            {
                int id = ids[0];
                WrappedCard card = room.GetCard(id);

                bool discard = true;
                FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                if (fcard is EquipCard && fcard.IsAvailable(room, caoren, card))
                {
                    if (RoomLogic.CanDiscard(room, caoren, caoren, id))
                        discard = room.AskForChoice(caoren, Name, "use+discard") == "discard";
                    else
                        discard = false;
                }

                if (discard)
                {
                    GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, caoren, info.SkillPosition);
                    CardMoveReason reason = new CardMoveReason(CardMoveReason.MoveReason.S_REASON_DISCARD, caoren.Name, null, Name, null)
                    {
                        General = gsk
                    };
                    room.ThrowCard(ref ids, reason, caoren, caoren);
                }
                else
                    room.UseCard(new CardUseStruct(card, caoren, new List<Player>(), true));
            }

            return false;
        }
    }
    public class Jiewei : TriggerSkill
    {
        public Jiewei() : base("jiewei")
        {
            events.Add(TriggerEvent.TurnedOver);
            view_as_skill = new JieweiVS();
            skill_type = SkillType.Wizzard;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            return (base.Triggerable(player, room) && player.FaceUp && player.Alive) ? new TriggerStruct(Name, player) : new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForDiscard(player, Name, 1, 1, true, true, "@jiewei", true, info.SkillPosition))
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
            {
                if (p.GetCards("ej").Count > 0)
                    targets.Add(p);
            }
            if (targets.Count > 0)
            {
                Player target1 = room.AskForPlayerChosen(player, targets, Name, "@jiewei1", true, false, info.SkillPosition);
                if (target1 != null)
                {
                    int card_id = room.AskForCardChosen(player, target1, "ej", Name);
                    WrappedCard card = room.GetCard(card_id);
                    Place place = room.GetCardPlace(card_id);

                    FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                    int equip_index = -1;
                    if (place == Place.PlaceEquip)
                    {
                        EquipCard equip = (EquipCard)fcard;
                        equip_index = (int)equip.EquipLocation();
                    }

                    List<Player> tos = new List<Player>();
                    foreach (Player p in room.GetAlivePlayers())
                    {
                        if (equip_index != -1)
                        {
                            if (p.GetEquip(equip_index) < 0 && RoomLogic.CanPutEquip(player, card))
                                tos.Add(p);
                        }
                        else if (RoomLogic.IsProhibited(room, null, p, card) == null && !RoomLogic.PlayerContainsTrick(room, p, card.Name))
                            tos.Add(p);
                    }

                    room.SetTag("MouduanTarget", target1);
                    string position = info.SkillPosition;
                    Player to = room.AskForPlayerChosen(player, tos, Name, "@jiewei-to:::" + card.Name, false, false, position);
                    room.RemoveTag("MouduanTarget");
                    if (to != null)
                    {
                        room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, target1.Name, to.Name);
                        CardMoveReason reason = new CardMoveReason(CardMoveReason.MoveReason.S_REASON_TRANSFER, player.Name, Name, null)
                        {
                            CardString = RoomLogic.CardToString(room, card)
                        };
                        room.MoveCardTo(card, target1, to, place, reason);
                        /*
                        if (place == Place.PlaceDelayedTrick)
                        {
                            CardUseStruct use = new CardUseStruct(card, null, to);
                            object _data = use;
                            room.RoomThread.Trigger(TriggerEvent.TargetConfirming, room, to, ref _data);
                            CardUseStruct new_use = (CardUseStruct)_data;
                            if (new_use.To.Count == 0)
                                fcard.OnNullified(room, to, card);

                            foreach (Player p in room.GetAllPlayers())
                                room.RoomThread.Trigger(TriggerEvent.TargetConfirmed, room, p, ref _data);
                        }
                        */
                    }
                }
            }
            return false;
        }
    }

    public class LiegongJX : TriggerSkill
    {
        public LiegongJX() : base("liegong_jx")
        {
            events.Add(TriggerEvent.TargetChosen);
            skill_type = SkillType.Attack;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardUseStruct use && base.Triggerable(player, room))
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is Slash)
                {
                    List<Player> targets = new List<Player>();
                    foreach (Player to in use.To)
                    {
                        if (to.HandcardNum <= player.HandcardNum || to.Hp >= player.Hp)
                            targets.Add(to);
                    }
                    if (targets.Count > 0)
                        return new TriggerStruct(Name, player, targets);
                }
            }
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player skill_target, ref object data, Player player, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, skill_target, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player target, ref object data, Player player, TriggerStruct info)
        {
            List<string> choices = new List<string>();
            if (target.HandcardNum <= player.HandcardNum)
                choices.Add("nojink");
            if (target.Hp >= player.Hp)
                choices.Add("damage");

            if (choices.Count == 0)
                return false;

            CardUseStruct use = (CardUseStruct)data;
            while (choices.Count > 0)
            {
                string choice = room.AskForChoice(player, Name, string.Join("+", choices));
                if (choice == "nojink")
                {
                    LogMessage log = new LogMessage
                    {
                        Type = "#NoJink",
                        From = target.Name
                    };
                    room.SendLog(log);

                    int index = 0;
                    for (int i = 0; i < use.EffectCount.Count; i++)
                    {
                        CardBasicEffect effect = use.EffectCount[i];
                        if (effect.To == target)
                        {
                            index++;
                            if (index == info.Times)
                            {
                                effect.Effect2 = 0;
                                data = use;
                                break;
                            }
                        }
                    }
                }
                else if (choice == "damage")
                {
                    LogMessage log = new LogMessage
                    {
                        Type = "#Liegong_add",
                        From = target.Name,
                        To = new List<string> { target.Name }
                    };
                    room.SendLog(log);

                    int index = 0;
                    for (int i = 0; i < use.EffectCount.Count; i++)
                    {
                        CardBasicEffect effect = use.EffectCount[i];
                        if (effect.To == target)
                        {
                            index++;
                            if (index == info.Times)
                            {
                                effect.Effect1++;
                                data = use;
                                break;
                            }
                        }
                    }
                }
                else
                    break;

                choices.Remove(choice);
                if (choices.Count > 0 && !choices.Contains("cancel"))
                    choices.Add("cancel");
                else
                    break;
            }

            return false;
        }
    }
    /*
    public class LiegongRecord : TriggerSkill
    {
        public LiegongRecord() : base("#liegong-damage")
        {
            events = new List<TriggerEvent> { TriggerEvent.ConfirmDamage, TriggerEvent.CardFinished };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardFinished && data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName))
            {
                string tag = string.Format("liegong_{0}", RoomLogic.CardToString(room, use.Card));
                use.From.RemoveTag(tag);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.ConfirmDamage && data is DamageStruct damage && damage.From != null && damage.Card != null
                && damage.Card.Name.Contains(Slash.ClassName) && !damage.Transfer && !damage.Chain)
            {
                string tag = string.Format("liegong_{0}", RoomLogic.CardToString(room, damage.Card));
                List<string> targets = player.ContainsTag(tag) ? (List<string>)player.GetTag(tag) : new List<string>();
                if (targets.Contains(damage.To.Name))
                    return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                string tag = string.Format("liegong_{0}", RoomLogic.CardToString(room, damage.Card));
                List<string> targets = (List<string>)damage.From.GetTag(tag);
                targets.Remove(damage.To.Name);
                player.SetTag(tag, targets);
                damage.Damage++;
                data = damage;
            }

            return false;
        }
    }
    */
    public class LiegongTar : TargetModSkill
    {
        public LiegongTar() : base("#liegong-tar")
        {
        }

        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            if (from != null && RoomLogic.PlayerHasSkill(room, from, "liegong_jx") && to != null)
            {
                int distance = RoomLogic.DistanceTo(room, from, to, card);
                return distance > 0 && RoomLogic.GetCardNumber(room, card) >= distance;
            }

            return false;
        }

        public override void GetEffectIndex(Room room, Player player, WrappedCard card, ModType type, ref int index, ref string skill_name, ref string general_name, ref int skin_id)
        {
            index = -2;
        }
    }

    public class KuangguJX : TriggerSkill
    {
        public KuangguJX() : base("kuanggu_jx")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damage, TriggerEvent.PreDamageDone };
            skill_type = SkillType.Recover;
            frequency = Frequency.Compulsory;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (player != null && triggerEvent == TriggerEvent.PreDamageDone && data is DamageStruct damage)
            {
                Player weiyan = damage.From;
                if (weiyan != null)
                {
                    if (RoomLogic.DistanceTo(room, weiyan, damage.To) != -1 && RoomLogic.DistanceTo(room, weiyan, damage.To) <= 1)
                        weiyan.SetTag("InvokeKuanggu", damage.Damage);
                    else
                        weiyan.RemoveTag("InvokeKuanggu");
                }
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && triggerEvent == TriggerEvent.Damage && data is DamageStruct damage)
            {
                int recorded_damage = player.ContainsTag("InvokeKuanggu") ? (int)player.GetTag("InvokeKuanggu") : 0;
                if (recorded_damage > 0)
                {
                    TriggerStruct skill_list = new TriggerStruct(Name, player)
                    {
                        Times = damage.Damage
                    };
                    return skill_list;
                }
            }
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            return info;
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            List<string> choices = new List<string> { "draw" };
            if (player.IsWounded())
                choices.Add("recover");
            string result = room.AskForChoice(player, Name, string.Join("+", choices), null);
            if (result == "draw")
                room.DrawCards(player, 1, Name);
            else
            {
                RecoverStruct recover = new RecoverStruct
                {
                    Who = player,
                    Recover = 1
                };
                room.Recover(player, recover, true);
            }

            return false;
        }
    }

    public class QimouVS : ZeroCardViewAsSkill
    {
        public QimouVS() : base("qimou") { }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return player.Hp > 0 && player.GetMark("@mou") > 0;
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            WrappedCard qimou = new WrappedCard(QimouCard.ClassName)
            {
                Skill = Name,
                Mute = true
            };
            return qimou;
        }
    }

    public class Qimou : TriggerSkill
    {
        public Qimou() : base("qimou")
        {
            limit_mark = "@mou";
            skill_type = SkillType.Attack;
            events.Add(TriggerEvent.EventPhaseChanging);
            view_as_skill = new QimouVS();
            frequency = Frequency.Limited;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player.GetMark(Name) > 0)
                player.SetMark(Name, 0);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class QimouTar : TargetModSkill
    {
        public QimouTar() : base("#qimou-tar", false) { }

        public override int GetResidueNum(Room room, Player from, WrappedCard card)
        {
            return Engine.MatchExpPattern(room, pattern, from, card) ? from.GetMark("qimou") : 0;
        }
    }

    public class QimouDistance : DistanceSkill
    {
        public QimouDistance() : base("#qimou-distance") { }

        public override int GetCorrect(Room room, Player from, Player to, WrappedCard card = null)
        {
            return -from.GetMark("qimou");
        }
    }

    public class QimouCard : SkillCard
    {
        public static string ClassName = "QimouCard";
        public QimouCard() : base(ClassName)
        {
            target_fixed = true;
        }

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            room.SetPlayerMark(card_use.From, "@mou", 0);
            room.BroadcastSkillInvoke("qimou", card_use.From, card_use.Card.SkillPosition);
            room.DoSuperLightbox(card_use.From, card_use.Card.SkillPosition, "qimou");
            base.OnUse(room, card_use);
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            if (player.Alive && player.Hp > 0)
            {
                List<string> choices = new List<string>();
                for (int i = player.Hp; i > 0; i--)
                    choices.Add(i.ToString());

                int lose = int.Parse(room.AskForChoice(player, "qimou", string.Join("+", choices), new List<string> { "@qimou-lose" }));
                room.LoseHp(player, lose);

                if (player.Alive)
                    player.SetMark("qimou", lose);
            }
        }
    }

    public class Ruoyu : PhaseChangeSkill
    {
        public Ruoyu() : base("ruoyu")
        {
            frequency = Frequency.Wake;
            lord_skill = true;
            skill_type = SkillType.Recover;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Start && base.Triggerable(player, room) && player.GetMark(Name) == 0)
            {
                int min = 100;
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.Hp < min)
                        min = p.Hp;
                }
                if (player.Hp == min)
                    return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override bool OnPhaseChange(Room room, Player player, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.DoSuperLightbox(player, info.SkillPosition, Name);
            room.SetPlayerMark(player, Name, 1);
            room.SendCompulsoryTriggerLog(player, Name);
            if (player.Alive)
            {
                player.MaxHp++;
                room.BroadcastProperty(player, "MaxHp");

                LogMessage log = new LogMessage
                {
                    Type = "$GainMaxHp",
                    From = player.Name,
                    Arg = "1"
                };
                room.SendLog(log);

                room.RoomThread.Trigger(TriggerEvent.MaxHpChanged, room, player);
                RecoverStruct recover = new RecoverStruct
                {
                    Who = player,
                    Recover = 1
                };
                room.Recover(player, recover, true);

                room.HandleAcquireDetachSkills(player, "jijiang", true);
            }

            return false;
        }
    }

    public class Zhiji : PhaseChangeSkill
    {
        public Zhiji() : base("zhiji")
        {
            frequency = Frequency.Wake;
            skill_type = SkillType.Recover;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Start && player.GetMark(Name) == 0 && base.Triggerable(player, room) && player.IsKongcheng())
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool OnPhaseChange(Room room, Player player, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.DoSuperLightbox(player, info.SkillPosition, Name);
            room.SetPlayerMark(player, Name, 1);
            room.SendCompulsoryTriggerLog(player, Name);

            List<string> choices = new List<string> { "draw" };
            if (player.GetLostHp() > 0)
            {
                choices.Add("recover");
            }
            if (room.AskForChoice(player, Name, string.Join("+", choices)) == "recover")
            {
                RecoverStruct recover = new RecoverStruct
                {
                    Recover = 1,
                    Who = player
                };
                room.Recover(player, recover, true);
            }
            else
                room.DrawCards(player, 2, Name);

            room.LoseMaxHp(player);
            if (player.Alive)
                room.HandleAcquireDetachSkills(player, "guanxing_jx", true);

            return false;
        }
    }

    public class LierenJX : TriggerSkill
    {
        public LierenJX() : base("lieren_jx")
        {
            events.Add(TriggerEvent.TargetChosen);
            skill_type = SkillType.Attack;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player zhurong, ref object data, Player ask_who)
        {
            if (base.Triggerable(zhurong, room) && data is CardUseStruct use && use.Card != null)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is Slash && !zhurong.IsKongcheng())
                {
                    List<Player> targets = new List<Player>();
                    foreach (Player p in use.To)
                        if (RoomLogic.CanBePindianBy(room, p, zhurong)) targets.Add(p);

                    if (targets.Count > 0)
                        return new TriggerStruct(Name, zhurong, targets);
                }
            }
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player target, ref object data, Player zhurong, TriggerStruct info)
        {
            if (!zhurong.IsKongcheng() && RoomLogic.CanBePindianBy(room, target, zhurong))
            {
                target.SetFlags("lieren_target");
                bool invoke = room.AskForSkillInvoke(zhurong, Name, target, info.SkillPosition);
                target.SetFlags("-lieren_target");

                if (invoke)
                {
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, zhurong.Name, target.Name);
                    GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, zhurong, Name, info.SkillPosition);
                    room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                    PindianStruct pd = room.PindianSelect(zhurong, target, Name);
                    room.SetTag("lieren_pd", pd);
                    return info;
                }
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player target, ref object data, Player zhurong, TriggerStruct info)
        {
            PindianStruct pd = (PindianStruct)room.GetTag("lieren_pd");
            room.RemoveTag("lieren_pd");
            room.Pindian(ref pd);
            if (pd.Success)
            {
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, zhurong, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);
                if (RoomLogic.CanGetCard(room, zhurong, target, "he"))
                {
                    int card_id = room.AskForCardChosen(zhurong, target, "he", Name, false, HandlingMethod.MethodGet);
                    CardMoveReason reason = new CardMoveReason(CardMoveReason.MoveReason.S_REASON_EXTRACTION, zhurong.Name);
                    room.ObtainCard(zhurong, room.GetCard(card_id), reason, room.GetCardPlace(card_id) != Place.PlaceHand);
                }
            }
            else
            {
                List<CardsMoveStruct> moves = new List<CardsMoveStruct>();
                if (room.GetCardPlace(pd.From_card.Id) == Place.DiscardPile)
                {
                    CardsMoveStruct move1 = new CardsMoveStruct(pd.From_card.Id, target, Place.PlaceHand,
                        new CardMoveReason(CardMoveReason.MoveReason.S_REASON_GOTBACK, target.Name, Name, string.Empty));
                    moves.Add(move1);
                }
                if (room.GetCardPlace(pd.To_cards[0].Id) == Place.DiscardPile)
                {
                    CardsMoveStruct move2 = new CardsMoveStruct(pd.To_cards[0].Id, zhurong, Place.PlaceHand,
                        new CardMoveReason(CardMoveReason.MoveReason.S_REASON_GOTBACK, zhurong.Name, Name, string.Empty));
                    moves.Add(move2);
                }
                if (moves.Count > 0)
                    room.MoveCardsAtomic(moves, true);
            }

            return false;
        }
    }

    public class ZaiqiJX : TriggerSkill
    {
        public ZaiqiJX() : base("zaiqi_jx")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseEnd, TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseChanging };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.To_place == Place.DiscardPile)
            {
                int count = room.ContainsTag(Name) ? (int)room.GetTag(Name) : 0;
                foreach (int id in move.Card_ids)
                    if (WrappedCard.IsRed(room.GetCard(id).Suit)) count++;

                room.SetTag(Name, count);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                room.RemoveTag(Name);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseEnd && base.Triggerable(player, room) && player.Phase == PlayerPhase.Discard && room.ContainsTag(Name)
                && room.GetTag(Name) is int count && count > 0)
            {
                return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is int count)
            {
                List<Player> targets = room.AskForPlayersChosen(player, room.GetAlivePlayers(), Name, 0, count, "@zaiqi", true, info.SkillPosition);
                if (targets.Count > 0)
                {
                    room.SortByActionOrder(ref targets);
                    room.SetTag("tuxi_invoke" + player.Name, targets);
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            string str = "tuxi_invoke" + player.Name;
            List<Player> targets = room.ContainsTag(str) ? (List<Player>)room.GetTag(str) : new List<Player>();
            room.RemoveTag(str);

            foreach (Player p in targets)
            {
                if (p.Alive)
                {
                    List<string> choices = new List<string> { "draw" };
                    List<string> prompts = new List<string> { string.Empty, string.Empty };
                    if (player.Alive && player.IsWounded())
                    {
                        choices.Add("heal");
                        prompts.Add("@zaiqi:" + player.Name);
                    }

                    if (room.AskForChoice(p, Name, string.Join("+", choices), null, player) == "draw")
                        room.DrawCards(p, new DrawCardStruct(1, player, Name));
                    else
                    {
                        RecoverStruct recover = new RecoverStruct
                        {
                            Recover = 1,
                            Who = p
                        };
                        room.Recover(player, recover, true);
                    }
                }
            }

            return false;
        }
    }

    public class JiemingJX : MasochismSkill
    {
        public JiemingJX() : base("jieming_jx")
        {
            skill_type = SkillType.Masochism;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player != null && player.Alive && RoomLogic.PlayerHasSkill(room, player, Name) && data is DamageStruct damage)
            {
                TriggerStruct trigger = new TriggerStruct(Name, player)
                {
                    Times = damage.Damage
                };
                return trigger;
            }

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (!player.Alive)
                return new TriggerStruct();

            Player target = room.AskForPlayerChosen(player, room.GetAlivePlayers(), Name, "jieming-invoke", true, true, info.SkillPosition);
            if (target != null)
            {
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, player, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", (target == player ? 2 : 1), gsk.General, gsk.SkinId);

                List<string> target_list = player.ContainsTag("jieming_target") ? (List<string>)player.GetTag("jieming_target") : new List<string>();
                target_list.Add(target.Name);
                player.SetTag("jieming_target", target_list);

                return info;
            }
            return new TriggerStruct();
        }
        public override void OnDamaged(Room room, Player player, DamageStruct damage, TriggerStruct info)
        {
            List<string> target_list = (List<string>)player.GetTag("jieming_target");
            string target_name = target_list[target_list.Count - 1];
            target_list.RemoveAt(target_list.Count - 1);
            player.SetTag("jieming_target", target_list);

            Player to = room.FindPlayer(target_name);

            if (to != null)
            {
                int upper = Math.Min(5, to.MaxHp);
                int x = upper - to.HandcardNum;
                if (x > 0)
                    room.DrawCards(to, new DrawCardStruct(x, player, Name));
            }
        }
    }

    public class Zaoxian : PhaseChangeSkill
    {
        public Zaoxian() : base("zaoxian")
        {
            frequency = Frequency.Wake;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Start && player.GetMark(Name) == 0 && base.Triggerable(player, room) && player.GetPile("field").Count >= 3)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool OnPhaseChange(Room room, Player player, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.DoSuperLightbox(player, info.SkillPosition, Name);
            room.SetPlayerMark(player, Name, 1);
            room.SendCompulsoryTriggerLog(player, Name);

            room.LoseMaxHp(player);
            if (player.Alive)
                room.HandleAcquireDetachSkills(player, "jixi", true);

            return false;
        }
    }

    public class QiangxiJXCard : SkillCard
    {
        public static string ClassName = "QiangxiJXCard";
        public QiangxiJXCard() : base(ClassName)
        {
        }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            if (targets.Count > 0 || to_select == Self || Self.HasFlag(string.Format("qiangxi-{0}", to_select.Name)))
                return false;

            return RoomLogic.InMyAttackRange(room, Self, to_select, card);
        }
        public override void Use(Room room, CardUseStruct card_use)
        {
            if (card_use.Card.SubCards.Count == 0)
            {
                room.LoseHp(card_use.From);
                //card_use.From.SetFlags("qingxi");
            }
            //else
            //card_use.From.SetFlags("qiangxi_weapon");
            card_use.From.SetFlags(string.Format("qiangxi-{0}", card_use.To[0].Name));

            base.Use(room, card_use);
        }
        public override void OnEffect(Room room, CardEffectStruct effect)
        {
            room.Damage(new DamageStruct("qiangxi_jx", effect.From, effect.To));
        }
    }

    public class QiangxiJX : ViewAsSkill
    {
        public QiangxiJX() : base("qiangxi_jx")
        {
            skill_type = SkillType.Attack;
        }
        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            //return !player.HasFlag("qiangxi_weapon") || !player.HasFlag("qingxi");
            return true;
        }
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            //if (player.HasFlag("qiangxi_weapon")) return false;
            FunctionCard fcard = Engine.GetFunctionCard(to_select.Name);
            return selected.Count == 0 && fcard is Weapon && !RoomLogic.IsJilei(room, player, to_select);
        }
        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count == 0)
            {
                WrappedCard card = new WrappedCard(QiangxiJXCard.ClassName)
                {
                    Skill = Name,
                    ShowSkill = Name
                };
                return card;
            }
            else if (cards.Count == 1)
            {
                WrappedCard card = new WrappedCard(QiangxiJXCard.ClassName)
                {
                    Skill = Name,
                    ShowSkill = Name
                };
                card.AddSubCards(cards);
                return card;
            }
            else
                return null;
        }

        public override void GetEffectIndex(Room room, Player player, WrappedCard card, ref int index, ref string skill_name, ref string general_name, ref int skin_id)
        {
            index = 2 - card.SubCards.Count;
        }
    }

    #region 吴
    public class BuquJX : TriggerSkill
    {
        public BuquJX() : base("buqu_jx")
        {
            events.Add(TriggerEvent.AskForPeaches);
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Defense;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is DyingStruct dying && dying.Who == player && base.Triggerable(player, room) && player.Hp <= 0)
            {
                return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (RoomLogic.PlayerHasShownSkill(room, player, Name) || room.AskForSkillInvoke(player, Name, null, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name, true);
            int id = room.GetNCards(1)[0];
            int num = room.GetCard(id).Number;
            bool duplicate = false;
            List<int> buqu = player.GetPile(Name);
            room.AddToPile(player, Name, id);
            Thread.Sleep(500);

            foreach (int card_id in buqu)
            {
                if (room.GetCard(card_id).Number == num)
                {
                    duplicate = true;
                    LogMessage log = new LogMessage
                    {
                        Type = "#BuquDuplicate",
                        From = player.Name
                    };
                    List<string> number_string = new List<string> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
                    log.Arg = number_string[num - 1];
                    room.SendLog(log);

                    log = new LogMessage
                    {
                        Type = "$BuquDuplicateItem",
                        From = player.Name,
                        Card_str = card_id.ToString()
                    };
                    room.SendLog(log);
                    break;
                }
            }
            if (duplicate)
            {
                CardMoveReason reason = new CardMoveReason(CardMoveReason.MoveReason.S_REASON_REMOVE_FROM_PILE, null, Name, null);
                List<int> ints = new List<int> { id };
                room.ThrowCard(ref ints, reason, null);
                Thread.Sleep(1000);
            }
            else
            {
                RecoverStruct recover = new RecoverStruct
                {
                    Recover = 1 - player.Hp,
                    Who = player
                };
                room.Recover(player, recover, true);
            }

            return false;
        }
    }

    public class BuquMax : MaxCardsSkill
    {
        public BuquMax() : base("#buqu-max") { }

        public override int GetFixed(Room room, Player target)
        {
            if (target.GetPile("buqu_jx").Count > 0)
                return target.GetPile("buqu_jx").Count;

            return -1;
        }
    }

    public class BuquJXClear : DetachEffectSkill
    {
        public BuquJXClear() : base("buqu_jx", "buqu_jx")
        {
            frequency = Frequency.Compulsory;
        }
    }
    public class FenjiJX : TriggerSkill
    {
        public FenjiJX() : base("fenji_jx")
        {
            events.Add(TriggerEvent.CardsMoveOneTime);
            skill_type = SkillType.Replenish;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (data is CardsMoveOneTimeStruct move && move.From != null && move.From.Alive && move.From_places.Contains(Place.PlaceHand))
            {
                if ((move.Reason.Reason == CardMoveReason.MoveReason.S_REASON_EXTRACTION
                    || (move.Reason.Reason & CardMoveReason.MoveReason.S_MASK_BASIC_REASON) == CardMoveReason.MoveReason.S_REASON_DISCARD)
                    && !string.IsNullOrEmpty(move.Reason.PlayerId) && move.Reason.PlayerId != move.From.Name)
                {
                    List<Player> zhoutais = RoomLogic.FindPlayersBySkillName(room, Name);
                    foreach (Player p in zhoutais)
                    {
                        triggers.Add(new TriggerStruct(Name, p));
                    }
                }
            }

            return triggers;
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move && move.From.Alive && ask_who.Alive)
            {
                move.From.SetFlags("fenji_target");
                bool invoke = room.AskForSkillInvoke(ask_who, Name, move.From, info.SkillPosition);
                move.From.SetFlags("-fenji_target");

                if (invoke)
                {
                    room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, move.From.Name);
                    return info;
                }
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move && move.From.Alive)
            {
                room.DrawCards(move.From, new DrawCardStruct(2, ask_who, Name));
                if (ask_who.Alive)
                    room.LoseHp(ask_who);
            }

            return false;
        }
    }

    public class TianxiangJXViewAsSkill : OneCardViewAsSkill
    {
        public TianxiangJXViewAsSkill() : base("tianxiang_jx")
        {
        }
        public override bool IsAvailable(Room room, Player invoker, CardUseReason reason, string pattern, string position = null)
        {
            return reason == CardUseReason.CARD_USE_REASON_RESPONSE_USE && pattern == "@@tianxiang_jx";
        }
        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard tianxiangCard = new WrappedCard(TianxiangCard.ClassName);
            tianxiangCard.AddSubCard(card);
            tianxiangCard.Skill = Name;
            return tianxiangCard;
        }
        public override bool ViewFilter(Room room, WrappedCard to_select, Player player)
        {
            if (RoomLogic.IsJilei(room, player, to_select)) return false;
            string pat = ".|heart|.|hand";
            CardPattern pattern = Engine.GetPattern(pat);
            return pattern.Match(player, room, to_select);
        }
    }

    public class TianxiangJX : TriggerSkill
    {
        public TianxiangJX() : base("tianxiang_jx")
        {
            events.Add(TriggerEvent.DamageInflicted);
            skill_type = SkillType.Defense;
            view_as_skill = new TianxiangJXViewAsSkill();
        }
        public override bool CanPreShow() => true;
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player xiaoqiao, ref object data, Player ask_who)
        {
            if (base.Triggerable(xiaoqiao, room) && RoomLogic.CanDiscard(room, xiaoqiao, xiaoqiao, "h"))
                return new TriggerStruct(Name, xiaoqiao);
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player xiaoqiao, ref object data, Player ask_who, TriggerStruct info)
        {
            xiaoqiao.SetFlags("-tianxiang_invoke");
            room.SetTag("TianxiangDamage", data);
            room.AskForUseCard(xiaoqiao, "@@tianxiang_jx", "@tianxiang_jx-card", -1, HandlingMethod.MethodDiscard, true, info.SkillPosition);
            room.RemoveTag("TianxiangDamage");
            if (xiaoqiao.HasFlag("tianxiang_invoke"))
                return info;

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player xiaoqiao, ref object data, Player ask_who, TriggerStruct info)
        {
            LogMessage log = new LogMessage
            {
                Type = "#damaged-prevent",
                From = xiaoqiao.Name,
                Arg = Name
            };
            room.SendLog(log);

            return true;
        }
    }

    public class TianxiangSecond : TriggerSkill
    {
        public TianxiangSecond() : base("#tianxian-second")
        {
            events.Add(TriggerEvent.DamageComplete);
            frequency = Frequency.Compulsory;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is DamageStruct damage && damage.To == player && player.ContainsTag("tianxiang_target") && player.HasFlag("tianxiang_invoke"))
            {
                Player target = room.FindPlayer((string)player.GetTag("tianxiang_target"));
                if (target != null && target.Alive)
                {
                    return new TriggerStruct(Name, player);
                }
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player xiaoqiao, ref object data, Player player, TriggerStruct info)
        {
            Player target = room.FindPlayer((string)xiaoqiao.GetTag("tianxiang_target"));
            xiaoqiao.SetFlags("-tianxiang_invoke");
            DamageStruct damage = (DamageStruct)data;
            room.SetTag("TianxiangDamage", data);
            string choice = room.AskForChoice(xiaoqiao, "tianxiang_jx", "damage+losehp", new List<string> { "@tianxiang-target:" + target.Name });
            room.RemoveTag("TianxiangDamage");
            xiaoqiao.RemoveTag("tianxiang_target");

            if (choice == "damage")
            {
                room.Damage(new DamageStruct("tianxiang_jx", damage.From, target));
                if (target.Alive)
                    room.DrawCards(target, Math.Min(5, target.GetLostHp()), "tianxiang_jx");
            }
            else if (xiaoqiao.GetTag("tianxiang_card") is int id)
            {
                room.LoseHp(target);
                if (target.Alive && room.GetCardPlace(id) == Place.DiscardPile)
                    room.ObtainCard(target, room.GetCard(id), new CardMoveReason(CardMoveReason.MoveReason.S_REASON_RECYCLE, target.Name, "tianxiang_jx", string.Empty));
            }
            xiaoqiao.RemoveTag("tianxiang_card");

            return false;
        }
    }

    public class Hunzi : PhaseChangeSkill
    {
        public Hunzi() : base("hunzi")
        {
            frequency = Frequency.Wake;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Start && player.GetMark(Name) == 0 && base.Triggerable(player, room) && player.Hp == 1)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool OnPhaseChange(Room room, Player player, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.DoSuperLightbox(player, info.SkillPosition, Name);
            room.SetPlayerMark(player, Name, 1);
            room.SendCompulsoryTriggerLog(player, Name);

            room.LoseMaxHp(player);
            if (player.Alive)
            {
                List<string> skills = new List<string> { "yinghun_sunce", "yingzi_sunce" };
                room.HandleAcquireDetachSkills(player, skills);
            }

            return false;
        }
    }

    public class Zhiba : TriggerSkill
    {
        public Zhiba() : base("zhiba")
        {
            events = new List<TriggerEvent> { TriggerEvent.GameStart };
            lord_skill = true;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.GameStart && base.Triggerable(player, room))
            {
                if (!room.Skills.Contains("zhibavs"))
                    room.Skills.Add("zhibavs");
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.GetRoleEnum() != PlayerRole.Lord && p.Kingdom == "wu")
                        room.HandleAcquireDetachSkills(p, "zhibavs", true);
                }
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            return new TriggerStruct();
        }
    }

    public class ZhibaVS : ZeroCardViewAsSkill
    {
        public ZhibaVS() : base("zhibavs")
        {
            attached_lord_skill = true;
            frequency = Frequency.Compulsory;
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            List<Player> jiaozhu = RoomLogic.FindPlayersBySkillName(room, "zhiba");
            return jiaozhu.Count > 0 && player.Kingdom == "wu" && !player.HasUsed(ZhibaCard.ClassName) && !player.IsKongcheng();
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(ZhibaCard.ClassName);
        }
    }

    public class ZhibaCard : SkillCard
    {
        public static string ClassName = "ZhibaCard";
        public ZhibaCard() : base(ClassName)
        {
            handling_method = HandlingMethod.MethodNone;
            will_throw = false;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            List<Player> jiaozhu = RoomLogic.FindPlayersBySkillName(room, "zhiba");
            if (jiaozhu.Count < 2) return RoomLogic.CanBePindianBy(room, jiaozhu[0], Self);

            return targets.Count == 0 && jiaozhu.Contains(to_select) && RoomLogic.CanBePindianBy(room, to_select, Self);
        }

        public override bool TargetsFeasible(Room room, List<Player> targets, Player Self, WrappedCard card)
        {
            List<Player> jiaozhu = RoomLogic.FindPlayersBySkillName(room, "zhiba");
            return (jiaozhu.Count == 1 && targets.Count == 0) || (targets.Count == 1 && jiaozhu.Contains(targets[0]));
        }

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            List<Player> jiaozhu = RoomLogic.FindPlayersBySkillName(room, "zhiba");
            Player target = null, player = card_use.From;
            if (jiaozhu.Count == 1 && card_use.To.Count == 0)
                target = jiaozhu[0];
            else if (card_use.To.Count == 1 && jiaozhu.Contains(card_use.To[0]))
                target = card_use.To[0];

            bool do_pd = true;
            if (target.GetMark("hunzi") > 0)
                do_pd = room.AskForSkillInvoke(target, "zhiba", "@zhiba-refuse:" + player.Name);

            if (do_pd)
            {
                if (RoomLogic.PlayerHasSkill(room, target, "weidi_jx"))
                {
                    room.BroadcastSkillInvoke("weidi_jx", target);
                    room.NotifySkillInvoked(target, "weidi_jx");
                }
                else
                {
                    room.BroadcastSkillInvoke("zhiba", target);
                    room.NotifySkillInvoked(target, "zhiba");
                }

                PindianStruct pd = room.PindianSelect(player, target, "zhiba");
                room.Pindian(ref pd);
                if (!pd.Success && room.AskForSkillInvoke(target, "zhiba", "@zhiba"))
                {
                    List<int> ids = new List<int>();
                    if (room.GetCardPlace(pd.From_card.Id) == Place.DiscardPile)
                        ids.Add(pd.From_card.Id);
                    if (room.GetCardPlace(pd.To_cards[0].Id) == Place.DiscardPile)
                        ids.Add(pd.To_cards[0].Id);

                    if (ids.Count > 0 && target.Alive)
                        room.ObtainCard(target, ref ids, new CardMoveReason(CardMoveReason.MoveReason.S_REASON_GOTBACK, target.Name));
                }
            }
        }
    }

    public class PoluSJ : TriggerSkill
    {
        public PoluSJ() : base("polu_sj")
        {
            events.Add(TriggerEvent.Death);
            skill_type = SkillType.Replenish;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is DeathStruct death)
            {
                if (RoomLogic.PlayerHasSkill(room, player, Name))
                    return new TriggerStruct(Name, player);
                else if (death.Damage.From != null && base.Triggerable(death.Damage.From, room))
                    return new TriggerStruct(Name, death.Damage.From);
            }

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player p, ref object data, Player player, TriggerStruct info)
        {
            int count = player.ContainsTag(Name) ? (int)player.GetTag(Name) : 0;
            List<Player> targets = room.AskForPlayersChosen(player, room.GetAlivePlayers(), Name, 0, room.AliveCount(), string.Format("@polu_sj:::{0}", count + 1), true, info.SkillPosition);
            if (targets.Count > 0)
            {
                room.SortByActionOrder(ref targets);
                room.SetTag("tuxi_invoke" + player.Name, targets);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            string str = "tuxi_invoke" + ask_who.Name;
            List<Player> targets = room.ContainsTag(str) ? (List<Player>)room.GetTag(str) : new List<Player>();
            room.RemoveTag(str);

            int count = ask_who.ContainsTag(Name) ? (int)ask_who.GetTag(Name) : 0;
            count++;
            ask_who.SetTag(Name, count);

            foreach (Player p in targets)
                if (p.Alive)
                    room.DrawCards(p, new DrawCardStruct(count, ask_who, Name));

            return false;
        }
    }
    #endregion

    #region 神
    public class WushenFilter : FilterSkill
    {
        public WushenFilter() : base("wushen")
        {
        }

        public override bool ViewFilter(Room room, WrappedCard to_select, Player player)
        {
            return to_select.Suit == WrappedCard.CardSuit.Heart && room.GetCardPlace(to_select.Id) == Place.PlaceHand;
        }
        public override void ViewAs(Room room, ref WrappedCard card, Player player)
        {
            WrappedCard new_card = new WrappedCard(Slash.ClassName, card.Id, card.Suit, card.Number, card.CanRecast, card.Transferable)
            {
                CanRecast = card.CanRecast,
                Skill = Name,
                ShowSkill = card.ShowSkill,
                UserString = card.UserString,
                Flags = card.Flags,
                Mute = card.Mute,
            };

            card.TakeOver(new_card);
            card.Modified = true;
        }
    }

    public class Wushen : TriggerSkill
    {
        public Wushen() : base("wushen")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsedAnnounced, TriggerEvent.CardResponded };
            frequency = Frequency.Compulsory;
            view_as_skill = new WushenFilter();
            skill_type = SkillType.Alter;
        }
        public override bool CanPreShow() => true;
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardUsedAnnounced && data is CardUseStruct use && use.Card.Name == Slash.ClassName && use.Card.Skill == Name)
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.CardResponded && data is CardResponseStruct resp && resp.Card.Name == Slash.ClassName && resp.Card.Skill == Name)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.CardUsedAnnounced || triggerEvent == TriggerEvent.CardResponded)
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);

            return new TriggerStruct();
        }

        public override void GetEffectIndex(Room room, Player player, WrappedCard card, ref int index, ref string skill_name, ref string general_name, ref int skin_id)
        {
            index = -2;
        }
    }

    public class WushenTar : TargetModSkill
    {
        public WushenTar() : base("#wushen-target") { }
        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            if (RoomLogic.PlayerHasSkill(room, from, "wushen") && RoomLogic.GetCardSuit(room, card) == WrappedCard.CardSuit.Heart)
                return true;

            return false;
        }
        public override void GetEffectIndex(Room room, Player player, WrappedCard card, ModType type, ref int index, ref string skill_name, ref string general_name, ref int skin_id)
        {
            index = -2;
        }
    }

    public class Wuhun : TriggerSkill
    {
        public Wuhun() : base("wuhun")
        {
            events = new List<TriggerEvent> { TriggerEvent.Death, TriggerEvent.Damaged };
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Wizzard;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.Damaged && base.Triggerable(player, room) && data is DamageStruct damage && damage.From != null && damage.From.Alive)
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.Death && RoomLogic.PlayerHasSkill(room, player, Name))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, player, Name, info.SkillPosition);
            if (triggerEvent == TriggerEvent.Damaged && data is DamageStruct damage)
            {
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, damage.From.Name);
                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                return info;
            }
            else
            {
                int count = 0;
                List<Player> targets = new List<Player>();
                foreach (Player p in room.GetOtherPlayers(player))
                {
                    if (p.GetMark("@night") > count)
                        count = p.GetMark("@night");
                }
                if (count == 0) return new TriggerStruct();

                foreach (Player p in room.GetOtherPlayers(player))
                    if (p.GetMark("@night") == count)
                        targets.Add(p);

                if (targets.Count > 0)
                {
                    Player target = room.AskForPlayerChosen(player, targets, Name, "@wuhun", false, true, info.SkillPosition);
                    player.SetTag(Name, target.Name);
                    room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);
                    return info;
                }
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);

            if (triggerEvent == TriggerEvent.Damaged && data is DamageStruct damage)
            {
                room.AddPlayerMark(damage.From, "@night");
            }
            else if (triggerEvent == TriggerEvent.Death)
            {
                Player target = room.FindPlayer(player.GetTag(Name).ToString());
                player.RemoveTag(Name);

                JudgeStruct judge = new JudgeStruct
                {
                    Who = target,
                    Pattern = "Peach#GodSalvation",
                    Good = false,
                    PlayAnimation = true,
                    Reason = Name,
                    Negative = true
                };

                room.Judge(ref judge);

                if (judge.IsEffected() && target.Alive)
                {
                    target.Hp = 0;
                    room.BroadcastProperty(target, "Hp");
                    room.KillPlayer(target, new DamageStruct());
                }
            }

            return false;
        }
    }

    public class Qinyin : TriggerSkill
    {
        public Qinyin() : base("qinyin")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseEnd };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null && move.From.Phase == PlayerPhase.Discard
                && base.Triggerable(move.From, room) && move.From_places.Contains(Place.PlaceHand) && move.Reason.PlayerId == move.From.Name
                && (move.Reason.Reason & CardMoveReason.MoveReason.S_MASK_BASIC_REASON) == CardMoveReason.MoveReason.S_REASON_DISCARD)
                foreach (Place place in move.From_places)
                    if (place == Place.PlaceHand)
                        move.From.AddMark(Name);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseEnd && base.Triggerable(player, room) && player.Phase == PlayerPhase.Discard && player.GetMark(Name) > 1)
            {
                return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player lengtong, TriggerStruct info)
        {
            List<string> choices = new List<string> { "lose" };
            foreach (Player p in room.GetAlivePlayers())
            {
                if (p.IsWounded())
                {
                    choices.Add("recover");
                    break;
                }
            }
            choices.Add("cancel");

            string choice = room.AskForChoice(player, Name, string.Join("+", choices));
            if (choice != "cancel")
            {
                player.SetTag(Name, choice);
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, player, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", choice == "recover" ? 1 : 2, gsk.General, gsk.SkinId);
                return info;
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player lengtong, TriggerStruct info)
        {
            string choice = player.GetTag(Name).ToString();
            List<Player> targets = room.GetAlivePlayers();
            room.SortByActionOrder(ref targets);
            if (choice == "recover")
            {
                RecoverStruct recover = new RecoverStruct
                {
                    Recover = 1,
                    Who = player
                };
                foreach (Player p in targets)
                    room.Recover(p, recover, true);
            }
            else
            {
                foreach (Player p in targets)
                    room.LoseHp(p);
            }

            return false;
        }
    }

    public class QinyinClear : TriggerSkill
    {
        public QinyinClear() : base("#qinyin-clear")
        {
            events.Add(TriggerEvent.EventPhaseEnd);
        }

        public override int GetPriority()
        {
            return 0;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseEnd && player.Phase == PlayerPhase.Discard && player.GetMark("qinyin") > 0)
                player.SetMark("qinyin", 0);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class Yeyan : ViewAsSkill
    {
        public Yeyan() : base("yeyan")
        {
            limit_mark = "@fire";
            frequency = Frequency.Limited;
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return player.GetMark(limit_mark) > 0;
        }

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            if (selected.Count > 3 || room.GetCardPlace(to_select.Id) != Place.PlaceHand || !RoomLogic.CanDiscard(room, player, player, to_select.Id))
                return false;

            if (selected.Count > 0)
            {
                List<WrappedCard.CardSuit> suits = new List<WrappedCard.CardSuit>();
                foreach (WrappedCard card in selected)
                    suits.Add(card.Suit);

                return !suits.Contains(to_select.Suit);
            }

            return true;
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count == 0 || cards.Count == 4)
            {
                WrappedCard yy = new WrappedCard(YeyanCard.ClassName) { Skill = Name };
                yy.AddSubCards(cards);
                return yy;
            }

            return null;
        }
    }

    public class YeyanCard : SkillCard
    {
        public static string ClassName = "YeyanCard";
        public YeyanCard() : base(ClassName)
        {
            votes = true;
            will_throw = true;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            if (targets.Count >= 3) return false;
            if (card.SubCards.Count == 0)
                return !targets.Contains(to_select);
            else if (card.SubCards.Count == 4 && targets.Count == 2)
                return targets.Contains(to_select) || targets[0] == targets[1];

            return true;
        }

        public override bool TargetsFeasible(Room room, List<Player> targets, Player Self, WrappedCard card)
        {
            if (targets.Count == 0) return false;
            if (card.SubCards.Count == 0)
                return targets.Count <= 3;
            else if (card.SubCards.Count == 4 && targets.Count > 1 && targets.Count <= 3)
            {
                for (int i = 0; i < targets.Count; i++)
                {
                    Player p1 = targets[i];
                    for (int x = i + 1; x < targets.Count; x++)
                    {
                        Player p2 = targets[x];
                        if (p2 == p1)
                            return true;
                    }
                }
            }

            return false;
        }

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            room.SetPlayerMark(card_use.From, "@fire", 0);
            room.BroadcastSkillInvoke("yeyan", card_use.From, card_use.Card.SkillPosition);
            room.DoSuperLightbox(card_use.From, card_use.Card.SkillPosition, "yeyan");

            List<Player> targets = new List<Player>();
            for (int i = 0; i < card_use.To.Count; i++)
            {
                int count = 1;
                Player p1 = card_use.To[i];
                if (targets.Contains(p1)) continue;
                for (int x = i + 1; x < card_use.To.Count; x++)
                {
                    Player p2 = card_use.To[x];
                    if (p2 == p1)
                    {
                        count++;
                    }
                }

                p1.SetMark("yeyan", count);
                targets.Add(p1);
            }

            card_use.To = targets;
            card_use.Card.Mute = true;
            base.OnUse(room, card_use);
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            if (card_use.Card.SubCards.Count > 0)
                room.LoseHp(card_use.From, 3);

            base.Use(room, card_use);
        }

        public override void OnEffect(Room room, CardEffectStruct effect)
        {
            Player player = effect.From, target = effect.To;
            int count = target.GetMark("yeyan");
            target.SetMark("yeyan", 0);

            if (target.Alive)
                room.Damage(new DamageStruct("yeyan", player, target, count, DamageStruct.DamageNature.Fire));
        }
    }

    public class Qixing : TriggerSkill
    {
        public Qixing() : base("qixing")
        {
            events = new List<TriggerEvent> { TriggerEvent.GameStart, TriggerEvent.EventPhaseEnd };
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.GameStart && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.EventPhaseEnd && player.Phase == PlayerPhase.Draw && base.Triggerable(player, room)
                && player.HandcardNum > 0 && player.GetPile(Name).Count > 0)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.GameStart)
            {
                room.NotifySkillInvoked(player, Name);
                return info;
            }
            else if (room.AskForSkillInvoke(player, Name, null, info.SkillPosition))
            {
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            if (triggerEvent == TriggerEvent.GameStart)
            {
                List<int> ids = room.GetNCards(7, true);
                room.AddToPile(player, Name, ids, false, new List<Player> { player });
            }

            List<int> stars = player.GetPile(Name);
            if (stars.Count > 0 && player.HandcardNum > 0)
            {
                List<int> ups = player.GetCards("h");
                AskForMoveCardsStruct move = room.AskForMoveCards(player, ups, stars, true, Name, stars.Count, stars.Count, false, false, new List<int>(), info.SkillPosition);
                if (move.Success)
                {
                    List<int> up = new List<int>(), down = new List<int>();
                    foreach (int id in move.Top)
                        if (room.GetCardPlace(id) != Place.PlaceHand)
                            up.Add(id);

                    foreach (int id in move.Bottom)
                        if (room.GetCardPlace(id) == Place.PlaceHand)
                            down.Add(id);

                    Debug.Assert(up.Count == down.Count);
                    if (up.Count > 0)
                    {
                        List<CardsMoveStruct> moves = new List<CardsMoveStruct>();
                        CardsMoveStruct move1 = new CardsMoveStruct(up, player, Place.PlaceHand, new CardMoveReason(CardMoveReason.MoveReason.S_REASON_EXCHANGE_FROM_PILE, player.Name, Name, string.Empty));
                        CardsMoveStruct move2 = new CardsMoveStruct(down, player, Place.PlaceSpecial,
                            new CardMoveReason(CardMoveReason.MoveReason.S_REASON_REMOVE_FROM_GAME, player.Name, Name, string.Empty))
                        {
                            To_pile_name = Name
                        };

                        moves.Add(move1);
                        moves.Add(move2);
                        room.MoveCardsAtomic(moves, false);
                    }
                }
            }

            return false;
        }
    }

    public class Kuangfeng : TriggerSkill
    {
        public Kuangfeng() : base("kuangfeng")
        {
            view_as_skill = new KuangfengVS();
            skill_type = SkillType.Wizzard;
            events = new List<TriggerEvent> { TriggerEvent.TurnStart, TriggerEvent.EventPhaseStart, TriggerEvent.Death };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            bool remove = false;
            if (triggerEvent == TriggerEvent.TurnStart && room.ContainsTag(Name) && room.GetTag(Name) is Player target && player == target)
            {
                remove = true;
            }
            else if (triggerEvent == TriggerEvent.Death && room.ContainsTag(Name) && room.GetTag(Name) is Player death && death == player)
            {
                remove = true;
            }

            if (remove)
            {
                foreach (Player p in room.GetAlivePlayers())
                    if (p.GetMark("@gale") > 0)
                        room.SetPlayerMark(p, "@gale", 0);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Finish && base.Triggerable(player, room) && player.GetPile("qixing").Count > 0)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.AskForUseCard(player, "@@kuangfeng", "@kuangfeng", -1, HandlingMethod.MethodUse, true, info.SkillPosition);
            return new TriggerStruct();
        }
    }

    public class KuangfengDamage : TriggerSkill
    {
        public KuangfengDamage() : base("#kuangfeng")
        {
            events.Add(TriggerEvent.DamageInflicted);
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is DamageStruct damage && damage.Nature == DamageStruct.DamageNature.Fire
                && player.GetMark("@gale") > 0 && room.ContainsTag("kuangfeng") && room.GetTag("kuangfeng") is Player from && from.Alive)
                return new TriggerStruct(Name, from);

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                LogMessage log = new LogMessage
                {
                    Type = "#kuangfeng-add",
                    From = ask_who.Name,
                    Arg = damage.Damage.ToString(),
                    Arg2 = (++damage.Damage).ToString()
                };
                room.SendLog(log);

                data = damage;
            }

            return false;
        }
    }

    public class KuangfengVS : OneCardViewAsSkill
    {
        public KuangfengVS() : base("kuangfeng")
        {
            filter_pattern = ".|.|.|qixing";
            expand_pile = "qixing";
            response_pattern = "@@kuangfeng";
        }
        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return false;
        }
        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard shun = new WrappedCard(KuangfengCard.ClassName)
            {
                Skill = Name,
                ShowSkill = Name
            };
            shun.AddSubCard(card);
            return shun;
        }
    }

    public class KuangfengCard : SkillCard
    {
        public static string ClassName = "KuangfengCard";
        public KuangfengCard() : base(ClassName)
        {
            will_throw = false;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0;
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            List<int> ids = new List<int>(card_use.Card.SubCards);
            room.SetTag("kuangfeng", player);

            CardMoveReason reason = new CardMoveReason(CardMoveReason.MoveReason.S_REASON_REMOVE_FROM_PILE, null, "kuangfeng", null);
            room.ThrowCard(ref ids, reason, null);

            room.AddPlayerMark(target, "@gale");
        }
    }

    public class Dawu : TriggerSkill
    {
        public Dawu() : base("dawu")
        {
            view_as_skill = new DawuVS();
            skill_type = SkillType.Wizzard;
            events = new List<TriggerEvent> { TriggerEvent.TurnStart, TriggerEvent.EventPhaseStart, TriggerEvent.Death };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            bool remove = false;
            if (triggerEvent == TriggerEvent.TurnStart && room.ContainsTag(Name) && room.GetTag(Name) is Player target && player == target)
            {
                remove = true;
            }
            else if (triggerEvent == TriggerEvent.Death && room.ContainsTag(Name) && room.GetTag(Name) is Player death && death == player)
            {
                remove = true;
            }

            if (remove)
            {
                foreach (Player p in room.GetAlivePlayers())
                    if (p.GetMark("@fog") > 0)
                        room.SetPlayerMark(p, "@fog", 0);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Finish && base.Triggerable(player, room) && player.GetPile("qixing").Count > 0)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.AskForUseCard(player, "@@dawu", "@dawu", -1, HandlingMethod.MethodUse, true, info.SkillPosition);
            return new TriggerStruct();
        }
    }

    public class DawuDamage : TriggerSkill
    {
        public DawuDamage() : base("#dawu")
        {
            events.Add(TriggerEvent.DamageInflicted);
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is DamageStruct damage && damage.Nature != DamageStruct.DamageNature.Thunder
                && player.GetMark("@fog") > 0 && room.ContainsTag("dawu") && room.GetTag("dawu") is Player from && from.Alive)
                return new TriggerStruct(Name, from);

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            LogMessage log = new LogMessage
            {
                Type = "#damaged-prevent",
                From = player.Name,
                Arg = "dawu"
            };
            room.SendLog(log);

            return true;
        }
    }

    public class DawuVS : ViewAsSkill
    {
        public DawuVS() : base("dawu")
        {
            expand_pile = "qixing";
            response_pattern = "@@dawu";
        }
        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return false;
        }

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            return player.GetPile(expand_pile).Contains(to_select.Id);
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count > 0)
            {
                WrappedCard shun = new WrappedCard(DawuCard.ClassName)
                {
                    Skill = Name,
                    ShowSkill = Name
                };
                shun.AddSubCards(cards);
                return shun;
            }

            return null;
        }
    }

    public class DawuCard : SkillCard
    {
        public static string ClassName = "DawuCard";
        public DawuCard() : base(ClassName)
        {
            will_throw = false;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count < card.SubCards.Count;
        }

        public override bool TargetsFeasible(Room room, List<Player> targets, Player Self, WrappedCard card)
        {
            return targets.Count == card.SubCards.Count;
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            List<int> ids = new List<int>(card_use.Card.SubCards);
            room.SetTag("dawu", player);

            CardMoveReason reason = new CardMoveReason(CardMoveReason.MoveReason.S_REASON_REMOVE_FROM_PILE, null, "dawu", null);
            room.ThrowCard(ref ids, reason, null);

            base.Use(room, card_use);
        }

        public override void OnEffect(Room room, CardEffectStruct effect)
        {
            room.AddPlayerMark(effect.To, "@fog");
        }
    }

    public class Guixin : MasochismSkill
    {
        public Guixin() : base("guixin")
        {
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is DamageStruct damage)
            {
                TriggerStruct trigger = new TriggerStruct(Name, player)
                {
                    Times = damage.Damage
                };
                return trigger;
            }

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            bool check = false;
            foreach (Player p in room.GetOtherPlayers(player))
            {
                if (!p.IsAllNude() && RoomLogic.CanGetCard(room, player, p, "hej"))
                {
                    check = true;
                    break;
                }
            }
            if (check && room.AskForSkillInvoke(player, Name, null, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }

        public override void OnDamaged(Room room, Player target, DamageStruct damage, TriggerStruct info)
        {
            List<Player> targets = new List<Player>();
            foreach (Player p in room.GetOtherPlayers(target))
            {
                if (!p.IsAllNude() && RoomLogic.CanGetCard(room, target, p, "hej"))
                {
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, target.Name, p.Name);
                    targets.Add(p);
                }
            }

            foreach (Player p in targets)
            {
                if (!p.Alive || p.IsAllNude()) continue;
                List<int> ids = p.GetCards("hej");
                Shuffle.shuffle(ref ids);
                foreach (int id in ids)
                {
                    if (RoomLogic.CanGetCard(room, target, p, id))
                    {
                        List<int> cards = new List<int> { id };
                        room.ObtainCard(target, ref cards, new CardMoveReason(CardMoveReason.MoveReason.S_REASON_EXTRACTION, target.Name, p.Name, Name, string.Empty), false);
                        Thread.Sleep(300);
                        break;
                    }
                }

                if (!target.Alive) break;
            }

            if (target.Alive) room.TurnOver(target);
        }
    }

    public class Juejing : TriggerSkill
    {
        public Juejing() : base("juejing")
        {
            events = new List<TriggerEvent> { TriggerEvent.AskForPeaches, TriggerEvent.QuitDying };
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.AskForPeaches && data is DyingStruct dying && dying.Who == player && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.QuitDying && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.DrawCards(player, 1, Name);

            return false;
        }
    }

    public class JuejingMax : MaxCardsSkill
    {
        public JuejingMax() : base("#juejing-max") { }

        public override int GetExtra(Room room, Player target)
        {
            if (RoomLogic.PlayerHasSkill(room, target, "juejing")) return 2;

            return 0;
        }
    }

    public class Longhun : TriggerSkill
    {
        public Longhun() : base("longhun")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsedAnnounced };
            view_as_skill = new LonghunVS();
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is CardUseStruct use && use.Card.Skill == Name && use.Card.SubCards.Count == 2)
            {
                if (WrappedCard.IsRed(use.Card.Suit))
                {
                    use.ExDamage++;
                    data = use;

                    if (use.Card.Name == FireSlash.ClassName)
                    {
                        LogMessage log = new LogMessage
                        {
                            Type = "#longhun-damage",
                            From = player.Name
                        };
                        room.SendLog(log);
                    }
                    else
                    {
                        LogMessage log = new LogMessage
                        {
                            Type = "#longhun-recover",
                            From = player.Name
                        };

                        room.SendLog(log);
                    }
                }
                else if (room.Current.Alive && !room.Current.IsNude() && RoomLogic.CanDiscard(room, player, room.Current, "he"))
                {
                    int id = room.AskForCardChosen(player, room.Current, "he", Name, false, HandlingMethod.MethodDiscard);
                    room.ThrowCard(id, room.Current, player);
                }
            }
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class LonghunVS : ViewAsSkill
    {
        public LonghunVS() : base("longhun")
        {
        }

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            if (selected.Count > 0 && (selected.Count >= 2 || to_select.Suit != selected[0].Suit)) return false;

            if (room.GetRoomState().GetCurrentCardUseReason() == CardUseReason.CARD_USE_REASON_PLAY)
            {
                if (RoomLogic.IsCardLimited(room, player, to_select, HandlingMethod.MethodUse)) return false;

                if (player.IsWounded() && to_select.Suit == WrappedCard.CardSuit.Heart) return true;
                if (to_select.Suit == WrappedCard.CardSuit.Diamond)
                {
                    WrappedCard slash = new WrappedCard(FireSlash.ClassName, -1, WrappedCard.CardSuit.Diamond, to_select.Number);
                    return Slash.IsAvailable(room, player, slash);
                }
            }
            else if (room.GetRoomState().GetCurrentCardUseReason() == CardUseReason.CARD_USE_REASON_RESPONSE_USE)
            {
                if (RoomLogic.IsCardLimited(room, player, to_select, HandlingMethod.MethodUse)) return false;
                string pattern = room.GetRoomState().GetCurrentCardUsePattern(player);
                WrappedCard slash = new WrappedCard(FireSlash.ClassName);
                WrappedCard peach = new WrappedCard(Peach.ClassName);
                WrappedCard jink = new WrappedCard(Jink.ClassName);
                WrappedCard nulli = new WrappedCard(Nullification.ClassName);
                if (Engine.MatchExpPattern(room, pattern, player, slash) && to_select.Suit == WrappedCard.CardSuit.Diamond) return true;
                if (Engine.MatchExpPattern(room, pattern, player, jink) && to_select.Suit == WrappedCard.CardSuit.Club) return true;
                if (Engine.MatchExpPattern(room, pattern, player, peach) && to_select.Suit == WrappedCard.CardSuit.Heart) return true;
                if (Engine.MatchExpPattern(room, pattern, player, nulli) && to_select.Suit == WrappedCard.CardSuit.Spade) return true;
            }
            else if (room.GetRoomState().GetCurrentCardUseReason() == CardUseReason.CARD_USE_REASON_RESPONSE)
            {
                if (RoomLogic.IsCardLimited(room, player, to_select, HandlingMethod.MethodResponse)) return false;
                string pattern = room.GetRoomState().GetCurrentCardUsePattern(player);
                WrappedCard slash = new WrappedCard(FireSlash.ClassName);
                WrappedCard jink = new WrappedCard(Jink.ClassName);
                if (Engine.MatchExpPattern(room, pattern, player, slash) && to_select.Suit == WrappedCard.CardSuit.Diamond) return true;
                if (Engine.MatchExpPattern(room, pattern, player, jink) && to_select.Suit == WrappedCard.CardSuit.Club) return true;
            }

            return false;
        }

        public override bool IsEnabledAtNullification(Room room, Player player)
        {
            List<int> ids = player.GetCards("he");
            ids.AddRange(player.GetHandPile());
            foreach (int id in ids)
            {
                WrappedCard card = room.GetCard(id);
                if (card.Suit == WrappedCard.CardSuit.Spade)
                    return true;
            }

            return false;
        }

        public override bool IsEnabledAtResponse(Room room, Player player, string pattern)
        {
            WrappedCard slash = new WrappedCard(FireSlash.ClassName);
            WrappedCard peach = new WrappedCard(Peach.ClassName);
            WrappedCard jink = new WrappedCard(Jink.ClassName);
            return Engine.MatchExpPattern(room, pattern, player, slash) || Engine.MatchExpPattern(room, pattern, player, jink) || Engine.MatchExpPattern(room, pattern, player, peach);
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            WrappedCard slash = new WrappedCard(FireSlash.ClassName);
            return player.IsWounded() || Slash.IsAvailable(room, player, slash);
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count == 1 || cards.Count == 2)
            {
                if (cards.Count == 2 && cards[0].Suit != cards[1].Suit) return null;

                switch (cards[0].Suit)
                {
                    case WrappedCard.CardSuit.Heart:
                        {
                            WrappedCard card = new WrappedCard(Peach.ClassName) { Skill = Name };
                            card.AddSubCards(cards);
                            card = RoomLogic.ParseUseCard(room, card);
                            return Peach.Instance.IsAvailable(room, player, card) ? card : null;
                        }
                    case WrappedCard.CardSuit.Spade:
                        {
                            WrappedCard card = new WrappedCard(Nullification.ClassName) { Skill = Name };
                            card.AddSubCards(cards);
                            card = RoomLogic.ParseUseCard(room, card);
                            return card;
                        }
                    case WrappedCard.CardSuit.Club:
                        {
                            WrappedCard card = new WrappedCard(Jink.ClassName) { Skill = Name };
                            card.AddSubCards(cards);
                            card = RoomLogic.ParseUseCard(room, card);
                            return Engine.MatchExpPattern(room, room.GetRoomState().GetCurrentCardUsePattern(player), player, card) ? card : null;
                        }
                    case WrappedCard.CardSuit.Diamond:
                        {
                            WrappedCard card = new WrappedCard(FireSlash.ClassName) { Skill = Name };
                            card.AddSubCards(cards);
                            card = RoomLogic.ParseUseCard(room, card);
                            return room.GetRoomState().GetCurrentCardUseReason() == CardUseReason.CARD_USE_REASON_PLAY
                                || Engine.MatchExpPattern(room, room.GetRoomState().GetCurrentCardUsePattern(player), player, card) ? card : null;
                        }
                }
            }

            return null;
        }
    }

    public class Kuangbao : TriggerSkill
    {
        public Kuangbao() : base("kuangbao")
        {
            frequency = Frequency.Compulsory;
            events = new List<TriggerEvent> { TriggerEvent.Damage, TriggerEvent.Damaged, TriggerEvent.GameStart };
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);

            if (triggerEvent == TriggerEvent.GameStart)
                player.AddMark("baonu", 2);
            else if (data is DamageStruct damage)
                player.AddMark("baonu", damage.Damage);

            room.SetPlayerStringMark(player, "baonu", player.GetMark("baonu").ToString());
            return false;
        }
    }

    public class Wumou : TriggerSkill
    {
        public Wumou() : base("wumou")
        {
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Wizzard;
            events.Add(TriggerEvent.CardUsedAnnounced);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardUseStruct use && base.Triggerable(player, room))
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is TrickCard && !(fcard is DelayedTrick))
                    return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            List<string> choices = new List<string> { "lose" };
            if (player.GetMark("baonu") > 0)
                choices.Add("discard");

            if (room.AskForChoice(player, Name, string.Join("+", choices)) == "lose")
            {
                room.LoseHp(player);
            }
            else
            {
                player.AddMark("baonu", -1);
                if (player.GetMark("baonu") > 0)
                    room.SetPlayerStringMark(player, "baonu", player.GetMark("baonu").ToString());
                else
                    room.RemovePlayerStringMark(player, "baonu");
            }

            return false;
        }
    }

    public class Wuqian : TriggerSkill
    {
        public Wuqian() : base("wuqian")
        {
            events.Add(TriggerEvent.EventPhaseChanging);
            view_as_skill = new WuqianVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is PhaseChangeStruct change && player.HasFlag(Name) && change.To == PlayerPhase.NotActive)
            {
                room.HandleAcquireDetachSkills(player, "-wushuang", true);
                Player target = room.FindPlayer(player.GetTag(Name).ToString(), true);
                target.AddMark("Armor_Nullified", -1);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class WuqianVS : ZeroCardViewAsSkill
    {
        public WuqianVS() : base("wuqian") { }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(WuqianCard.ClassName) { Skill = Name };
        }
        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return player.GetMark("baonu") > 1 && !player.HasUsed(WuqianCard.ClassName);
        }
    }

    public class WuqianCard : SkillCard
    {
        public static string ClassName = "WuqianCard";
        public WuqianCard() : base(ClassName) { }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            player.AddMark("baonu", -2);

            if (player.GetMark("baonu") > 0)
                room.SetPlayerStringMark(player, "baonu", player.GetMark("baonu").ToString());
            else
                room.RemovePlayerStringMark(player, "baonu");

            player.SetFlags("wuqian");
            player.SetTag("wuqian", target.Name);
            room.HandleAcquireDetachSkills(player, "wushuang", true);

            LogMessage log = new LogMessage
            {
                Type = "#wuqian",
                From = target.Name
            };
            room.SendLog(log);

            target.AddMark("Armor_Nullified");
        }
    }

    public class Shenfen : ZeroCardViewAsSkill
    {
        public Shenfen() : base("shenfen") { skill_type = SkillType.Attack; }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return player.GetMark("baonu") > 5 && !player.HasUsed(ShenfenCard.ClassName);
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(ShenfenCard.ClassName) { Skill = Name };
        }
    }

    public class ShenfenCard : SkillCard
    {
        public static string ClassName = "ShenfenCard";
        public ShenfenCard() : base(ClassName)
        {
            target_fixed = true;
        }

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            List<Player> targets = room.GetOtherPlayers(player);
            card_use.To = targets;
            base.OnUse(room, card_use);
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            player.AddMark("baonu", -6);
            if (player.GetMark("baonu") > 0)
                room.SetPlayerStringMark(player, "baonu", player.GetMark("baonu").ToString());
            else
                room.RemovePlayerStringMark(player, "baonu");

            foreach (Player p in card_use.To)
                if (p.Alive)
                    room.Damage(new DamageStruct("shenfen", player, p));

            base.Use(room, card_use);

            if (player.Alive)
                room.TurnOver(player);
        }

        public override void OnEffect(Room room, CardEffectStruct effect)
        {
            Player to = effect.To;
            if (to.Alive)
            {
                List<int> ids = new List<int>();
                foreach (int id in to.GetEquips())
                    if (RoomLogic.CanDiscard(room, to, to, id))
                        ids.Add(id);

                if (ids.Count > 0)
                    room.ThrowCard(ref ids, to);

                if (to.Alive && !to.IsKongcheng())
                    room.AskForDiscard(to, "shenfen", 4, 4, false, false, "@shenfen");
            }
        }
    }

    public class Renjie : TriggerSkill
    {
        public Renjie() : base("renjie")
        {
            frequency = Frequency.Compulsory;
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime, TriggerEvent.Damaged };
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null && move.From.Phase == PlayerPhase.Discard
                && base.Triggerable(move.From, room) && move.From_places.Contains(Place.PlaceHand) && move.Reason.PlayerId == move.From.Name
                && (move.Reason.Reason & CardMoveReason.MoveReason.S_MASK_BASIC_REASON) == CardMoveReason.MoveReason.S_REASON_DISCARD)
            {
                foreach (Place place in move.From_places)
                    if (place == Place.PlaceHand)
                        return new TriggerStruct(Name, move.From);
            }
            else if (triggerEvent == TriggerEvent.Damaged && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);

            if (triggerEvent == TriggerEvent.Damaged && data is DamageStruct damage)
            {
                ask_who.AddMark("patience", damage.Damage);
            }
            else if (data is CardsMoveOneTimeStruct move)
            {
                int count = 0;
                foreach (Place place in move.From_places)
                    if (place == Place.PlaceHand)
                        count++;

                ask_who.AddMark("patience", count);
            }

            room.SetPlayerStringMark(ask_who, "patience", ask_who.GetMark("patience").ToString());

            return false;
        }
    }

    public class Lianpo : TriggerSkill
    {
        public Lianpo() : base("lianpo")
        {
            events = new List<TriggerEvent> { TriggerEvent.Death, TriggerEvent.EventPhaseChanging };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Death && data is DeathStruct death && death.Damage.From != null && death.Damage.From.Alive)
                death.Damage.From.SetFlags(Name);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                Player simayi = RoomLogic.FindPlayerBySkillName(room, Name);
                if (simayi != null && simayi.HasFlag(Name))
                    return new TriggerStruct(Name, simayi);
            }

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(ask_who, Name, null, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            LogMessage l = new LogMessage
            {
                Type = "#Fangquan",
                To = new List<string> { ask_who.Name }
            };
            room.SendLog(l);
            room.GainAnExtraTurn(ask_who);
            return false;
        }
    }

    public class LianpoClear : TriggerSkill
    {
        public LianpoClear() : base("#lianpo")
        {
            events.Add(TriggerEvent.EventPhaseChanging);
        }

        public override int GetPriority() => 2;

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                foreach (Player p in room.GetAlivePlayers())
                    if (p.HasFlag("lianpo"))
                        p.SetFlags("-lianpo");
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class Baiyin : PhaseChangeSkill
    {
        public Baiyin() : base("baiyin")
        {
            frequency = Frequency.Wake;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Start && base.Triggerable(player, room) && player.GetMark(Name) == 0 && player.GetMark("patience") >= 4)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool OnPhaseChange(Room room, Player player, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.DoSuperLightbox(player, info.SkillPosition, Name);
            room.SetPlayerMark(player, Name, 1);
            room.SendCompulsoryTriggerLog(player, Name);

            room.LoseMaxHp(player);
            room.HandleAcquireDetachSkills(player, "jilue", true);

            return false;
        }
    }

    public class Jilue : TriggerSkill
    {
        public Jilue() : base("jilue")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsed, TriggerEvent.EventPhaseChanging, TriggerEvent.Damaged, TriggerEvent.AskForRetrial };
            skill_type = SkillType.Wizzard;
            view_as_skill = new JilueVS();
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                if (player.GetMark(Name) > 0)
                {
                    room.RemovePlayerStringMark(player, Name);
                    player.SetMark(Name, 0);
                }

                if (player.HasFlag(Name))
                    room.HandleAcquireDetachSkills(player, "-wansha", true);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardUsed && base.Triggerable(player, room) && data is CardUseStruct use && use.Card != null && player.GetMark("patience") > 0)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard.IsNDTrick())
                    return new TriggerStruct(Name, player);
            }
            else if (triggerEvent == TriggerEvent.Damaged && base.Triggerable(player, room) && player.GetMark("patience") > 0)
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.AskForRetrial && base.Triggerable(player, room)
                && (!player.IsNude() || player.GetHandPile().Count > 0) && player.GetMark("patience") > 0)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.CardUsed && room.AskForSkillInvoke(player, Name, "@jilue-jizhi", info.SkillPosition))
            {
                player.AddMark("patience", -1);
                if (player.GetMark("patience") > 0)
                    room.SetPlayerStringMark(ask_who, "patience", ask_who.GetMark("patience").ToString());
                else
                    room.RemovePlayerStringMark(player, "patience");

                room.BroadcastSkillInvoke("jizhi", player, info.SkillPosition);
                return info;
            }
            else if (triggerEvent == TriggerEvent.Damaged)
            {
                Player to = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@jilue-fangzhu", true, true, info.SkillPosition);
                if (to != null)
                {
                    player.AddMark("patience", -1);
                    if (player.GetMark("patience") > 0)
                        room.SetPlayerStringMark(ask_who, "patience", ask_who.GetMark("patience").ToString());
                    else
                        room.RemovePlayerStringMark(player, "patience");

                    room.BroadcastSkillInvoke("fangzhu", player, info.SkillPosition);
                    List<string> target_list = player.ContainsTag("fangzhu_target") ? (List<string>)player.GetTag("fangzhu_target") : new List<string>();
                    target_list.Add(to.Name);
                    player.SetTag("fangzhu_target", target_list);
                    return info;
                }
            }
            else if (triggerEvent == TriggerEvent.AskForRetrial && data is JudgeStruct judge)
            {
                List<string> prompt_list = new List<string> { "@jilue-guicai", judge.Who.Name, string.Empty, judge.Reason };
                string prompt = string.Join(":", prompt_list);

                room.SetTag(Name, data);
                WrappedCard card = room.AskForCard(player, Name, "..", prompt, data, HandlingMethod.MethodResponse, judge.Who, true);
                room.RemoveTag(Name);
                if (card != null)
                {
                    player.AddMark("patience", -1);
                    if (player.GetMark("patience") > 0)
                        room.SetPlayerStringMark(ask_who, "patience", ask_who.GetMark("patience").ToString());
                    else
                        room.RemovePlayerStringMark(player, "patience");

                    room.BroadcastSkillInvoke("guicai", player, info.SkillPosition);
                    room.Retrial(card, player, ref judge, Name, false, info.SkillPosition);
                    data = judge;
                    return info;
                }
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.CardUsed)
            {
                List<int> card_ids = room.GetNCards(1, true);
                CardsMoveStruct move = new CardsMoveStruct(card_ids, player, Place.PlaceHand,
                    new CardMoveReason(CardMoveReason.MoveReason.S_REASON_DRAW, player.Name, player.Name, Name, string.Empty));
                card_ids = room.MoveCardsAtomic(new List<CardsMoveStruct> { move }, false);
                if (player.Phase == PlayerPhase.Play && card_ids.Count == 1 && room.GetCardPlace(card_ids[0]) == Place.PlaceHand
                    && room.GetCardOwner(card_ids[0]) == player && Engine.GetFunctionCard(room.GetCard(card_ids[0]).Name) is BasicCard)
                {
                    List<int> ids = room.AskForExchange(player, Name, 1, 0, "@jizhi", string.Empty, card_ids[0].ToString(), info.SkillPosition);
                    if (ids.Count > 0)
                    {
                        room.ThrowCard(ref ids, player, null, Name);
                        player.AddMark(Name, ids.Count);
                        room.SetPlayerStringMark(player, Name, player.GetMark(Name).ToString());
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.Damaged)
            {
                List<string> target_list = (List<string>)player.GetTag("fangzhu_target");
                string target_name = target_list[target_list.Count - 1];
                target_list.RemoveAt(target_list.Count - 1);
                player.SetTag("fangzhu_target", target_list);
                Player to = room.FindPlayer(target_name); ;

                if (to != null)
                {
                    if (player.IsWounded())
                        room.DrawCards(to, new DrawCardStruct(player.GetLostHp(), player, Name));
                    room.TurnOver(to);
                }
            }
            else if (data is JudgeStruct judge)
            {
                room.UpdateJudgeResult(ref judge);
                data = judge;
                return false;
            }

            return false;
        }
    }

    public class JilueVS : ViewAsSkill
    {
        public JilueVS() : base("jilue")
        {
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            if (player.GetMark("patience") == 0) return false;
            if (player.HasUsed(ZhihengJCard.ClassName) && RoomLogic.PlayerHasSkill(room, player, "wansha")) return false;

            return true;
        }
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            if (player.HasUsed(ZhihengJCard.ClassName)) return false;
            return !RoomLogic.IsJilei(room, player, to_select);
        }
        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count == 0 && !RoomLogic.PlayerHasSkill(room, player, "wansha"))
            {
                return new WrappedCard(JilueCard.ClassName) { Skill = "wansha" };
            }
            else if (cards.Count > 0 && !player.HasUsed(ZhihengJCard.ClassName))
            {
                WrappedCard zhiheng_card = new WrappedCard(JilueCard.ClassName)
                {
                    Skill = "zhiheng_jx",
                };
                zhiheng_card.AddSubCards(cards);
                return zhiheng_card;
            }

            return null;
        }
    }

    public class JilueCard : SkillCard
    {
        public static string ClassName = "JilueCard";
        public JilueCard() : base(ClassName)
        {
            target_fixed = true;
            auto_use = false;
        }
        
        public override void OnCardAnnounce(Room room, CardUseStruct use, bool ignore_rule)
        {
            if (use.Card.SubCards.Count > 0)
            {
                use.From.AddHistory(ZhihengJCard.ClassName);
                if (use.From.IsLastHandCard(use.Card, true))
                    use.Card.UserString = "1";
            }
            base.OnCardAnnounce(room, use, ignore_rule);
        }
        public override void Use(Room room, CardUseStruct card_use)
        {
            card_use.From.AddMark("patience", -1);

            if (card_use.From.GetMark("patience") > 0)
                room.SetPlayerStringMark(card_use.From, "patience", card_use.From.GetMark("patience").ToString());
            else
                room.RemovePlayerStringMark(card_use.From, "patience");

            if (card_use.Card.SubCards.Count == 0)
            {
                room.HandleAcquireDetachSkills(card_use.From, "wansha", true);
                card_use.From.SetFlags("jilue");
            }
            else if (card_use.From.Alive)
            {
                int count = card_use.Card.SubCards.Count;
                if (card_use.Card.UserString == "1") count++;
                room.DrawCards(card_use.From, count, "zhiheng_jx");
            }
        }
    }
    #endregion
}