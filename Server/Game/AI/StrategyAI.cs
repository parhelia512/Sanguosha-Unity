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


                new ZhiweiAI(),
                new ZhenteAI(),


                new ShejianHegemonyAI(),
            };

            use_cards = new List<UseCard>
            {
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
        public override bool OnSkillInvoke(TrustedAI ai, Player player, object data) => true;
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

}