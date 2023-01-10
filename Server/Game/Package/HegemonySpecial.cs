using CommonClass;
using CommonClass.Game;
using CommonClassLibrary;
using SanguoshaServer.Game;
using System;
using System.Collections.Generic;
using static CommonClass.Game.CardUseStruct;
using static CommonClass.Game.Player;
using static SanguoshaServer.Package.FunctionCard;

namespace SanguoshaServer.Package
{
    public class HegemonySpecial : GeneralPackage
    {
        public HegemonySpecial() : base("HegemonySpecial")
        {
            skills = new List<Skill>
            {
                new Daoshu(),
                new Weicheng(),
                new Quanjin(),
                new Zaoyun(),
                new ZaoyunDistance(),
                new Juejue(),
                new JuejueEffect(),
                new Fangyuan(),
                new FangyuanMax(),
                new DeshaoHegemony(),
                new MingfaHegemony(),
                new MingfaEffect(),

                new Tunchu(),
                new TunchuAdd(),
                new TunchuProhibit(),
                new Shuliang(),
                new Zhuhai(),
                new ZhuhaiTag(),
                new JujianHegemony(),
                new Tongdu(),
                new Qingyin(),

                new Yuanyu(),
                new Guishu(),
                new WukuHegemony(),
                new ZhidaoHegemony(),
                new ZhidaoHegemonyPro(),
                new ZhidaoDistance(),
                new JiliYbhHegemony(),
                new Xishe(),
                new GuowuHegemony(),
                new GuowuHegemonyTar(),
                new ZhuangrongHegemony(),
                new ZhuangrongMax(),
                new Zhuidu(),
                new Shigong(),
                new YaowuHegemony(),
                new Shiyong(),

                new Dujin(),
                new AocaiHegemony(),
                new DuwuHegemony(),
                new Diaogui(),
                new Fengyang(),
                new FengYangFix(),

            };
            skill_cards = new List<FunctionCard>
            {
                new GuishuCard(),
                new DaoshuCard(),
                new JujianHCard(),
                new QuanjinCard(),
                new ZaoyunCard(),
                new QingyinCard(),
                new AocaiHegemonyCard(),
                new DuwuHegemonyCard(),
                new JuejueCard(),
                new DiaoguiCard(),
                new MingfaCard(),
            };
            related_skills = new Dictionary<string, List<string>>
            {
                { "tunchu", new List<string> { "#tunchu-add", "#tunchu-prohibit" } },
                { "zhidao_hegemony", new List<string> { "#zhidao_hegemony", "#zhidao-distance" } },
                { "zaoyun", new List<string> { "#zaoyun" } },
                { "juejue", new List<string> { "#juejue" } },
                { "fangyuan", new List<string> { "#fangyuan" } },
                { "fengyang", new List<string> { "#fengyang" } },
                { "guowu_hegemony", new List<string> { "#guowu_hegemony" } },
                { "zhuangrong_hegemony", new List<string> { "#zhuangrong_hegemony" } },
                { "zhuhai", new List<string>{ "#zhuhai" } },
                { "mingfa_hegemony", new List<string> { "#mingfa_hegemony" } },
            };
        }
    }

