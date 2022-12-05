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
    public class StrategyAI : AIPackage
    {
        public StrategyAI() : base("Strategy")
        {
            events = new List<SkillEvent>
            {
                new QiaoAI(),
                new ChengshangAI(),
                new JianliangHegemonyAI(),
                new WeimengHegemonyAI(),
                new WeimengSAI(),
                new YouyanHegemonyAI(),
                new ZhuihuanHegemonyAI(),

                new ZhiweiAI(),
                new ZhenteAI(),
                new YusuiAI(),
                new BoyanAI(),
                new BoyanSAI(),

                new ShejianHegemonyAI(),
                new FenglueHegemonyAI(),
                new FenglueSAI(),
                new AnyongAI(),
            };

            use_cards = new List<UseCard>
            {
                new BoyanCardAI(),
                new BoyanSCardAI(),
                new FenglueCardAI(),
                new FenglueSCardAI(),
                new WeimengHCardAI(),
                new WeimengSCardAI(),
            };
        }
    }


    public class QiaoAI : SkillEvent
    {
        public QiaoAI() : base("qiao") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (data is Player target && !ai.IsFriend(target))
                return true;

            return false;
        }
    }

    public class ChengshangAI : SkillEvent
    {
        public ChengshangAI() : base("chengshang") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data) => ai.WillShowForAttack() && data is Player target && !ai.IsFriend(target);
        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            if (ai.WillShowForAttack())
            {
                ai.SortByDefense(ref targets);
                foreach (Player p in targets)
                    if (ai.IsEnemy(p))
                        return new List<Player> { p };
                foreach (Player p in targets)
                    if (!ai.IsFriend(p))
                        return new List<Player> { p };
            }
            return new List<Player>();
        }
    }

    public class JianliangHegemonyAI : SkillEvent
    {
        public JianliangHegemonyAI() : base("jianliang_hegemony") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data) => ai.WillShowForDefence();
    }

    public class WeimengHegemonyAI : SkillEvent
    {
        public WeimengHegemonyAI() : base("weimeng_hegemony") { }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (!player.HasUsed(WeimengHCard.ClassName))
                return new List<WrappedCard> { new WrappedCard(WeimengHCard.ClassName) { Skill = Name, ShowSkill = Name } };

            return new List<WrappedCard>();
        }
        public override List<int> OnExchange(TrustedAI ai, Player player, string pattern, int min, int max, string pile)
        {
            List<int> ids = new List<int>();
            List<int> cards = player.GetCards("he");
            ai.SortByUseValue(ref cards, false);
            for (int i = 0; i < Math.Min(cards.Count, min); i++)
                ids.Add(cards[i]);

            return ids;
        }
    }

    public class WeimengHCardAI : UseCard
    {
        public WeimengHCardAI() : base(WeimengHCard.ClassName) { }
        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            List<Player> enemies = ai.GetEnemies(player);
            if (enemies.Count > 0)
            {
                ai.SortByDefense(ref enemies, false);
                foreach (Player p in enemies)
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

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 7;
    }

    public class WeimengSAI : SkillEvent
    {
        public WeimengSAI() : base("weimeng_strategy") { }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (!player.HasUsed(WeimengSCard.ClassName))
                return new List<WrappedCard> { new WrappedCard(WeimengSCard.ClassName) { Skill = Name } };

            return new List<WrappedCard>();
        }
        public override List<int> OnExchange(TrustedAI ai, Player player, string pattern, int min, int max, string pile)
        {
            List<int> cards = player.GetCards("he");
            ai.SortByUseValue(ref cards, false);
            return new List<int> { cards[0] };
        }
    }

    public class WeimengSCardAI : UseCard
    {
        public WeimengSCardAI() : base(WeimengSCard.ClassName) { }
        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            List<Player> enemies = ai.GetEnemies(player);
            if (enemies.Count > 0)
            {
                ai.SortByDefense(ref enemies, false);
                foreach (Player p in enemies)
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

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 7;
    }

    public class YouyanHegemonyAI : SkillEvent
    {
        public YouyanHegemonyAI() : base("youyan_hegemony") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data) => ai.WillShowForAttack() || ai.WillShowForDefence();
    }

    public class ZhuihuanHegemonyAI : SkillEvent
    {
        public ZhuihuanHegemonyAI() : base("zhuihuan_hegemony") { }
        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            List<Player> result = new List<Player>();
            ai.SortByDefense(ref targets, false);
            foreach (Player p in targets)
            {
                if (ai.IsFriend(p))
                {
                    result.Add(p);
                    if (result.Count >= 2)
                        break;
                }
            }
            return result;
        }
        public override ScoreStruct GetDamageScore(TrustedAI ai, DamageStruct damage)
        {
            ScoreStruct score = new ScoreStruct
            {
                Score = 0
            };

            if (damage.To != null && damage.To.GetMark("zhuihuan_0") > 1 && damage.From != null && damage.From != damage.To)
            {
                DamageStruct _damage = new DamageStruct(Name, damage.To, damage.From);
                if (ai.DamageEffect(_damage, DamageStruct.DamageStep.Caused) > 0)
                {
                    float point = -3;
                    if (damage.From.Hp == 1) point = -10;
                    if (damage.To.Hp - damage.Damage == 0)
                        point += 1;
                    else if (damage.To.Hp - damage.Damage < 0)
                        point = 0;
                    if (ai.IsFriend(damage.From))
                        score.Score = point;
                    else
                        score.Score = -point;
                }
            }
            if (damage.To != null && damage.To.GetMark("zhuihuan_1") > 1 && damage.From != null && damage.From != damage.To)
            {
                float point = -2;
                if (damage.From.HandcardNum < 2) point /= 2;
                if (damage.To.Hp - damage.Damage == 0)
                    point /= 2;
                else if (damage.To.Hp - damage.Damage < 0)
                    point = 0;
                if (ai.IsFriend(damage.From))
                    score.Score = point;
                else
                    score.Score = -point;
            }

            return score;
        }
    }

    public class ZhiweiAI : SkillEvent
    {
        public ZhiweiAI() : base("zhiwei") { }
        public override List<Player> OnPlayerChosen(TrustedAI ai, Player player, List<Player> targets, int min, int max)
        {
            ai.SortByDefense(ref targets);
            foreach (Player p in targets)
                if (ai.IsFriend(p)) return new List<Player> { p };
            return new List<Player>();
        }
    }
    public class ZhenteAI : SkillEvent
    {
        public ZhenteAI() : base("zhente") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (data is CardUseStruct use)
            {
                if (use.Card.Name != Edict.ClassName && use.Card.Name != KnownBoth.ClassName && ai.IsCardEffect(use.Card, player, use.From))
                {
                    if (ai.IsWeak(player))
                        return true;
                    else if (!ai.IsFriend(use.From))
                        return true;
                }
            }

            return false;
        }
    }

    public class YusuiAI : SkillEvent
    {
        public YusuiAI() : base("yusui") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (ai.WillShowForAttack() && data is Player target)
            {
                if (target.Alive && ai.IsEnemy(target) && player.Hp > 1)
                {
                    int count = Math.Min(target.HandcardNum, target.MaxHp);
                    if (count >= 3 || target.Hp - player.Hp - 1 >= 2) return true;
                }
            }
            return false;
        }
    }

    public class BoyanAI : SkillEvent
    {
        public BoyanAI() : base("boyan") { }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (ai.WillShowForAttack() && !player.HasUsed(BoyanCard.ClassName))
                return new List<WrappedCard> { new WrappedCard(BoyanCard.ClassName) { Skill = Name, ShowSkill = Name } };
            return new List<WrappedCard>();
        }
    }

    public class BoyanCardAI : UseCard
    {
        public BoyanCardAI() : base(BoyanCard.ClassName) { }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                foreach (Player p in use.To)
                {
                    if (!p.HasShownOneGeneral() && ai.IsKnown(player, p))
                    {
                        int count = p.MaxHp - p.HandcardNum;
                        if (count >= 2)
                            ai.UpdatePlayerRelation(player, p, true);
                        else if (count == 0)
                            ai.UpdatePlayerRelation(player, p, false);
                    }
                }
            }
        }
        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            List<Player> friends = ai.FriendNoSelf;
            if (friends.Count > 0)
            {
                int max = 0;
                foreach (Player p in friends)
                {
                    int count = p.MaxHp - p.HandcardNum;
                    if (count > max)
                        max = count;
                }

                foreach (Player p in friends)
                {
                    int count = p.MaxHp - p.HandcardNum;
                    if (count == max)
                    {
                        use.Card = card;
                        use.To.Add(p);
                        return;
                    }
                }
            }

            List<Player> enemies = ai.GetEnemies(player);
            if (enemies.Count > 0)
            {
                ai.SortByDefense(ref enemies, false);
                foreach (Player p in enemies)
                {
                    int count = Math.Min(5 - p.HandcardNum, p.MaxHp - p.HandcardNum);
                    if (count == 0)
                    {
                        use.Card = card;
                        use.To.Add(p);
                        return;
                    }
                }
            }
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 3.7;
    }

    public class BoyanSAI : SkillEvent
    {
        public BoyanSAI() : base("boyan_strategy") { }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (ai.WillShowForAttack() && !player.HasUsed(BoyanSCard.ClassName))
                return new List<WrappedCard> { new WrappedCard(BoyanSCard.ClassName) { Skill = Name } };
            return new List<WrappedCard>();
        }
    }

    public class BoyanSCardAI : UseCard
    {
        public BoyanSCardAI() : base(BoyanSCard.ClassName) { }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                foreach (Player p in use.To)
                    ai.UpdatePlayerRelation(player, p, false);
            }
        }
        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            List<Player> enemies = ai.GetEnemies(player);
            if (enemies.Count > 0)
            {
                ai.SortByDefense(ref enemies, false);
                use.Card = card;
                use.To.Add(enemies[0]);
            }
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 4;
    }


    public class ShejianHegemonyAI : SkillEvent
    {
        public ShejianHegemonyAI() : base("shejian_hegemony") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            if (data is string str && player.HandcardNum == 1)
            {
                Room room = ai.Room;
                string[] strs = str.Split(':');
                Player target = room.FindPlayer(strs[0]);
                if (ai.IsEnemy(target) && ai.GetDamageScore(new DamageStruct(Name, player, target)).Score > 3)
                    return true;
            }
            return false;
        }
    }

    public class FenglueHegemonyAI : SkillEvent
    {
        public FenglueHegemonyAI() : base("fenglue_hegemony") { }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if ( ai.WillShowForAttack() && !player.HasUsed(FenglueCard.ClassName) && !player.IsKongcheng())
            {
                if (ai.GetMaxCard().Number >= 11)
                    return new List<WrappedCard> { new WrappedCard(FenglueCard.ClassName) { Skill = Name, ShowSkill = Name } };
            }
            return new List<WrappedCard>();
        }
        public override WrappedCard OnPindian(TrustedAI ai, Player requestor, List<Player> players) => ai.GetMaxCard();
        public override List<int> OnExchange(TrustedAI ai, Player player, string pattern, int min, int max, string pile)
        {
            List<int> ids = new List<int>();
            if (player.HasFlag(Name))
            {
                List<int> judges = player.GetCards("j");
                for (int i = 0; i < Math.Min(judges.Count, 2); i++)
                    ids.Add(judges[i]);

                if (ids.Count < 2)
                {
                    List<int> cards = player.GetCards("he");
                    ai.SortByKeepValue(ref cards, false);
                    for (int i = 0; i < 2 - judges.Count; i++)
                        ids.Add(cards[i]);
                }
            }
            else
            {
                List<int> cards = player.GetCards("he");
                ai.SortByKeepValue(ref cards, false);
                ids.Add(cards[0]);
            }
            return ids;
        }
    }

    public class FenglueCardAI : UseCard
    {
        public FenglueCardAI() : base(FenglueCard.ClassName) { }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                foreach (Player p in use.To)
                    ai.UpdatePlayerRelation(player, p, false);
            }
        }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            List<Player> enemies = ai.GetEnemies(player);
            if (enemies.Count > 0)
            {
                ai.SortByDefense(ref enemies, false);
                foreach (Player p in enemies)
                {
                    if (!p.IsKongcheng() && RoomLogic.CanBePindianBy(ai.Room, p, player))
                    {
                        use.Card = card;
                        use.To.Add(p);
                        return;
                    }
                }
            }
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 3.6;
    }

    public class FenglueSAI : SkillEvent
    {
        public FenglueSAI() : base("fenglue_strategy") { }
        public override List<WrappedCard> GetTurnUse(TrustedAI ai, Player player)
        {
            if (!player.HasUsed(FenglueSCard.ClassName) && !player.IsKongcheng())
            {
                if (ai.GetMaxCard().Number >= 12)
                    return new List<WrappedCard> { new WrappedCard(FenglueSCard.ClassName) { Skill = Name } };
            }
            return new List<WrappedCard>();
        }
        public override WrappedCard OnPindian(TrustedAI ai, Player requestor, List<Player> players) => ai.GetMaxCard();
        public override List<int> OnExchange(TrustedAI ai, Player player, string pattern, int min, int max, string pile)
        {
            List<int> ids = new List<int>();
            if (player.HasFlag(Name))
            {
                List<int> judges = player.GetCards("j");
                if (judges.Count > 0) return new List<int> { judges[0] };

                List<int> cards = player.GetCards("he");
                ai.SortByKeepValue(ref cards, false);
                return new List<int> { cards[0] };
            }
            else
            {
                List<int> cards = player.GetCards("he");
                ai.SortByKeepValue(ref cards, false);
                for (int i = 0; i < Math.Min(cards.Count, 2); i++)
                    ids.Add(cards[i]);
            }
            return ids;
        }
    }

    public class FenglueSCardAI : UseCard
    {
        public FenglueSCardAI() : base(FenglueSCard.ClassName) { }
        public override void OnEvent(TrustedAI ai, TriggerEvent triggerEvent, Player player, object data)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                foreach (Player p in use.To)
                    ai.UpdatePlayerRelation(player, p, false);
            }
        }

        public override void Use(TrustedAI ai, Player player, ref CardUseStruct use, WrappedCard card)
        {
            List<Player> enemies = ai.GetEnemies(player);
            if (enemies.Count > 0)
            {
                ai.SortByDefense(ref enemies, false);
                foreach (Player p in enemies)
                {
                    if (!p.IsKongcheng() && RoomLogic.CanBePindianBy(ai.Room, p, player))
                    {
                        use.Card = card;
                        use.To.Add(p);
                        return;
                    }
                }
            }
        }

        public override double UsePriorityAdjust(TrustedAI ai, Player player, List<Player> targets, WrappedCard card) => 3.6;
    }

    public class AnyongAI : SkillEvent
    {
        public AnyongAI() : base("anyong") { }
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data)
        {
            Room room = ai.Room;
            if (room.GetTag(Name) is DamageStruct damage && ai.IsEnemy(damage.To) && !ai.HasArmorEffect(damage.To, SilverLion.ClassName))
            {
                DamageStruct _damage = new DamageStruct(damage.Card, damage.From, damage.To, damage.Damage * 2, damage.Nature);
                if (ai.GetDamageScore(_damage).Score - ai.GetDamageScore(damage).Score > 4)
                    return true;
            }
            return false;
        }
    }
}