    //jianggan
    public class Weicheng : TriggerSkill
    {
        public Weicheng() : base("weicheng")
        {
            events.Add(TriggerEvent.CardsMoveOneTime);
            skill_type = SkillType.Replenish;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardsMoveOneTimeStruct move && move.To != null && move.From != null && base.Triggerable(move.From, room)
                && move.From_places.Contains(Place.PlaceHand) && (move.Reason.Reason == MoveReason.S_REASON_GIVE
                || move.Reason.Reason == MoveReason.S_REASON_EXTRACTION) && move.From.HandcardNum < move.From.Hp)
                return new TriggerStruct(Name, move.From);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player p, ref object data, Player player, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player p, ref object data, Player player, TriggerStruct info)
        {
            room.DrawCards(player, 1, Name);
            return false;
        }
    }
    public class Daoshu : TriggerSkill
    {
        public Daoshu() : base("daoshu")
        {
            events.Add(TriggerEvent.EventPhaseChanging);
            skill_type = SkillType.Wizzard;
            view_as_skill = new DaoshuVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is PhaseChangeStruct change && change.From == PlayerPhase.Play && player.HasFlag(Name))
                player.SetFlags("-daoshu");
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }
    public class DaoshuVS : ZeroCardViewAsSkill
    {
        public DaoshuVS() : base("daoshu")
        {
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.HasFlag(Name);
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            WrappedCard card = new WrappedCard(DaoshuCard.ClassName)
            {
                Skill = Name,
                ShowSkill = Name
            };
            return card;
        }
    }

    public class DaoshuCard : SkillCard
    {
        public static string ClassName = "DaoshuCard";
        private readonly List<string> suits = new List<string> { "spade", "heart", "club", "diamond" };
        public DaoshuCard() : base(ClassName)
        {
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return Self != to_select && targets.Count == 0 && !to_select.IsKongcheng() && RoomLogic.CanGetCard(room, Self, to_select, "h");
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            Player target = card_use.To[0];
            if (target.Alive && !target.IsKongcheng() && RoomLogic.CanGetCard(room, player, target, "h"))
            {
                target.SetFlags("daoshu_target");
                string suit = room.AskForChoice(player, "daoshu", string.Join("+", suits), null, null, card_use.Card.SkillPosition);
                target.SetFlags("-daoshu_target");

                int id = room.AskForCardChosen(player, target, "h", "daoshu", false, HandlingMethod.MethodGet);
                room.ObtainCard(player, id);

                if (WrappedCard.GetSuitString(room.GetCard(id).Suit) == suit)
                {
                    room.Damage(new DamageStruct("daoshu", player, target));
                }
                else
                {
                    suit = WrappedCard.GetSuitString(room.GetCard(id).Suit);
                    player.SetFlags("daoshu");
                    List<int> ids = new List<int>();
                    CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, "daoshu", string.Empty);
                    foreach (int card_id in player.GetCards("h"))
                    {
                        if (WrappedCard.GetSuitString(room.GetCard(card_id).Suit) != suit)
                            ids.Add(card_id);
                    }

                    if (ids.Count == 0) room.ShowAllCards(player, null, "daoshu");
                    else if (ids.Count == 1)
                    {
                        room.ObtainCard(target, ref ids, reason, true);
                    }
                    else
                    {
                        List<int> to_give = room.AskForExchange(player, "daoshu", 1, 1, "@daoshu-give:" + target.Name, string.Empty, string.Format(".|^{0}|.|hand", suit), card_use.Card.SkillPosition);
                        if (to_give.Count == 1)
                            room.ObtainCard(target, ref to_give, reason, true);
                        else
                        {
                            List<int> give = new List<int> { ids[0] };
                            room.ObtainCard(target, ref give, reason, true);
                        }
                    }
                }
            }
        }
    }

    //dongzhao
    public class Quanjin : TriggerSkill
    {
        public Quanjin() : base("quanjin")
        {
            view_as_skill = new QuanjinVS();
            skill_type = SkillType.Wizzard;
            events = new List<TriggerEvent> { TriggerEvent.Damaged, TriggerEvent.EventPhaseChanging };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Damaged && player.Alive && room.Current != null && room.Current.Phase == PlayerPhase.Play)
                player.SetFlags(Name);
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.From == PlayerPhase.Play)
            {
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.HasFlag(Name)) p.SetFlags("-quanjin");
                }
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }
    public class QuanjinVS : OneCardViewAsSkill
    {
        public QuanjinVS() : base("quanjin") { filter_pattern = "."; }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.HasUsed(QuanjinCard.ClassName) && !player.IsKongcheng();
        }
        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard jieyue = new WrappedCard(QuanjinCard.ClassName) { Skill = Name, ShowSkill = Name };
            jieyue.AddSubCard(card);
            return jieyue;
        }
    }

    public class QuanjinCard : SkillCard
    {
        public static string ClassName = "QuanjinCard";
        public QuanjinCard() : base(ClassName) { will_throw = false; }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return to_select != Self && targets.Count == 0 && to_select.HasFlag("quanjin");
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            Player target = card_use.To[0];

            List<int> ids = new List<int>(card_use.Card.SubCards);
            room.ObtainCard(target, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, "quanjin", string.Empty), false);

            if (player.Alive && target.Alive)
            {
                target.SetFlags("imperialorder_target");        //这个flag表明该玩家为敕令的固定目标，且会自动在ViewAsSkill生成随机敕令牌后清除
                player.SetTag("order_reason", "quanjin");
                WrappedCard card = room.AskForUseCard(player, RespondType.Skill, "@@imperialorder!", "@quanjin-target:" + target.Name, null, -1, HandlingMethod.MethodUse);
                if (card == null)
                {
                    string card_name = player.ContainsTag("imperialorder_select") ? ((string)player.GetTag("imperialorder_select")).Split('+')[0] : string.Empty;
                    if (string.IsNullOrEmpty(card_name))
                        card = ImperialOrderVS.GetImperialOrders(room, player)[0];
                    else
                        card = new WrappedCard(card_name);

                    CardUseStruct use = new CardUseStruct(card, player, target);
                    room.UseCard(use);
                }
                player.RemoveTag("imperialorder_select");

                if (!player.ContainsTag("ImperialOrder") || !(bool)player.GetTag("ImperialOrder"))
                {
                    if (player.Alive && player.HandcardNum < 5)
                    {
                        int max = 0;
                        foreach (Player p in room.GetAlivePlayers())
                        {
                            if (p.HandcardNum > max) max = p.HandcardNum;
                        }
                        if (player.HandcardNum < max)
                        {
                            max = Math.Min(5, max + 1);
                            int count = max - player.HandcardNum;
                            room.DrawCards(player, count, "quanjin");
                        }
                    }
                }
                else if (player.Alive)
                    room.DrawCards(player, 1, Name);
            }
        }
    }

    public class Zaoyun : ViewAsSkill
    {
        public Zaoyun() : base("zaoyun")
        {
            skill_type = SkillType.Attack;
        }

        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(ZaoyunCard.ClassName);

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            return RoomLogic.CanDiscard(room, player, player, to_select.Id) && room.GetCardPlace(to_select.Id) == Place.PlaceHand;
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count > 0)
            {
                WrappedCard zy = new WrappedCard(ZaoyunCard.ClassName) { Skill = Name, ShowSkill = Name };
                zy.AddSubCards(cards);
                return zy;
            }
            return null;
        }
    }

    public class ZaoyunCard : SkillCard
    {
        public static string ClassName = "ZaoyunCard";
        public ZaoyunCard() : base(ClassName)
        {
            will_throw = true;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            if (targets.Count == 0 && to_select != Self && !RoomLogic.WillBeFriendWith(room, Self, to_select))
            {
                int distance = RoomLogic.DistanceTo(room, Self, to_select);
                return distance > 1 && distance - 1 == card.SubCards.Count;
            }
            return false;
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            player.SetFlags("zaoyun_from");
            target.SetFlags("zaoyun");
            room.Damage(new DamageStruct("zaoyun", player, target));
        }
    }

    public class ZaoyunDistance : DistanceSkill
    {
        public ZaoyunDistance() : base("#zaoyun")
        {
        }
        public override int GetFixed(Room room, Player from, Player to)
        {
            if (from.HasFlag("zaoyun_from") && to.HasFlag("zaoyun"))
                return 1;
            else
                return 0;
        }
    }

    //zhuling
    public class Juejue : TriggerSkill
    {
        public Juejue() : base("juejue")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseChanging };
            view_as_skill = new JuejueVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null && move.From.Alive && move.From.Phase == PlayerPhase.Discard && move.From.HasFlag(Name)
                && move.From_places.Contains(Place.PlaceHand) && (move.Reason.Reason & MoveReason.S_MASK_BASIC_REASON) == MoveReason.S_REASON_DISCARD)
            {
                for (int i = 0; i < move.Card_ids.Count; i++)
                    if (move.From_places[i] == Place.PlaceHand)
                        move.From.AddMark(Name);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.From == PlayerPhase.Discard)
                player.SetMark(Name, 0);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Discard && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.LoseHp(player);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.Alive) player.SetFlags(Name);
            return false;
        }
    }

    public class JuejueEffect : TriggerSkill
    {
        public JuejueEffect() : base("#juejue")
        {
            events= new List<TriggerEvent> { TriggerEvent.EventPhaseEnd, TriggerEvent.RewardPunish };
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseEnd && player.Alive && player.GetMark("juejue") > 0 && player.Phase == PlayerPhase.Discard)
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.RewardPunish && base.Triggerable(player, room) && data is Player victim && RoomLogic.IsFriendWith(room, player, victim))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.EventPhaseEnd)
                return info;
            else if (RoomLogic.PlayerHasShownSkill(room, player, Name) || room.AskForSkillInvoke(player, Name, null, info.SkillPosition))
                return info;
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.EventPhaseEnd)
            {
                List<Player> targets = room.GetOtherPlayers(player);
                foreach (Player p in targets)
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, p.Name);
                int count = player.GetMark("juejue");
                foreach (Player p in targets)
                {
                    if (p.Alive)
                    {
                        p.SetMark("juejue", count);
                        WrappedCard card = room.AskForUseCard(p, RespondType.Skill, "@@juejue", string.Format("@juejue:{0}::{1}", player.Name, count), null);
                        p.SetMark("juejue", 0);
                        if (card == null && player.Alive)
                            room.Damage(new DamageStruct("juejue", player, p));
                    }
                }
                return false;
            }
            else
            {
                room.SendCompulsoryTriggerLog(player, "juejue");
                return true;
            }
        }
    }

    public class JuejueVS : ViewAsSkill
    {
        public JuejueVS() : base("juejue")
        {}

        public override bool IsAvailable(Room room, Player invoker, CardUseReason reason, RespondType respond, string pattern, string position = null) => pattern == "@@juejue";
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
            => selected.Count < player.GetMark(Name) && room.GetCardPlace(to_select.Id) == Place.PlaceHand;

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count == player.GetMark(Name))
            {
                WrappedCard jj = new WrappedCard(JuejueCard.ClassName);
                jj.AddSubCards(cards);
                return jj;
            }
            return null;
        }
    }

    public class JuejueCard : SkillCard
    {
        public static string ClassName = "JuejueCard";
        public JuejueCard() : base(ClassName)
        {
            target_fixed = true;
            will_throw = false;
        }

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            room.MoveCardTo(card_use.Card, null, Place.DiscardPile, new CardMoveReason(MoveReason.S_REASON_NATURAL_ENTER, card_use.From.Name, "juejue", string.Empty), true);
        }
    }

    public class Fangyuan : BattleArraySkill
    {
        public Fangyuan() : base("fangyuan", ArrayType.Siege)
        {
            events.Add(TriggerEvent.EventPhaseStart);
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Attack;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Finish && RoomLogic.PlayerHasShownSkill(room, player, Name) && room.AliveCount() >= 4)
            {
                Player p1 = room.GetLastAlive(player);
                Player p2 = room.GetNextAlive(player);
                if (p2 != player && RoomLogic.InSiegeRelation(room, p1, p2, player))
                    return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = Name, DistanceLimited = false };
            List<Player> targets = new List<Player>();
            Player p1 = room.GetLastAlive(player);
            Player p2 = room.GetNextAlive(player);
            if (RoomLogic.IsProhibited(room, player, p1, slash) == null) targets.Add(p1);
            if (RoomLogic.IsProhibited(room, player, p2, slash) == null) targets.Add(p2);
            if (targets.Count > 0)
            {
                Player target = room.AskForPlayerChosen(player, targets, Name, "@fangyuan", false, true, info.SkillPosition);
                if (target != null)
                    room.UseCard(new CardUseStruct(slash, player, target, false));
            }

            return false;
        }
    }

    public class FangyuanMax : MaxCardsSkill
    {
        public FangyuanMax() : base("#fangyuan") { }
        public override int GetExtra(Room room, Player target)
        {
            int count = 0;
            if (target.HasShownOneGeneral() && room.AliveCount() >= 4)
            {
                Player p1 = room.GetLastAlive(target);
                Player p2 = room.GetNextAlive(target);

                Player p3 = room.GetLastAlive(target, 2);
                Player p4 = room.GetNextAlive(target, 2);

                if ((target != p3 && RoomLogic.InSiegeRelation(room, target, p3, p1) && (RoomLogic.PlayerHasShownSkill(room, target, Name) || RoomLogic.PlayerHasShownSkill(room, p3, Name)))
                    || (target != p4 && RoomLogic.InSiegeRelation(room, target, p4, p2) && (RoomLogic.PlayerHasShownSkill(room, target, Name) || RoomLogic.PlayerHasShownSkill(room, p4, Name))))
                    count ++;

                if (p1 != p2 && RoomLogic.InSiegeRelation(room, p1, p2, target) && (RoomLogic.PlayerHasShownSkill(room, p1, Name) || RoomLogic.PlayerHasShownSkill(room, p2, Name)))
                    count--;
            }

            return count;
        }
    }

    //yanghu
    public class DeshaoHegemony : TriggerSkill
    {
        public DeshaoHegemony() : base("deshao_hegemony")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetConfirmed, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Replenish;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                    p.SetMark(Name, 0);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TargetConfirmed && data is CardUseStruct use && use.From != null && !Engine.IsSkillCard(use.Card.Name) && WrappedCard.IsBlack(use.Card.Suit)
                && use.From != player && base.Triggerable(player, room) && player.GetMark(Name) < player.Hp && !use.From.IsNude() && RoomLogic.CanDiscard(room, player, use.From, "he"))
            {
                int count_from = use.From.HasShownAllGenerals() ? 2 : use.From.General1Showed ? 1 : 0;
                int count_self = player.HasShownAllGenerals() ? 2 : player.HasShownOneGeneral() ? 1 : 0;
                if (count_from <= count_self)
                    return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use && room.AskForSkillInvoke(player, Name, use.From, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                player.AddMark(Name);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use && use.From.Alive && player.Alive && !use.From.IsNude() && RoomLogic.CanDiscard(room, player, use.From, "he"))
            {
                List<int> ids = new List<int> { room.AskForCardChosen(player, use.From, "he", Name, false, HandlingMethod.MethodDiscard) };
                room.ThrowCard(ref ids, new CardMoveReason(MoveReason.S_REASON_DISMANTLE, player.Name, use.From.Name, Name, string.Empty), use.From, player);
            }
            return false;
        }
    }


    public class MingfaHegemony : ZeroCardViewAsSkill
    {
        public MingfaHegemony() : base("mingfa_hegemony") { skill_type = SkillType.Attack; }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(MingfaCard.ClassName);
        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(MingfaCard.ClassName) { Skill = Name, ShowSkill = Name };
    }

    public class MingfaCard : SkillCard
    {
        public static string ClassName = "MingfaCard";
        public MingfaCard() : base(ClassName) { }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card) => targets.Count == 0 && !RoomLogic.WillBeFriendWith(room, Self, to_select);
        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            List<string> froms = target.ContainsTag("mingfa_hegemony") ? (List<string>)target.GetTag("mingfa_hegemony") : new List<string>();
            froms.Add(player.Name);
            target.SetTag("mingfa_hegemony", froms);
            room.SetPlayerStringMark(target, "mingfa_hegemony", string.Empty);
        }
    }

    public class MingfaEffect : TriggerSkill
    {
        public MingfaEffect() : base("#mingfa_hegemony")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging };
            frequency = Frequency.Compulsory;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player.Alive && player.ContainsTag("mingfa_hegemony"))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.GetTag("mingfa_hegemony") is List<string> names)
            {
                player.RemoveTag("mingfa_hegemony");
                room.RemovePlayerStringMark(player, "mingfa_hegemony");
            List<Player> froms = new List<Player>();
                foreach (string player_name in names)
                {
                    Player from = room.FindPlayer(player_name);
                    if (from != null)
                        froms.Add(from);
                }
                if (froms.Count > 0)
                {
                    room.SortByActionOrder(ref froms);
                    foreach (Player p in froms)
                    {
                        if (p.Alive && player.Alive)
                        {
                            room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, p.Name, player.Name);
                            room.SendCompulsoryTriggerLog(p, "mingfa_hegemony");
                            if (player.HandcardNum < p.HandcardNum)
                            {
                                room.Damage(new DamageStruct("mingfa_hegemony", p, player));
                                if (p.Alive && player.Alive && !player.IsKongcheng() && RoomLogic.CanGetCard(room, p, player, "h"))
                                {
                                    List<int> ids = new List<int> { room.AskForCardChosen(p, player, "h", Name, false, HandlingMethod.MethodGet) };
                                    room.ObtainCard(p, ref ids, new CardMoveReason(MoveReason.S_REASON_EXTRACTION, p.Name, player.Name, "mingfa_hegemony", string.Empty), false);
                                }
                            }
                            else
                            {
                                int count = player.HandcardNum - p.HandcardNum;
                                count = Math.Min(5, count);
                                room.DrawCards(p, count, "mingfa_hegemony");
                            }
                        }
                    }
                }
            }

            return false;
        }
    }

    //lifeng
    public class Tunchu : DrawCardsSkill
    {
        public Tunchu() : base("tunchu")
        {
            skill_type = SkillType.Replenish;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Draw && player.GetPile("commissariat").Count == 0)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, null, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                player.SetTag(Name, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }
        public override int GetDrawNum(Room room, Player player, int n)
        {
            player.SetFlags(Name);
            return n + 2;
        }
    }

    public class TunchuAdd : TriggerSkill
    {
        public TunchuAdd() : base("#tunchu-add")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventLoseSkill, TriggerEvent.AfterDrawNCards };
            frequency = Frequency.Compulsory;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventLoseSkill && data is InfoStruct info && info.Info == "tunchu")
                room.ClearOnePrivatePile(player, "commissariat");
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.AfterDrawNCards && player != null && player.Alive && player.HasFlag("tunchu"))
            {
                if (player.IsKongcheng())
                {
                    player.SetFlags("-tunchu");
                    return new TriggerStruct();
                }
                else
                {
                    return new TriggerStruct(Name, player) { SkillPosition = (string)player.GetTag("tunchu") };
                }
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            player.SetFlags("-tunchu");
            player.RemoveTag("tunchu");

            List<int> ids = room.AskForExchange(player, "tunchu", 2, 0, "@tunchu", string.Empty, ".|.|.|hand", info.SkillPosition);
            if (ids.Count > 0) room.AddToPile(player, "commissariat", ids);

            return false;
        }
    }


    public class TunchuProhibit : ProhibitSkill
    {
        public TunchuProhibit() : base("#tunchu-prohibit")
        {
        }
        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null)
        {
            if (from != null && from.GetPile("commissariat").Count > 0 && card != null && card.Name.Contains("Slash") && from.Phase != PlayerPhase.NotActive)
            {
                CardUseReason reason = room.GetRoomState().GetCurrentCardUseReason();
                return reason == CardUseReason.CARD_USE_REASON_PLAY || reason == CardUseReason.CARD_USE_REASON_RESPONSE_USE;
            }

            return false;
        }
    }

    public class Shuliang : TriggerSkill
    {
        public Shuliang() : base("shuliang")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            skill_type = SkillType.Replenish;
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> skill_list = new List<TriggerStruct>();
            if (player.Alive && player.Phase == PlayerPhase.Finish)
            {
                List<Player> lifengs = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in lifengs)
                {
                    int count = p.GetPile("commissariat").Count;
                    int distance = RoomLogic.DistanceTo(room, p, player);
                    if (count > 0 && RoomLogic.IsFriendWith(room, p, player) && count >= distance && distance >= 0)
                    {
                        TriggerStruct trigger = new TriggerStruct(Name, p);
                        skill_list.Add(trigger);
                    }
                }
            }
            return skill_list;
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player lifeng, TriggerStruct info)
        {
            if (player.Alive && player.Phase == PlayerPhase.Finish && lifeng.GetPile("commissariat").Count > 0)
            {
                List<int> ids = room.AskForExchange(lifeng, Name, 1, 0, "@shuliang:" + player.Name, "commissariat", string.Empty, info.SkillPosition);
                if (ids.Count > 0)
                {
                    CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_REMOVE_FROM_PILE, string.Empty, Name, Name);
                    room.ThrowCard(ref ids, reason, null);
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, lifeng.Name, player.Name);
                    room.BroadcastSkillInvoke(Name, lifeng, info.SkillPosition);
                    return info;
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.Alive)
                room.DrawCards(player, new DrawCardStruct(2, ask_who, Name));
            return false;
        }
    }


    //xushu
    public class JujianHCard : SkillCard
    {
        public static string ClassName = "JujianHCard";
        public JujianHCard() : base(ClassName)
        {
        }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && RoomLogic.WillBeFriendWith(room, to_select, Self);
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];

            List<string> choicelist = new List<string> { "draw" };
            if (target.IsWounded())
                choicelist.Add("recover");
            string choice = room.AskForChoice(target, "jujian_hegemony", string.Join("+", choicelist));

            if (choice == "draw")
                room.DrawCards(target, new DrawCardStruct(2, player, "jujian_hegemony"));
            else if (choice == "recover")
            {
                RecoverStruct recover = new RecoverStruct
                {
                    Recover = 1,
                    Who = player
                };
                room.Recover(target, recover, true);
            }

            if (player.Alive && player.GetMark("jujian_hegemony") == 0 && target.Alive && RoomLogic.CanTransform(target) && room.AskForSkillInvoke(target, "transform"))
            {
                player.SetMark("jujian_hegemony", 1);
                room.TransformDeputyGeneral(target);
            }
        }
    }

    public class JujianHVS : OneCardViewAsSkill
    {
        public JujianHVS() : base("jujian_hegemony")
        {
            filter_pattern = "^BasicCard!";
            response_pattern = "@@jujian_hegemony";
        }
        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard jujianCard = new WrappedCard(JujianHCard.ClassName) { Skill = Name, ShowSkill = Name };
            jujianCard.AddSubCard(card);
            return jujianCard;
        }
    }
    public class Zhuhai : TriggerSkill
    {
        public Zhuhai() : base("zhuhai")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damage, TriggerEvent.EventPhaseStart, TriggerEvent.CardUsedAnnounced };
            skill_type = SkillType.Attack;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Damage && player.Alive && room.Current == player)
                player.SetFlags(Name);
            else if (triggerEvent == TriggerEvent.CardUsedAnnounced && data is CardUseStruct use && use.Pattern == "Slash:zhuhai")
            {
                room.ShowSkill(player, Name, string.Empty);
                room.NotifySkillInvoked(player, Name);
                room.BroadcastSkillInvoke(Name, player);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Alive && player.Phase == PlayerPhase.Finish && player.HasFlag(Name))
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    if (player != p) triggers.Add(new TriggerStruct(Name, p));
            }

            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.Alive && ask_who.Alive)
            {
                ask_who.SetFlags("slashTargetFix");
                player.SetFlags("SlashAssignee");

                WrappedCard used = room.AskForUseCard(ask_who, RespondType.Slash, "Slash:zhuhai", "@zhuhai-slash:" + player.Name, null, -1, HandlingMethod.MethodUse, false);
                if (used == null)
                {
                    ask_who.SetFlags("-slashTargetFix");
                    player.SetFlags("-SlashAssignee");
                }
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info) => false;
    }

    public class ZhuhaiTag : TargetModSkill
    {
        public ZhuhaiTag() : base("#zhuhai", false) { }
        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseStruct.CardUseReason reason, string pattern)
        {
            if (reason == CardUseReason.CARD_USE_REASON_RESPONSE_USE && to.HasFlag("SlashAssignee")
                && (room.GetRoomState().GetCurrentResponseSkill() == "zhuhai" || pattern == "Slash:zhuhai"))
                return true;
            return false;
        }
    }

    public class JujianHegemony : PhaseChangeSkill
    {
        public JujianHegemony() : base("jujian_hegemony")
        {
            view_as_skill = new JujianHVS();
            relate_to_place = "deputy";
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Finish && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.AskForUseCard(player, RespondType.Skill, "@@jujian_hegemony", "@jujian", null, -1, HandlingMethod.MethodUse, true, info.SkillPosition);
            return new TriggerStruct();
        }

        public override bool OnPhaseChange(Room room, Player player, TriggerStruct info)
        {
            return false;
        }
    }

    //liuba
    public class Tongdu : TriggerSkill
    {
        public Tongdu() : base("tongdu")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseStart, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Replenish;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null && move.From.Alive && move.From.Phase == PlayerPhase.Discard
                && (move.From_places.Contains(Place.PlaceHand) || move.From_places.Contains(Place.PlaceEquip)) && (move.Reason.Reason & MoveReason.S_MASK_BASIC_REASON) == MoveReason.S_REASON_DISCARD)
            {
                for (int i = 0; i < move.Card_ids.Count; i++)
                    if (move.From_places[i] == Place.PlaceHand || move.From_places[i] == Place.PlaceEquip)
                        move.From.AddMark(Name);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                player.SetMark(Name, 0);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Alive && player.Phase == PlayerPhase.Finish && player.GetMark(Name) > 0)
            {
                List<Player> lbs = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in lbs)
                {
                    if (RoomLogic.WillBeFriendWith(room, p, player, Name))
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(ask_who, Name, player, info.SkillPosition))
            {
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, player.Name);
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int count = Math.Min(3, player.GetMark(Name));
            room.DrawCards(player, new DrawCardStruct(count, ask_who, Name));
            return false;
        }
    }

    public class Qingyin : ZeroCardViewAsSkill
    {
        public Qingyin() : base("qingyin")
        {
            frequency = Frequency.Limited;
            limit_mark = "@qingyin";
        }

        public override bool IsEnabledAtPlay(Room room, Player player) => player.GetMark(limit_mark) > 0;

        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(QingyinCard.ClassName) { Skill = Name, ShowSkill = Name };
    }

    public class QingyinCard : SkillCard
    {
        public static string ClassName = "QingyinCard";
        public QingyinCard() : base(ClassName)
        {
            target_fixed = true;
        }
        public override void OnUse(Room room, CardUseStruct card_use)
        {
            room.SetPlayerMark(card_use.From, "@qingyin", 0);
            room.BroadcastSkillInvoke("qingyin", card_use.From, card_use.Card.SkillPosition);
            room.DoSuperLightbox(card_use.From, card_use.Card.SkillPosition, "qingyin");
            base.OnUse(room, card_use);
        }
        public override void Use(Room room, CardUseStruct card_use)
        {
            List<Player> targets = new List<Player>();
            foreach (Player p in room.GetAlivePlayers())
            {
                if (RoomLogic.IsFriendWith(room, p, card_use.From))
                {
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, card_use.From.Name, p.Name);
                    targets.Add(p);
                }
            }
            room.SortByActionOrder(ref targets);
            card_use.To = targets;
            base.Use(room, card_use);

            if (card_use.From.Alive)
            {
                bool head = RoomLogic.InPlayerHeadSkills(card_use.From, "qingyin");
                if (!string.IsNullOrEmpty(card_use.Card.SkillPosition))
                    head = card_use.Card.SkillPosition == "head" ? true : false;
                room.RemoveGeneral(card_use.From, head);
            }
        }
        public override void OnEffect(Room room, CardEffectStruct effect)
        {
            if (effect.To.IsWounded())
            {
                RecoverStruct recover = new RecoverStruct();
                recover.Recover = effect.To.MaxHp - effect.To.Hp;
                recover.Who = effect.From;
                room.Recover(effect.To, recover, true);
            }
        }
    }

    //himiko
    public class Guishu : TriggerSkill
    {
        public Guishu() : base("guishu")
        {
            events.Add(TriggerEvent.EventPhaseChanging);
            skill_type = SkillType.Alter;
            view_as_skill = new GuishuVS();
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
    public class GuishuVS : ViewAsSkill
    {
        public GuishuVS() : base("guishu")
        {
            response_or_use = true;
        }
        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return true;
        }
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            return to_select.Suit == WrappedCard.CardSuit.Spade && selected.Count == 0 && room.GetCardPlace(to_select.Id) != Place.PlaceEquip;
        }

        public override List<WrappedCard> GetGuhuoCards(Room room, List<WrappedCard> cards, Player player)
        {
            List<WrappedCard> result = new List<WrappedCard>();
            if (cards.Count == 1)
            {
                foreach (FunctionCard fcard in room.AvailableFunctionCards)
                {
                    if (fcard.Name == BefriendAttacking.ClassName && (player.GetMark(Name) == 0 || player.GetMark(Name) == 1))
                    {

                        WrappedCard ba = new WrappedCard(BefriendAttacking.ClassName)
                        {
                            Skill = Name,
                            ShowSkill = Name,
                        };
                        ba.AddSubCards(cards);
                        result.Add(ba);
                    }

                    if (fcard.Name == KnownBoth.ClassName && (player.GetMark(Name) == 0 || player.GetMark(Name) == 2))
                    {
                        WrappedCard kb = new WrappedCard(KnownBoth.ClassName)
                        {
                            Skill = Name,
                            ShowSkill = Name,
                        };
                        kb.AddSubCards(cards);
                        result.Add(kb);
                    }
                }
            }

            return result;
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count == 1 && cards[0].IsVirtualCard())
            {
                WrappedCard gs = new WrappedCard(GuishuCard.ClassName)
                {
                    Skill = Name,
                    ShowSkill = Name,
                    UserString = cards[0].Name
                };
                gs.AddSubCard(cards[0]);
                return gs;
            }

            return null;
        }
    }

    public class GuishuCard : SkillCard
    {
        public static string ClassName = "GuishuCard";
        public GuishuCard() : base(ClassName)
        {
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            WrappedCard ba = new WrappedCard(card.UserString);
            ba.AddSubCard(card);
            ba = RoomLogic.ParseUseCard(room, ba);
            FunctionCard bcard = Engine.GetFunctionCard(card.UserString);

            return bcard.TargetFilter(room, targets, to_select, Self, ba);
        }

        public override WrappedCard Validate(Room room, CardUseStruct use)
        {
            Player player = use.From;
            WrappedCard ba = new WrappedCard(use.Card.UserString)
            {
                Skill = "guishu",
                ShowSkill = "guishu",
                SkillPosition = use.Card.SkillPosition
            };
            ba.AddSubCard(use.Card);
            ba = RoomLogic.ParseUseCard(room, ba);

            if (ba.Name == BefriendAttacking.ClassName)
                player.SetMark("guishu", 2);
            else
                player.SetMark("guishu", 1);

            return ba;
        }
    }

    public class Yuanyu : TriggerSkill
    {
        public Yuanyu() : base("yuanyu")
        {
            events.Add(TriggerEvent.DamageInflicted);
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Defense;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is DamageStruct damage && damage.From != null && damage.From.Alive && damage.From != damage.To
                && room.GetNextAlive(damage.From) != player && room.GetNextAlive(player) != damage.From)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            bool invoke = RoomLogic.PlayerHasShownSkill(room, player, Name) ? true : room.AskForSkillInvoke(player, Name, data, info.SkillPosition);
            if (invoke)
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name, true);
            DamageStruct damage = (DamageStruct)data;
            LogMessage log = new LogMessage
            {
                Type = "#ReduceDamage",
                From = player.Name,
                Arg = Name,
                Arg2 = (--damage.Damage).ToString()
            };
            room.SendLog(log);

            if (damage.Damage < 1)
                return true;
            data = damage;

            return false;
        }
    }

    public class WukuHegemony : TriggerSkill
    {
        public WukuHegemony() : base("wuku_hegemony")
        {
            events.Add(TriggerEvent.CardUsed);
            frequency = Frequency.Compulsory;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (data is CardUseStruct use && player != null && player.HasShownOneGeneral())
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is EquipCard)
                {
                    foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                        if (!RoomLogic.WillBeFriendWith(room, p, player) && p.GetMark("wuku") < 2)
                            triggers.Add(new TriggerStruct(Name, p));
                }
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (RoomLogic.PlayerHasShownSkill(room, ask_who, this) || room.AskForSkillInvoke(ask_who, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            ask_who.AddMark("wuku");
            room.SetPlayerStringMark(ask_who, "wuku", ask_who.GetMark("wuku").ToString());
            return false;
        }
    }

    //yanbaihu
    public class ZhidaoHegemony : TriggerSkill
    {
        public ZhidaoHegemony() : base("zhidao_hegemony")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damage, TriggerEvent.EventPhaseChanging, TriggerEvent.EventPhaseStart };
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Attack;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Damage && player.Phase == PlayerPhase.Play && data is DamageStruct damage && damage.To.HasFlag(Name))
                player.AddMark(Name);
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.From == PlayerPhase.Play && player.GetMark(Name) > 0)
                player.SetMark(Name, 0);

        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.Damage && data is DamageStruct damage && player.GetMark(Name) == 1 && damage.To.Alive && !damage.To.IsAllNude()
                 && damage.To.HasFlag(Name) && base.Triggerable(player, room) && RoomLogic.CanGetCard(room, player, damage.To, "hej") && damage.To != player)
            {
                return new TriggerStruct(Name, player);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Play && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                bool option = !RoomLogic.PlayerHasShownSkill(room, player, Name);
                string prompt = option ? "@zhidao-hegemony" : "@zhidao-hegemony2";
                Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, prompt, option, true, info.SkillPosition);
                if (target != null)
                {
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    room.SetTag(Name, target);
                }
                else
                    return new TriggerStruct();
            }

            return info;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                Player target = damage.To;
                room.SendCompulsoryTriggerLog(player, Name);
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, target.Name);
                List<int> ids = new List<int>();
                if (!target.IsKongcheng() && RoomLogic.CanGetCard(room, player, target, "h"))
                {
                    int id = room.AskForCardChosen(player, target, "h", Name, false, HandlingMethod.MethodGet);
                    ids.Add(id);
                }
                if (target.HasEquip() && RoomLogic.CanGetCard(room, player, target, "e"))
                {
                    int id = room.AskForCardChosen(player, target, "e", Name, false, HandlingMethod.MethodGet);
                    ids.Add(id);
                }
                if (target.JudgingArea.Count > 0 && RoomLogic.CanGetCard(room, player, target, "j"))
                {
                    int id = room.AskForCardChosen(player, target, "j", Name, false, HandlingMethod.MethodGet);
                    ids.Add(id);
                }
                if (ids.Count > 0)
                    room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_EXTRACTION, player.Name, target.Name, Name, string.Empty), false);

            }
            else if (room.GetTag(Name) is Player target)
            {
                room.RemoveTag(Name);
                player.SetFlags(Name);
                target.SetFlags(Name);
            }
            return false;
        }
    }

    public class ZhidaoHegemonyPro : ProhibitSkill
    {
        public ZhidaoHegemonyPro() : base("#zhidao_hegemony") { }

        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null)
        {
            if (from != null && Engine.GetFunctionCard(card.Name).TypeID != CardType.TypeSkill && from.HasFlag("zhidao_hegemony") && from.Phase != PlayerPhase.NotActive)
                return from != to && to != null && !to.HasFlag("zhidao_hegemony");

            return false;
        }
    }

    public class ZhidaoDistance : DistanceSkill
    {
        public ZhidaoDistance() : base("#zhidao-distance")
        {
        }
        public override int GetFixed(Room room, Player from, Player to)
        {
            if (from.HasFlag("zhidao_hegemony") && from.Phase != PlayerPhase.NotActive && to.HasFlag("zhidao_hegemony"))
                return 1;
            else
                return 0;
        }
    }

    public class JiliYbhHegemony : TriggerSkill
    {
        public JiliYbhHegemony() : base("jili_ybh_hegemony")
        {
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Wizzard;
            events = new List<TriggerEvent> { TriggerEvent.DamageInflicted, TriggerEvent.CardFinished, TriggerEvent.Damaged, TriggerEvent.EventPhaseChanging };
            relate_to_place = "deputy";
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Damaged && player.Alive)
                player.AddMark(Name);
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                foreach (Player p in room.GetAlivePlayers())
                    if (p.GetMark(Name) > 0) p.SetMark(Name, 0);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardFinished && data is CardUseStruct use && use.To.Count == 1 && base.Triggerable(use.To[0], room) && use.Card.Name != Jink.ClassName
                && use.From != null && use.From.Alive && WrappedCard.IsRed(use.Card.Suit))
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is BasicCard || (fcard is TrickCard && !(fcard is DelayedTrick)))
                {
                    WrappedCard card = new WrappedCard(use.Card.Name);
                    if (fcard.IsAvailable(room, use.From, card) && (fcard.TargetFixed(card) || RoomLogic.IsProhibited(room, use.From, use.To[0], card) == null))
                        return new TriggerStruct(Name, use.To[0]);
                }
            }
            else if (triggerEvent == TriggerEvent.DamageInflicted && base.Triggerable(player, room) && player.GetMark(Name) == 1)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.DamageInflicted && (RoomLogic.PlayerHasShownSkill(room, player, Name) || room.AskForSkillInvoke(player, Name, "@jili-remove", info.SkillPosition)))
                return info;
            else if (triggerEvent == TriggerEvent.CardFinished && data is CardUseStruct use
                && (RoomLogic.PlayerHasShownSkill(room, ask_who, Name) || room.AskForSkillInvoke(ask_who, Name, string.Format("@jili-use:{0}::{1}", use.From.Name, use.Card.Name), info.SkillPosition)))
                return info;

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            if (triggerEvent == TriggerEvent.DamageInflicted)
            {
                room.RemoveGeneral(ask_who, false);
                return true;
            }
            else if (data is CardUseStruct use)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                WrappedCard card = new WrappedCard(use.Card.Name);
                room.UseCard(new CardUseStruct(card, use.From, fcard.TargetFixed(card) ? new List<Player>() : new List<Player> { ask_who }));
            }
            return false;
        }
    }


    //huangzhu
    public class Xishe : TriggerSkill
    {
        public Xishe() : base("xishe")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging, TriggerEvent.EventPhaseStart, TriggerEvent.TargetChosen, TriggerEvent.Death };
            skill_type = SkillType.Attack;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName) && use.Card.GetSkillName() == Name)
            {
                foreach (Player p in use.To)
                {
                    if (p.Hp < player.Hp)
                    {
                        LogMessage log = new LogMessage
                        {
                            Type = "#NoJink",
                            From = p.Name
                        };
                        room.SendLog(log);
                    }
                }

                for (int i = 0; i < use.EffectCount.Count; i++)
                {
                    CardBasicEffect effect = use.EffectCount[i];
                    if (effect.To.Hp < player.Hp)
                        effect.Effect2 = 0;
                }

                data = use;
            }
            else if (triggerEvent == TriggerEvent.Death && data is DeathStruct death && death.Damage.From != null && death.Damage.Card != null && death.Damage.From.Alive
                && death.Damage.From.GetMark(Name + "_transform") == 0 && death.Damage.Card.Name.Contains(Slash.ClassName) && death.Damage.Card.GetSkillName() == Name && death.Damage.From != player)
            {
                death.Damage.From.SetFlags(Name);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetOtherPlayers(player))
                    if (p.HasFlag(Name) && RoomLogic.CanTransform(p)) triggers.Add(new TriggerStruct(Name, p));
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart && player.Alive && player.Phase == PlayerPhase.Start)
            {
                WrappedCard card = new WrappedCard(Slash.ClassName) { Skill = "_xishe", DistanceLimited = false };
                List<Player> hzs = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in hzs)
                {
                    if (p != player && p.HasEquip() && RoomLogic.IsProhibited(room, p, player, card) == null)
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }

            return triggers;

        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && room.AskForSkillInvoke(ask_who, "transform"))
                return info;
            else if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                List<int> ids = new List<int>();
                foreach (int id in ask_who.GetCards("e"))
                    if (RoomLogic.CanDiscard(room, ask_who, ask_who, id))
                        ids.Add(id);
                List<string> strs = JsonUntity.IntList2StringList(ids);
                List<int> dis = room.AskForExchange(ask_who, Name, 1, 0, "@xishe:" + player.Name, string.Empty, string.Join("#", strs), info.SkillPosition);
                if (dis.Count > 0)
                {
                    room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                    room.ThrowCard(dis[0], ask_who, null, Name);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging)
            {
                ask_who.AddMark(Name + "_transform");
                room.TransformDeputyGeneral(ask_who);
            }
            else
            {
                WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = "_xishe", DistanceLimited = false };
                room.UseCard(new CardUseStruct(slash, ask_who, player, false));

                while (player.Alive && ask_who.Alive && ask_who.HasEquip())
                {
                    WrappedCard card = new WrappedCard(Slash.ClassName) { Skill = "_xishe", DistanceLimited = false };
                    if (RoomLogic.IsProhibited(room, ask_who, player, card) == null)
                    {
                        List<int> ids = new List<int>();
                        foreach (int id in ask_who.GetCards("e"))
                            if (RoomLogic.CanDiscard(room, ask_who, ask_who, id))
                                ids.Add(id);
                        List<string> strs = JsonUntity.IntList2StringList(ids);
                        List<int> dis = room.AskForExchange(ask_who, Name, 1, 0, "@xishe:" + player.Name, string.Empty, string.Join("#", strs), info.SkillPosition);
                        if (dis.Count > 0)
                        {
                            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                            room.ThrowCard(dis[0], ask_who, null, Name);
                            room.UseCard(new CardUseStruct(card, ask_who, player, false));
                        }
                        else
                            break;
                    }
                    else
                        break;
                }
            }

            return false;
        }
    }

    //lvlingqi
    public class GuowuHegemony : TriggerSkill
    {
        public GuowuHegemony() : base("guowu_hegemony")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging, TriggerEvent.EventPhaseStart, TriggerEvent.CardTargetAnnounced };
            skill_type = SkillType.Attack;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.From == PlayerPhase.Play)
            {
                player.SetFlags("-guowu_hegemony_distance");
                player.SetFlags("-guowu_hegemony_tar");
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Play && base.Triggerable(player, room) && !player.IsKongcheng())
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct _use && player.HasFlag("guowu_hegemony_tar"))
            {
                FunctionCard fcard = Engine.GetFunctionCard(_use.Card.Name);
                if (fcard is Slash || (fcard.IsNDTrick() && !(fcard is AOE) && _use.Card.Name != Collateral.ClassName && _use.Card.Name != AwaitExhausted.ClassName
                    && _use.Card.Name != BurningCamps.ClassName && _use.Card.Name != ThreatenEmperor.ClassName && _use.Card.Name != FightTogether.ClassName))
                    return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.ShowAllCards(player, null, Name, info.SkillPosition);
                return info;
            }
            else if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                List<Player> targets = new List<Player>();
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (!use.To.Contains(p) && RoomLogic.IsProhibited(room, use.From, p, use.Card) == null)
                    {
                        if ((fcard is Slash && p == use.From) || (fcard is Peach && !p.IsWounded())
                            || (fcard is IronChain && !p.Chained && !RoomLogic.CanBeChainedBy(room, player, p))
                            || (fcard is FireAttack && p.IsKongcheng())
                            || (fcard is Snatch && (!RoomLogic.CanGetCard(room, player, p, "hej") || p == use.From || p.IsAllNude()))
                            || (fcard is Dismantlement && (!RoomLogic.CanDiscard(room, player, p, "hej") || p == use.From || p.IsAllNude()))
                            || (fcard is Duel && p == use.From)
                            || ((fcard is ArcheryAttack || fcard is SavageAssault) && p == use.From)
                            || (fcard is BefriendAttacking && (p == use.From || !p.HasShownOneGeneral() || RoomLogic.IsFriendWith(room, use.From, p)))
                            || (fcard is AllianceFeast && (p == use.From || !p.HasShownOneGeneral() || RoomLogic.IsFriendWith(room, use.From, p)))) continue;
                        targets.Add(p);
                    }
                }

                if (targets.Count > 0)
                {
                    room.SetTag("extra_target_skill", data);
                    List<Player> victims = room.AskForPlayersChosen(player, targets, Name, 0, 2, string.Format("@guowu_hegemony:::{0}", use.Card.Name), true, info.SkillPosition);
                    room.RemoveTag("extra_target_skill");
                    if (victims.Count > 0)
                    {
                        player.SetFlags("-guowu_hegemony_tar");
                        room.SetTag(Name, victims);
                        return info;
                    }
                }
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                List<Player> targets = (List<Player>)room.GetTag(Name);
                room.RemoveTag(Name);
                use.To.AddRange(targets);
                LogMessage log = new LogMessage
                {
                    Type = "$extra_target",
                    From = player.Name,
                    Card_str = RoomLogic.CardToString(room, use.Card),
                    Arg = Name
                };
                log.SetTos(targets);
                room.SendLog(log);

                room.SortByActionOrder(ref use);
                data = use;
            }
            else
            {
                bool basic = false, equip = false, trick = false;
                int count = 0;
                foreach (int id in player.GetCards("h"))
                {
                    FunctionCard fcard = Engine.GetFunctionCard(room.GetCard(id).Name);
                    if (!basic && fcard is BasicCard)
                    {
                        basic = true;
                        count++;
                    }
                    else if (!equip && fcard is EquipCard)
                    {
                        equip = true;
                        count++;
                    }
                    else if (!trick && fcard is TrickCard)
                    {
                        trick = true;
                        count++;
                    }
                }
                if (count > 0)
                {
                    int slash = -1;
                    foreach (int id in room.DiscardPile)
                    {
                        if (room.GetCard(id).Name.Contains(Slash.ClassName))
                        {
                            slash = id;
                            break;
                        }
                    }

                    if (slash > -1)
                        room.ObtainCard(player, room.GetCard(slash), new CardMoveReason(MoveReason.S_REASON_RECYCLE, player.Name, Name, string.Empty));
                }

                if (player.Alive && count > 1)
                    player.SetFlags("guowu_hegemony_distance");
                if (player.Alive && count > 2)
                    player.SetFlags("guowu_hegemony_tar");
            }

            return false;
        }
    }

    public class GuowuHegemonyTar : TargetModSkill
    {
        public GuowuHegemonyTar() : base("#guowu_hegemony", false)
        {
            pattern = "Slash#TrickCard";
        }

        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern) => from.HasFlag("guowu_hegemony_distance");
    }

    public class ZhuangrongHegemony : DrawCardsSkill
    {
        public ZhuangrongHegemony() : base("zhuangrong_hegemony")
        {
            frequency = Frequency.Compulsory;
            relate_to_place = "head";
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            bool invoke = false;
            if (RoomLogic.PlayerHasShownSkill(room, player, Name))
            {
                room.SendCompulsoryTriggerLog(player, Name);
                invoke = true;
            }
            else if (room.AskForSkillInvoke(player, Name, null, info.SkillPosition))
            {
                invoke = true;
            }
            if (invoke)
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            else
                return new TriggerStruct();
        }

        public override int GetDrawNum(Room room, Player player, int n) => n + 2;
    }

    public class ZhuangrongMax : MaxCardsSkill
    {
        public ZhuangrongMax() : base("#zhuangrong_hegemony") { }
        public override int GetExtra(Room room, Player target)
        {
            return RoomLogic.PlayerHasSkill(room, target, "zhuangrong_hegemony") ? 2 : 0;
        }
    }

    //liufuren
    public class Zhuidu : TriggerSkill
    {
        public Zhuidu() : base("zhuidu")
        {
            events.Add(TriggerEvent.DamageCaused);
            skill_type = SkillType.Attack;
            view_as_skill = new ZhuiduVS();
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is DamageStruct damage && base.Triggerable(player, room) && player != damage.To && damage.To.Alive && !player.HasFlag(Name))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                if (damage.To.PlayerGender == Gender.Female && damage.To.HasEquip() && RoomLogic.CanDiscard(room, damage.To, damage.To, "e"))
                {
                    WrappedCard card = room.AskForUseCard(player, RespondType.Skill, "@@zhuidu", "@zhuidu:" + damage.To.Name, null, -1, HandlingMethod.MethodUse, true, info.SkillPosition);
                    if (card != null)
                    {
                        List<int> ids = new List<int>(card.SubCards);
                        if (ids.Count > 0)
                        {
                            player.SetFlags("zhuidu_both");
                            room.ThrowCard(ref ids, player, null, Name);
                        }

                        room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, damage.To.Name);
                        player.SetFlags(Name);
                        room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                        return info;
                    }
                }
                else if (room.AskForSkillInvoke(player, Name, damage.To, info.SkillPosition))
                {
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, damage.To.Name);
                    player.SetFlags(Name);
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                Player target = damage.To;
                if (player.HasFlag("zhuidu_both"))
                {
                    player.SetFlags("-zhuidu_both");
                    List<int> ids = new List<int>();
                    foreach (int id in target.GetEquips())
                        if (RoomLogic.CanDiscard(room, target, target, id))
                            ids.Add(id);

                    if (ids.Count > 0)
                        room.ThrowCard(ref ids, new CardMoveReason(MoveReason.S_REASON_THROW, player.Name, target.Name, Name, string.Empty), target);

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
                }
                else
                {
                    bool add = true;
                    if (target.HasEquip() && RoomLogic.CanDiscard(room, target, target, "e"))
                        add = !room.AskForSkillInvoke(target, Name, string.Format("@zhuidu-choose:{0}::{1}:{2}", player.Name, damage.Card != null ? damage.Card.Name : damage.Reason, damage.Damage));

                    if (!add)
                    {
                        List<int> ids = new List<int>();
                        foreach (int id in target.GetEquips())
                            if (RoomLogic.CanDiscard(room, target, target, id))
                                ids.Add(id);

                        if (ids.Count > 0)
                            room.ThrowCard(ref ids, new CardMoveReason(MoveReason.S_REASON_THROW, player.Name, target.Name, Name, string.Empty), target);
                    }
                    else
                    {
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
                    }
                }
            }
            return false;
        }
    }

    public class ZhuiduVS : ViewAsSkill
    {
        public ZhuiduVS() : base("zhuidu") { response_pattern = "@@zhuidu"; }
        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            WrappedCard card = new WrappedCard(DummyCard.ClassName);
            card.AddSubCards(cards);
            return card;
        }
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player) => selected.Count == 0 && RoomLogic.CanDiscard(room, player, player, to_select.Id);
    }

    public class Shigong : TriggerSkill
    {
        public Shigong() : base("shigong")
        {
            events.Add(TriggerEvent.Dying);
            skill_type = SkillType.Recover;
            frequency = Frequency.Limited;
            limit_mark = "@shigong";
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.GetMark(limit_mark) > 0 && player.Phase == PlayerPhase.NotActive && room.Current != null && room.Current.Alive
                && room.Current != player && !player.ActualGeneral2.Contains("sujiang"))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                room.SetPlayerMark(player, limit_mark, 0);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.DoSuperLightbox(player, info.SkillPosition, Name);
                player.SetTag(Name, player.ActualGeneral2);
                room.RemoveGeneral(player, false);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.Alive && room.Current.Alive && player.GetTag(Name) is string general)
            {
                player.RemoveTag(Name);
                List<string> skills = new List<string>();
                foreach (string skill in Engine.GetGeneralSkills(general, room.Setting.GameMode, false))
                {
                    Skill real = Engine.GetSkill(skill);
                    if (real.SkillFrequency < Frequency.Compulsory)
                        skills.Add(skill);
                }
                skills.Add("recover");
                string choice = room.AskForChoice(room.Current, Name, string.Join("+", skills), new List<string> { "@shigong-choose:" + player.Name }, player);
                if (choice == "recover")
                {
                    int count = 1 - player.Hp;
                    if (count > 0)
                        room.Recover(player, count);
                }
                else
                {
                    room.HandleAcquireDetachSkills(room.Current, choice, true);
                    if (player.Alive)
                    {
                        int count = player.MaxHp - player.Hp;
                        if (count > 0)
                            room.Recover(player, count);
                    }
                }
            }

            return false;
        }
    }

    //huaxiong
    public class YaowuHegemony : TriggerSkill
    {
        public YaowuHegemony() : base("yaowu_hegemony")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damage, TriggerEvent.Death };
            frequency = Frequency.Limited;
            limit_mark = "@yaowu_hegemony";
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Death && player.GetMark(Name) > 0)
            {
                foreach (Player p in room.GetAlivePlayers())
                    if (RoomLogic.IsFriendWith(room, p, player))
                        room.LoseHp(p);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.Damage && base.Triggerable(player, room) && player.GetMark(limit_mark) > 0)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, data , info.SkillPosition))
            {
                room.RemovePlayerMark(player, limit_mark);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.DoSuperLightbox(player, info.SkillPosition, Name);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.Alive)
            {
                room.AddPlayerMark(player, Name);

                player.MaxHp += 2;
                room.BroadcastProperty(player, "MaxHp");

                LogMessage log = new LogMessage
                {
                    Type = "$GainMaxHp",
                    From = player.Name,
                    Arg = "2"
                };
                room.SendLog(log);

                room.RoomThread.Trigger(TriggerEvent.MaxHpChanged, room, player);
                room.Recover(player, 2);
            }
            return false;
        }
    }

    public class Shiyong : TriggerSkill
    {
        public Shiyong() : base("shiyong")
        {
            events.Add(TriggerEvent.DamageDone);
            frequency = Frequency.Compulsory;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is DamageStruct damage && damage.Card != null && base.Triggerable(player, room) && ((player.GetMark("yaowu_hegemony") > 0 && !WrappedCard.IsRed(damage.Card.Suit))
                || (player.GetMark("yaowu_hegemony") == 0 && !WrappedCard.IsBlack(damage.Card.Suit) && damage.From != null && damage.From.Alive)))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (RoomLogic.PlayerHasShownSkill(room, player, Name) || room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
                return info;

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                room.SendCompulsoryTriggerLog(player, Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                if (player.GetMark("yaowu_hegemony") == 0 && !WrappedCard.IsBlack(damage.Card.Suit) && damage.From != null && damage.From.Alive)
                    room.DrawCards(damage.From, 1, Name);
                else if (player.Alive && player.GetMark("yaowu_hegemony") == 0 && !WrappedCard.IsRed(damage.Card.Suit))
                    room.DrawCards(player, 1, Name);
            }

            return false;
        }
    }

    //lincao
    public class Dujin : DrawCardsSkill
    {
        public Dujin() : base("dujin")
        {
            skill_type = SkillType.Replenish;
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
        public override int GetDrawNum(Room room, Player player, int n)
        {
            int m = player.GetEquips().Count / 2 + 1;
            return n + m;
        }
    }


    public class AocaiHegemony : TriggerSkill
    {
        public AocaiHegemony() : base("aocai_hegemony")
        {
            skill_type = SkillType.Defense;
            view_as_skill = new AocaiHegemonyVS();
            events = new List<TriggerEvent> { TriggerEvent.DrawPileChanged, TriggerEvent.CardsMoveOneTime };
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.DrawPileChanged)
            {
                List<Player> zhugeke = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in zhugeke)
                    p.Piles["#aocai"] = new List<int>();
            }
            else if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move)
            {
                if ((base.Triggerable(move.From, room) && move.From_places.Contains(Place.PlaceHand)))
                    move.From.Piles["#aocai"] = new List<int>();

                if ((base.Triggerable(move.To, room) && move.To_place == Place.PlaceHand))
                    move.To.Piles["#aocai"] = new List<int>();
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class AocaiHegemonyVS : ViewAsSkill
    {
        public AocaiHegemonyVS() : base("aocai_hegemony")
        {
            expand_pile = "#aocai";
        }
        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return false;
        }
        public override bool IsEnabledAtResponse(Room room, Player player, RespondType respond, string pattern)
        {
            if (player.Phase != PlayerPhase.NotActive || (!MatchBasic(respond) && !MatchRetrial(respond)))
                return false;

            return true;
        }

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            return selected.Count == 0 && player.GetPile(expand_pile).Contains(to_select.Id)
                && Engine.MatchExpPattern(room, room.GetRoomState().GetCurrentCardUsePattern(player), player, to_select);
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (player.GetPile(expand_pile).Count == 0)
                return new WrappedCard(AocaiHegemonyCard.ClassName) { Skill = Name, Mute = true };
            else if (cards.Count == 1)
                return cards[0];

            return null;
        }
    }

    public class AocaiHegemonyCard : SkillCard
    {
        public static string ClassName = "AocaiHegemonyCard";
        public AocaiHegemonyCard() : base(ClassName)
        {
            target_fixed = true;
        }
        public override WrappedCard Validate(Room room, CardUseStruct use)
        {
            View(room, use.From, use.Card.SkillPosition);
            return null;
        }

        public override WrappedCard ValidateInResponse(Room room, Player player, WrappedCard card)
        {
            View(room, player, card.SkillPosition);
            return null;
        }

        private void View(Room room, Player player, string head)
        {
            room.ShowSkill(player, "aocai_hegemony", head);
            int count = 2;
            List<int> guanxing = room.GetNCards(count, false);
            room.NotifySkillInvoked(player, "aocai_hegemony");
            room.BroadcastSkillInvoke("aocai_hegemony", player, head);
            LogMessage log = new LogMessage
            {
                Type = "$ViewDrawPile",
                From = player.Name,
                Card_str = string.Join("+", JsonUntity.IntList2StringList(guanxing))
            };
            room.SendLog(log, player);
            log.Type = "$ViewDrawPile2";
            log.Arg = guanxing.Count.ToString();
            log.Card_str = null;
            room.SendLog(log, new List<Player> { player });

            player.Piles["#aocai"] = guanxing;
            room.SetPromotSkill(player, "aocai_hegemony", head, room.GetRoomState().GetCurrentCardUsePattern(), room.GetRoomState().GetCurrentCardUseReason());
        }
    }

    public class DuwuHegemony : TriggerSkill
    {
        public DuwuHegemony() : base("duwu_hegemony")
        {
            events.Add(TriggerEvent.QuitDying);
            skill_type = SkillType.Attack;
            view_as_skill = new DuwuHegemonyVS();
            frequency = Frequency.Limited;
            limit_mark = "@duwu_hegemony";
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is DyingStruct dying && dying.Damage.From != null && !string.IsNullOrEmpty(dying.Damage.Reason) && dying.Damage.Reason == Name && dying.Damage.From.Alive
                && !dying.Damage.Transfer && !dying.Damage.Chain && player.Alive)
            {
                foreach (Player p in room.GetOtherPlayers(player))
                    if (p.HasFlag(Name)) p.SetFlags("-duwu_hegemony");
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class DuwuHegemonyVS : ZeroCardViewAsSkill
    {
        public DuwuHegemonyVS() : base("duwu_hegemony")
        {
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            if (player.GetMark("@duwu_hegemony") > 0)
            {
                foreach (Player p in room.GetOtherPlayers(player))
                    if (RoomLogic.InMyAttackRange(room, player, p) && !RoomLogic.WillBeFriendWith(room, player, p, Name))
                        return true;
            }
            return false;
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(DuwuHegemonyCard.ClassName)
            {
                Skill = Name,
                ShowSkill = Name,
                Mute = true
            };
        }
    }

    public class DuwuHegemonyCard : SkillCard
    {
        public static string ClassName = "DuwuHegemonyCard";
        public DuwuHegemonyCard() : base(ClassName) { target_fixed = true; }
        public override void OnUse(Room room, CardUseStruct card_use)
        {
            room.SetPlayerMark(card_use.From, "@duwu_hegemony", 0);
            room.BroadcastSkillInvoke("duwu_hegemony", card_use.From, card_use.Card.SkillPosition);
            room.DoSuperLightbox(card_use.From, card_use.Card.SkillPosition, "duwu_hegemony");
            base.OnUse(room, card_use);
        }
        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            WrappedCard card = room.AskForUseCard(player, RespondType.Skill, "@@imperialorder!", "@duwu_select", null, -1, HandlingMethod.MethodUse);
            if (card == null)
            {
                string card_name = player.ContainsTag("imperialorder_select") ? ((string)player.GetTag("imperialorder_select")).Split('+')[0] : string.Empty;
                if (string.IsNullOrEmpty(card_name))
                    card = ImperialOrderVS.GetImperialOrders(room, player)[0];
                else
                    card = new WrappedCard(card_name);

                room.UseCard(new CardUseStruct(card, player, new List<Player>()));
            }
            player.RemoveTag("imperialorder_select");

            List<Player> targets = new List<Player>();
            foreach (Player p in room.GetOtherPlayers(player))
            {
                if (RoomLogic.InMyAttackRange(room, player, p) && !RoomLogic.IsFriendWith(room, player, p))
                {
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, p.Name);
                    targets.Add(p);
                }
            }
            room.SortByActionOrder(ref targets);

            player.SetFlags("duwu_hegemony");
            player.SetTag("order_reason", "duwu_hegemony");
            FunctionCard fcard = Engine.GetFunctionCard(card.Name);
            if (fcard != null && fcard is ImperialOrder order)
            {
                foreach (Player p in targets)
                {
                    if (!order.Effect(room, player, p) && player.Alive && p.Alive)
                    {
                        room.Damage(new DamageStruct("duwu_hegemony", player, p));
                        if (player.Alive)
                            room.DrawCards(player, 1, "duwu_hegemony");
                    }
                }
            }

            if (player.Alive && !player.HasFlag("duwu_hegemony"))
            {
                LogMessage log = new LogMessage
                {
                    Type = "#duwu-lose",
                    From = player.Name
                };
                
                room.SendLog(log);
                room.LoseHp(player);
            }
        }
    }

    public class Diaogui : OneCardViewAsSkill
    {
        public Diaogui() : base("diaogui")
        {
            filter_pattern = "EquipCard";
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.IsNude() && !player.HasUsed(DiaoguiCard.ClassName);
        }

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            if (card != null)
            {
                WrappedCard dg = new WrappedCard(DiaoguiCard.ClassName) { Skill = Name, ShowSkill = Name };
                dg.AddSubCard(card);
                return dg;
            }
            return null;
        }
    }

    public class DiaoguiCard : SkillCard
    {
        public static string ClassName = "DiaoguiCard";
        public DiaoguiCard() : base(ClassName)
        {
            will_throw = false;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            WrappedCard lt = new WrappedCard(LureTiger.ClassName);
            lt.AddSubCards(card.SubCards);
            lt = RoomLogic.ParseUseCard(room, lt);
            return Engine.GetFunctionCard(LureTiger.ClassName).TargetFilter(room, targets, to_select, Self, lt);
        }

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            WrappedCard lt = new WrappedCard(LureTiger.ClassName) { Skill = "diaogui", ShowSkill = "diaogui", SkillPosition = card_use.Card.SkillPosition };
            lt.AddSubCards(card_use.Card.SubCards);
            lt = RoomLogic.ParseUseCard(room, lt);

            List<Player> targets = room.AliveCount() >= 4 ? RoomLogic.GetFormation(room, card_use.From) : new List<Player>();
            int count = targets.Count > 1 ? targets.Count : 0;

            room.UseCard(new CardUseStruct(lt, card_use.From, card_use.To, true));

            if (card_use.From.Alive)
            {
                targets = room.AliveCount() >= 4 ? RoomLogic.GetFormation(room, card_use.From) : new List<Player>();
                int dix = (targets.Count > 1 ? targets.Count : 0) - count;
                if (dix > 0)
                    room.DrawCards(card_use.From, dix, "diaogui");
            }
        }
    }

    public class Fengyang : BattleArraySkill
    {
        public Fengyang() : base("fengyang", ArrayType.Formation)
        {
            events = new List<TriggerEvent>{ TriggerEvent.EventPhaseStart, TriggerEvent.Death, TriggerEvent.EventAcquireSkill, TriggerEvent.GeneralShown,TriggerEvent.GeneralHidden,TriggerEvent.RemoveStateChanged };
        }
        public override bool CanPreShow() => false;
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            Player current = room.Current;
            if (player == null || current == null) return;

            if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                if (player.Phase != PlayerPhase.RoundStart)
                    return;
            }
            else if (triggerEvent == TriggerEvent.Death)
            {
                if (player != current && !RoomLogic.IsFriendWith(room, player, player))
                    return;
            }
            else if (triggerEvent == TriggerEvent.GeneralShown)
            {
                if (player.HasShownAllGenerals() || !RoomLogic.InFormationRalation(room, current, player))
                    return;
            }
            else if (triggerEvent == TriggerEvent.GeneralHidden && player.HasShownOneGeneral())
            {
                return;
            }

            if (room.AliveCount() < 4)
                return;

            if (current != null && current.Alive && current.Phase != PlayerPhase.NotActive)
            {
                List<Player> jiangweis = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player jiangwei in jiangweis)
                {
                    if (RoomLogic.PlayerHasShownSkill(room, jiangwei, Name) && RoomLogic.InFormationRalation(room, jiangwei, current))
                    {
                        room.DoBattleArrayAnimate(jiangwei);
                        break;
                    }
                }
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            return new TriggerStruct();
        }
    }

    public class FengYangFix : FixCardSkill
    {
        public FengYangFix() : base("#fengyang")
        {
        }
        public override bool IsCardFixed(Room room, Player from, Player to, string flags, HandlingMethod method)
        {
            if (room.AliveCount() >= 4 && !RoomLogic.IsFriendWith(room, from, to) && (method == HandlingMethod.MethodGet || method == HandlingMethod.MethodDiscard) && flags.Contains("e"))
            {
                List<Player> players = RoomLogic.GetFormation(room, to);
                if (players.Count > 1)
                {
                    foreach (Player p in players)
                        if (RoomLogic.PlayerHasShownSkill(room, p, "fengyang"))
                            return true;
                }
            }

            return false;
        }
    }
}