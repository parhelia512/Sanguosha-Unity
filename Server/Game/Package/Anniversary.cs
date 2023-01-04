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
    public class Anniversary : GeneralPackage
    {
        public Anniversary() : base("Anniversary")
        {
            skills = new List<Skill>
            {
                new Yanjiao(),
                new YanjiaoMax(),
                new Xingshen(),
                new Andong(),
                new AndongMax(),
                new Yingshi(),
                new YingshiTag(),
                new Sanwen(),
                new Qiai(),
                new Denglou(),
                new Lvli(),
                new Choujue(),
                new Beishui(),
                new Qingjiao(),
                new QingjiaoThrow(),
                new QianxinZG(),
                new QianxinEffect(),
                new QianxinMax(),
                new Zhenxing(),
                new Tuiyan(),
                new Busuan(),
                new BusuanDraw(),
                new Mingjie(),
                new Weilu(),
                new Zengdao(),
                new ZengdaoDamage(),
                new Chijie(),
                new ChijieEffect(),
                new Yinju(),
                new YinjuEffect(),
                new ZhuilieTar(),
                new Zhuilie(),
                new Pianchong(),
                new PianchongDraw(),
                new Zunwei(),
                new Lilu(),
                new YizhengCS(),
                new YizhengCSEffect(),
                new Liedan(),
                new Zhuangdan(),
                new Cuijian(),
                new Tongyuan(),
                new Xianwei(),
                new XianweiDis(),
                new YisheDFR(),
                new YisheDFREffect(),
                new Shunshi(),
                new ShunshiTar(),
                new ShunshiDraw(),
                new ShunshiMax(),
                new Yuqi(),
                new Shanshen(),
                new Xianjing(),
                new Xingzuo(),
                new Miaoxian(),
                new Qianlong(),
                new Fensi(),
                new Juetao(),
                new JuetaoPro(),
                new JuetaoTag(),
                new Zhushi(),
                new Choutao(),
                new Xiangshu(),
                new Caiyi(),
                new Guili(),
                new Deshao(),
                new Mingfa(),
                new Fuping(),
                new FupingTar(),
                new Weilie(),
                new Poyuan(),
                new Huace(),
                new Fenyan(),
                new Fudao(),
                new FudaoPro(),

                new Tunan(),
                new TunanTag(),
                new Bijing(),
                new BijingDiscard(),
                new Tianjiang(),
                new Zhuren(),
                new Manyi(),
                new Mansi(),
                new Souying(),
                new Zhanyuan(),
                new Xili(),
                new Youyan(),
                new Zhuihuan(),
                new ZhuihuanEffect(),
                new Bazhan(),
                new Jiaoying(),
                new Huguan(),
                new HuguanMax(),
                new Yaopei(),
                new Mingluan(),
                new Jianliang(),
                new Weimeng(),
                new Zhubi(),
                new Liuzhuan(),
                new LiuzhuanPro(),
                new Quanjian(),
                new QuanjianEffect(),
                new QuanjianPro(),
                new Tujue(),

                new Jiedao(),
                new JiedaoDis(),
                new Kannan(),
                new KannanDamage(),
                new Jixu(),
                new JixuTar(),
                new Jijun(),
                new Fangtong(),
                new Lixun(),
                new KuizhuLS(),
                new Fenyue(),
                new Xuhe(),
                new Mouzhu(),
                new Yujue(),
                new Tuxin(),
                new Zhihu(),
                new Niluan(),
                new Weiwu(),
                new WeiwuProhibi(),
                new Gongjian(),
                new GongjianRecord(),
                new Kuimang(),
                new Cixiao(),
                new Panshi(),
                new Xianshuai(),
                new XianshuaiRecord(),
                new JieyingHF(),
                new JieyingHFPro(),
                new JieyingHFTar(),
                new Weipo(),
                new Minsi(),
                new MinsiTar(),
                new MinsiMax(),
                new Jijing(),
                new Zhuide(),
                new Shiyuan(),
                new Dushi(),
                new DushiPro(),
                new Yuwei(),
                new CangchuClassic(),
                new CangchuMax(),
                new LiangyingClassic(),
                new Shishou(),
                new Yangzhong(),
                new Huangkong(),
                new YixiangSP(),
                new YirangSP(),
                new Mouni(),
                new Zongfan(),
                new Zhangu(),
                new Lulue(),
                new Zhuixi(),
                new Kangge(),
                new Jielie(),
                new Langmie(),
                new Koulue(),
                new Suiren(),
                new QingchengC(),
                new HuoshuiC(),
                new HuoshuiInvalid(),
                new Guowu(),
                new GuowuTar(),
                new Zhuangrong(),
                new Shenwei(),
                new ShenweiMax(),
                new Chaofeng(),
                new Chuanshu(),
                new Chuanyun(),
                new Zhenge(),
                new ZhengeRange(),
                new Xinghan(),
                new Tianze(),
                new Difa(),
                new Xuezhao(),
                new XuezhaoEffect(),
                new XuezhaoTar(),
                new Wangzhu(),
                new Yingshui(),
                new Fuyuan(),
                new Heqia(),
                new Yinni(),
                new Channi(),
                new Nifu(),
                new Tiqi(),
                new TiqiMax(),
                new Baoshu(),
                new BaoshuDraw(),
                new Xiaowu(),
                new Huaping(),
                new Shawu(),
                new Bingjie(),
                new BingjieEffect(),
                new Zhengding(),
                new Jiezhen(),
                new Zhecai(),
                new YinshiHCY(),
                new Shuizheng(),
                new ShuizhengTar(),
                new Yijiao(),
                new YijiaoEffect(),
                new Qibie(),
                new Xunli(),
                new Zhishi(),
                new Lieyi(),
                new Jinggong(),
                new JinggongDamage(),
                new Xiaojun(),
                new Piaoping(),
                new Tuoxian(),
                new Zhuili(),
                new Xiaoxi(),
                new Xiongrao(),
                new XiongraoInvalid(),
                new Geyuan(),
                new Jieshu(),
                new JieshuMax(),
                new Gusuan(),
                new Yingtu(),
                new Congshi(),
                new Suoliang(),
                new Qinbao(),

                new Guolun(),
                new Songsang(),
                new Zhanji(),
                new Guanwei(),
                new Gongqing(),
                new Qinguo(),
                new QinguoRecover(),
                new Youdi(),
                new Duanfa(),
                new Biaozhao(),
                new BiaozhaoEffect(),
                new Yechou(),
                new YechouLose(),
                new Guanchao(),
                new GuanchaoRecord(),
                new Xunxian(),
                new Fuhai(),
                new Lianhua(),
                new Zhafu(),
                new ZhafuEffect(),
                new Songshu(),
                new Sibian(),
                new FenyinOl(),
                new FenyinOlRecord(),
                new Liji(),
                new Zhiren(),
                new Yaner(),
                new Zhukou(),
                new Mangqing(),
                new Yuyun(),
                new YuyunTar(),
                new YuyunMax(),
                new Jinghui(),
                new Qingman(),
                new JiqiaoSY(),
                new XiongyiSy(),
                new YusuiClassic(),
                new BoyanClassic(),
                new Renzheng(),
                new Jinjian(),
                new JinjianFlag(),
                new JinjianEffect(),
                new Chongxing(),
                new ChongxingEffect(),
                new Liunian(),
                new LiunianMax(),
                new YuanyuZY(),
                new YuanyuZYEffect(),
                new Xiyan(),
                new XiyanMax(),
                new XiyanTar(),
                new XiyanPro(),
                new Chenjian(),
                new Xixiu(),
                new XixiuFix(),
                new Tongli(),
                new TongliEffect(),
                new Shezhang(),
                new Xiecui(),
                new XiecuiMax(),
                new Youxu(),
                new Wanglu(),
                new Xianzhu(),
                new Chaixie(),
                new Huishu(),
                new HuishuEffect(),
                new Yishu(),
                new Ligong(),
            };

            skill_cards = new List<FunctionCard>
            {
                new GuolunCard(),
                new KannanCard(),
                new DuanfaCard(),
                new YanjiaoCard(),
                new TunanCard(),
                new JixuCard(),
                new FuhaiCard(),
                new ZhafuCard(),
                new BusuanCard(),
                new QianxinZGCard(),
                new ZengdaoCard(),
                new TianjiangCard(),
                new ZhurenCard(),
                new YinjuCard(),
                new SongshuCard(),
                new FenyueCard(),
                new LijiCard(),
                new MouzhuCard(),
                new YujueCard(),
                new CixiaoCard(),
                new MinsiCard(),
                new JijingCard(),
                new ZunweiCard(),
                new LiangyingClassicCard(),
                new LiluCard(),
                new ZongfanCard(),
                new CuijianCard(),
                new QingchengCCard(),
                new ShunshiCard(),
                new BazhanCard(),
                new ZhukouCard(),
                new XuezhaoCard(),
                new YingshuiCard(),
                new YaopeiCard(),
                new HeqiaCard(),
                new JinghuiCard(),
                new ChanniCard(),
                new WeimengCard(),
                new BoyanCCard(),
                new XiaowuCard(),
                new ShawuCard(),
                new YuanyuZYCard(),
                new ChenjianCard(),
                new YijiaoCard(),
                new LieyiCard(),
                new YingshiCard(),
                new WeilieCard(),
                new QuanjianCard(),
                new FenyanCard(),
            };

            related_skills = new Dictionary<string, List<string>>
            {
                { "jiedao", new List<string>{ "#jiedao" } },
                { "kannan", new List<string>{ "#kannan" } },
                { "yanjiao", new List<string>{ "#yanjiao" } },
                { "qinguo", new List<string>{ "#qinguo" } },
                { "bijing", new List<string>{ "#bijing" } },
                { "tunan", new List<string>{ "#tunan" } },
                { "andong", new List<string>{ "#andong" } },
                { "yingshi", new List<string>{ "#yingshi" } },
                { "biaozhao", new List<string>{ "#biaozhao" } },
                { "yechou", new List<string>{ "#yechou" } },
                { "guanchao", new List<string>{ "#guanchao" } },
                { "qingjiao", new List<string>{ "#qingjiao" } },
                { "zhafu", new List<string>{ "#zhafu" } },
                { "busuan", new List<string>{ "#busuan" } },
                { "zengdao", new List<string>{ "#zengdao" } },
                { "qianxin_zg", new List<string>{ "#qianxin_zg" } },
                { "chijie", new List<string>{ "#chijie" } },
                { "yinju", new List<string>{ "#yinju" } },
                { "zhuilie", new List<string>{ "#zhuilie" } },
                { "fenyin_ol", new List<string>{ "#fenyin_ol" } },
                { "weiwu", new List<string>{ "#weiwu" } },
                { "gongjian", new List<string>{ "#gongjian" } },
                { "xianshuai", new List<string>{ "#xianshuai" } },
                { "jieying_hf", new List<string>{ "#jieying_hf-tar", "#jieying_hf-pro" } },
                { "minsi", new List<string>{ "#minsi-tar", "#minsi-max" } },
                { "dushi", new List<string>{ "#dushi" } },
                { "pianchong", new List<string>{ "#pianchong" } },
                { "cangchu_classic", new List<string>{ "#cangchu" } },
                { "yizheng_cs", new List<string>{ "#yizheng_cs" } },
                { "zhuihuan", new List<string>{ "#zhuihuan" } },
                { "huoshui_classic", new List<string>{ "#huoshui_classic" } },
                { "xianwei", new List<string>{ "#xianwei" } },
                { "yishe_dfr", new List<string>{ "#yishe_dfr" } },
                { "shunshi", new List<string>{ "#shunshi-draw", "#shunshi-tar", "#shunshi-max" } },
                { "yuyun", new List<string>{ "#yuyun-tar", "#yuyun-max" } },
                { "guowu", new List<string>{ "#guowu" } },
                { "shenwei", new List<string>{ "#shenwei" } },
                { "zhenge", new List<string>{ "#zhenge" } },
                { "xuezhao", new List<string>{ "#xuezhao", "#xuezhao-effect" } },
                { "huguan", new List<string>{ "#huguan" } },
                { "tiqi", new List<string>{ "#tiqi" } },
                { "baoshu", new List<string>{ "#baoshu" } },
                { "juetao", new List<string>{ "#juetao", "#juetao-tar" } },
                { "bingjie", new List<string>{ "#bingjie" } },
                { "jinjian", new List<string>{ "#jinjian", "#jinjian-flag" } },
                { "chongxing", new List<string>{ "#chongxing" } },
                { "liunian", new List<string>{ "#liunian" } },
                { "yuanyu_zy", new List<string>{ "#yuanyu_zy" } },
                { "xiyan", new List<string>{ "#xiyan", "#xiyan-tar", "#xiyan-pro" } },
                { "shuizheng", new List<string>{ "#shuizheng" } },
                { "xixiu", new List<string>{ "#xixiu" } },
                { "yijiao", new List<string>{ "#yijiao" } },
                { "jinggong", new List<string>{ "#jinggong" } },
                { "liuzhuan", new List<string>{ "#liuzhuan" } },
                { "fuping", new List<string>{ "#fuping" } },
                { "tongli", new List<string>{ "#tongli" } },
                { "xiecui", new List<string>{ "#xiecui" } },
                { "jixu", new List<string>{ "#jixu" } },
                { "quanjian", new List<string>{ "#quanjian", "#quanjian-pro" } },
                { "xiongrao", new List<string>{ "#xiongrao" } },
                { "jieshu", new List<string>{ "#jieshu" } },
                { "huishu", new List<string>{ "#huishu" } },
                { "fudao", new List<string>{ "#fudao" } },
            };
        }
    }

    public class Yanjiao : TriggerSkill
    {
        public Yanjiao() : base("yanjiao")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging };
            view_as_skill = new YanjiaoVS();
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
        public override bool SortFilter(Room room, List<int> to_sorts, List<int> ups, List<int> downs)
        {
            int up = 0, down = 0;
            foreach (int id in ups)
                up += room.GetCard(id).Number;

            foreach (int id in downs)
                down += room.GetCard(id).Number;

            return up == down;
        }
    }

    public class YanjiaoVS : ZeroCardViewAsSkill
    {
        public YanjiaoVS() : base("yanjiao")
        {
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.HasUsed(YanjiaoCard.ClassName);
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(YanjiaoCard.ClassName) { Skill = Name };
        }
    }

    public class YanjiaoCard : SkillCard
    {
        public static string ClassName = "YanjiaoCard";
        public YanjiaoCard() : base(ClassName)
        {
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && to_select != Self;
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            int count = 4 + player.GetMark("xingshen");
            player.SetMark("xingshen", 0);
            room.RemovePlayerStringMark(player, "xingshen");

            List<int> card_ids = room.GetNCards(count);
            foreach (int id in card_ids)
            {
                room.MoveCardTo(room.GetCard(id), player, Place.PlaceTable, new CardMoveReason(MoveReason.S_REASON_TURNOVER, player.Name, "yanjiao", null), false);
                Thread.Sleep(400);
            }
            AskForMoveCardsStruct result = room.AskforSortCards(target, "yanjiao", card_ids, true, card_use.Card.SkillPosition);
            List<CardsMoveStruct> moves = new List<CardsMoveStruct>();
            if (result.Success)
            {
                card_ids.RemoveAll(t => result.Top.Contains(t));
                card_ids.RemoveAll(t => result.Bottom.Contains(t));

                if (result.Bottom.Count > 0 && result.Top.Count > 0)
                {
                    moves.Add(new CardsMoveStruct(result.Bottom, target, Place.PlaceHand, new CardMoveReason(MoveReason.S_REASON_GOTBACK, target.Name, "yanjiao", null)));
                    moves.Add(new CardsMoveStruct(result.Top, player, Place.PlaceHand, new CardMoveReason(MoveReason.S_REASON_GOTBACK, player.Name, "yanjiao", null)));

                }
            }

            if (card_ids.Count > 0)
            {
                moves.Add(new CardsMoveStruct(card_ids, null, Place.DiscardPile, new CardMoveReason(MoveReason.S_REASON_NATURAL_ENTER, null, "yanjiao", null)));
                if (card_ids.Count > 1) player.AddMark("yanjiao");
            }
            room.MoveCards(moves, true);
        }
    }

    public class YanjiaoMax : MaxCardsSkill
    {
        public YanjiaoMax() : base("#yanjiao") { }
        public override int GetExtra(Room room, Player target)
        {
            return -target.GetMark("yanjiao");
        }
    }

    public class Xingshen : MasochismSkill
    {
        public Xingshen() : base("xingshen") { }

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
            int draw = 1;
            if (Shuffle.random(1, 2)) draw = 2;
            room.DrawCards(target, draw, Name);

            int mark = target.GetMark(Name);
            mark += target.GetLostHp();
            mark = Math.Min(6, mark);
            target.SetMark(Name, mark);
            room.SetPlayerStringMark(target, Name, mark.ToString());
        }
    }

    public class Andong : TriggerSkill
    {
        public Andong() : base("andong")
        {
            events.Add(TriggerEvent.DamageDefined);
            skill_type = SkillType.Defense;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is DamageStruct damage && damage.From != null && damage.From != player && damage.From.Alive && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                room.SetTag(Name, data);
                bool invoke = room.AskForSkillInvoke(player, Name, damage.From, info.SkillPosition);
                room.RemoveTag(Name);

                if (invoke)
                {
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, damage.From.Name);
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
                Player chooser = damage.From;
                List<string> desc = new List<string>
                {
                    string.Format("@andong:{0}", player.Name),
                    "@andong-prevent",
                    "@andong-view",
                };
                if (player.GetMark(Name) > 0)
                {
                    chooser = player;
                    player.SetMark(Name, 0);

                    desc = new List<string> { "@to-player:" + damage.From.Name, "@andong-prevent2", "@andong-view2" };
                }

                List<string> choices = new List<string> { "prevent", "view" };
                if (chooser == player && damage.From.IsKongcheng())
                {
                    choices.Remove("view");
                    desc.Remove("@andong-view2");
                }

                string choice = room.AskForChoice(chooser, Name, string.Join("+", choices), desc, data, info.SkillPosition);
                if (choice == "prevent")
                {
                    if (damage.From.Phase != PlayerPhase.NotActive) damage.From.SetFlags(Name);
                    LogMessage log = new LogMessage
                    {
                        Type = "#damaged-prevent",
                        From = player.Name,
                        Arg = Name
                    };
                    room.SendLog(log);
                    return true;
                }
                else
                {
                    if (!damage.From.IsKongcheng())
                    {
                        room.ShowAllCards(damage.From, player, Name);
                        List<int> ids = new List<int>();
                        foreach (int id in damage.From.GetCards("h"))
                        {
                            if (room.GetCard(id).Suit == WrappedCard.CardSuit.Heart && RoomLogic.CanGetCard(room, player, damage.From, id))
                                ids.Add(id);
                        }
                        if (ids.Count > 0)
                            room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_EXTRACTION, player.Name, damage.From.Name, Name, string.Empty));
                    }
                    else
                        player.AddMark(Name);
                }
            }

            return false;
        }
    }

    public class AndongMax : MaxCardsSkill
    {
        public AndongMax() : base("#andong") { }
        public override bool Ingnore(Room room, Player player, int card_id)
        {
            return player.HasFlag("andong") && room.GetCard(card_id).Suit == WrappedCard.CardSuit.Heart;
        }
    }

    public class Yingshi : TriggerSkill
    {
        public Yingshi() : base("yingshi")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.CardUsedAnnounced, TriggerEvent.Damage };
            skill_type = SkillType.Attack;
            view_as_skill = new YingshiVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardUsedAnnounced && data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName) && use.Pattern == "Slash:yingshi")
                use.Card.SetFlags(Name);
            else if (triggerEvent == TriggerEvent.Damage && data is DamageStruct damage && damage.From != null && damage.Card != null && damage.Card.HasFlag(Name))
                damage.From.SetFlags(Name);
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Play && base.Triggerable(player, room) && !player.IsKongcheng())
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.AskForUseCard(player, RespondType.Skill, "@@yingshi", "@yingshi", null, -1, HandlingMethod.MethodUse, true, info.SkillPosition);
            return new TriggerStruct();
        }
    }
    
    public class YingshiVS : OneCardViewAsSkill
    {
        public YingshiVS() : base("yingshi")
        {
            response_pattern = "@@yingshi";
            filter_pattern = ".";
        }

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard ys = new WrappedCard(YingshiCard.ClassName) { Skill = Name };
            ys.AddSubCard(card);
            return ys;
        }
    }

    public class YingshiCard : SkillCard
    {
        public static string ClassName = "YingshiCard";
        public YingshiCard() : base(ClassName) { will_throw = false; }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            WrappedCard slash = new WrappedCard(Slash.ClassName);
            if (targets.Count == 0)
            {
                if (RoomLogic.IsCardLimited(room, to_select, slash, HandlingMethod.MethodUse)) return false;
            }
            else if (targets.Count == 1)
            {
                if (to_select == Self || RoomLogic.IsProhibited(room, targets[0], to_select, slash) != null) return false;
            }

            return targets.Count < 2;
        }
        public override bool TargetsFeasible(Room room, List<Player> targets, Player Self, WrappedCard card) => targets.Count == 2;
        public override void OnUse(Room room, CardUseStruct card_use)
        {
            Player diaochan = card_use.From;

            object data = card_use;
            RoomThread thread = room.RoomThread;

            thread.Trigger(TriggerEvent.PreCardUsed, room, diaochan, ref data);
            room.BroadcastSkillInvoke("yingshi", diaochan, card_use.Card.SkillPosition);

            CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_SHOW, diaochan.Name, null, "yingshi", null)
            {
                General = RoomLogic.GetGeneralSkin(room, diaochan, Name, card_use.Card.SkillPosition)
            };
            room.MoveCardTo(card_use.Card, diaochan, null, Place.PlaceTable, reason, true);

            LogMessage log = new LogMessage
            {
                From = diaochan.Name,
                To = new List<string>(),
                Type = "#UseCard",
                Card_str = RoomLogic.CardToString(room, card_use.Card)
            };
            log.To.Add(card_use.To[0].Name);
            room.SendLog(log);

            List<string> show_arg = new List<string> { diaochan.Name, JsonUntity.Object2Json(new List<int> { card_use.Card.GetEffectiveId() } ), "yingshi" };
            room.DoBroadcastNotify(CommandType.S_COMMAND_SHOW_CARD, show_arg);

            thread.Trigger(TriggerEvent.CardUsedAnnounced, room, diaochan, ref data);
            thread.Trigger(TriggerEvent.CardTargetAnnounced, room, diaochan, ref data);
            thread.Trigger(TriggerEvent.CardUsed, room, diaochan, ref data);
            thread.Trigger(TriggerEvent.CardFinished, room, diaochan, ref data);
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player from = card_use.To[0];
            Player to = card_use.To[1];
            room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, from.Name, to.Name);
            from.SetFlags("slashTargetFix");
            to.SetFlags("SlashAssignee");

            from.SetFlags("yingshi_slasher");
            WrappedCard used = room.AskForUseCard(from, RespondType.Slash, "Slash:yingshi", string.Format("@yingshi-slash:{0}:{1}", card_use.From.Name, to.Name),
                null, -1, HandlingMethod.MethodUse, false, card_use.Card.SkillPosition);
            from.SetFlags("-yingshi_slasher");
            bool discard = true;
            if (used == null)
            {
                from.SetFlags("-slashTargetFix");
                to.SetFlags("-SlashAssignee");
            }
            else
            {
                if (from.Alive)
                {
                    discard = false;
                    WrappedCard card = room.GetCard(card_use.Card.GetEffectiveId());
                    WrappedCard.CardSuit suit = card.Suit;
                    int number = card.Number;
                    room.ObtainCard(from, card, new CardMoveReason(MoveReason.S_REASON_RECYCLE, card_use.From.Name, from.Name, "yingshi", string.Empty));
                    if (from.Alive && from.HasFlag("yingshi"))
                    {
                        from.SetFlags("-yingshi");
                        List<int> ids = new List<int>();
                        foreach (int id in room.DrawPile)
                        {
                            WrappedCard wrapped = room.GetCard(id);
                            if (wrapped.Suit == suit && wrapped.Number == number)
                                ids.Add(id);
                        }

                        if (ids.Count > 0)
                            room.ObtainCard(from, ref ids, new CardMoveReason(MoveReason.S_REASON_GOTCARD, card_use.From.Name, from.Name, "yingshi", string.Empty), true);
                    }
                }
            }
            if (discard)
            {
                WrappedCard card = room.GetCard(card_use.Card.GetEffectiveId());
                if (card_use.From.Alive)
                    room.ObtainCard(card_use.From, card, new CardMoveReason(MoveReason.S_REASON_RECYCLE, card_use.From.Name, from.Name, "yingshi", string.Empty));
                else
                    room.MoveCardTo(card, null, Place.DiscardPile, new CardMoveReason(MoveReason.S_REASON_NATURAL_ENTER, card_use.From.Name, "yingshi", string.Empty));
            }
        }
    }

    public class YingshiTag : TargetModSkill
    {
        public YingshiTag() : base("#yingshi", false) { }
        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            if (reason == CardUseReason.CARD_USE_REASON_RESPONSE_USE && to.HasFlag("SlashAssignee")
                && (room.GetRoomState().GetCurrentResponseSkill() == "yingshi" || pattern == "Slash:yingshi"))
                return true;

            return false;
        }
    }

    public class Sanwen : TriggerSkill
    {
        public Sanwen() : base("sanwen")
        {
            events.Add(TriggerEvent.CardsMoveOneTime);
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardsMoveOneTimeStruct move && move.To != null && move.To_place == Place.PlaceHand && base.Triggerable(move.To, room)
                && !move.To.IsKongcheng() && !move.To.HasFlag(Name))
            {
                foreach (int id in move.Card_ids)
                {
                    if (room.GetCardPlace(id) == Place.PlaceHand && room.GetCardOwner(id) == move.To)
                        return new TriggerStruct(Name, move.To);
                }
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move)
            {
                List<string> patterns = new List<string>();
                foreach (int id in move.Card_ids)
                {
                    WrappedCard card = room.GetCard(id);
                    string pattern = string.Format("{0}+^{1}|.|.|hand", card.Name.Contains(Slash.ClassName) ? Slash.ClassName : card.Name, id);
                    patterns.Add(pattern);
                }

                List<int> ids = room.AskForExchange(ask_who, Name, ask_who.GetCardCount(false), 0, "@sanwen", string.Empty, string.Join("#", patterns), info.SkillPosition);
                if (ids.Count > 0)
                {
                    room.NotifySkillInvoked(ask_who, Name);
                    room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                    room.ShowCards(ask_who, ids, Name);
                    room.SetTag(Name, ids);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            ask_who.SetFlags(Name);
            if (room.GetTag(Name) is List<int> ids && data is CardsMoveOneTimeStruct move)
            {
                room.RemoveTag(Name);
                List<string> patterns = new List<string>();
                foreach (int id in ids)
                {
                    WrappedCard card = room.GetCard(id);
                    string pattern = card.Name.Contains(Slash.ClassName) ? Slash.ClassName : card.Name;
                    if (!patterns.Contains(pattern))
                        patterns.Add(pattern);
                }
                List<int> discard = new List<int>();
                foreach (int id in move.Card_ids)
                {
                    WrappedCard card = room.GetCard(id);
                    string pattern = card.Name.Contains(Slash.ClassName) ? Slash.ClassName : card.Name;
                    if (patterns.Contains(pattern) && RoomLogic.CanDiscard(room, ask_who, ask_who, id))
                        discard.Add(id);
                }

                int count = discard.Count * 2;
                room.ThrowCard(ref discard,
                    new CardMoveReason(MoveReason.S_REASON_THROW, ask_who.Name, Name, string.Empty) { General = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition) },
                    ask_who);
                if (ask_who.Alive)
                    room.DrawCards(ask_who, count, Name);
            }

            return false;
        }
    }

    public class Qiai : TriggerSkill
    {
        public Qiai() : base("qiai")
        {
            frequency = Frequency.Limited;
            events.Add(TriggerEvent.Dying);
            limit_mark = "@qiai";
        }

        public override bool Triggerable(Player target, Room room)
        {
            if (base.Triggerable(target, room) && target.GetMark(limit_mark) > 0)
                foreach (Player p in room.GetOtherPlayers(target))
                    if (!p.IsNude())
                        return true;

            return false;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player pangtong, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(pangtong, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, pangtong, info.SkillPosition);
                room.DoSuperLightbox(pangtong, info.SkillPosition, Name);
                room.SetPlayerMark(pangtong, limit_mark, 0);
                return info;
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            player.SetFlags(Name);
            foreach (Player p in room.GetOtherPlayers(player))
            {
                if (p.Alive && !p.IsNude() && player.Alive)
                {
                    List<int> ids = room.AskForExchange(p, Name, 1, 1, "@qiai-give:" + player.Name, string.Empty, "..", string.Empty);
                    if (ids.Count > 0)
                        room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, p.Name, player.Name, Name, string.Empty), false);
                }
            }
            player.SetFlags("-qiai");

            return false;
        }
    }

    public class Denglou : TriggerSkill
    {
        public Denglou() : base("denglou")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            limit_mark = "@denglou";
            frequency = Frequency.Limited;
            view_as_skill = new DenglouVS();
        }

        public override bool Triggerable(Player target, Room room)
        {
            return base.Triggerable(target, room) && target.Phase == PlayerPhase.Finish && target.IsKongcheng() && target.GetMark(limit_mark) > 0;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player pangtong, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(pangtong, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, pangtong, info.SkillPosition);
                room.DoSuperLightbox(pangtong, info.SkillPosition, Name);
                room.SetPlayerMark(pangtong, limit_mark, 0);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<int> ids = room.GetNCards(4), get = new List<int>(), basic = new List<int>();
            foreach (int id in ids)
            {
                WrappedCard card = room.GetCard(id);
                FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                if (fcard is BasicCard)
                    basic.Add(id);
                else
                    get.Add(id);
            }
            if (get.Count > 0)
                room.ObtainCard(player, ref get, new CardMoveReason(MoveReason.S_REASON_DRAW, player.Name, Name, string.Empty), true);

            while (player.Alive && basic.Count > 0)
            {
                player.Piles["#denglou"] = new List<int>(basic);
                WrappedCard card = room.AskForUseCard(player, RespondType.Skill, "@@denglou", "@denglou-use", null, -1, HandlingMethod.MethodUse, true, info.SkillPosition);
                player.Piles["#denglou"].Clear();
                if (card != null)
                    basic.RemoveAll(t => card.SubCards.Contains(t));
                else
                    break;
            }
            if (basic.Count > 0)
            {
                CardsMoveStruct move = new CardsMoveStruct(basic, null, Place.DiscardPile, new CardMoveReason(MoveReason.S_REASON_NATURAL_ENTER, player.Name, Name, string.Empty));
                List<CardsMoveStruct> moves = new List<CardsMoveStruct> { move };
                room.MoveCardsAtomic(moves, true);
            }

            return false;
        }
    }

    public class DenglouVS : OneCardViewAsSkill
    {
        public DenglouVS() : base("denglou")
        {
            expand_pile = "#denglou";
            response_pattern = "@@denglou";
        }

        public override bool IsEnabledAtPlay(Room room, Player player) => false;
        public override bool ViewFilter(Room room, WrappedCard to_select, Player player)
        {
            FunctionCard fcard = Engine.GetFunctionCard(to_select.Name);
            return player.GetPile(expand_pile).Contains(to_select.Id) && fcard.IsAvailable(room, player, to_select);
        }

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player) => card;
    }

    public class Lvli : TriggerSkill
    {
        public Lvli() : base("lvli")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging, TriggerEvent.Damage, TriggerEvent.Damaged };
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                    if (p.GetMark(Name) > 0) p.SetMark(Name, 0);
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if ((triggerEvent == TriggerEvent.Damage || triggerEvent == TriggerEvent.Damaged)
                && base.Triggerable(player, room) && (player.GetMark(Name) == 0 || (player.GetMark(Name) < 2 && player.GetMark("choujue") == 1 && player == room.Current))
                && (player.HandcardNum < player.Hp || (player.Hp < player.HandcardNum && player.IsWounded())))
            {
                if (triggerEvent == TriggerEvent.Damaged && player.GetMark("beishui") == 1 || triggerEvent == TriggerEvent.Damage)
                    return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, null, info.SkillPosition))
            {
                player.AddMark(Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.HandcardNum < player.Hp)
            {
                int count = player.Hp - player.HandcardNum;
                room.DrawCards(player, count, Name);
            }
            else if (player.Hp < player.HandcardNum && player.IsWounded())
            {
                int max = Math.Min(player.HandcardNum, player.MaxHp);
                int count = max - player.Hp;
                room.Recover(player, count);
            }
            return false;
        }
    }

    public class Choujue : TriggerSkill
    {
        public Choujue() : base("choujue")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            frequency = Frequency.Wake;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (player.Phase == PlayerPhase.Finish)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    if (p.GetMark(Name) == 0 && Math.Abs(p.Hp - p.HandcardNum) >= 3)
                        triggers.Add(new TriggerStruct(Name, p));
            }

            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            room.DoSuperLightbox(ask_who, info.SkillPosition, Name);
            room.SetPlayerMark(ask_who, Name, 1);
            room.SendCompulsoryTriggerLog(ask_who, Name);

            room.LoseMaxHp(ask_who);
            if (ask_who.Alive)
                room.HandleAcquireDetachSkills(ask_who, "beishui", true);

            return false;
        }
    }

    public class Beishui : TriggerSkill
    {
        public Beishui() : base("beishui")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            frequency = Frequency.Wake;
        }

        public override bool Triggerable(Player target, Room room)
        {
            return base.Triggerable(target, room) && target.GetMark(Name) == 0 && (target.Hp < 2 || target.HandcardNum < 2) && target.Phase == PlayerPhase.Start;
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.DoSuperLightbox(player, info.SkillPosition, Name);
            room.SetPlayerMark(player, Name, 1);
            room.SendCompulsoryTriggerLog(player, Name);

            room.LoseMaxHp(player);
            if (player.Alive)
                room.HandleAcquireDetachSkills(player, "qingjiao", true);

            return false;
        }
    }

    public class Qingjiao : TriggerSkill
    {
        public Qingjiao() : base("qingjiao")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            skill_type = SkillType.Attack;
        }

        public override bool Triggerable(Player target, Room room)
        {
            if (base.Triggerable(target, room) && target.Phase == PlayerPhase.Play && target.HandcardNum > 0)
            {
                bool discard = true;
                foreach (int id in target.GetCards("h"))
                {
                    if (!RoomLogic.CanDiscard(room, target, target, id))
                    {
                        discard = false;
                        break;
                    }
                }
                return discard;
            }
            return false;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, null, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.ThrowAllHandCards(player);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<string> names = new List<string>();
            bool slash = false, jink = false, peach = false, ana = false, weapon = false, armor = false, oh = false, dh = false, treasure = false;
            List<int> ids = new List<int>(room.DiscardPile);
            ids.AddRange(room.DrawPile);

            Shuffle.shuffle(ref ids);

            List<int> get = new List<int>();
            foreach (int id in ids)
            {
                WrappedCard card = room.GetCard(id);
                FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                if (!slash && fcard is Slash)
                {
                    get.Add(id);
                    slash = true;
                }
                else if (!jink && fcard is Jink)
                {
                    get.Add(id);
                    jink = true;
                }
                else if (!peach && fcard is Peach)
                {
                    get.Add(id);
                    peach = true;
                }
                else if (!ana && fcard is Analeptic)
                {
                    get.Add(id);
                    ana = true;
                }
                else if (!dh && fcard is DefensiveHorse)
                {
                    get.Add(id);
                    dh = true;
                }
                else if (!weapon && fcard is Weapon)
                {
                    get.Add(id);
                    weapon = true;
                }
                else if (!armor && fcard is Armor)
                {
                    get.Add(id);
                    armor = true;
                }
                else if (!oh && fcard is OffensiveHorse)
                {
                    get.Add(id);
                    oh = true;
                }
                else if (!treasure && fcard is Treasure)
                {
                    get.Add(id);
                    treasure = true;
                }
                else if (fcard is TrickCard && !names.Contains(card.Name))
                {
                    get.Add(id);
                    names.Add(card.Name);
                }

                if (get.Count >= 8)
                    break;
            }

            if (get.Count > 0)
            {
                player.SetFlags(Name);
                room.ObtainCard(player, ref get, new CardMoveReason(MoveReason.S_REASON_GOTCARD, player.Name, Name, string.Empty));
            }

            return false;
        }
    }

    public class QingjiaoThrow : TriggerSkill
    {
        public QingjiaoThrow() : base("#qingjiao")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            frequency = Frequency.Compulsory;
        }

        public override bool Triggerable(Player target, Room room)
        {
            return base.Triggerable(target, room) && target.Phase == PlayerPhase.Finish && !target.IsNude() && target.HasFlag("qingjiao");
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.ThrowAllHandCardsAndEquips(player);
            return false;
        }
    }

    public class QianxinZG : ViewAsSkill
    {
        public QianxinZG() : base("qianxin_zg")
        {
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.IsKongcheng() && !player.HasUsed(QianxinZGCard.ClassName) && !player.ContainsTag(Name);
        }

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            return room.GetCardPlace(to_select.Id) == Place.PlaceHand;
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count > 0)
            {
                WrappedCard qx = new WrappedCard(QianxinZGCard.ClassName) { Skill = Name };
                qx.AddSubCards(cards);
                return qx;
            }
            return null;
        }
    }

    public class QianxinZGCard : SkillCard
    {
        public static string ClassName = "QianxinZGCard";
        public QianxinZGCard() : base(ClassName)
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
            player.SetTag("qianxin_zg", ids);
            foreach (Player p in room.GetAlivePlayers())
            {
                if (p.ContainsTag("qianxin_zg_from") && p.GetTag("qianxin_zg_from") is List<string> names && names.Contains(player.Name))
                {
                    names.Remove(player.Name);
                    if (names.Count == 0)
                        p.RemoveTag("qianxin_zg_from");
                    else
                        p.SetTag("qianxin_zg_from", names);
                }
            }

            List<string> froms = target.ContainsTag("qianxin_zg_from") ? (List<string>)target.GetTag("qianxin_zg_from") : new List<string>();
            froms.Add(player.Name);
            target.SetTag("qianxin_zg_from", froms);

            CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_PUT, player.Name, Name, string.Empty);
            CardsMoveStruct move = new CardsMoveStruct(ids, null, Place.PlaceUnknown, reason)
            {
                To_pile_name = string.Empty,
                From = player.Name
            };
            List<CardsMoveStruct> moves = new List<CardsMoveStruct> { move };
            room.MoveCardsAtomic(moves, false);

            for (int i = 0; i < ids.Count; i++)
            {
                int id = ids[i];
                room.SetCardMapping(id, null, Place.DrawPile);
                int index = room.AliveCount() * (i + 1) - 1;
                index = Math.Min(index, room.DrawPile.Count);
                room.DrawPile.Insert(index, id);
            }

            object data = room.DrawPile.Count;
            room.RoomThread.Trigger(TriggerEvent.DrawPileChanged, room, null, ref data);
            List<string> arg = new List<string>
            {
                room.DrawPile.Count.ToString()
            };
            room.DoBroadcastNotify(CommandType.S_COMMAND_UPDATE_PILE, arg);
        }
    }

    public class QianxinEffect : TriggerSkill
    {
        public QianxinEffect() : base("#qianxin_zg")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.CardsMoveOneTime };
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move)
            {
                if (move.From_places.Contains(Place.DrawPile))
                {
                    if (move.To != null && move.To_place == Place.PlaceHand && move.To == room.Current && move.To.ContainsTag("qianxin_zg_from")
                        && move.To.GetTag("qianxin_zg_from") is List<string> names)
                    {
                        Dictionary<string, List<int>> from_ids = move.To.ContainsTag("qianxin_zg_get")
                            ? (Dictionary<string, List<int>>)move.To.GetTag("qianxin_zg_get") : new Dictionary<string, List<int>>();
                        foreach (string general in names)
                        {
                            Player target = room.FindPlayer(general, true);
                            if (target.ContainsTag("qianxin_zg") && target.GetTag("qianxin_zg") is List<int> ids)
                            {
                                List<int> get = ids.FindAll(t => move.Card_ids.Contains(t));
                                if (get.Count > 0)
                                {
                                    if (from_ids.ContainsKey(target.Name))
                                        from_ids[target.Name].AddRange(get);
                                    else
                                        from_ids[target.Name] = get;
                                }
                            }
                        }
                        if (from_ids.Count > 0)
                            move.To.SetTag("qianxin_zg_get", from_ids);
                    }

                    foreach (Player p in room.GetAlivePlayers())
                    {
                        if (p.ContainsTag("qianxin_zg") && p.GetTag("qianxin_zg") is List<int> ids && ids.Find(t => move.Card_ids.Contains(t)) > 0)
                        {
                            ids.RemoveAll(t => move.Card_ids.Contains(t));
                            if (ids.Count > 0)
                                p.SetTag("qianxin_zg", ids);
                            else
                                p.RemoveTag("qianxin_zg");
                        }
                    }
                }
                else if (move.From_places.Contains(Place.PlaceHand) && move.From.ContainsTag("qianxin_zg_get") && move.From.GetTag("qianxin_zg_get") is Dictionary<string, List<int>> from_ids)
                {
                    List<string> keys = new List<string>(from_ids.Keys);
                    foreach (string key in keys)
                    {
                        from_ids[key].RemoveAll(t => move.Card_ids.Contains(t));
                    }
                    foreach (string key in keys)
                        if (from_ids[key].Count == 0) from_ids.Remove(key);

                    if (from_ids.Count > 0)
                        move.From.SetTag("qianxin_zg_get", from_ids);
                    else
                        move.From.RemoveTag("qianxin_zg_get");
                }
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Discard && player.ContainsTag("qianxin_zg_get"))
            {
                return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.GetTag("qianxin_zg_get") is Dictionary<string, List<int>> from_ids)
            {
                bool has = false;
                player.RemoveTag("qianxin_zg_get");
                List<Player> from = new List<Player>();
                foreach (string general in from_ids.Keys)
                {
                    if (from_ids[general].Find(t => player.GetCards("h").Contains(t)) > 0)
                    {
                        has = true;
                        Player target = room.FindPlayer(general);
                        if (target != null && target.HandcardNum < 4)
                            from.Add(target);
                    }
                }

                if (has)
                {
                    room.SetTag("qianxin_zg", from);
                    bool draw = false;
                    if (from.Count > 0 && room.AskForChoice(player, "qianxin_zg", "draw+max", null, from, info.SkillPosition) == "draw")
                    {
                        draw = true;
                        room.SortByActionOrder(ref from);
                        foreach (Player p in from)
                            if (p.Alive) room.DrawCards(p, new DrawCardStruct(4 - p.HandcardNum, player, "qianxin_zg"));
                    }
                    room.RemoveTag("qianxin_zg");

                    if (!draw)
                    {
                        player.SetFlags("qianxin_zg");
                        LogMessage log = new LogMessage
                        {
                            Type = "#qianxin_zg-less",
                            From = player.Name,
                            Arg = "qianxin_zg"
                        };
                        room.SendLog(log);
                    }
                }
            }

            return false;
        }
    }

    public class QianxinMax : MaxCardsSkill
    {
        public QianxinMax() : base("#qianxin-zg-max") { }
        public override int GetExtra(Room room, Player target)
        {
            return target.HasFlag("qianxin_zg") ? -2 : 0;
        }
    }
    public class Zhenxing : TriggerSkill
    {
        public Zhenxing() : base("zhenxing")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.Damaged };
            skill_type = SkillType.Wizzard;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Finish || triggerEvent == TriggerEvent.Damaged))
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
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int count = int.Parse(room.AskForChoice(player, Name, "1+2+3", new List<string> { "@zhenxing-view" }, null, info.SkillPosition));
            List<int> guanxing = room.GetNCards(count, false);
            if (count == 1)
                room.ObtainCard(player, ref guanxing, new CardMoveReason(MoveReason.S_REASON_GOTCARD, player.Name, Name, string.Empty), false);
            else
            {
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

                bool option = true;
                List<WrappedCard.CardSuit> suits = new List<WrappedCard.CardSuit>();
                foreach (int card in guanxing)
                    suits.Add(room.GetCard(card).Suit);
                foreach (int card in guanxing)
                {
                    if (suits.Count(t => t == room.GetCard(card).Suit) == 1)
                    {
                        option = false;
                        break;
                    }
                }

                room.SetTag(Name, guanxing);
                AskForMoveCardsStruct move = room.AskForMoveCards(player, guanxing, new List<int>(), false, Name, 1, 1, option, false, new List<int>(), info.SkillPosition);
                room.RemoveTag(Name);
                if (move.Success && move.Bottom.Count == 1)
                {
                    List<int> get = new List<int>(move.Bottom);
                    room.ObtainCard(player, ref get, new CardMoveReason(MoveReason.S_REASON_GOTCARD, player.Name, Name, string.Empty), false);
                }
            }

            return false;
        }
        public override bool MoveFilter(Room room, int id, List<int> downs)
        {
            if (id > -1 && room.ContainsTag(Name) && room.GetTag(Name) is List<int> ids)
            {
                List<WrappedCard.CardSuit> suits = new List<WrappedCard.CardSuit>();
                foreach (int card in ids)
                    suits.Add(room.GetCard(card).Suit);

                int count = suits.Count(t => t == room.GetCard(id).Suit);
                return count == 1;
            }

            return true;
        }
    }

    public class Tuiyan : TriggerSkill
    {
        public Tuiyan() : base("tuiyan")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            skill_type = SkillType.Wizzard;
        }

        public override bool Triggerable(Player target, Room room)
        {
            return base.Triggerable(target, room) && target.Phase == PlayerPhase.Play;
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

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<int> ids = room.GetNCards(3, false);

            LogMessage log = new LogMessage
            {
                Type = "$ViewDrawPile",
                From = player.Name,
                Card_str = string.Join("+", JsonUntity.IntList2StringList(ids))
            };
            room.SendLog(log, player);
            log.Type = "$ViewDrawPile2";
            log.Arg = ids.Count.ToString();
            log.Card_str = null;
            room.SendLog(log, new List<Player> { player });

            room.FillAG(Name, ids, player);
            room.AskForAG(player, new List<int>(), true, Name);
            room.ClearAG(player);

            return false;
        }
    }

    public class Busuan : ZeroCardViewAsSkill
    {
        public Busuan() : base("busuan") { }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.HasUsed(BusuanCard.ClassName);
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(BusuanCard.ClassName) { Skill = Name };
        }
    }

    public class BusuanCard : SkillCard
    {
        public static string ClassName = "BusuanCard";
        public BusuanCard() : base(ClassName) { }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card) => targets.Count == 0 && to_select != Self;

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            List<string> cards = new List<string>(), choices = new List<string>();
            foreach (FunctionCard fcard in room.AvailableFunctionCards)
            {
                if (fcard is EquipCard || fcard is FireSlash || fcard is ThunderSlash) continue;
                choices.Add(fcard.Name);
            }
            string choice1 = room.AskForChoice(player, "busuan", string.Join("+", choices), new List<string> { "@to-player:" + target.Name }, target, card_use.Card.SkillPosition);
            choices.Remove(choice1);
            choices.Add("cancel");
            cards.Add(choice1);
            string choice2 = room.AskForChoice(player, "busuan", string.Join("+", choices), new List<string> { "@to-player:" + target.Name }, target, card_use.Card.SkillPosition);
            if (choice2 != "cancel")
                cards.Add(choice2);
            target.SetTag("busuan", cards);
        }
    }
    public class BusuanDraw : DrawCardsSkill
    {
        public BusuanDraw() : base("#busuan")
        {
            frequency = Frequency.Compulsory;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Draw && player.ContainsTag("busuan"))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }
        public override int GetDrawNum(Room room, Player player, int n)
        {
            int count = n;
            if (player.GetTag("busuan") is List<string> cards)
            {
                player.RemoveTag("busuan");
                if (n > 0)
                {
                    List<int> ids = new List<int>(room.DrawPile);
                    ids.AddRange(room.DiscardPile);
                    Shuffle.shuffle(ref ids);
                    List<int> get = new List<int>();
                    foreach (string card_name in cards)
                    {
                        ids.RemoveAll(t => get.Contains(t));
                        foreach (int id in ids)
                        {
                            WrappedCard card = room.GetCard(id);
                            if (card.Name.Contains(card_name))
                            {
                                get.Add(id);
                                count--;
                                break;
                            }
                        }
                        if (count == 0)
                            break;
                    }

                    if (get.Count > 0)
                        room.ObtainCard(player, ref get, new CardMoveReason(MoveReason.S_REASON_GOTCARD, player.Name, "busuan", string.Empty));
                }
            }

            return count;
        }
    }

    public class Mingjie : TriggerSkill
    {
        public Mingjie() : base("mingjie")
        {
            events.Add(TriggerEvent.EventPhaseStart);
        }

        public override bool Triggerable(Player target, Room room)
        {
            return base.Triggerable(target, room) && target.Phase == PlayerPhase.Finish;
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

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<int> get = new List<int>(), ids = new List<int>();
            bool red = true;
            do
            {
                ids = room.GetNCards(1, true);
                get.AddRange(ids);
                room.MoveCardTo(room.GetCard(ids[0]), null, Place.PlaceTable, new CardMoveReason(MoveReason.S_REASON_TURNOVER, player.Name, Name, string.Empty));
                red = WrappedCard.IsRed(room.GetCard(ids[0]).Suit);
            }
            while (get.Count < 3 && red && room.AskForSkillInvoke(player, Name, null, info.SkillPosition));

            if (get.Count > 0)
                room.ObtainCard(player, ref get, new CardMoveReason(MoveReason.S_REASON_GOTCARD, player.Name, Name, string.Empty));

            if (!red && player.Alive && player.Hp > 1) room.LoseHp(player);

            return false;
        }
    }

    public class Weilu : TriggerSkill
    {
        public Weilu() : base("weilu")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damaged, TriggerEvent.EventPhaseStart, TriggerEvent.EventPhaseChanging };
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Wizzard;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.ContainsTag("weilu_hp") && p.GetTag("weilu_hp") is int count)
                    {
                        p.RemoveTag("weilu_hp");
                        int n = Math.Min(count, p.GetLostHp());
                        if (n > 0)
                            room.Recover(p, n);
                    }
                }
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.Damaged && base.Triggerable(player, room) && data is DamageStruct damage && damage.From != null && damage.From != player && damage.From.Alive)
            {
                return new TriggerStruct(Name, player);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Play && player.ContainsTag(Name))
            {
                return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, player, Name, info.SkillPosition);
            if (triggerEvent == TriggerEvent.Damaged && data is DamageStruct damage)
            {
                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, damage.From.Name);
                room.SetPlayerStringMark(damage.From, Name, string.Empty);

                List<string> generals = player.ContainsTag(Name) ? (List<string>)player.GetTag(Name) : new List<string>();
                generals.Add(damage.From.Name);
                player.SetTag(Name, generals);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart && player.GetTag(Name) is List<string> names)
            {
                player.RemoveTag(Name);
                List<Player> targets = new List<Player>();
                foreach (string general in names)
                {
                    Player target = room.FindPlayer(general);
                    if (target != null)
                        room.RemovePlayerStringMark(target, Name);

                    if (target != null && !targets.Contains(target) && target.Hp > 1)
                        targets.Add(target);
                }

                if (targets.Count > 0)
                {
                    room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);
                    room.SortByActionOrder(ref targets);
                    foreach (Player p in targets)
                    {
                        room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, p.Name);
                        int count = p.Hp - 1;
                        p.SetTag("weilu_hp", count);
                        room.LoseHp(p, count);
                    }
                }
            }

            return false;
        }
    }

    public class Zengdao : ViewAsSkill
    {
        public Zengdao() : base("zengdao")
        {
            limit_mark = "@zengdao";
            frequency = Frequency.Limited;
            skill_type = SkillType.Replenish;
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return player.HasEquip() && player.GetMark(limit_mark) > 0;
        }
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            return room.GetCardPlace(to_select.Id) == Place.PlaceEquip;
        }
        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            WrappedCard zd = new WrappedCard(ZengdaoCard.ClassName) { Skill = Name, Mute = true };
            zd.AddSubCards(cards);
            return zd;
        }
    }

    public class ZengdaoCard : SkillCard
    {
        public static string ClassName = "ZengdaoCard";
        public ZengdaoCard() : base(ClassName)
        {
            will_throw = false;
        }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return base.TargetFilter(room, targets, to_select, Self, card);
        }
        public override void OnUse(Room room, CardUseStruct card_use)
        {
            room.SetPlayerMark(card_use.From, "@zengdao", 0);
            room.BroadcastSkillInvoke("zengdao", card_use.From, card_use.Card.SkillPosition);
            room.DoSuperLightbox(card_use.From, card_use.Card.SkillPosition, "zengdao");
            base.OnUse(room, card_use);
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            Player target = card_use.To[0];

            ResultStruct result = card_use.From.Result;
            result.Assist += card_use.Card.SubCards.Count;
            card_use.From.Result = result;

            List<int> ids = new List<int>(card_use.Card.SubCards);
            room.AddToPile(target, "zengdao", ids);
        }
    }

    public class ZengdaoDamage : TriggerSkill
    {
        public ZengdaoDamage() : base("#zengdao")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageCaused };
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Alive && player.GetPile("zengdao").Count > 0)
            {
                return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<int> ids = player.GetPile("zengdao");
            CardsMoveStruct move = new CardsMoveStruct(ids[0], null, Place.DiscardPile, new CardMoveReason(MoveReason.S_REASON_NATURAL_ENTER, ask_who.Name, Name, string.Empty));
            room.MoveCardsAtomic(move, true);

            DamageStruct damage = (DamageStruct)data;
            LogMessage log = new LogMessage
            {
                Type = "#AddDamage",
                From = player.Name,
                To = new List<string> { damage.To.Name },
                Arg = "zengdao",
                Arg2 = (++damage.Damage).ToString()
            };
            room.SendLog(log);
            data = damage;

            return false;
        }
    }

    public class Chijie : TriggerSkill
    {
        public Chijie() : base("chijie")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetConfirmed, TriggerEvent.CardFinished };
            skill_type = SkillType.Masochism;
            priority = new Dictionary<TriggerEvent, double>
            {
                { TriggerEvent.TargetConfirmed, 3 },
                { TriggerEvent.CardFinished, 2 },
            };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardFinished && data is CardUseStruct use && room.ContainsTag("chijie_card")
                && room.GetTag("chijie_card") is Dictionary<WrappedCard, List<Player>> _chijie && _chijie.ContainsKey(use.Card))
            {
                _chijie.Remove(use.Card);
                if (_chijie.Count == 0)
                    room.RemoveTag("chijie_card");
                else
                    room.SetTag("chijie_card", _chijie);
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is CardUseStruct use && use.From != player && !player.HasFlag(Name))
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (!(fcard is DelayedTrick) && !(fcard is SkillCard) && (use.Card.SubCards.Count > 0 || use.Card.Name.Contains(Slash.ClassName) || use.Card.Name == FireAttack.ClassName
                    || use.Card.Name == Duel.ClassName || use.Card.Name == SavageAssault.ClassName || use.Card.Name == ArcheryAttack.ClassName || use.Card.Name == HiddenDagger.ClassName
                    || use.Card.Name == HoneyTrap.ClassName))
                    return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                room.SetTag(Name, data);
                bool invoke = room.AskForSkillInvoke(player, Name, string.Format("@chijie:{0}::{1}", use.From.Name, use.Card.Name), info.SkillPosition);
                room.RemoveTag(Name);
                if (invoke)
                {
                    GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, player, Name, info.SkillPosition);
                    room.BroadcastSkillInvoke(Name, "male", -1, gsk.General, gsk.SkinId);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                player.SetFlags(Name);
                Dictionary<WrappedCard, List<Player>> chijie = room.ContainsTag("chijie_card") ? (Dictionary<WrappedCard, List<Player>>)room.GetTag("chijie_card")
                    : new Dictionary<WrappedCard, List<Player>>();
                if (chijie.ContainsKey(use.Card))
                    chijie[use.Card].Add(player);
                else
                    chijie[use.Card] = new List<Player> { player };
                room.SetTag("chijie_card", chijie);
            }

            return false;
        }
    }

    public class ChijieEffect : TriggerSkill
    {
        public ChijieEffect() : base("#chijie")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damage, TriggerEvent.Damaged, TriggerEvent.DamageInflicted, TriggerEvent.CardFinished };
            frequency = Frequency.Compulsory;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {

            if (triggerEvent == TriggerEvent.Damage && data is DamageStruct damage && damage.Card != null && !damage.Card.HasFlag("chijie_damage")
                && room.ContainsTag("chijie_card") && room.GetTag("chijie_card") is Dictionary<WrappedCard, List<Player>> chijie && chijie.ContainsKey(damage.Card))
            {
                damage.Card.SetFlags("chijie_damage");
            }
            else if (triggerEvent == TriggerEvent.Damaged && data is DamageStruct _damage && player.Alive && _damage.Card != null && !_damage.Card.HasFlag("chijie")
                && room.ContainsTag("chijie_card") && room.GetTag("chijie_card") is Dictionary<WrappedCard, List<Player>> _chijie && _chijie.ContainsKey(_damage.Card)
                && _chijie[_damage.Card].Contains(player))
            {
                _chijie.Remove(_damage.Card);
                if (_chijie.Count == 0)
                    room.RemoveTag("chijie_card");
                else
                    room.SetTag("chijie_card", _chijie);
                _damage.Card.SetFlags("chijie");
            }
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.DamageInflicted && data is DamageStruct damage && damage.Card != null && damage.Card.HasFlag("chijie"))
            {
                triggers.Add(new TriggerStruct(Name, player));
            }
            else if (triggerEvent == TriggerEvent.CardFinished && data is CardUseStruct use && room.ContainsTag("chijie_card") && !use.Card.HasFlag("chijie_damage")
                && room.GetTag("chijie_card") is Dictionary<WrappedCard, List<Player>> chijie && chijie.ContainsKey(use.Card) && use.Card.SubCards.Count > 0)
            {
                List<int> ids = new List<int>(use.Card.SubCards), subs = room.GetSubCards(use.Card);
                if (ids.SequenceEqual(subs))
                {
                    bool check = true;
                    foreach (int id in ids)
                    {
                        if (room.GetCardPlace(id) != Place.DiscardPile)
                        {
                            check = false;
                            break;
                        }
                    }
                    if (check)
                    {
                        foreach (Player p in chijie[use.Card])
                            if (p.Alive) triggers.Add(new TriggerStruct(Name, p));
                    }
                }
            }

            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.DamageInflicted)
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
            else if (data is CardUseStruct use)
            {
                List<int> ids = new List<int>(use.Card.SubCards), subs = room.GetSubCards(use.Card);
                if (ids.SequenceEqual(subs))
                {
                    bool check = true;
                    foreach (int id in ids)
                    {
                        if (room.GetCardPlace(id) != Place.DiscardPile)
                        {
                            check = false;
                            break;
                        }
                    }
                    if (check)
                    {
                        room.RemoveSubCards(use.Card);
                        room.SendCompulsoryTriggerLog(ask_who, "chijie");

                        room.ObtainCard(ask_who, ref ids, new CardMoveReason(MoveReason.S_REASON_RECYCLE, ask_who.Name, "chijie", string.Empty));
                    }
                }
            }

            return false;
        }
    }

    public class Yinju : ZeroCardViewAsSkill
    {
        public Yinju() : base("yinju")
        {
            skill_type = SkillType.Defense;
            limit_mark = "@yinju";
            frequency = Frequency.Limited;
        }

        public override bool IsEnabledAtPlay(Room room, Player player) => player.GetMark(limit_mark) > 0;
        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(YinjuCard.ClassName) { Skill = Name, Mute = true };
    }

    public class YinjuCard : SkillCard
    {
        public static string ClassName = "YinjuCard";
        public YinjuCard() : base(ClassName) { }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card) => targets.Count == 0 && to_select != Self;

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            room.SetPlayerMark(card_use.From, "@yinju", 0);
            GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, card_use.From, "yinju", card_use.Card.SkillPosition);
            room.BroadcastSkillInvoke("yinju", "male", 1, gsk.General, gsk.SkinId);
            room.DoSuperLightbox(card_use.From, card_use.Card.SkillPosition, "yinju");
            base.OnUse(room, card_use);
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            card_use.To[0].SetFlags("yinju_" + card_use.From.Name);
        }
    }

    public class YinjuEffect : TriggerSkill
    {
        public YinjuEffect() : base("#yinju")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageCaused, TriggerEvent.TargetChosen };
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.DamageCaused && data is DamageStruct damage && damage.To.HasFlag("yinju_" + player.Name))
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use && Engine.GetFunctionCard(use.Card.Name).TypeID != CardType.TypeSkill)
            {
                foreach (Player p in use.To)
                    if (p.HasFlag("yinju_" + player.Name)) return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, "yingju");
            GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, player, "yinju", info.SkillPosition);
            room.BroadcastSkillInvoke("yinju", "male", 2, gsk.General, gsk.SkinId);
            if (triggerEvent == TriggerEvent.DamageCaused && data is DamageStruct damage)
            {
                Player to = damage.To;
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, to.Name);
                if (to.IsWounded())
                {
                    RecoverStruct recover = new RecoverStruct
                    {
                        Recover = Math.Min(to.GetLostHp(), damage.Damage),
                        Who = player
                    };
                    room.Recover(to, recover, true);
                }

                LogMessage log = new LogMessage
                {
                    Type = "#damage-prevent",
                    From = player.Name,
                    To = new List<string> { to.Name },
                    Arg = Name
                };
                room.SendLog(log);
                return true;
            }
            else if (triggerEvent == TriggerEvent.TargetChosen)
                room.DrawCards(player, 1, Name);

            return false;
        }
    }

    public class Zhuilie : TriggerSkill
    {
        public Zhuilie() : base("zhuilie")
        {
            events.Add(TriggerEvent.TargetChosen);
            skill_type = SkillType.Attack;
            frequency = Frequency.Compulsory;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardUseStruct use && base.Triggerable(player, room) && use.Card.Name.Contains(Slash.ClassName))
            {
                List<Player> targets = new List<Player>();
                foreach (Player p in use.To)
                    if (!RoomLogic.InMyAttackRange(room, player, p))
                        targets.Add(p);

                if (targets.Count > 0)
                    return new TriggerStruct(Name, player, targets);
            }
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player skill_target, ref object data, Player player, TriggerStruct info)
        {
            room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, skill_target.Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.SendCompulsoryTriggerLog(player, Name, true);
            return info;
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player target, ref object data, Player player, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                JudgeStruct judge = new JudgeStruct
                {
                    Pattern = "Weapon#Horse",
                    Good = true,
                    PlayAnimation = true,
                    Reason = Name,
                    Who = player
                };
                player.SetTag(Name, target.Name);
                room.Judge(ref judge);

                if (judge.IsGood() && target.Alive && target.Hp > 1)
                {
                    LogMessage log = new LogMessage
                    {
                        Type = "#add_damage",
                        From = target.Name,
                        To = new List<string> { target.Name },
                        Arg = (target.Hp - 1).ToString()
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
                                effect.Effect1 += target.Hp - 1;
                                data = use;
                                break;
                            }
                        }
                    }
                }
                else if (judge.IsBad() && player.Alive)
                    room.LoseHp(player);
            }

            return false;
        }
    }

    public class ZhuilieTar : TargetModSkill
    {
        public ZhuilieTar() : base("#zhuilie")
        {
        }

        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern) => from != null && RoomLogic.PlayerHasSkill(room, from, "zhuilie") && to != null;

        public override bool CheckSpecificAssignee(Room room, Player from, Player to, WrappedCard card, string pattern)
        {
            return from != null && RoomLogic.PlayerHasSkill(room, from, "zhuilie") && to != null && !RoomLogic.InMyAttackRange(room, from, to, card);
        }
        public override void GetEffectIndex(Room room, Player player, WrappedCard card, ModType type, ref int index, ref string skill_name, ref string general_name, ref int skin_id) => index = -2;
    }

    public class Pianchong : TriggerSkill
    {
        public Pianchong() : base("pianchong")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            skill_type = SkillType.Wizzard;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Draw)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, player, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                return info;
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<int> ids = new List<int>();
            if (room.DrawPile.Count < 2) room.SwapPile();
            bool black = false;
            bool red = false;
            foreach (int id in room.DrawPile)
            {
                bool b = WrappedCard.IsBlack(room.GetCard(id).Suit);
                if (!black && b)
                {
                    ids.Add(id);
                    black = true;
                }
                else if (!red && !b)
                {
                    ids.Add(id);
                    red = true;
                }
                if (red && black) break;
            }

            room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_DRAW, player.Name, Name, string.Empty), false);
            if (player.Alive)
            {
                string choice = room.AskForChoice(player, Name, "black+red", new List<string> { "@pianchong" }, null, info.SkillPosition);
                int mark = choice == "black" ? 1 : 2;
                player.SetMark(Name, mark);
                room.SetPlayerStringMark(player, Name, choice);
            }

            return true;
        }
    }
    public class PianchongDraw : TriggerSkill
    {
        public PianchongDraw() : base("#pianchong")
        {
            events= new List<TriggerEvent> { TriggerEvent.TurnStart, TriggerEvent.CardsMoveOneTime };
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.TurnStart && player.GetMark("pianchong") > 0)
            {
                player.SetMark("pianchong", 0);
                room.RemovePlayerStringMark(player, "pianchong");
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null && move.From.Alive && (move.From_places.Contains(Place.PlaceEquip)
                || move.From_places.Contains(Place.PlaceHand)) && move.From.GetMark("pianchong") > 0 && (move.To != move.From || move.To_place != Place.PlaceHand))
            {
                bool black = move.From.GetMark("pianchong") == 1;
                for (int i = 0; i < move.Card_ids.Count; i++)
                {
                    if ((move.From_places[i] == Place.PlaceEquip || move.From_places[i] == Place.PlaceHand)
                        && WrappedCard.IsBlack(room.GetCard(move.Card_ids[i]).Suit) == black)
                        return new TriggerStruct(Name, move.From);
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move)
            {
                room.SendCompulsoryTriggerLog(ask_who, "pianchong");
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, "pianchong", info.SkillPosition);
                room.BroadcastSkillInvoke("pianchong", "male", 2, gsk.General, gsk.SkinId);
                List<int> ids = new List<int>();

                bool black = move.From.GetMark("pianchong") == 1;
                int count = 0;
                for (int i = 0; i < move.Card_ids.Count; i++)
                {
                    if ((move.From_places[i] == Place.PlaceEquip || move.From_places[i] == Place.PlaceHand)
                        && WrappedCard.IsBlack(room.GetCard(move.Card_ids[i]).Suit) == black)
                        count++;
                }

                if (room.DrawPile.Count < count) room.SwapPile();
                foreach (int id in room.DrawPile)
                {
                    if (WrappedCard.IsRed(room.GetCard(id).Suit) == black)
                    {
                        ids.Add(id);
                        count--;
                    }
                    if (count == 0) break;
                }

                room.ObtainCard(ask_who, ref ids, new CardMoveReason(MoveReason.S_REASON_DRAW, ask_who.Name, "pianchong", string.Empty), false);
            }
            
            return false;
        }
    }

    public class Zunwei : ZeroCardViewAsSkill
    {
        public Zunwei() : base("zunwei") {}
        public override bool IsEnabledAtPlay(Room room, Player player) => player.GetMark("zunwei_1") == 0 || player.GetMark("zunwei_2") == 0 || (player.GetMark("zunwei_3") == 0 && player.GetLostHp() > 0);

        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(ZunweiCard.ClassName) { Skill = Name };
    }

    public class ZunweiCard : SkillCard
    {
        public static string ClassName = "ZunweiCard";
        public ZunweiCard() : base(ClassName)
        {
        }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            if (targets.Count == 0 && Self != to_select)
            {
                if ((Self.GetMark("zunwei_1") == 0 && to_select.HandcardNum > Self.HandcardNum)
                    || (Self.GetMark("zunwei_3") == 0 && to_select.Hp > Self.Hp && Self.GetLostHp() > 0))
                    return true;
                else if (Self.GetMark("zunwei_2") == 0 && to_select.GetEquips().Count > Self.GetEquips().Count)
                {
                    for (int i = 0; i < 5; i++)
                        if (Self.CanPutEquip(i)) return true;
                }
            }

            return false;
        }
        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            bool handcard = false;
            bool equip = false;
            bool hp = false;

            if (player.GetMark("zunwei_1") == 0 && target.HandcardNum > player.HandcardNum)
                handcard = true;
            if (player.GetMark("zunwei_3") == 0 && target.Hp > player.Hp && player.GetLostHp() > 0)
                hp = true;
            if (player.GetMark("zunwei_2") == 0 && target.GetEquips().Count > player.GetEquips().Count)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (player.CanPutEquip(i))
                    {
                        equip = true;
                        break;
                    }
                }
            }
            List<string> choices = new List<string>();
            if (handcard) choices.Add("handcard");
            if (equip) choices.Add("equip");
            if (hp) choices.Add("hp");
            string choice = room.AskForChoice(player, "zunwei", string.Join("+", choices), new List<string> { "@to-player:" + target.Name }, target, card_use.Card.SkillPosition);
            if (choice == "handcard")
            {
                player.SetMark("zunwei_1", 1);
                int count = Math.Min(5, target.HandcardNum - player.HandcardNum);
                room.DrawCards(player, count, "zunwei");
            }
            else if (choice == "equip")
            {
                player.SetMark("zunwei_2", 1);
                int count = target.GetEquips().Count - player.GetEquips().Count;

                while (count > 0)
                {
                    int card_id = -1;
                    foreach (int id in room.DrawPile)
                    {
                        FunctionCard fcard = Engine.GetFunctionCard(room.GetCard(id).Name);
                        if (fcard is EquipCard card && player.CanPutEquip((int)card.EquipLocation()))
                        {
                            card_id = id;
                            break;
                        }
                    }
                    if (card_id >= 0)
                    {
                        count--;
                        room.UseCard(new CardUseStruct(room.GetCard(card_id), player, new List<Player>()));
                    }
                    else
                        break;
                }
            }
            else
            {
                player.SetMark("zunwei_3", 1);
                int count = Math.Min(player.GetLostHp(), target.Hp - player.Hp);
                room.Recover(player, count);
            }
        }
    }

    public class Lilu : TriggerSkill
    {
        public Lilu() : base("lilu")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventLoseSkill, TriggerEvent.EventPhaseStart };
            view_as_skill = new LiluVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventLoseSkill && data is InfoStruct info && info.Info == Name)
            {
                player.SetMark(Name, 0);
                room.RemovePlayerStringMark(player, Name);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Draw)
                return new TriggerStruct(Name, player);
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

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int count = Math.Min(5, player.MaxHp - player.HandcardNum);
            if (count > 0) room.DrawCards(player, count, Name);
            if (player.Alive && !player.IsKongcheng())
            {
                if (room.AskForUseCard(player, RespondType.Skill, "@@lilu!", "@lilu", null, -1, HandlingMethod.MethodNone, true, info.SkillPosition) == null)
                {
                    List<int> hands = new List<int>(player.GetCards("h"));
                    Shuffle.shuffle(ref hands);
                    List<int> cards = new List<int> { hands[0] };
                    List<Player> targets = room.GetOtherPlayers(player);
                    Shuffle.shuffle(ref targets);
                    Player target = targets[0];
                    room.ObtainCard(target, ref cards, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, "lilu", string.Empty), false);
                    if (player.Alive)
                    {
                        int old = player.GetMark(Name);
                        player.SetMark(Name, cards.Count);
                        room.SetPlayerStringMark(player, Name, player.GetMark(Name).ToString());
                        if (cards.Count > old)
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
                            room.Recover(player, 1);
                        }
                    }
                }
            }

            return true;
        }
    }

    public class LiluVS : ViewAsSkill
    {
        public LiluVS() : base("lilu") { response_pattern = "@@lilu"; }

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            return room.GetCardPlace(to_select.Id) == Place.PlaceHand;
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count > 0)
            {
                WrappedCard ll = new WrappedCard(LiluCard.ClassName);
                ll.AddSubCards(cards);
                return ll;
            }

            return null;
        }
    }

    public class LiluCard : SkillCard
    {
        public static string ClassName = "LiluCard";
        public LiluCard() : base(ClassName)
        {
            will_throw = false;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && to_select != Self;
        }

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            List<int> cards = new List<int>(card_use.Card.SubCards);
            Player player = card_use.From, target = card_use.To[0];
            room.ObtainCard(target, ref cards, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, "lilu", string.Empty), false);
            if (player.Alive)
            {
                int old = player.GetMark("lilu");
                player.SetMark("lilu", cards.Count);
                room.SetPlayerStringMark(player, "lilu", player.GetMark("lilu").ToString());
                if (cards.Count > old)
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
                    room.Recover(player, 1);
                }
            }
        }
    }

    public class YizhengCS : TriggerSkill
    {
        public YizhengCS() : base("yizheng_cs")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.TurnStart };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.TurnStart && player.ContainsTag(Name) && player.GetTag(Name) is string target_name)
            {
                Player target = room.FindPlayer(target_name);
                if (target != null && target.ContainsTag("yizheng_from") && target.GetTag("yizheng_from") is string from && from == player.Name)
                {
                    target.RemoveTag("yizheng_from");
                    room.RemovePlayerStringMark(target, Name);
                }
                player.RemoveTag(Name);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.Phase == PlayerPhase.Finish)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@yizheng_cs", true, true, info.SkillPosition);
            if (target != null)
            {
                player.SetTag(Name, target.Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.GetTag(Name) is string target_name)
            {
                Player target = room.FindPlayer(target_name);
                target.SetTag("yizheng_from", player.Name);
                room.SetPlayerStringMark(target, Name, string.Empty);
            }
            return false;
        }
    }

    public class YizhengCSEffect : TriggerSkill
    {
        public YizhengCSEffect() : base("#yizheng_cs")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageCaused, TriggerEvent.PreHpRecover };
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.ContainsTag("yizheng_from") && player.GetTag("yizheng_from") is string from_name)
            {
                Player from = room.FindPlayer(from_name);
                if (from != null && player.MaxHp < from.MaxHp)
                {
                    return new TriggerStruct(Name, player, from);
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player from = room.FindPlayer(info.SkillOwner);
            room.SendCompulsoryTriggerLog(from, "yizheng_cs");
            room.LoseMaxHp(from);
            if (triggerEvent == TriggerEvent.DamageCaused)
            {
                DamageStruct damage = (DamageStruct)data;
                LogMessage log = new LogMessage
                {
                    Type = "#AddDamage",
                    From = player.Name,
                    To = new List<string> { damage.To.Name },
                    Arg = "yizheng_cs",
                    Arg2 = (++damage.Damage).ToString()
                };
                room.SendLog(log);

                data = damage;
            }
            else
            {
                RecoverStruct recover = (RecoverStruct)data;

                LogMessage log = new LogMessage
                {
                    Type = "#AddRecover",
                    From = player.Name,
                    To = new List<string> { player.Name },
                    Arg = "yizheng_cs",
                    Arg2 = (++recover.Recover).ToString()
                };
                room.SendLog(log);
                
                data = recover;
            }

            return false;
        }
    }

    public class Liedan : TriggerSkill
    {
        public Liedan() : base("liedan")
        {
            frequency = Frequency.Compulsory;
            events.Add(TriggerEvent.EventPhaseStart);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (player.Alive && player.Phase == PlayerPhase.Start)
            {
                List<Player> xhj = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in xhj)
                    if (p.GetMark("zhuangdan") == 0 && (p != player || player.GetMark(Name) >= 5))
                        triggers.Add(new TriggerStruct(Name, p));
            }
            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
            if (player == ask_who)
            {
                room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);
                player.Hp = 0;
                room.BroadcastProperty(player, "Hp");
                room.KillPlayer(player, new DamageStruct());
            }
            else
            {
                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                int count = 0;
                if (ask_who.HandcardNum > player.HandcardNum)
                    count++;
                if (ask_who.Hp > player.Hp)
                    count++;
                if (ask_who.GetEquips().Count > player.GetEquips().Count)
                    count++;

                if (count > 0) room.DrawCards(ask_who, count, Name);
                if (ask_who.Alive && count == 3)
                {
                    ask_who.MaxHp++;
                    room.BroadcastProperty(ask_who, "MaxHp");

                    LogMessage log = new LogMessage
                    {
                        Type = "$GainMaxHp",
                        From = ask_who.Name,
                        Arg = "1"
                    };
                    room.SendLog(log);

                    room.RoomThread.Trigger(TriggerEvent.MaxHpChanged, room, ask_who);
                }
                else if (ask_who.Alive && count == 0)
                {
                    room.LoseHp(ask_who);
                    if (ask_who.Alive)
                    {
                        ask_who.AddMark(Name);
                        room.SetPlayerStringMark(ask_who, Name, ask_who.GetMark(Name).ToString());
                    }
                }
            }

            return false;
        }
    }

    public class Zhuangdan : TriggerSkill
    {
        public Zhuangdan() :base("zhuangdan")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging, TriggerEvent.EventLoseSkill };
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player.GetMark(Name) > 0)
            {
                player.SetMark(Name, 0);
                room.RemovePlayerStringMark(player, Name);
            }
            else if (triggerEvent == TriggerEvent.EventLoseSkill && data is InfoStruct info && info.Info == Name)
            {
                player.SetMark(Name, 0);
                room.RemovePlayerStringMark(player, Name);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                int max = 0;
                Player max_p = null;
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.HandcardNum > max)
                    {
                        max_p = p;
                        max = p.HandcardNum;
                    }
                }

                if (max_p != null)
                {
                    foreach (Player p in room.GetOtherPlayers(max_p))
                    {
                        if (p.HandcardNum == max)
                        {
                            max_p = null;
                            break;
                        }
                    }
                }

                if (max_p != null && max_p != player && max_p.GetMark(Name) == 0 && base.Triggerable(max_p, room))
                    return new TriggerStruct(Name, max_p);
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            ask_who.AddMark(Name);
            room.SetPlayerStringMark(ask_who, Name, string.Empty);
            return false;
        }
    }

    public class Cuijian: ZeroCardViewAsSkill
    {
        public Cuijian() : base("cuijian")
        {
        }

        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(CuijianCard.ClassName);

        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(CuijianCard.ClassName) { Skill = Name };
    }

    public class CuijianCard : SkillCard
    {
        public static string ClassName = "CuijianCard";
        public CuijianCard() : base(ClassName)
        {
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && Self != to_select && !to_select.IsKongcheng();
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            List<int> ids = new List<int>();
            foreach (int id in target.GetCards("h"))
            {
                if (room.GetCard(id).Name == Jink.ClassName)
                    ids.Add(id);
            }

            if (ids.Count > 0)
            {
                ids.AddRange(target.GetEquips());
                room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, target.Name, player.Name, "cuijian", string.Empty), false);
                if (player.Alive && target.Alive && player.GetMark("tongyuan_peach") == 0)
                {
                    int count = ids.Count;
                    List<int> give = room.AskForExchange(player, "cuijian", count, count,
                        string.Format("@cuijian-give:{0}::{1}", target.Name, count), string.Empty, "..", card_use.Card.SkillPosition);
                    if (give.Count > 0)
                        room.ObtainCard(target, ref give, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, "cuijian", string.Empty), false);
                }
            }
            else if (player.GetMark("tongyuan_null") > 0)
            {
                room.DrawCards(player, 2, "cuijian");
            }
        }
    }

    public class Tongyuan : TriggerSkill
    {
        public Tongyuan() : base("tongyuan")
        {
            events = new List<TriggerEvent> { TriggerEvent.TrickCardCanceling, TriggerEvent.CardFinished, TriggerEvent.CardTargetAnnounced };
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardFinished && data is CardUseStruct use && base.Triggerable(player, room))
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is BasicCard && player.GetMark("tongyuan_peach") == 0 && WrappedCard.IsRed(use.Card.Suit))
                {
                    room.SendCompulsoryTriggerLog(player, Name);
                    room.BroadcastSkillInvoke(Name, player);
                    player.AddMark("tongyuan_peach");
                    if (player.GetMark("tongyuan_null") > 0)
                    {
                        room.SetPlayerStringMark(player, Name, string.Empty);
                        room.SetPlayerMark(player, "cuijian_description_index", 3);
                        room.RefreshSkill(player);
                    }
                    else
                    {
                        room.SetPlayerMark(player, "cuijian_description_index", 1);
                        room.RefreshSkill(player);
                    }
                }
                else if (fcard is TrickCard && player.GetMark("tongyuan_null") == 0 && WrappedCard.IsRed(use.Card.Suit))
                {
                    room.SendCompulsoryTriggerLog(player, Name);
                    room.BroadcastSkillInvoke(Name, player);
                    player.AddMark("tongyuan_null");
                    if (player.GetMark("tongyuan_peach") > 0)
                    {
                        room.SetPlayerStringMark(player, Name, string.Empty);
                        room.SetPlayerMark(player, "cuijian_description_index", 3);
                        room.RefreshSkill(player);
                    }
                    else
                    {
                        room.SetPlayerMark(player, "cuijian_description_index", 2);
                        room.RefreshSkill(player);
                    }
                }
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TrickCardCanceling && data is CardEffectStruct effect && base.Triggerable(effect.From, room) && effect.From.GetMark("tongyuan_null") > 0
                && effect.From.GetMark("tongyuan_peach") > 0 && effect.Card.Name == Nullification.ClassName && WrappedCard.IsRed(effect.Card.Suit))
                return new TriggerStruct(Name, effect.From);
            else if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use && player.GetMark("tongyuan_null") > 0
                && player.GetMark("tongyuan_peach") > 0 && WrappedCard.IsRed(use.Card.Suit))
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is BasicCard) return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.TrickCardCanceling)
                return true;
            else if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use)
            {
                List<Player> targets = new List<Player>();
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                foreach (Player p in room.GetOtherPlayers(player))
                {
                    if ((fcard is Peach && !p.IsWounded())) continue;
                    if (!use.To.Contains(p) && RoomLogic.IsProhibited(room, player, p, use.Card) == null)
                        targets.Add(p);
                }

                room.SetTag("extra_target_skill", data);                   //for AI
                Player target = room.AskForPlayerChosen(player, targets, Name, "@tongyuan-extra:::" + use.Card.Name, true, true, info.SkillPosition);
                room.RemoveTag("extra_target_skill");
                if (target != null)
                {
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, target.Name);
                    LogMessage log = new LogMessage
                    {
                        Type = "$extra_target",
                        From = player.Name,
                        To = new List<string> { target.Name },
                        Card_str = RoomLogic.CardToString(room, use.Card),
                        Arg = Name
                    };
                    room.SendLog(log);

                    use.To.Add(target);
                    room.SortByActionOrder(ref use);
                    data = use;
                }
            }

            return false;
        }
    }

    public class Xianwei : TriggerSkill
    {
        public Xianwei() : base("xianwei")
        {
            frequency = Frequency.Compulsory;
            events.Add(TriggerEvent.EventPhaseStart);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Start && base.Triggerable(player, room))
            {
                for (int i = 0; i < 5; i++)
                {
                    if (!player.EquipIsBaned(i))
                        return new TriggerStruct(Name, player);
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
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
                            choices.Add("DefensiveHorse");
                            break;
                        case 3:
                            choices.Add("OffensiveHorse");
                            break;
                        case 4:
                            choices.Add("Treasure");
                            break;
                    }
                }
            }

            string choice = room.AskForChoice(player, Name, string.Join("+", choices), new List<string> { "@xianwei" }, null, info.SkillPosition);
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);

            int index = -1;
            switch (choice)
            {
                case "Weapon":
                    index = 0;
                    break;
                case "Armor":
                    index = 1;
                    break;
                case "DefensiveHorse":
                    index = 2;
                    break;
                case "OffensiveHorse":
                    index = 3;
                    break;
                case "Treasure":
                    index = 4;
                    break;
            }
            room.AbolisheEquip(player, index, Name);
            if (player.Alive)
            {
                int count = 0;
                for (int i = 0; i < 5; i++)
                    if (!player.EquipIsBaned(i))
                        count++;

                if (count > 0)
                    room.DrawCards(player, count, Name);

                player.SetTag(Name, index);
                Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@xianwei-equip:::" + choice, true, true, info.SkillPosition);
                player.RemoveTag(Name);
                if (target != null)
                {
                    int card_id = -1;
                    foreach (int id in room.DrawPile)
                    {
                        WrappedCard card = room.GetCard(id);
                        FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                        switch (fcard)
                        {
                            case Weapon _ when choice == "Weapon":
                                card_id = id;
                                break;
                            case Armor _ when choice == "Armor":
                                card_id = id;
                                break;
                            case DefensiveHorse _ when choice == "DefensiveHorse":
                                card_id = id;
                                break;
                            case OffensiveHorse _ when choice == "OffensiveHorse":
                                card_id = id;
                                break;
                            case Treasure _ when choice == "Treasure":
                                card_id = id;
                                break;
                        }

                        if (card_id > -1) break;
                    }

                    if (card_id > -1 && target.CanPutEquip(index) && RoomLogic.IsProhibited(room, target, target, room.GetCard(card_id)) == null)
                        room.UseCard(new CardUseStruct(room.GetCard(card_id), target, new List<Player>(), false));

                    if (count == 0 && player.Alive)
                    {
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

                        if (player.Alive)
                        {
                            player.SetMark(Name, 1);
                            room.SetPlayerStringMark(player, Name, string.Empty);
                        }
                    }
                }

            }
            return false;
        }
    }

    public class XianweiDis : TargetModSkill
    {
        public XianweiDis() : base("#xianwei", false)
        {}

        public override bool InAttackRange(Room room, Player from, Player to, WrappedCard card)
        {
            return from != null && to != null && from != to && (from.GetMark("xianwei") > 0 || to.GetMark("xianwei") > 0) ? true : false;
        }
    }

    public class YisheDFR : TriggerSkill
    {
        public YisheDFR() : base("yishe_dfr")
        {
            events.Add(TriggerEvent.CardsMoveOneTime);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardsMoveOneTimeStruct move && move.To != null && move.From != null && move.To != move.From && move.To.Alive
                && (move.To_place == Place.PlaceHand || move.To_place == Place.PlaceEquip)
                && (move.From_places.Contains(Place.PlaceHand) || move.From_places.Contains(Place.PlaceEquip)) && base.Triggerable(move.From, room))
                return new TriggerStruct(Name, move.From);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move)
            {
                bool black = false;
                foreach (int id in move.Card_ids)
                {
                    if (WrappedCard.IsBlack(room.GetCard(id).Suit))
                        return info;
                }

                if (!black && move.To.IsWounded())
                {
                    move.To.SetFlags(Name);
                    bool invoke = room.AskForSkillInvoke(ask_who, Name, "@yishe-recover:" + move.To.Name, info.SkillPosition);
                    move.To.SetFlags("-yishe_dfr");
                    if (invoke) return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move)
            {
                bool black = false;
                bool red = false;
                foreach (int id in move.Card_ids)
                {
                    if (WrappedCard.IsBlack(room.GetCard(id).Suit))
                        black = true;
                    else
                        red = true;
                }
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, move.From.Name, move.To.Name);
                room.BroadcastSkillInvoke(Name, move.From, info.SkillPosition);
                bool reco = false;
                if (black)
                {
                    move.To.AddMark(Name);
                    room.SetPlayerStringMark(move.To, Name, move.To.GetMark(Name).ToString());
                    room.SendCompulsoryTriggerLog(move.From, Name);

                    if (red)
                    {
                        move.To.SetFlags(Name);
                        reco = move.To.IsWounded() && room.AskForSkillInvoke(ask_who, Name, "@yishe-recover:" + move.To.Name, info.SkillPosition);
                        move.To.SetFlags("-yishe_dfr");
                    }
                }
                else
                    reco = true;

                if (reco)
                {
                    RecoverStruct recover = new RecoverStruct
                    {
                        Who = ask_who,
                        Recover = 1
                    };
                    room.Recover(move.To, recover, true);
                }
            }
            return false;
        }
    }

    public class YisheDFREffect : TriggerSkill
    {
        public YisheDFREffect() : base("#yishe_dfr")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageInflicted };
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Masochism;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is DamageStruct damage && player.GetMark("yishe_dfr") > 0 && damage.Card != null && damage.Card.Name.Contains(Slash.ClassName))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            DamageStruct damage = (DamageStruct)data;
            damage.Damage += player.GetMark("yishe_dfr");
            data = damage;

            room.RemovePlayerStringMark(player, "yishe_dfr");
            player.SetMark("yishe_dfr", 0);

            LogMessage log = new LogMessage
            {
                Type = "#AddDamaged",
                From = player.Name,
                Arg = "yishe_dfr",
                Arg2 = (damage.Damage).ToString()
            };
            room.SendLog(log);

            return false;
        }
    }

    public class Shunshi : TriggerSkill
    {
        public Shunshi() : base("shunshi")
        {
            view_as_skill = new ShunshiVS();
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging, TriggerEvent.EventPhaseStart, TriggerEvent.Damaged };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change)
            {
                if (change.From == PlayerPhase.Draw)
                {
                    if (player.GetMark("shunshi_draw") > 0)
                        player.SetMark("shunshi_draw", 0);

                    if (player.GetMark("shunshi_draw_delay") > 0)
                    {
                        player.AddMark("shunshi_draw", player.GetMark("shunshi_draw_delay"));
                        player.SetMark("shunshi_draw_delay", 0);
                    }
                }
                else if (change.From == PlayerPhase.Play)
                {
                    if (player.GetMark("shunshi_slash") > 0)
                        player.SetMark("shunshi_slash", 0);

                    if (player.GetMark("shunshi_slash_delay") > 0)
                    {
                        player.AddMark("shunshi_slash", player.GetMark("shunshi_slash_delay"));
                        player.SetMark("shunshi_slash_delay", 0);
                    }
                }
                else if (change.From == PlayerPhase.Discard)
                {
                    if (player.GetMark("shunshi_max") > 0)
                        player.SetMark("shunshi_max", 0);

                    if (player.GetMark("shunshi_max_delay") > 0)
                    {
                        player.AddMark("shunshi_max", player.GetMark("shunshi_max_delay"));
                        player.SetMark("shunshi_max_delay", 0);
                    }
                }
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Start && base.Triggerable(player, room) && !player.IsNude())
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.Damaged && base.Triggerable(player, room) && !player.IsNude())
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = null;
            if (triggerEvent == TriggerEvent.Damaged && data is DamageStruct damage && damage.From != null && damage.From != player)
                target = damage.From;

            if (target != null) target.SetFlags(Name);
            WrappedCard card = room.AskForUseCard(player, RespondType.Skill, "@@shunshi",
                target == null ? "@shunshi" : "@shunshi-exsi:" + target.Name, null, -1, HandlingMethod.MethodNone, true, info.SkillPosition);
            if (card != null)
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.Phase != PlayerPhase.Draw)
                player.AddMark("shunshi_draw");
            else
                player.AddMark("shunshi_draw_delay");

            if (player.Phase != PlayerPhase.Play)
                player.AddMark("shunshi_slash");
            else
                player.AddMark("shunshi_slash_delay");

            if (player.Phase != PlayerPhase.Discard)
                player.AddMark("shunshi_max");
            else
                player.AddMark("shunshi_max_delay");

            return false;
        }
    }

    public class ShunshiDraw : DrawCardsSkill
    {
        public ShunshiDraw() : base("#shunshi-draw") { frequency = Frequency.Compulsory; }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == Player.PlayerPhase.Draw && (int)data >= 0 && player.GetMark("shunshi_draw") > 0)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override int GetDrawNum(Room room, Player player, int n)
        {
            int count = player.GetMark("shunshi_draw");
            player.SetMark("shunshi_draw", 0);
            return n + count;
        }
    }

    public class ShunshiMax : MaxCardsSkill
    {
        public ShunshiMax() : base("#shunshi-max") { }
        public override int GetExtra(Room room, Player target) => target.GetMark("shunshi_max");
    }

    public class ShunshiTar : TargetModSkill
    {
        public ShunshiTar() : base("#shunshi-tar", false) { }

        public override int GetResidueNum(Room room, Player from, WrappedCard card) => from.GetMark("shunshi_slash");
    }

    public class ShunshiVS : OneCardViewAsSkill
    {
        public ShunshiVS() : base("shunshi")
        {
            filter_pattern = "..";
            response_pattern = "@@shunshi";
        }
        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard ss = new WrappedCard(ShunshiCard.ClassName) { Skill = Name, Mute = true };
            ss.AddSubCard(card);
            return ss;
        }
    }

    public class ShunshiCard : SkillCard
    {
        public static string ClassName = "ShunshiCard";
        public ShunshiCard() : base(ClassName)
        { will_throw = false; }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && !to_select.HasFlag("shunshi") && to_select != Self;
        }

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            foreach (Player p in room.GetAlivePlayers())
                p.SetFlags("-shunshi");

            List<int> ids = new List<int>(card_use.Card.SubCards);
            room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, card_use.From.Name, card_use.To[0].Name);
            room.ObtainCard(card_use.To[0], ref ids,
                new CardMoveReason(MoveReason.S_REASON_GIVE, card_use.From.Name, card_use.To[0].Name, "shunshi", string.Empty), false);
        }
    }

    public class Yuqi : TriggerSkill
    {
        public Yuqi() : base("yuqi")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damaged, TriggerEvent.EventPhaseChanging };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                foreach (Player p in room.GetAlivePlayers())
                    p.SetMark(Name, 0);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.Damaged && player.Alive)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                {
                    if (p.GetMark(Name) < 2)
                    {
                        int count = RoomLogic.DistanceTo(room, p, player);
                        if (count <= p.GetMark("yuqi_distance") && count >= 0)
                            triggers.Add(new TriggerStruct(Name, p));
                    }
                }
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(ask_who, Name, player, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                ask_who.AddMark(Name);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int count = Math.Min(5, 3 + ask_who.GetMark("yuqi_view"));
            List<int> yiji_cards = room.GetNCards(count);
            List<int> origin_yiji = new List<int>(yiji_cards);
            
            int give_count = Math.Min(5, 1 + ask_who.GetMark("yuqi_give"));
            List<int> ids = room.NotifyChooseCards(ask_who, yiji_cards, Name, give_count, 1, string.Format("@yuqi-give:{0}::{1}", player.Name, give_count), string.Empty, info.SkillPosition);
            yiji_cards.RemoveAll(t => ids.Contains(t));

            List<CardsMoveStruct> lirangs = new List<CardsMoveStruct>();
            CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_PREVIEWGIVE, ask_who.Name, player.Name, Name, null);
                CardsMoveStruct moves = new CardsMoveStruct(ids, player, Place.PlaceHand, reason);
                lirangs.Add(moves);
                        
            if (yiji_cards.Count > 0)
            {
                int get_count = Math.Min(5, 1 + ask_who.GetMark("yuqi_get"));
                get_count = Math.Min(get_count, yiji_cards.Count);

                ask_who.SetFlags(Name);
                List<int> gets = room.NotifyChooseCards(ask_who, yiji_cards, Name, get_count, 0, string.Format("@yuqi-get:::{0}", get_count), string.Empty, info.SkillPosition);
                ask_who.SetFlags("-yuqi");

                if (gets.Count > 0)
                {
                    yiji_cards.RemoveAll(t => gets.Contains(t));
                    reason = new CardMoveReason(MoveReason.S_REASON_PREVIEWGIVE, ask_who.Name, Name, null);
                    CardsMoveStruct moves2 = new CardsMoveStruct(gets, ask_who, Place.PlaceHand, reason);
                    lirangs.Add(moves2);
                }
            }

            room.MoveCardsAtomic(lirangs, false);
            if (yiji_cards.Count > 0) room.ReturnToDrawPile(yiji_cards, false);
            return false;
        }
    }

    public class Shanshen : TriggerSkill
    {
        public Shanshen() : base("shanshen")
        {
            events = new List<TriggerEvent> { TriggerEvent.Death, TriggerEvent.EventLoseSkill, TriggerEvent.Damage };
        }
        
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventLoseSkill && data is InfoStruct info && info.Info == Name)
            {
                int distance = player.GetMark("shanshen_distance");
                int view = player.GetMark("shanshen_view");
                int give = player.GetMark("shanshen_give");
                int get = player.GetMark("shanshen_get");

                player.AddMark("yuqi_distance", -distance);
                player.AddMark("yuqi_view", -view);
                player.AddMark("yuqi_give", -give);
                player.AddMark("yuqi_get", -get);

                if (player.GetMark("yuqi_distance") > 0)
                    room.SetPlayerStringMark(player, "yuqi_distance", "+" + player.GetMark("yuqi_distance").ToString());
                else
                    room.RemovePlayerStringMark(player, "yuqi_distance");


                if (player.GetMark("yuqi_distance") > 0)
                    room.SetPlayerStringMark(player, "yuqi_distance", "+" + player.GetMark("yuqi_distance").ToString());
                else
                    room.RemovePlayerStringMark(player, "yuqi_distance");

                if (player.GetMark("yuqi_view") > 0)
                    room.SetPlayerStringMark(player, "yuqi_view", "+" + player.GetMark("yuqi_view").ToString());
                else
                    room.RemovePlayerStringMark(player, "yuqi_view");

                if (player.GetMark("yuqi_give") > 0)
                    room.SetPlayerStringMark(player, "yuqi_give", "+" + player.GetMark("yuqi_give").ToString());
                else
                    room.RemovePlayerStringMark(player, "yuqi_give");

                if (player.GetMark("yuqi_get") > 0)
                    room.SetPlayerStringMark(player, "yuqi_get", "+" + player.GetMark("yuqi_get").ToString());
                else
                    room.RemovePlayerStringMark(player, "yuqi_get");
            }
            else if (triggerEvent == TriggerEvent.Damage && data is DamageStruct damage && player != damage.To)
            {
                player.AddMark("shanshen_" + damage.To.Name);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.Death)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                {
                    if (p != player)
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int distance = Math.Max(0, 5 - ask_who.GetMark("yuqi_distance"));
            int view = Math.Max(0, 2 - ask_who.GetMark("yuqi_view"));
            int give = Math.Max(0, 4 - ask_who.GetMark("yuqi_give"));
            int get = Math.Max(0, 5 - ask_who.GetMark("yuqi_get"));
            List<string> choices = new List<string>();
            List<string> descript = new List<string> { "@shanshen" };
            if (distance > 0)
            {
                choices.Add("distance");
                descript.Add("@shanshen-distance:::" + Math.Min(2, distance).ToString());
            }
            if (view > 0)
            {
                choices.Add("view");
                descript.Add("@shanshen-view:::" + Math.Min(2, view).ToString());
            }
            if (give > 0)
            {
                choices.Add("give");
                descript.Add("@shanshen-give:::" + Math.Min(2, give).ToString());
            }
            if (get > 0)
            {
                choices.Add("get");
                descript.Add("@shanshen-get:::" + Math.Min(2, get).ToString());
            }

            if (choices.Count > 0)
            {
                choices.Add("cancel");
                string choice = room.AskForChoice(ask_who, Name, string.Join("+", choices), descript, null, info.SkillPosition);
                if (choice != "cancel")
                {
                    room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                    switch (choice)
                    {
                        case "distance":
                            ask_who.AddMark("yuqi_distance", Math.Min(2, distance));
                            ask_who.AddMark("shanshen_distance", Math.Min(2, distance));
                            room.SetPlayerStringMark(ask_who, "yuqi_distance", "+" + ask_who.GetMark("yuqi_distance").ToString());
                            break;
                        case "view":
                            ask_who.AddMark("yuqi_view", Math.Min(2, view));
                            ask_who.AddMark("shanshen_view", Math.Min(2, view));
                            room.SetPlayerStringMark(ask_who, "yuqi_view", "+" + ask_who.GetMark("yuqi_view").ToString());
                            break;
                        case "give":
                            ask_who.AddMark("yuqi_give", Math.Min(2, give));
                            ask_who.AddMark("shanshen_give", Math.Min(2, give));
                            room.SetPlayerStringMark(ask_who, "yuqi_give", "+" + ask_who.GetMark("yuqi_give").ToString());
                            break;
                        case "get":
                            ask_who.AddMark("yuqi_get", Math.Min(2, get));
                            ask_who.AddMark("shanshen_get", Math.Min(2, get));
                            room.SetPlayerStringMark(ask_who, "yuqi_get", "+" + ask_who.GetMark("yuqi_get").ToString());
                            break;
                    }
                    return info;
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (ask_who.GetMark("shanshen_" + player.Name) == 0 && ask_who.GetLostHp() > 0)
                room.Recover(ask_who);

            return false;
        }
    }

    public class Xianjing : TriggerSkill
    {
        public Xianjing() : base("xianjing")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventLoseSkill, TriggerEvent.EventPhaseStart };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventLoseSkill && data is InfoStruct info && info.Info == Name)
            {
                int distance = player.GetMark("xianjing_distance");
                int view = player.GetMark("xianjing_view");
                int give = player.GetMark("xianjing_give");
                int get = player.GetMark("xianjing_get");

                player.AddMark("yuqi_distance", -distance);
                player.AddMark("yuqi_view", -view);
                player.AddMark("yuqi_give", -give);
                player.AddMark("yuqi_get", -get);

                if (player.GetMark("yuqi_distance") > 0)
                    room.SetPlayerStringMark(player, "yuqi_distance", "+" + player.GetMark("yuqi_distance").ToString());
                else
                    room.RemovePlayerStringMark(player, "yuqi_distance");


                if (player.GetMark("yuqi_distance") > 0)
                    room.SetPlayerStringMark(player, "yuqi_distance", "+" + player.GetMark("yuqi_distance").ToString());
                else
                    room.RemovePlayerStringMark(player, "yuqi_distance");

                if (player.GetMark("yuqi_view") > 0)
                    room.SetPlayerStringMark(player, "yuqi_view", "+" + player.GetMark("yuqi_view").ToString());
                else
                    room.RemovePlayerStringMark(player, "yuqi_view");

                if (player.GetMark("yuqi_give") > 0)
                    room.SetPlayerStringMark(player, "yuqi_give", "+" + player.GetMark("yuqi_give").ToString());
                else
                    room.RemovePlayerStringMark(player, "yuqi_give");

                if (player.GetMark("yuqi_get") > 0)
                    room.SetPlayerStringMark(player, "yuqi_get", "+" + player.GetMark("yuqi_get").ToString());
                else
                    room.RemovePlayerStringMark(player, "yuqi_get");
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.Phase == PlayerPhase.Start)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int distance = Math.Max(0, 5 - player.GetMark("yuqi_distance"));
            int view = Math.Max(0, 2 - player.GetMark("yuqi_view"));
            int give = Math.Max(0, 4 - player.GetMark("yuqi_give"));
            int get = Math.Max(0, 5 - player.GetMark("yuqi_get"));
            List<string> choices = new List<string>();
            List<string> descript = new List<string> { "@shanshen" };
            if (distance > 0)
            {
                choices.Add("distance");
                descript.Add("@xianjing-distance");
            }
            if (view > 0)
            {
                choices.Add("view");
                descript.Add("@xianjing-view");
            }
            if (give > 0)
            {
                choices.Add("give");
                descript.Add("@xianjing-give");
            }
            if (get > 0)
            {
                choices.Add("get");
                descript.Add("@xianjing-get");
            }

            if (choices.Count > 0)
            {
                choices.Add("cancel");
                string choice = room.AskForChoice(player, Name, string.Join("+", choices), descript, null, info.SkillPosition);
                if (choice != "cancel")
                {
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    room.SetTag(Name, choice);
                    switch (choice)
                    {
                        case "distance":
                            player.AddMark("yuqi_distance", 1);
                            player.AddMark("xianjing_distance", 1);
                            room.SetPlayerStringMark(player, "yuqi_distance", "+" + player.GetMark("yuqi_distance").ToString());
                            break;
                        case "view":
                            player.AddMark("yuqi_view", 1);
                            player.AddMark("xianjing_view", 1);
                            room.SetPlayerStringMark(player, "yuqi_view", "+" + player.GetMark("yuqi_view").ToString());
                            break;
                        case "give":
                            player.AddMark("yuqi_give", 1);
                            player.AddMark("xianjing_give", 1);
                            room.SetPlayerStringMark(player, "yuqi_give", "+" + player.GetMark("yuqi_give").ToString());
                            break;
                        case "get":
                            player.AddMark("yuqi_get", 1);
                            player.AddMark("xianjing_get", 1);
                            room.SetPlayerStringMark(player, "yuqi_get", "+" + player.GetMark("yuqi_get").ToString());
                            break;
                    }
                    return info;
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.GetLostHp() == 0 && room.GetTag(Name) is string choiced)
            {
                int distance = Math.Max(0, 5 - player.GetMark("yuqi_distance"));
                int view = Math.Max(0, 2 - player.GetMark("yuqi_view"));
                int give = Math.Max(0, 4 - player.GetMark("yuqi_give"));
                int get = Math.Max(0, 5 - player.GetMark("yuqi_get"));
                List<string> choices = new List<string>();
                List<string> descript = new List<string> { "@shanshen" };
                if (distance > 0 && choiced != "distance")
                {
                    choices.Add("distance");
                    descript.Add("@xianjing-distance");
                }
                if (view > 0 && choiced != "view")
                {
                    choices.Add("view");
                    descript.Add("@xianjing-view");
                }
                if (give > 0 && choiced != "give")
                {
                    choices.Add("give");
                    descript.Add("@xianjing-give");
                }
                if (get > 0 && choiced != "get")
                {
                    choices.Add("get");
                    descript.Add("@xianjing-get");
                }

                if (choices.Count > 0)
                {
                    choices.Add("cancel");
                    string choice = room.AskForChoice(player, Name, string.Join("+", choices), descript, null, info.SkillPosition);
                    if (choice != "cancel")
                    {
                        switch (choice)
                        {
                            case "distance":
                                player.AddMark("yuqi_distance", 1);
                                player.AddMark("xianjing_distance", 1);
                                room.SetPlayerStringMark(player, "yuqi_distance", "+" + player.GetMark("yuqi_distance").ToString());
                                break;
                            case "view":
                                player.AddMark("yuqi_view", 1);
                                player.AddMark("xianjing_view", 1);
                                room.SetPlayerStringMark(player, "yuqi_view", "+" + player.GetMark("yuqi_view").ToString());
                                break;
                            case "give":
                                player.AddMark("yuqi_give", 1);
                                player.AddMark("xianjing_give", 1);
                                room.SetPlayerStringMark(player, "yuqi_give", "+" + player.GetMark("yuqi_give").ToString());
                                break;
                            case "get":
                                player.AddMark("yuqi_get", 1);
                                player.AddMark("xianjing_get", 1);
                                room.SetPlayerStringMark(player, "yuqi_get", "+" + player.GetMark("yuqi_get").ToString());
                                break;
                        }
                    }
                }
            }

            return false;
        }
    }

    public class Xingzuo : TriggerSkill
    {
        public Xingzuo() : base("xingzuo")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart };
            skill_type = SkillType.Wizzard;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Play)
                return new TriggerStruct(Name, player);
            else if (player != null && player.Alive && player.Phase == PlayerPhase.Finish && player.HasFlag(Name))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.Phase == PlayerPhase.Play && room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                player.SetFlags(Name);
                return info;
            }
            else if (player.Phase == PlayerPhase.Finish)
            {
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.Phase == PlayerPhase.Play)
            {
                List<int> ids = room.GetNCardsFromBottom(3, true);

                LogMessage log = new LogMessage
                {
                    Type = "$ViewDrawPileBottom2",
                    From = player.Name,
                    Arg = "3",
                };
                room.SendLog(log, new List<Player> { player });

                LogMessage log1 = new LogMessage
                {
                    Type = "$ViewDrawPileBottom",
                    From = player.Name,
                    Card_str = string.Join("+", JsonUntity.IntList2StringList(ids))
                };
                room.SendLog(log1, player);

                List<int> hands = player.GetCards("h");

                AskForMoveCardsStruct move = room.AskForMoveCards(player, hands, ids, false, Name, 3, 3, true, true, new List<int>(), info.SkillPosition);
                if (move.Success && move.Bottom.Count == 3)
                {
                    List<int> to_hand = move.Top.FindAll(t => !hands.Contains(t));
                    List<int> to_table = move.Bottom.FindAll(t => !ids.Contains(t));                   

                    CardsMoveStruct move1 = new CardsMoveStruct(to_hand, player, Place.PlaceHand, new CardMoveReason(MoveReason.S_REASON_GOTCARD, player.Name, Name, string.Empty));
                    CardsMoveStruct move2 = new CardsMoveStruct(to_table, null, Place.DrawPileBottom,
                        new CardMoveReason(MoveReason.S_REASON_PUT, player.Name, Name, string.Empty))
                    { From = player.Name };
                    List<CardsMoveStruct> exchangeMove = new List<CardsMoveStruct> { move1, move2 };
                    room.MoveCardsAtomic(exchangeMove, false);
                    room.ReturnToDrawPile(move.Bottom, true);
                }
            }
            else
            {
                List<Player> targets = new List<Player>();
                foreach (Player p in room.GetAlivePlayers())
                    if (!p.IsKongcheng()) targets.Add(p);

                if (targets.Count > 0)
                {
                    Player target = room.AskForPlayerChosen(player, targets, Name, "@xingzuo-bottom", true, true, info.SkillPosition);
                    if (target != null)
                    {
                        List<int> ids = room.GetNCardsFromBottom(3, true);
                        List<int> hands = target.GetCards("h");

                        CardsMoveStruct move1 = new CardsMoveStruct(ids, target, Place.PlaceHand, new CardMoveReason(MoveReason.S_REASON_GOTCARD, player.Name, target.Name, Name, string.Empty));
                        CardsMoveStruct move2 = new CardsMoveStruct(hands, null, Place.DrawPileBottom,
                            new CardMoveReason(MoveReason.S_REASON_PUT, player.Name, target.Name, Name, string.Empty))
                        { From = target.Name };
                        List <CardsMoveStruct> exchangeMove = new List<CardsMoveStruct> { move1, move2 };
                        room.MoveCardsAtomic(exchangeMove, false);

                        //room.ReturnToDrawPile(hands, true);

                        if (player.Alive && hands.Count > 3)
                            room.LoseHp(player);
                    }
                }
            }

            return false;
        }
    }

    public class Miaoxian : TriggerSkill
    {
        public Miaoxian() : base("miaoxian")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime };
            view_as_skill = new MiaoxianVS();
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardsMoveOneTimeStruct move && move.From_places.Contains(Place.PlaceHand) && (move.Reason.Reason == MoveReason.S_REASON_USE || move.Reason.Reason == MoveReason.S_REASON_LETUSE)
                && move.Card_ids.Count == 1 && WrappedCard.IsRed(room.GetCard(move.Card_ids[0]).Suit) && base.Triggerable(move.From, room))
            {
                bool check = true;
                foreach (int id in player.GetCards("h"))
                {
                    if (WrappedCard.IsRed(room.GetCard(id).Suit))
                    {
                        check = false;
                        break;
                    }
                }
                
                if (check) return new TriggerStruct(Name, move.From);
            }
            return new TriggerStruct();
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

    public class MiaoxianVS : ViewAsSkill
    {
        public MiaoxianVS() : base("miaoxian") { }

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player) => selected.Count == 0 && WrappedCard.IsBlack(to_select.Suit);
        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            if (!player.HasUsed("ViewAsSkill_miaoxianCard") && !player.IsKongcheng())
            {
                int count = 0;
                foreach (int id in player.GetCards("h"))
                    if (WrappedCard.IsBlack(room.GetCard(id).Suit))
                        count++;

                return count == 1;
            }
            return false;
        }

        public override List<WrappedCard> GetGuhuoCards(Room room, List<WrappedCard> cards, Player player)
        {
            List<WrappedCard> result = new List<WrappedCard>();
            if (cards.Count == 1)
            {
                foreach (string card_name in ViewAsSkill.GetGuhuoCards(room, "t"))
                {
                    WrappedCard card = new WrappedCard(card_name) { Skill = Name };
                    card.AddSubCards(cards);
                    card = RoomLogic.ParseUseCard(room, card);
                    result.Add(card);
                }
            }
            return result;
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count == 1 && cards[0].IsVirtualCard())
                return cards[0];
            return null;
        }
    }

    public class Qianlong : MasochismSkill
    {
        public Qianlong() : base("qianlong") { }
        public override void OnDamaged(Room room, Player target, DamageStruct damage, TriggerStruct info)
        {
            List<int> ids = room.GetNCards(3);
            AskForMoveCardsStruct result = room.AskForMoveCards(target, ids, new List<int>(), true, Name, 0, Math.Min(3, target.GetLostHp()), true, true, new List<int>(), info.SkillPosition);

            List<int> top_cards = result.Top, bottom_cards = result.Bottom;

            if (result.Success && bottom_cards.Count > 0)
                room.ObtainCard(target, ref bottom_cards, new CardMoveReason(MoveReason.S_REASON_GOTBACK, target.Name, Name, string.Empty));
            
            if (top_cards.Count > 0)
            {
                LogMessage log1 = new LogMessage
                {
                    Type = "$GuanxingBottom",
                    From = target.Name,
                    Card_str = string.Join("+", JsonUntity.IntList2StringList(top_cards))
                };
                room.SendLog(log1);
                room.ReturnToDrawPile(top_cards, true, target, true);
            }
        }
    }

    public class Fensi : TriggerSkill
    {
        public Fensi() : base("fensi")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            skill_type = SkillType.Attack;
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Start)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            List<Player> targets = new List<Player>();
            foreach (Player p in room.GetAlivePlayers())
                if (p.Hp >= player.Hp) targets.Add(p);

            Player target = room.AskForPlayerChosen(player, targets, Name, "@fensi", false, true, info.SkillPosition);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.Damage(new DamageStruct(Name, player, target));

            if (player.Alive && target.Alive && player != target)
            {
                WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = "_fensi", DistanceLimited = true };
                room.UseCard(new CardUseStruct(slash, target, player, false), true, true);
            }

            return false;
        }
    }

    public class Juetao : TriggerSkill
    {
        public Juetao() : base("juetao")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            skill_type = SkillType.Attack;
            frequency = Frequency.Limited;
            limit_mark = "@juetao";
            view_as_skill = new JuetaoVS();
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Play && player.Hp == 1 && player.GetMark(limit_mark) > 0)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@juetao-target", true, true, info.SkillPosition);
            if (target != null)
            {
                room.SetTag(Name, target);
                room.SetPlayerMark(player, limit_mark, 0);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.DoSuperLightbox(player, info.SkillPosition, Name);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is Player target)
            {
                while (player.Alive && target.Alive)
                {
                    int id = room.DrawPile[room.DrawPile.Count - 1];
                    player.PileChange("#juetao", new List<int> { id }, true);
                    WrappedCard card = room.AskForUseCard(player, RespondType.Skill, "@@juetao", "@juetao-choose:" + target.Name, null, -1, HandlingMethod.MethodUse, true, info.SkillPosition);
                    player.Piles["#juetao"].Clear();
                    if (card == null)
                        break;
                }

                room.RemoveTag(Name);
            }
            return false;
        }
    }

    public class JuetaoVS : OneCardViewAsSkill
    {
        public JuetaoVS() : base("juetao") { response_pattern = "@@juetao"; expand_pile = "#juetao"; }
        public override bool IsAvailable(Room room, Player invoker, CardUseReason reason, RespondType respond, string pattern, string position = null) => reason == CardUseReason.CARD_USE_REASON_RESPONSE_USE && pattern == response_pattern;
        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player) => card;
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player) => player.GetPile(expand_pile).Contains(to_select.Id);
    }
    public class JuetaoTag : TargetModSkill
    {
        public JuetaoTag() : base("#juetao-tar", false) { pattern = ".#@@juetao"; }
        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            if (reason == CardUseReason.CARD_USE_REASON_RESPONSE_USE && from.GetPile("#juetao").Contains(card.Id) && pattern == "@@juetao")
                return true;

            return false;
        }
    }

    public class JuetaoPro : ProhibitSkill
    {
        public JuetaoPro() : base("#juetao") { }
        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null)
        {
            if (from != null && from.GetPile("#juetao").Contains(card.Id))
            {
                return from == to || (room.ContainsTag("juetao") && room.GetTag("juetao") is Player target && target == to) ? false : true;
            }
            return false;
        }
    }

    public class Zhushi : TriggerSkill
    {
        public Zhushi() : base("zhushi")
        {
            events.Add(TriggerEvent.HpRecover);
            lord_skill = true;
            skill_type = SkillType.Replenish;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> result = new List<TriggerStruct>();
            if (player.Alive && player.Kingdom == "wei" && !player.HasFlag(Name))
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
            if (ask_who.Alive && caopi.Alive)
            {
                caopi.SetFlags("zhushi_target");
                bool invoke = room.AskForSkillInvoke(ask_who, Name, caopi);
                caopi.SetFlags("-zhushi_target");
                if (invoke)
                {
                    ask_who.SetFlags(Name);
                    room.NotifySkillInvoked(caopi, Name);
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, info.SkillOwner);
                    room.BroadcastSkillInvoke(Name, caopi, info.SkillPosition);
                    return info;
                }
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.DrawCards(player, new DrawCardStruct(1, ask_who, Name));
            return false;
        }
    }

    public class Choutao : TriggerSkill
    {
        public Choutao() : base("choutao")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsed, TriggerEvent.TargetChosen, TriggerEvent.TargetConfirmed };
            skill_type = SkillType.Attack;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName) && use.Card.HasFlag(Name))
            {
                for (int i = 0; i < use.EffectCount.Count; i++)
                {
                    CardBasicEffect effect = use.EffectCount[i];
                    effect.Effect2 = 0;

                    LogMessage log = new LogMessage
                    {
                        Type = "#NoJink",
                        From = effect.To.Name
                    };
                    room.SendLog(log);
                }
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName) && base.Triggerable(player, room) && !player.IsNude() && RoomLogic.CanDiscard(room, player, player, "he"))
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.TargetConfirmed && data is CardUseStruct _use && _use.Card.Name.Contains(Slash.ClassName) && base.Triggerable(player, room)
                && _use.From != null && _use.From.Alive && !_use.From.IsNude() && RoomLogic.CanDiscard(room, player, _use.From, "he"))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            CardUseStruct use = (CardUseStruct)data;
            if (triggerEvent == TriggerEvent.CardUsed && room.AskForDiscard(player, Name, 1, 1, true, true, "@choutao:::" + use.Card.Name, true, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            else if (triggerEvent == TriggerEvent.TargetConfirmed && room.AskForSkillInvoke(player, Name, use.From, info.SkillPosition))
            {
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, use.From.Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            CardUseStruct use = (CardUseStruct)data;
            if (triggerEvent == TriggerEvent.CardUsed)
            {
                use.Card.SetFlags(Name);
                if (use.AddHistory)
                {
                    use.AddHistory = false;
                    player.AddHistory(use.Card.Name, -1);
                    data = use;
                }
            }
            else
            {
                int id = room.AskForCardChosen(player, use.From, "he", Name, false, HandlingMethod.MethodDiscard);
                room.ThrowCard(id, use.From, player, Name);

                if (player.Alive)
                {
                    LogMessage log = new LogMessage
                    {
                        Type = "#NoJink",
                        From = player.Name
                    };
                    room.SendLog(log);

                    int index = 0;
                    for (int i = 0; i < use.EffectCount.Count; i++)
                    {
                        CardBasicEffect effect = use.EffectCount[i];
                        if (effect.To == player)
                        {
                            index++;
                            if (index == info.Times)
                            {
                                effect.Effect2 = 0;
                                break;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }

    public class Xiangshu : TriggerSkill
    {
        public Xiangshu() : base("xiangshu")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.Damage, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Recover;
            frequency = Frequency.Limited;
            limit_mark = "@xiangshu";
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Damage && player.GetMark(limit_mark) > 0 && player.Phase != PlayerPhase.NotActive)
                player.AddMark(Name);
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                player.SetMark(Name, 0);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.GetMark(limit_mark) > 0 && player.GetMark(Name) > 0 && player.Phase == PlayerPhase.Finish)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<Player> targets = new List<Player>();
            foreach (Player p in room.GetAlivePlayers())
                if (p.IsWounded()) targets.Add(p);

            if (targets.Count > 0)
            {
                Player target = room.AskForPlayerChosen(player, targets, Name, "@xiangshu-tar:::" + player.GetMark(Name).ToString(), true, true, info.SkillPosition);
                if (target != null)
                {
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    room.SetPlayerMark(player, limit_mark, 0);
                    room.SetTag(Name, target);
                    room.DoSuperLightbox(player, info.SkillPosition, Name);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is Player target)
            {
                room.RemoveTag(Name);
                int count = Math.Min(target.GetLostHp(), player.GetMark(Name));
                count = Math.Min(5, count);
                RecoverStruct recover = new RecoverStruct
                {
                    Recover = count,
                    Who = player
                };
                room.Recover(target, recover, true);

                if (target.Alive)
                {
                    int draw = Math.Min(5, player.GetMark(Name));
                    room.DrawCards(target, new DrawCardStruct(draw, player, Name));
                }
            }

            return false;
        }
    }

    public class Caiyi : TriggerSkill
    {
        public Caiyi() : base("caiyi")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.EventLoseSkill, TriggerEvent.EventAcquireSkill };
            skill_type = SkillType.Wizzard;
            turn = true;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventAcquireSkill && data is InfoStruct info && info.Info == Name)
            {
                room.SetTurnSkillState(player, Name, false, info.Head ? "head" : "deputy");
            }
            else if (triggerEvent == TriggerEvent.EventLoseSkill && data is InfoStruct _info && _info.Info == Name)
            {
                room.RemoveTurnSkill(player);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.Phase == PlayerPhase.Finish)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<string> choices = new List<string>();
            List<Player> targets = new List<Player>();
            if (player.GetMark(Name) == 0)
            {
                if (player.GetMark("caiyi_0") == 0)
                    choices.Add("recover");
                else if (player.GetMark("caiyi_3") == 0)
                    choices.Add("random_0");
                if (player.GetMark("caiyi_1") == 0)
                    choices.Add("draw");
                else if (!choices.Contains("random_0") && player.GetMark("caiyi_3") == 0)
                    choices.Add("random_0");
                if (player.GetMark("caiyi_2") == 0)
                    choices.Add("reset");
                else if (!choices.Contains("random_0") && player.GetMark("caiyi_3") == 0)
                    choices.Add("random_0");

                foreach (Player p in room.GetAlivePlayers())
                {
                    if ((p.IsWounded() && (choices.Contains("recover") || (choices.Contains("random_0") && player.GetMark("caiyi_0") == 1)))
                        || choices.Contains("draw") || (choices.Contains("random_0") && player.GetMark("caiyi_1") == 1)
                        || ((!p.FaceUp || p.Chained) && (choices.Contains("reset") || (choices.Contains("random_0") && player.GetMark("caiyi_2") == 1))))
                        targets.Add(p);
                }
            }
            else
            {
                if (player.GetMark("caiyi_4") == 0)
                    choices.Add("damaged");
                else if (player.GetMark("caiyi_7") == 0)
                    choices.Add("random_1");
                if (player.GetMark("caiyi_5") == 0)
                    choices.Add("discard");
                else if (!choices.Contains("random_1") && player.GetMark("caiyi_7") == 0)
                    choices.Add("random_1");
                if (player.GetMark("caiyi_6") == 0)
                    choices.Add("facedown");
                else if (!choices.Contains("random_1") && player.GetMark("caiyi_7") == 0)
                    choices.Add("random_1");

                foreach (Player p in room.GetAlivePlayers())
                {
                    if ((!p.IsNude() && RoomLogic.CanDiscard(room, p, p, "he") && (choices.Contains("discard") || (choices.Contains("random_1") && player.GetMark("caiyi_5") == 1)))
                        || choices.Contains("damaged") || (choices.Contains("random_1") && player.GetMark("caiyi_4") == 1)
                        || ((p.FaceUp || !p.Chained) && (choices.Contains("facedown") || (choices.Contains("random_1") && player.GetMark("caiyi_6") == 1))))
                        targets.Add(p);
                }
            }
            
            if (targets.Count > 0)
            {
                Player target = room.AskForPlayerChosen(player, targets, Name, "@caiyi", true, true, info.SkillPosition);
                if (target != null)
                {
                    room.SetTag(Name, target);
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is Player target)
            {
                room.RemoveTag(Name);
                List<string> choices = new List<string>();
                List<string> descriptions = new List<string>();
                List<string> rands = new List<string>();
                bool random_1 = false;
                bool random_2 = false;
                bool random_3 = false;
                int count = 0;
                if (player.GetMark(Name) == 0)
                {
                    count = player.GetMark("caiyi_3") == 0 ? 1 : 0;
                    if (player.GetMark("caiyi_0") == 0)
                    {
                        count++;
                        if (target.IsWounded()) choices.Add("recover");
                    }
                    else if (player.GetMark("caiyi_3") == 0 && target.IsWounded())
                    {
                        random_1 = true;
                        choices.Add("random_0");
                    }
                    if (player.GetMark("caiyi_1") == 0)
                    {
                        count++;
                        choices.Add("draw");
                    }
                    else if (player.GetMark("caiyi_3") == 0)
                    {
                        random_2 = true;
                        if (!choices.Contains("random_0")) choices.Add("random_0");
                    }
                    if (player.GetMark("caiyi_2") == 0)
                    {
                        count++;
                        if (!target.FaceUp || target.Chained) choices.Add("reset");
                    }
                    else if (player.GetMark("caiyi_3") == 0 && (!target.FaceUp || target.Chained))
                    {
                        random_3 = true;
                        if (!choices.Contains("random_0")) choices.Add("random_0");
                    }
                    descriptions.Add(string.Format("@caiyi-choose:{0}::{1}", player.Name, count.ToString()));
                    if (random_1) rands.Add("recover");
                    if (random_2) rands.Add("draw");
                    if (random_3) rands.Add("reset");

                    if (choices.Contains("random_0"))
                    {
                        choices.Remove("random_0");
                        if (rands.Count > 1)
                        {
                            choices.Insert(0, "random_0");
                            string random = "@caiyi_";
                            foreach (string choice in rands)
                                random += choice;
                            descriptions.Add(random);
                        }
                        else
                            choices.Add(rands[0]);
                    }
                }
                else
                {
                    count = player.GetMark("caiyi_7") == 0 ? 1 : 0;
                    if (player.GetMark("caiyi_4") == 0)
                    {
                        count++;
                        choices.Add("damaged");
                    }
                    else if (player.GetMark("caiyi_7") == 0)
                    {
                        random_1 = true;
                        choices.Add("random_1");
                    }
                    if (player.GetMark("caiyi_5") == 0)
                    {
                        count++;
                        if (!target.IsNude() && RoomLogic.CanDiscard(room, target, target, "he")) choices.Add("discard");
                    }
                    else if (player.GetMark("caiyi_7") == 0 && !target.IsNude() && RoomLogic.CanDiscard(room, target, target, "he"))
                    {
                        random_2 = true;
                        if (!choices.Contains("random_1")) choices.Add("random_1");
                    }
                    if (player.GetMark("caiyi_6") == 0)
                    {
                        count++;
                        if (target.FaceUp || !target.Chained) choices.Add("facedown");
                    }
                    else if (player.GetMark("caiyi_7") == 0 && (target.FaceUp || !target.Chained))
                    {
                        random_3 = true;
                        if (!choices.Contains("random_1")) choices.Add("random_1");
                    }
                    descriptions.Add(string.Format("@caiyi-choose:{0}::{1}", player.Name, count.ToString()));
                    if (random_1) rands.Add("damaged");
                    if (random_2) rands.Add("discard");
                    if (random_3) rands.Add("facedown");

                    //如果可选项>1，在可弃牌数不满足要求时，无法选择该选项
                    if (choices.Count > 1 && choices.Contains("discard"))
                    {
                        int dis = 0;
                        foreach (int id in target.GetCards("he"))
                            if (RoomLogic.CanDiscard(room, target, target, id)) dis++;

                        if (dis < count) choices.Remove("discard");
                    }
                    if (rands.Contains("discard") && (choices.Count > 1 || rands.Count > 1))
                    {
                        int dis = 0;
                        foreach (int id in target.GetCards("he"))
                            if (RoomLogic.CanDiscard(room, target, target, id)) dis++;

                        if (dis < count)
                        {
                            rands.Remove("discard");
                            if (rands.Count == 0) choices.Remove("random_1");
                        }
                    }

                    if (choices.Contains("random_1"))
                    {
                        choices.Remove("random_1");
                        if (rands.Count > 1)
                        {
                            choices.Insert(0, "random_1");
                            string random = "@caiyi_";
                            foreach (string choice in rands)
                                random += choice;
                            descriptions.Add(random);
                        }
                        else
                            choices.Add(rands[0]);
                    }
                }
                int mark = player.GetMark(Name) == 0 ? 1 : 0;
                player.SetMark(Name, mark);
                room.SetTurnSkillState(player, Name, mark == 1, info.SkillPosition);

                if (choices.Count > 0)
                {
                    string choice = room.AskForChoice(target, Name, string.Join("+", choices), descriptions, count);
                    switch (choice)
                    {
                        case "recover":
                            player.AddMark("caiyi_0");
                            {
                                int re = Math.Min(count, target.GetLostHp());
                                RecoverStruct recover = new RecoverStruct
                                {
                                    Who = player,
                                    Recover = re
                                };
                                room.Recover(target, recover, true);
                            }
                            break;
                        case "draw":
                            player.AddMark("caiyi_1");
                            room.DrawCards(target, new DrawCardStruct(count, player, Name));
                            break;
                        case "reset":
                            player.AddMark("caiyi_2");
                            if (target.Chained)
                                room.SetPlayerChained(target, false, true);
                            if (target.Alive && !target.FaceUp)
                                room.TurnOver(target);
                            break;
                        case "random_0":
                            player.AddMark("caiyi_3");
                            {
                                Shuffle.shuffle(ref rands);
                                switch (rands[0])
                                {
                                    case "recover":
                                        {
                                            int re = Math.Min(count, target.GetLostHp());
                                            RecoverStruct recover = new RecoverStruct
                                            {
                                                Who = player,
                                                Recover = re
                                            };
                                            room.Recover(target, recover, true);
                                        }
                                        break;
                                    case "draw":
                                        room.DrawCards(target, new DrawCardStruct(count, player, Name));
                                        break;
                                    case "reset":
                                        if (target.Chained)
                                            room.SetPlayerChained(target, false, true);
                                        if (target.Alive && !target.FaceUp)
                                            room.TurnOver(target);
                                        break;
                                }
                            }
                            break;
                        case "damaged":
                            player.AddMark("caiyi_4");
                            room.Damage(new DamageStruct(Name, player, target, count));
                            break;
                        case "discard":
                            player.AddMark("caiyi_5");
                            room.AskForDiscard(target, Name, count, count, false, true, string.Format("@caiyi-disacard:{0}::{1}", player.Name, count));
                            break;
                        case "facedown":
                            player.AddMark("caiyi_6");
                            if (target.FaceUp)
                                room.TurnOver(target);
                            if (target.Alive && !target.Chained)
                                room.SetPlayerChained(target, true, true);
                            break;
                        case "random_1":
                            player.AddMark("caiyi_7");
                            {
                                Shuffle.shuffle(ref rands);
                                switch (rands[0])
                                {
                                    case "damaged":
                                        room.Damage(new DamageStruct(Name, player, target, count));
                                        break;
                                    case "discard":
                                        room.AskForDiscard(target, Name, count, count, false, true, string.Format("@caiyi-disacard:{0}::{1}", player.Name, count));
                                        break;
                                    case "facedown":
                                        if (target.FaceUp)
                                            room.TurnOver(target);
                                        if (target.Alive && !target.Chained)
                                            room.SetPlayerChained(target, true, true);
                                        break;
                                }
                                break;
                            }
                    }
                }
            }
            return false;
        }
    }

    public class Guili : TriggerSkill
    {
        public Guili() : base("guili")
        {
            events = new List<TriggerEvent> { TriggerEvent.TurnStart, TriggerEvent.Damage, TriggerEvent.EventPhaseChanging, TriggerEvent.RoundStart };
            skill_type = SkillType.Wizzard;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Damage && player.ContainsTag(Name) && player.GetMark("guili_turn") == 0)
                player.SetFlags(Name);
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player.ContainsTag(Name))
            {
                player.AddMark("guili_turn");
                if (player.GetMark("guili_turn") == 1 && !player.HasFlag(Name) && player.GetTag(Name) is List<string> target_names)
                {
                    List<Player> targets = new List<Player>();
                    foreach (string player_name in target_names)
                    {
                        Player target = room.FindPlayer(player_name);
                        if (target != null && RoomLogic.PlayerHasSkill(room, target, Name)) targets.Add(target);
                    }

                    if (targets.Count > 0)
                    {
                        room.SortByActionOrder(ref targets);
                        foreach (Player p in targets)
                        {
                            room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, p.Name);
                            LogMessage log = new LogMessage
                            {
                                Type = "#guili",
                                From = p.Name
                            };
                            room.SendLog(log);
                            room.GainAnExtraTurn(p);
                        }
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.RoundStart)
                foreach (Player p in room.GetAlivePlayers())
                    p.SetMark("guili_turn", 0);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TurnStart && base.Triggerable(player, room) && player.GetMark(Name) == 0)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@guili", true, true, info.SkillPosition);
            if (target != null)
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                player.AddMark(Name);
                List<string> names = target.ContainsTag(Name) ? (List<string>)target.GetTag(Name) : new List<string>();
                names.Add(player.Name);
                target.SetTag(Name, names);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info) => false;
    }

    public class Deshao : TriggerSkill
    {
        public Deshao() : base("deshao")
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
                && use.From != player && base.Triggerable(player, room) && player.GetMark(Name) < 2)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                player.AddMark(Name);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.DrawCards(player, 1, Name);
            if (data is CardUseStruct use && use.From.Alive && player.Alive && use.From.HandcardNum >= player.HandcardNum
                && !use.From.IsNude() && RoomLogic.CanDiscard(room, player, use.From, "he"))
            {
                List<int> ids = new List<int> { room.AskForCardChosen(player, use.From, "he", Name, false, HandlingMethod.MethodDiscard) };
                room.ThrowCard(ref ids, new CardMoveReason(MoveReason.S_REASON_DISMANTLE, player.Name, use.From.Name, Name, string.Empty), use.From, player);
            }
            return false;
        }
    }

    public class Mingfa : TriggerSkill
    {
        public Mingfa() : base("mingfa")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardFinished, TriggerEvent.Death, TriggerEvent.EventPhaseStart };
            skill_type = SkillType.Wizzard;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Death)
            {
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.ContainsTag(Name) && p.GetTag(Name) is string target && target == player.Name)
                    {
                        p.RemoveTag(Name);
                        room.ClearOnePrivatePile(p, Name);
                    }
                }
            }
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.CardFinished && data is CardUseStruct use && base.Triggerable(player, room) && player.Phase == PlayerPhase.Play && use.To.Count > 0
                && !use.Card.IsVirtualCard() && use.Card.Name == room.GetCard(use.Card.GetEffectiveId()).Name && room.GetCardPlace(use.Card.GetEffectiveId()) == Place.DiscardPile
                && player.GetPile(Name).Count == 0 && !player.HasFlag(Name))
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is Slash || fcard.IsNDTrick())
                    triggers.Add(new TriggerStruct(Name, player));
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart && player.Alive && player.Phase == PlayerPhase.Finish)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                {
                    if (p.ContainsTag(Name) && p.GetTag(Name) is string target && target == player.Name && p.GetPile(Name).Count > 0)
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.CardFinished && data is CardUseStruct use)
            {
                WrappedCard card = room.GetCard(use.Card.GetEffectiveId());
                FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                List<Player> targets = new List<Player>();
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (card.Name != ExNihilo.ClassName && card.Name != GodSalvation.ClassName && card.Name != AmazingGrace.ClassName && player == p) continue;
                    targets.Add(p);
                }
                if (targets.Count > 0)
                {
                    Player target = room.AskForPlayerChosen(player, targets, Name, string.Format("@mingfa:::{0}", card.Name), true, true, info.SkillPosition);
                    if (target != null)
                    {
                        room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                        player.SetFlags(Name);
                        player.SetTag(Name, target.Name);
                        room.AddToPile(player, Name, card.Id, true);
                        return info;
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                int count = player.HandcardNum;
                count = Math.Max(1, count);
                count = Math.Min(5, count);
                string card_name = room.GetCard(ask_who.GetPile(Name)[0]).Name;
                room.ClearOnePrivatePile(ask_who, Name);
                ask_who.RemoveTag(Name);
                FunctionCard fcard = Engine.GetFunctionCard(card_name);
                
                while (ask_who.Alive && player.Alive && count > 0)
                {
                    WrappedCard card = new WrappedCard(card_name) { Skill = "_mingfa", DistanceLimited = false };
                    if (fcard.TargetFilter(room, new List<Player>(), player, ask_who, card) || (fcard.TargetFixed(card) && RoomLogic.IsProhibited(room, ask_who, player, card) == null))
                    {
                        count--;
                        room.UseCard(new CardUseStruct(card, ask_who, player, false), true);
                    }
                    else
                        break;
                }
            }
            return false;
        }
    }

    public class Fuping : TriggerSkill
    {
        public Fuping() : base("fuping")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardFinished, TriggerEvent.EventPhaseChanging, TriggerEvent.CardUsedAnnounced, TriggerEvent.CardResponded };
            skill_type = SkillType.Wizzard;
            view_as_skill = new FupingVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardUsedAnnounced && data is CardUseStruct use && use.Card.GetSkillName() == Name)
            {
                string flag = string.Format("{0}_{1}", Name, use.Card.Name.Contains(Slash.ClassName) ? Slash.ClassName : use.Card.Name);
                player.SetFlags(flag);
            }
            else if (triggerEvent == TriggerEvent.CardResponded && data is CardResponseStruct resp && resp.Card.GetSkillName() == Name)
            {
                string flag = string.Format("{0}_{1}", Name, resp.Card.Name.Contains(Slash.ClassName) ? Slash.ClassName : resp.Card.Name);
                player.SetFlags(flag);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triiggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.CardFinished && data is CardUseStruct use && !Engine.IsSkillCard(use.Card.Name) && use.Card.Name != Jink.ClassName)
            {
                string card_name = use.Card.Name.Contains(Slash.ClassName) ? Slash.ClassName : use.Card.Name;
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                {
                    if (p != player && use.To.Contains(p) && (!p.ContainsTag(Name) || (p.GetTag(Name) is List<string> cards && !cards.Contains(card_name))))
                    {
                        for (int i = 0; i <5; i++)
                        {
                            if (!p.EquipIsBaned(i))
                            {
                                triiggers.Add(new TriggerStruct(Name, p));
                                break;
                            }
                        }
                    }
                }
            }

            return triiggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player _, ref object data, Player player, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                string card_name = use.Card.Name.Contains(Slash.ClassName) ? Slash.ClassName : use.Card.Name;
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
                                choices.Add("DefensiveHorse");
                                break;
                            case 3:
                                choices.Add("OffensiveHorse");
                                break;
                            case 4:
                                choices.Add("Treasure");
                                break;
                        }
                    }
                }
                choices.Add("cancel");
                string choice = room.AskForChoice(player, Name, string.Join("+", choices), new List<string> { "@fuping:::" + card_name }, null, info.SkillPosition);
                if (choice != "cancel")
                {
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    room.NotifySkillInvoked(player, Name);
                    int index = -1;
                    switch (choice)
                    {
                        case "Weapon":
                            index = 0;
                            break;
                        case "Armor":
                            index = 1;
                            break;
                        case "DefensiveHorse":
                            index = 2;
                            break;
                        case "OffensiveHorse":
                            index = 3;
                            break;
                        case "Treasure":
                            index = 4;
                            break;
                    }
                    room.AbolisheEquip(player, index, Name);
                    if (player.Alive)
                    {
                        List<string> cards = player.ContainsTag(Name) ? (List<string>)player.GetTag(Name) : new List<string>();
                        cards.Add(card_name);
                        player.SetTag(Name, cards);
                        return info;
                    }
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info) => false;
    }

    public class FupingVS : ViewAsSkill
    {
        public FupingVS() : base("fuping") { response_or_use = true; }
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            if (selected.Count == 0 && !(Engine.GetFunctionCard(to_select.Name) is BasicCard))
            {
                if (room.GetRoomState().GetCurrentCardUseReason() == CardUseReason.CARD_USE_REASON_PLAY || room.GetRoomState().GetCurrentCardUseReason() == CardUseReason.CARD_USE_REASON_RESPONSE_USE)
                    return !RoomLogic.IsCardLimited(room, player, to_select, HandlingMethod.MethodUse, room.GetCardPlace(to_select.Id) == Place.PlaceHand);
                else
                    return !RoomLogic.IsCardLimited(room, player, to_select, HandlingMethod.MethodResponse, room.GetCardPlace(to_select.Id) == Place.PlaceHand);
            }
            return false;
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            if (player.ContainsTag(Name) && player.GetTag(Name) is List<string> cards)
            {
                foreach (string card in cards)
                {
                    string flag = string.Format("{0}_{1}", Name, card);
                    if (!player.HasFlag(flag))
                        return true;
                }
            }
            return false;
        }

        public override bool IsEnabledAtResponse(Room room, Player player, RespondType respond, string pattern)
        {
            if (player.ContainsTag(Name) && player.GetTag(Name) is List<string> cards)
            {
                if (MatchSlash(respond) && cards.Contains(Slash.ClassName) && !player.HasFlag("fuping_Slash"))
                    return true;

                if (MatchAnaleptic(respond) && cards.Contains(Analeptic.ClassName) && !player.HasFlag("fuping_Analeptic"))
                    return true;

                if (MatchPeach(respond) && cards.Contains(Peach.ClassName) && !player.HasFlag("fuping_Peach"))
                    return true;
            }
            return false;
        }

        public override List<WrappedCard> GetGuhuoCards(Room room, List<WrappedCard> cards, Player player)
        {
            List<WrappedCard> result = new List<WrappedCard>();
            if (cards.Count == 1 && player.ContainsTag(Name) && player.GetTag(Name) is List<string> all)
            {
                if (room.GetRoomState().GetCurrentCardUseReason() == CardUseReason.CARD_USE_REASON_PLAY)
                {
                    foreach (string card in all)
                    {
                        string flag = string.Format("{0}_{1}", Name, card);
                        if (!player.HasFlag(flag))
                        {
                            WrappedCard wrapped = new WrappedCard(card) { Skill = Name };
                            wrapped.AddSubCards(cards);
                            wrapped = RoomLogic.ParseUseCard(room, wrapped);

                            result.Add(wrapped);
                            if (card == Slash.ClassName)
                            {
                                WrappedCard fire = new WrappedCard(FireSlash.ClassName) { Skill = Name };
                                fire.AddSubCards(cards);
                                fire = RoomLogic.ParseUseCard(room, fire);
                                WrappedCard thunder = new WrappedCard(ThunderSlash.ClassName) { Skill = Name };
                                thunder.AddSubCards(cards);
                                thunder = RoomLogic.ParseUseCard(room, thunder);
                                result.Add(fire);
                                result.Add(thunder);
                            }
                        }
                    }
                }
                else
                {
                    if (all.Contains(Slash.ClassName) && !player.HasFlag("fuping_Slash"))
                    {
                        WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = Name };
                        slash.AddSubCards(cards);
                        slash = RoomLogic.ParseUseCard(room, slash);
                        WrappedCard fire = new WrappedCard(FireSlash.ClassName) { Skill = Name };
                        fire.AddSubCards(cards);
                        fire = RoomLogic.ParseUseCard(room, fire);
                        WrappedCard thunder = new WrappedCard(ThunderSlash.ClassName) { Skill = Name };
                        thunder.AddSubCards(cards);
                        thunder = RoomLogic.ParseUseCard(room, thunder);
                        result.Add(slash);
                        result.Add(fire);
                        result.Add(thunder);
                    }
                    if (all.Contains(Analeptic.ClassName) && !player.HasFlag("fuping_Analeptic"))
                    {
                        WrappedCard thunder = new WrappedCard(Analeptic.ClassName) { Skill = Name };
                        thunder.AddSubCards(cards);
                        thunder = RoomLogic.ParseUseCard(room, thunder);
                        result.Add(thunder);
                    }
                    if (all.Contains(Peach.ClassName) && !player.HasFlag("fuping_Peach"))
                    {
                        WrappedCard thunder = new WrappedCard(Peach.ClassName) { Skill = Name };
                        thunder.AddSubCards(cards);
                        thunder = RoomLogic.ParseUseCard(room, thunder);
                        result.Add(thunder);
                    }
                }
            }
            return result;
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count > 0 && cards[0].IsVirtualCard())
                return cards[0];
            return null;
        }
    }

    public class FupingTar : TargetModSkill
    {
        public FupingTar() : base("#fuping", false) { pattern = "."; }
        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            if (RoomLogic.PlayerHasSkill(room, from, "fuping"))
            {
                bool invoke = true;
                for (int i = 0; i < 5; i++)
                {
                    if (!from.EquipIsBaned(i))
                    {
                        invoke = false;
                        break;
                    }
                }
                return invoke;
            }
            return false;
        }
    }

    public class Weilie : OneCardViewAsSkill
    {
        public Weilie() : base("weilie") { }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            int count = player.ContainsTag("fuping") ? ((List<string>)player.GetTag("fuping")).Count : 0;
            return player.GetMark(Name) < 1 + count;
        }

        public override bool ViewFilter(Room room, WrappedCard to_select, Player player) => RoomLogic.CanDiscard(room, player, player, to_select.Id);

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard wl = new WrappedCard(WeilieCard.ClassName) { Skill = Name };
            wl.AddSubCard(card);
            return wl;
        }
    }

    public class WeilieCard : SkillCard
    {
        public static string ClassName = "WeilieCard";
        public WeilieCard() : base(ClassName) { will_throw = true; }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card) => targets.Count == 0 && to_select.IsWounded();
        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            player.AddMark("weilie");
            RecoverStruct recover = new RecoverStruct
            {
                Who = player,
                Recover = 1
            };
            room.Recover(target, recover, true);
            if (target.Alive && target.IsWounded())
                room.DrawCards(target, new DrawCardStruct(1, player, "weilie"));
        }
    }

    public class Poyuan : TriggerSkill
    {
        public Poyuan() : base("poyuan")
        {
            events = new List<TriggerEvent> { TriggerEvent.TurnStart, TriggerEvent.GameStart };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.GameStart && base.Triggerable(player, room))
            {
                foreach (int id in Engine.GetEngineCards())
                {
                    WrappedCard real_card = Engine.GetRealCard(id);
                    if (real_card.Name == Trebuchet.ClassName && room.GetCard(id) == null)
                    {
                        room.AddNewCard(id);
                        break;
                    }
                }
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who) => base.Triggerable(player, room) ? new TriggerStruct(Name, player) : new TriggerStruct();

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.HasEquip(Trebuchet.ClassName))
            {
                List<Player> targets = new List<Player>();
                foreach (Player p in room.GetOtherPlayers(player))
                    if (p.HasEquip() && RoomLogic.CanDiscard(room, player, p, "e"))
                        targets.Add(p);
                if (targets.Count > 0)
                {
                    Player target = room.AskForPlayerChosen(player, targets, Name, "@poyuan", true, true, info.SkillPosition);
                    if (target != null)
                    {
                        room.SetTag(Name, target);
                        room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                        return info;
                    }
                }
            }
            else if (room.AskForDiscard(player, Name, 1, 1, true, true, "@poyuan-equip", true, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.HasEquip(Trebuchet.ClassName) && room.GetTag(Name) is Player target)
            {
                room.RemoveTag(Name);
                List<int> ids = room.AskForCardsChosen(player, target, "e", Name, 1, 2, false, HandlingMethod.MethodDiscard);
                if (ids.Count > 0)
                    room.ThrowCard(ref ids, new CardMoveReason(MoveReason.S_REASON_DISMANTLE, player.Name, target.Name, Name, string.Empty), target, player);
            }
            else if (!player.HasEquip(Trebuchet.ClassName))
            {
                int catapult = -1;
                foreach (int id in room.RoomCards)
                {
                    WrappedCard card = room.GetCard(id);
                    if (card.Name == Trebuchet.ClassName)
                    {
                        catapult = id;
                        break;
                    }
                }
                if (catapult == -1) return false;
                
                int equipped_id = -1;
                if (player.GetTreasure())
                    equipped_id = player.Weapon.Key;
                List<CardsMoveStruct> exchangeMove = new List<CardsMoveStruct>();
                if (equipped_id != -1)
                {
                    CardsMoveStruct move1 = new CardsMoveStruct(new List<int> { equipped_id }, player, Player.Place.PlaceTable,
                        new CardMoveReason(MoveReason.S_REASON_CHANGE_EQUIP, player.Name));
                    exchangeMove.Add(move1);
                    room.MoveCardsAtomic(exchangeMove, true);
                }
                CardsMoveStruct move2 = new CardsMoveStruct(new List<int> { catapult }, room.GetCardOwner(catapult), player, room.GetCardPlace(catapult),
                                      Place.PlaceEquip, new CardMoveReason(MoveReason.S_REASON_PUT, player.Name, Name, string.Empty));
                exchangeMove.Add(move2);
                room.MoveCardsAtomic(exchangeMove, true);

                LogMessage log = new LogMessage
                {
                    From = player.Name,
                    Type = "$Install",
                    Card_str = catapult.ToString()
                };
                room.SendLog(log);

                if (equipped_id != -1)
                {
                    if (room.GetCardPlace(equipped_id) == Place.PlaceTable)
                    {
                        CardsMoveStruct move3 = new CardsMoveStruct(new List<int> { equipped_id }, null, Player.Place.DiscardPile,
                           new CardMoveReason(MoveReason.S_REASON_CHANGE_EQUIP, player.Name));
                        room.MoveCardsAtomic(new List<CardsMoveStruct> { move3 }, true);
                    }
                }
            }

            return false;
        }
    }

    public class Huace : TriggerSkill
    {
        public Huace() : base("huace")
        {
            events = new List<TriggerEvent> { TriggerEvent.RoundStart, TriggerEvent.CardUsedAnnounced };
            skill_type = SkillType.Alter;
            view_as_skill = new HuaceVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.RoundStart)
            {
                room.SetTag("huace_cards", room.GetTag(Name));
                room.RemoveTag(Name);
            }
            else if (data is CardUseStruct use && Engine.GetFunctionCard(use.Card.Name).IsNDTrick())
            {
                List<string> cards = room.ContainsTag(Name) ? (List<string>)room.GetTag(Name) : new List<string>();
                if (!cards.Contains(use.Card.Name))
                {
                    cards.Add(use.Card.Name);
                    room.SetTag(Name, cards);
                }
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data) => new List<TriggerStruct>();
    }

    public class HuaceVS : ViewAsSkill
    {
        public HuaceVS() : base("huace") { response_or_use = true; }
        public override bool IsEnabledAtPlay(Room room, Player player) => player.UsedTimes("ViewAsSkill_huaceCard") < 1;
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
            => selected.Count == 0 && room.GetCardPlace(to_select.Id) != Place.PlaceEquip && !RoomLogic.IsCardLimited(room, player, to_select, HandlingMethod.MethodUse, true);
        public override List<WrappedCard> GetGuhuoCards(Room room, List<WrappedCard> cards, Player player)
        {
            List<WrappedCard> results = new List<WrappedCard>();
            if (cards.Count == 1)
            {
                List<string> choices = ViewAsSkill.GetGuhuoCards(room, "t");
                if (room.ContainsTag("huace_cards") && room.GetTag("huace_cards") is List<string> used)
                    choices.RemoveAll(t => used.Contains(t));

                foreach (string card_name in choices)
                {
                    WrappedCard card = new WrappedCard(card_name) { Skill = Name, ShowSkill = Name };
                    card.AddSubCards(cards);
                    card = RoomLogic.ParseUseCard(room, card);
                    results.Add(card);
                }
            }
            return results;
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count == 1 && cards[0].IsVirtualCard())
                return cards[0];
            return null;
        }
    }

    public class Fenyan : TriggerSkill
    {
        public Fenyan() : base("fenyan")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging };
            view_as_skill = new FenyanVS();
            skill_type = SkillType.Attack;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is PhaseChangeStruct change && change.From == PlayerPhase.Play)
            {
                player.SetFlags("-fenyan_hp");
                player.SetFlags("-fenyan_card");
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who) => new TriggerStruct();
    }

    public class FenyanVS : ZeroCardViewAsSkill
    {
        public FenyanVS() : base("fenyan") { }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasFlag("fenyan_hp") || !player.HasFlag("fenyan_card");
        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(FenyanCard.ClassName) { Skill = Name };
    }

    public class FenyanCard : SkillCard
    {
        public static string ClassName = "FenyanCard";
        public FenyanCard() : base(ClassName) { }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            if (targets.Count == 0 && to_select != Self)
            {
                if (!to_select.IsKongcheng() && to_select.Hp <= Self.Hp && !Self.HasFlag("fenyan_hp"))
                    return true;
                else if (to_select.HandcardNum <= Self.HandcardNum && !Self.HasFlag("fenyan_card"))
                {
                    WrappedCard slash = new WrappedCard(Slash.ClassName) { DistanceLimited = false };
                    return RoomLogic.IsProhibited(room, Self, to_select, slash) == null;
                }
            }
            return false;
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            List<string> choices = new List<string>();
            if (!target.IsKongcheng() && target.Hp <= player.Hp && !player.HasFlag("fenyan_hp"))
                choices.Add("hp");

            WrappedCard slash = new WrappedCard(Slash.ClassName) { DistanceLimited = false, Skill = "_fenyan" };
            if (target.HandcardNum <= player.HandcardNum && !player.HasFlag("fenyan_card") && RoomLogic.IsProhibited(room, player, target, slash) == null)
                choices.Add("handcard");

            string choice = room.AskForChoice(player, "fenyan", string.Join("+", choices), new List<string> { "@to-player:" + target.Name }, target, card_use.Card.SkillPosition);
            if (choice == "hp")
            {
                player.SetFlags("fenyan_hp");
                List<int> ids = room.AskForExchange(target, "fenyan", 1, 1, "@fenyan-give:" + player.Name, string.Empty, ".", string.Empty);
                if (ids.Count > 0) room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, target.Name, player.Name, "fenyan", string.Empty), false);
            }
            else
            {
                player.SetFlags("fenyan_card");
                room.UseCard(new CardUseStruct(slash, player, target, true), false, true);
            }
        }
    }

    public class Fudao : TriggerSkill
    {
        public Fudao() : base("fudao")
        {
            events = new List<TriggerEvent> { TriggerEvent.GameStart, TriggerEvent.TargetChosen, TriggerEvent.Death, TriggerEvent.DamageCaused };
            frequency = Frequency.Compulsory;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Death && data is DeathStruct death && death.Damage.From != null && death.Damage.From.Alive)
            {
                Player from = null, to = null;
                if (player.ContainsTag(Name))
                {
                    from = player;
                    if (from.ContainsTag(Name) && from.GetTag(Name) is string target_name)
                        to = room.FindPlayer(target_name, true);
                }
                else if (player.ContainsTag("fudao_from") && player.GetTag("fudao_from") is string from_name)
                {
                    to = player;
                    from = room.FindPlayer(from_name, true);
                }
                if (from != null && to != null && from != death.Damage.From && to != death.Damage.From && (from.Alive || to.Alive))
                {
                    Player who = from.Alive ? from : to;
                    death.Damage.From.SetTag("fudao_damage", who.Name);
                    room.SetPlayerStringMark(death.Damage.From, "rupture", string.Empty);
                }
            }
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.GameStart && base.Triggerable(player, room))
                triggers.Add(new TriggerStruct(Name, player));
            else if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use && !Engine.IsSkillCard(use.Card.Name) && player != null && player.Alive)
            {
                if (player.ContainsTag(Name) && player.GetTag(Name) is string target_name && !player.HasFlag(Name))
                {
                    foreach (Player p in use.To)
                    {
                        if (p.Name == target_name && !p.HasFlag(Name))
                        {
                            triggers.Add(new TriggerStruct(Name, player, new List<Player> { p }));
                            break;
                        }
                    }
                }
                else if (player.ContainsTag("fudao_from") && player.GetTag("fudao_from") is string from_name && !player.HasFlag(Name))
                {
                    foreach (Player p in use.To)
                    {
                        if (p.Name == from_name && !p.HasFlag(Name))
                        {
                            triggers.Add(new TriggerStruct(Name, player, p));
                            break;
                        }
                    }
                }
                if (WrappedCard.IsBlack(use.Card.Suit) && player.ContainsTag("fudao_damage") && player.GetTag("fudao_damage") is string from)
                {
                    foreach (Player p in use.To)
                    {
                        if (p.Name == from && from.Contains(Name))
                        {
                            triggers.Add(new TriggerStruct(Name, player, p));
                            break;
                        }
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.DamageCaused && data is DamageStruct damage && damage.To.Alive && player != null && player.Alive && damage.To.ContainsTag("fudao_damage")
                && damage.To.GetTag("fudao_damage") is string from && from == player.Name)
                triggers.Add(new TriggerStruct(Name, player));

            return triggers;
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.GameStart)
            {
                Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@fudao", false, true, info.SkillPosition);
                if (target != null)
                {
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    player.SetTag(Name, target.Name);
                    target.SetTag("fudao_from", player.Name);
                    room.SetPlayerStringMark(target, Name, string.Empty);
                }
            }
            else if (triggerEvent == TriggerEvent.DamageCaused && data is DamageStruct damage)
            {
                LogMessage log = new LogMessage
                {
                    Type = "#AddDamage",
                    From = player.Name,
                    To = new List<string> { damage.To.Name },
                    Arg = "rupture",
                    Arg2 = (++damage.Damage).ToString()
                };
                room.SendLog(log);

                data = damage;
            }
            else if (triggerEvent == TriggerEvent.TargetChosen)
            {
                bool draw = false;
                if (ask_who.ContainsTag(Name) && ask_who.GetTag(Name) is string target_name && player.Name == target_name && !ask_who.HasFlag(Name) && !player.HasFlag(Name))
                    draw = true;
                else if (ask_who.ContainsTag("fudao_from") && ask_who.GetTag("fudao_from") is string from_name && from_name == player.Name && !ask_who.HasFlag(Name) && !player.HasFlag(Name))
                    draw = true;

                if (draw)
                {
                    ask_who.SetFlags(Name);
                    player.SetFlags(Name);
                    List<Player> players = new List<Player> { player, ask_who };
                    Player from = player.ContainsTag(Name) ? player : ask_who;
                    room.SortByActionOrder(ref players);
                    room.SendCompulsoryTriggerLog(from, Name);
                    room.BroadcastSkillInvoke(Name, from, info.SkillPosition);
                    foreach (Player p in players)
                        if (p.Alive) room.DrawCards(p, new DrawCardStruct(2, from, Name));
                }

                if (ask_who.ContainsTag("fudao_damage") && ask_who.GetTag("fudao_damage") is string from_player && from_player == player.Name && player.ContainsTag(Name))
                {
                    LogMessage log = new LogMessage("#fudao-pro");
                    log.From = ask_who.Name;
                    log.Arg = "rupture";
                    room.SendLog(log);

                    ask_who.SetFlags("fudao_pro");
                }
            }
            return false;
        }
    }

    public class FudaoPro : ProhibitSkill
    {
        public FudaoPro() : base("#fudao") { }
        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null) => from != null && from.HasFlag("fudao_pro");
    }

    public class Tunan : ViewAsSkill
    {
        public Tunan() : base("tunan")
        {
        }
        public override bool IsAvailable(Room room, Player invoker, CardUseReason reason, RespondType respond, string pattern, string position = null)
        {
            switch (reason)
            {
                case CardUseReason.CARD_USE_REASON_PLAY:
                    return RoomLogic.PlayerHasSkill(room, invoker, Name) && !invoker.HasUsed(TunanCard.ClassName);
                case CardUseReason.CARD_USE_REASON_RESPONSE_USE when pattern.StartsWith("@@tunan"):
                    return true;
                default:
                    return false;
            }
        }
        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (player == room.Current && cards.Count == 0)
                return new WrappedCard(TunanCard.ClassName) { Skill = Name };
            else if (player != room.Current && cards.Count == 1)
                return cards[0];

            return null;
        }

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            return false;
        }

        public override List<WrappedCard> GetGuhuoCards(Room room, List<WrappedCard> cards, Player player)
        {
            List<WrappedCard> result = new List<WrappedCard>();
            if (player != room.Current && room.GetRoomState().GetCurrentCardUsePattern() == "@@tunan")
            {
                int id = player.GetMark(Name);
                if (!player.HasFlag(Name))
                {
                    result.Add(room.GetCard(id));
                }
                else
                {
                    WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = "_tunan" };
                    slash.AddSubCard(id);
                    slash = RoomLogic.ParseUseCard(room, slash);
                    result.Add(slash);
                }
            }

            return result;
        }
    }

    public class TunanTag : TargetModSkill
    {
        public TunanTag() : base("#tunan", false) { pattern = ".#@@tunan"; }
        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            if (reason == CardUseReason.CARD_USE_REASON_RESPONSE_USE && !card.IsVirtualCard() && (room.GetRoomState().GetCurrentResponseSkill() == "tunan" || pattern == "@@tunan"))
                return true;

            return false;
        }
    }

    public class TunanCard : SkillCard
    {
        public static string ClassName = "TunanCard";
        public TunanCard() : base(ClassName)
        {
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card) => targets.Count == 0 && to_select != Self;

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player target = card_use.To[0];
            List<int> ids = room.GetNCards(1, false);
            target.SetMark("tunan", ids[0]);
            WrappedCard card = room.GetCard(ids[0]);
            FunctionCard fcard = Engine.GetFunctionCard(card.Name);
            if (!fcard.IsAvailable(room, target, card) || room.AskForUseCard(target, RespondType.Skill, "@@tunan", "@tunan-use", null, -1, HandlingMethod.MethodUse, false) == null)
            {
                target.SetFlags("tunan");
                room.AskForUseCard(target, RespondType.Skill, "@@tunan", "@tunan-slash", null, -1, HandlingMethod.MethodUse, false);
                target.SetFlags("-tunan");
            }
            target.SetMark("tunan", 0);
        }
    }

    public class Bijing : TriggerSkill
    {
        public Bijing() : base("bijing")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart };
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player target, ref object data, Player ask_who)
        {
            return triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(target, room) && target.Phase == PlayerPhase.Finish
                && !target.IsKongcheng() ? new TriggerStruct(Name, target) : new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<int> ids = room.AskForExchange(player, Name, 1, 0, "@bijing", string.Empty, ".", info.SkillPosition);
            if (ids.Count == 1)
            {
                player.SetTag(Name, ids[0]);
                room.NotifySkillInvoked(player, Name);
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, player, "bijing", info.SkillPosition);
                room.BroadcastSkillInvoke("bijing", "male", 1, gsk.General, gsk.SkinId);

                List<string> args = new List<string> { CommonClass.JsonUntity.Object2Json(ids), Name };
                room.DoNotify(room.GetClient(player), CommandType.S_COMMAND_UPDATE_CARD_FOOTNAME, args);

                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            return false;
        }
    }

    public class BijingDiscard : TriggerSkill
    {
        public BijingDiscard() : base("#bijing")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.CardsMoveOneTime };
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null && move.From.ContainsTag("bijing") && move.From.Alive
                && move.From.GetTag("bijing") is int id && move.From.Phase == PlayerPhase.NotActive && move.Card_ids.Contains(id) && move.From_places[move.Card_ids.IndexOf(id)] == Place.PlaceHand)
            {
                return new TriggerStruct(Name, move.From);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                if (player.Phase == PlayerPhase.Start && player.ContainsTag("bijing"))
                    return new TriggerStruct(Name, player);
                else if (player.Phase == PlayerPhase.Discard && player.GetMark("bijing") > 0)
                    return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime)
            {
                ask_who.RemoveTag("bijing");
                room.SendCompulsoryTriggerLog(ask_who, "bijing");
                if (room.Current != null && room.Current.Alive)
                {
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, room.Current.Name);
                    room.Current.AddMark("bijing");
                    room.SetPlayerStringMark(room.Current, "bijing", string.Empty);
                }
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                if (player.Phase == PlayerPhase.Start && player.ContainsTag("bijing") && player.GetTag("bijing") is int id)
                {
                    room.RemoveTag("bijing");
                    if (player.GetCards("h").Contains(id) && RoomLogic.CanDiscard(room, player, player, id))
                    {
                        if (RoomLogic.PlayerHasSkill(room, player, Name))
                        {
                            GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, player, "bijing", info.SkillPosition);
                            room.BroadcastSkillInvoke("bijing", "male", 2, gsk.General, gsk.SkinId);
                        }
                        room.ThrowCard(id, player);
                    }
                }
                else if (player.Phase == PlayerPhase.Discard && player.GetMark("bijing") > 0)
                {
                    player.SetMark("bijing", 0);
                    Player target = RoomLogic.FindPlayerBySkillName(room, Name);
                    if (target != null)
                    {
                        room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, target.Name, player.Name);
                        GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, target, "bijing", info.SkillPosition);
                        room.BroadcastSkillInvoke("bijing", "male", 2, gsk.General, gsk.SkinId);
                    }
                    room.AskForDiscard(player, "bijing", 2, 2, false, true, "@bijing-discard");
                    room.RemovePlayerStringMark(player, "bijing");
                }
            }

            return false;
        }
    }

    public class Tianjiang : TriggerSkill
    {
        public Tianjiang() : base("tianjiang")
        {
            events = new List<TriggerEvent> { TriggerEvent.GameStart };
            view_as_skill = new TianjiangVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.GameStart && base.Triggerable(player, room))
            {
                bool weapon = false, armor = false, oh = false, dh = false, treasure = false;
                List<int> ids = new List<int>(room.DrawPile);
                Shuffle.shuffle(ref ids);

                List<int> get = new List<int>();
                foreach (int id in ids)
                {
                    WrappedCard card = room.GetCard(id);
                    FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                    if (!dh && fcard is DefensiveHorse)
                    {
                        get.Add(id);
                        dh = true;
                    }
                    else if (!weapon && fcard is Weapon)
                    {
                        get.Add(id);
                        weapon = true;
                    }
                    else if (!armor && fcard is Armor)
                    {
                        get.Add(id);
                        armor = true;
                    }
                    else if (!oh && fcard is OffensiveHorse)
                    {
                        get.Add(id);
                        oh = true;
                    }
                    else if (!treasure && fcard is Treasure)
                    {
                        get.Add(id);
                        treasure = true;
                    }

                    if (get.Count >= 2)
                        break;
                }

                room.SendCompulsoryTriggerLog(player, Name);
                room.BroadcastSkillInvoke(Name, player);

                foreach (int id in get)
                {
                    WrappedCard equip_card = room.GetCard(id);
                    FunctionCard fcard = Engine.GetFunctionCard(equip_card.Name);
                    EquipCard equip = (EquipCard)fcard;
                    int equip_index = (int)equip.EquipLocation();

                    int equipped_id = player.GetEquip(equip_index);
                    List<CardsMoveStruct> exchangeMove = new List<CardsMoveStruct>();
                    if (equipped_id != -1)
                    {
                        CardsMoveStruct move1 = new CardsMoveStruct(equipped_id, player, Place.PlaceTable, new CardMoveReason(MoveReason.S_REASON_CHANGE_EQUIP, player.Name));
                        exchangeMove.Add(move1);
                        room.MoveCardsAtomic(exchangeMove, true);
                    }
                    CardsMoveStruct move2 = new CardsMoveStruct(id, player, Place.PlaceEquip, new CardMoveReason(MoveReason.S_REASON_PUT, player.Name, Name, string.Empty));
                    exchangeMove.Add(move2);
                    room.MoveCardsAtomic(exchangeMove, true);

                    LogMessage log = new LogMessage
                    {
                        From = player.Name,
                        Type = "$Install",
                        Card_str = id.ToString()
                    };
                    room.SendLog(log);

                    if (equipped_id != -1)
                    {
                        if (room.GetCardPlace(equipped_id) == Place.PlaceTable)
                        {
                            CardsMoveStruct move3 = new CardsMoveStruct(equipped_id, null, Place.DiscardPile, new CardMoveReason(MoveReason.S_REASON_CHANGE_EQUIP, player.Name));
                            room.MoveCardsAtomic(new List<CardsMoveStruct> { move3 }, true);
                        }
                    }
                }
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class TianjiangVS : OneCardViewAsSkill
    {
        public TianjiangVS() : base("tianjiang")
        {
        }

        public override bool ViewFilter(Room room, WrappedCard to_select, Player player) => room.GetCardPlace(to_select.Id) == Place.PlaceEquip;

        public override bool IsEnabledAtPlay(Room room, Player player) => player.HasEquip();

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard tj = new WrappedCard(TianjiangCard.ClassName) { Skill = Name };
            tj.AddSubCard(card);
            return tj;
        }
    }

    public class TianjiangCard : SkillCard
    {
        public static string ClassName = "TianjiangCard";
        public TianjiangCard() : base(ClassName)
        {
            will_throw = false;
        }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            if (targets.Count > 0 || to_select == Self)
                return false;
            WrappedCard equip_card = room.GetCard(card.SubCards[0]);
            return RoomLogic.CanPutEquip(to_select, equip_card);
        }

        private List<string> weapons = new List<string>
        {
            Lance.ClassName, QuenchedKnife.ClassName, PosionedDagger.ClassName, WaterSword.ClassName, LightningSummoner.ClassName
        };

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.To[0];
            int id = card_use.Card.GetEffectiveId();
            WrappedCard equip_card = room.GetCard(id);
            FunctionCard fcard = Engine.GetFunctionCard(equip_card.Name);
            EquipCard equip = (EquipCard)fcard;
            int equip_index = (int)equip.EquipLocation();

            int equipped_id = player.GetEquip(equip_index);
            List<CardsMoveStruct> exchangeMove = new List<CardsMoveStruct>();
            bool draw = false;
            if (weapons.Contains(room.GetCard(id).Name)) draw = true;
            if (equipped_id != -1)
            {
                CardsMoveStruct move1 = new CardsMoveStruct(equipped_id, player, Place.PlaceTable, new CardMoveReason(MoveReason.S_REASON_CHANGE_EQUIP, player.Name));
                exchangeMove.Add(move1);
                room.MoveCardsAtomic(exchangeMove, true);
            }
            CardsMoveStruct move2 = new CardsMoveStruct(id, card_use.From, player, Place.PlaceEquip,
                                  Place.PlaceEquip, new CardMoveReason(MoveReason.S_REASON_TRANSFER, player.Name, Name, string.Empty));
            exchangeMove.Add(move2);
            room.MoveCardsAtomic(exchangeMove, true);

            if (equipped_id != -1 && room.GetCardPlace(equipped_id) == Place.PlaceTable)
            {
                CardsMoveStruct move3 = new CardsMoveStruct(equipped_id, null, Place.DiscardPile, new CardMoveReason(MoveReason.S_REASON_CHANGE_EQUIP, player.Name));
                room.MoveCardsAtomic(new List<CardsMoveStruct> { move3 }, true);
            }

            if (draw && card_use.From.Alive)
                room.DrawCards(card_use.From, 2, "tianjiang");
        }
    }

    public class Zhuren : TriggerSkill
    {
        public Zhuren() : base("zhuren")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime };
            skill_type = SkillType.Wizzard;
            view_as_skill = new ZhurenVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.To_place == Place.DiscardPile)
            {
                List<int> remove = new List<int>();
                foreach (int id in move.Card_ids)
                {
                    WrappedCard card = room.GetCard(id);
                    if (room.GetCardPlace(id) == Place.DiscardPile && (card.Name == Lance.ClassName || card.Name == PosionedDagger.ClassName || card.Name == QuenchedKnife.ClassName
                        || card.Name == LightningSummoner.ClassName || card.Name == WaterSword.ClassName))
                    {
                        room.SetTag(string.Format("{0}_{1}", Name, card.Name), false);
                        remove.Add(id);
                    }
                }

                if (remove.Count > 0)
                {
                    if (move.Reason.Card != null)
                    {
                        List<int> subs = room.GetSubCards(move.Reason.Card);
                        subs.RemoveAll(t => remove.Contains(t));
                    }

                    Player holder = room.Players[0];
                    room.AddToPile(holder, "#virtual_cards", remove, false);
                }
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class ZhurenVS : OneCardViewAsSkill
    {
        public ZhurenVS() : base("zhuren")
        {
            filter_pattern = ".!";
        }

        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(ZhurenCard.ClassName) && !player.IsKongcheng();
        //public override bool IsEnabledAtPlay(Room room, Player player) => !player.IsKongcheng();

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard zr = new WrappedCard(ZhurenCard.ClassName) { Skill = Name };
            zr.AddSubCard(card);
            return zr;
        }
    }

    public class ZhurenCard : SkillCard
    {
        public static string ClassName = "ZhurenCard";
        public ZhurenCard() : base(ClassName)
        {
            target_fixed = true;
        }
        private readonly Dictionary<WrappedCard.CardSuit, string> suits = new Dictionary<WrappedCard.CardSuit, string>
        {
            { WrappedCard.CardSuit.Heart, Lance.ClassName },
            { WrappedCard.CardSuit.Diamond, QuenchedKnife.ClassName },
            { WrappedCard.CardSuit.Spade, PosionedDagger.ClassName },
            { WrappedCard.CardSuit.Club, WaterSword.ClassName },
        };
        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            int id = card_use.Card.GetEffectiveId();
            WrappedCard card = room.GetCard(id);
            string card_name;
            if (card.Name == Lightning.ClassName)
            {
                card_name = LightningSummoner.ClassName;
            }
            else
            {
                card_name = suits[card.Suit];
            }

            if (!room.ContainsTag(card_name))
            {
                foreach (int card_id in Engine.GetEngineCards())
                {
                    WrappedCard real_card = Engine.GetRealCard(card_id);
                    if (real_card.Name == card_name && room.GetCard(card_id) == null)
                    {
                        room.AddNewCard(card_id);
                        room.SetTag(string.Format("zhuren_{0}", card_name), false);
                        break;
                    }
                }
            }

            bool ingame = (bool)room.GetTag(string.Format("zhuren_{0}", card_name));
            List<int> ids = new List<int>();
            if (!ingame && card_name != card.Name && (card.Name == Lightning.ClassName || Shuffle.random(87 + card.Number, 100)))
            {
                foreach (int card_id in room.RoomCards)
                {
                    if (room.GetCard(card_id).Name == card_name)
                    {
                        ids.Add(card_id);
                        break;
                    }
                }
                room.SetTag(string.Format("zhuren_{0}", card_name), true);
            }
            else
            {
                foreach (int card_id in room.DrawPile)
                {
                    if (room.GetCard(card_id).Name.Contains(Slash.ClassName))
                    {
                        ids.Add(card_id);
                        break;
                    }
                }
            }
            if (ids.Count > 0) room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_GOTCARD, player.Name, "zhuren", string.Empty));
        }
    }

    public class Manyi : TriggerSkill
    {
        public Manyi() : base("manyi")
        {
            events.Add(TriggerEvent.CardEffected);
            frequency = Frequency.Compulsory;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player != null && player.Alive && base.Triggerable(player, room) && data is CardEffectStruct effect && effect.Card.Name == SavageAssault.ClassName)
            {
                return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (RoomLogic.PlayerHasShownSkill(room, player, this) || room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                return info;
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);

            LogMessage log = new LogMessage
            {
                Type = "#Skillnullify",
                From = player.Name,
                Arg = Name,
                Arg2 = SavageAssault.ClassName
            };
            room.SendLog(log);

            return true;
        }
    }

    public class Mansi : TriggerSkill
    {
        public Mansi() : base("mansi")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damage };
            skill_type = SkillType.Replenish;
            view_as_skill = new MansiVS();
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.Damage && data is DamageStruct damage && damage.Card != null && damage.Card.Name == SavageAssault.ClassName)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    triggers.Add(new TriggerStruct(Name, p));
            }

            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name, true);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            room.DrawCards(ask_who, 1, Name);
            ask_who.AddMark(Name);
            return false;
        }
    }

    public class MansiVS : ViewAsSkill
    {
        public MansiVS() : base("mansi")
        {
        }
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player) => false;
        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count == 1 && cards[0].Id < 0)
            {
                WrappedCard card = new WrappedCard(cards[0].Name) { Skill = Name };
                card.AddSubCards(player.GetCards("h"));
                return card;
            }

            return null;
        }
        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            if (!player.IsKongcheng() && !player.HasUsed("ViewAsSkill_mansiCard"))
            {
                foreach (int id in player.GetCards("h"))
                {
                    WrappedCard card = room.GetCard(id);
                    if (RoomLogic.IsCardLimited(room, player, card, HandlingMethod.MethodUse))
                        return false;
                }

                return true;
            }
            return false;
        }
        public override List<WrappedCard> GetGuhuoCards(Room room, List<WrappedCard> cards, Player player)
        {
            List<WrappedCard> savas = new List<WrappedCard>();
            WrappedCard card = new WrappedCard(SavageAssault.ClassName);
            card.AddSubCards(player.GetCards("h"));
            savas.Add(card);
            return savas;
        }
    }

    public class Souying : TriggerSkill
    {
        public Souying() : base("souying")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen, TriggerEvent.EventPhaseChanging };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.Players)
                {
                    foreach (Player p2 in room.GetOtherPlayers(p))
                    {
                        string str = string.Format("{0}_to_{1}", Name, p2.Name);
                        if (p.GetMark(str) > 0)
                            p.SetMark(str, 0);
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is SkillCard || fcard is DelayedTrick) return;
                foreach (Player p in use.To)
                {
                    string str = string.Format("{0}_to_{1}", Name, p.Name);
                    player.AddMark(str);
                }
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use && use.To.Count == 1 && use.To[0] != player)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is SkillCard || fcard is DelayedTrick) return triggers;
                Player to = use.To[0];
                string str = string.Format("{0}_to_{1}", Name, to.Name);
                if (base.Triggerable(player, room) && player.GetMark(str) > 1 && !player.HasFlag(Name))
                    triggers.Add(new TriggerStruct(Name, player));
                if (base.Triggerable(to, room) && player.GetMark(str) > 1 && !to.HasFlag(Name))
                    triggers.Add(new TriggerStruct(Name, to));
            }

            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                WrappedCard card = use.Card;
                bool invoke = false;
                if (player == ask_who)
                {
                    List<int> table_cardids = room.GetCardIdsOnTable(room.GetSubCards(card));
                    List<int> ids = new List<int>(card.SubCards);
                    List<int> whole = room.GetSubCards(card);
                    bool take = false;
                    if (table_cardids.Count > 0 && ids.SequenceEqual(table_cardids) && ids.SequenceEqual(whole))
                        take = true;
                    Player to = use.To[0];
                    if (take)
                        invoke = room.AskForDiscard(player, Name, 1, 1, true, true, string.Format("@souying:{0}::{1}", to.Name, use.Card.Name), true, info.SkillPosition);
                }
                else if (player != ask_who)
                {
                    string prompt = string.Format("@souying-invalid:{0}::{1}", player.Name, use.Card.Name);
                    invoke = room.AskForDiscard(ask_who, Name, 1, 1, true, true, prompt, true, info.SkillPosition);
                }

                if (invoke)
                {
                    room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                    ask_who.SetFlags(Name);
                    return info;
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                WrappedCard card = use.Card;

                if (player == ask_who)
                {
                    List<int> table_cardids = room.GetCardIdsOnTable(room.GetSubCards(card));
                    List<int> ids = new List<int>(card.SubCards);
                    List<int> whole = room.GetSubCards(card);
                    bool take = false;
                    if (table_cardids.Count > 0 && ids.SequenceEqual(table_cardids) && ids.SequenceEqual(whole))
                        take = true;

                    if (take)
                        room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_RECYCLE, player.Name, Name, string.Empty), true);
                }
                else if (player != ask_who)
                {
                    int index = 0;
                    for (int i = 0; i < use.EffectCount.Count; i++)
                    {
                        CardBasicEffect effect = use.EffectCount[i];
                        if (effect.To == ask_who)
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
            }

            return false;
        }
    }

    public class Zhanyuan : PhaseChangeSkill
    {
        public Zhanyuan() : base("zhanyuan")
        {
            frequency = Frequency.Wake;
            skill_type = SkillType.Recover;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Start && base.Triggerable(player, room) && player.GetMark(Name) == 0 && player.GetMark("mansi") > 7)
            {
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

                List<Player> targets = new List<Player>();
                foreach (Player p in room.GetOtherPlayers(player))
                    if (p.IsMale()) targets.Add(p);

                if (targets.Count > 0)
                {
                    Player target = room.AskForPlayerChosen(player, targets, Name, "@zhanyuan", true, false, info.SkillPosition);
                    if (target != null)
                    {
                        room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, target.Name);
                        room.HandleAcquireDetachSkills(player, "xili", true);
                        room.HandleAcquireDetachSkills(target, "xili", true);
                        room.HandleAcquireDetachSkills(player, "-mansi", false);
                    }
                }
            }

            return false;
        }
    }

    public class Xili : TriggerSkill
    {
        public Xili() : base("xili")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageCaused, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Attack;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                foreach (Player p in room.GetOtherPlayers(player))
                    if (p.HasFlag(Name)) p.SetFlags("-xili");
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.DamageCaused && data is DamageStruct damage && room.Current == player
                && base.Triggerable(player, room) && damage.To.Alive && !RoomLogic.PlayerHasSkill(room, damage.To, Name))
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    if (p != player && !p.HasFlag(Name))
                        triggers.Add(new TriggerStruct(Name, p));
            }

            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                room.SetTag(Name, data);
                bool invoke = room.AskForDiscard(ask_who, Name, 1, 1, true, true, string.Format("@xili:{0}:{1}", player.Name, damage.To.Name), true, info.SkillPosition);
                room.RemoveTag(Name);
                if (invoke)
                {
                    ask_who.SetFlags(Name);
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, player.Name);
                    room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
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

            room.DrawCards(player, new DrawCardStruct(2, ask_who, Name));
            room.DrawCards(ask_who, 2, Name);
            return false;
        }
    }

    public class Youyan : TriggerSkill
    {
        public Youyan() : base("youyan")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime };
            skill_type = SkillType.Replenish;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardsMoveOneTimeStruct move && base.Triggerable(move.From, room) && move.From.Phase != PlayerPhase.NotActive
                && (move.Reason.Reason & MoveReason.S_MASK_BASIC_REASON) == MoveReason.S_REASON_DISCARD && ((move.From.Phase == PlayerPhase.Play && !move.From.HasFlag("youyan_play"))
                || (move.From.Phase == PlayerPhase.Discard && !move.From.HasFlag("youyan_disacard"))))
            {
                List<WrappedCard.CardSuit> suits = new List<WrappedCard.CardSuit>();
                for (int i = 0; i < move.Card_ids.Count; i++)
                {
                    int id = move.Card_ids[i];
                    if (move.From_places[i] == Place.PlaceHand || move.From_places[i] == Place.PlaceEquip)
                    {
                        WrappedCard.CardSuit suit = room.GetCard(id).Suit;
                        if (!suits.Contains(suit))
                            suits.Add(suit);
                    }
                }
                if (suits.Count < 4) return new TriggerStruct(Name, move.From);
            }

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(ask_who, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                if (ask_who.Phase == PlayerPhase.Play)
                    ask_who.SetFlags("youyan_play");
                else
                    ask_who.SetFlags("youyan_disacard");

                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move)
            {
                List<WrappedCard.CardSuit> suits = new List<WrappedCard.CardSuit>();
                for (int i = 0; i < move.Card_ids.Count; i++)
                {
                    int id = move.Card_ids[i];
                    if (move.From_places[i] == Place.PlaceHand || move.From_places[i] == Place.PlaceEquip)
                    {
                        WrappedCard.CardSuit suit = room.GetCard(id).Suit;
                        if (!suits.Contains(suit))
                            suits.Add(suit);
                    }
                }

                List<int> ids = new List<int>();
                foreach (int id in room.DrawPile)
                {
                    WrappedCard.CardSuit suit = room.GetCard(id).Suit;
                    if (!suits.Contains(suit))
                    {
                        suits.Add(suit);
                        ids.Add(id);
                        if (suits.Count >= 4) break;
                    }
                }

                if (ids.Count > 0)
                {
                    foreach (int id in ids)
                    {
                        room.MoveCardTo(room.GetCard(id), ask_who, Place.PlaceTable, new CardMoveReason(MoveReason.S_REASON_TURNOVER, ask_who.Name, Name, null), false);
                        Thread.Sleep(100);
                    }

                    CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_GOTBACK, ask_who.Name, Name, string.Empty);
                    room.ObtainCard(ask_who, ref ids, reason, true);
                }
            }

            return false;
        }
    }

    public class Zhuihuan : TriggerSkill
    {
        public Zhuihuan() : base("zhuihuan")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.Damaged };
            skill_type = SkillType.Wizzard;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Damaged && data is DamageStruct damage && player.GetMark(Name) > 0 && damage.From != null && damage.From.Alive
                && damage.From != player)
            {
                List<string> targets = player.ContainsTag(Name) ? (List<string>)player.GetTag(Name) : new List<string>();
                if (!targets.Contains(damage.From.Name)) targets.Add(damage.From.Name);
                player.SetTag(Name, targets);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Finish && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.AskForPlayerChosen(player, room.GetAlivePlayers(), Name, "@zhuihuan", true, false, info.SkillPosition);
            if (target != null)
            {
                List<string> arg = new List<string>
                {
                    AnimateType.S_ANIMATE_INDICATE.ToString(),
                    player.Name,
                    target.Name
                };
                room.SetTag(Name, target);
                room.DoNotify(room.GetClient(player), CommandType.S_COMMAND_ANIMATE, arg);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.NotifySkillInvoked(player, Name);
                return info;
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is Player target)
            {
                room.DoNotify(room.GetClient(player), CommandType.S_COMMAND_SET_STRINGMARK, new List<string> { player.Name, Name, string.Empty });
                target.SetMark(Name, 1);
                room.RemoveTag(Name);
            }

            return false;
        }
    }

    public class ZhuihuanEffect : TriggerSkill
    {
        public ZhuihuanEffect() :base("#zhuihuan")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Start && player.GetMark("zhuihuan") > 0 && player.Alive)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            player.SetMark("zhuihuan", 0);
            if (player.ContainsTag("zhuihuan") && player.GetTag("zhuihuan") is List<string> targets_name)
            {
                player.RemoveTag("zhuihuan");
                List<Player> targets = new List<Player>();
                foreach (string target_name in targets_name)
                {
                    Player target = room.FindPlayer(target_name);
                    if (target != null) targets.Add(target);
                }

                if (targets.Count > 0)
                {
                    room.SortByActionOrder(ref targets);
                    foreach (Player target in targets)
                    {
                        if (target.Alive && player.Alive)
                        {
                            room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, target.Name);
                            LogMessage log = new LogMessage
                            {
                                Type = "#zhuilie-effect",
                                From = player.Name,
                                To = new List<string> { target.Name },
                            };
                            room.SendLog(log);

                            if (target.Hp > player.Hp)
                            {
                                room.Damage(new DamageStruct("zhuihuan", player, target, 2));
                            }
                            else if (!target.IsKongcheng())
                            {
                                List<int> to_discard = new List<int>();
                                if (target.HandcardNum > 2)
                                {
                                    List<int> ids = target.GetCards("h");
                                    Shuffle.shuffle(ref ids);
                                    for (int i = 0; i < 2; i++)
                                        to_discard.Add(ids[i]);
                                }
                                else
                                {
                                    to_discard = target.GetCards("h");
                                }

                                room.ThrowCard(ref to_discard, new CardMoveReason(MoveReason.S_REASON_THROW, target.Name, "zhuihuan", string.Empty), null, null);
                            }
                        }
                    }
                }
            }
            room.RemovePlayerStringMark(player, "zhuihuan");
            return false;
        }
    }

    public class Bazhan : ViewAsSkill
    {
        public Bazhan() : base("bazhan")
        {
            turn = true;
            skill_type = SkillType.Wizzard;
        }
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            if (player.GetMark(Name) == 0)
                return selected.Count < 2 && room.GetCardPlace(to_select.Id) == Place.PlaceHand;
            else
                return false;
        }
        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.HasUsed(BazhanCard.ClassName);
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (player.GetMark(Name) == 0)
            {
                if (cards.Count > 0)
                {
                    WrappedCard bz = new WrappedCard(BazhanCard.ClassName) { Skill = Name };
                    bz.AddSubCards(cards);
                    return bz;
                }
                return null;
            }
            else
                return new WrappedCard(BazhanCard.ClassName) { Skill = Name };
        }

    }

    public class BazhanCard : SkillCard
    {
        public static string ClassName = "BazhanCard";
        public BazhanCard() : base(ClassName)
        {
            will_throw = false;
        }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            if (card.SubCards.Count == 0 && (to_select.IsKongcheng() || !RoomLogic.CanGetCard(room, Self, to_select, "h"))) return false;
            return targets.Count == 0 && to_select != Self;
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            Player target = card_use.To[0];
            bool check = false;

            Player healer = null;
            if (player.GetMark("bazhan") == 0)
            {
                healer = target;
                player.SetMark("bazhan", 1);
                List<int> ids = new List<int>(card_use.Card.SubCards);
                room.ObtainCard(target, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, "bazhan", string.Empty));
                foreach (int id in ids)
                {
                    WrappedCard card = room.GetCard(id);
                    if (card.Name == Analeptic.ClassName || card.Suit == WrappedCard.CardSuit.Heart)
                    {
                        check = true;
                        break;
                    }
                }
            }
            else
            {
                healer = player;
                player.SetMark("bazhan", 0);

                List<int> ids = new List<int>();
                ids.Add(room.AskForCardChosen(player, target, "h", "bazhan", false, HandlingMethod.MethodGet));
                if (target.HandcardNum > ids.Count && room.AskForSkillInvoke(player, "bazhan", "@bazhan:" + target.Name, card_use.Card.SkillPosition))
                {
                    ids.Add(room.AskForCardChosen(player, target, "h", "bazhan", false, HandlingMethod.MethodGet, ids));
                }
                if (ids.Count > 0)
                {
                    room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_EXTRACTION, player.Name, target.Name, "bazhan", string.Empty));
                    foreach (int id in ids)
                    {
                        WrappedCard card = room.GetCard(id);
                        if (card.Name == Analeptic.ClassName || card.Suit == WrappedCard.CardSuit.Heart)
                        {
                            check = true;
                            break;
                        }
                    }
                }
            }

            if (player.Alive)
            {
                room.SetTurnSkillState(player, "bazhan", player.GetMark("bazhan") == 1, card_use.Card.SkillPosition);
                if (check)
                {
                    List<string> choices = new List<string>();
                    if (healer.IsWounded()) choices.Add("recover");
                    if (!healer.FaceUp || healer.Chained) choices.Add("reset");
                    if (choices.Count > 0)
                    {
                        choices.Add("cancel");
                        string choice = room.AskForChoice(player, "bazhan", string.Join("+", choices), new List<string> { "@to-player:" + healer.Name }, healer, card_use.Card.SkillPosition);
                        if (choice == "recover")
                        {
                            RecoverStruct recover = new RecoverStruct
                            {
                                Recover = 1,
                                Who = player
                            };
                            room.Recover(healer, recover);
                        }
                        else if (choice == "reset")
                        {
                            if (healer.Chained)
                                room.SetPlayerChained(healer, false, true);
                            if (!healer.FaceUp)
                                room.TurnOver(healer);
                        }
                    }
                }
            }
        }
    }

    public class Jiaoying : TriggerSkill
    {
        public Jiaoying() : base("jiaoying")
        {
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Wizzard;
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime, TriggerEvent.CardUsed, TriggerEvent.EventPhaseChanging, TriggerEvent.EventPhaseStart };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use && player.HasFlag(Name) && !Engine.IsSkillCard(use.Card.Name))
                player.SetFlags("-jiaoying");
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                foreach (Player p in room.GetAlivePlayers())
                    RoomLogic.RemovePlayerCardLimitation(p, Name);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null && move.To != null && move.From_places.Contains(Place.PlaceHand)
                && move.To_place == Place.PlaceHand && move.To.Alive && move.From != move.To && base.Triggerable(move.From, room))
            {
                triggers.Add(new TriggerStruct(Name, move.From));
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Finish)
            {
                List<Player> checks = new List<Player>();
                foreach (Player p in room.GetAlivePlayers())
                    if (p.HasFlag(Name)) checks.Add(p);

                if (checks.Count > 0)
                {
                    foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                        if (!checks.Contains(p) || checks.Count > 1)
                            triggers.Add(new TriggerStruct(Name, p));
                }
            }
            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move)
            {
                move.To.SetFlags(Name);
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, move.To.Name);
                room.SendCompulsoryTriggerLog(ask_who, Name);

                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);

                bool red = false, black = false;

                if (ask_who.Limitation.ContainsKey(Name))
                {
                    red = ask_who.Limitation[Name][1].Contains("red");
                    black = ask_who.Limitation[Name][1].Contains("black");
                }
                if (!red || !black)
                {
                    foreach (int id in move.Card_ids)
                    {
                        bool _red = WrappedCard.IsRed(room.GetCard(id).Suit);
                        if (!red && _red) red = true;
                        if (!black && !_red) black = true;
                    }
                }
                LogMessage log = new LogMessage
                {
                    Type = "#bazhan-color",
                    From = move.To.Name
                };
                if (black && red) log.Type = "#bazhan-all";
                else if (black) log.Arg = "black";
                else log.Type = "red";
                room.SendLog(log);

                string pattern = red ? ".|red" : string.Empty;
                if (black) pattern += string.IsNullOrEmpty(pattern) ? ".|black" : "#.|black";

                RoomLogic.RemovePlayerCardLimitation(move.To, Name);
                RoomLogic.SetPlayerCardLimitation(move.To, Name, "use,response", pattern, true);
            }
            else
            {
                List<Player> targets = new List<Player>();
                foreach (Player p in room.GetAlivePlayers())
                    if (p.HandcardNum < 5) targets.Add(p);
                if (targets.Count > 0)
                {
                    Player target = room.AskForPlayerChosen(ask_who, targets, Name, "@jiaoying", true, true, info.SkillPosition);
                    if (target != null)
                    {
                        GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                        room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);

                        int count = 5 - target.HandcardNum;
                        room.DrawCards(target, new DrawCardStruct(count, ask_who, Name));
                    }
                }
            }
            return false;
        }
    }

    public class Huguan : TriggerSkill
    {
        public Huguan() : base("huguan")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging, TriggerEvent.CardUsed };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use && !Engine.IsSkillCard(use.Card.Name) && player.Phase == PlayerPhase.Play)
            {
                use.From.AddMark(Name);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                player.SetMark(Name, 0);
                player.RemoveTag(Name);
                room.RemovePlayerStringMark(player, Name);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use && !Engine.IsSkillCard(use.Card.Name)
                && player.GetMark(Name) == 1 && WrappedCard.IsRed(use.Card.Suit) && player.Phase == PlayerPhase.Play)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    triggers.Add(new TriggerStruct(Name, p));
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<string> choices = new List<string> { "spade", "heart", "club", "diamond", "cancel" };
            string choice = room.AskForChoice(ask_who, Name, string.Join("+", choices), new List<string> { "@huguan:" + player.Name }, player, info.SkillPosition);
            if (choice != "cancel")
            {
                WrappedCard.CardSuit suit = WrappedCard.GetSuit(choice);
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, player.Name);
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                room.NotifySkillInvoked(ask_who, Name);
                List<WrappedCard.CardSuit> suits = player.ContainsTag(Name) ? (List<WrappedCard.CardSuit>)player.GetTag(Name) : new List<WrappedCard.CardSuit>();
                if (!suits.Contains(suit)) suits.Add(suit);
                player.SetTag(Name, suits);

                StringBuilder builder = new StringBuilder();
                foreach (WrappedCard.CardSuit s in suits)
                    builder.Append(WrappedCard.GetSuitIcon(s));
                string icon = builder.ToString();
                room.SetPlayerStringMark(player, Name, icon);

                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info) => false;
    }

    public class HuguanMax : MaxCardsSkill
    {
        public HuguanMax() : base("#huguan") { }
        public override bool Ingnore(Room room, Player player, int card_id)
        {
            if (player.ContainsTag("huguan") && player.GetTag("huguan") is List<WrappedCard.CardSuit> suits)
                return suits.Contains(room.GetCard(card_id).Suit);

            return false;
        }
    }

    public class Yaopei : TriggerSkill
    {
        public Yaopei() : base("yaopei")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseEnd, TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseChanging };
            view_as_skill = new YaopeiVS();
            skill_type = SkillType.Recover;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null && move.From.Phase == PlayerPhase.Discard
                && move.From == room.Current && (move.Reason.Reason & MoveReason.S_MASK_BASIC_REASON) == MoveReason.S_REASON_DISCARD)
            {
                List<Player> erzhangs = RoomLogic.FindPlayersBySkillName(room, Name);
                bool check = false;
                foreach (Player p in erzhangs)
                {
                    if (move.From != p)
                    {
                        check = true;
                        break;
                    }
                }
                if (!check) return;

                List<WrappedCard.CardSuit> suits = move.From.ContainsTag(Name) ? (List<WrappedCard.CardSuit>)move.From.GetTag(Name) : new List<WrappedCard.CardSuit>();
                foreach (int card_id in move.Card_ids)
                {
                    if (!suits.Contains(room.GetCard(card_id).Suit))
                        suits.Add(room.GetCard(card_id).Suit);
                }

                move.From.SetTag(Name, suits);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.From == PlayerPhase.Discard)
                player.RemoveTag(Name);
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> skill_list = new List<TriggerStruct>();
            if (player != null && player.Alive && triggerEvent == TriggerEvent.EventPhaseEnd && player.Phase == PlayerPhase.Discard && player.ContainsTag(Name)
                && player.GetTag(Name) is List<WrappedCard.CardSuit> suits)
            {
                if (suits.Count < 4)
                {
                    List<Player> erzhangs = RoomLogic.FindPlayersBySkillName(room, Name);
                    foreach (Player erzhang in erzhangs)
                    {
                        if (player != erzhang && !erzhang.IsNude())
                            skill_list.Add(new TriggerStruct(Name, erzhang));
                    }
                }
            }

            return skill_list;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.AskForUseCard(ask_who, RespondType.Skill, "@@yaopei", "@yaopei:" + player.Name, null, -1, HandlingMethod.MethodUse, true, info.SkillPosition);
            return new TriggerStruct();
        }
    }

    public class YaopeiVS : OneCardViewAsSkill
    {
        public YaopeiVS() : base("yaopei") { response_pattern = "@@yaopei"; }

        public override bool ViewFilter(Room room, WrappedCard to_select, Player player)
        {
            if (room.Current.GetTag(Name) is List<WrappedCard.CardSuit> suits)
                return !suits.Contains(to_select.Suit) && RoomLogic.CanDiscard(room, player, player, to_select.Id);

            return false;
        }

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard yp = new WrappedCard(YaopeiCard.ClassName) { Skill = Name };
            yp.AddSubCard(card);
            return yp;
        }
    }

    public class YaopeiCard : SkillCard
    {
        public static string ClassName = "YaopeiCard";
        public YaopeiCard() : base(ClassName) { will_throw = true; }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card) => targets.Count == 0 && (to_select == Self || to_select == room.Current);

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player draw = card_use.To[0], recover = null;
            if (draw != card_use.From)
                recover = card_use.From;
            else
                recover = room.Current;

            if (recover.IsWounded()) room.Recover(recover);
            if (draw.Alive) room.DrawCards(draw, new DrawCardStruct(2, card_use.From, "yaopei"));
        }
    }
    
    public class Mingluan : TriggerSkill
    {
        public Mingluan() : base("mingluan")
        {
            events = new List<TriggerEvent> { TriggerEvent.HpRecover, TriggerEvent.EventPhaseStart };
            skill_type = SkillType.Replenish;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.HpRecover) player.SetFlags(Name);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.EventPhaseStart && player != null && player.Alive && !player.IsKongcheng() && player.Phase == PlayerPhase.Finish)
            {
                bool check = false;
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.HasFlag(Name))
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                        if (player != p && !p.IsNude())
                            triggers.Add(new TriggerStruct(Name, p));
                }
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int count = Math.Min(5, player.HandcardNum);
            if (room.AskForDiscard(ask_who, Name, 1, 1, true, true, "@mingluan:::" + count.ToString(), true, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (ask_who.Alive && player.Alive && player.HandcardNum > 0)
            {
                int count = Math.Min(5 - ask_who.HandcardNum, player.HandcardNum);
                room.DrawCards(ask_who, count, Name);
            }

            return false; ;
        }
    }

    public class Jianliang : TriggerSkill
    {
        public Jianliang() : base("jianliang")
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
            List<Player> targets = room.AskForPlayersChosen(player, room.GetAlivePlayers(), Name, 0, 2, "@jianliang", true, info.SkillPosition);
            if (targets.Count > 0)
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.SetTag(Name, targets);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is List<Player> targets)
            {
                room.RemoveTag(Name);
                room.SortByActionOrder(ref targets);

                foreach (Player p in targets)
                {
                    if (p.Alive)
                        room.DrawCards(p, new DrawCardStruct(1, player, Name));
                }
            }

            return false;
        }
    }

    public class Weimeng : ZeroCardViewAsSkill
    {
        public Weimeng() : base("weimeng") { }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(WeimengCard.ClassName);

        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(WeimengCard.ClassName) { Skill = Name };
    }

    public class WeimengCard : SkillCard
    {
        public static string ClassName = "WeimengCard";
        public WeimengCard() : base(ClassName) { }

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

            List<int> ids = room.AskForCardsChosen(player, target, patterns, "weimeng");
            CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_EXTRACTION, player.Name);
            room.ObtainCard(player, ref ids, reason, false);

            if (player.Alive && target.Alive)
            {
                int count = 0;
                foreach (int id in ids)
                    count += room.GetCard(id).Number;

                int min = Math.Min(player.GetCardCount(true), ids.Count);
                List<int> give = room.AskForExchange(player, "weimeng", min, min, string.Format("@weimeng:{0}::{1}", target.Name, min), string.Empty, "..", card_use.Card.SkillPosition);

                room.ObtainCard(target, ref give, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, "weimeng", string.Empty), false);
                if (player.Alive)
                {
                    int give_count = 0;
                    foreach (int id in give)
                        give_count += room.GetCard(id).Number;

                    if (give_count > count)
                        room.DrawCards(player, 1, "weimeng");
                    else if (give_count < count && target.Alive && !target.IsAllNude() && RoomLogic.CanDiscard(room, player, target, "hej"))
                    {
                        int card_id = room.AskForCardChosen(player, target, "hej", "weimeng", false, HandlingMethod.MethodDiscard);
                        room.ThrowCard(card_id, room.GetCardPlace(card_id) == Place.PlaceDelayedTrick ? null : target, player);
                    }
                }
            }
        }
    }

    public class Zhubi : TriggerSkill
    {
        public Zhubi() : base("zhubi")
        {
            events.Add(TriggerEvent.CardsMoveOneTime);
            skill_type = SkillType.Wizzard;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (data is CardsMoveOneTimeStruct move && move.To_place == Place.DiscardPile && (move.Reason.Reason & MoveReason.S_MASK_BASIC_REASON) == MoveReason.S_REASON_DISCARD)
            {
                bool diamond = false;
                foreach (int id in move.Card_ids)
                {
                    if (room.GetCard(id).Suit == WrappedCard.CardSuit.Diamond)
                    {
                        diamond = true;
                        break;
                    }
                }
                if (diamond)
                {
                    foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }
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
            int card_id = -1;
            foreach (int id in room.DiscardPile)
            {
                if (room.GetCard(id).Name == ExNihilo.ClassName)
                {
                    card_id = id;
                    break;
                }
            }
            if (card_id == -1)
            {
                foreach (int id in room.DrawPile)
                {
                    if (room.GetCard(id).Name == ExNihilo.ClassName)
                    {
                        card_id = id;
                        break;
                    }
                }
            }
            if (card_id >= 0)
            {
                room.MoveCardTo(room.GetCard(card_id), null, Place.PlaceTable, new CardMoveReason(MoveReason.S_REASON_SHOW, ask_who.Name, Name, string.Empty), true);

                CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_PUT, ask_who.Name, Name, string.Empty);
                CardsMoveStruct move = new CardsMoveStruct(new List<int> { card_id }, null, Place.DrawPile, reason)
                {
                    To_pile_name = string.Empty,
                    From = string.Empty,
                    From_place = Place.PlaceTable,
                };
                List<CardsMoveStruct> moves = new List<CardsMoveStruct> { move };
                room.MoveCardsAtomic(moves, true);
            }

            return false;
        }
    }

    public class Liuzhuan : TriggerSkill
    {
        public Liuzhuan() : base("liuzhuan")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Replenish;
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move)
            {
                if (move.To != null && move.To.Phase != PlayerPhase.NotActive && move.To.Phase != PlayerPhase.Draw && move.To_place == Place.PlaceHand)
                {
                    List<int> ids = room.ContainsTag(Name) ? (List<int>)room.GetTag(Name) : new List<int>();
                    foreach (int id in move.Card_ids)
                        if (!ids.Contains(id)) ids.Add(id);

                    room.SetTag(Name, ids);
                }
                else if (move.From != null && move.From.Phase != PlayerPhase.NotActive && move.From_places.Contains(Place.PlaceHand) && room.ContainsTag(Name) && room.GetTag(Name) is List<int> _ids)
                {
                    List<int> same = _ids.FindAll(t => move.Card_ids.Contains(t));
                    _ids.RemoveAll(t => move.Card_ids.Contains(t));
                    room.SetTag(Name, _ids);

                    if (same.Count > 0 && (move.Reason.Reason & MoveReason.S_MASK_BASIC_REASON) == MoveReason.S_REASON_DISCARD)
                    {
                        List<int> skill = room.ContainsTag("liuzhuan_discard") ? (List<int>)room.GetTag("liuzhuan_discard") : new List<int>();
                        foreach (int id in same)
                            if (!skill.Contains(id))
                                skill.Add(id);

                        room.SetTag("liuzhuan_discard", skill);
                    }
                }
                else if (move.To_place != Place.DiscardPile && room.ContainsTag("liuzhuan_discard") && room.GetTag("liuzhuan_discard") is List<int> ids)
                {
                    ids.RemoveAll(t => move.Card_ids.Contains(t));
                    if (ids.Count > 0)
                        room.SetTag("liuzhuan_discard", ids);
                    else
                        room.RemoveTag("liuzhuan_discard");
                }
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                room.RemoveTag(Name);
                room.RemoveTag("liuzhuan_discard");
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.To_place == Place.DiscardPile
                && (move.Reason.Reason & MoveReason.S_MASK_BASIC_REASON) == MoveReason.S_REASON_DISCARD && room.ContainsTag("liuzhuan_discard") && room.GetTag("liuzhuan_discard") is List<int> ids)
            {
                List<int> same = ids.FindAll(t => move.Card_ids.Contains(t) && room.GetCardPlace(t) == Place.DiscardPile);
                if (same.Count > 0)
                {
                    foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                        if (p.Phase == PlayerPhase.NotActive)
                            triggers.Add(new TriggerStruct(Name, p));
                }
            }
            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move && room.GetTag("liuzhuan_discard") is List<int> ids)
            {
                List<int> same = ids.FindAll(t => move.Card_ids.Contains(t) && room.GetCardPlace(t) == Place.DiscardPile);
                ids.RemoveAll(t => move.Card_ids.Contains(t));
                if (ids.Count > 0)
                    room.SetTag("liuzhuan_discard", ids);
                else
                    room.RemoveTag("liuzhuan_discard");
                if (same.Count > 0)
                {
                    room.SendCompulsoryTriggerLog(ask_who, Name);
                    room.ObtainCard(ask_who, ref same, new CardMoveReason(MoveReason.S_REASON_RECYCLE, ask_who.Name, Name, string.Empty), true);
                }
            }

            return false;
        }
    }

    public class LiuzhuanPro : ProhibitSkill
    {
        public LiuzhuanPro() : base("#liuzhuan") { }
        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null)
        {
            if (from != null && from.Phase != PlayerPhase.NotActive && from != to && to != null && RoomLogic.PlayerHasShownSkill(room, to, "liuzhuan") && card.SubCards.Count > 0
                && room.ContainsTag("liuzhuan") && room.GetTag("liuzhuan") is List<int> ids)
            {
                List<int> same = card.SubCards.FindAll(t => ids.Contains(t));
                return same.Count > 0;
            }
            return false;
        }
    }

    public class QuanjianEffect : TriggerSkill
    {
        public QuanjianEffect() : base("#quanjian")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging, TriggerEvent.DamageInflicted };
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change)
            {
                if (change.From == PlayerPhase.Play)
                {
                    player.SetFlags("-quanjian_draw");
                    player.SetFlags("-quanjian_damage");
                }
                else if (change.To == PlayerPhase.NotActive)
                {
                    foreach (Player p in room.GetAlivePlayers())
                    {
                        p.SetMark("quanjian", 0);
                        room.RemovePlayerStringMark(p, "quanjian");
                    }
                }
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.DamageInflicted && player.Alive && player.GetMark("quanjian") > 0)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int count = player.GetMark("quanjian");
            player.SetMark("quanjian", 0);
            room.RemovePlayerStringMark(player, "quanjian");

            DamageStruct damage = (DamageStruct)data;
            damage.Damage += count;
            LogMessage log = new LogMessage
            {
                Type = "#AddDamaged",
                From = player.Name,
                Arg = "quanjian",
                Arg2 = (damage.Damage).ToString()
            };
            room.SendLog(log);
            data = damage;

            return false;
        }
    }

    public class Quanjian : ZeroCardViewAsSkill
    {
        public Quanjian() : base("quanjian") { }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasFlag("quanjian_draw") || !player.HasFlag("quanjian_damage");
        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(QuanjianCard.ClassName) { Skill = Name };
    }

    public class QuanjianCard : SkillCard
    {
        public static string ClassName = "QuanjianCard";
        public QuanjianCard() : base(ClassName) { }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            if (targets.Count == 0)
            {
                return to_select != Self && (!Self.HasFlag("quanjian_damage") || to_select.HandcardNum > to_select.MaxHp || (to_select.HandcardNum < 5 && to_select.HandcardNum < to_select.MaxHp));
            }
            else if (targets.Count == 1 && !Self.HasFlag("quanjian_damage"))
            {
                return to_select != targets[0] && RoomLogic.InMyAttackRange(room, targets[0], to_select);
            }
            return false;
        }

        public override bool TargetsFeasible(Room room, List<Player> targets, Player Self, WrappedCard card)
        {
            return (!Self.HasFlag("quanjian_draw") && targets.Count == 1) || (!Self.HasFlag("quanjian_damage") && targets.Count == 2);
        }
        public override void OnUse(Room room, CardUseStruct card_use)
        {
            Player diaochan = card_use.From;

            object data = card_use;
            RoomThread thread = room.RoomThread;

            thread.Trigger(TriggerEvent.PreCardUsed, room, diaochan, ref data);
            room.BroadcastSkillInvoke("quanjian", diaochan, card_use.Card.SkillPosition);
            
            LogMessage log = new LogMessage
            {
                From = diaochan.Name,
                To = new List<string>(),
                Type = "#UseCard",
                Card_str = RoomLogic.CardToString(room, card_use.Card)
            };
            log.To.Add(card_use.To[0].Name);
            room.SendLog(log);

            thread.Trigger(TriggerEvent.CardUsedAnnounced, room, diaochan, ref data);
            thread.Trigger(TriggerEvent.CardTargetAnnounced, room, diaochan, ref data);
            thread.Trigger(TriggerEvent.CardUsed, room, diaochan, ref data);
            thread.Trigger(TriggerEvent.CardFinished, room, diaochan, ref data);
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            Player target = card_use.To[0];
            if (card_use.To.Count == 1)
            {
                player.SetFlags("quanjian_draw");
                if (target.HandcardNum < target.MaxHp && target.HandcardNum < 5)
                {
                    int count = Math.Min(target.MaxHp, 5) - target.HandcardNum;
                    if (room.AskForSkillInvoke(target, "quanjian", string.Format("@quanjian-draw:{0}::{1}", player.Name, count)))
                    {
                        room.DrawCards(target, new DrawCardStruct(count, player, "quanjian"));
                        target.SetFlags("quanjian-pro");
                    }
                    else
                    {
                        target.AddMark("quanjian");
                        room.SetPlayerStringMark(target, "quanjian", target.GetMark("quanjian").ToString());
                    }
                }
                else if (target.HandcardNum > target.MaxHp)
                {
                    int count = target.HandcardNum - target.MaxHp;
                    if (!room.AskForDiscard(target, "quanjian", count, count, true, false, string.Format("@quanjian-disacard:{0}::{1}", player.Name, count)))
                    {
                        target.AddMark("quanjian");
                        room.SetPlayerStringMark(target, "quanjian", target.GetMark("quanjian").ToString());
                    }
                    else
                        target.SetFlags("quanjian-pro");
                }
            }
            else
            {
                player.SetFlags("quanjian_damage");
                Player victim = card_use.To[1];
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, target.Name, victim.Name);
                if (room.AskForSkillInvoke(target, "quanjian", string.Format("@quanjian-damage:{0}:{1}", player.Name, victim.Name)))
                {
                    room.Damage(new DamageStruct("quanjian", target, victim));
                }
                else
                {
                    target.AddMark("quanjian");
                    room.SetPlayerStringMark(target, "quanjian", target.GetMark("quanjian").ToString());
                }
            }
        }
    }

    public class QuanjianPro : ProhibitSkill
    {
        public QuanjianPro() : base("#quanjian-pro") { }
        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null)
        {
            if (from != null && from.HasFlag("quanjian-pro") && card != null)
            {
                foreach (int id in card.SubCards)
                    if (room.GetCardOwner(id) == from && room.GetCardPlace(id) == Place.PlaceHand)
                        return true;
            }
            return false;
        }
    }

    public class Tujue : TriggerSkill
    {
        public Tujue() : base("tujue")
        {
            events.Add(TriggerEvent.Dying);
            skill_type = SkillType.Recover;
            limit_mark = "@tujue";
            frequency = Frequency.Limited;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.GetMark(limit_mark) > 0 && !player.IsNude())
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@tujue-target", true, true, info.SkillPosition);
            if (target != null)
            {
                room.SetPlayerMark(player, limit_mark, 0);
                room.DoSuperLightbox(player, info.SkillPosition, Name);
                room.SetTag(Name, target);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is Player target)
            {
                room.RemoveTag(Name);
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, target.Name);
                List<int> ids = player.GetCards("he");
                room.ObtainCard(target, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, Name, string.Empty), false);

                if (player.Alive && ids.Count > 0)
                {
                    int count = Math.Min(ids.Count, player.GetLostHp());
                    room.Recover(player, count);
                    if (player.Alive) room.DrawCards(player, ids.Count, Name);
                }
            }

            return false;
        }
    }

    public class Jiedao : TriggerSkill
    {
        public Jiedao() : base("jiedao")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageCaused, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Attack;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.DamageCaused)
                player.AddMark(Name);
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                foreach (Player p in room.GetAlivePlayers())
                    if (p.GetMark(Name) > 0) p.SetMark(Name, 0);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.DamageCaused && base.Triggerable(player, room) && player.IsWounded() && player.GetMark(Name) == 1)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage && room.AskForSkillInvoke(player, Name, damage.To, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                List<string> choices = new List<string>();
                for (int i = 1; i <= player.GetLostHp(); i++)
                    choices.Add(i.ToString());

                string choice = room.AskForChoice(player, Name, string.Join("+", choices), new List<string> { "@jiedao:" + damage.To.Name }, data, info.SkillPosition);
                int count = int.Parse(choice);
                string mark = string.Format("{0}:{1}", Name, choice);
                if (damage.Marks == null)
                    damage.Marks = new List<string> { mark };
                else
                    damage.Marks.Add(mark);

                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, damage.To.Name);
                LogMessage log = new LogMessage
                {
                    Type = "#AddDamage",
                    From = player.Name,
                    To = new List<string> { damage.To.Name },
                    Arg = Name,
                    Arg2 = (damage.Damage += count).ToString()
                };
                room.SendLog(log);

                data = damage;
            }
            return false;
        }
    }

    public class JiedaoDis : TriggerSkill
    {
        public JiedaoDis() : base("#jiedao")
        {
            events.Add(TriggerEvent.DamageComplete);
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is DamageStruct damage && player.Alive && !damage.Prevented && damage.From != null && damage.From.Alive && damage.Marks != null && !damage.From.IsNude())
            {
                foreach (string str in damage.Marks)
                {
                    if (str.StartsWith("jiedao"))
                        return new TriggerStruct(Name, damage.From);
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                int count = 0;
                foreach (string str in damage.Marks)
                {
                    if (str.StartsWith("jiedao"))
                    {
                        string[] strs = str.Split(':');
                        count = int.Parse(strs[1]);
                        break;
                    }
                }

                room.AskForDiscard(ask_who, "jiedao", count, count, false, true, "@jiedao-discard:::" + count.ToString(), false, info.SkillPosition);
            }

            return false;
        }
    }

    public class Kannan : TriggerSkill
    {
        public Kannan() : base("kannan")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging };
            view_as_skill = new KannanVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is PhaseChangeStruct change && change.From == PlayerPhase.Play && player.HasFlag(Name))
                player.SetFlags("-kannan");
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class KannanVS : ZeroCardViewAsSkill
    {
        public KannanVS() : base("kannan")
        {
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.HasFlag(Name) && player.UsedTimes(KannanCard.ClassName) < player.Hp && !player.IsKongcheng();
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(KannanCard.ClassName) { Skill = Name };
        }
    }

    public class KannanCard : SkillCard
    {
        public static string ClassName = "KannanCard";
        public KannanCard() : base(ClassName)
        {
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && Self != to_select && !to_select.HasFlag("kannan") && RoomLogic.CanBePindianBy(room, to_select, Self);
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            target.SetFlags("kannan");
            PindianStruct pd = room.PindianSelect(player, target, "kannan");
            room.Pindian(ref pd);
            if (pd.From_number > pd.To_numbers[0])
            {
                player.AddMark("kannan");
                room.SetPlayerStringMark(player, "kannan", player.GetMark("kannan").ToString());
                player.SetFlags("kannan");
            }
            else if (pd.To_numbers[0] > pd.From_number)
            {
                target.AddMark("kannan");
                room.SetPlayerStringMark(target, "kannan", target.GetMark("kannan").ToString());
            }
        }
    }

    public class KannanDamage : TriggerSkill
    {
        public KannanDamage() : base("#kannan")
        {
            events.Add(TriggerEvent.CardUsedAnnounced);
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName) && player.Alive && player.GetMark("kannan") > 0)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                LogMessage log = new LogMessage
                {
                    Type = "#kannan-add",
                    From = player.Name,
                    Arg = player.GetMark("kannan").ToString(),
                    Arg2 = use.Card.Name
                };
                room.SendLog(log);

                use.ExDamage += player.GetMark("kannan");
                data = use;
                player.SetMark("kannan", 0);
                room.RemovePlayerStringMark(player, "kannan");
            }

            return false;
        }
    }

    public class Jixu : TriggerSkill
    {
        public Jixu() : base("jixu")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardTargetAnnounced, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Attack;
            view_as_skill = new JixuVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.From == PlayerPhase.Play)
            {
                player.SetMark(Name, 0);
                foreach (Player p in room.GetOtherPlayers(player))
                {
                    if (p.HasFlag(Name))
                    {
                        room.RemovePlayerStringMark(p, "jixu_wrong");
                        p.SetFlags("-jixu");
                    }
                }
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName)
                && player.Phase == PlayerPhase.Play && player.HasUsed(JixuCard.ClassName))
            {
                foreach (Player p in room.GetOtherPlayers(player))
                    if (p.HasFlag(Name) && !use.To.Contains(p) && RoomLogic.IsProhibited(room, player, p, use.Card, use.To) == null)
                        return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use && room.AskForSkillInvoke(player, Name, string.Format("@jixu-target:::{0}", use.Card.Name), info.SkillPosition))
            {
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                List<Player> targets = new List<Player>();
                foreach (Player p in room.GetOtherPlayers(player))
                {
                    if (p.HasFlag(Name) && !use.To.Contains(p) && RoomLogic.IsProhibited(room, player, p, use.Card, use.To) == null)
                    {
                        targets.Add(p);
                        room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, p.Name);
                    }
                }

                if (targets.Count > 0)
                {
                    use.To.AddRange(targets);
                    room.SortByActionOrder(ref use);
                    data = use;
                }
            }

            return false;
        }
    }

    public class JixuVS : ZeroCardViewAsSkill
    {
        public JixuVS() : base("jixu")
        { }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.HasUsed(JixuCard.ClassName) && !player.IsKongcheng();
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(JixuCard.ClassName) { Skill = Name };
        }
    }

    public class JixuCard : SkillCard
    {
        public static string ClassName = "JixuCard";
        public JixuCard() : base(ClassName) { }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card) => to_select != Self && targets.Count < Self.Hp;

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            bool has = false;
            foreach (int id in player.GetCards("h"))
            {
                if (room.GetCard(id).Name.Contains(Slash.ClassName))
                {
                    has = true;
                    break;
                }
            }

            List<Player> yes = new List<Player>(), no = new List<Player>();
            foreach (Player p in card_use.To)
            {
                LogMessage log = new LogMessage
                {
                    Type = "#jixu",
                    From = p.Name,
                };
                if (room.AskForChoice(p, "jixu", "has+nohas", new List<string> { "@jixu:" + player.Name }) == "has")
                {
                    yes.Add(p);
                    log.Arg = "has";
                }
                else
                {
                    log.Arg = "nohas";
                    no.Add(p);
                }
                room.SendLog(log);
            }

            LogMessage result = new LogMessage
            {
                Type = has ? "#jixu-has" : "#jixu-no",
                From = player.Name
            };
            room.SendLog(result);

            int count;
            if (has)
            {
                player.AddMark("jixu", no.Count);
                count = no.Count;
                foreach (Player p in no)
                {
                    room.SetPlayerStringMark(p, "jixu_wrong", string.Empty);
                    p.SetFlags("jixu");
                }
            }
            else
            {
                count = yes.Count;
                foreach (Player p in yes)
                {
                    if (player.Alive && p.Alive && !p.IsNude() && RoomLogic.CanDiscard(room, player, p, "he"))
                    {
                        int id = room.AskForCardChosen(player, p, "he", "jixu", false, HandlingMethod.MethodDiscard);
                        room.ThrowCard(id, p, player);
                    }
                }
            }

            if (count > 0) room.DrawCards(player, count, "jixu");
        }
    }

    public class JixuTar : TargetModSkill
    {
        public JixuTar() : base("#jixu", false) { }
        public override int GetResidueNum(Room room, Player from, WrappedCard card) => from.GetMark("jixu");
    }

    public class Jijun : TriggerSkill
    {
        public Jijun() : base("jijun")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen, TriggerEvent.CardsMoveOneTime };
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use && base.Triggerable(player, room) && use.To.Contains(player))
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is Weapon || !(fcard is EquipCard))
                    return new TriggerStruct(Name, player);
            }
            else if (data is CardsMoveOneTimeStruct move && move.To_place == Place.DiscardPile && move.Reason.Reason == MoveReason.S_REASON_JUDGEDONE && !string.IsNullOrEmpty(move.Reason.EventName)
                && move.Reason.EventName == Name && move.From.Alive && move.Card_ids.Count == 1 && room.GetCardPlace(move.Card_ids[0]) == Place.DiscardPile)
                return new TriggerStruct(Name, move.From);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && room.AskForSkillInvoke(player, Name, null, info.SkillPosition))
            {
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                return info;
            }
            else if (triggerEvent == TriggerEvent.CardsMoveOneTime && room.AskForSkillInvoke(ask_who, Name, "@jijun", info.SkillPosition))
            {
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.TargetChosen)
            {
                JudgeStruct judge = new JudgeStruct
                {
                    Good = true,
                    PlayAnimation = false,
                    Who = player,
                    Reason = Name
                };

                room.Judge(ref judge);
            }
            else if (data is CardsMoveOneTimeStruct move)
            {
                room.AddToPile(ask_who, Name, move.Card_ids);
            }

            return false;
        }
    }

    public class Fangtong : TriggerSkill
    {
        public Fangtong() : base("fangtong")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.CardsMoveOneTime };
            skill_type = SkillType.Wizzard;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null && base.Triggerable(move.From, room)
                && move.Reason.Reason == MoveReason.S_REASON_THROW && move.Reason.SkillName == Name && move.Card_ids.Count == 1 && move.To_place == Place.PlaceTable && move.From.Alive)
            {
                int count = 0;
                foreach (int id in move.Card_ids)
                    count += room.GetCard(id).Number;

                move.From.SetMark("fangtong_discard", count);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.GetPile("jijun").Count > 0 && player.Phase == PlayerPhase.Finish)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForDiscard(player, Name, 1, 1, true, true, "@fangtong", true, info.SkillPosition))
            {
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<int> ids = room.AskForExchange(player, Name, player.GetPile("jijun").Count, 1, "@fangtong-disacard", "jijun", string.Empty, info.SkillPosition);
            int count = player.GetMark(Name);
            foreach (int id in ids)
                count += room.GetCard(id).Number;

            CardsMoveStruct move = new CardsMoveStruct(ids, null, Place.DiscardPile, new CardMoveReason(MoveReason.S_REASON_NATURAL_ENTER, ask_who.Name, Name, string.Empty));
            room.MoveCardsAtomic(move, true);

            if (player.Alive)
            {
                player.SetMark(Name, count);
                room.SetPlayerStringMark(player, Name, count.ToString());
                int discard = player.GetMark("fangtong_discard");
                player.SetMark("fangtong_discard", 0);
                if (count + discard == 36)
                {
                    Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@fangtong-target", false, true, info.SkillPosition);
                    GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                    room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);

                    room.Damage(new DamageStruct(Name, player, target, 3, DamageStruct.DamageNature.Thunder));
                }
            }

            if (player.Alive && count >= 36)
            {
                player.SetMark(Name, 0);
                room.RemovePlayerStringMark(player, Name);
            }

            return false;
        }
    }

    public class Lixun : TriggerSkill
    {
        public Lixun() : base("lixun")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageInflicted, TriggerEvent.EventPhaseStart, TriggerEvent.CardsMoveOneTime };
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Masochism;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null && move.Reason.Reason == MoveReason.S_REASON_THROW
                && move.Reason.SkillName == Name && move.To_place == Place.PlaceTable)
                move.From.SetTag(Name, move.Card_ids.Count);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.DamageInflicted && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.EventPhaseStart && player.GetMark("@zhu") > 1 && player.Phase == PlayerPhase.Play)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
            if (triggerEvent == TriggerEvent.DamageInflicted && data is DamageStruct damage)
            {
                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                room.AddPlayerMark(player, "@zhu", damage.Damage);
                LogMessage log = new LogMessage
                {
                    Type = "#damaged-prevent",
                    From = player.Name,
                    Arg = Name
                };
                room.SendLog(log);
                return true;
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);
                JudgeStruct judge = new JudgeStruct
                {
                    Good = true,
                    PlayAnimation = false,
                    Who = player,
                    Reason = Name,
                    Negative = true,
                    Pattern = string.Format(".|.|1~{0}", player.GetMark("@zhu") - 1)
                };

                room.Judge(ref judge);
                if (judge.IsEffected())
                {
                    int count = 0, number = player.GetMark("@zhu");
                    if (player.Alive && room.AskForDiscard(player, Name, number, number, false, false,
                        string.Format("@lixun:::{0}", number), false, info.SkillPosition) && player.ContainsTag(Name) && player.GetTag(Name) is int discard)
                        count = discard;

                    if (player.Alive && count < number) room.LoseHp(player, number - count);
                }
            }

            return false;
        }
    }

    public class KuizhuLS : TriggerSkill
    {
        public KuizhuLS() : base("kuizhu_ls")
        {
            events.Add(TriggerEvent.EventPhaseEnd);
            skill_type = SkillType.Wizzard;
        }

        public override bool Triggerable(Player target, Room room)
        {
            return base.Triggerable(target, room) && target.Phase == PlayerPhase.Play && target.HandcardNum < 5;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<Player> targets = new List<Player>();
            int max = 0;
            foreach (Player p in room.GetAlivePlayers())
                if (p.Hp > max) max = p.Hp;
            foreach (Player p in room.GetOtherPlayers(player))
                if (p.Hp == max && p.HandcardNum > player.HandcardNum) targets.Add(p);
            if (targets.Count > 0)
            {
                Player target = room.AskForPlayerChosen(player, targets, Name, "@kuizhu_ls-target", true, true, info.SkillPosition);
                if (target != null)
                {
                    room.SetTag(Name, target);
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    return info;
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = (Player)room.GetTag(Name);
            room.RemoveTag(Name);
            int count = Math.Min(5 - player.HandcardNum, target.HandcardNum - player.HandcardNum);
            room.DrawCards(player, count, Name);
            if (player.Alive && target.Alive && player.HandcardNum > 0)
            {
                object decisionData = string.Format("viewCards:{0}:all", target.Name);
                room.RoomThread.Trigger(TriggerEvent.ChoiceMade, room, player, ref decisionData);


                List<int> disable = new List<int>(), ids = player.GetCards("h");
                foreach (int id in ids)
                    if (!RoomLogic.CanGetCard(room, target, player, id)) disable.Add(id);
                room.FillAG(Name, ids, target, disable);
                List<int> discard = room.AskForExchange(target, Name, ids.Count - disable.Count, 0, "@kuizhu_from:" + player.Name, string.Empty, ".!", string.Empty);
                room.ClearAG(target);

                if (discard.Count > 0)
                {
                    count = discard.Count;
                    room.ThrowCard(ref discard, target);

                    if (player.Alive && target.Alive && player.HandcardNum > 0)
                    {
                        ids = player.GetCards("h");
                        List<int> can = new List<int>(ids);
                        can.RemoveAll(t => !RoomLogic.CanGetCard(room, target, player, t));
                        room.SetTag(Name, can);
                        AskForMoveCardsStruct move = room.AskForMoveCards(target, ids, new List<int>(), false, Name, Math.Min(can.Count, count),
                            Math.Min(can.Count, count), false, true, new List<int>(), string.Empty);
                        room.RemoveTag(Name);
                        List<int> get = new List<int>();
                        if (move.Success && move.Bottom.Count == count)
                        {
                            get = move.Bottom;
                        }
                        else
                        {
                            for (int i = 0; i < Math.Min(can.Count, count); i++)
                                get.Add(can[i]);
                        }

                        if (get.Count > 0)
                        {
                            room.ObtainCard(target, ref get, new CardMoveReason(MoveReason.S_REASON_EXTRACTION, target.Name, player.Name, Name, string.Empty), false);
                            if (player.Alive && target.Alive && get.Count > 1)
                            {
                                bool option = player.GetMark("@zhu") > 0;
                                List<Player> targets = new List<Player>();
                                foreach (Player p in room.GetOtherPlayers(target))
                                    if (RoomLogic.InMyAttackRange(room, target, p)) targets.Add(p);

                                bool remove = option;
                                if (targets.Count > 0)
                                {
                                    player.SetFlags(Name);
                                    target.SetFlags("kuizhu_target");
                                    Player victim = room.AskForPlayerChosen(player, targets, Name, "@kuizhu-damage:" + target.Name, option, true, info.SkillPosition);
                                    player.SetFlags("-kuizhu_ls");
                                    target.SetFlags("-kuizhu_target");
                                    if (victim != null)
                                    {
                                        remove = false;
                                        room.Damage(new DamageStruct(Name, target, victim));
                                    }
                                }

                                if (remove) room.AddPlayerMark(player, "@zhu", -1);
                            }
                        }
                    }
                }
            }

            return false;
        }
    }

    public class Fenyue : ZeroCardViewAsSkill
    {
        public Fenyue() : base("fenyue") { skill_type = SkillType.Alter; }
        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            if (!player.IsKongcheng())
            {
                int count = 0;
                foreach (Player p in room.GetOtherPlayers(player))
                {
                    PlayerRole role = p.GetRoleEnum();
                    if (role == PlayerRole.Lord || role == PlayerRole.Loyalist)
                    {
                        if (player.GetRoleEnum() != PlayerRole.Lord && player.GetRoleEnum() != PlayerRole.Loyalist)
                            count++;
                    }
                    else if (player.GetRoleEnum() != p.GetRoleEnum())
                        count++;
                }
                return player.UsedTimes(FenyueCard.ClassName) < count;
            }

            return false;
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(FenyueCard.ClassName) { Skill = Name };
        }
    }

    public class FenyueCard : SkillCard
    {
        public static string ClassName = "FenyueCard";
        public FenyueCard() : base(ClassName)
        {
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && to_select != Self && RoomLogic.CanBePindianBy(room, to_select, Self);
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            PindianStruct pd = room.PindianSelect(card_use.From, target, "fenyue");

            room.Pindian(ref pd);
            if (pd.Success)
            {
                int number = Engine.GetRealCard(pd.From_card.Id).Number;
                if (number <= 5 && player.Alive && target.Alive && !target.IsNude() && RoomLogic.CanGetCard(room, player, target, "he"))
                {
                    int card_id = room.AskForCardChosen(player, target, "he", "fenyue", false, HandlingMethod.MethodGet);
                    CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_EXTRACTION, player.Name, target.Name, "fenyue", string.Empty);
                    room.ObtainCard(player, room.GetCard(card_id), reason, false);
                }

                if (number <= 9 && player.Alive)
                {
                    List<int> ids = new List<int>();
                    foreach (int id in room.DrawPile)
                    {
                        if (room.GetCard(id).Name.Contains(Slash.ClassName))
                        {
                            ids.Add(id);
                            break;
                        }
                    }

                    if (ids.Count > 0)
                    {
                        CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_GOTBACK, player.Name, "fenyue", string.Empty);
                        room.ObtainCard(player, ref ids, reason, true);
                    }
                }

                if (player.Alive && target.Alive)
                {
                    WrappedCard slash = new WrappedCard(ThunderSlash.ClassName)
                    {
                        DistanceLimited = false
                    };
                    if (RoomLogic.IsProhibited(room, player, target, slash) == null)
                        room.UseCard(new CardUseStruct(slash, player, target, false));
                }
            }
        }
    }

    public class Xuhe : TriggerSkill
    {
        public Xuhe() : base("xuhe")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.EventPhaseEnd };
            skill_type = SkillType.Wizzard;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseEnd && player.Phase == PlayerPhase.Play && base.Triggerable(player, room))
            {
                int count = 0;
                foreach (Player p in room.GetAlivePlayers())
                    if (p.MaxHp > count) count = p.MaxHp;

                if (player.MaxHp < count)
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
                }

                if (player.Alive)
                {
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
                }
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Play && base.Triggerable(player, room) && player.MaxHp > 1)
            {
                return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            string choice = room.AskForChoice(player, Name, "discard+draw+cancel", null, null, info.SkillPosition);
            if (choice != "cancel")
            {
                player.SetTag(Name, choice);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.NotifySkillInvoked(player, Name);
                room.LoseMaxHp(player);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.GetTag(Name) is string choice && player.Alive)
            {
                player.RemoveTag(Name);
                List<Player> targets = new List<Player>();
                if (choice == "discard")
                {
                    if (RoomLogic.CanDiscard(room, player, player, "he")) targets.Add(player);
                    foreach (Player p in room.GetOtherPlayers(player))
                        if (RoomLogic.DistanceTo(room, player, p) == 1)
                            targets.Add(p);

                    if (targets.Count > 0)
                    {
                        room.SortByActionOrder(ref targets);
                        foreach (Player p in targets)
                        {
                            if (p.Alive && RoomLogic.CanDiscard(room, player, p, "he") && player.Alive)
                            {
                                CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_DISMANTLE, player.Name, p.Name, Name, null)
                                {
                                    General = RoomLogic.GetGeneralSkin(room, player, Name, info.SkillPosition)
                                };
                                List<int> ints = new List<int>();
                                if (p == player)
                                {
                                    ints.AddRange(room.AskForExchange(player, Name, 1, 1, "@xuhe", null, "..!", info.SkillPosition));
                                }
                                else
                                    ints.Add(room.AskForCardChosen(player, p, "he", Name, false, HandlingMethod.MethodDiscard));

                                room.ThrowCard(ref ints, reason, p, player);
                            }
                        }
                    }
                }
                else
                {
                    targets.Add(player);
                    foreach (Player p in room.GetOtherPlayers(player))
                        if (RoomLogic.DistanceTo(room, player, p) == 1)
                            targets.Add(p);

                    room.SortByActionOrder(ref targets);
                    foreach (Player p in targets)
                        room.DrawCards(p, new DrawCardStruct(1, player, Name));
                }

            }

            return false;
        }
    }

    public class Mouzhu : ZeroCardViewAsSkill
    {
        public Mouzhu() : base("mouzhu") { }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(MouzhuCard.ClassName);

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(MouzhuCard.ClassName) { Skill = Name };
        }
    }

    public class MouzhuCard : SkillCard
    {
        public static string ClassName = "MouzhuCard";
        public MouzhuCard() : base(ClassName)
        {
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
            => !to_select.IsKongcheng() && to_select != Self && (RoomLogic.DistanceTo(room, Self, to_select) == 1 || to_select.Hp == Self.Hp);

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            foreach (Player p in card_use.To)
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, p.Name);

            foreach (Player p in card_use.To)
            {
                if (p.Alive && player.Alive && !p.IsKongcheng())
                    Do(room, p, player);
            }
        }

        private void Do(Room room, Player from, Player to)
        {
            List<int> give = room.AskForExchange(from, "mouzhu", 1, 1, "@mouzhu:" + to.Name, string.Empty, ".", string.Empty);
            if (give.Count > 0)
            {
                room.ObtainCard(to, ref give, new CardMoveReason(MoveReason.S_REASON_GIVE, from.Name, to.Name, "mouzhu", string.Empty), false);
                if (from.Alive && to.Alive && from.HandcardNum < to.HandcardNum)
                {
                    List<string> choices = new List<string>();
                    WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = "_mouzhu", DistanceLimited = false };
                    if (RoomLogic.IsProhibited(room, from, to, slash) == null)
                        choices.Add("slash");

                    WrappedCard duel = new WrappedCard(Duel.ClassName) { Skill = "_mouzhu" };
                    if (RoomLogic.IsProhibited(room, from, to, duel) == null)
                        choices.Add("duel");

                    if (choices.Count > 0)
                    {
                        string choice = room.AskForChoice(from, "mouzhu", string.Join("+", choices), new List<string> { "@mouzhu-choice:" + to.Name }, to);
                        if (choice == "slash")
                            room.UseCard(new CardUseStruct(slash, from, to));
                        else
                            room.UseCard(new CardUseStruct(duel, from, to));
                    }
                }
            }
        }
    }

    public class Yujue : TriggerSkill
    {
        public Yujue() : base("yujue")
        {
            events = new List<TriggerEvent> { TriggerEvent.TurnStart, TriggerEvent.Death };
            view_as_skill = new YujueVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (player.ContainsTag(Name) && player.GetTag(Name) is string player_name)
            {
                Player target = room.FindPlayer(player_name);
                if (target != null)
                    room.HandleAcquireDetachSkills(target, "-zhihu", true);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class YujueVS : ZeroCardViewAsSkill
    {
        public YujueVS() : base("yujue") { }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            if (!player.HasUsed(YujueCard.ClassName))
            {
                for (int i = 0; i < 5; i++)
                    if (!player.EquipIsBaned(i))
                        return true;
            }

            return false;
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(YujueCard.ClassName) { Skill = Name };
        }
    }

    public class YujueCard : SkillCard
    {
        public static string ClassName = "YujueCard";
        public YujueCard() : base(ClassName)
        {
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && Self != to_select && !to_select.IsKongcheng();
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            Player target = card_use.To[0];
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
                            choices.Add("DHorse");
                            break;
                        case 3:
                            choices.Add("OHorse");
                            break;
                        case 4:
                            choices.Add("Treasure");
                            break;
                    }
                }
            }

            string choice = room.AskForChoice(player, "yujue", string.Join("+", choices), null, null, card_use.Card.SkillPosition);
            switch (choice)
            {
                case "Weapon":
                    room.AbolisheEquip(player, 0, "yujue");
                    break;
                case "Armor":
                    room.AbolisheEquip(player, 1, "yujue");
                    break;
                case "DHorse":
                    room.AbolisheEquip(player, 2, "yujue");
                    break;
                case "OHorse":
                    room.AbolisheEquip(player, 3, "yujue");
                    break;
                case "Treasure":
                    room.AbolisheEquip(player, 4, "yujue");
                    break;
            }

            if (target.Alive && !target.IsKongcheng() && player.Alive)
            {
                List<int> ids = room.AskForExchange(target, "yujue", 1, 1, "@yujue:" + player.Name, string.Empty, ".", card_use.Card.SkillPosition);
                room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, target.Name, player.Name, "yujue", string.Empty), false);
            }

            if (target.Alive && player.Alive)
            {
                room.HandleAcquireDetachSkills(target, "zhihu", true);
                player.SetTag("yujue", target.Name);
            }
        }
    }

    public class Tuxin : TriggerSkill
    {
        public Tuxin() : base("tuxin")
        {
            events = new List<TriggerEvent> { TriggerEvent.EquipBolished, TriggerEvent.DamageCaused };
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EquipBolished && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.DamageCaused && player.GetMark(Name) > 0)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);

            if (triggerEvent == TriggerEvent.EquipBolished)
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
                room.Recover(player, 1);

                bool all = true;
                for (int i = 0; i < 5; i++)
                    if (!player.EquipIsBaned(i))
                        all = false;

                if (all && player.Alive)
                {
                    player.SetMark(Name, 1);
                    room.LoseMaxHp(player, 4);
                }
            }
            else if (data is DamageStruct damage)
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

            return false;
        }
    }

    public class Zhihu : TriggerSkill
    {
        public Zhihu() : base("zhihu")
        {
            events= new List<TriggerEvent> { TriggerEvent.Damage, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Replenish;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                foreach (Player p in room.GetAlivePlayers())
                    p.SetMark(Name, 0);
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.Damage && base.Triggerable(player, room) && player.GetMark(Name) < 2)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            player.AddMark(Name);
            room.DrawCards(player, 2, Name);
            return false;
        }
    }

    public class Niluan : TriggerSkill
    {
        public Niluan() : base("niluan")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damage, TriggerEvent.CardFinished };
            view_as_skill = new NiluanVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Damage && data is DamageStruct damage && damage.From != null && damage.Card != null && damage.Card.GetSkillName() == Name)
            {
                damage.Card.SetFlags(Name);
            }
            else if (triggerEvent == TriggerEvent.CardFinished && data is CardUseStruct use && use.Card.GetSkillName() == Name && !use.Card.HasFlag(Name) && use.AddHistory)
            {
                use.AddHistory = false;
                player.AddHistory(use.Card.Name, -1);
                data = use;
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class NiluanVS : OneCardViewAsSkill
    {
        public NiluanVS() : base("niluan") { filter_pattern = ".|black"; response_or_use = true; }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.IsNude() && Slash.IsAvailable(room, player);
        }

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = "niluan" };
            slash.AddSubCard(card);
            slash = RoomLogic.ParseUseCard(room, slash);
            return slash;
        }
    }
    
    public class Weiwu : OneCardViewAsSkill
    {
        public Weiwu() : base("weiwu") { filter_pattern = ".|red"; response_or_use = true; }

        public override bool IsEnabledAtPlay(Room room, Player player) => player.UsedTimes("ViewAsSkill_weiwuCard") == 0;
        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard await = new WrappedCard(Snatch.ClassName)
            {
                Skill = Name,
                ShowSkill = Name
            };
            await.AddSubCard(card);
            await = RoomLogic.ParseUseCard(room, await);
            return await;
        }
    }

    public class WeiwuProhibi : ProhibitSkill
    {
        public WeiwuProhibi() : base("#weiwu") { }
        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null)
        {
            if (from != null && to != null && card != null && card.GetSkillName() == "weiwu")
                return to.HandcardNum < from.HandcardNum;
            return false;
        }
    }

    public class Gongjian : TriggerSkill
    {
        public Gongjian() : base("gongjian")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Attack;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                foreach (Player p in room.GetAlivePlayers())
                    if (p.HasFlag(Name)) p.SetFlags("-gongjian");
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.TargetChosen && room.ContainsTag(Name) && data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName) && room.GetTag(Name) is List<Player> targets)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                {
                    if (!p.HasFlag(Name))
                    {
                        foreach (Player victim in use.To)
                        {
                            if (p != victim && !victim.IsNude() && RoomLogic.CanDiscard(room, p, victim, "he"))
                            {
                                triggers.Add(new TriggerStruct(Name, p));
                                break;
                            }
                        }
                    }
                }
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(ask_who, Name, data, info.SkillPosition))
            {
                ask_who.SetFlags(Name);
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName) && room.GetTag(Name) is List<Player> targets)
            {
                List<Player> players = new List<Player>();
                foreach (Player p in use.To)
                    if (targets.Contains(p) && p != ask_who)
                        players.Add(p);

                room.SortByActionOrder(ref players);
                foreach (Player p in players)
                {
                    if (p.Alive && ask_who.Alive && !p.IsNude() && RoomLogic.CanDiscard(room, ask_who, p, "he"))
                    {
                        room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, p.Name);
                        List<int> ids = room.AskForCardsChosen(ask_who, p, "he", Name, 1, Math.Min(2, p.GetCardCount(true)), false, HandlingMethod.MethodDiscard);
                        room.ThrowCard(ref ids, p, ask_who);
                        List<int> get = new List<int>();
                        foreach (int id in ids)
                        {
                            if (room.GetCard(id).Name.Contains(Slash.ClassName) && room.GetCardPlace(id) == Place.DiscardPile)
                                get.Add(id);
                        }
                        if (get.Count > 0 && ask_who.Alive)
                            room.ObtainCard(ask_who, ref get, new CardMoveReason(MoveReason.S_REASON_RECYCLE, ask_who.Name, Name, string.Empty));
                    }
                }
            }
            return false;
        }
    }
    public class GongjianRecord : TriggerSkill
    {
        public GongjianRecord() : base("#gongjian")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen };
        }
        public override int Priority => 0;
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName))
                room.SetTag("gongjian", use.To);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data) => new List<TriggerStruct>();
    }

    public class Kuimang : TriggerSkill
    {
        public Kuimang() : base("kuimang")
        {
            events = new List<TriggerEvent> { TriggerEvent.PreDamageDone, TriggerEvent.Death };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.PreDamageDone && data is DamageStruct damage && damage.From != null && damage.From.Alive)
            {
                List<string> names = new List<string>();
                if (damage.From.ContainsTag(Name))
                    names = (List<string>)damage.From.GetTag(Name);
                if (!names.Contains(player.Name))
                    names.Add(player.Name);

                damage.From.SetTag(Name, names);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.Death)
            {
                List<Player> players = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in players)
                {
                    if (p.ContainsTag(Name) && p.GetTag(Name) is List<string> targets && targets.Contains(player.Name))
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }
            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            room.DrawCards(ask_who, 2, Name);
            return false;
        }
    }

    public class Cixiao : TriggerSkill
    {
        public Cixiao() : base("cixiao")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            view_as_skill = new CixiaoVS();
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Start)
            {
                bool invoke = true;
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.GetMark("foster_son") > 0)
                    {
                        invoke = false;
                        break;
                    }
                }
                if (invoke) return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@cixiao", true, true, info.SkillPosition);
            if (target != null)
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.SetTag(Name, target);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is Player target)
            {
                room.RemoveTag(Name);
                target.SetMark("foster_son", 1);
                room.SetPlayerStringMark(target, "foster_son", string.Empty);
                room.HandleAcquireDetachSkills(target, "panshi", true);
            }

            return false;
        }
    }

    public class CixiaoVS : OneCardViewAsSkill
    {
        public CixiaoVS() : base("cixiao")
        {
            filter_pattern = ".!";
        }
        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            bool invoke = false;
            foreach (Player p in room.GetOtherPlayers(player))
            {
                if (p.GetMark("foster_son") > 0)
                {
                    invoke = true;
                    break;
                }
            }

            return invoke && !player.IsNude() && !player.HasUsed(CixiaoCard.ClassName);
        }

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard cx = new WrappedCard(CixiaoCard.ClassName) { Skill = Name };
            cx.AddSubCard(card);
            return cx;
        }
    }

    public class CixiaoCard : SkillCard
    {
        public static string ClassName = "CixiaoCard";
        public CixiaoCard() : base(ClassName)
        {
            will_throw = true;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            if (targets.Count == 0)
                return Self != to_select;
            else if (targets.Count == 1)
            {
                Player first = targets[0];
                if (first.GetMark("foster_son") == 0)
                    return Self != to_select && to_select.GetMark("foster_son") > 0;
                else
                    return Self != to_select && to_select.GetMark("foster_son") == 0;
            }
            return false;
        }

        public override bool TargetsFeasible(Room room, List<Player> targets, Player Self, WrappedCard card) => targets.Count == 2;

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player first = null, second = null;
            foreach (Player p in card_use.To)
            {
                if (p.GetMark("foster_son") > 0)
                    first = p;
                else
                    second = p;
            }

            first.SetMark("foster_son", 0);
            room.RemovePlayerStringMark(first, "foster_son");
            room.HandleAcquireDetachSkills(first, "-panshi", true);

            if (second.Alive)
            {
                second.SetMark("foster_son", 1);
                room.SetPlayerStringMark(second, "foster_son", string.Empty);
                room.HandleAcquireDetachSkills(second, "panshi", true);
            }
        }
    }

    public class Panshi : TriggerSkill
    {
        public Panshi() : base("panshi")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.DamageCaused };
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Wizzard;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.Phase == PlayerPhase.Start
                && !player.IsKongcheng() && RoomLogic.FindPlayerBySkillName(room, Name) != null)

                return new TriggerStruct(Name, player);

            else if (triggerEvent == TriggerEvent.DamageCaused && data is DamageStruct damage && base.Triggerable(player, room) && player.Phase == PlayerPhase.Play && damage.To != null
                && damage.Card != null && damage.Card.Name.Contains(Slash.ClassName) && RoomLogic.PlayerHasSkill(room, damage.To, "cixiao"))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                List<Player> dys = RoomLogic.FindPlayersBySkillName(room, "cixiao");
                room.SortByActionOrder(ref dys);
                foreach (Player p in dys)
                {
                    if (player.Alive && p.Alive && !player.IsKongcheng())
                    {
                        List<int> ids = room.AskForExchange(player, Name, 1, 1, "@panshi:" + p.Name, string.Empty, ".", info.SkillPosition);
                        room.ObtainCard(p, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, p.Name, string.Empty), false);
                    }
                }
            }
            else if (data is DamageStruct damage)
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

                player.SetFlags("Global_PlayPhaseTerminated");
            }


            return false;
        }
    }

    public class Xianshuai : TriggerSkill
    {
        public Xianshuai() : base("xianshuai")
        {
            events.Add(TriggerEvent.Damage);
            skill_type = SkillType.Replenish;
            frequency = Frequency.Compulsory;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (room.ContainsTag(Name) && room.GetTag(Name) is int count && count == 1)
            {
                List<Player> dys = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in dys)
                    triggers.Add(new TriggerStruct(Name, p));
            }
            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            room.DrawCards(ask_who, 1, Name);
            if (player == ask_who && data is DamageStruct damage)
                room.Damage(new DamageStruct(Name, player, damage.To));

            return false;
        }
    }
    public class XianshuaiRecord : TriggerSkill
    {
        public XianshuaiRecord() : base("#xianshuai")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damage, TriggerEvent.RoundStart };
        }
        public override int Priority => 5;
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Damage)
            {
                int count = 1;
                if (room.ContainsTag("xianshuai") && room.GetTag("xianshuai") is int old)
                    count += old;
                room.SetTag("xianshuai", count);
            }
            else
                room.RemoveTag("xianshuai");
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class JieyingHF : TriggerSkill
    {
        public JieyingHF() : base("jieying_hf")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.Damage, TriggerEvent.CardTargetAnnounced, TriggerEvent.EventPhaseChanging };
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player.GetMark(Name) > 0)
            {
                room.RemovePlayerStringMark(player, Name);
                player.SetMark(Name, 0);
            }
            else if (triggerEvent == TriggerEvent.Damage && player != null && player.Phase != PlayerPhase.NotActive && player.GetMark(Name) > 0)
                player.SetFlags("jieying_hf_pro");
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.Phase == PlayerPhase.Finish)
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.CardTargetAnnounced && player.GetMark(Name) > 0 && player.Phase != PlayerPhase.NotActive
                && data is CardUseStruct use && use.To.Count == 1 && use.Card.Name != Collateral.ClassName)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard.TypeID == CardType.TypeTrick && !(fcard is DelayedTrick) || fcard is Slash)
                    return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                player.SetFlags(Name);
                Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@jieying_hf", true, true, info.SkillPosition);
                player.SetFlags("-jieying_hf");
                if (target != null)
                {
                    room.SetTag(Name, target);
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    return info;
                }
            }
            else if (data is CardUseStruct use)
            {
                List<Player> targets = new List<Player>();
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                foreach (Player p in room.GetOtherPlayers(player))
                {
                    if ((fcard is Peach && !p.IsWounded())
                        || (fcard is IronChain && !p.Chained && !RoomLogic.CanBeChainedBy(room, player, p))
                        || (fcard is FireAttack && p.IsKongcheng())
                        || (fcard is Snatch && !Snatch.Instance.TargetFilter(room, new List<Player>(), p, player, use.Card))
                        || (fcard is Dismantlement && (!RoomLogic.CanDiscard(room, player, p, "hej") || p.IsAllNude()))) continue;

                    if (!use.To.Contains(p) && RoomLogic.IsProhibited(room, player, p, use.Card) == null)
                        targets.Add(p);
                }

                room.SetTag("extra_target_skill", data);                   //for AI
                Player target = room.AskForPlayerChosen(player, targets, Name, "@jieying_hf-extra:::" + use.Card.Name, true);
                room.RemoveTag("extra_target_skill");
                if (target != null)
                {
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, target.Name);
                    LogMessage log = new LogMessage
                    {
                        Type = "$extra_target",
                        From = player.Name,
                        To = new List<string> { target.Name },
                        Card_str = RoomLogic.CardToString(room, use.Card),
                        Arg = Name
                    };
                    room.SendLog(log);

                    room.SetTag(Name, target);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = (Player)room.GetTag(Name);
            room.RemoveTag(Name);
            if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                target.AddMark(Name);
                room.SetPlayerStringMark(target, Name, string.Empty);
            }
            else if (data is CardUseStruct use)
            {
                use.To.Add(target);
                room.SortByActionOrder(ref use);
                data = use;
            }

            return false;
        }
    }

    public class JieyingHFTar : TargetModSkill
    {
        public JieyingHFTar() : base("#jieying_hf-tar")
        {
            pattern = "Slash#TrickCard";
        }

        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            if (card != null && from != null && from.HasFlag("jieying_hf"))
            {
                FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                if (fcard.TypeID == CardType.TypeTrick && !(fcard is DelayedTrick) || fcard is Slash)
                    return true;
            }
            return false;
        }
    }
    public class JieyingHFPro : ProhibitSkill
    {
        public JieyingHFPro() : base("#jieying_hf-pro") { }
        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null)
        {
            if (from != null && card != null && from.HasFlag("jieying_hf_pro"))
                return !(Engine.GetFunctionCard(card.Name) is SkillCard);
            return false;
        }
    }

    public class Weipo : TriggerSkill
    {
        public Weipo() : base("weipo")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen, TriggerEvent.CardFinished, TriggerEvent.TurnStart };
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Replenish;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.TurnStart && player.GetMark(Name) > 0)
                player.SetMark(Name, 0);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard.TypeID == CardType.TypeTrick && !(fcard is DelayedTrick) || fcard is Slash)
                {
                    foreach (Player p in use.To)
                    {
                        if (p != player && RoomLogic.PlayerHasSkill(room, p, Name) && p.HandcardNum < p.MaxHp && p.GetMark(Name) == 0)
                            triggers.Add(new TriggerStruct(Name, p));
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.CardFinished && data is CardUseStruct _use && _use.Card.HasFlag(Name))
            {
                FunctionCard fcard = Engine.GetFunctionCard(_use.Card.Name);
                if (fcard.TypeID == CardType.TypeTrick && !(fcard is DelayedTrick) || fcard is Slash)
                {
                    foreach (Player p in room.GetOtherPlayers(_use.From))
                    {
                        if (p.HasFlag(Name))
                            triggers.Add(new TriggerStruct(Name, p));
                    }
                }
            }

            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use)
            {
                use.Card.SetFlags(Name);
                ask_who.SetFlags(Name);
                room.DrawCards(ask_who, ask_who.MaxHp - ask_who.HandcardNum, Name);
                ask_who.SetMark("weipo_count", ask_who.HandcardNum);
            }
            else
            {
                int count = ask_who.GetMark("weipo_count");
                ask_who.SetMark("weipo_count", 0);
                ask_who.SetFlags("-weipo");
                if (ask_who.HandcardNum < count)
                {
                    ask_who.SetMark(Name, 1);
                    if (!ask_who.IsKongcheng() && player.Alive)
                    {
                        player.SetFlags("weipo_target");
                        List<int> ids = room.AskForExchange(ask_who, Name, 1, 1, "@weipo:" + player.Name, string.Empty, ".", info.SkillPosition);
                        player.SetFlags("-weipo_target");
                        room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, ask_who.Name, player.Name, Name, string.Empty), false);
                    }
                }
            }

            return false;
        }
    }

    public class Minsi : TriggerSkill
    {
        public Minsi() : base("minsi")
        {
            events.Add(TriggerEvent.EventPhaseChanging);
            view_as_skill = new MinsiVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && room.ContainsTag(Name) && room.GetTag(Name) is List<int> ids)
            {
                room.RemoveTag(Name);
                foreach (int id in ids)
                    room.SetCardFlag(id, "-minsi");
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class MinsiVS : ViewAsSkill
    {
        public MinsiVS() : base("minsi")
        {
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.IsNude() && !player.HasUsed(MinsiCard.ClassName);
        }

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            int count = 0;
            foreach (WrappedCard card in selected)
                count += card.Number;
            return count + to_select.Number <= 13 && RoomLogic.CanDiscard(room, player, player, to_select.Id);
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count > 0)
            {
                int count = 0;
                foreach (WrappedCard card in cards)
                    count += card.Number;
                if (count == 13)
                {
                    WrappedCard ms = new WrappedCard(MinsiCard.ClassName) { Skill = Name };
                    ms.AddSubCards(cards);
                    return ms;
                }
            }
            return null;
        }
    }

    public class MinsiCard : SkillCard
    {
        public static string ClassName = "MinsiCard";
        public MinsiCard() : base(ClassName)
        {
            target_fixed = true;
            will_throw = true;
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            int count = card_use.Card.SubCards.Count * 2;
            Player player = card_use.From;
            List<int> ids = room.DrawCards(player, count, "minsi");
            List<int> record = ids;
            if (room.ContainsTag("minsi") && room.GetTag("minsi") is List<int> old)
                record.AddRange(old);
            room.SetTag("minsi", record);
            foreach (int id in ids)
                room.SetCardFlag(id, "minsi");
        }
    }

    public class MinsiTar : TargetModSkill
    {
        public MinsiTar() : base("#minsi-tar")
        {
            pattern = ".";
        }
        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            if (card != null && card.SubCards.Count > 0)
            {
                FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                if (!(fcard is SkillCard))
                {
                    foreach (int id in card.SubCards)
                    {
                        if (!room.GetCard(id).HasFlag("minsi") || !WrappedCard.IsBlack(room.GetCard(id).Suit))
                            return false;
                    }
                    return true;
                }
            }
            return false;
        }
    }

    public class MinsiMax : MaxCardsSkill
    {
        public MinsiMax() : base("#minsi-max") { }

        public override bool Ingnore(Room room, Player player, int card_id) => room.GetCard(card_id).HasFlag("minsi") && WrappedCard.IsRed(room.GetCard(card_id).Suit);
    }

    public class Jijing : TriggerSkill
    {
        public Jijing() : base("jijing")
        {
            events.Add(TriggerEvent.Damaged);
            skill_type = SkillType.Recover;
            view_as_skill = new JijingVS();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.IsWounded() && room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            JudgeStruct judge = new JudgeStruct
            {
                Good = true,
                PlayAnimation = false,
                Who = player,
                Reason = Name
            };

            room.Judge(ref judge);
            player.SetMark(Name, judge.JudgeNumber);
            room.AskForUseCard(player, RespondType.Skill, "@@jijing", "@jijing:::" + judge.Card.Number.ToString(), null, -1, HandlingMethod.MethodUse, true, info.SkillPosition);
            return false;
        }
    }

    public class JijingVS : ViewAsSkill
    {
        public JijingVS() : base("jijing")
        {
            response_pattern = "@@jijing";
        }

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            int count = 0;
            foreach (WrappedCard card in selected)
                count += card.Number;
            return count + to_select.Number <= player.GetMark(Name) && RoomLogic.CanDiscard(room, player, player, to_select.Id);
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count > 0)
            {
                int count = 0;
                foreach (WrappedCard card in cards)
                    count += card.Number;
                if (count == player.GetMark(Name))
                {
                    WrappedCard ms = new WrappedCard(JijingCard.ClassName) { Skill = Name, Mute = true };
                    ms.AddSubCards(cards);
                    return ms;
                }
            }
            return null;
        }
    }

    public class JijingCard : SkillCard
    {
        public static string ClassName = "JijingCard";
        public JijingCard() : base(ClassName)
        {
            will_throw = true;
            target_fixed = true;
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            if (player.IsWounded())
                room.Recover(player, 1);
        }
    }

    public class Zhuide : TriggerSkill
    {
        public Zhuide() : base("zhuide")
        {
            events.Add(TriggerEvent.Death);
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            return RoomLogic.PlayerHasSkill(room, player, Name) ? new TriggerStruct(Name, player) : new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@zhuide", true, true, info.SkillPosition);
            if (target != null)
            {
                player.SetTag(Name, target.Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.FindPlayer((string)player.GetTag(Name));
            bool slash = false;
            bool ana = false;
            bool jink = false;
            bool peach = false;
            List<int> ids = new List<int>();
            foreach (int id in room.DrawPile)
            {
                WrappedCard card = room.GetCard(id);
                if (!slash && card.Name.Contains(Slash.ClassName))
                {
                    slash = true;
                    ids.Add(id);
                }
                if (!ana && card.Name == Analeptic.ClassName)
                {
                    ana = true;
                    ids.Add(id);
                }
                if (!jink && card.Name == Jink.ClassName)
                {
                    jink = true;
                    ids.Add(id);
                }
                if (!peach && card.Name == Peach.ClassName)
                {
                    peach = true;
                    ids.Add(id);
                }

                if (ids.Count == 4) break;
            }
            if (ids.Count > 0)
                room.ObtainCard(target, ref ids, new CardMoveReason(MoveReason.S_REASON_DRAW, target.Name, Name, string.Empty), false);

            return false;
        }
    }

    public class Shiyuan : TriggerSkill
    {
        public Shiyuan() : base("shiyuan")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetConfirmed, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Replenish;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                {
                    p.SetMark("shiyuan_1", 0);
                    p.SetMark("shiyuan_2", 0);
                    p.SetMark("shiyuan_3", 0);
                }
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TargetConfirmed && base.Triggerable(player, room)&& data is CardUseStruct use && player != use.From)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard.TypeID != CardType.TypeSkill)
                {
                    int count = RoomLogic.PlayerHasSkill(room, player, "yuwei") && use.From.Kingdom == "qun" ? 2 : 1;
                    if (use.From.Hp > player.Hp && player.GetMark("shiyuan_3") < count)
                        return new TriggerStruct(Name, player);
                    else if (use.From.Hp == player.Hp && player.GetMark("shiyuan_2") < count)
                        return new TriggerStruct(Name, player);
                    else if (use.From.Hp < player.Hp && player.GetMark("shiyuan_1") < count)
                        return new TriggerStruct(Name, player);
                }
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                int count = 1;
                if (use.From.Hp > player.Hp) count = 3;
                else if (use.From.Hp == player.Hp) count = 2;
                string prompt = string.Format("@shiyuan:::{0}", count);
                if (room.AskForSkillInvoke(player, Name, prompt, info.SkillPosition))
                {
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                int count = 1;
                if (use.From.Hp > player.Hp) count = 3;
                else if (use.From.Hp == player.Hp) count = 2;
                string mark = string.Format("{0}_{1}", Name, count);
                player.AddMark(mark);
                room.DrawCards(player, count, Name);
            }

            return false;
        }
    }


    public class Dushi : TriggerSkill
    {
        public Dushi() : base("dushi")
        {
            events = new List<TriggerEvent> { TriggerEvent.Dying, TriggerEvent.Death };
            skill_type = SkillType.Wizzard;
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.Dying && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.Death && player != null && RoomLogic.PlayerHasSkill(room, player, Name))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            if (triggerEvent == TriggerEvent.Death)
            {
                List<Player> targets = new List<Player>();
                foreach (Player p in room.GetOtherPlayers(player))
                    if (!RoomLogic.PlayerHasSkill(room, p, Name, true)) targets.Add(p);
                if (targets.Count > 0)
                {
                    Player target = room.AskForPlayerChosen(player, targets, Name, "@dushi-get", false, true, info.SkillPosition);
                    room.HandleAcquireDetachSkills(target, Name, true);
                }
            }
            return false;
        }
    }
    public class DushiPro : ProhibitSkill
    {
        public DushiPro() : base("#dushi")
        {
        }

        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null)
        {
            return from != null && to != null && to != from && card.Name == Peach.ClassName
                && RoomLogic.PlayerHasSkill(room, to, Name) && to.HasFlag("Global_Dying");
        }
    }

    public class Yuwei : Skill
    {
        public Yuwei(): base("yuwei"){ lord_skill = true; frequency = Frequency.Compulsory; }
    }


    //淳于琼
    public class CangchuClassic : TriggerSkill
    {
        public CangchuClassic() : base("cangchu_classic")
        {
            events = new List<TriggerEvent> { TriggerEvent.GameStart, TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseChanging };
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            base.Record(triggerEvent, room, player, ref data);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.GameStart && player != null && base.Triggerable(player, room))
            {
                return new TriggerStruct(Name, player);
            }
            else if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.To != null && base.Triggerable(move.To, room)
                && !move.To.HasFlag(Name) && move.To_place == Place.PlaceHand && move.To.Phase == PlayerPhase.NotActive && move.To.GetMark("@gd_liang") < room.AliveCount())
            {
                return new TriggerStruct(Name, move.To);
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name, true);
            GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
            if (triggerEvent == TriggerEvent.GameStart)
            {
                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                room.SetPlayerMark(player, "@gd_liang", 3);
            }
            else
            {
                ask_who.SetFlags(Name);
                room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);
                room.AddPlayerMark(ask_who, "@gd_liang");
            }

            return false;
        }
    }

    public class CangchuMax : MaxCardsSkill
    {
        public CangchuMax() : base("#cangchu") { }
        public override int GetExtra(Room room, Player target) => RoomLogic.PlayerHasShownSkill(room, target, "cangchu_classic") ? target.GetMark("@gd_liang") : 0;
    }

    public class LiangyingClassicVS : OneCardViewAsSkill
    {
        public LiangyingClassicVS() : base("liangying_classic")
        {
            response_pattern = "@@liangying_classic";
        }
        public override bool ViewFilter(Room room, WrappedCard to_select, Player player)
        {
            return player.GetPile("#liangying").Contains(to_select.Id);
        }

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard ss = new WrappedCard(LiangyingClassicCard.ClassName);
            ss.AddSubCard(card);
            return ss;
        }
    }

    public class LiangyingClassicCard : SkillCard
    {
        public static string ClassName = "LiangyingClassicCard";
        public LiangyingClassicCard() : base(ClassName)
        {
            will_throw = false;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && to_select.HasFlag("liangying_classic") && to_select != Self;
        }

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            room.SetTag("liangying_target", card_use.To[0]);

            ResultStruct result = card_use.From.Result;
            result.Assist += card_use.Card.SubCards.Count;
            card_use.From.Result = result;
        }
    }
    public class LiangyingClassic : TriggerSkill
    {
        public LiangyingClassic() : base("liangying_classic")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            view_as_skill = new LiangyingClassicVS();
            skill_type = SkillType.Replenish;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Discard && player.GetMark("@gd_liang") > 0)
                return new TriggerStruct(Name, player);

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

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.DrawCards(player, player.GetMark("@gd_liang"), Name);
            List<Player> friends = room.GetOtherPlayers(player), targets = new List<Player>();
            foreach (Player p in friends)
            {
                p.SetFlags(Name);
            }

            List<int> cards = player.GetCards("he");
            player.PileChange("#liangying", cards);

            List<CardsMoveStruct> moves = new List<CardsMoveStruct>();
            int count = player.GetMark("@gd_liang");
            while (cards.Count > 0 && friends.Count > 0 && count > 0)
            {
                WrappedCard card = room.AskForUseCard(player, RespondType.Skill, "@@liangying_classic", string.Format("@liangying_classic:::{0}", count),
                    null, -1, HandlingMethod.MethodNone, true, info.SkillPosition);
                if (card != null)
                {
                    count--;
                    Player target = (Player)room.GetTag("liangying_target");
                    room.RemoveTag("liangying_target");
                    target.SetFlags("-" + Name);
                    friends.Remove(target);
                    targets.Add(target);
                    CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, Name, string.Empty);
                    CardsMoveStruct move = new CardsMoveStruct(new List<int>(card.SubCards), target, Place.PlaceHand, reason);
                    moves.Add(move);

                    player.PileChange("#liangying", card.SubCards, false);
                    cards.RemoveAll(t => card.SubCards.Contains(t));

                    List<string> args = new List<string> { JsonUntity.Object2Json(card.SubCards), "@attribute:" + target.Name };
                    room.DoNotify(room.GetClient(player), CommandType.S_COMMAND_UPDATE_CARD_FOOTNAME, args);
                }
                else
                    break;
            }

            player.PileChange("#liangying", cards, false);
            foreach (Player p in room.Players)
                p.SetFlags("-liangying_classic");

            if (moves.Count > 0)
            {
                LogMessage l = new LogMessage
                {
                    Type = "#ChoosePlayerWithSkill",
                    From = player.Name,
                    Arg = Name
                };
                l.SetTos(targets);
                room.SendLog(l);

                room.MoveCardsAtomic(moves, false);
            }

            return false;
        }
    }

    public class Shishou : TriggerSkill
    {
        public Shishou() : base("shishou")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsed, TriggerEvent.Damaged, TriggerEvent.EventPhaseStart };
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Wizzard;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.Damaged && base.Triggerable(player, room) && player.GetMark("@gd_liang") > 0 && data is DamageStruct damage
                && damage.Nature == DamageStruct.DamageNature.Fire)
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.CardUsed && base.Triggerable(player, room) && player.GetMark("@gd_liang") > 0
                && data is CardUseStruct use && use.Card.Name == Analeptic.ClassName)
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Start && base.Triggerable(player, room) && player.GetMark("@gd_liang") == 0)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name, true);
            GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
            if (triggerEvent == TriggerEvent.Damaged || triggerEvent == TriggerEvent.CardUsed)
            {
                room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);
                room.RemovePlayerMark(ask_who, "@gd_liang");
            }
            else
            {
                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                room.LoseHp(player);
            }

            return false;
        }
    }

    public class Yangzhong : TriggerSkill
    {
        public Yangzhong() : base("yangzhong")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damage, TriggerEvent.Damaged };
            skill_type = SkillType.Wizzard;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.Damage && data is DamageStruct damage && base.Triggerable(player, room) && damage.To.Alive && player.GetCardCount(true) >= 2)
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.Damaged && data is DamageStruct _damage && base.Triggerable(player, room) && _damage.From != null && _damage.From.Alive
                && _damage.From.GetCardCount(true) >= 2)
                return new TriggerStruct(Name, _damage.From, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            DamageStruct damage = (DamageStruct)data;
            Player target = triggerEvent == TriggerEvent.Damage ? damage.To : player;
            string prompt = triggerEvent == TriggerEvent.Damage ? string.Format("@yangzhong-from:{0}", damage.To.Name) : string.Format("@yangzhong-to:{0}", player.Name);
            bool invoke = room.AskForDiscard(ask_who, Name, 2, 2, true, true, prompt, true, triggerEvent == TriggerEvent.Damage ? info.SkillPosition : null);
            if (invoke)
            {
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, target.Name);
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, player, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", triggerEvent == TriggerEvent.Damage ? 1 : 2, gsk.General, gsk.SkinId);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                Player target = triggerEvent == TriggerEvent.Damage ? damage.To : player;
                if (target.Alive)
                    room.LoseHp(target);
            }

            return false;
        }
    }

    public class Huangkong : TriggerSkill
    {
        public Huangkong() : base("huangkong")
        {
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Replenish;
            events.Add(TriggerEvent.TargetConfirmed);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.IsKongcheng() && data is CardUseStruct use && player.Phase == PlayerPhase.NotActive)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is Slash || fcard.IsNDTrick())
                    return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name, true);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.DrawCards(player, 2, Name);
            return false;
        }
    }

    public class YixiangSP : TriggerSkill
    {
        public YixiangSP() : base("yixiang_sp")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsed, TriggerEvent.DamageInflicted, TriggerEvent.CardEffected, TriggerEvent.EventPhaseChanging };
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Defense;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use && player.Phase == PlayerPhase.Play && player.GetMark(Name) < 2)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (!(fcard is SkillCard))
                {
                    player.AddMark(Name);
                    if (player.GetMark(Name) == 1)
                        room.SetCardFlag(use.Card, "yixiang_first");
                    else if (!(fcard is DelayedTrick) && WrappedCard.IsBlack(use.Card.Suit))
                        room.SetCardFlag(use.Card, "yixiang_second");
                }
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.From == PlayerPhase.Play && player.GetMark(Name) > 0)
                player.SetMark(Name, 0);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.DamageInflicted && data is DamageStruct damage && base.Triggerable(player, room) && damage.From != null
                && damage.From.Phase == PlayerPhase.Play && damage.From != player && damage.Card != null && damage.Card.HasFlag("yixiang_first"))
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.CardEffected && data is CardEffectStruct effect && effect.From != null && effect.From.Phase == PlayerPhase.Play
                && effect.From != player && effect.Card.HasFlag("yixiang_second") && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.DamageInflicted && data is DamageStruct damage)
            {
                room.SendCompulsoryTriggerLog(player, Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);

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
            }
            else if (triggerEvent == TriggerEvent.CardEffected && data is CardEffectStruct effect)
            {
                LogMessage log = new LogMessage
                {
                    Type = "#Skillnullify",
                    From = player.Name,
                    Arg = Name,
                    Arg2 = effect.Card.Name
                };
                room.SendLog(log);

                return true;
            }

            return false;
        }
    }

    public class YirangSP : TriggerSkill
    {
        public YirangSP() : base("yirang_sp")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            skill_type = SkillType.Recover;
        }

        public override bool Triggerable(Player target, Room room)
        {
            if (base.Triggerable(target, room) && target.Phase == PlayerPhase.Play && !target.IsNude())
            {
                bool check = false;
                foreach (int id in target.GetCards("he"))
                {
                    if (Engine.GetFunctionCard(room.GetCard(id).Name).TypeID != CardType.TypeBasic)
                    {
                        check = true;
                        break;
                    }
                }

                if (check) return true;
            }

            return false;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@yirang_sp", true, true, info.SkillPosition);
            if (target != null)
            {
                room.SetTag(Name, target);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = (Player)room.GetTag(Name);
            room.RemoveTag(Name);
            
            List<int> ids = new List<int>();
            foreach (int id in player.GetCards("he"))
            {
                CardType type = Engine.GetFunctionCard(room.GetCard(id).Name).TypeID;
                if (type != CardType.TypeBasic)
                    ids.Add(id);
            }

            ResultStruct result = player.Result;
            result.Assist += ids.Count;
            player.Result = result;

            room.ObtainCard(target, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, Name, string.Empty), false);

            if (player.Alive)
            {
                int count = target.MaxHp - player.MaxHp;
                if (count > 0)
                {
                    player.MaxHp += count;
                    room.BroadcastProperty(player, "MaxHp");

                    LogMessage log = new LogMessage
                    {
                        Type = "$GainMaxHp",
                        From = player.Name,
                        Arg = count.ToString()
                    };
                    room.SendLog(log);

                    room.RoomThread.Trigger(TriggerEvent.MaxHpChanged, room, player);
                }

            }
            if (player.Alive && player.IsWounded())
            {
                RecoverStruct recover = new RecoverStruct
                {
                    Who = player,
                    Recover = Math.Min(ids.Count, player.GetLostHp())
                };
                room.Recover(player, recover, true);
            }

            return false;
        }
    }

    public class Mouni : TriggerSkill
    {
        public Mouni() : base("mouni")
        {
            skill_type = SkillType.Attack;
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.DamageDone, TriggerEvent.Dying };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.Dying && player.HasFlag(Name))
                player.SetFlags("-mouni");
            else if (triggerEvent == TriggerEvent.DamageDone && data is DamageStruct damage && damage.Card != null && room.ContainsTag(Name) && room.GetTag(Name) is int id
                && id == damage.Card.GetEffectiveId())
                room.RemoveTag(Name);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Start && base.Triggerable(player, room))
            {
                bool invoke = false;
                foreach (int id in player.GetCards("h"))
                {
                    if (room.GetCard(id).Name.Contains(Slash.ClassName))
                    {
                        invoke = true;
                        break;
                    }
                }
                if (invoke) return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<Player> targets = new List<Player>();
            WrappedCard slash = new WrappedCard(Slash.ClassName);
            foreach (Player p in room.GetOtherPlayers(player))
                if (RoomLogic.IsProhibited(room, player, p, slash) == null)
                    targets.Add(p);

            if (targets.Count > 0)
            {
                Player target = room.AskForPlayerChosen(player, targets, Name, "@mouni", true, true, info.SkillPosition);
                if (target != null)
                {
                    room.SetTag(Name, target);
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is Player target)
            {
                target.SetFlags(Name);
                int count = 0;
                bool skip = false;
                while (player.Alive && target.Alive && count < 29 && target.HasFlag(Name))
                {
                    WrappedCard slash = null;
                    foreach (int id in player.GetCards("h"))
                    {
                        WrappedCard card = room.GetCard(id);
                        if (card.Name.Contains(Slash.ClassName) && RoomLogic.IsProhibited(room, player, target, card) == null)
                        {
                            slash = card;
                            break;
                        }
                    }

                    if (slash != null)
                    {
                        room.SetTag(Name, slash.GetEffectiveId());
                        count++;
                        room.UseCard(new CardUseStruct(slash, player, target, true), true, true);
                        if (!skip && room.ContainsTag(Name))
                            skip = true;
                    }
                    else
                        break;
                }
                if (target.Alive) target.SetFlags("-mouni");
                if (skip && player.Alive)
                {
                    room.SkipPhase(player, PlayerPhase.Play, true);
                    room.SkipPhase(player, PlayerPhase.Discard, true);
                }
                if (count > 0 && !skip)
                    player.SetFlags("zongfan");
            }
            room.RemoveTag(Name);

            return false;
        }
    }

    public class Zongfan : TriggerSkill
    {
        public Zongfan() : base("zongfan")
        {
            frequency = Frequency.Wake;
            skill_type = SkillType.Recover;
            events.Add(TriggerEvent.EventPhaseStart);
            view_as_skill = new ZongfanVS();
        }

        public override bool Triggerable(Player target, Room room)
        {
            return base.Triggerable(target, room) && target.GetMark(Name) == 0 && target.HasFlag(Name) && target.Phase == PlayerPhase.Finish;
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.DoSuperLightbox(player, info.SkillPosition, Name);
            room.SetPlayerMark(player, Name, 1);
            room.SendCompulsoryTriggerLog(player, Name);

            WrappedCard card = room.AskForUseCard(player, RespondType.Skill, "@@zongfan", "@zongfan", null, -1, HandlingMethod.MethodNone, false, info.SkillPosition);
            if (player.Alive)
                room.HandleAcquireDetachSkills(player, "-mouni|zhangu", false);

            return false;
        }
    }

    public class ZongfanVS : ViewAsSkill
    {
        public ZongfanVS() : base("zongfan") { response_pattern = "@@zongfan"; }
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player) => true;
        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count > 0)
            {
                WrappedCard card = new WrappedCard(ZongfanCard.ClassName);
                card.AddSubCards(cards);
                return card;
            }
            return null;
        }
    }

    public class ZongfanCard : SkillCard
    {
        public static string ClassName = "ZongfanCard";
        public ZongfanCard() : base(ClassName) { }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && to_select != Self;
        }

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            List<int> ids = new List<int>(card_use.Card.SubCards);
            Player player = card_use.From;
            room.ObtainCard(card_use.To[0], ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, card_use.To[0].Name, "zongfan", string.Empty), false);
            if (player.Alive)
            {
                player.MaxHp += ids.Count;
                room.BroadcastProperty(player, "MaxHp");

                LogMessage log = new LogMessage
                {
                    Type = "$GainMaxHp",
                    From = player.Name,
                    Arg = ids.Count.ToString()
                };
                room.SendLog(log);

                room.RoomThread.Trigger(TriggerEvent.MaxHpChanged, room, player);
                RecoverStruct recover = new RecoverStruct
                {
                    Who = player,
                    Recover = ids.Count
                };
                room.Recover(player, recover, true);
            }
        }
    }

    public class Zhangu : TriggerSkill
    {
        public Zhangu() : base("zhangu")
        {
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Wizzard;
            events.Add(TriggerEvent.TurnStart);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.MaxHp > 1 && (player.IsKongcheng() || player.GetEquips().Count == 0))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.SendCompulsoryTriggerLog(player, Name);

            room.LoseMaxHp(player);
            if (player.Alive)
            {
                bool basic = false, equip = false, trick = false;
                List<int> get = new List<int>();
                foreach (int id in room.DrawPile)
                {
                    WrappedCard card = room.GetCard(id);
                    FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                    if (!basic && fcard is BasicCard)
                    {
                        get.Add(id);
                        basic = true;
                    }
                    else if (!equip && fcard is EquipCard)
                    {
                        get.Add(id);
                        equip = true;
                    }
                    else if (!trick && fcard is TrickCard)
                    {
                        get.Add(id);
                        trick = true;
                    }

                    if (get.Count >= 3)
                        break;
                }

                if (get.Count > 0)
                {
                    room.ObtainCard(player, ref get, new CardMoveReason(MoveReason.S_REASON_GOTCARD, player.Name, Name, string.Empty));
                }
            }

            return false;
        }
    }

    public class Lulue : TriggerSkill
    {
        public Lulue() : base("lulue")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            skill_type = SkillType.Wizzard;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Play && !player.IsKongcheng())
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<Player> targets = new List<Player>();
            foreach (Player p in room.GetOtherPlayers(player))
                if (!p.IsKongcheng() && p.HandcardNum < player.HandcardNum)
                    targets.Add(p);
            if (targets.Count > 0)
            {
                Player target = room.AskForPlayerChosen(player, targets, Name, "@lulue", true, true, info.SkillPosition);
                if (target != null)
                {
                    room.SetTag(Name, target);
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is Player target)
            {
                room.RemoveTag(Name);
                string choice = room.AskForChoice(target, Name, "give+slash", new List<string> { "@lulue-from:" + player.Name }, player);
                if (choice == "give")
                {
                    List<int> ids = target.GetCards("h");
                    room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, target.Name, player.Name, Name, string.Empty), false);
                    if (player.Alive)
                        room.TurnOver(player);
                }
                else
                {
                    room.TurnOver(target);
                    if (player.Alive && target.Alive)
                    {
                        WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = "_lulue" };
                        if (RoomLogic.IsProhibited(room, target, player, slash) == null)
                            room.UseCard(new CardUseStruct(slash, target, player));
                    }
                }
            }
            return false;
        }
    }

    public class Zhuixi : TriggerSkill
    {
        public Zhuixi() : base("zhuixi")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageCaused, TriggerEvent.DamageInflicted };
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Wizzard;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is DamageStruct damage && damage.From != null && damage.To != damage.From && damage.From.Alive && damage.From.FaceUp != damage.To.FaceUp)
            {
                return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (RoomLogic.PlayerHasShownSkill(room, player, Name) || room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, player, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", triggerEvent == TriggerEvent.DamageCaused ? 1 : 2, gsk.General, gsk.SkinId);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            DamageStruct damage = (DamageStruct)data;
            if (triggerEvent == TriggerEvent.DamageCaused)
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
            else
            {
                LogMessage log = new LogMessage
                {
                    Type = "#AddDamaged",
                    From = player.Name,
                    Arg = Name,
                    Arg2 = (++damage.Damage).ToString()
                };
                room.SendLog(log);

                data = damage;
            }

            return false;
        }
    }

    public class Kangge : TriggerSkill
    {
        public Kangge() : base("kangge")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime, TriggerEvent.TurnStart, TriggerEvent.Dying, TriggerEvent.Death, TriggerEvent.EventPhaseChanging, TriggerEvent.RoundStart };
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                    p.SetMark("kangge_draw", 0);
            }
            else if (triggerEvent == TriggerEvent.RoundStart)
                foreach (Player p in room.GetAlivePlayers())
                    p.SetMark("kangge_recover", 0);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.TurnStart && base.Triggerable(player, room) && player.GetMark(Name) == 0)
                triggers.Add(new TriggerStruct(Name, player));
            else if (triggerEvent == TriggerEvent.Dying && player.Alive && player.Hp < 1)
            {
                List<Player> yw = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in yw)
                {
                    if (player != p && p.ContainsTag(Name) && p.GetTag(Name) is string target && target == player.Name && p.GetMark("kangge_recover") == 0)
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }
            else if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.To != null
                && move.To.Phase == PlayerPhase.NotActive && move.To_place == Place.PlaceHand)
            {
                List<Player> yw = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in yw)
                {
                    if (p != move.To && p.ContainsTag(Name) && p.GetTag(Name) is string target && target == move.To.Name && p.GetMark("kangge_draw") < 3)
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }
            else if (triggerEvent == TriggerEvent.Death)
            {
                List<Player> yw = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in yw)
                {
                    if (p != player && p.ContainsTag(Name) && p.GetTag(Name) is string target && target == player.Name)
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }

            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && !room.AskForSkillInvoke(ask_who, Name, data, info.SkillPosition))
                return new TriggerStruct();
            else if (triggerEvent == TriggerEvent.Dying && !room.AskForSkillInvoke(ask_who, Name, player, info.SkillPosition))
                return new TriggerStruct();

            return info;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.TurnStart)
            {
                List<Player> targets = room.GetOtherPlayers(player);
                Player target = room.AskForPlayerChosen(player, targets, Name, "@kangge", false, true, info.SkillPosition);
                if (target == null)
                {
                    Shuffle.shuffle(ref targets);
                    target = targets[0];
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, target.Name);
                    room.NotifySkillInvoked(player, Name);
                    LogMessage log = new LogMessage
                    {
                        Type = "#ChoosePlayerWithSkill",
                        From = player.Name,
                        To = new List<string> { target.Name },
                        Arg = Name
                    };
                    room.SendLog(log);
                }

                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);

                player.SetMark(Name, 1);
                player.SetTag(Name, target.Name);
                room.SetPlayerStringMark(target, Name, string.Empty);
            }
            else if (triggerEvent == TriggerEvent.Dying)
            {
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);

                ask_who.SetMark("kangge_recover", 1);
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, player.Name);
                int count = 1 - player.Hp;
                RecoverStruct recover = new RecoverStruct();
                recover.Recover = count;
                recover.Who = ask_who;
                room.Recover(player, recover, true);
            }
            else if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move)
            {
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);
                
                int count = Math.Min(3 - ask_who.GetMark("kangge_draw"), move.Card_ids.Count);
                ask_who.AddMark("kangge_draw", count);
                room.DrawCards(ask_who, count, Name);
            }
            else if (triggerEvent == TriggerEvent.Death)
            {
                ask_who.RemoveTag(Name);
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);

                room.SendCompulsoryTriggerLog(ask_who, Name);
                room.ThrowAllCards(ask_who);
                room.LoseHp(ask_who);
            }

            return false;
        }
    }

    public class Jielie : TriggerSkill
    {
        public Jielie() : base("jielie")
        {
            events.Add(TriggerEvent.DamageInflicted);
            skill_type = SkillType.Masochism;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is DamageStruct damage && damage.From != player)
            {
                if (damage.From == null || !player.ContainsTag("kangge") || !(player.GetTag("kangge") is string target) || target != damage.From.Name)
                    return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<string> suits = new List<string>();
            suits.Add(WrappedCard.GetSuitString(WrappedCard.CardSuit.Club));
            suits.Add(WrappedCard.GetSuitString(WrappedCard.CardSuit.Diamond));
            suits.Add(WrappedCard.GetSuitString(WrappedCard.CardSuit.Heart));
            suits.Add(WrappedCard.GetSuitString(WrappedCard.CardSuit.Spade));
            suits.Add("cancel");
            string choice = room.AskForChoice(player, Name, string.Join("+", suits), new List<string> { "@jielie" }, data, info.SkillPosition);
            if (choice != "cancel")
            {
                player.SetTag(Name, choice);
                room.NotifySkillInvoked(player, Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                LogMessage log = new LogMessage()
                {
                    Type = "#ChooseSuit",
                    From = player.Name,
                    Arg = choice,
                };
                room.SendLog(log);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage && player.GetTag(Name) is string choice && player.GetTag("kangge") is string target_name)
            {
                player.RemoveTag(Name);
                room.LoseHp(player, damage.Damage);

                Player target = room.FindPlayer(target_name);
                if (target != null)
                {
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, target_name);
                    WrappedCard.CardSuit suit = WrappedCard.GetSuit(choice);
                    List<int> ids = new List<int>();

                    foreach (int id in room.DiscardPile)
                    {
                        if (room.GetCard(id).Suit == suit)
                        {
                            ids.Add(id);
                            if (ids.Count >= damage.Damage)
                                break;
                        }
                    }
                    if (ids.Count > 0)
                        room.ObtainCard(target, ref ids, new CardMoveReason(MoveReason.S_REASON_RECYCLE, player.Name, target_name, Name, string.Empty), true);
                }
            }

            return true;
        }
    }

    public class Langmie : TriggerSkill
    {
        public Langmie() : base("langmie")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseEnd, TriggerEvent.EventPhaseChanging, TriggerEvent.CardUsed, TriggerEvent.Damage, TriggerEvent.EventPhaseStart };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use && player != null && player.Alive && player.Phase == PlayerPhase.Play)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is BasicCard)
                {
                    player.AddMark("langmie_basic");
                }
                else if (fcard is TrickCard)
                {
                    player.AddMark("langmie_trick");
                }
                else if (fcard is EquipCard)
                {
                    player.AddMark("langmie_equip");
                }
            }
            else if (triggerEvent == TriggerEvent.Damage && data is DamageStruct damage && player != null && player.Alive && player.Phase != PlayerPhase.NotActive)
                player.AddMark("langmie_damage");
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change)
            {
                if (change.From == PlayerPhase.Play)
                {
                    player.SetMark("langmie_basic", 0);
                    player.SetMark("langmie_trick", 0);
                    player.SetMark("langmie_equip", 0);
                }
                if (change.To == PlayerPhase.NotActive)
                    player.SetMark("langmie_damage", 0);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.EventPhaseEnd && player.Alive && player.Phase == PlayerPhase.Play &&
                (player.GetMark("langmie_basic") > 1 || player.GetMark("langmie_trick") > 1 || player.GetMark("langmie_equip") > 1))
            {
                List<Player> hr = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in hr)
                    if (p != player)
                        triggers.Add(new TriggerStruct(Name, p));
            }
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Alive && player.Phase == PlayerPhase.Finish && player.GetMark("langmie_damage") > 1)
            {
                List<Player> hr = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in hr)
                    if (p != player)
                        triggers.Add(new TriggerStruct(Name, p));
            }

            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.EventPhaseEnd && room.AskForSkillInvoke(ask_who, Name, data, info.SkillPosition))
            {
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                return info;
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart && room.AskForDiscard(ask_who, Name, 1, 1, true, true, "@langmie:" + player.Name, true, info.SkillPosition))
            {
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, player.Name);
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.EventPhaseEnd)
                room.DrawCards(ask_who, 1, Name);
            else
                room.Damage(new DamageStruct(Name, ask_who, player, 1));

            return false;
        }
    }

    public class Koulue : TriggerSkill
    {
        public Koulue() :base("koulue")
        {
            events.Add(TriggerEvent.Damage);
            skill_type = SkillType.Attack;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (Triggerable(player, room) && player.Phase == PlayerPhase.Play && data is DamageStruct damage && damage.To.Alive && damage.To != player && !damage.To.IsKongcheng())
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage && room.AskForSkillInvoke(player, Name, damage.To, info.SkillPosition))
            {
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, damage.To.Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                List<string> patterns = new List<string>();
                for (int i = 0; i < Math.Max(1, Math.Min(damage.To.GetLostHp(), damage.To.HandcardNum)); i++)
                    patterns.Add("h^false^none");
                List<int> ids = room.AskForCardsChosen(player, damage.To, patterns, Name);
                room.ShowCards(damage.To, ids, Name);
                bool red = false;
                List<int> gets = new List<int>();
                foreach (int id in ids)
                {
                    WrappedCard card = room.GetCard(id);
                    if (!red && WrappedCard.IsRed(card.Suit)) red = true;
                    if (card.Name.Contains(Slash.ClassName) || card.Name == Duel.ClassName || card.Name == FireAttack.ClassName
                        || card.Name == SavageAssault.ClassName || card.Name == ArcheryAttack.ClassName)
                    {
                        if (RoomLogic.CanGetCard(room, player, damage.To, id))
                            gets.Add(id);
                    }
                }
                if (gets.Count > 0)
                    room.ObtainCard(player, ref gets, new CardMoveReason(MoveReason.S_REASON_EXTRACTION, player.Name, damage.To.Name, Name, string.Empty));
                if (red && player.Alive)
                {
                    if (player.IsWounded())
                        room.LoseMaxHp(player);
                    else
                        room.LoseHp(player);

                    if (player.Alive)
                        room.DrawCards(player, 2, Name);
                }
            }

            return false;
        }
    }

    public class Suiren : TriggerSkill
    {
        public Suiren() : base("suiren")
        {
            events.Add(TriggerEvent.Death);
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player != null && RoomLogic.PlayerHasSkill(room, player, Name) && !player.IsKongcheng())
            {
                foreach (int id in player.GetCards("h"))
                {
                    WrappedCard card = room.GetCard(id);
                    if (card.Name.Contains(Slash.ClassName) || card.Name == Duel.ClassName || card.Name == FireAttack.ClassName
                        || card.Name == SavageAssault.ClassName || card.Name == ArcheryAttack.ClassName)
                        return new TriggerStruct(Name, player);
                }
            }
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@suiren", true, true, info.SkillPosition);
            if (target != null)
            {
                room.SetTag(Name, target);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is Player target)
            {
                room.RemoveTag(Name);
                List<int> ids = new List<int>();
                foreach (int id in player.GetCards("h"))
                {
                    WrappedCard card = room.GetCard(id);
                    if (card.Name.Contains(Slash.ClassName) || card.Name == Duel.ClassName || card.Name == FireAttack.ClassName
                        || card.Name == SavageAssault.ClassName || card.Name == ArcheryAttack.ClassName)
                        ids.Add(id);
                }

                if (ids.Count > 0)
                    room.ObtainCard(target, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, Name, string.Empty), false);
            }

            return false;
        }
    }

    public class HuoshuiC : TriggerSkill
    {
        public HuoshuiC() : base("huoshui_classic")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.EventPhaseChanging };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.Players)
                {
                    if (p.GetMark(Name) > 0)
                    {
                        p.SetMark(Name, 0);
                        room.RemovePlayerStringMark(p, Name);
                        room.FilterCards(p, p.GetCards("he"), true);
                    }
                }
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Start && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player skill_target, ref object data, Player player, TriggerStruct info)
        {
            int count = Math.Max(1, player.GetLostHp());
            List<Player> targets = room.AskForPlayersChosen(player, room.GetOtherPlayers(player), Name, 0, count, "@huoshui_c:::" + count.ToString(), true, info.SkillPosition);
            if (targets.Count > 0)
            {
                room.SetTag(Name, targets);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player skill_target, ref object data, Player machao, TriggerStruct info)
        {
            if (room.GetTag(Name) is List<Player> targets)
            {
                foreach (Player target in targets)
                    DoTieqi(room, target);
            }
            return false;
        }

        private void DoTieqi(Room room, Player target)
        {
            room.SetPlayerStringMark(target, Name, string.Empty);
            target.SetMark(Name, 1);
            room.FilterCards(target, target.GetCards("he"), true);
        }
    }
    public class HuoshuiInvalid : InvalidSkill
    {
        public HuoshuiInvalid() : base("#huoshui_classic")
        {
        }

        public override bool Invalid(Room room, Player player, string skill)
        {
            if (player.HasEquip(skill)) return false;
            Skill s = Engine.GetSkill(skill);
            return s != null && !s.Attached_lord_skill && s.SkillFrequency != Frequency.Compulsory && s.SkillFrequency != Frequency.Wake && player.GetMark("huoshui_classic") > 0;
        }
    }

    public class QingchengC : ZeroCardViewAsSkill
    {
        public QingchengC() : base("qingcheng_classic") { }
        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.IsKongcheng() && !player.HasUsed(QingchengCCard.ClassName);
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(QingchengCCard.ClassName) { Skill = Name };
        }
    }

    public class QingchengCCard : SkillCard
    {
        public static string ClassName = "QingchengCCard";
        public QingchengCCard() : base(ClassName)
        { }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && to_select != Self && to_select.HandcardNum <= Self.HandcardNum && to_select.IsMale();
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player a = card_use.From;
            Player b = card_use.To[0];

            int n1 = a.HandcardNum;
            int n2 = b.HandcardNum;

            CardsMoveStruct move1 = new CardsMoveStruct(a.GetCards("h"), b, Place.PlaceHand,
                new CardMoveReason(MoveReason.S_REASON_SWAP, a.Name, b.Name, "qingcheng_classic", null));
            CardsMoveStruct move2 = new CardsMoveStruct(b.GetCards("h"), a, Place.PlaceHand,
                new CardMoveReason(MoveReason.S_REASON_SWAP, b.Name, a.Name, "qingcheng_classic", null));
            List<CardsMoveStruct> exchangeMove = new List<CardsMoveStruct> { move1, move2 };
            room.MoveCards(exchangeMove, false);

            LogMessage log = new LogMessage
            {
                Type = "#Dimeng",
                From = a.Name,
                To = new List<string> { b.Name },
                Arg = n1.ToString(),
                Arg2 = n2.ToString()
            };
            room.SendLog(log);
            Thread.Sleep(500);
        }
    }

    public class Guowu : TriggerSkill
    {
        public Guowu() : base("guowu")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging, TriggerEvent.EventPhaseStart };
            skill_type = SkillType.Attack;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.From == PlayerPhase.Play)
            {
                player.SetFlags("-guowu_distance");
                player.SetFlags("-guowu_tar");
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Play && base.Triggerable(player, room) && !player.IsKongcheng())
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.ShowAllCards(player, null, Name, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
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
                player.SetFlags("guowu_distance");
            if (player.Alive && count > 2)
                player.SetFlags("guowu_tar");

            return false;
        }
    }

    public class GuowuTar : TargetModSkill
    {
        public GuowuTar() : base("#guowu", false)
        {
            pattern = "Slash#TrickCard";
        }

        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern) => from.HasFlag("guowu_distance");
        public override int GetExtraTargetNum(Room room, Player from, WrappedCard card) => from.HasFlag("guowu_tar") ? 2 : 0;
    }

    public class Zhuangrong : TriggerSkill
    {
        public Zhuangrong() : base("zhuangrong")
        {
            events.Add(TriggerEvent.EventPhaseChanging);
            skill_type = SkillType.Recover;
            frequency = Frequency.Wake;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    if (p.GetMark(Name) == 0 && (p.Hp == 1 || p.HandcardNum == 1))
                        triggers.Add(new TriggerStruct(Name, p));
            }

            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            room.DoSuperLightbox(ask_who, info.SkillPosition, Name);
            room.SetPlayerMark(ask_who, Name, 1);
            room.SendCompulsoryTriggerLog(ask_who, Name);

            room.LoseMaxHp(ask_who);
            if (ask_who.Alive && ask_who.IsWounded())
            {
                int count = ask_who.MaxHp - ask_who.Hp;
                room.Recover(ask_who, count);
            }
            if (ask_who.Alive && ask_who.HandcardNum < ask_who.MaxHp)
            {
                int count = ask_who.MaxHp - ask_who.HandcardNum;
                room.DrawCards(ask_who, count, Name);
            }

            if (ask_who.Alive)
                room.HandleAcquireDetachSkills(ask_who, "shenwei|wushuang", true);

            return false;
        }
    }

    public class Shenwei : DrawCardsSkill
    {
        public Shenwei() : base("shenwei") { frequency = Frequency.Compulsory; }

        public override int GetDrawNum(Room room, Player player, int n) => n + 2;
    }

    public class ShenweiMax : MaxCardsSkill
    {
        public ShenweiMax() : base("#shenwei") { }
        public override int GetExtra(Room room, Player target)
        {
            return RoomLogic.PlayerHasSkill(room, target, "shenwei") ? 2 : 0;
        }
    }

    public class Chaofeng : TriggerSkill
    {
        public Chaofeng() : base("chaofeng")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageCaused, TriggerEvent.CardsMoveOneTime };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null && move.To_place == Place.DiscardPile && move.Reason.SkillName == Name
                && (move.Reason.Reason & MoveReason.S_MASK_BASIC_REASON) == MoveReason.S_REASON_DISCARD && move.Card_ids.Count == 1)
            {
                move.From.SetTag(Name, move.Card_ids[0]);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.DamageCaused && base.Triggerable(player, room) && player.Phase == PlayerPhase.Play && !player.HasFlag(Name) && !player.IsKongcheng())
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                room.SetTag("chaofeng_damage", data);
                bool invoke = room.AskForDiscard(player, Name, 1, 1, true, false, "@chaofeng:" + damage.To.Name, true, info.SkillPosition);
                room.RemoveTag("chaofeng_damage");
                if (invoke)
                {
                    player.SetFlags(Name);
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage && player.GetTag(Name) is int id)
            {
                player.RemoveTag(Name);
                int count = 1;
                WrappedCard card = room.GetCard(id);
                bool add = false;

                if (damage.Card != null)
                {
                    FunctionCard damage_type = Engine.GetFunctionCard(damage.Card.Name);
                    if (!Engine.IsSkillCard(damage.Card.Name))
                    {
                        if (damage.Card.Suit != WrappedCard.CardSuit.NoSuit && WrappedCard.IsBlack(damage.Card.Suit) == WrappedCard.IsBlack(card.Suit)) count++;
                        if (Engine.GetFunctionCard(card.Name).TypeID == damage_type.TypeID) add = true;
                    }
                }

                room.DrawCards(player, count, Name);

                if (add)
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

            return false;
        }
    }

    public class Chuanshu : TriggerSkill
    {
        public Chuanshu() : base("chuanshu")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart };
            frequency = Frequency.Limited;
            limit_mark = "@chuanshu";
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Start && base.Triggerable(player, room) && player.GetMark(limit_mark) == 1 && player.IsWounded())
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@chuanshu-target", true, true, info.SkillPosition);
            if (target != null)
            {
                room.SetTag(Name, target);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.RemovePlayerMark(player, limit_mark);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.DoSuperLightbox(player, info.SkillPosition, Name);
            if (room.GetTag(Name) is Player target)
            {
                room.RemoveTag(Name);
                room.HandleAcquireDetachSkills(target, "chaofeng", true);
            }
            if (player.Alive)
                room.HandleAcquireDetachSkills(player, "longdan_jx|congjian_jx|chuanyun", true);

            return false;
        }
    }

    public class Chuanyun : TriggerSkill
    {
        public Chuanyun() : base("chuanyun")
        {
            events = new List<TriggerEvent> {  TriggerEvent.TargetChosen };
            skill_type = SkillType.Attack;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && base.Triggerable(player, room) && data is CardUseStruct use && use.Card != null)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is Slash)
                    return new TriggerStruct(Name, player, use.To);
            }
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player skill_target, ref object data, Player player, TriggerStruct info)
        {
            if (skill_target.HasEquip() && RoomLogic.CanDiscard(room, skill_target, skill_target, "e") && room.AskForSkillInvoke(player, Name, skill_target, info.SkillPosition))
            {
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, skill_target.Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player skill_target, ref object data, Player machao, TriggerStruct info)
        {
            List<int> revers = new List<int>();
            foreach (int id in skill_target.GetCards("e"))
                if (!RoomLogic.CanDiscard(room, skill_target, skill_target, id)) revers.Add(id);
            List<int> discard = room.ForceToDiscard(skill_target, skill_target.GetCards("e"), 1, true);
            if (discard.Count > 0)
                room.ThrowCard(ref discard, new CardMoveReason(MoveReason.S_REASON_THROW, skill_target.Name, Name, string.Empty), skill_target);

            return false;
        }
    }

    public class Zhenge : TriggerSkill
    {
        public Zhenge() : base("zhenge")
        {
            events.Add(TriggerEvent.EventPhaseStart);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Start)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.AskForPlayerChosen(player, room.GetAlivePlayers(), Name, "@zhenge", true, true, info.SkillPosition);
            if (target != null)
            {
                room.SetTag(Name, target);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is Player target)
            {
                int count = Math.Min(5, target.GetMark(Name) + 1);
                target.SetMark(Name, count);
                room.SetPlayerStringMark(target, Name, count.ToString());
                bool check = true;
                foreach (Player p in room.GetOtherPlayers(target))
                {
                    if (!RoomLogic.InMyAttackRange(room, target, p))
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = "_zhenge" };
                    List<Player> targets = new List<Player>();
                    foreach (Player p in room.GetOtherPlayers(target))
                    {
                        if (RoomLogic.IsProhibited(room, target, p, slash) == null)
                            targets.Add(p);
                    }

                    if (targets.Count > 0)
                    {
                        player.SetFlags(Name);
                        Player victim = room.AskForPlayerChosen(player, targets, Name, "@zhenge-slash:" + target.Name, true, false, info.SkillPosition);
                        player.SetFlags("-zhenge");
                        if (victim != null)
                            room.UseCard(new CardUseStruct(slash, target, victim, false));
                    }
                }
                room.RemoveTag(Name);
            }
            return false;
        }
    }

    public class ZhengeRange : AttackRangeSkill
    {
        public ZhengeRange() : base("#zhenge") { }
        public override int GetExtra(Room room, Player target, bool include_weapon) => target.GetMark("zhenge");
    }

    public class Xinghan : TriggerSkill
    {
        public Xinghan() : base("xinghan")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damage, TriggerEvent.CardUsed, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Replenish;
            frequency = Frequency.Compulsory;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName) && room.Current != null && !room.ContainsTag(Name))
            {
                use.Card.SetFlags(Name);
                room.SetTag(Name, true);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                room.RemoveTag(Name);
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.Damage && data is DamageStruct damage && player != null && player.Alive && damage.Card != null
                && damage.Card.Name.Contains(Slash.ClassName) && damage.Card.HasFlag(Name) && player.GetMark("zhenge") > 0)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    triggers.Add(new TriggerStruct(Name, p));
            }
            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            int max = 0;
            foreach (Player p in room.GetAlivePlayers())
                if (p.HandcardNum > max) max = p.HandcardNum;
            int number = 0;
            foreach (Player p in room.GetAlivePlayers())
                if (p.HandcardNum == max) number++;
            if (number > 1 || ask_who.HandcardNum != max)
                room.DrawCards(ask_who, Math.Min(5, RoomLogic.GetAttackRange(room, player, true)), Name);
            else
                room.DrawCards(ask_who, 1, Name);

            return false;
        }
    }

    public class Tianze : TriggerSkill
    {
        public Tianze() : base("tianze")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardFinished, TriggerEvent.FinishJudge };
            skill_type = SkillType.Wizzard;
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.CardFinished && player != null && player.Alive && player.Phase == PlayerPhase.Play
                && data is CardUseStruct use && WrappedCard.IsBlack(use.Card.Suit) && use.IsHandcard)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    if (p != player && !p.IsNude() && !p.HasFlag(Name))
                        triggers.Add(new TriggerStruct(Name, p));
            }
            else if (triggerEvent == TriggerEvent.FinishJudge && data is JudgeStruct judge && WrappedCard.IsBlack(judge.Card.Suit))
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    if (p != player)
                        triggers.Add(new TriggerStruct(Name, p));
            }

            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.CardFinished)
            {
                player.SetFlags("tianze_target");
                List<int> ids = room.AskForExchange(ask_who, Name, 1, 0, "@tianze:" + player.Name, string.Empty, ".|black!", info.SkillPosition);
                player.SetFlags("-tianze_target");
                if (ids.Count > 0)
                {
                    ask_who.SetFlags(Name);
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, player.Name);
                    GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                    room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                    room.NotifySkillInvoked(ask_who, Name);
                    room.ThrowCard(ref ids, ask_who, null, Name);
                    return info;
                }
            }
            else if (triggerEvent == TriggerEvent.FinishJudge)
                return info;

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.CardFinished)
            {
                if (player.Alive && ask_who.Alive)
                    room.Damage(new DamageStruct(Name, ask_who, player));
            }
            else
            {
                room.SendCompulsoryTriggerLog(ask_who, Name, true);
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);

                room.DrawCards(ask_who, 1, Name);
            }

            return false;
        }
    }

    public class Difa : TriggerSkill
    {
        public Difa() : base("difa")
        {
            events.Add(TriggerEvent.CardsMoveOneTime);
            skill_type = SkillType.Replenish;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardsMoveOneTimeStruct move && move.To_place == Place.PlaceHand && move.Reason.Reason == MoveReason.S_REASON_DRAW
                && base.Triggerable(move.To, room) && move.To.Phase != PlayerPhase.NotActive && move.From_places.Contains(Place.DrawPile) && !move.To.HasFlag(Name))
            {
                foreach (int id in move.Card_ids)
                    if (WrappedCard.IsRed(room.GetCard(id).Suit) && room.GetCardPlace(id) == Place.PlaceHand && room.GetCardOwner(id) == move.To)
                        return new TriggerStruct(Name, move.To);
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move)
            {
                List<int> ids = new List<int>();
                foreach (int id in move.Card_ids)
                    if (WrappedCard.IsRed(room.GetCard(id).Suit) && room.GetCardPlace(id) == Place.PlaceHand && room.GetCardOwner(id) == move.To)
                        ids.Add(id);

                List<int> discard = room.AskForExchange(ask_who, Name, ids.Count, 0, "@difa", string.Empty,
                    string.Format("{0}!", string.Join("#", JsonUntity.IntList2StringList(ids))), info.SkillPosition);
                if (discard.Count > 0)
                {
                    ask_who.SetFlags(Name);
                    room.ThrowCard(ref discard, ask_who, null, Name);
                    ask_who.SetMark(Name, discard.Count);
                    room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                    return info;
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (ask_who.Alive)
            {
                int count = ask_who.GetMark(Name);
                List<string> cards = new List<string>();
                while (count > 0)
                {
                    string card = room.AskForChoice(ask_who, Name, string.Join("+", ViewAsSkill.GetGuhuoCards(room, "td")), null, null, info.SkillPosition);
                    cards.Add(card);
                    LogMessage log = new LogMessage
                    {
                        Type = "#difa",
                        From = ask_who.Name,
                        Arg = card
                    };
                    room.SendLog(log);
                    count--;
                }
                List<string> gets = new List<string>();
                List<int> ids = new List<int>();
                foreach (string card_name in cards)
                {
                    foreach (int id in room.DrawPile)
                    {
                        if (room.GetCard(id).Name == card_name && !ids.Contains(id))
                        {
                            ids.Add(id);
                            gets.Add(card_name);
                            break;
                        }
                    }
                }
                foreach (string card in gets)
                    cards.Remove(card);

                foreach (string card_name in cards)
                {
                    foreach (int id in room.DiscardPile)
                    {
                        if (room.GetCard(id).Name == card_name && !ids.Contains(id))
                        {
                            ids.Add(id);
                            gets.Add(card_name);
                            break;
                        }
                    }
                }

                if (ids.Count > 0)
                    room.ObtainCard(ask_who, ref ids, new CardMoveReason(MoveReason.S_REASON_GOTCARD, ask_who.Name, Name, string.Empty), true);
            }
            return false;
        }
    }

    public class XuezhaoEffect : TriggerSkill
    {
        public XuezhaoEffect() : base("#xuezhao-effect")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen, TriggerEvent.EventPhaseChanging, TriggerEvent.TrickCardCanceling };
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player.GetMark("xuezhao") > 0)
                player.SetMark("xuezhao", 0);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use && player.Alive)
            {
                if (use.Card.Name.Contains(Slash.ClassName) || use.Card.Name == Duel.ClassName || use.Card.Name == Collateral.ClassName
                    || use.Card.Name == ArcheryAttack.ClassName || use.Card.Name == SavageAssault.ClassName)
                {
                    foreach (Player p in use.To)
                    {
                        string mark = string.Format("xuezhao_{0}", p.Name);
                        if (p != player && player.HasFlag(mark)) return new TriggerStruct(Name, player);
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.TrickCardCanceling && data is CardEffectStruct effect && player != effect.From && effect.From != null && effect.From.Alive)
            {
                string mark = string.Format("xuezhao_{0}", player.Name);
                if (effect.From.HasFlag(mark)) return new TriggerStruct(Name, effect.From);
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use)
            {
                List<Player> targets = new List<Player>();
                if (use.Card.Name.Contains(Slash.ClassName) || use.Card.Name == Duel.ClassName || use.Card.Name == Collateral.ClassName
                    || use.Card.Name == ArcheryAttack.ClassName || use.Card.Name == SavageAssault.ClassName)
                {
                    for (int i = 0; i < use.EffectCount.Count; i++)
                    {
                        CardBasicEffect effect = use.EffectCount[i];
                        string mark = string.Format("xuezhao_{0}", effect.To.Name);
                        if (player.HasFlag(mark))
                        {
                            effect.Effect2 = 0;
                            if (!targets.Contains(effect.To))
                                targets.Add(effect.To);
                        }
                    }
                }

                if (targets.Count > 0)
                {
                    room.SortByActionOrder(ref targets);
                    foreach (Player p in targets)
                    {
                        room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, p.Name);
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.TrickCardCanceling)
                return true;

            return false;
        }
    }

    public class XuezhaoTar : TargetModSkill
    {
        public XuezhaoTar() : base("#xuezhao", false) { }
        public override int GetResidueNum(Room room, Player from, WrappedCard card)
        {
            return from.GetMark("xuezhao");
        }
    }

    public class Xuezhao : OneCardViewAsSkill
    {
        public Xuezhao() : base("xuezhao")
        {
            filter_pattern = ".!";
            skill_type = SkillType.Wizzard;
        }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(XuezhaoCard.ClassName);

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard xz = new WrappedCard(XuezhaoCard.ClassName) { Skill = Name };
            xz.AddSubCard(card);
            return xz;
        }
    }

    public class XuezhaoCard : SkillCard
    {
        public static string ClassName = "XuezhaoCard";
        public XuezhaoCard() : base(ClassName)
        {
            will_throw = true;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count < Self.MaxHp && to_select != Self;
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            foreach (Player p in card_use.To)
            {
                if (player.Alive && p.Alive)
                {
                    bool draw = false;
                    if (!p.IsNude())
                    {
                        List<int> ids = room.AskForExchange(p, "xuezhao", 1, 0, "@xuezhao:" + player.Name, string.Empty, "..", null);
                        if (ids.Count > 0)
                        {
                            draw = true;
                            room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, p.Name, player.Name, "xuezhao", string.Empty), false);
                        }
                    }
                    if (draw)
                    {
                        if (p.Alive) room.DrawCards(p, 1, "xuezhao");
                        player.AddMark("xuezhao");
                    }
                    else
                    {
                        string mark = string.Format("xuezhao_{0}", p.Name);
                        player.SetFlags(mark);
                    }
                }
            }
        }
    }

    public class Wangzhu : TriggerSkill
    {
        public Wangzhu() : base("wangzhu")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageInflicted };
            skill_type = SkillType.Defense;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is DamageStruct damage && damage.From != null && damage.From != player && !player.IsKongcheng()
                && !player.HasFlag(Name) && RoomLogic.CanDiscard(room, player, player, "h"))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int royal = 1, rebel = 0;
            foreach (Player p in room.GetAlivePlayers())
            {
                if (p.GetRoleEnum() == PlayerRole.Loyalist)
                    royal++;
                else if (p.GetRoleEnum() == PlayerRole.Rebel)
                    rebel++;
            }
            bool random = true;
            switch (player.GetRoleEnum())
            {
                case PlayerRole.Renegade:
                    if (royal <= 1 && rebel <= 1) random = false;
                    break;
                case PlayerRole.Lord:
                case PlayerRole.Loyalist:
                    if (royal >= rebel) random = false;
                    break;
                case PlayerRole.Rebel:
                    if (royal <= rebel) random = false;
                    break;
            }
            DamageStruct damage = (DamageStruct)data;
            bool invoke = false;
            if (random)
            {
                if (room.AskForSkillInvoke(player, Name, "@wangzhu-random:" + damage.From.Name, info.SkillPosition))
                {
                    List<int> discard = room.ForceToDiscard(player, player.GetCards("h"), 1, true);
                    room.ThrowCard(ref discard, player, null, Name);
                    invoke = true;
                }
            }
            else if (room.AskForDiscard(player, Name, 1, 1, true, false, "@wangzhu:" + damage.From.Name, true, info.SkillPosition))
                invoke = true;

            if (invoke)
            {
                player.SetFlags(Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
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

    public class Yingshui : ViewAsSkill
    {
        public Yingshui() : base("yingshui")
        {
        }
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            if (room.GetRoomState().GetCurrentCardUseReason() == CardUseReason.CARD_USE_REASON_PLAY)
                return selected.Count == 0;
            else
                return Engine.GetFunctionCard(to_select.Name) is EquipCard;
        }

        public override bool IsAvailable(Room room, Player invoker, CardUseReason reason, RespondType respond, string pattern, string position = null)
        {
            switch (reason)
            {
                case CardUseReason.CARD_USE_REASON_PLAY:
                    return RoomLogic.PlayerHasSkill(room, invoker, Name) && !invoker.HasUsed(YingshuiCard.ClassName);
                case CardUseReason.CARD_USE_REASON_RESPONSE:
                case CardUseReason.CARD_USE_REASON_RESPONSE_USE:
                    return pattern == "@@yingshui";
                default:
                    return false;
            }
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (room.GetRoomState().GetCurrentCardUseReason() == CardUseReason.CARD_USE_REASON_PLAY)
            {
                if (cards.Count == 1)
                {
                    WrappedCard ys = new WrappedCard(YingshuiCard.ClassName) { Skill = Name };
                    ys.AddSubCards(cards);
                    return ys;
                }
            }
            else if (cards.Count >= 2)
            {
                WrappedCard ys = new WrappedCard(YingshuiCard.ClassName) { Skill = Name, Mute = true };
                ys.AddSubCards(cards);
                return ys;
            }
            return null;
        }
    }

    public class YingshuiCard : SkillCard
    {
        public static string ClassName = "YingshuiCard";
        public YingshuiCard() : base(ClassName) { will_throw = false; }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            if (!Self.HasFlag("yingshui_target") && targets.Count == 0 && Self != to_select && RoomLogic.InMyAttackRange(room, Self, to_select))
                return true;

            return false;
        }

        public override bool TargetsFeasible(Room room, List<Player> targets, Player Self, WrappedCard card) => Self.HasFlag("yingshui_target") || targets.Count == 1;

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            if (card_use.From.HasFlag("yingshui_target")) return;
            base.OnUse(room, card_use);
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            room.ObtainCard(target, room.GetCard(card_use.Card.GetEffectiveId()), new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, "yingshui", string.Empty), false);
            if (player.Alive && target.Alive)
            {
                target.SetFlags("yingshui_target");
                WrappedCard card = room.AskForUseCard(target, RespondType.Skill, "@@yingshui", "@yingshui:" + player.Name, null);
                target.SetFlags("-yingshui_target");
                if (card != null)
                {
                    List<int> ids = new List<int>(card.SubCards);
                    room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, target.Name, player.Name, "yingshui", string.Empty), false);
                }
                else
                    room.Damage(new DamageStruct("yingshui", player, target));
            }
        }
    }

    public class Fuyuan : TriggerSkill
    {
        public Fuyuan() : base("fuyuan")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen, TriggerEvent.TargetConfirmed };
            skill_type = SkillType.Replenish;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use && !Engine.IsSkillCard(use.Card.Name) && WrappedCard.IsRed(use.Card.Suit))
            {
                foreach (Player p in use.To)
                    p.SetFlags(Name);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> result = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.TargetConfirmed && !player.HasFlag(Name) && data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName))
            {
                List<Player> zhongyao = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in zhongyao)
                    result.Add(new TriggerStruct(Name, p));
            }

            return result;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(ask_who, Name, player, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.DrawCards(player, new DrawCardStruct(1, ask_who, Name));
            return false;
        }
    }

    public class Heqia : TriggerSkill
    {
        public Heqia() : base("heqia")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.CardTargetAnnounced };
            skill_type = SkillType.Wizzard;
            view_as_skill = new HeqiaVS();
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Play && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.CardTargetAnnounced && data is CardUseStruct use
                && Engine.GetFunctionCard(use.Card.Name) is BasicCard && use.Card.GetSkillName() == Name && player.Alive && player.GetMark(Name) > 0)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                room.AskForUseCard(player, RespondType.Skill, "@@heqia", "@heqia", null, -1, HandlingMethod.MethodUse, true, info.SkillPosition);
            }
            else if (data is CardUseStruct use)
            {
                List<Player> targets = new List<Player>();
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                foreach (Player p in room.GetOtherPlayers(player))
                {
                    if (fcard is Peach && !p.IsWounded()) continue;
                    if (!use.To.Contains(p) && RoomLogic.IsProhibited(room, player, p, use.Card) == null)
                        targets.Add(p);
                }

                room.SetTag("extra_target_skill", data);                   //for AI
                List<Player> players = room.AskForPlayersChosen(player, targets, Name, 0, targets.Count,
                    string.Format("@heqia-extra:::{0}:{1}",  use.Card.Name, player.GetMark(Name)), true, info.SkillPosition);
                room.RemoveTag("extra_target_skill");
                if (players.Count > 0)
                {
                    List<string> names = new List<string>();
                    foreach (Player p in players)
                    {
                        room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, p.Name);
                        names.Add(p.Name);
                    }
                    LogMessage log = new LogMessage
                    {
                        Type = "$extra_target",
                        From = player.Name,
                        Card_str = RoomLogic.CardToString(room, use.Card),
                        Arg = Name
                    };
                    log.SetTos(players);
                    room.SendLog(log);

                    player.SetTag("extra_targets", names);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            CardUseStruct use = (CardUseStruct)data;
            List<string> names = (List<string>)player.GetTag("extra_targets");
            player.RemoveTag("extra_targets");
            List<Player> targets = new List<Player>();
            foreach (string name in names)
                targets.Add(room.FindPlayer(name));

            if (targets.Count > 0)
            {
                use.To.AddRange(targets);
                room.SortByActionOrder(ref use);
                data = use;
            }

            return false;
        }
    }

    public class HeqiaVS : ViewAsSkill
    {
        public HeqiaVS() : base("heqia") {}
        public override bool IsAvailable(Room room, Player invoker, CardUseReason reason, RespondType respond, string pattern, string position = null)
        {
            return reason == CardUseReason.CARD_USE_REASON_RESPONSE_USE && pattern == "@@heqia";
        }

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            if (!player.HasFlag(Name)) return true;
            return selected.Count == 0 && room.GetCardPlace(to_select.Id) == Place.PlaceHand && !RoomLogic.IsCardLimited(room, player, to_select, HandlingMethod.MethodUse, true);
        }

        public override List<WrappedCard> GetGuhuoCards(Room room, List<WrappedCard> cards, Player player)
        {
            List<WrappedCard> result = new List<WrappedCard>();
            if (player.HasFlag(Name) && cards.Count == 1)
            {
                foreach (string card_name in GetGuhuoCards(room, "b"))
                {
                    if (card_name != Jink.ClassName)
                    {
                        WrappedCard card = new WrappedCard(card_name) { Skill = "_heqia", DistanceLimited = false };
                        card.AddSubCards(cards);
                        card = RoomLogic.ParseUseCard(room, card);
                        result.Add(card);
                    }
                }
            }
            return result;
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (!player.HasFlag(Name))
            {
                WrappedCard hq = new WrappedCard(HeqiaCard.ClassName) { Skill = Name };
                hq.AddSubCards(cards);
                return hq;
            }
            else if (cards.Count == 1 && cards[0].IsVirtualCard())
                return cards[0];

            return null;
        }
    }

    public class HeqiaCard : SkillCard
    {
        public static string ClassName = "HeqiaCard";
        public HeqiaCard() : base(ClassName)
        {
            will_throw = false;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && to_select != Self && (card.SubCards.Count > 0 || to_select.HandcardNum > 0);
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0], user = null;
            List<int> ids = new List<int>(card_use.Card.SubCards);
            if (ids.Count > 0)
            {
                room.ObtainCard(target, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, "heqia", string.Empty), false);
                user = target;
            }
            else
            {
                ids = room.AskForExchange(target, "heqia", 100, 1, "@heqia-give:" + player.Name, string.Empty, "..", string.Empty);
                room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, target.Name, player.Name, "heqia", string.Empty), false);
                user = player;
            }

            if (user.Alive && !user.IsKongcheng())
            {
                user.SetMark("heqia", ids.Count - 1);
                user.SetFlags("heqia");
                room.AskForUseCard(user, RespondType.Skill, "@@heqia", "@heqia-slash:::" + (ids.Count - 1).ToString(), null, -1, HandlingMethod.MethodUse, false, card_use.Card.SkillPosition);
                user.SetMark("heqia", 0);
                user.SetFlags("-heqia");
            }
        }
    }

    public class Yinni : TriggerSkill
    {
        public Yinni() : base("yinni")
        {
            events.Add(TriggerEvent.DamageDefined);
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Defense;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is DamageStruct damage && damage.From != null && damage.From.Alive && damage.From != player && damage.Nature == DamageStruct.DamageNature.Normal && base.Triggerable(player, room) 
                && !player.HasFlag(Name) && (damage.From.Hp != player.Hp || damage.From.HandcardNum != player.HandcardNum))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            player.SetFlags(Name);
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
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

    public class Channi : TriggerSkill
    {
        public Channi() : base("channi")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damage, TriggerEvent.Damaged };
            skill_type = SkillType.Attack;
            view_as_skill = new ChanniVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is DamageStruct damage && damage.Card != null && damage.Card.GetSkillName() == Name && player.Alive && player.HasFlag(Name))
                player.SetFlags(triggerEvent == TriggerEvent.Damage ? "channi_damage" : "channi_damaged");
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data) => new List<TriggerStruct>();
    }

    public class ChanniVS : ViewAsSkill
    {
        public ChanniVS() : base("channi")
        {
        }
        public override bool IsAvailable(Room room, Player invoker, CardUseReason reason, RespondType respond, string pattern, string position = null)
        {
            switch (reason)
            {
                case CardUseReason.CARD_USE_REASON_RESPONSE_USE when pattern == "@@channi":
                    return true;
                case CardUseReason.CARD_USE_REASON_PLAY when !invoker.HasUsed(ChanniCard.ClassName) && RoomLogic.PlayerHasSkill(room, invoker, Name):
                    return true;
            }
            return false;
        }

        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            if (player.GetMark(Name) > 0)
                return selected.Count < player.GetMark(Name) && room.GetCardPlace(to_select.Id) == Place.PlaceHand && !RoomLogic.IsCardLimited(room, player, to_select, HandlingMethod.MethodUse, true);
            else
                return room.GetCardPlace(to_select.Id) == Place.PlaceHand;
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count > 0)
            {
                if (player.GetMark(Name) == 0)
                {
                    WrappedCard cn = new WrappedCard(ChanniCard.ClassName) { Skill = Name };
                    cn.AddSubCards(cards);
                    return cn;
                }
                else if (cards.Count > 0 && player.GetMark(Name) <= cards.Count)
                {
                    WrappedCard duel = new WrappedCard(Duel.ClassName) { Skill = "_channi" };
                    duel.AddSubCards(cards);
                    return duel;
                }
            }
            return null;
        }
    }

    public class ChanniCard : SkillCard
    {
        public static string ClassName = "ChanniCard";
        public ChanniCard() : base(ClassName) { will_throw = false; }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card) => targets.Count == 0 && Self != to_select;

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            List<int> ids = new List<int>(card_use.Card.SubCards);
            room.ObtainCard(target, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, "channi", string.Empty), false);
            if (target.Alive && target.HandcardNum >= ids.Count)
            {
                target.SetMark("channi", ids.Count);
                target.SetFlags("channi");
                WrappedCard duel = room.AskForUseCard(target, RespondType.Skill, "@@channi", string.Format("@channi:{0}::{1}", player.Name, ids.Count), null, -1, HandlingMethod.MethodUse, true);
                target.SetMark("channi", 0);

                if (duel != null)
                {
                    if (target.Alive && target.HasFlag("channi_damage"))
                        room.DrawCards(target, new DrawCardStruct(duel.SubCards.Count, player, "channi"));
                    else if (player.Alive && target.HasFlag("channi_damaged") && !player.IsKongcheng())
                        room.ThrowAllHandCards(player);

                    target.SetFlags("-channi");
                    target.SetFlags("-channi_damage");
                    target.SetFlags("-channi_damaged");
                }
            }

        }
    }

    public class Nifu : TriggerSkill
    {
        public Nifu() : base("nifu")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            skill_type = SkillType.Wizzard;
            frequency = Frequency.Compulsory;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (player.Phase == PlayerPhase.Finish)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    if (p.HandcardNum != 3)
                        triggers.Add(new TriggerStruct(Name, p));
            }
            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
            room.BroadcastSkillInvoke(Name, "male", ask_who.HandcardNum < 3 ? 1 : 2, gsk.General, gsk.SkinId);

            if (ask_who.HandcardNum < 3)
            {
                room.DrawCards(ask_who, 3 - ask_who.HandcardNum, Name);
            }
            else
            {
                int count = ask_who.HandcardNum - 3;
                room.AskForDiscard(ask_who, Name, count, count, false, false, "@nifu", false, info.SkillPosition);
            }

            return false;
        }
    }

    public class Tiqi : TriggerSkill
    {
        public Tiqi() : base("tiqi")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseEnd, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Replenish;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.To != null && move.To.Phase == PlayerPhase.Draw
                && move.Reason.Reason == MoveReason.S_REASON_DRAW && move.To_place == Place.PlaceHand && move.Reason.SkillName == "gamerule")
                move.To.AddMark(Name, move.Card_ids.Count);
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change)
            {
                if (change.From == PlayerPhase.Draw)
                {
                    player.SetMark(Name, 0);
                }
                else if (change.To == PlayerPhase.NotActive)
                {
                    player.SetMark("tiqi_max", 0);
                    room.RemovePlayerStringMark(player, Name);
                }
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.EventPhaseEnd && player.GetMark(Name) > 0 && player.GetMark(Name) != 2 && player.Phase == PlayerPhase.Draw)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    if (p != player) triggers.Add(new TriggerStruct(Name, p));
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(ask_who, Name, data , info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int count = Math.Abs(2 - player.GetMark(Name));
            if (count > 0)
            {
                room.DrawCards(ask_who, count, Name);
                if (ask_who.Alive && player.Alive)
                {
                    string choice = room.AskForChoice(ask_who, Name, "add+reduce+cancel",
                        new List<string> { "@to-player:" + player.Name, "@tiqi-add:::+" + count.ToString(), "@tiqi-add:::-" + count.ToString() }, player, info.SkillPosition);
                    if (choice == "add")
                    {
                        room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, player.Name);
                        player.AddMark("tiqi_max", count);
                        LogMessage log = new LogMessage
                        {
                            Type = "#tiqi-add",
                            From = ask_who.Name,
                            To = new List<string> { player.Name },
                            Arg = "+" + count.ToString()
                        };
                        room.SendLog(log);
                    }
                    else if (choice == "reduce")
                    {
                        room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, player.Name);
                        player.AddMark("tiqi_max", -count);
                        LogMessage log = new LogMessage
                        {
                            Type = "#tiqi-add",
                            From = ask_who.Name,
                            To = new List<string> { player.Name },
                            Arg = (-count).ToString()
                        };
                        room.SendLog(log);
                    }

                    if (player.Alive)
                    {
                        if (player.GetMark("tiqi_max") != 0)
                            room.SetPlayerStringMark(player, Name, player.GetMark("tiqi_max").ToString());
                        else
                            room.RemovePlayerStringMark(player, Name);
                    }
                }
            }

            return false;
        }
    }

    public class TiqiMax : MaxCardsSkill
    {
        public TiqiMax() : base("#tiqi") { }
        public override int GetExtra(Room room, Player target) => target.GetMark("tiqi_max");
    }

    public class Baoshu : TriggerSkill
    {
        public Baoshu() : base("baoshu")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart };
            skill_type = SkillType.Replenish;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.Phase == PlayerPhase.Start)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int count = player.MaxHp;
            List<Player> targets = room.AskForPlayersChosen(player, room.GetAlivePlayers(), Name, 0, count, "@baoshu:::" + count.ToString(), true, info.SkillPosition);
            if (targets.Count > 0)
            {
                room.SetTag(Name, targets);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is List<Player> targets)
            {
                room.RemoveTag(Name);
                int count = player.MaxHp - targets.Count;
                foreach (Player p in targets)
                {
                    if (p.Chained)
                        room.SetPlayerChained(p, false, true);
                    if (p.Alive && !p.FaceUp)
                        room.TurnOver(p);
                    if (p.Alive)
                    {
                        p.AddMark(Name, 1 + count);
                        room.SetPlayerStringMark(p, Name, p.GetMark(Name).ToString());
                    }
                }
            }

            return false;
        }
    }

    public class BaoshuDraw : DrawCardsSkill
    {
        public BaoshuDraw() : base("#baoshu") { frequency = Frequency.Compulsory; }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == Player.PlayerPhase.Draw && (int)data >= 0 && player.GetMark("baoshu") > 0)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override int GetDrawNum(Room room, Player player, int n)
        {
            int count = player.GetMark("baoshu");
            player.SetMark("baoshu", 0);
            room.RemovePlayerStringMark(player, "baoshu");
            return n + count;
        }
    }

    public class Xiaowu : ZeroCardViewAsSkill
    {
        public Xiaowu() : base("xiaowu") { }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(XiaowuCard.ClassName);

        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(XiaowuCard.ClassName) { Skill = Name };
    }

    public class XiaowuCard : SkillCard
    {
        public static string ClassName = "XiaowuCard";
        public XiaowuCard() : base(ClassName) { }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            if (to_select == Self) return false;
            if (targets.Count > 0)
                return room.GetNextAlive(targets[targets.Count - 1]) == to_select || room.GetLastAlive(targets[targets.Count - 1]) == to_select;
            else
                return room.GetNextAlive(Self) == to_select || room.GetLastAlive(Self) == to_select;
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            int self = 0, draw = 0;
            List<Player> targets = new List<Player>();
            foreach (Player p in card_use.To)
                p.SetFlags("xiaowu");
            player.SetMark("xiaowu_self", 0);
            player.SetMark("xiaowu_draw", 0);
            foreach (Player p in card_use.To)
            {
                if (p.Alive && player.Alive)
                {
                    string choice = room.AskForChoice(p, "xiaowu", "let+draw", new List<string> { string.Empty, "@xiaowu:" + player.Name }, player);
                    p.SetFlags("-xiaowu");
                    if (choice == "let")
                    {
                        draw++;
                        room.DrawCards(player, 1, "xiaowu");
                    }
                    else
                    {
                        self++;
                        targets.Add(p);
                        room.DrawCards(p, 1, "xiaowu");
                    }
                    player.SetMark("xiaowu_self", self);
                    player.SetMark("xiaowu_draw", draw);
                }
            }

            if (player.Alive)
            {
                if (self > draw)
                {
                    foreach (Player p in targets)
                        if (player.Alive && p.Alive) room.Damage(new DamageStruct(Name, player, p));
                }
                else if (draw > self)
                {
                    player.AddMark("shawu");
                    room.SetPlayerStringMark(player, "shawu", player.GetMark("shawu").ToString());
                }
            }
        }
    }

    public class Huaping : TriggerSkill
    {
        public Huaping() : base("huaping")
        {
            events.Add(TriggerEvent.Death);
            skill_type = SkillType.Wizzard;
            frequency = Frequency.Limited;
            limit_mark = "@huaping";
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (RoomLogic.PlayerHasSkill(room, player, Name) && player.GetMark(limit_mark) > 0)
                triggers.Add(new TriggerStruct(Name, player));
            foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                if (p != player && p.GetMark(limit_mark) > 0) triggers.Add(new TriggerStruct(Name, p));

            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player == ask_who)
            {
                Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@huaping-shawu", true, true, info.SkillPosition);
                if (target != null)
                {
                    room.SetTag(Name, target);
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    room.DoSuperLightbox(player, info.SkillPosition, Name);
                    room.SetPlayerMark(player, limit_mark, 0);
                    return info;
                }
            }
            else
            {
                if (room.AskForSkillInvoke(ask_who, Name, "@huaping-get:" + player.Name, info.SkillPosition))
                {
                    room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                    room.DoSuperLightbox(ask_who, info.SkillPosition, Name);
                    room.SetPlayerMark(ask_who, limit_mark, 0);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (ask_who == player && room.GetTag(Name) is Player target)
            {
                target.AddMark("shawu", player.GetMark("shawu"));
                room.SetPlayerStringMark(target, "shawu", target.GetMark("shawu").ToString());
                room.HandleAcquireDetachSkills(target, "shawu", true);
            }
            else if (ask_who != player)
            {
                List<string> skills = new List<string>();
                foreach (string skill_name in Engine.GetGeneralSkills(player.General1, room.Setting.GameMode, true))
                {
                    Skill s = Engine.GetSkill(skill_name);
                    if (s != null && s.SkillFrequency != Frequency.Limited && s.SkillFrequency != Frequency.Wake && !s.LordSkill && !s.Attached_lord_skill)
                        skills.Add(skill_name);
                }

                if (skills.Count > 0)
                {
                    room.HandleAcquireDetachSkills(ask_who, skills, true);
                    room.FilterCards(ask_who, ask_who.GetCards("he"), true);
                }

                if (ask_who.Alive)
                {
                    int count = ask_who.GetMark("shawu");
                    ask_who.SetMark("shawu", 0);
                    room.RemovePlayerStringMark(ask_who, "shawu");
                    room.HandleAcquireDetachSkills(ask_who, "-xiaowu");
                    if (ask_who.Alive && count > 0)
                        room.DrawCards(ask_who, count, Name);
                }
            }
            return false;
        }
    }

    public class Shawu : TriggerSkill
    {
        public Shawu() : base("shawu")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen };
            skill_type = SkillType.Attack;
            view_as_skill = new ShawuVS();
        }
        
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && base.Triggerable(player, room) && data is CardUseStruct use && use.Card != null)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is Slash)
                    return new TriggerStruct(Name, player, use.To);
            }
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player skill_target, ref object data, Player player, TriggerStruct info)
        {
            WrappedCard card = room.AskForUseCard(player, RespondType.Skill, "@@shawu", "@shawu:" + skill_target.Name, null, -1, HandlingMethod.MethodUse, true, info.SkillPosition);
            if (card != null && player.GetTag(Name) is List<int> ids)
            {
                room.ThrowCard(ref ids, player, null, Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            else if (player.GetMark(Name) > 0 && room.AskForSkillInvoke(player, Name, "@shawu-mark:" + skill_target.Name, info.SkillPosition))
            {
                player.AddMark(Name, -1);
                if (player.GetMark(Name) == 0)
                    room.RemovePlayerStringMark(player, Name);
                else
                    room.SetPlayerStringMark(player, Name, player.GetMark(Name).ToString());

                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player skill_target, ref object data, Player machao, TriggerStruct info)
        {
            if (machao.ContainsTag(Name))
                machao.RemoveTag(Name);
            else
                room.DrawCards(machao, 2, Name);

            if (machao.Alive && skill_target.Alive)
                room.Damage(new DamageStruct(Name, machao, skill_target));
            return false;
        }
    }

    public class ShawuVS : ViewAsSkill
    {
        public ShawuVS() : base("shawu") { response_pattern = "@@shawu"; }
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player) => selected.Count < 2 && room.GetCardPlace(to_select.Id) == Place.PlaceHand && RoomLogic.CanDiscard(room, player, player, to_select.Id);

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count == 2)
            {
                WrappedCard card = new WrappedCard(ShawuCard.ClassName);
                card.AddSubCards(cards);
                return card;
            }
            return null;
        }
    }

    public class ShawuCard : SkillCard
    {
        public static string ClassName = "ShawuCard";
        public ShawuCard() : base(ClassName) { target_fixed = true; }
        public override void OnUse(Room room, CardUseStruct card_use)
        {
            card_use.From.SetTag("shawu", card_use.Card.SubCards);
        }
    }

    public class Bingjie : TriggerSkill
    {
        public Bingjie() : base("bingjie")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            skill_type = SkillType.Attack;
                }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Play)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.LoseMaxHp(player);
                return info;
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.Alive)
                player.SetFlags(Name);
            return false;
        }
    }

    public class BingjieEffect : TriggerSkill
    {
        public BingjieEffect() : base("#bingjie")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen };
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && base.Triggerable(player, room) && data is CardUseStruct use && player.HasFlag("bingjie"))
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is Slash || fcard.IsNDTrick())
                {
                    List<Player> targets = new List<Player>();
                    foreach (Player p in use.To)
                        if (p != player && !p.IsNude())
                            targets.Add(p);

                    if (targets.Count > 0)
                        return new TriggerStruct(Name, player, targets);
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player skill_target, ref object data, Player machao, TriggerStruct info)
        {
            DoTieqi(room, skill_target, machao);
            return false;
        }

        private void DoTieqi(Room room, Player target, Player player)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, target.Name);
            room.AskForDiscard(target, "bingjie", 1, 1, false, true, string.Format("@bingjie:{0}", player.Name));
        }
    }

    public class Zhengding : TriggerSkill
    {
        public Zhengding() : base("zhengding")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardResponded, TriggerEvent.CardUsed };
            skill_type = SkillType.Recover;
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardResponded && data is CardResponseStruct resp && base.Triggerable(player, room) && resp.Data != null && player.Phase == PlayerPhase.NotActive)
            {
                WrappedCard card = null;
                if (resp.Data is CardEffectStruct effect)
                    card = effect.Card;
                else if (resp.Data is SlashEffectStruct slash)
                    card = slash.Slash;

                if (card != null && resp.Card != null
                    && ((WrappedCard.IsBlack(card.Suit) && WrappedCard.IsBlack(resp.Card.Suit)) || (card.Suit == WrappedCard.CardSuit.NoSuit && resp.Card.Suit == WrappedCard.CardSuit.NoSuit)
                    || (WrappedCard.IsRed(card.Suit) && WrappedCard.IsRed(resp.Card.Suit))))
                    return new TriggerStruct(Name, player);
            }
            else if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use && use.RespondData != null && use.RespondData.Card != null && base.Triggerable(player, room) && player.Phase == PlayerPhase.NotActive)
            {
                if ((WrappedCard.IsBlack(use.Card.Suit) && WrappedCard.IsBlack(use.RespondData.Card.Suit))
                    || (use.RespondData.Card.Suit == WrappedCard.CardSuit.NoSuit && use.Card.Suit == WrappedCard.CardSuit.NoSuit)
                    || (WrappedCard.IsRed(use.RespondData.Card.Suit) && WrappedCard.IsRed(use.Card.Suit)))
                    return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
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
            return false;
        }
    }

    public class Jiezhen : TriggerSkill
    {
        public Jiezhen() : base("jiezhen")
        {
            events.Add(TriggerEvent.CardsMoveOneTime);
            skill_type = SkillType.Replenish;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (data is CardsMoveOneTimeStruct move && move.From != null && move.From.Alive && move.From_places.Contains(Place.PlaceHand) && move.From.IsKongcheng())
            {
                string mark = string.Format("{0}_{1}", Name, move.From.Name);
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                {
                    if (p.GetMark(mark) == 0)
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move && room.AskForSkillInvoke(ask_who, Name, move.From, info.SkillPosition))
            {
                string mark = string.Format("{0}_{1}", Name, move.From.Name);
                ask_who.AddMark(mark);
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move)
            {
                bool jink = false, peach = false, ana = false, nulli = false;
                List<int> ids = new List<int>();
                if (room.DrawPile.Count < 4) room.SwapPile();

                foreach (int id in room.DrawPile)
                {
                    WrappedCard card = room.GetCard(id);
                    if (!jink && card.Name == Jink.ClassName)
                    {
                        jink = true;
                        ids.Add(id);
                    }
                    else if (!peach && card.Name == Peach.ClassName)
                    {
                        peach = true;
                        ids.Add(id);
                    }
                    else if (!ana && card.Name == Analeptic.ClassName)
                    {
                        ana = true;
                        ids.Add(id);
                    }
                    else if (!nulli && card.Name == Nullification.ClassName)
                    {
                        nulli = true;
                        ids.Add(id);
                    }
                    if (ids.Count == 4)
                        break;
                }

                if (ids.Count > 0)
                {
                    room.ObtainCard(ask_who, ref ids, new CardMoveReason(MoveReason.S_REASON_GOTCARD, ask_who.Name, Name, string.Empty), true);
                    if (ask_who.Alive && move.From.Alive)
                    {
                        ids.RemoveAll(t => (room.GetCardOwner(t) != ask_who || room.GetCardPlace(t) != Place.PlaceHand));
                        if (ids.Count > 0)
                        {
                            List<int> give = room.AskForExchange(ask_who, Name, ids.Count, 1, "@jiezhen:" + move.From.Name, string.Empty, string.Join("#", ids), info.SkillPosition);
                            if (give.Count == 0)
                                give = new List<int> { ids[0] };
                            room.ObtainCard(move.From, ref give, new CardMoveReason(MoveReason.S_REASON_GIVE, ask_who.Name, move.From.Name, Name, string.Empty), true);
                        }
                    }
                }
            }
              return false;
        }
    }

    public class Zhecai : TriggerSkill
    {
        public Zhecai() : base("zhecai")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsed, TriggerEvent.RoundStart };
            frequency = Frequency.Limited;
            limit_mark = "@zhecai";
            skill_type = SkillType.Wizzard;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use && player != null && player.Alive)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is TrickCard)
                    player.AddMark(Name);
            }
            else if (triggerEvent == TriggerEvent.RoundStart)
            {
                int max = 0;
                Player most = null;
                foreach (Player p in room.GetAlivePlayers())
                {
                    int count = p.GetMark(Name);
                    if (count > max)
                    {
                        max = p.GetMark(Name);
                        most = p;
                    }
                    else if (count > 0 && count == max)
                        most = null;
                }
                foreach (Player p in room.GetAlivePlayers())
                    p.SetMark(Name, 0);

                if (most != null)
                    most.SetFlags(Name);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.RoundStart)
            {
                Player most = null;
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.HasFlag(Name))
                    {
                        most = p;
                        break;
                    }
                }

                if (most != null)
                {
                    foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    {
                        if (p.GetMark(limit_mark) > 0)
                            triggers.Add(new TriggerStruct(Name, p));
                    }
                }
            }

            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player most = null;
            foreach (Player p in room.GetAlivePlayers())
            {
                if (p.HasFlag(Name))
                {
                    most = p;
                    break;
                }
            }

            if (room.AskForSkillInvoke(ask_who, Name, most, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                room.DoSuperLightbox(ask_who, info.SkillPosition, Name);
                room.SetPlayerMark(ask_who, limit_mark, 0);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player most = null;
            foreach (Player p in room.GetAlivePlayers())
            {
                if (p.HasFlag(Name))
                {
                    most = p;
                    break;
                }
            }

            room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, most.Name);
            room.HandleAcquireDetachSkills(most, "qicai_jx", true);
            if (most.Alive)
            {
                if (room.Current != null && room.Current != most)
                {
                    room.GainAnExtraTurn(room.Current);
                    room.SetCurrent(most);
                }
                else
                    room.GainAnExtraTurn(most);
            }
            return false;
        }
    }

    public class YinshiHCY : TriggerSkill
    {
        public YinshiHCY() : base("yinshi_hcy")
        {
            events.Add(TriggerEvent.DamageDefined);
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Defense;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is DamageStruct damage && base.Triggerable(player, room) && !player.HasFlag(Name) && (damage.Card == null || Engine.IsSkillCard(damage.Card.Name) || damage.Card.Suit == WrappedCard.CardSuit.NoSuit))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            player.SetFlags(Name);
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

    public class Shuizheng : TriggerSkill
    {
        public Shuizheng() : base("shuizheng")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.EventPhaseEnd, TriggerEvent.EventPhaseChanging, TriggerEvent.Damage };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                player.AddMark(Name, -1);
                if (player.GetMark(Name) == 0)
                    room.RemovePlayerStringMark(player, Name);
            }
            else if (triggerEvent == TriggerEvent.Damage && player.GetMark(Name) > 0 && player.Phase == PlayerPhase.Play && data is DamageStruct damage)
                damage.To.SetFlags(Name);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.Phase == PlayerPhase.Finish)
                triggers.Add(new TriggerStruct(Name, player));
            else if (triggerEvent == TriggerEvent.EventPhaseEnd && player != null && player.Phase == PlayerPhase.Play && player.GetMark(Name) > 0)
            {
                List<Player> victims = new List<Player>();
                foreach (Player p in room.GetAlivePlayers())
                    if (p.HasFlag(Name)) victims.Add(p);

                if (victims.Count > 0)
                {
                    foreach (Player p in room.GetAlivePlayers())
                    {
                        if (p.ContainsTag(Name) && p.GetTag(Name) is string player_name && player_name == player.Name && (!victims.Contains(p) || victims.Count > 1))
                            triggers.Add(new TriggerStruct(Name, p));
                    }
                }
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                Player target = room.AskForPlayerChosen(player, room.GetAlivePlayers(), Name, "@shuizheng", true, true, info.SkillPosition);
                if (target != null)
                {
                    room.SetTag(Name, target);
                    GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                    room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                    return info;
                }
            }
            else
            {
                List<Player> victims = new List<Player>();
                foreach (Player p in room.GetAlivePlayers())
                    if (p.HasFlag(Name) && p != ask_who) victims.Add(p);

                Player target = room.AskForPlayerChosen(ask_who, victims, Name, "@shuizheng-slash:" + player.Name, true, true, info.SkillPosition);
                if (target != null)
                {
                    room.SetTag(Name, target);
                    GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                    room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);
                    return info;
                }
            }
            return info;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is Player target)
            {
                if (triggerEvent == TriggerEvent.EventPhaseStart)
                {
                    target.SetMark(Name, target == player ? 2 : 1);
                    player.SetTag(Name, target.Name);
                    room.SetPlayerStringMark(target, Name, string.Empty);
                }
                else
                {
                    WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = "_shuizheng", DistanceLimited = false };
                    if (RoomLogic.IsProhibited(room, ask_who, target, slash) == null)
                        room.UseCard(new CardUseStruct(slash, ask_who, target));
                }
            }

            return false;
        }
    }

    public class ShuizhengTar : TargetModSkill
    {
        public ShuizhengTar() : base("#shuizheng", false) { }
        public override int GetResidueNum(Room room, Player from, WrappedCard card) => from.GetMark("shuizheng") > 0 ? 1 : 0;
        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern) => from.GetMark("shuizheng") > 0;
    }

    public class Yijiao : ZeroCardViewAsSkill
    {
        public Yijiao() : base("yijiao") { skill_type = SkillType.Wizzard; }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(YijiaoCard.ClassName);
        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(YijiaoCard.ClassName) { Skill = Name };
    }
    public class YijiaoCard : SkillCard
    {
        public static string ClassName = "YijiaoCard";
        public YijiaoCard() : base(ClassName)
        { }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card) => targets.Count == 0 && to_select != Self;
        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            List<int> ids = new List<int> { 10, 20, 30, 40 };
            ids.Remove(player.GetMark("yijiao"));
            string number = room.AskForChoice(player, "yijiao", string.Join("+", ids), new List<string> { "@yijiao:" + target.Name }, target, card_use.Card.SkillPosition);
            int count = int.Parse(number);
            player.SetMark("yijiao", count);
            target.SetMark("yijiao_mark", count);
            room.SetPlayerStringMark(target, "yijiao", count.ToString());
            player.SetTag("yijiao", target.Name);
        }
    }
    public class YijiaoEffect : TriggerSkill
    {
        public YijiaoEffect() : base("#yijiao")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsed, TriggerEvent.EventPhaseChanging, TriggerEvent.EventPhaseStart };
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use && player.Alive && player.Phase != PlayerPhase.NotActive && player.GetMark("yijiao_mark") > 0)
            {
                player.AddMark("yijiao_used", use.Card.Number);
                room.SetPlayerStringMark(player, "yijiao", (player.GetMark("yijiao_mark") - player.GetMark("yijiao_used")).ToString());
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player.GetMark("yijiao_mark") > 0)
            {
                foreach (Player p in room.GetOtherPlayers(player))
                    if (p.ContainsTag("yijiao") && p.GetTag("yijiao") is string player_name && player_name == player.Name)
                        p.RemoveTag("yijiao");

                player.SetMark("yijiao_used", 0);
                player.SetMark("yijiao_mark", 0);
                room.RemovePlayerStringMark(player, "yijiao");
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Alive && player.Phase == PlayerPhase.Finish && player.GetMark("yijiao_mark") > 0)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name, false);
            int count = player.GetMark("yijiao_mark") - player.GetMark("yijiao_used");
            if (count > 0 && !player.IsKongcheng())
            {
                List<int> ids = room.ForceToDiscard(player, player.GetCards("h"), 1);
                room.ThrowCard(ref ids, new CardMoveReason(MoveReason.S_REASON_THROW, player.Name, "yijiao", string.Empty), player);
            }
            else if (count == 0)
                room.GainAnExtraTurn(player);
            else if (count < 0)
            {
                foreach (Player p in room.GetOtherPlayers(player))
                    if (p.ContainsTag("yijiao") && p.GetTag("yijiao") is string player_name && player_name == player.Name)
                        room.DrawCards(p, 2, "yijiao");
            }

            return false;
        }
    }

    public class Qibie : TriggerSkill
    {
        public Qibie() : base("qibie")
        {
            events.Add(TriggerEvent.Death);
            skill_type = SkillType.Recover;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
            {
                if (p != player && !p.IsKongcheng() && RoomLogic.CanDiscard(room, p, p, "h")) triggers.Add(new TriggerStruct(Name, p));
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(ask_who, Name, data , info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<int> ids = new List<int>();
            foreach (int id in ask_who.GetCards("h"))
                if (RoomLogic.CanDiscard(room, ask_who, ask_who, id))
                    ids.Add(id);
            if (ids.Count > 0)
            {
                room.ThrowCard(ref ids, ask_who, null, Name);
                if (ask_who.Alive && ask_who.IsWounded()) room.Recover(ask_who);
                if (ask_who.Alive) room.DrawCards(ask_who, ids.Count + 1, Name);
            }

            return false;
        }
    }

    public class Xunli : TriggerSkill
    {
        public Xunli() : base("xunli")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseStart, TriggerEvent.EventLoseSkill };
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Wizzard;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventLoseSkill && data is InfoStruct info && info.Info == Name)
                room.ClearOnePrivatePile(player, Name);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.To_place == Place.DiscardPile && (move.Reason.Reason & MoveReason.S_MASK_BASIC_REASON) == MoveReason.S_REASON_DISCARD && move.From != null)
            {
                bool black = false;
                foreach (int id in move.Card_ids)
                {
                    if (room.GetCardPlace(id) == Place.DiscardPile && WrappedCard.IsBlack(room.GetCard(id).Suit))
                    {
                        black = true;
                        break;
                    }
                }

                if (black)
                {
                    foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                        if (p.GetPile(Name).Count < 9) triggers.Add(new TriggerStruct(Name, p));
                }
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.Phase == PlayerPhase.Play && !player.IsKongcheng() && player.GetPile(Name).Count > 0)
                triggers.Add(new TriggerStruct(Name, player));

            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct _move)
            {
                List<int> ids = new List<int>();
                foreach (int id in 
                    _move.Card_ids)
                    if (room.GetCardPlace(id) == Place.DiscardPile && WrappedCard.IsBlack(room.GetCard(id).Suit))
                        ids.Add(id);

                room.SendCompulsoryTriggerLog(ask_who, Name);
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                if (ids.Count + ask_who.GetPile(Name).Count <= 9)
                    room.AddToPile(ask_who, Name, ids);
                else
                {
                    List<int> take = new List<int>();
                    while (ask_who.GetPile(Name).Count + take.Count < 9)
                    {
                        room.FillAG(Name, ids, ask_who, take, null, "@xunli");
                        List<int> choose = new List<int>(ids);
                        choose.RemoveAll(t => take.Contains(t));
                        int id = room.AskForAG(ask_who, choose, false, Name);
                        take.Add(id);
                        room.ClearAG(ask_who);
                    }

                    if (take.Count > 0)
                        room.AddToPile(ask_who, Name, take);
                }
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                List<int> stars = player.GetPile(Name);
                List<int> ups = new List<int>();
                foreach (int id in player.GetCards("h"))
                    if (WrappedCard.IsBlack(room.GetCard(id).Suit)) ups.Add(id);

                if (ups.Count > 0)
                {
                    room.SendCompulsoryTriggerLog(ask_who, Name);
                    room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                    AskForMoveCardsStruct move = room.AskForMoveCards(player, ups, stars, true, Name, stars.Count, stars.Count, true, false, new List<int>(), info.SkillPosition);
                    if (move.Success)
                    {
                        List<int> up = new List<int>(), down = new List<int>();
                        foreach (int id in move.Top)
                            if (room.GetCardPlace(id) != Place.PlaceHand)
                                up.Add(id);

                        foreach (int id in move.Bottom)
                            if (room.GetCardPlace(id) == Place.PlaceHand)
                                down.Add(id);

                        if (up.Count > 0)
                        {
                            List<CardsMoveStruct> moves = new List<CardsMoveStruct>();
                            CardsMoveStruct move1 = new CardsMoveStruct(up, player, Place.PlaceHand, new CardMoveReason(MoveReason.S_REASON_EXCHANGE_FROM_PILE, player.Name, Name, string.Empty));
                            CardsMoveStruct move2 = new CardsMoveStruct(down, player, Place.PlaceSpecial,
                                new CardMoveReason(MoveReason.S_REASON_REMOVE_FROM_GAME, player.Name, Name, string.Empty))
                            {
                                To_pile_name = Name
                            };

                            moves.Add(move1);
                            moves.Add(move2);
                            room.MoveCardsAtomic(moves, false);
                        }
                    }
                }
            }
            return false;
        }
    }

    public class Zhishi : TriggerSkill
    {
        public Zhishi() : base("zhishi")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetConfirmed, TriggerEvent.EventPhaseStart, TriggerEvent.TurnStart, TriggerEvent.Dying, TriggerEvent.Death };
            skill_type = SkillType.Defense;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.TurnStart && player.ContainsTag(Name) && player.GetTag(Name) is string player_name)
            {
                player.RemoveTag(Name);
                Player target = room.FindPlayer(player_name);
                if (target != null) room.RemovePlayerStringMark(target, Name);
            }

        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.Phase == PlayerPhase.Finish)
                triggers.Add(new TriggerStruct(Name, player));
            else if (triggerEvent == TriggerEvent.TargetConfirmed && data is CardUseStruct use && use.Card.Name.Contains(Slash.ClassName) && player.Alive)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    if (p.ContainsTag(Name) && p.GetTag(Name) is string player_name && player_name == player.Name && p.GetPile("xunli").Count > 0)
                        triggers.Add(new TriggerStruct(Name, p));
            }
            else if (triggerEvent == TriggerEvent.Dying)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    if (p.ContainsTag(Name) && p.GetTag(Name) is string player_name && player_name == player.Name && p.GetPile("xunli").Count > 0)
                        triggers.Add(new TriggerStruct(Name, p));
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                Player target = room.AskForPlayerChosen(player, room.GetAlivePlayers(), Name, "@zhishi", true, true, info.SkillPosition);
                if (target != null)
                {
                    player.SetTag(Name, target.Name);
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    room.SetPlayerStringMark(target, Name, string.Empty);
                    return info;
                }
            }
            else
            {
                List<int> ids = room.AskForExchange(ask_who, Name, ask_who.GetPile("xunli").Count, 0, "@zhishi-target:" + player.Name, "xunli", ".|.|.|xunli", info.SkillPosition);
                if (ids.Count > 0)
                {
                    ask_who.SetMark(Name, ids.Count);
                    room.NotifySkillInvoked(ask_who, Name);
                    room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                    CardsMoveStruct move = new CardsMoveStruct(ids, ask_who, Place.DiscardPile, new CardMoveReason(MoveReason.S_REASON_NATURAL_ENTER, ask_who.Name, Name, string.Empty))
                    {
                        To_pile_name = string.Empty,
                        From = ask_who.Name
                    };

                    //if (!string.IsNullOrEmpty(pileName))
                    //    dstPlayer.PileChange(pileName, move.Card_ids);

                    List<CardsMoveStruct> moves = new List<CardsMoveStruct> { move };
                    room.MoveCardsAtomic(moves, true);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent != TriggerEvent.EventPhaseStart && player.Alive)
            {
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, player.Name);
                room.DrawCards(player, new DrawCardStruct(ask_who.GetMark(Name), ask_who, Name));
            }

            return false;
        }
    }

    public class Lieyi : TriggerSkill
    {
        public Lieyi() : base("lieyi") { events.Add(TriggerEvent.Dying); skill_type = SkillType.Attack; view_as_skill = new LieyiVS(); }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is DyingStruct dying && player.HasFlag(Name) && dying.Damage.Card != null && dying.Damage.Card.HasFlag(Name))
                player.SetFlags("-lieyi");
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data) => new List<TriggerStruct>();
    }

    public class LieyiVS : ZeroCardViewAsSkill
    {
        public LieyiVS() : base("lieyi") { }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(LieyiCard.ClassName) && player.GetPile("xunli").Count > 0;
        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(LieyiCard.ClassName) { Skill = Name };
    }

    public class LieyiCard : SkillCard
    {
        public static string ClassName = "LieyiCard";
        public LieyiCard() : base(ClassName) { }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card) => targets.Count == 0 && to_select != Self;
        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            target.SetFlags("lieyi");
            List<int> ids = player.GetPile("xunli");
            foreach (int id in ids)
            {
                WrappedCard card = room.GetCard(id);
                room.MoveCardTo(card, player, Place.PlaceTable, new CardMoveReason(MoveReason.S_REASON_REMOVE_FROM_PILE, player.Name, "lieyi", null), false);
            }

            List<int> use = new List<int>(ids);
            while (player.Alive && use.Count > 0 && target.Alive)
            {
                int id = use[0];
                use.RemoveAt(0);
                WrappedCard card = room.GetCard(id);
                if (RoomLogic.IsProhibited(room, player, target, card) == null)
                {
                    bool can_use = true;
                    FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                    card.SetFlags("lieyi");
                    if (card.Name == Snatch.ClassName && (!RoomLogic.CanGetCard(room, player, target, "hej") || target.IsAllNude()))
                        can_use = false;
                    else if (fcard is AOE || fcard is GlobalEffect || fcard is Slash)
                    {

                    }
                    else if (fcard.TargetFixed(card))
                        can_use = false;
                    else if (card.Name == Collateral.ClassName)
                    {
                        can_use = false;
                        if (target.GetWeapon())
                        {
                            List<Player> vitcims = new List<Player>();
                            foreach (Player p in room.GetOtherPlayers(target))
                                if (RoomLogic.CanSlash(room, target, p)) vitcims.Add(p);

                            if (vitcims.Count > 0)
                            {
                                Player victim = room.AskForPlayerChosen(player, vitcims, Name, "@Collateral:" + target.Name, false, false, card_use.Card.SkillPosition);
                                ids.Remove(id);
                                room.UseCard(new CardUseStruct(card, player, new List<Player> { target, victim }, false) { Reason = CardUseReason.CARD_USE_REASON_RESPONSE_USE }, false, true);
                            }
                        }
                    }
                    else if (!fcard.TargetFilter(room, new List<Player>(), target, player, card))
                        can_use = false;

                    if (can_use)
                    {
                        ids.Remove(id);
                        room.UseCard(new CardUseStruct(card, player, target, false) { Reason = CardUseReason.CARD_USE_REASON_RESPONSE_USE }, false, true);
                    }
                }
            }
            if (player.Alive && target.Alive && target.HasFlag("lieyi"))
                room.LoseHp(player);

            if (ids.Count > 0)
                room.MoveCards(new List<CardsMoveStruct> { new CardsMoveStruct(ids, null, Place.DiscardPile, new CardMoveReason(MoveReason.S_REASON_NATURAL_ENTER, null, "lieyi", null)) }, true);
        }
    }

    public class Jinggong : OneCardViewAsSkill
    {
        public Jinggong() : base("jinggong")
        {
            response_or_use = true;
            skill_type = SkillType.Attack;
        }
        public override bool IsEnabledAtPlay(Room room, Player player) => Slash.IsAvailable(room, player);
        public override bool IsEnabledAtResponse(Room room, Player player, RespondType respond, string pattern)
            => MatchSlash(respond) && room.GetRoomState().GetCurrentCardUseReason() == CardUseReason.CARD_USE_REASON_RESPONSE_USE;
        public override bool ViewFilter(Room room, WrappedCard card, Player player)
        {
            if (!(Engine.GetFunctionCard(card.Name) is EquipCard)) return false;
            return true;
        }
        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard slash = new WrappedCard(Slash.ClassName)
            {
                Skill = Name,
                ShowSkill = Name,
                DistanceLimited = false
            };
            slash.AddSubCard(card);
            slash = RoomLogic.ParseUseCard(room, slash);
            return slash;
        }
    }

    public class JinggongDamage : TriggerSkill
    {
        public JinggongDamage() : base("#jinggong")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageCaused };
            skill_type = SkillType.Attack;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is DamageStruct damage && damage.Card != null && damage.Card.Name.Contains(Slash.ClassName) && damage.Card.GetSkillName() == "jinggong"
                && damage.Damage != RoomLogic.DistanceTo(room, player, damage.To) && !damage.Transfer && !damage.Chain)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                int count = Math.Max(1, RoomLogic.DistanceTo(room, player, damage.To));
                count = Math.Min(3, count);
                if (count != damage.Damage)
                {
                    room.SendCompulsoryTriggerLog(player, "jinggong");
                    LogMessage log = new LogMessage
                    {
                        Type = "#jinggong-damage",
                        To = new List<string> { damage.To.Name },
                        From = player.Name,
                        Arg = damage.Card.Name,
                        Arg2 = count.ToString()
                    };
                    room.SendLog(log);

                    damage.Damage = count;
                    data = damage;
                }
            }
            return false;
        }
    }

    public class Xiaojun : TriggerSkill
    {
        public Xiaojun() : base("xiaojun")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen };
            skill_type = SkillType.Attack;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && base.Triggerable(player, room) && data is CardUseStruct use
                && !Engine.IsSkillCard(use.Card.Name) && use.To.Count == 1 && player != use.To[0] && use.To[0].HandcardNum > 1 && RoomLogic.CanDiscard(room, player, use.To[0], "h"))
                return new TriggerStruct(Name, player, use.To);

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player skill_target, ref object data, Player player, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, skill_target, info.SkillPosition))
            {
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, skill_target.Name);
                room.NotifySkillInvoked(player, Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player skill_target, ref object data, Player machao, TriggerStruct info)
        {
            List<string> patterns = new List<string>();
            for (int i = 0; i < Math.Max(1, skill_target.HandcardNum / 2); i++)
                patterns.Add("h^false^discard");
            List<int> ids = room.AskForCardsChosen(machao, skill_target, patterns, Name);
            room.ThrowCard(ref ids, new CardMoveReason(MoveReason.S_REASON_DISMANTLE, machao.Name, skill_target.Name, Name, string.Empty), skill_target, machao);
            if (data is CardUseStruct use && machao.Alive && machao.HandcardNum > 1 && RoomLogic.CanDiscard(room, machao, machao, "h"))
            {
                bool discard = false;
                foreach (int id in ids)
                {
                    if (room.GetCard(id).Suit == use.Card.Suit)
                    {
                        discard = true;
                        break;
                    }
                }
                if (discard)
                    room.AskForDiscard(machao, Name, machao.HandcardNum / 2, machao.HandcardNum / 2, false, false, "@xiaojun", false, info.SkillPosition);
            }

            return false;
        }
    }

    public class Piaoping : TriggerSkill
    {
        public Piaoping() : base("piaoping")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsed, TriggerEvent.CardResponded, TriggerEvent.EventPhaseChanging, TriggerEvent.EventAcquireSkill, TriggerEvent.EventLoseSkill };
            skill_type = SkillType.Wizzard;
            frequency = Frequency.Compulsory;
            turn = true;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventAcquireSkill && data is InfoStruct info && info.Info == Name)
            {
                room.SetTurnSkillState(player, Name, false, info.Head ? "head" : "deputy");
            }
            else if (triggerEvent == TriggerEvent.EventLoseSkill && data is InfoStruct _info && _info.Info == Name)
            {
                room.RemoveTurnSkill(player);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                    p.SetMark("piaoping_invoke", 0);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use && !Engine.IsSkillCard(use.Card.Name) && base.Triggerable(player, room) && !player.HasFlag(Name))
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.CardResponded && data is CardResponseStruct resp && resp.Use && base.Triggerable(player, room) && !player.HasFlag(Name))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            player.AddMark("piaoping_invoke");
            int count = player.GetMark("piaoping_invoke");
            count = Math.Min(player.Hp, count);
            count = Math.Max(1, count);
            if (count > 0)
            {
                if (player.GetMark(Name) == 0)
                {
                    room.DrawCards(player, count, Name);
                }
                else if (!player.IsNude() && RoomLogic.CanDiscard(room, player, player, "he"))
                {
                    count = Math.Min(count, player.GetCardCount(true));
                    room.AskForDiscard(player, Name, count, count, false, true, "@piaoping:::" + count.ToString(), false, info.SkillPosition);
                }
            }
            if (player.Alive)
            {
                int mark = player.GetMark(Name) == 0 ? 1 : 0;
                player.SetMark(Name, mark);
                room.SetTurnSkillState(player, Name, mark == 1, info.SkillPosition);
            }

            return false;
        }
    }
    
    public class Tuoxian : TriggerSkill
    {
        public Tuoxian() : base("tuoxian")
        {
            events.Add(TriggerEvent.CardsMoveOneTime);
            skill_type = SkillType.Replenish;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            CardsMoveOneTimeStruct move = (CardsMoveOneTimeStruct)data;
            if ((move.Reason.Reason & MoveReason.S_MASK_BASIC_REASON) == MoveReason.S_REASON_DISCARD && move.To_place == Place.DiscardPile && move.Reason.SkillName == "piaoping"
                && base.Triggerable(move.From, room) && move.From.GetMark(Name) > 0)
            {
                for (int i = 0; i < move.Card_ids.Count; i++)
                {
                    int card_id = move.Card_ids[i];
                    if (room.GetCardPlace(card_id) == Place.DiscardPile)
                        return new TriggerStruct(Name, move.From);
                }
            }

            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player tar, ref object data, Player player, TriggerStruct info)
        {
            CardsMoveOneTimeStruct move = (CardsMoveOneTimeStruct)data;
            List<int> cards = new List<int>();
            for (int i = 0; i < move.Card_ids.Count; i++)
            {
                int card_id = move.Card_ids[i];
                if (room.GetCardPlace(card_id) == Place.DiscardPile)
                    cards.Add(card_id);
            }
            
            if (cards.Count > 0)
            {
                Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@tuoxian:::" + cards.Count.ToString(), true, true, info.SkillPosition);
                if (target != null)
                {
                    room.SetTag(Name, target);
                    player.AddMark(Name, -1);
                    room.SetPlayerStringMark(player, Name, player.GetMark(Name).ToString());
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    return info;
                }
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player p, ref object data, Player player, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move && room.GetTag(Name) is Player target)
            {
                room.RemoveTag(Name);
                List<int> cards = new List<int>();
                for (int i = 0; i < move.Card_ids.Count; i++)
                {
                    int card_id = move.Card_ids[i];
                    if (room.GetCardPlace(card_id) == Place.DiscardPile)
                        cards.Add(card_id);
                }
                room.ObtainCard(target, ref cards, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, Name, string.Empty));
                if (player.Alive && target.Alive)
                {
                    List<string> choices = new List<string> { "invalid" };
                    List<string> desc = new List<string> { "@from-player:" + player.Name };
                    int count = cards.Count;
                    List<int> ids = new List<int>();
                    if (!target.IsAllNude() && RoomLogic.CanDiscard(room, target, target, "hej"))
                    {
                        foreach (int id in target.GetCards("hej"))
                            if (RoomLogic.CanDiscard(room, target, target, id)) ids.Add(id);

                        if (ids.Count >= count)
                        {
                            choices.Insert(0, "discard");
                            desc.Add("@tuoxian-discard:::" + count.ToString());
                        }
                    }
                    target.SetMark("tuoxian_count", count);
                    string choice = room.AskForChoice(target, Name, string.Join("+", choices), desc, player);
                    target.SetMark("tuoxian_count", 0);
                    if (choice == "invalid")
                    {
                        player.SetFlags("piaoping");
                    }
                    else
                    {
                        List<int> dis = new List<int>();
                        if (ids.Count == count)
                        {
                            dis = ids;
                        }
                        else
                        {
                            List<string> patterns = new List<string>();
                            for (int i = 0; i < count; i++)
                                patterns.Add("hej^true^discard");
                            dis = room.AskForCardsChosen(target, target, patterns, Name);
                        }
                        room.ThrowCard(ref dis, new CardMoveReason(MoveReason.S_REASON_THROW, target.Name, Name, string.Empty), target);
                    }
                }
            }
            return false;
        }
    }

    public class Zhuili : TriggerSkill
    {
        public Zhuili() : base("zhuili")
        {
            events = new List<TriggerEvent> { TriggerEvent.TargetConfirmed };
            skill_type = SkillType.Wizzard;
            frequency = Frequency.Compulsory;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TargetConfirmed && data is CardUseStruct use && use.From != null && !Engine.IsSkillCard(use.Card.Name) && WrappedCard.IsBlack(use.Card.Suit)
                && use.From != player && base.Triggerable(player, room) && !player.HasFlag(Name) && RoomLogic.PlayerHasSkill(room, player, "piaoping"))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            if (player.GetMark("piaoping") == 0)
            {
                player.SetFlags(Name);
                player.AddMark("tuoxian");
                room.SetPlayerStringMark(player, "tuoxian", player.GetMark("tuoxian").ToString());
            }
            else
            {
                player.SetMark("piaoping", 0);
                room.SetTurnSkillState(player, "piaoping", false, info.SkillPosition);
            }

            return false;
        }
    }

    public class Xiaoxi : TriggerSkill
    {
        public Xiaoxi() : base("xiaoxi")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            skill_type = SkillType.Attack;
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Play)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<string> choices = new List<string> { "1" };
            if (player.MaxHp > 1) choices.Add("2");
            string choice = room.AskForChoice(player, Name, string.Join("+", choices), new List<string> { "@xiaoxi-hp" }, null, info.SkillPosition);
            int count = int.Parse(choice);
            room.LoseMaxHp(player, count);
            if (player.Alive)
            {
                List<Player> targets = new List<Player>();
                WrappedCard slash = new WrappedCard(Slash.ClassName) { Skill = "_xiaoxi" };
                foreach (Player p in room.GetOtherPlayers(player))
                {
                    if (RoomLogic.InMyAttackRange(room, player, p) && (!p.IsNude() && RoomLogic.CanGetCard(room, player, p, "he") || RoomLogic.IsProhibited(room, player, p, slash) == null))
                        targets.Add(p);
                }

                if (targets.Count > 0)
                {
                    Player target = room.AskForPlayerChosen(player, targets, Name, "@xiaoxi", false, true, info.SkillPosition);
                    if (target != null)
                    {
                        choices.Clear();
                        if (!target.IsNude() && RoomLogic.CanGetCard(room, player, target, "he")) choices.Add("getcard");
                        if (RoomLogic.IsProhibited(room, player, target, slash) == null) choices.Add("slash");
                        choice = room.AskForChoice(player, Name, string.Join("+", choices), new List<string> { "@to-player:" + target.Name }, target, info.SkillPosition);
                        if (choice == "getcard")
                        {
                            List<string> patterns = new List<string>();
                            for (int i = 0; i < Math.Max(1, Math.Min(count, target.GetCardCount(true))); i++)
                                patterns.Add("he^false^get");

                            List<int> ids = room.AskForCardsChosen(player, target, patterns, Name);
                            CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_EXTRACTION, player.Name, target.Name, Name, string.Empty);
                            room.ObtainCard(player, ref ids, reason, false);
                        }
                        else
                        {
                            while (count > 0 && player.Alive && target.Alive && RoomLogic.IsProhibited(room, player, target, slash) == null)
                            {
                                count--;
                                WrappedCard card = new WrappedCard(Slash.ClassName) { Skill = "_xiaoxi", DistanceLimited = false };
                                room.UseCard(new CardUseStruct(card, player, target), false, true);
                            }
                        }
                    }
                }
            }

            return false;
        }
    }

    public class Xiongrao : PhaseChangeSkill
    {
        public Xiongrao() : base("xiongrao")
        {
            skill_type = SkillType.Replenish;
            frequency = Frequency.Limited;
            limit_mark = "@xiongrao";
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Start)
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
                return info;
            }
            return new TriggerStruct();
        }
        public override bool OnPhaseChange(Room room, Player player, TriggerStruct info)
        {
            foreach (Player p in room.GetOtherPlayers(player))
                p.SetFlags(Name);

            LogMessage log2 = new LogMessage
            {
                Type = "#xiongrao",
                From = player.Name,
            };
            room.SendLog(log2);

            if (player.MaxHp != 7)
            {
                int count = 7 - player.MaxHp;
                player.MaxHp = 7;
                room.BroadcastProperty(player, "MaxHp");

                LogMessage log = new LogMessage
                {
                    Type = "$GainMaxHp",
                    From = player.Name,
                    Arg = count.ToString()
                };
                room.SendLog(log);

                room.RoomThread.Trigger(TriggerEvent.MaxHpChanged, room, player);
                if (count > 0 && player.Alive)
                    room.DrawCards(player, count, Name);
            }

            return false;
        }
    }

    public class XiongraoInvalid : InvalidSkill
    {
        public XiongraoInvalid() : base("#xiongrao") { }
        public override bool Invalid(Room room, Player player, string skill)
        {
            Skill s = Engine.GetSkill(skill);
            if (s == null || s.SkillFrequency >= Frequency.Compulsory || s.Attached_lord_skill) return false;
            if (player.HasEquip(skill)) return false;
            return player.HasFlag("xiongrao");
        }
    }

    public class Geyuan : TriggerSkill
    {
        public Geyuan() : base("geyuan")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime, TriggerEvent.GameStart };
            frequency = Frequency.Compulsory;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.To_place == Place.DiscardPile)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                {
                    if (p.ContainsTag(Name) && p.GetTag(Name) is Dictionary<int, List<int>> numbers && numbers[1].Count < numbers[0].Count)
                    {
                        foreach (int id in move.Card_ids)
                        {
                            int number = room.GetCard(id).Number;
                            if (numbers[0].Contains(number) && !numbers[1].Contains(number))
                            {
                                triggers.Add(new TriggerStruct(Name, p));
                                break;
                            }
                        }
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.GameStart && base.Triggerable(player, room))
                triggers.Add(new TriggerStruct(Name, player));
            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.GameStart)
            {
                room.SendCompulsoryTriggerLog(player, Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);

                List<int> ids = new List<int>();
                for (int i = 1; i <= 13; i++)
                    ids.Add(i);
                Shuffle.shuffle(ref ids);
                Dictionary<int, List<int>> keys = new Dictionary<int, List<int>>();
                keys.Add(0, ids);
                keys.Add(1, new List<int>());
                player.SetTag(Name, keys);

                List<string> args = new List<string>
                {
                    GameEventType.S_GAME_EVENT_SKILL_GEYUAN.ToString(),
                    player.Name,
                    JsonUntity.Object2Json(keys),
                };
                room.DoBroadcastNotify(CommandType.S_COMMAND_LOG_EVENT, args);

                LogMessage log = new LogMessage("#geyuan_new");
                log.From = player.Name;
                room.SendLog(log);
            }
            else if (ask_who.GetTag(Name) is Dictionary<int, List<int>> numbers && data is CardsMoveOneTimeStruct move)
            {
                if (numbers[1].Count == 0)
                {
                    foreach (int id in move.Card_ids)
                    {
                        int number = room.GetCard(id).Number;
                        if (numbers[0].Contains(number))
                        {
                            LogMessage log = new LogMessage("#geyuan_add");
                            log.From = ask_who.Name;
                            log.Arg = number.ToString();
                            room.SendLog(log);
                            numbers[1].Add(number);
                            ask_who.SetTag(Name, numbers);

                            List<string> args = new List<string>
                            {
                                GameEventType.S_GAME_EVENT_SKILL_GEYUAN.ToString(),
                                ask_who.Name,
                                JsonUntity.Object2Json(numbers),
                            };
                            room.DoBroadcastNotify(CommandType.S_COMMAND_LOG_EVENT, args);
                            break;
                        }
                    }
                }
                else
                {
                    int min = 99, max = 0;
                    foreach (int id in numbers[1])
                    {
                        int index = numbers[0].IndexOf(id);
                        min = Math.Min(min, index);
                        max = Math.Max(max, index);
                    }

                    int first = min > 0 ? numbers[0][min - 1] : -1;
                    if (first == -1)
                    {
                        for (int i = numbers[0].Count - 1; i > min; i--)
                        {
                            if (!numbers[1].Contains(numbers[0][i]))
                            {
                                first = numbers[0][i];
                                break;
                            }
                        }
                    }
                    int last = max < numbers[0].Count - 1 ? numbers[0][max + 1] : -1;
                    if (last == -1)
                    {
                        for (int i = 0; i < max; i++)
                        {
                            if (!numbers[1].Contains(numbers[0][i]))
                            {
                                last = numbers[0][i];
                                break;
                            }
                        }
                    }

                    foreach (int id in move.Card_ids)
                    {
                        int number = room.GetCard(id).Number;
                        if (!numbers[1].Contains(number) && (number == first || number == last))
                        {
                            LogMessage log = new LogMessage("#geyuan_add");
                            log.From = ask_who.Name;
                            log.Arg = number.ToString();
                            room.SendLog(log);

                            numbers[1].Add(number);
                            ask_who.SetTag(Name, numbers);

                            List<string> args = new List<string>
                            {
                                GameEventType.S_GAME_EVENT_SKILL_GEYUAN.ToString(),
                                ask_who.Name,
                                JsonUntity.Object2Json(numbers),
                            };
                            room.DoBroadcastNotify(CommandType.S_COMMAND_LOG_EVENT, args);
                        }
                    }
                }

                if (numbers[1].Count == numbers[0].Count)
                {
                    if (numbers[0].Count > 3)
                    {
                        int first = numbers[1][0];
                        int last = numbers[1][numbers[1].Count - 1];
                        int first_count = ask_who.MaxHp;
                        int last_count = ask_who.MaxHp;
                        numbers[0].Remove(first);
                        numbers[0].Remove(last);

                        List<int> cards = new List<int>();
                        foreach (int id in room.DrawPile)
                        {
                            int number = room.GetCard(id).Number;
                            if (number == first && first_count > 0)
                            {
                                first_count--;
                                cards.Add(id);
                            }
                            else if (number == last && last_count > 0)
                            {
                                last_count--;
                                cards.Add(id);
                            }
                        }
                        if (cards.Count > 0)
                            room.ObtainCard(ask_who, ref cards, new CardMoveReason(MoveReason.S_REASON_GOTCARD, ask_who.Name, Name, string.Empty), true);

                        if (ask_who.Alive)
                        {
                            List<CardsMoveStruct> exchangeMove = new List<CardsMoveStruct>();
                            foreach (Player p in room.GetAlivePlayers())
                            {
                                List<int> ids = new List<int>();
                                foreach (int id in p.GetCards("ej"))
                                {
                                    int number = room.GetCard(id).Number;
                                    if ((number == first || number == last) && RoomLogic.CanGetCard(room, ask_who, p, id))
                                        ids.Add(id);
                                }

                                if (ids.Count > 0)
                                {
                                    CardsMoveStruct move1 = new CardsMoveStruct(ids, ask_who, Place.PlaceHand, new CardMoveReason(MoveReason.S_REASON_EXTRACTION, ask_who.Name, p.Name, Name, string.Empty));
                                    exchangeMove.Add(move1);
                                }
                            }
                            if (exchangeMove.Count > 0) room.MoveCards(exchangeMove, true);
                        }
                    }
                    else if (ask_who.GetMark("geyuan_description_index") == 1)
                    {
                        List<Player> targets = room.AskForPlayersChosen(ask_who, room.GetAlivePlayers(), Name, 0, 3, "@geyuan", true, info.SkillPosition);
                        if (targets.Count > 0)
                        {
                            List<string> choices = new List<string> { "draw" }, result = new List<string>();
                            if (targets.Count > 1) choices.Add("discard");
                            if (targets.Count > 2) choices.Add("exchange");

                            foreach (Player p in targets)
                            {
                                string choice = room.AskForChoice(ask_who, Name, string.Join("+", choices), new List<string> { "@to-player:" + p.Name }, p, info.SkillPosition);
                                result.Add(choice);
                                choices.Remove(choice);
                            }

                            int index = result.IndexOf("draw");
                            room.DrawCards(targets[index], new DrawCardStruct(3, ask_who, Name));

                            if (targets.Count > 1)
                            {
                                index = result.IndexOf("discard");
                                if (!targets[index].IsAllNude())
                                    room.AskForDiscard(targets[index], Name, 4, 4, false, true, "@geyuan-discard:" + ask_who.Name, false);
                            }
                            if (targets.Count > 2)
                            {
                                index = result.IndexOf("exchange");
                                if (room.DrawPile.Count < 5) room.SwapPile();
                                List<int> bottom = new List<int>();
                                for (int i = 0; i < 5; i++)
                                    bottom.Add(room.DrawPile[room.DrawPile.Count - 1 - i]);

                                CardsMoveStruct move1 = new CardsMoveStruct(bottom, targets[index], Place.PlaceHand, new CardMoveReason(MoveReason.S_REASON_SWAP, ask_who.Name, targets[index].Name, Name, string.Empty));
                                List<CardsMoveStruct> exchangeMove = new List<CardsMoveStruct> { move1 };

                                if (!targets[index].IsKongcheng())
                                {
                                    CardsMoveStruct move2 = new CardsMoveStruct(targets[index].GetCards("h"), null, Place.DrawPileBottom, new CardMoveReason(MoveReason.S_REASON_SWAP, ask_who.Name, targets[index].Name, Name, string.Empty));
                                    exchangeMove.Add(move2);
                                }
                                room.MoveCards(exchangeMove, false);
                            }
                        }
                    }

                    if (ask_who.Alive)
                    {
                        numbers[1].Clear();
                        List<int> ids = numbers[0];
                        Shuffle.shuffle(ref ids);
                        numbers[0] = ids;
                        ask_who.SetTag(Name, numbers);

                        List<string> args = new List<string>
                        {
                            GameEventType.S_GAME_EVENT_SKILL_GEYUAN.ToString(),
                            ask_who.Name,
                            JsonUntity.Object2Json(numbers),
                        };
                        room.DoBroadcastNotify(CommandType.S_COMMAND_LOG_EVENT, args);

                        LogMessage log = new LogMessage("#geyuan_new");
                        log.From = ask_who.Name;
                        room.SendLog(log);
                    }
                }
            }
            return false;
        }
    }

    public class Jieshu : TriggerSkill
    {
        public Jieshu() : base("jieshu")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsed, TriggerEvent.CardResponded };
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            int number = 0;
            if (triggerEvent == TriggerEvent.CardUsed && base.Triggerable(player, room) && data is CardUseStruct use)
                number = use.Card.Number;
            else if (triggerEvent == TriggerEvent.CardResponded && data is CardResponseStruct resp)
                number = resp.Card.Number;

            if (number > 0 && RoomLogic.PlayerHasSkill(room, player, "geyuan") && player.ContainsTag("geyuan") && player.GetTag("geyuan") is Dictionary<int, List<int>> numbers && numbers[1].Count < numbers[0].Count
                 && numbers[0].Contains(number) && !numbers[1].Contains(number))
            {
                if (numbers[1].Count == 0)
                    return new TriggerStruct(Name, player);
                else
                {
                    int min = 99, max = 0;
                    foreach (int id in numbers[1])
                    {
                        int index = numbers[0].IndexOf(id);
                        min = Math.Min(min, index);
                        max = Math.Max(max, index);
                    }

                    int first = min > 0 ? numbers[0][min - 1] : -1;
                    if (first == -1)
                    {
                        for (int i = numbers[0].Count - 1; i > min; i--)
                        {
                            if (!numbers[1].Contains(numbers[0][i]))
                            {
                                first = numbers[0][i];
                                break;
                            }
                        }
                    }
                    int last = max < numbers[0].Count - 1 ? numbers[0][max + 1] : -1;
                    if (last == -1)
                    {
                        for (int i = 0; i < max; i++)
                        {
                            if (!numbers[1].Contains(numbers[0][i]))
                            {
                                last = numbers[0][i];
                                break;
                            }
                        }
                    }

                    //room.Debug(string.Format("card number {0}, circle {1}, first {2}, last {3}", number, JsonUntity.Object2Json(numbers[0]), first, last));
                    if (number == first || number == last)
                        return new TriggerStruct(Name, player);
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.SendCompulsoryTriggerLog(player, Name);
            room.DrawCards(player, 1, Name);
            return false;
        }
    }

    public class JieshuMax : MaxCardsSkill
    {
        public JieshuMax() : base("#jieshu") { }
        public override bool Ingnore(Room room, Player player, int card_id)
        {
            if (RoomLogic.PlayerHasSkill(room, player, "jieshu") && RoomLogic.PlayerHasSkill(room, player, "geyuan") && player.ContainsTag("geyuan") && player.GetTag("geyuan") is Dictionary<int, List<int>> numbers)
                return !numbers[0].Contains(room.GetCard(card_id).Number);

            return false;
        }
    }

    public class Gusuan : TriggerSkill
    {
        public Gusuan() : base("gusuan")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            frequency = Frequency.Wake;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (player != null && player.Phase == PlayerPhase.Finish)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                {
                    if (p.GetMark(Name) == 0 && p.ContainsTag("geyuan") && p.GetTag("geyuan") is Dictionary<int, List<int>> numbers && numbers[0].Count == 3)
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }

            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            room.DoSuperLightbox(ask_who, info.SkillPosition, Name);
            room.SetPlayerMark(ask_who, Name, 1);
            room.SendCompulsoryTriggerLog(ask_who, Name);
            room.LoseMaxHp(ask_who);

            if (ask_who.Alive && ask_who.OwnSkill("geyuan"))
            {
                room.SetPlayerMark(ask_who, "geyuan_description_index", 1);
                room.RefreshSkill(ask_who);
            }
            return false;
        }
    }

    public class Yingtu : TriggerSkill
    {
        public Yingtu() : base("yingtu")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime };
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (data is CardsMoveOneTimeStruct move && move.To != null && move.To.Alive && !move.To.IsNude() && move.To.Phase != PlayerPhase.Draw && move.To_place == Place.PlaceHand)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                {
                    if (!p.HasFlag(Name) && (room.GetNextAlive(move.To) == p || room.GetLastAlive(move.To) == p) && RoomLogic.CanGetCard(room, p, move.To, "he"))
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }

            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move)
            {
                Player to = room.GetNextAlive(move.To) == ask_who ? room.GetNextAlive(ask_who) : room.GetLastAlive(ask_who);
                if (room.AskForSkillInvoke(ask_who, Name, string.Format("@yingtu:{0}:{1}", move.To.Name, to.Name), info.SkillPosition))
                {
                    ask_who.SetFlags(Name);
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, move.To.Name);
                    room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move)
            {
                bool next = room.GetNextAlive(move.To) == ask_who;
                int id = room.AskForCardChosen(ask_who, move.To, "he", Name, false, HandlingMethod.MethodGet);
                room.ObtainCard(ask_who, room.GetCard(id), new CardMoveReason(MoveReason.S_REASON_EXTRACTION, ask_who.Name, move.To.Name, Name, string.Empty), false);
                if (ask_who.Alive && !ask_who.IsNude())
                {
                    Player to = next ? room.GetNextAlive(ask_who) : room.GetLastAlive(ask_who);
                    List<int> ids = room.AskForExchange(ask_who, Name, 1, 1, "@yingtu-to:" + to.Name, string.Empty, "..", info.SkillPosition);
                    if (ids.Count > 0)
                    {
                        room.ObtainCard(to, ref ids, new CardMoveReason(MoveReason.S_REASON_GIVE, ask_who.Name, to.Name, Name, string.Empty), false);
                        if (to.Alive && ids.Count == 1 && room.GetCardPlace(ids[0]) == Place.PlaceHand && room.GetCardOwner(ids[0]) == to)
                        {
                            WrappedCard card = room.GetCard(ids[0]);
                            FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                            if (fcard is EquipCard && fcard.IsAvailable(room, to, card))
                                room.UseCard(new CardUseStruct(card, to, new List<Player>(), true));
                        }
                    }
                }
            }

            return false;
        }
    }
    public class Congshi : TriggerSkill
    {
        public Congshi() : base("congshi")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardFinished };
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Replenish;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (data is CardUseStruct use && player.Alive && Engine.GetFunctionCard(use.Card.Name) is EquipCard)
            {
                int max = 0;
                foreach (Player p in room.GetAlivePlayers())
                    if (p.GetEquips().Count > max)
                        max = p.GetEquips().Count;

                if (player.GetEquips().Count == max)
                {
                    foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }
            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            room.DrawCards(ask_who, 1, Name);
            return false;
        }
    }

    public class Suoliang : TriggerSkill
    {
        public Suoliang() : base("suoliang")
        {
            events.Add(TriggerEvent.Damage);
            skill_type = SkillType.Attack;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && !player.HasFlag(Name) && data is DamageStruct damage && damage.To != player && damage.To.Alive && !damage.To.IsNude())
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage && room.AskForSkillInvoke(player, Name, damage.To, info.SkillPosition))
            {
                player.SetFlags(Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                List<int> ids = room.AskForCardsChosen(player, damage.To, "he", Name, 1, Math.Min(damage.To.MaxHp, 5));
                if (ids.Count > 0)
                {
                    List<int> show = new List<int>();
                    foreach (int id in ids)
                        if (room.GetCardPlace(id) == Place.PlaceHand)
                            show.Add(id);

                    if (show.Count > 0)
                        room.ShowCards(damage.To, show, Name);

                    List<int> gets = new List<int>();
                    foreach (int id in ids)
                    {
                        WrappedCard card = room.GetCard(id);
                        if ((card.Suit == WrappedCard.CardSuit.Heart || card.Suit == WrappedCard.CardSuit.Club) && RoomLogic.CanGetCard(room, player, damage.To, id))
                            gets.Add(id);
                    }

                    if (gets.Count > 0)
                    {
                        room.ObtainCard(player, ref gets, new CardMoveReason(MoveReason.S_REASON_EXTRACTION, player.Name, damage.To.Name, Name, string.Empty), true);
                    }
                    else
                    {
                        ids.RemoveAll(t => !RoomLogic.CanDiscard(room, player, damage.To, t));
                        if (ids.Count > 0)
                            room.ThrowCard(ref ids, damage.To, player);
                    }
                }
            }
            return false;
        }
    }

    public class Qinbao : TriggerSkill
    {
        public Qinbao() : base("qinbao")
        {
            frequency = Frequency.Compulsory;
            events = new List<TriggerEvent> { TriggerEvent.TargetChosen, TriggerEvent.TrickCardCanceling };
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use && base.Triggerable(player, room))
            {
                if (use.Card.Name.Contains(Slash.ClassName))
                {
                    foreach (Player p in use.To)
                        if (p != player && p.HandcardNum >= player.HandcardNum)
                            return new TriggerStruct(Name, player);

                }
                if (Engine.GetFunctionCard(use.Card.Name).IsNDTrick())
                    foreach (Player p in room.GetOtherPlayers(player))
                        if (p.HandcardNum >= player.HandcardNum)
                            return new TriggerStruct(Name, player);
            }
            else if (triggerEvent == TriggerEvent.TrickCardCanceling && data is CardEffectStruct effect && base.Triggerable(effect.From, room) && player != effect.From && player.HandcardNum >= effect.From.HandcardNum)
            {
                return new TriggerStruct(Name, effect.From);
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.TargetChosen && data is CardUseStruct use)
            {
                List<Player> targets = new List<Player>();
                if (use.Card.Name.Contains(Slash.ClassName) || use.Card.Name == Duel.ClassName || use.Card.Name == Collateral.ClassName
                    || use.Card.Name == ArcheryAttack.ClassName || use.Card.Name == SavageAssault.ClassName)
                {
                    for (int i = 0; i < use.EffectCount.Count; i++)
                    {
                        CardBasicEffect effect = use.EffectCount[i];
                        if (effect.To.HandcardNum >= player.HandcardNum)
                        {
                            effect.Effect2 = 0;
                            if (!targets.Contains(effect.To))
                                targets.Add(effect.To);
                        }
                    }
                }

                if (Engine.GetFunctionCard(use.Card.Name).IsNDTrick())
                    foreach (Player p in room.GetOtherPlayers(player))
                        if (p.HandcardNum >= player.HandcardNum && !targets.Contains(p))
                            targets.Add(p);

                if (targets.Count > 0)
                {
                    room.SortByActionOrder(ref targets);
                    foreach (Player p in targets)
                        room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, p.Name);

                    room.SendCompulsoryTriggerLog(ask_who, Name);
                    room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);

                    LogMessage log = new LogMessage
                    {
                        Type = "#NoRespond2",
                        From = player.Name,
                        Card_str = RoomLogic.CardToString(room, use.Card)
                    };
                    log.SetTos(targets);
                    room.SendLog(log);
                }
            }
            else if (triggerEvent == TriggerEvent.TrickCardCanceling)
                return true;

            return false;
        }
    }

    public class Guolun : ZeroCardViewAsSkill
    {
        public Guolun() : base("guolun") { }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(GuolunCard.ClassName);

        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(GuolunCard.ClassName) { Skill = Name };
    }

    public class GuolunCard : SkillCard
    {
        public static string ClassName = "GuolunCard";
        public GuolunCard() : base(ClassName) { }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card) => targets.Count == 0 && !to_select.IsKongcheng() && to_select != Self;
        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            int id = room.AskForCardChosen(player, target, "h", "guolun", false, HandlingMethod.MethodNone);
            room.ShowCard(target, id, "guolun");

            List<int> ids = new List<int>();
            player.SetMark("guolun", id);
            target.SetFlags("guolun");
            if (!player.IsKongcheng())
                ids = room.AskForExchange(player, "guolun", 1, 0, "@guolun:" + target.Name, string.Empty, ".", card_use.Card.SkillPosition);
            player.SetMark("guolun", 0);
            target.SetFlags("-guolun");

            if (ids.Count > 0)
            {
                Player drawer = null;
                if (room.GetCard(ids[0]).Number < room.GetCard(id).Number)
                    drawer = player;
                else if (room.GetCard(ids[0]).Number > room.GetCard(id).Number)
                    drawer = target;

                CardsMoveStruct move1 = new CardsMoveStruct(ids, target, Place.PlaceHand,
                    new CardMoveReason(MoveReason.S_REASON_SWAP, player.Name, target.Name, "guolun", string.Empty));
                CardsMoveStruct move2 = new CardsMoveStruct(new List<int> { id }, player, Place.PlaceHand,
                    new CardMoveReason(MoveReason.S_REASON_SWAP, target.Name, player.Name, "guolun", string.Empty));
                List<CardsMoveStruct> exchangeMove = new List<CardsMoveStruct> { move1, move2 };
                room.MoveCards(exchangeMove, true);

                if (drawer != null && drawer.Alive)
                    room.DrawCards(drawer, new DrawCardStruct(1, player, "guolun"));
            }
        }
    }
    public class Songsang : TriggerSkill
    {
        public Songsang() : base("songsang")
        {
            events.Add(TriggerEvent.Death);
            frequency = Frequency.Limited;
            skill_type = SkillType.Recover;
            limit_mark = "@sang";
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            List<Player> caopis = RoomLogic.FindPlayersBySkillName(room, Name);
            foreach (Player caopi in caopis)
                if (caopi != player && caopi.GetMark(limit_mark) > 0)
                    triggers.Add(new TriggerStruct(Name, caopi));

            return triggers;
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player caopi, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(caopi, Name, data, info.SkillPosition))
            {
                room.SetPlayerMark(caopi, limit_mark, 0);
                room.BroadcastSkillInvoke(Name, caopi, info.SkillPosition);
                room.DoSuperLightbox(caopi, info.SkillPosition, Name);
                return info;
            }
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player caopi, TriggerStruct info)
        {
            if (caopi.IsWounded())
            {
                RecoverStruct recover = new RecoverStruct
                {
                    Who = caopi,
                    Recover = 1
                };
                room.Recover(caopi, recover, true);
            }
            else
            {
                caopi.MaxHp++;
                room.BroadcastProperty(caopi, "MaxHp");

                LogMessage log = new LogMessage
                {
                    Type = "$GainMaxHp",
                    From = caopi.Name,
                    Arg = "1"
                };
                room.SendLog(log);
                room.RoomThread.Trigger(TriggerEvent.MaxHpChanged, room, caopi);
            }
            room.HandleAcquireDetachSkills(caopi, "zhanji", true);

            return false;
        }
    }

    public class Zhanji : TriggerSkill
    {
        public Zhanji() : base("zhanji")
        {
            events.Add(TriggerEvent.CardsMoveOneTime);
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardsMoveOneTimeStruct move && move.To != null && base.Triggerable(move.To, room) && move.To.Phase == PlayerPhase.Play
                && move.Reason.Reason == MoveReason.S_REASON_DRAW && move.Reason.SkillName != Name)
                return new TriggerStruct(Name, move.To);

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            room.DrawCards(ask_who, 1, Name);

            return false;
        }
    }

    public class Guanwei : TriggerSkill
    {
        public Guanwei() : base("guanwei")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsed, TriggerEvent.CardResponded, TriggerEvent.EventPhaseEnd, TriggerEvent.EventPhaseChanging };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use && player.Alive && player == room.Current && !player.HasFlag(Name))
            {
                if (Engine.GetFunctionCard(use.Card.Name).TypeID != CardType.TypeSkill)
                {
                    List<WrappedCard.CardSuit> suits = player.ContainsTag(Name) ? (List<WrappedCard.CardSuit>)player.GetTag(Name) : new List<WrappedCard.CardSuit>();
                    if (use.Card.Suit > WrappedCard.CardSuit.Diamond || (suits.Count > 0 && !suits.Contains(use.Card.Suit)))
                    {
                        player.SetFlags(Name);
                    }
                    else
                    {
                        suits.Add(use.Card.Suit);
                        player.SetTag(Name, suits);
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.CardResponded && data is CardResponseStruct resp && resp.Use && player.Alive && player == room.Current && !player.HasFlag(Name))
            {
                List<WrappedCard.CardSuit> suits = player.ContainsTag(Name) ? (List<WrappedCard.CardSuit>)player.GetTag(Name) : new List<WrappedCard.CardSuit>();
                if (resp.Card.Suit > WrappedCard.CardSuit.Diamond || (suits.Count > 0 && !suits.Contains(resp.Card.Suit)))
                {
                    player.SetFlags(Name);
                }
                else
                {
                    suits.Add(resp.Card.Suit);
                    player.SetTag(Name, suits);
                }
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player.ContainsTag(Name))
                player.RemoveTag(Name);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.EventPhaseEnd && player.Phase == PlayerPhase.Play && player.Alive && !player.HasFlag(Name) && player.ContainsTag(Name)
                && player.GetTag(Name) is List<WrappedCard.CardSuit> suits && suits.Count > 1)
            {
                bool invoke = true;
                for (int i = 1; i < suits.Count; i++)
                {
                    if (suits[i] != suits[0])
                    {
                        invoke = false;
                        break;
                    }
                }

                if (invoke)
                {
                    foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }

            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.Alive && ask_who.Alive && !player.HasFlag(Name) && room.AskForDiscard(ask_who, Name, 1, 0, true, true, "@guanwei:" + player.Name, true, info.SkillPosition))
            {
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, player.Name);
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            player.SetFlags(Name);
            if (player.Alive) room.DrawCards(player, new DrawCardStruct(2, ask_who, Name));
            if (player.Alive) player.AddPhase(PlayerPhase.Play);
            return false;
        }
    }

    public class Gongqing : TriggerSkill
    {
        public Gongqing() : base("gongqing")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageInflicted, TriggerEvent.DamageDefined };
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Masochism;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && data is DamageStruct damage && damage.From != null && damage.From.Alive)
            {
                int range = RoomLogic.GetAttackRange(room, damage.From);
                if ((triggerEvent == TriggerEvent.DamageDefined && range < 3 && damage.Damage > 1) || (triggerEvent == TriggerEvent.DamageInflicted && range > 3))
                    return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            DamageStruct damage = (DamageStruct)data;
            room.SendCompulsoryTriggerLog(player, Name);
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);

            if (triggerEvent == TriggerEvent.DamageDefined)
            {
                damage.Damage = 1;
                LogMessage log = new LogMessage
                {
                    Type = "#ReduceDamage",
                    From = player.Name,
                    Arg = Name,
                    Arg2 = (damage.Damage).ToString()
                };
                room.SendLog(log);
            }
            else
            {
                LogMessage log = new LogMessage
                {
                    Type = "#AddDamaged",
                    From = player.Name,
                    Arg = Name,
                    Arg2 = (++damage.Damage).ToString()
                };
                room.SendLog(log);
            }

            data = damage;

            return false;
        }
    }
    public class Qinguo : TriggerSkill
    {
        public Qinguo() : base("qinguo")
        {
            events.Add(TriggerEvent.CardFinished);
            skill_type = SkillType.Attack;
            view_as_skill = new QinguoVS();
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardUseStruct use && base.Triggerable(player, room) && room.Current == player && Engine.GetFunctionCard(use.Card.Name) is EquipCard)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.AskForUseCard(player, RespondType.Skill, "@@qinguo", "@qinguo-slash", null, -1, HandlingMethod.MethodUse, false, info.SkillPosition);
            return new TriggerStruct();
        }

        public override void GetEffectIndex(Room room, Player player, WrappedCard card, ref int index, ref string skill_name, ref string general_name, ref int skin_id)
        {
            index = 1;
        }
    }


    public class QinguoVS : ViewAsSkill
    {
        public QinguoVS() : base("qinguo")
        {
            response_pattern = "@@qinguo";
        }
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            return false;
        }
        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return false;
        }

        public override List<WrappedCard> GetGuhuoCards(Room room, List<WrappedCard> cards, Player Self)
        {
            if (cards.Count == 0)
                return new List<WrappedCard> { new WrappedCard(Slash.ClassName) { Skill = Name, ShowSkill = Name } };

            return new List<WrappedCard>();
        }

        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count == 1 && cards[0].IsVirtualCard())
                return cards[0];

            return null;
        }
    }

    public class QinguoRecover : TriggerSkill
    {
        public QinguoRecover() : base("#qinguo")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime };
            skill_type = SkillType.Recover;
            frequency = Frequency.Compulsory;
        }


        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move)
            {
                if (move.From != null && base.Triggerable(move.From, room) && move.From_places.Contains(Place.PlaceEquip) && move.From.Hp == move.From.GetEquips().Count
                    && move.Card_ids.Count == move.From_places.Count && move.From.IsWounded())
                {
                    int count = 0;
                    foreach (Place place in move.From_places)
                        if (place == Place.PlaceEquip) count++;
                    if (count > 0) return new TriggerStruct(Name, move.From);

                }
                else if (move.To != null && base.Triggerable(move.To, room) && move.To_place == Place.PlaceEquip && move.To.Hp == move.To.GetEquips().Count
                    && move.Card_ids.Count > 0 && move.To.IsWounded())
                {
                    return new TriggerStruct(Name, move.To);
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (ask_who.Alive && ask_who.IsWounded())
            {
                room.SendCompulsoryTriggerLog(ask_who, Name, true);
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
                room.BroadcastSkillInvoke("qinguo", "male", 2, gsk.General, gsk.SkinId);

                RecoverStruct recover = new RecoverStruct
                {
                    Recover = 1,
                    Who = ask_who
                };
                room.Recover(ask_who, recover, true);
            }

            return false;
        }
    }

    public class Youdi : PhaseChangeSkill
    {
        public Youdi() : base("youdi")
        {
            skill_type = SkillType.Attack;
        }

        public override bool Triggerable(Player target, Room room)
        {
            return base.Triggerable(target, room) && target.Phase == PlayerPhase.Finish && !target.IsKongcheng();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<Player> targets = new List<Player>();
            foreach (Player p in room.GetOtherPlayers(player))
                if (RoomLogic.CanDiscard(room, p, player, "h")) targets.Add(p);

            if (targets.Count > 0)
            {
                Player target = room.AskForPlayerChosen(player, targets, Name, "@youdi", true, true, info.SkillPosition);
                if (target != null)
                {
                    room.SetTag(Name, target);
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    return info;
                }
            }

            return new TriggerStruct();
        }

        public override bool OnPhaseChange(Room room, Player player, TriggerStruct info)
        {
            Player target = (Player)room.GetTag(Name);
            room.RemoveTag(Name);

            int id = room.AskForCardChosen(target, player, "h", Name, false, HandlingMethod.MethodDiscard);
            List<int> ids = new List<int> { id };
            room.ThrowCard(ref ids, player, target);
            if (ids.Count == 1)
            {
                WrappedCard card = room.GetCard(ids[0]);
                bool red = WrappedCard.IsRed(card.Suit);
                if (player.Alive && !card.Name.Contains(Slash.ClassName) && target.Alive && RoomLogic.CanGetCard(room, player, target, "he"))
                {
                    int get = room.AskForCardChosen(player, target, "he", Name, false, HandlingMethod.MethodGet);
                    List<int> gets = new List<int> { get };
                    room.ObtainCard(player, ref gets, new CardMoveReason(MoveReason.S_REASON_EXTRACTION, player.Name, target.Name, string.Empty), false);
                }

                if (red && player.Alive)
                    room.DrawCards(player, 1, Name);
            }

            return false;
        }
    }

    public class DuanfaCard : SkillCard
    {
        public static string ClassName = "DuanfaCard";
        public DuanfaCard() : base(ClassName)
        {
            target_fixed = true;
        }
        public override void Use(Room room, CardUseStruct card_use)
        {
            if (card_use.From.Alive)
            {
                int count = card_use.Card.SubCards.Count;
                card_use.From.AddMark("duanfa", count);
                room.DrawCards(card_use.From, count, "duanfa");
            }
        }
    }

    public class Duanfa : TriggerSkill
    {
        public Duanfa() : base("duanfa")
        {
            events.Add(TriggerEvent.EventPhaseChanging);
            view_as_skill = new DuanfaVS();
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is PhaseChangeStruct change && change.From == PlayerPhase.Play && player.GetMark(Name) > 0)
                player.SetMark(Name, 0);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class DuanfaVS : ViewAsSkill
    {
        public DuanfaVS() : base("duanfa")
        {
        }
        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return !player.IsNude() && player.GetMark(Name) < player.MaxHp;
        }
        public override bool ViewFilter(Room room, List<WrappedCard> selected, WrappedCard to_select, Player player)
        {
            return !RoomLogic.IsJilei(room, player, to_select) && WrappedCard.IsBlack(to_select.Suit) && selected.Count < player.MaxHp - player.GetMark(Name);
        }
        public override WrappedCard ViewAs(Room room, List<WrappedCard> cards, Player player)
        {
            if (cards.Count == 0)
                return null;

            WrappedCard zhiheng_card = new WrappedCard(DuanfaCard.ClassName)
            {
                Skill = Name,
                ShowSkill = Name
            };
            zhiheng_card.AddSubCards(cards);
            return zhiheng_card;
        }
    }

    public class Biaozhao : TriggerSkill
    {
        public Biaozhao() : base("biaozhao") { events.Add(TriggerEvent.EventPhaseStart); }

        public override bool Triggerable(Player target, Room room)
        {
            return base.Triggerable(target, room) && target.Phase == PlayerPhase.Finish && !target.IsNude();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<int> ids = room.AskForExchange(player, Name, 1, 0, "@biaozhao", string.Empty, "..", info.SkillPosition);
            if (ids.Count > 0)
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.NotifySkillInvoked(player, Name);
                room.AddToPile(player, Name, ids);
                return info;
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            return false;
        }
    }

    public class BiaozhaoEffect : TriggerSkill
    {
        public BiaozhaoEffect() : base("#biaozhao")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseStart, TriggerEvent.EventLoseSkill };
            frequency = Frequency.Compulsory;
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.To_place == Place.DiscardPile)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, "biaozhao"))
                {
                    List<int> ids = p.GetPile("biaozhao");
                    if (ids.Count > 0)
                    {
                        bool invoke = false;
                        WrappedCard card1 = room.GetCard(ids[0]);
                        foreach (int id2 in move.Card_ids)
                        {
                            WrappedCard card2 = room.GetCard(id2);
                            if (card1.Number == card2.Number && card1.Suit == card2.Suit)
                            {
                                invoke = true;
                                break;
                            }
                        }
                        if (invoke) triggers.Add(new TriggerStruct(Name, p));
                    }
                }
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.Phase == PlayerPhase.Start && player.GetPile("biaozhao").Count > 0)
            {
                triggers.Add(new TriggerStruct(Name, player));
            }
            else if (triggerEvent == TriggerEvent.EventLoseSkill && data is InfoStruct info && info.Info == "biaozhao" && player.GetPile("biaozhao").Count > 0)
            {
                triggers.Add(new TriggerStruct(Name, player));
            }
            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move)
            {
                if (move.From != null && (move.Reason.Reason & MoveReason.S_MASK_BASIC_REASON) == MoveReason.S_REASON_DISCARD && move.From.Alive)
                {
                    List<int> ids = ask_who.GetPile("biaozhao");
                    room.ObtainCard(move.From, ref ids, new CardMoveReason(MoveReason.S_REASON_GOTCARD, move.From.Name, "biaozhao", string.Empty));
                }
                else
                    room.ClearOnePrivatePile(ask_who, "biaozhao");

                if (ask_who.Alive)
                    room.LoseHp(ask_who);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                room.ClearOnePrivatePile(player, "biaozhao");
                Player target = room.AskForPlayerChosen(player, room.GetAlivePlayers(), "biaozhao", "@biaozhao-draw", false, true, info.SkillPosition);
                if (target.IsWounded())
                {
                    RecoverStruct recover = new RecoverStruct
                    {
                        Recover = 1,
                        Who = player
                    };
                    room.Recover(target, recover, true);
                }
                if (target.Alive)
                {
                    int count = 0;
                    foreach (Player p in room.GetAlivePlayers())
                        if (p.HandcardNum > count) count = p.HandcardNum;

                    int draw = Math.Min(count - target.HandcardNum, 5);
                    if (draw > 0)
                        room.DrawCards(target, new DrawCardStruct(draw, player, "biaozhao"));
                }
            }
            else if (triggerEvent == TriggerEvent.EventLoseSkill)
            {
                room.ClearOnePrivatePile(player, "biaozhao");
            }
            return false;
        }
    }

    public class Yechou : TriggerSkill
    {
        public Yechou() : base("yechou")
        {
            events = new List<TriggerEvent> { TriggerEvent.Death, TriggerEvent.TurnStart };
            skill_type = SkillType.Attack;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.TurnStart && player.GetMark(Name) > 0)
            {
                player.SetMark(Name, 0);
                room.RemovePlayerStringMark(player, Name);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.Death && RoomLogic.PlayerHasSkill(room, player, Name))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<Player> targets = new List<Player>();
            foreach (Player p in room.GetOtherPlayers(player))
                if (p.GetLostHp() > 1) targets.Add(p);
            if (targets.Count > 0)
            {
                Player target = room.AskForPlayerChosen(player, targets, Name, "@yechou", true, true, info.SkillPosition);
                if (target != null)
                {
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    room.SetTag(Name, target);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = (Player)room.GetTag(Name);
            room.RemoveTag(Name);
            target.AddMark(Name);
            room.SetPlayerStringMark(target, Name, string.Empty);
            return false;
        }
    }

    public class YechouLose : TriggerSkill
    {
        public YechouLose() : base("#yechou") { events.Add(TriggerEvent.EventPhaseChanging); frequency = Frequency.Compulsory; }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
                foreach (Player p in room.GetAlivePlayers())
                    if (p.GetMark("yechou") > 0)
                        triggers.Add(new TriggerStruct(Name, p));

            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.LoseHp(ask_who);
            return false;
        }
    }

    public class Guanchao : TriggerSkill
    {
        public Guanchao() : base("guanchao")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsed, TriggerEvent.CardResponded, TriggerEvent.EventPhaseStart, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Replenish;
            priority = new Dictionary<TriggerEvent, double>
            {
                { TriggerEvent.CardUsed, 2 },
                { TriggerEvent.CardResponded, 2 },
                { TriggerEvent.EventPhaseStart, 3 },
                { TriggerEvent.EventPhaseChanging, 3 },
            };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.From == Player.PlayerPhase.Play
                && (player.HasFlag("guanchao++") || player.HasFlag("guanchao--")))
            {
                player.SetFlags("-guanchao++");
                player.SetFlags("-guanchao--");
                player.SetMark("guanchao", 0);
                room.RemovePlayerStringMark(player, "guanchao");
            }
            else if ((triggerEvent == TriggerEvent.CardUsed || triggerEvent == TriggerEvent.CardResponded) && player.Phase == PlayerPhase.Play
                && (player.HasFlag("guanchao++") || player.HasFlag("guanchao--")))
            {
                WrappedCard card = null;
                if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use)
                    card = use.Card;
                else if (triggerEvent == TriggerEvent.CardResponded && data is CardResponseStruct resp && resp.Use)
                    card = resp.Card;

                if (card != null)
                {
                    FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                    if (!(fcard is SkillCard) && !(fcard is ImperialOrder))
                    {
                        bool remove = false;
                        if (card.Number == 0)
                            remove = true;
                        else
                        {
                            if ((player.HasFlag("guanchao++") && card.Number <= player.GetMark(Name))
                                || (player.HasFlag("guanchao--") && card.Number >= player.GetMark(Name) && player.GetMark(Name) > 0))
                                remove = true;
                            else
                            {
                                player.SetMark("guanchao", card.Number);
                                room.SetPlayerStringMark(player, "guanchao", card.Number.ToString());
                            }
                        }

                        if (remove)
                        {
                            player.SetFlags("-guanchao++");
                            player.SetFlags("-guanchao--");
                            player.SetMark("guanchao", 0);
                            room.RemovePlayerStringMark(player, "guanchao");
                        }
                    }
                }
            }
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Play && base.Triggerable(player, room))
            {
                return new TriggerStruct(Name, player);
            }
            return new TriggerStruct();
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            string choice = room.AskForChoice(player, Name, "more+less+cancel", null, null, info.SkillPosition);
            if (choice != "cancel")
            {
                room.NotifySkillInvoked(player, Name);
                GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, player, "guanchao", info.SkillPosition);
                room.BroadcastSkillInvoke("guanchao", "male", 1, gsk.General, gsk.SkinId);

                LogMessage log = new LogMessage
                {
                    From = player.Name
                };
                if (choice == "more")
                {
                    player.SetFlags("guanchao++");
                    log.Type = "#guanchao-more";
                }
                else
                {
                    player.SetFlags("guanchao--");
                    log.Type = "#guanchao-less";
                }
                room.SendLog(log);
                return info;
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            return false;
        }
    }
    public class GuanchaoRecord : TriggerSkill
    {
        public GuanchaoRecord() : base("#guanchao")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsed, TriggerEvent.CardResponded };
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if ((triggerEvent == TriggerEvent.CardUsed || triggerEvent == TriggerEvent.CardResponded) && player.Phase == PlayerPhase.Play && player.Alive)
            {
                WrappedCard card = null;
                if (triggerEvent == TriggerEvent.CardUsed && data is CardUseStruct use)
                    card = use.Card;
                else if (triggerEvent == TriggerEvent.CardResponded && data is CardResponseStruct resp && resp.Use)
                    card = resp.Card;

                if (card != null && card.Number > 0)
                {
                    FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                    if (!(fcard is SkillCard) && !(fcard is ImperialOrder))
                    {
                        int number = player.GetMark("guanchao");
                        if (number > 0 && ((card.Number > number && player.HasFlag("guanchao++")) || (card.Number < number && player.HasFlag("guanchao--"))))
                            return new TriggerStruct(Name, player);
                    }
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, "guanchao");
            GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, player, "guanchao", info.SkillPosition);
            room.BroadcastSkillInvoke("guanchao", "male", 2, gsk.General, gsk.SkinId);

            if (player.Alive) room.DrawCards(player, 1, "guanchao");
            return false;
        }
    }

    public class Xunxian : TriggerSkill
    {
        public Xunxian() : base("xunxian")
        {
            events.Add(TriggerEvent.CardsMoveOneTime);
            skill_type = SkillType.Replenish;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardsMoveOneTimeStruct move && move.Reason.Card != null && ((move.Reason.Reason & MoveReason.S_MASK_BASIC_REASON) == MoveReason.S_REASON_USE
                || move.Reason.Reason == MoveReason.S_REASON_RESPONSE) && move.Card_ids.Count > 0 && move.To_place == Place.DiscardPile)
            {
                Player from = room.FindPlayer(move.Reason.PlayerId);
                if (base.Triggerable(from, room) && !from.HasFlag(Name) && from.Phase == PlayerPhase.NotActive)
                {
                    List<int> ids = room.GetSubCards(move.Reason.Card);
                    if (ids.SequenceEqual(move.Reason.Card.SubCards) && ids.SequenceEqual(move.Card_ids))
                    {
                        bool check = true;
                        foreach (int id in ids)
                        {
                            if (room.GetCardPlace(id) != Place.DiscardPile)
                            {
                                check = false;
                                break;
                            }
                        }
                        if (check) return new TriggerStruct(Name, from);
                    }
                }
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<Player> targets = new List<Player>();
            foreach (Player p in room.GetOtherPlayers(ask_who))
                if (p.HandcardNum > ask_who.HandcardNum)
                    targets.Add(p);

            if (targets.Count > 0 && data is CardsMoveOneTimeStruct move)
            {
                Player target = room.AskForPlayerChosen(ask_who, targets, Name, "@xunxian:::" + move.Reason.Card.Name, true, true, info.SkillPosition);
                if (target != null)
                {
                    room.SetTag(Name, target);
                    room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                    return info;
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            ask_who.SetFlags(Name);
            Player target = (Player)room.GetTag(Name);
            room.RemoveTag(Name);
            if (data is CardsMoveOneTimeStruct move)
            {
                List<int> ids = room.GetSubCards(move.Reason.Card);
                if (ids.Count > 0)
                {
                    room.RemoveSubCards(move.Reason.Card);
                    room.ObtainCard(target, ref ids, new CardMoveReason(MoveReason.S_REASON_RECYCLE, ask_who.Name, target.Name, Name, string.Empty));
                }
            }
            return false;
        }
    }

    public class Fuhai : TriggerSkill
    {
        public Fuhai() : base("fuhai")
        {
            events.Add(TriggerEvent.EventPhaseChanging);
            view_as_skill = new FuhaiVS();
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is PhaseChangeStruct change && change.From == PlayerPhase.Play)
            {
                if (player.GetMark(Name) > 0) player.SetMark(Name, 0);
                foreach (Player p in room.GetAlivePlayers())
                    if (p.HasFlag(Name))
                        p.SetFlags("-fuhai");
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }
    public class FuhaiVS : ZeroCardViewAsSkill
    {
        public FuhaiVS() : base("fuhai")
        {
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            if (player.HasFlag(Name) || player.IsKongcheng()) return false;
            foreach (Player p in room.GetOtherPlayers(player))
                if (!p.IsKongcheng() && !p.HasFlag(Name))
                    return true;

            return false;
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(FuhaiCard.ClassName) { Skill = Name };
        }
    }

    public class FuhaiCard : SkillCard
    {
        public static string ClassName = "FuhaiCard";
        public FuhaiCard() : base(ClassName)
        {
            target_fixed = true;
        }
        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            Player target;
            string choic = room.AskForChoice(player, "fuhai", "counterclockwise+clockwise", null, null, card_use.Card.SkillPosition);
            if (choic == "counterclockwise")
            {
                target = room.GetNextAlive(player, 1, false);
                bool succes;
                do
                {
                    while (target != player && (target.IsKongcheng() || target.HasFlag("fuhai")))
                        target = room.GetNextAlive(target, 1, false);

                    if (target != player)
                    {
                        player.AddMark("fuhai");
                        succes = DoShow(room, player, target, card_use.Card.SkillPosition);
                        if (!succes)
                        {
                            player.SetFlags("fuhai");
                            int count = player.GetMark("fuhai");
                            room.DrawCards(player, count, "fuhai");
                            if (target.Alive)
                                room.DrawCards(target, count, "fuhai");
                        }
                    }
                    else
                        succes = false;
                }
                while (succes && player.Alive && !player.IsKongcheng());
            }
            else
            {
                target = room.GetLastAlive(player, 1, false);
                bool succes;
                do
                {
                    while (target != player && (target.IsKongcheng() || target.HasFlag("fuhai")))
                        target = room.GetLastAlive(target, 1, false);

                    if (target != player)
                    {
                        player.AddMark("fuhai");
                        succes = DoShow(room, player, target, card_use.Card.SkillPosition);
                        Thread.Sleep(400);
                        if (!succes)
                        {
                            player.SetFlags("fuhai");
                            int count = player.GetMark("fuhai");
                            room.DrawCards(player, count, "fuhai");
                            if (target.Alive)
                                room.DrawCards(target, count, "fuhai");

                            Thread.Sleep(400);
                        }
                    }
                    else
                        succes = false;
                }
                while (succes && player.Alive && !player.IsKongcheng());
            }
        }

        private bool DoShow(Room room, Player player, Player target, string position)
        {
            target.SetFlags("fuhai");
            int from = room.AskForExchange(player, "fuhai", 1, 1, "@fuhai-show:" + target.Name, string.Empty, ".", position)[0];
            room.ShowCard(player, from, "fuhai");
            room.SetTag("fuhai", from);
            int to = room.AskForCardShow(target, player, "fuhai", from);
            room.RemoveTag("fuhai");
            room.ShowCard(target, to, "fuhai");
            if (room.GetCard(from).Number >= room.GetCard(to).Number)
            {
                if (RoomLogic.CanDiscard(room, player, player, from)) room.ThrowCard(from, player);

                return true;
            }
            else
            {
                if (RoomLogic.CanDiscard(room, target, target, to)) room.ThrowCard(to, target);

                return false;
            }
        }
    }

    public class Lianhua : TriggerSkill
    {
        public Lianhua() : base("lianhua")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damaged, TriggerEvent.EventPhaseStart, TriggerEvent.EventPhaseChanging };
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                if (player.HasFlag("lianhua_yingzi"))
                    room.HandleAcquireDetachSkills(player, "-yingzi_zhouyu", true);
                if (player.HasFlag("lianhua_guanxing"))
                    room.HandleAcquireDetachSkills(player, "-guanxing_jx", true);
                if (player.HasFlag("lianhua_gongxin"))
                    room.HandleAcquireDetachSkills(player, "-gongxin", true);
                if (player.HasFlag("lianhua_zhiyan"))
                    room.HandleAcquireDetachSkills(player, "-zhiyan", true);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Play && (player.GetMark("lianhua_red") > 0 || player.GetMark("lianhua_black") > 0))
            {
                player.SetMark("lianhua_red", 0);
                player.SetMark("lianhua_black", 0);
                room.SetPlayerMark(player, "@danxue", 0);
            }
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.Damaged && player.Alive)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    if (p != player && p.Phase == PlayerPhase.NotActive)
                        triggers.Add(new TriggerStruct(Name, p));
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.Phase == PlayerPhase.Start)
            {
                triggers.Add(new TriggerStruct(Name, player));
            }

            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, ask_who, Name, info.SkillPosition);
            if (triggerEvent == TriggerEvent.Damaged)
            {
                if ((player.GetRoleEnum() == PlayerRole.Lord || player.GetRoleEnum() == PlayerRole.Loyalist)
                    && (ask_who.GetRoleEnum() == PlayerRole.Lord || ask_who.GetRoleEnum() == PlayerRole.Loyalist))
                {
                    ask_who.AddMark("lianhua_red");
                }
                else if (player.GetRoleEnum() == PlayerRole.Rebel && ask_who.GetRoleEnum() == PlayerRole.Rebel)
                {
                    ask_who.AddMark("lianhua_red");
                }
                else
                    ask_who.AddMark("lianhua_black");

                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                room.SetPlayerMark(ask_who, "@danxue", ask_who.GetMark("lianhua_red") + ask_who.GetMark("lianhua_black"));
            }
            else
            {
                room.BroadcastSkillInvoke(Name, "male", 2, gsk.General, gsk.SkinId);
                List<int> ids = new List<int>(room.DrawPile);
                ids.AddRange(room.DiscardPile);
                Shuffle.shuffle(ref ids);
                if (ask_who.GetMark("lianhua_red") + ask_who.GetMark("lianhua_black") <= 3)
                {
                    player.SetFlags("lianhua_yingzi");
                    room.HandleAcquireDetachSkills(player, "yingzi_zhouyu", true);
                    foreach (int id in ids)
                    {
                        if (room.GetCard(id).Name == Peach.ClassName)
                        {
                            room.ObtainCard(player, id, true);
                            break;
                        }
                    }
                }
                else
                {
                    if (ask_who.GetMark("lianhua_red") > ask_who.GetMark("lianhua_black"))
                    {
                        player.SetFlags("lianhua_guanxing");
                        room.HandleAcquireDetachSkills(player, "guanxing_jx", true);
                        foreach (int id in ids)
                        {
                            if (room.GetCard(id).Name == ExNihilo.ClassName)
                            {
                                room.ObtainCard(player, id, true);
                                break;
                            }
                        }
                    }
                    else if (ask_who.GetMark("lianhua_red") < ask_who.GetMark("lianhua_black"))
                    {
                        player.SetFlags("lianhua_zhiyan");
                        room.HandleAcquireDetachSkills(player, "zhiyan", true);
                        foreach (int id in ids)
                        {
                            if (room.GetCard(id).Name == Snatch.ClassName)
                            {
                                room.ObtainCard(player, id, true);
                                break;
                            }
                        }
                    }
                    else
                    {
                        player.SetFlags("lianhua_gongxin");
                        room.HandleAcquireDetachSkills(player, "gongxin", true);
                        bool slash = false, duel = false;
                        foreach (int id in ids)
                        {
                            if (!slash && room.GetCard(id).Name == Slash.ClassName)
                            {
                                room.ObtainCard(player, id, true);
                                slash = true;
                            }
                            else if (!duel && room.GetCard(id).Name == Duel.ClassName)
                            {
                                room.ObtainCard(player, id, true);
                                duel = true;
                            }

                            if (slash && duel)
                                break;
                        }
                    }
                }
            }

            return false;
        }
    }

    public class Zhafu : ZeroCardViewAsSkill
    {
        public Zhafu() : base("zhafu")
        {
            frequency = Frequency.Limited;
            limit_mark = "@zhafu";
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            return player.GetMark(limit_mark) > 0;
        }

        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(ZhafuCard.ClassName) { Skill = Name, Mute = true };
        }
    }

    public class ZhafuCard : SkillCard
    {
        public static string ClassName = "ZhafuCard";
        public ZhafuCard() : base(ClassName) { }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && to_select != Self;
        }

        public override void OnUse(Room room, CardUseStruct card_use)
        {
            room.SetPlayerMark(card_use.From, "@zhafu", 0);
            room.BroadcastSkillInvoke("zhafu", card_use.From, card_use.Card.SkillPosition);
            room.DoSuperLightbox(card_use.From, card_use.Card.SkillPosition, "zhafu");
            base.OnUse(room, card_use);
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            card_use.To[0].SetTag("zhafu", card_use.From.Name);
            room.SetPlayerStringMark(card_use.To[0], "zhafu", string.Empty);
        }
    }
    public class ZhafuEffect : TriggerSkill
    {
        public ZhafuEffect() : base("#zhafu")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart };
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Discard && player.ContainsTag("zhafu"))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.GetTag("zhafu") is string general)
            {
                player.RemoveTag("zhafu");
                room.RemovePlayerStringMark(player, "zhafu");
                Player target = room.FindPlayer(general);
                if (target != null && player.HandcardNum > 1)
                {
                    List<int> hands = player.GetCards("h"), ids = room.AskForExchange(player, "zhafu", 1, 1, "@zhafu-give:" + target.Name, string.Empty, ".", string.Empty);
                    hands.RemoveAll(t => ids.Contains(t));
                    room.ObtainCard(target, ref hands, new CardMoveReason(MoveReason.S_REASON_GIVE, player.Name, target.Name, "zhafu", string.Empty), false);
                }
            }


            return false;
        }
    }

    public class Songshu : TriggerSkill
    {
        public Songshu() : base("songshu")
        {
            events.Add(TriggerEvent.EventPhaseChanging);
            view_as_skill = new SongshuVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.From == PlayerPhase.Play && player.HasFlag(Name))
                player.SetFlags("-songshu");
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class SongshuVS : ZeroCardViewAsSkill
    {
        public SongshuVS() : base("songshu") { }

        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasFlag(Name) && !player.IsKongcheng();
        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(SongshuCard.ClassName) { Skill = Name };
    }

    public class SongshuCard : SkillCard
    {
        public static string ClassName = "SongshuCard";
        public SongshuCard() : base(ClassName) { }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && RoomLogic.CanBePindianBy(room, to_select, Self) && to_select != Self;
        }
        public override void Use(Room room, CardUseStruct card_use)
        {
            Player target = card_use.To[0];
            PindianStruct pd = room.PindianSelect(card_use.From, target, "songshu");

            room.Pindian(ref pd);
            if (!pd.Success)
            {
                if (card_use.From.Alive) room.DrawCards(card_use.From, 2, "songshu");
                if (target.Alive) room.DrawCards(target, new DrawCardStruct(2, card_use.From, "songshu"));
                if (card_use.From.Alive) card_use.From.SetFlags("songshu");
            }
        }
    }
    public class Sibian : PhaseChangeSkill
    {
        public Sibian() : base("sibian")
        {
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player lidian, ref object data, Player ask_who)
        {
            return (base.Triggerable(lidian, room) && lidian.Phase == PlayerPhase.Draw) ? new TriggerStruct(Name, lidian) : new TriggerStruct();
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
        public override bool OnPhaseChange(Room room, Player player, TriggerStruct info)
        {
            List<int> card_ids = room.GetNCards(4), get = new List<int>();
            int max = 0, min = 13;
            foreach (int id in card_ids)
            {
                WrappedCard card = room.GetCard(id);
                if (card.Number > max) max = card.Number;
                if (card.Number < min) min = card.Number;
                room.MoveCardTo(room.GetCard(id), player, Place.PlaceTable, new CardMoveReason(MoveReason.S_REASON_TURNOVER, player.Name, Name, null), false);
                Thread.Sleep(400);
            }
            foreach (int id in card_ids)
            {
                WrappedCard card = room.GetCard(id);
                if (card.Number == max || card.Number == min) get.Add(id);
            }

            card_ids.RemoveAll(t => get.Contains(t));

            if (get.Count > 0)
                room.ObtainCard(player, ref get, new CardMoveReason(MoveReason.S_REASON_GOTCARD, player.Name, Name, string.Empty));

            bool throw_ids = true;
            if (player.Alive && card_ids.Count > 0)
            {
                List<Player> targets = new List<Player>();
                int hand_min = 400;
                foreach (Player p in room.GetAlivePlayers())
                    if (p.HandcardNum < hand_min)
                        hand_min = p.HandcardNum;

                foreach (Player p in room.GetAlivePlayers())
                    if (p.HandcardNum == hand_min)
                        targets.Add(p);

                Player target = room.AskForPlayerChosen(player, targets, Name, "@sibian", true, true, info.SkillPosition);
                if (target != null)
                    room.ObtainCard(target, ref card_ids, new CardMoveReason(MoveReason.S_REASON_PREVIEWGIVE, player.Name, target.Name, Name, string.Empty));
                else
                    throw_ids = true;
            }
            else
                throw_ids = true;

            if (throw_ids && card_ids.Count > 0)
            {
                CardsMoveStruct move = new CardsMoveStruct(card_ids, null, Place.DiscardPile, new CardMoveReason(MoveReason.S_REASON_NATURAL_ENTER, player.Name, Name, string.Empty));
                List<CardsMoveStruct> moves = new List<CardsMoveStruct> { move };
                room.MoveCardsAtomic(moves, true);
            }

            return true;
        }
    }

    public class FenyinOl : TriggerSkill
    {
        public FenyinOl() : base("fenyin_ol")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Replenish;
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive
                && room.ContainsTag(Name))
                room.RemoveTag(Name);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && room.Current != null && base.Triggerable(room.Current, room)
                && move.To_place == Place.DiscardPile)
            {
                List<int> suits = new List<int>();
                if (room.ContainsTag(Name)) suits = (List<int>)room.GetTag(Name);
                foreach (int id in move.Card_ids)
                {
                    int suit = (int)room.GetCard(id).Suit;
                    if (!suits.Contains(suit))
                        return new TriggerStruct(Name, room.Current);
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move)
            {
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                room.SendCompulsoryTriggerLog(ask_who, Name);
                int count = 0;
                List<int> suits = new List<int>();
                if (room.ContainsTag(Name)) suits = (List<int>)room.GetTag(Name);
                foreach (int id in move.Card_ids)
                {
                    int suit = (int)room.GetCard(id).Suit;
                    if (!suits.Contains(suit))
                    {
                        suits.Add(suit);
                        count++;
                    }
                }

                if (count > 0)
                    room.DrawCards(ask_who, count, Name);
            }


            return false;
        }
    }

    public class FenyinOlRecord : TriggerSkill
    {
        public FenyinOlRecord() : base("#fenyin_ol")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime };
        }

        public override int Priority => 1;

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && room.Current != null && move.To_place == Place.DiscardPile)
            {
                List<int> suits = new List<int>();
                if (room.ContainsTag("fenyin_ol")) suits = (List<int>)room.GetTag("fenyin_ol");
                foreach (int id in move.Card_ids)
                {
                    int suit = (int)room.GetCard(id).Suit;
                    if (!suits.Contains(suit))
                        suits.Add(suit);
                }

                room.SetTag("fenyin_ol", suits);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class Liji : TriggerSkill
    {
        public Liji() : base("liji")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseStart, TriggerEvent.EventPhaseChanging };
            view_as_skill = new LijiVS();
            skill_type = SkillType.Attack;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && room.Current != null && move.To_place == Place.DiscardPile)
            {
                int count = 0;
                if (room.ContainsTag(Name)) count = (int)room.GetTag(Name);
                count += move.Card_ids.Count;

                room.SetTag(Name, count);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive
                && room.ContainsTag(Name))
            {
                room.RemoveTag(Name);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.RoundStart && room.AliveCount() < 5)
            {
                player.SetMark(Name, 1);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            return new List<TriggerStruct>();
        }
    }

    public class LijiVS : OneCardViewAsSkill
    {
        public LijiVS() : base("liji")
        {
            filter_pattern = "..!";
        }

        public override bool IsEnabledAtPlay(Room room, Player player)
        {
            if (room.ContainsTag(Name) && room.GetTag(Name) is int count)
            {
                int number = 8;
                if (player.GetMark(Name) > 0) number = 4;
                if (count / number > player.UsedTimes(LijiCard.ClassName))
                    return true;
            }

            return false;
        }

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard lj = new WrappedCard(LijiCard.ClassName) { Skill = Name };
            lj.AddSubCard(card);
            return lj;
        }
    }

    public class LijiCard : SkillCard
    {
        public static string ClassName = "LijiCard";
        public LijiCard() : base(ClassName)
        {
            will_throw = true;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && to_select != Self;
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From;
            Player target = card_use.To[0];
            room.Damage(new DamageStruct("liji", player, target, 1));
        }
    }

    public class Zhiren : TriggerSkill
    {
        public Zhiren() : base("zhiren")
        {
            events.Add(TriggerEvent.CardUsed);
        }

        private Dictionary<string, int> counts = new Dictionary<string, int>
        {
            //basic
            { Slash.ClassName, 1 },
            { Jink.ClassName, 1 },
            { Peach.ClassName, 1 },
            { Analeptic.ClassName, 1 },
            { FireSlash.ClassName, 2 },
            { ThunderSlash.ClassName, 2 },

            //equip
            { CrossBow.ClassName, 4 },
            { DoubleSword.ClassName, 5 },
            { Spear.ClassName, 4 },
            { Fan.ClassName, 4 },
            { Triblade.ClassName, 5 },
            { Vine.ClassName, 2 },
            { SilverLion.ClassName, 4 },
            { "Jueying", 2 },
            { "Dilu", 2 },
            { "Zhuahuangfeidian", 4 },
            { "Chitu", 2 },
            { "Dayuan", 2 },
            { "Zixing", 2 },
            { "Jingfan", 2 },
            { "Hualiu", 2 },
            { ClassicBlade.ClassName, 5 },
            { ClassicWoodenOx.ClassName, 4 },
            { ClassicHalberd.ClassName, 4 },
            { PosionedDagger.ClassName, 4 },

            //trick
            { SavageAssault.ClassName, 4 },
            { ArcheryAttack.ClassName, 4 },
            { GodSalvation.ClassName, 4 },
            { AmazingGrace.ClassName, 4 },
            { Nullification.ClassName, 4 },
            { Snatch.ClassName, 4 },
            { Dismantlement.ClassName, 4 },
            { Collateral.ClassName, 4 },
            { ExNihilo.ClassName, 4 },
            { Duel.ClassName, 2 },
            { FireAttack.ClassName, 2 },
            { Indulgence.ClassName, 4 },
            { SupplyShortage.ClassName, 4 },
            { Lightning.ClassName, 2 },
            { IronChain.ClassName, 4 },
            { HoardUp.ClassName, 2 },
            { Reinforcement.ClassName, 2 },
            { GDFighttogether.ClassName, 4 },
            { HiddenDagger.ClassName, 4 },
        };

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardUseStruct use && !player.HasFlag(Name) && (player.Phase != PlayerPhase.NotActive || player.GetMark("yaner") > 0) && !use.Card.IsVirtualCard() && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            player.SetFlags(Name);
            if (data is CardUseStruct use)
            {
                if (!counts.TryGetValue(use.Card.Name, out int count))
                    count = 3;

                if (room.AskForSkillInvoke(player, Name, "@zhiren-view", info.SkillPosition))
                {
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);

                    List<int> ids = room.GetNCards(count, false);
                    LogMessage log = new LogMessage
                    {
                        Type = "$ViewDrawPile",
                        From = player.Name,
                        Card_str = string.Join("+", JsonUntity.IntList2StringList(ids))
                    };
                    room.SendLog(log, player);
                    log.Type = "$ViewDrawPile2";
                    log.Arg = count.ToString();
                    log.Card_str = null;
                    room.SendLog(log, new List<Player> { player });
                    room.AskForGuanxing(player, ids, Name, true, info.SkillPosition);
                }

                if (player.Alive && count > 1)
                {
                    List<Player> targets = new List<Player>();
                    string flag = "ej";
                    foreach (Player p in room.GetAlivePlayers())
                    {
                        if (RoomLogic.CanDiscard(room, player, p, flag) && p.GetCards(flag).Count > 0)
                            targets.Add(p);
                    }

                    if (targets.Count > 0)
                    {
                        player.SetFlags("zhiren_" + flag);
                        Player target = room.AskForPlayerChosen(player, targets, Name, string.Format("@zhiren-{0}", flag), true, true, info.SkillPosition);
                        player.SetFlags("-zhiren_" + flag);
                        if (target != null)
                        {
                            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                            int card_id = room.AskForCardChosen(player, target, flag, Name, false, HandlingMethod.MethodDiscard);
                            bool trick = room.GetCardPlace(card_id) == Place.PlaceDelayedTrick;
                            room.ThrowCard(card_id, trick ? null : target, player);
                            flag = flag.Replace(trick ? "j" : "e", string.Empty);
                        }
                    }
                    if (flag.Length == 1)
                    {
                        targets.Clear();
                        foreach (Player p in room.GetAlivePlayers())
                        {
                            if (RoomLogic.CanDiscard(room, player, p, flag) && p.GetCards(flag).Count > 0)
                                targets.Add(p);
                        }

                        if (targets.Count > 0)
                        {
                            player.SetFlags("zhiren_" + flag);
                            Player target = room.AskForPlayerChosen(player, targets, Name, string.Format("@zhiren-{0}", flag), true, true, info.SkillPosition);
                            player.SetFlags("-zhiren_" + flag);
                            if (target != null)
                            {
                                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                                int card_id = room.AskForCardChosen(player, target, flag, Name, false, HandlingMethod.MethodDiscard);
                                bool trick = room.GetCardPlace(card_id) == Place.PlaceDelayedTrick;
                                room.ThrowCard(card_id, trick ? null : target, player);
                            }
                        }
                    }
                }

                if (player.Alive && count > 2 && player.IsWounded() && room.AskForSkillInvoke(player, Name, "@zhiren-recover", info.SkillPosition))
                {
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    room.Recover(player);
                }

                if (player.Alive && count > 3 && room.AskForSkillInvoke(player, Name, "@zhiren-draw", info.SkillPosition))
                {
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    room.DrawCards(player, 3, Name);
                }
            }

            return false;
        }
    }

    public class Yaner : TriggerSkill
    {
        public Yaner() : base("yaner")
        {
            events = new List<TriggerEvent> { TriggerEvent.TurnStart, TriggerEvent.CardsMoveOneTime };
            skill_type = SkillType.Replenish;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.TurnStart && player.GetMark(Name) > 0)
                player.SetMark(Name, 0);
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.From != null && move.From.Alive && move.From.Phase == PlayerPhase.Play
                && move.From_places.Contains(Place.PlaceHand) && move.Is_last_handcard)
            {
                List<Player> jfs = RoomLogic.FindPlayersBySkillName(room, Name);
                foreach (Player p in jfs)
                    if (p != move.From && !p.HasFlag(Name))
                        triggers.Add(new TriggerStruct(Name, p));
            }
            return triggers;
        }
        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move && move.From.Alive)
            {
                move.From.SetFlags("yaner_target");
                bool invoke = room.AskForSkillInvoke(ask_who, Name, move.From, info.SkillPosition);
                move.From.SetFlags("-yaner_target");
                if (invoke)
                {
                    room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, ask_who.Name, ((CardsMoveOneTimeStruct)data).From.Name);
                    room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                    ask_who.SetFlags(Name);
                    return info;
                }
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardsMoveOneTimeStruct move && move.From.Alive)
            {
                List<Player> players = new List<Player> { move.From, ask_who };
                room.SortByActionOrder(ref players);
                Dictionary<Player, List<int>> draws = new Dictionary<Player, List<int>>();
                foreach (Player p in players)
                {
                    if (p.Alive)
                     draws.Add(p, room.DrawCards(p, new DrawCardStruct(2, ask_who, Name)));
                }

                if (ask_who.Alive && ask_who.GetMark(Name) == 0 && SameCards(room, ask_who, draws[ask_who]))
                    ask_who.SetMark(Name, 1);
                if (move.From.Alive && move.From.IsWounded() && SameCards(room, move.From, draws[move.From]))
                    room.Recover(move.From);
            }
            return false;
        }

        private bool SameCards(Room room, Player player, List<int> ids)
        {
            if (ids.Count == 2 && room.GetCardOwner(ids[0]) == player && room.GetCardOwner(ids[1]) == player
                && room.GetCardPlace(ids[0]) == Place.PlaceHand && room.GetCardPlace(ids[1]) == Place.PlaceHand)
            {
                WrappedCard card1 = room.GetCard(ids[0]);
                WrappedCard card2 = room.GetCard(ids[1]);
                if (Engine.GetFunctionCard(card1.Name).TypeID == Engine.GetFunctionCard(card2.Name).TypeID)
                {
                    room.ShowCards(player, ids, Name);
                    return true;
                }
            }
            return false;
        }
    }

    public class Zhukou : TriggerSkill
    {
        public Zhukou() : base("zhukou")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardUsed, TriggerEvent.Damage, TriggerEvent.EventPhaseStart, TriggerEvent.CardResponded, TriggerEvent.EventPhaseChanging };
            view_as_skill = new ZhukouVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardUsed && room.Current != null && player.GetMark(Name) == 0 && data is CardUseStruct use && !Engine.IsSkillCard(use.Card.Name))
                player.AddMark("zhukou_used");
            else if (triggerEvent == TriggerEvent.CardResponded && data is CardResponseStruct resp && resp.Use && room.Current != null && player.GetMark(Name) == 0)
                player.AddMark("zhukou_used");
            else if (triggerEvent == TriggerEvent.Damage && room.Current != null && room.Current.Phase == PlayerPhase.Play)
                player.AddMark(Name);
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change)
            {
                if (change.From == PlayerPhase.Play)
                {
                    foreach (Player p in room.GetAlivePlayers())
                        p.SetMark(Name, 0);
                }
                else if (change.To == PlayerPhase.NotActive)
                {
                    foreach (Player p in room.GetAlivePlayers())
                        p.SetMark("zhukou_used", 0);
                }
            }

            if (triggerEvent == TriggerEvent.Damage && player.Phase != PlayerPhase.NotActive)
                player.SetFlags(Name);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.Damage && room.Current != null && room.Current.Phase == PlayerPhase.Play && base.Triggerable(player, room)
                && player.GetMark(Name) == 1 && player.GetMark("zhukou_used") > 0)
                return new TriggerStruct(Name, player);
            else if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Finish && base.Triggerable(player, room) && !player.HasFlag(Name))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.Damage && room.AskForSkillInvoke(player, Name, "@zhukou-draw:::" + player.GetMark("zhukou_used").ToString(), info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                return info;
            }
            else if (triggerEvent == TriggerEvent.EventPhaseStart)
            {
                WrappedCard card = room.AskForUseCard(player, RespondType.Skill, "@@zhukou", string.Format("@zhukou-damage:::{0}", Math.Min(2, room.AliveCount() - 1)), null, -1, HandlingMethod.MethodUse, true, info.SkillPosition);
                if (card != null)
                {
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    return info;
                }
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (triggerEvent == TriggerEvent.Damage)
                room.DrawCards(player, player.GetMark("zhukou_used"), Name);
            else if (room.GetTag(Name) is List<Player> targets)
            {
                room.RemoveTag(Name);
                room.SortByActionOrder(ref targets);
                foreach (Player p in targets)
                {
                    if (player.Alive && p.Alive)
                        room.Damage(new DamageStruct(Name, player, p));
                }
            }

            return false;
        }
    }

    public class ZhukouVS : ZeroCardViewAsSkill
    {
        public ZhukouVS() : base("zhukou") { response_pattern = "@@zhukou"; }
        public override WrappedCard ViewAs(Room room, Player player)
        {
            return new WrappedCard(ZhukouCard.ClassName);
        }
    }

    public class ZhukouCard : SkillCard
    {
        public static string ClassName = "ZhukouCard";
        public ZhukouCard() : base(ClassName) { }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            int count = Math.Min(2, room.AliveCount() - 1);
            return targets.Count < count && Self != to_select;
        }
        public override bool TargetsFeasible(Room room, List<Player> targets, Player Self, WrappedCard card) => targets.Count == Math.Min(2, room.AliveCount() - 1);
        public override void OnUse(Room room, CardUseStruct card_use)
        {
            room.SetTag("zhukou", card_use.To);
        }
    }

    public class Mangqing : PhaseChangeSkill
    {
        public Mangqing() : base("mangqing")
        {
            frequency = Frequency.Wake;
            skill_type = SkillType.Recover;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Start && base.Triggerable(player, room) && player.GetMark(Name) == 0)
            {
                int count = 0;
                foreach (Player p in room.GetAlivePlayers())
                {
                    if (p.IsWounded())
                        count++;
                }
                if (count > player.Hp)
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
                player.MaxHp += 3;
                room.BroadcastProperty(player, "MaxHp");

                LogMessage log = new LogMessage
                {
                    Type = "$GainMaxHp",
                    From = player.Name,
                    Arg = "3"
                };
                room.SendLog(log);

                room.RoomThread.Trigger(TriggerEvent.MaxHpChanged, room, player);
                room.Recover(player, Math.Min(3, player.MaxHp - player.Hp));

                room.HandleAcquireDetachSkills(player, "-zhukou|yuyun", false);
            }

            return false;
        }
    }

    public class Yuyun : PhaseChangeSkill
    {
        public Yuyun() : base("yuyun")
        {
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Play && base.Triggerable(player, room) && player.MaxHp > 1)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool OnPhaseChange(Room room, Player player, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name);

            string pattern = "maxhp";
            if (player.Hp > 1) pattern = "hp+maxhp";
            string result = room.AskForChoice(player, Name, pattern, null, null, info.SkillPosition);
            int index = (result == "hp") ? 2 : 1;
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            if (result == "hp")
                room.LoseHp(player);
            else
                room.LoseMaxHp(player);

            if (player.Alive)
            {
                List<string> choices = new List<string> { "draw", "slash", "max", "full" };
                bool discard = false;
                foreach (Player p in room.GetOtherPlayers(player))
                {
                    if (!p.IsNude() && RoomLogic.CanDiscard(room, player, p, "he"))
                    {
                        discard = true;
                        break;
                    }
                }
                if (discard) choices.Insert(3, "discard");
                result = room.AskForChoice(player, Name, string.Join("+", choices), null, null, info.SkillPosition);
                DoChoice(room, player, result, info.SkillPosition);

                if (player.Alive && player.GetLostHp() > 1)
                {
                    choices.Remove(result);
                    result = room.AskForChoice(player, Name, string.Join("+", choices), null, null, info.SkillPosition);
                    DoChoice(room, player, result, info.SkillPosition);
                }
            }

            return false;
        }

        private void DoChoice(Room room, Player player, string choice, string position)
        {
            switch (choice)
            {
                case "draw":
                    room.DrawCards(player, 2, Name);
                    break;
                case "slash":
                    {
                        player.SetFlags("yuyun_slash");
                        Player victim = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), Name, "@yuyun-slash", false, true, position);
                        if (victim != null)
                        {
                            room.Damage(new DamageStruct(Name, player, victim));
                            if (victim.Alive)
                            {
                                victim.SetFlags("yuyun_victim");
                            }
                        }
                    }
                    break;
                case "max":
                    player.SetFlags("yuyun_max");
                    break;
                case "discard":
                    {
                        List<Player> targets = new List<Player>();
                        foreach (Player p in room.GetOtherPlayers(player))
                        {
                            if (!p.IsNude() && RoomLogic.CanGetCard(room, player, p, "hej"))
                                targets.Add(p);
                        }

                        if (targets.Count > 0)
                        {
                            Player target = room.AskForPlayerChosen(player, targets, Name, "@yuyun-disacard", false, true, position);
                            room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, target.Name);

                            int id = room.AskForCardChosen(player, target, "hej", Name, false, HandlingMethod.MethodGet);
                            room.ObtainCard(player,room.GetCard(id), new CardMoveReason(MoveReason.S_REASON_GOTCARD, player.Name, target.Name, Name, string.Empty), false);
                        }
                    }
                    break;
                case "full":
                    {
                        List<Player> targets = new List<Player>();
                        foreach (Player p in room.GetOtherPlayers(player))
                        {
                            if (p.HandcardNum < 5 && p.HandcardNum < p.MaxHp)
                                targets.Add(p);
                        }

                        if (targets.Count > 0)
                        {
                            player.SetFlags("yuyun_full");
                            Player target = room.AskForPlayerChosen(player, targets, Name, "@yuyun-draw", false, true, position);
                            player.SetFlags("-yuyun_full");
                            if (target != null)
                            {
                                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, target.Name);
                                int count = Math.Min(5 - target.HandcardNum, target.MaxHp - target.HandcardNum);
                                room.DrawCards(target, new DrawCardStruct(count, player, Name));
                            }
                        }
                    }
                    break;
            }
        }
    }

    public class YuyunMax : MaxCardsSkill
    {
        public YuyunMax() : base("#yuyun-max") { }
        public override int GetExtra(Room room, Player target)
        {
            return target.HasFlag("yuyun_max") ? 200 : 0;
        }
    }

    public class YuyunTar : TargetModSkill
    {
        public YuyunTar() : base("#yuyun-tar", false) { }

        public override bool CheckSpecificAssignee(Room room, Player from, Player to, WrappedCard card, string pattern)
        {
            return from.HasFlag("yuyun_slash") && to.HasFlag("yuyun_victim");
        }

        public override bool GetDistanceLimit(Room room, Player from, Player to, WrappedCard card, CardUseReason reason, string pattern)
        {
            return from.HasFlag("yuyun_slash") && to.HasFlag("yuyun_victim");
        }
    }

    public class Jinghui : ZeroCardViewAsSkill
    {
        public Jinghui() : base("jinghui")
        {
            skill_type = SkillType.Wizzard;
        }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(JinghuiCard.ClassName);

        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(JinghuiCard.ClassName) { Skill = Name };
    }

    public class JinghuiCard : SkillCard
    {
        public static string ClassName = "JinghuiCard";
        public JinghuiCard() : base(ClassName)
        {
            target_fixed = true;
            will_throw = false;
        }

        private List<int> GetAvailable(Room room, List<int> ids, Player from, Player to)
        {
            List<int> available = new List<int>();
            foreach (int id in ids)
            {
                WrappedCard card = room.GetCard(id);
                FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                if (fcard is EquipCard || fcard is Analeptic || fcard is ExNihilo || (fcard is Peach && from.IsWounded()))
                {
                    if (RoomLogic.IsProhibited(room, from, from, card) == null)
                        available.Add(id);
                }
                else if (fcard is Snatch && to.Alive && !to.IsAllNude() && RoomLogic.CanGetCard(room, from, to, "hej"))
                {
                    if (RoomLogic.IsProhibited(room, from, to, card) == null)
                        available.Add(id);
                }
                else if (fcard is Dismantlement && to.Alive && !to.IsAllNude() && RoomLogic.CanGetCard(room, from, to, "hej"))
                {
                    if (RoomLogic.IsProhibited(room, from, to, card) == null)
                        available.Add(id);
                }
                else if ((fcard is SupplyShortage || fcard is Indulgence) && to.Alive && to.JudgingAreaAvailable && !RoomLogic.PlayerContainsTrick(room, to, card.Name))
                {
                    if (RoomLogic.IsProhibited(room, from, to, card) == null)
                        available.Add(id);
                }
            }
            return available;
        }

        public override void Use(Room room, CardUseStruct card_use)
        {
            if (room.DrawPile.Count < 5) room.SwapPile();
            Player player = card_use.From;
            List<int> ids = new List<int>();
            List<string> cards = new List<string>();
            foreach (int id in room.DrawPile)
            {
                WrappedCard card = room.GetCard(id);
                FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                if (cards.Contains(card.Name)) continue;
                if (fcard is EquipCard || fcard is Peach || fcard is Analeptic || fcard is Snatch || fcard is Dismantlement || fcard is ExNihilo || fcard is SupplyShortage || fcard is Indulgence)
                {
                    ids.Add(id);
                    cards.Add(card.Name);
                }
                if (ids.Count >= 3)
                    break;
            }

            if (ids.Count > 0)
            {
                foreach (int id in ids)
                    room.MoveCardTo(room.GetCard(id), player, Place.PlaceTable, new CardMoveReason(MoveReason.S_REASON_TURNOVER, player.Name, "jinghui", null), false);

                if (player.Alive)
                {
                    Player target = room.AskForPlayerChosen(player, room.GetOtherPlayers(player), "jinghui", "@jinghui", false, false, card_use.Card.SkillPosition);
                    List<int> can_use = GetAvailable(room, ids, target, player);
                    if (can_use.Count > 0)
                    {
                        List<string> patterns = new List<string>();
                        foreach (int id in can_use)
                            patterns.Add(id.ToString());

                        List<int> result = room.NotifyChooseCards(target, ids, "jinghui", 1, 1, "@jinghui-from:" + player.Name, string.Join("#", patterns), string.Empty);
                        int to_use = result[0];
                        ids.Remove(to_use);
                        WrappedCard card = room.GetCard(to_use);
                        FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                        if (fcard is EquipCard || fcard is Analeptic || fcard is ExNihilo || fcard is Peach)
                            room.UseCard(new CardUseStruct(card, target, new List<Player>()), true, true);
                        else
                            room.UseCard(new CardUseStruct(card, target, player), true, true);
                    }

                    while (player.Alive && ids.Count > 0)
                    {
                        can_use = GetAvailable(room, ids, player, target);
                        if (can_use.Count > 0)
                        {
                            List<string> patterns = new List<string>();
                            foreach (int id in can_use)
                                patterns.Add(id.ToString());

                            List<int> result = room.NotifyChooseCards(player, ids, "jinghui", 1, 0, "@jinghui-to:" + target.Name, string.Join("#", patterns), card_use.Card.SkillPosition);
                            if (result.Count == 1)
                            {
                                int to_use = result[0];
                                ids.Remove(to_use);
                                WrappedCard card = room.GetCard(to_use);
                                FunctionCard fcard = Engine.GetFunctionCard(card.Name);
                                if (fcard is EquipCard || fcard is Analeptic || fcard is ExNihilo || fcard is Peach)
                                    room.UseCard(new CardUseStruct(card, player, new List<Player>()), true, true);
                                else
                                    room.UseCard(new CardUseStruct(card, player, target), true, true);
                            }
                            else
                                break;
                        }
                        else
                            break;
                    }
                }

                if (ids.Count > 0)
                {
                    foreach (int id in ids)
                        room.MoveCardTo(room.GetCard(id), null, Place.DiscardPile, new CardMoveReason(MoveReason.S_REASON_NATURAL_ENTER, player.Name, "jinghui", null), false);
                }
            }
        }
    }

    public class Qingman : TriggerSkill
    {
        public Qingman() : base("qingman")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Replenish;
            frequency = Frequency.Compulsory;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> result = new List<TriggerStruct>();
            if (player != null && player.Alive && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                int count = 0;
                for (int i = 0; i < 5; i++)
                    if (!player.EquipIsBaned(i) && !player.HasEquip(i)) count++;

                if (count > 0)
                    foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                        if (p.HandcardNum < count)
                            result.Add(new TriggerStruct(Name, p));
            }

            return result;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name, true);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);

            int count = 0;
            for (int i = 0; i < 5; i++)
                if (!player.EquipIsBaned(i) && !player.HasEquip(i)) count++;

            room.DrawCards(ask_who, count - ask_who.HandcardNum, Name);
            return false;
        }
    }

    public class JiqiaoSY : TriggerSkill
    {
        public JiqiaoSY() : base("jiqiao_sy")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.EventPhaseChanging, TriggerEvent.CardUsed, TriggerEvent.EventLoseSkill };
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (((triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.From == PlayerPhase.Play) ||
                (triggerEvent == TriggerEvent.EventLoseSkill && data is InfoStruct info && info.Info == Name)) && player.Alive && player.GetPile(Name).Count > 0)
            {
                room.ClearOnePrivatePile(player, Name);
            }
            else if (triggerEvent == TriggerEvent.CardUsed && player.GetPile(Name).Count > 0)
            {
                List<int> maps = player.GetPile(Name);
                int card_id;
                if (maps.Count == 1)
                    card_id = maps[0];
                else
                {
                    room.FillAG(Name, maps, player, null, null, "@jiqiao_sy");
                    card_id = room.AskForAG(player, maps, false, Name);
                    room.ClearAG(player);
                }
                room.ClearAG(player);

                List<int> ids = new List<int> { card_id };
                room.ObtainCard(player, ref ids, new CardMoveReason(MoveReason.S_REASON_EXCHANGE_FROM_PILE, player.Name, Name, string.Empty), false);

                maps.Remove(card_id);

                int red = 0, black = 0;
                foreach (int id in maps)
                {
                    if (WrappedCard.IsBlack(room.GetCard(id).Suit))
                        black++;
                    else
                        red++;
                }

                if (red == black)
                {
                    if (player.IsWounded()) room.Recover(player);
                }
                else
                    room.LoseHp(player);
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && base.Triggerable(player, room) && player.Phase == PlayerPhase.Play)
                return new TriggerStruct(Name, player);
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

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<int> ids = room.GetNCards(player.MaxHp, true);
            room.AddToPile(player, Name, ids, true);

            return false;
        }
    }

    public class XiongyiSy : TriggerSkill
    {
        public XiongyiSy() : base("xiongyi_sy")
        {
            events = new List<TriggerEvent> { TriggerEvent.Dying, TriggerEvent.GameStart };
            frequency = Frequency.Limited;
            limit_mark = "@xiongyi_sy";
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.GameStart)
                room.HandleUsedGeneral("xushi");
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.Dying && base.Triggerable(player, room) && player.GetMark(limit_mark) > 0)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(player, Name, data, info.SkillPosition))
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
            bool xuhsi = false;
            foreach (Player p in room.GetOtherPlayers(player))
            {
                if (p.ActualGeneral1 == "xushi")
                {
                    xuhsi = true;
                    break;
                }
            }

            if (!xuhsi)
            {
                int count = Math.Max(0, 3 - player.Hp);
                if (count > 0) room.Recover(player, count);
                if (player.Alive)
                {
                    string from_general = player.ActualGeneral1;
                    if (!from_general.Contains("sujiang"))
                    {
                        room.DoAnimate(AnimateType.S_ANIMATE_REMOVE, player.Name, true.ToString());
                        room.HandleUsedGeneral("-" + from_general);
                    }

                    //room.HandleUsedGeneral("guansuo");
                    player.ActualGeneral1 = player.General1 = "xushi";
                    player.HeadSkinId = 0;
                    player.PlayerGender = Gender.Female;
                    player.Kingdom = "wu";
                    room.BroadcastProperty(player, "Kingdom");
                    room.BroadcastProperty(player, "HeadSkinId");
                    room.BroadcastProperty(player, "PlayerGender");
                    room.NotifyProperty(room.GetClient(player), player, "ActualGeneral1");
                    room.BroadcastProperty(player, "General1");

                    List<string> skills = player.GetSkills(true, false);
                    foreach (string skill in skills)
                    {
                        Skill _s = Engine.GetSkill(skill);
                        if (_s != null && !_s.Attached_lord_skill)
                            room.DetachSkillFromPlayer(player, skill, false, player.GetAcquiredSkills().Contains(skill), true);
                    }

                    foreach (string skill in Engine.GetGeneralRelatedSkills("xushi", room.Setting.GameMode))
                        room.AddSkill2Game(skill);

                    foreach (string skill_name in Engine.GetGeneralSkills("xushi", room.Setting.GameMode, true))
                    {
                        room.AddSkill2Game(skill_name);
                        room.AddPlayerSkill(player, skill_name);
                    }

                    room.AddSkill2Game("wenguavs");

                    foreach (Player p in room.GetOtherPlayers(player))
                        room.HandleAcquireDetachSkills(p, "wenguavs", true);

                    room.SendPlayerSkillsToOthers(player);
                    room.FilterCards(player, player.GetCards("he"), true);
                }
            }
            else
            {
                int count = Math.Max(0, 1 - player.Hp);
                if (count > 0) room.Recover(player, count);
                if (player.Alive) room.LoseMaxHp(player);
                if (player.Alive)
                {
                    List<string> skills = new List<string> { "yinghun_sunce", "yingzi_sunce" };
                    room.HandleAcquireDetachSkills(player, skills);
                }
            }

            return false;
        }
    }


    public class YusuiClassic : TriggerSkill
    {
        public YusuiClassic() : base("yusui_classic")
        {
            events.Add(TriggerEvent.TargetConfirmed);
            skill_type = SkillType.Masochism;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardUseStruct use && use.From != null && use.From != player && !Engine.IsSkillCard(use.Card.Name)
                && WrappedCard.IsBlack(use.Card.Suit) && !player.HasFlag(Name) && base.Triggerable(player, room) && player.Hp > 0)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use && room.AskForSkillInvoke(player, Name, use.From, info.SkillPosition))
            {
                room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, use.From.Name);
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                player.SetFlags(Name);
                room.LoseHp(player);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.Alive && data is CardUseStruct use && use.From.Alive)
            {
                List<string> choices = new List<string>();
                if (!use.From.IsKongcheng())
                    choices.Add("discard");
                if (use.From.Hp > player.Hp)
                    choices.Add("losehp");

                if (choices.Count > 0)
                {
                    string choice = room.AskForChoice(player, Name, string.Join("+", choices), new List<string> { "@to-player:" + use.From.Name }, use.From, info.SkillPosition);
                    if (choice == "discard")
                    {
                        int count = Math.Min(use.From.HandcardNum, use.From.MaxHp);
                        room.AskForDiscard(use.From, Name, count, count, false, false, string.Format("@yusui:{0}::{1}", player.Name, count), false);
                    }
                    else
                        room.LoseHp(use.From, use.From.Hp - player.Hp);
                }
            }

            return false;
        }
    }

    public class BoyanClassic : TriggerSkill
    {
        public BoyanClassic() : base("boyan_classic")
        {
            events.Add(TriggerEvent.EventPhaseChanging);
            view_as_skill = new BoyanVS();
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                    RoomLogic.RemovePlayerCardLimitation(p, Name);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data) => new List<TriggerStruct>();
    }


    public class BoyanVS : ZeroCardViewAsSkill
    {
        public BoyanVS() : base("boyan_classic") { }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(BoyanCCard.ClassName);
        public override WrappedCard ViewAs(Room room, Player player) => new WrappedCard(BoyanCCard.ClassName) { Skill = Name };
    }

    public class BoyanCCard : SkillCard
    {
        public static string ClassName = "BoyanCCard";
        public BoyanCCard() : base(ClassName) { }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card) => to_select != Self && targets.Count == 0;
        public override void Use(Room room, CardUseStruct card_use)
        {
            Player player = card_use.From, target = card_use.To[0];
            int count = Math.Min(5 - target.HandcardNum, target.MaxHp - target.HandcardNum);
            if (count > 0) room.DrawCards(target, new DrawCardStruct(count, player, "boyan_classic"));

            if (target.Alive)
            {
                string pattern = ".|.|.|hand";
                RoomLogic.SetPlayerCardLimitation(target, "boyan_classic", "use,response", pattern, true);
            }
        }
    }

    public class Renzheng : TriggerSkill
    {
        public Renzheng() : base("renzheng")
        {
            events.Add(TriggerEvent.DamageModified);
            skill_type = SkillType.Replenish;
            frequency = Frequency.Compulsory;
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                triggers.Add(new TriggerStruct(Name, p));
            return triggers;
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            room.DrawCards(ask_who, 2, Name);
            return false;
        }
    }

    public class Jinjian : TriggerSkill
    {
        public Jinjian() : base("jinjian")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageCaused, TriggerEvent.DamageInflicted };
            skill_type = SkillType.Wizzard;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && !player.HasFlag(Name))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
            {
                string prompt = triggerEvent == TriggerEvent.DamageCaused
                    ? string.Format("@jinjian-damage:{0}::{1}", damage.To.Name, damage.Damage) : string.Format("@jinjian-damaged:::{0}:{1}", damage.Card != null ? damage.Card.Name : damage.Reason, damage.Damage);
                if (room.AskForSkillInvoke(player, Name, prompt, info.SkillPosition))
                {
                    player.SetFlags(Name);
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    return info;
                }
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            DamageStruct damage = (DamageStruct)data;
            if (triggerEvent == TriggerEvent.DamageCaused)
            {
                player.SetFlags("jinjian_damage_pre");
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
                player.SetFlags("jinjian_damaged_pre");

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
            }

            return false;
        }
    }

    public class JinjianFlag : TriggerSkill
    {
        public JinjianFlag() : base("#jinjian-flag")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageCaused, TriggerEvent.DamageInflicted };
        }

        public override int Priority => 1;

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (player.Alive)
            {
                if (triggerEvent == TriggerEvent.DamageCaused && player.HasFlag("jinjian_damage_pre"))
                {
                    player.SetFlags("-jinjian_damage_pre");
                    player.SetFlags("jinjian_damage");
                }
                else if (triggerEvent == TriggerEvent.DamageInflicted && player.HasFlag("jinjian_damaged_pre"))
                {
                    player.SetFlags("-jinjian_damaged_pre");
                    player.SetFlags("jinjian_damaged");
                }
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data) => new List<TriggerStruct>();
    }

    public class JinjianEffect : TriggerSkill
    {
        public JinjianEffect() : base("#jinjian")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageCaused, TriggerEvent.DamageInflicted };
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Alive)
            {
                if (triggerEvent == TriggerEvent.DamageCaused && player.HasFlag("jinjian_damage"))
                    return new TriggerStruct(Name, player);
                else if (triggerEvent == TriggerEvent.DamageInflicted && player.HasFlag("jinjian_damaged"))
                    return new TriggerStruct(Name, player);
            }

            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            DamageStruct damage = (DamageStruct)data;
            room.SendCompulsoryTriggerLog(player, "jinjian");

            if (triggerEvent == TriggerEvent.DamageCaused)
            {
                player.SetFlags("-jinjian_damage");
                LogMessage log = new LogMessage
                {
                    Type = "#ReduceDamage2",
                    From = player.Name,
                    To = new List<string> { damage.To.Name },
                    Arg = Name,
                    Arg2 = "1"
                };
                room.SendLog(log);
                damage.Damage--;
                if (damage.Damage < 1) return true;
                data = damage;
            }
            else
            {
                player.SetFlags("-jinjian_damaged");
                LogMessage log = new LogMessage
                {
                    Type = "#AddDamaged",
                    From = player.Name,
                    Arg = Name,
                    Arg2 = (++damage.Damage).ToString()
                };
                room.SendLog(log);
                data = damage;
            }

            return false;
        }
    }

    public class Chongxing : TriggerSkill
    {
        public Chongxing() : base("chongxing")
        {
            events.Add(TriggerEvent.RoundStart);
            skill_type = SkillType.Replenish;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            foreach (Player p in room.GetAlivePlayers())
                p.RemoveTag(Name);
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                if (p.Hp > 0) triggers.Add(new TriggerStruct(Name, p));
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<string> choices = new List<string>();
            for (int i = 0; i <= ask_who.Hp; i++)
                choices.Add(i.ToString());
            choices.Add("cancel");

            string choice = room.AskForChoice(ask_who, Name, string.Join("+", choices), new List<string> { "@chongxing-draw" }, null, info.SkillPosition);
            if (choice != "cancel")
            {
                int count = int.Parse(choice);
                ask_who.SetMark(Name, count);
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                room.NotifySkillInvoked(ask_who, Name);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int count = ask_who.GetMark(Name);
            int max = ask_who.Hp - count;
            room.DrawCards(ask_who, count, Name);
            if (ask_who.Alive && max > 0)
            {
                List<int> ids = room.AskForExchange(ask_who, Name, max, 0, string.Format("@chongxing:::{0}", max), string.Empty, ".", info.SkillPosition);
                if (ids.Count > 0)
                {
                    ask_who.SetTag(Name, ids);
                    room.ShowCards(ask_who, ids, Name);
                }
            }

            return false;
        }
    }

    public class ChongxingEffect : TriggerSkill
    {
        public ChongxingEffect() : base("#chongxing")
        {
            events.Add(TriggerEvent.CardsMoveOneTime);
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardsMoveOneTimeStruct move && move.From != null && move.From.Alive && move.From_places.Contains(Place.PlaceHand) && move.From.ContainsTag("chongxing")
                && move.From.GetTag("chongxing") is List<int> ids)
            {
                for (int i = 0; i < move.Card_ids.Count; i++)
                    if (ids.Contains(move.Card_ids[i]) && move.From_places[i] == Place.PlaceHand)
                        return new TriggerStruct(Name, move.From);
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, "chongxing");
            int count = 0;
            if (data is CardsMoveOneTimeStruct move && ask_who.GetTag("chongxing") is List<int> ids)
            {
                for (int i = 0; i < move.Card_ids.Count; i++)
                {
                    if (ids.Contains(move.Card_ids[i]) && move.From_places[i] == Place.PlaceHand)
                    {
                        count += 2;
                        ids.Remove(move.Card_ids[i]);
                    }
                }

                if (ids.Count > 0)
                    ask_who.SetTag("chongxing", ids);
                else
                    ask_who.RemoveTag("chongxing");

                room.DrawCards(ask_who, count, "chongxing");
            }

            return false;
        }
    }

    public class Liunian : TriggerSkill
    {
        public Liunian() : base("liunian")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging, TriggerEvent.SwapPile };
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Masochism;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.SwapPile)
            {
                foreach (Player p in room.GetAlivePlayers())
                    p.AddMark(Name);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                {
                    if (p.GetMark(Name) > p.GetMark("liunian_invoke") && p.GetMark("liunian_invoke") < 2)
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }
            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            ask_who.AddMark("liunian_invoke");
            
            if (ask_who.GetMark("liunian_invoke") == 1)
            {
                ask_who.MaxHp++;
                room.BroadcastProperty(ask_who, "MaxHp");

                LogMessage log = new LogMessage
                {
                    Type = "$GainMaxHp",
                    From = ask_who.Name,
                    Arg = "1"
                };
                room.SendLog(log);

                room.RoomThread.Trigger(TriggerEvent.MaxHpChanged, room, ask_who);
            }
            else if (ask_who.IsWounded())
                room.Recover(ask_who);

            return false;
        }
    }

    public class LiunianMax : MaxCardsSkill
    {
        public LiunianMax() : base("#liunian") { }
        public override int GetExtra(Room room, Player target) => target.GetMark("liunian_invoke") > 1 ? 10 : 0;
    }

    public class YuanyuZY : OneCardViewAsSkill
    {
        public YuanyuZY() : base("yuanyu_zy")
        {
            filter_pattern = ".";
        }
        public override bool IsEnabledAtPlay(Room room, Player player) => !player.HasUsed(YuanyuZYCard.ClassName);
        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            WrappedCard yy = new WrappedCard(YuanyuZYCard.ClassName) { Skill = Name };
            yy.AddSubCard(card);
            return yy;
        }
    }

    public class YuanyuZYCard : SkillCard
    {
        public static string ClassName = "YuanyuZYCard";
        public YuanyuZYCard() : base(ClassName) { will_throw = false; }
        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card)
        {
            return targets.Count == 0 && to_select != Self;
        }
        public override void OnUse(Room room, CardUseStruct card_use)
        {
            List<int> ids = new List<int>(card_use.Card.SubCards);
            room.AddToPile(card_use.From, "yuanyu_zy", ids);
            Player target = card_use.To[0];
            if (card_use.From.Alive && target.Alive)
            {
                List<string> names = target.ContainsTag("yuanyu_zy") ? (List<string>)target.GetTag("yuanyu_zy") : new List<string>();
                if (!names.Contains(card_use.From.Name)) names.Add(card_use.From.Name);
                target.SetTag("yuanyu_zy", names);
                room.SetPlayerStringMark(target, "yuanyu_zy", string.Empty);
            }
        }
    }
    public class YuanyuZYEffect : TriggerSkill
    {
        public YuanyuZYEffect() : base("#yuanyu_zy")
        {
            events.Add(TriggerEvent.Damage);
            frequency = Frequency.Compulsory;
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (player.Alive && player.ContainsTag("yuanyu_zy") && player.GetTag("yuanyu_zy") is List<string> names && !player.IsKongcheng())
            {
                foreach (string player_name in names)
                {
                    Player target = room.FindPlayer(player_name);
                    if (target != null && RoomLogic.PlayerHasSkill(room, target, "yuanyu_zy"))
                        triggers.Add(new TriggerStruct(Name, player, target));
                }
            }
            return triggers;
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (!ask_who.IsKongcheng())
            {
                List<int> ids = room.AskForExchange(ask_who, Name, 1, 1, "@yuanyu_zy:" + player.Name, string.Empty, ".", string.Empty);
                if (ids.Count == 0) ids.Add(ask_who.GetCards("h")[0]);
                room.AddToPile(player, "yuanyu_zy", ids);
            }

            return false;
        }
    }

    public class Xiyan : TriggerSkill
    {
        public Xiyan() : base("xiyan")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Replenish;
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive && player != null)
                player.SetMark(Name, 0);
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardsMoveOneTime && data is CardsMoveOneTimeStruct move && move.To_place == Place.PlaceSpecial && move.To_pile_name == "yuanyu_zy" && base.Triggerable(move.To, room)
                && move.To.GetPile("yuanyu_zy").Count > 0)
            {
                List<WrappedCard.CardSuit> suits = new List<WrappedCard.CardSuit>();
                foreach (int id in move.To.GetPile("yuanyu_zy"))
                {
                    WrappedCard card = room.GetCard(id);
                    if (!suits.Contains(card.Suit)) suits.Add(card.Suit);
                    if (suits.Count == 4) break;
                }

                if (suits.Count == 4) return new TriggerStruct(Name, move.To);
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(ask_who, Name);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
            List<int> ids = ask_who.GetPile("yuanyu_zy");
            room.ObtainCard(ask_who, ref ids, new CardMoveReason(MoveReason.S_REASON_REMOVE_FROM_PILE, ask_who.Name, Name, string.Empty));

            foreach (Player p in room.GetOtherPlayers(ask_who))
            {
                if (p.ContainsTag("yuanyu_zy") && p.GetTag("yuanyu_zy") is List<string> names)
                {
                    names.RemoveAll(t => t == ask_who.Name);
                    if (names.Count == 0)
                    {
                        p.RemoveTag("yuanyu_zy");
                        room.RemovePlayerStringMark(p, "yuanyu_zy");
                    }
                    else
                        p.SetTag("yuanyu_zy", names);
                }
            }

            if (ask_who.Alive && room.Current != null && room.Current.Phase != PlayerPhase.NotActive)
            {
                LogMessage log = new LogMessage("#hancard_max");
                log.From = room.Current.Name;
                if (room.Current == ask_who)
                {
                    ask_who.AddMark(Name);
                    log.Arg = "+4";
                }
                else
                {
                    room.Current.AddMark(Name, -1);
                    log.Arg = "-4";
                }

                room.SendLog(log);
            }

            return false;
        }
    }

    public class XiyanMax : MaxCardsSkill
    {
        public XiyanMax() : base("#xiyan") { }
        public override int GetExtra(Room room, Player target) => target.GetMark("xiyan") * 4;
    }

    public class XiyanTar : TargetModSkill
    {
        public XiyanTar() : base("#xiyan-tar", false) { pattern = "."; }
        public override bool CheckSpecificAssignee(Room room, Player from, Player to, WrappedCard card, string pattern) => from.GetMark("xiyan") > 0;
    }

    public class XiyanPro : ProhibitSkill
    {
        public XiyanPro() : base("#xiyan-pro") { }
        public override bool IsProhibited(Room room, Player from, Player to, WrappedCard card, List<Player> others = null) => from != null && card != null && Engine.GetFunctionCard(card.Name) is BasicCard ? from.GetMark("xiyan") < 0 : false;
    }

    public class Chenjian : TriggerSkill
    {
        public Chenjian() : base("chenjian")
        {
            events.Add(TriggerEvent.EventPhaseStart);
            view_as_skill = new ChenjianVS();
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.Phase == PlayerPhase.Start)
                return new TriggerStruct(Name, player);
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

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int count = Math.Min(5, player.GetMark(Name) + 3);
            List<int> ids = room.GetNCards(count);

            foreach (int id in ids)
            {
                WrappedCard card = room.GetCard(id);
                room.MoveCardTo(card, player, Place.PlaceTable, new CardMoveReason(MoveReason.S_REASON_TURNOVER, player.Name, Name, null), false);
            }

            bool all = false;
            while (player.Alive && ids.Count > 0)
            {
                bool use = !player.HasFlag("chenjian_use");
                bool discard = !player.HasFlag("chenjian_discard") && !player.IsNude() && RoomLogic.CanDiscard(room, player, player, "he");
                player.PileChange("#chenjian", ids);
                string prompt = string.Empty;
                if (use && discard)
                    prompt = "@chenjian-all";
                else if (use)
                    prompt = "@chenjian-use";
                else if (discard)
                    prompt = "@chenjian-discard";
                else
                    break;

                player.Piles["#chenjian"] = new List<int>(ids);
                WrappedCard card = room.AskForUseCard(player, RespondType.Skill, "@@chenjian", prompt, null, -1, HandlingMethod.MethodUse, true, info.SkillPosition);
                player.Piles["#chenjian"].Clear();
                if (card != null)
                {
                    if (Engine.IsSkillCard(card.Name))
                    {
                        player.SetFlags("chenjian_discard");
                        Player target = room.FindPlayer((string)player.GetTag(Name));
                        player.RemoveTag(Name);
                        room.DoAnimate(AnimateType.S_ANIMATE_INDICATE, player.Name, target.Name);
                        WrappedCard.CardSuit suit = (WrappedCard.CardSuit)player.GetMark("chenjian_suit");
                        room.ThrowCard(card.GetEffectiveId(), player, null, Name);
                        if (target.Alive)
                        {
                            List<int> get = new List<int>();
                            foreach (int id in ids)
                                if (room.GetCard(id).Suit == suit) get.Add(id);

                            ids.RemoveAll(t => get.Contains(t));
                            if (get.Count > 0)
                                room.ObtainCard(target, ref get, new CardMoveReason(MoveReason.S_REASON_RECYCLE, player.Name, target.Name, Name, string.Empty));
                        }
                    }
                    else
                    {
                        if (player.Alive) player.SetFlags("chenjian_use");
                        ids.Remove(card.GetEffectiveId());
                    }
                }
                else
                {
                    break;
                }
            }
            if (ids.Count > 0)
                room.MoveCards(new List<CardsMoveStruct> { new CardsMoveStruct(ids, null, Place.DiscardPile, new CardMoveReason(MoveReason.S_REASON_NATURAL_ENTER, null, Name, null)) }, true);

            if (player.HasFlag("chenjian_use") && player.HasFlag("chenjian_discard")) all = true;
            if (player.Alive && all)
            {
                if (player.GetMark(Name) < 2) player.AddMark(Name);
                if (player.HandcardNum > 0)
                {
                    CardMoveReason reason = new CardMoveReason(MoveReason.S_REASON_RECAST, player.Name)
                    {
                        SkillName = Name
                    };

                    List<int> hands = player.GetCards("h");
                    CardsMoveStruct move = new CardsMoveStruct(hands, player, Place.PlaceTable, reason)
                    {
                        To_pile_name = string.Empty,
                        From = player.Name
                    };
                    List<CardsMoveStruct> moves = new List<CardsMoveStruct> { move };
                    room.MoveCardsAtomic(moves, true);

                    List<int> table_cardids = room.GetCardIdsOnTable(hands);
                    if (table_cardids.Count > 0)
                    {
                        CardsMoveStruct move2 = new CardsMoveStruct(table_cardids, player, null, Place.PlaceTable, Place.DiscardPile, reason);
                        room.MoveCardsAtomic(new List<CardsMoveStruct>() { move2 }, true);
                    }

                    room.DrawCards(player, hands.Count, "recast");
                }
            }

            return false;
        }
    }

    public class ChenjianVS : OneCardViewAsSkill
    {
        public ChenjianVS() : base("chenjian")
        {
            expand_pile = "#chenjian";
            response_pattern = "@@chenjian";
        }
        public override bool ViewFilter(Room room, WrappedCard to_select, Player player)
        {
            if (!player.HasFlag("chenjian_use") && player.GetPile(expand_pile).Contains(to_select.Id)) return true;
            if (!player.HasFlag("chenjian_discard") && room.GetCardPlace(to_select.Id) != Place.PlaceTable && RoomLogic.CanDiscard(room, player, player, to_select.Id)) return true;
            return false;
        }

        public override WrappedCard ViewAs(Room room, WrappedCard card, Player player)
        {
            if (player.GetPile(expand_pile).Contains(card.Id))
                return card;
            else
            {
                WrappedCard cj = new WrappedCard(ChenjianCard.ClassName);
                cj.AddSubCard(card);
                return cj;
            }
        }
    }

    public class ChenjianCard : SkillCard
    {
        public static string ClassName = "ChenjianCard";
        public ChenjianCard() : base(ClassName)
        {
            will_throw = false;
        }

        public override bool TargetFilter(Room room, List<Player> targets, Player to_select, Player Self, WrappedCard card) => targets.Count == 0;
        public override void OnUse(Room room, CardUseStruct card_use)
        {
            WrappedCard.CardSuit suit = room.GetCard(card_use.Card.GetEffectiveId()).Suit;
            card_use.From.SetMark("chenjian_suit", (int)suit);
            card_use.From.SetTag("chenjian", card_use.To[0].Name);
        }
    }

    public class Xixiu : TriggerSkill
    {
        public Xixiu() : base("xixiu")
        {
            events.Add(TriggerEvent.TargetConfirmed);
            frequency = Frequency.Compulsory;
            skill_type = SkillType.Replenish;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (base.Triggerable(player, room) && player.GetEquips().Count > 0 && data is CardUseStruct use && (int)use.Card.Suit < 4 && use.From != null && use.From != player)
            {
                foreach (int id in player.GetEquips())
                {
                    if (room.GetCard(id).Suit == use.Card.Suit)
                        return new TriggerStruct(Name, player);
                }
            }
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

    public class XixiuFix : FixCardSkill
    {
        public XixiuFix() : base("#xixiu") { }

        public override bool IsCardFixed(Room room, Player from, Player to, string flags, HandlingMethod method)
        {
            if (to != null && from != null && from != to && to.GetEquips().Count == 1 && flags == "e" && method == HandlingMethod.MethodDiscard && RoomLogic.PlayerHasSkill(room, to, "xixiu"))
                return true;

            return false;
        }
    }

    public class Tongli : TriggerSkill
    {
        public Tongli() : base("tongli")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseChanging, TriggerEvent.CardUsedAnnounced, TriggerEvent.CardResponded };
            skill_type = SkillType.Wizzard;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.CardUsedAnnounced && player != null && player.Alive && player.Phase == PlayerPhase.Play && data is CardUseStruct use && !Engine.IsSkillCard(use.Card.Name))
                player.AddMark(Name);
            else if (triggerEvent == TriggerEvent.CardResponded && player != null && player.Alive && player.Phase == PlayerPhase.Play && data is CardResponseStruct resp && resp.Use)
                player.AddMark(Name);
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.From == PlayerPhase.Play)
                player.SetMark(Name, 0);
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.CardUsedAnnounced && base.Triggerable(player, room) && player.Phase == PlayerPhase.Play && !player.IsKongcheng()
                && player.GetMark(Name) <= 4 && data is CardUseStruct use && use.To.Count > 0 && use.Card.GetSkillName() != Name)
            {
                FunctionCard fcard = Engine.GetFunctionCard(use.Card.Name);
                if (fcard is BasicCard || fcard.IsNDTrick())
                {
                    List<WrappedCard.CardSuit> suits = new List<WrappedCard.CardSuit>();
                    foreach (int id in player.GetCards("h"))
                    {
                        WrappedCard.CardSuit suit = room.GetCard(id).Suit;
                        if (!suits.Contains(suit))
                        {
                            suits.Add(suit);
                            if (suits.Count == 4) break;
                        }
                    }
                    if (suits.Count == player.GetMark(Name))
                        return new TriggerStruct(Name, player);
                }
            }
            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is CardUseStruct use)
            {
                string prompt = string.Format("@tongli:::{0}:{1}", use.Card.Name, player.GetMark(Name));
                if (room.AskForSkillInvoke(player, Name, prompt, info.SkillPosition))
                {
                    room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                    List<int> counts = room.ContainsTag(Name) ? (List<int>)room.GetTag(Name) : new List<int>();
                    counts.Add(player.GetMark(Name));
                    room.SetTag(Name, counts);
                    use.Card.SetFlags(Name);
                    return info;
                }
            }

            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info) => false;
    }

    public class TongliEffect : TriggerSkill
    {
        public TongliEffect() : base("#tongli")
        {
            events.Add(TriggerEvent.CardFinished);
            frequency = Frequency.Compulsory;
        }
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardUseStruct use && player.Alive && use.Card.HasFlag("tongli") && use.To.Count > 0)
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag("tongli") is List<int> counts && data is CardUseStruct use)
            {
                int count = counts[counts.Count - 1];
                counts.RemoveAt(counts.Count - 1);
                room.SetTag("tongli", counts);

                while (count > 0 && player.Alive)
                {
                    count--;
                    WrappedCard card = new WrappedCard(use.Card.Name) { Skill = "_tongli" };
                    List<Player> targets = new List<Player>();
                    foreach (Player p in use.To)
                        if (p.Alive && RoomLogic.IsProhibited(room, player, p, card) == null)
                            targets.Add(p);

                    if (targets.Count == use.To.Count)
                        room.UseCard(new CardUseStruct(card, player, targets, false), true, true);
                    else
                        break;
                }
            }
            return false;
        }
    }

    public class Shezhang : TriggerSkill
    {
        public Shezhang() : base("shezhang")
        {
            events = new List<TriggerEvent> { TriggerEvent.RoundStart, TriggerEvent.Dying };
            skill_type = SkillType.Replenish;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.RoundStart)
                foreach (Player p in room.GetAlivePlayers())
                {
                    p.SetMark(Name, 0);
                }
        }
        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.Dying)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                {
                    if (p.GetMark(Name) == 0 && (p == player || p.Phase != PlayerPhase.NotActive))
                        triggers.Add(new TriggerStruct(Name, p));
                }
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.AskForSkillInvoke(ask_who, Name, data, info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                ask_who.AddMark(Name);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<WrappedCard.CardSuit> suits = new List<WrappedCard.CardSuit>();
            if (room.DrawPile.Count < 4) room.SwapPile();
            if (ask_who.Alive)
            {
                List<int> ids = new List<int>();
                foreach (int id in room.DrawPile)
                {
                    WrappedCard.CardSuit suit = room.GetCard(id).Suit;
                    if (!suits.Contains(suit))
                    {
                        ids.Add(id);
                        suits.Add(suit);
                        if (ids.Count == 4) break;
                    }
                }

                if (ids.Count > 0)
                    room.ObtainCard(ask_who, ref ids, new CardMoveReason(MoveReason.S_REASON_GOTCARD, ask_who.Name, Name, string.Empty), true);
            }
            return false;
        }
    }

    public class Xiecui : TriggerSkill
    {
        public Xiecui() : base("xiecui")
        {
            events = new List<TriggerEvent> { TriggerEvent.DamageCaused, TriggerEvent.EventPhaseChanging };
            skill_type = SkillType.Attack;
        }
        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.DamageCaused && data is DamageStruct damage && damage.From != null && damage.From == room.Current && damage.From.Alive && damage.Card != null)
            {
                damage.From.AddMark(Name);
            }
            else if (triggerEvent == TriggerEvent.EventPhaseChanging && data is PhaseChangeStruct change && change.To == PlayerPhase.NotActive)
            {
                foreach (Player p in room.GetAlivePlayers())
                    p.SetMark(Name, 0);
            }
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (triggerEvent == TriggerEvent.DamageCaused && data is DamageStruct damage && damage.From != null && damage.From.GetMark(Name) == 1 && damage.Card != null)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    if (!p.HasFlag(Name))
                        triggers.Add(new TriggerStruct(Name, p));
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage && room.AskForSkillInvoke(ask_who, Name, string.Format("@xiecui:{0}:{1}:{2}", player.Name, damage.To.Name, damage.Card.Name), info.SkillPosition))
            {
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                ask_who.SetFlags(Name);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (data is DamageStruct damage)
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

                if (player.Alive && player.Kingdom == "wu")
                {
                    WrappedCard card = damage.Card;
                    List<int> ids = room.GetSubCards(card);
                    if (ids.Count > 0 && ids.SequenceEqual(card.SubCards))
                    {
                        bool check = true;
                        foreach (int id in card.SubCards)
                        {
                            if (room.GetCardPlace(id) != Place.PlaceTable)
                            {
                                check = false;
                                break;
                            }
                        }

                        if (check)
                        {
                            player.SetFlags("xiecui_max");
                            LogMessage log2 = new LogMessage("#hancard_max")
                            {
                                From = player.Name,
                                Arg = "+1"
                            };
                            room.SendLog(log2);

                            ResultStruct result = ask_who.Result;
                            result.Assist += ids.Count;
                            ask_who.Result = result;
                            room.RemoveSubCards(damage.Card);
                            room.ObtainCard(damage.From, card);
                        }
                    }
                }
            }
            return false;
        }
    }

    public class XiecuiMax : MaxCardsSkill
    {
        public XiecuiMax() : base("#xiecui") { }
        public override int GetExtra(Room room, Player target) => target.HasFlag("xiecui_max") ? 1 : 0;
    }

    public class Youxu : TriggerSkill
    {
        public Youxu() : base("youxu")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart };
        }

        public override List<TriggerStruct> Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            List<TriggerStruct> triggers = new List<TriggerStruct>();
            if (player != null && player.Alive && player.Phase == PlayerPhase.Finish && player.HandcardNum > player.MaxHp)
            {
                foreach (Player p in RoomLogic.FindPlayersBySkillName(room, Name))
                    triggers.Add(new TriggerStruct(Name, p));
            }
            return triggers;
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            Player target = room.AskForPlayerChosen(ask_who, room.GetOtherPlayers(player), Name, string.Format("@youxu:{0}", player.Name), true, true, info.SkillPosition);
            if (target != null)
            {
                room.SetTag(Name, target);
                room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (room.GetTag(Name) is Player target)
            {
                room.RemoveTag(Name);
                int id = ask_who == player ? room.AskForExchange(ask_who, Name, 1, 1, string.Format("@youxu-show:{0}", target.Name), string.Empty, string.Empty, info.SkillPosition)[0]
                    : room.AskForCardChosen(ask_who, player, "h", Name, false, HandlingMethod.MethodNone);
                room.ShowCard(player, id, Name);
                room.ObtainCard(target, room.GetCard(id), new CardMoveReason(MoveReason.S_REASON_GIVE, ask_who.Name, target.Name, Name, string.Empty), true);
                if (target.Alive && target.IsWounded())
                {
                    bool check = true;
                    foreach (Player p in room.GetOtherPlayers(target))
                    {
                        if (p.Hp < target.Hp)
                        {
                            check = false;
                            break;
                        }
                    }
                    if (check)
                    {
                        RecoverStruct recover = new RecoverStruct
                        {
                            Recover = 1,
                            Who = ask_who
                        };
                        room.Recover(target, recover, true);
                    }
                }
            }
            return false;
        }
    }

    public class Wanglu : TriggerSkill
    {
        public Wanglu() : base("wanglu")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseStart, TriggerEvent.GameStart };
            frequency = Frequency.Compulsory;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if (triggerEvent == TriggerEvent.GameStart && base.Triggerable(player, room))
            {
                foreach (int id in Engine.GetEngineCards())
                {
                    WrappedCard real_card = Engine.GetRealCard(id);
                    if (real_card.Name == Breachingtower.ClassName && room.GetCard(id) == null)
                    {
                        room.AddNewCard(id);
                        break;
                    }
                }
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseStart && player.Phase == PlayerPhase.Start && base.Triggerable(player, room))
                return new TriggerStruct(Name, player);
            return new TriggerStruct();
        }
        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            room.SendCompulsoryTriggerLog(player, Name, true);
            GeneralSkin gsk = RoomLogic.GetGeneralSkin(room, player, Name, info.SkillPosition);

            if (!player.HasTreasure(Breachingtower.ClassName))
            {
                int breaching = -1;
                foreach (int id in room.RoomCards)
                {
                    WrappedCard card = room.GetCard(id);
                    if (card.Name == Breachingtower.ClassName)
                    {
                        breaching = id;
                        break;
                    }
                }
                if (breaching == -1) return false;

                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);

                int equipped_id = -1;
                if (player.GetTreasure())
                    equipped_id = player.Weapon.Key;
                List<CardsMoveStruct> exchangeMove = new List<CardsMoveStruct>();
                if (equipped_id != -1)
                {
                    CardsMoveStruct move1 = new CardsMoveStruct(new List<int> { equipped_id }, player, Place.PlaceTable,
                        new CardMoveReason(MoveReason.S_REASON_CHANGE_EQUIP, player.Name));
                    exchangeMove.Add(move1);
                    room.MoveCardsAtomic(exchangeMove, true);
                }
                CardsMoveStruct move2 = new CardsMoveStruct(new List<int> { breaching }, room.GetCardOwner(breaching), player, room.GetCardPlace(breaching),
                                      Place.PlaceEquip, new CardMoveReason(MoveReason.S_REASON_PUT, player.Name, Name, string.Empty));
                exchangeMove.Add(move2);
                room.MoveCardsAtomic(exchangeMove, true);

                LogMessage log = new LogMessage
                {
                    From = player.Name,
                    Type = "$Install",
                    Card_str = breaching.ToString()
                };
                room.SendLog(log);

                if (equipped_id != -1)
                {
                    if (room.GetCardPlace(equipped_id) == Place.PlaceTable)
                    {
                        CardsMoveStruct move3 = new CardsMoveStruct(new List<int> { equipped_id }, null, Player.Place.DiscardPile,
                           new CardMoveReason(MoveReason.S_REASON_CHANGE_EQUIP, player.Name));
                        room.MoveCardsAtomic(new List<CardsMoveStruct> { move3 }, true);
                    }
                }
            }
            else
            {
                room.BroadcastSkillInvoke(Name, "male", 1, gsk.General, gsk.SkinId);
                player.AddPhase(PlayerPhase.Play);
            }

            return false;
        }
    }

    public class Xianzhu : TriggerSkill
    {
        public Xianzhu() : base("xianzhu")
        {
            events = new List<TriggerEvent> { TriggerEvent.Damage };
        }
        
        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.Damage && data is DamageStruct damage && damage.Card != null && damage.Card.Name.Contains(Slash.ClassName)
                && base.Triggerable(player, room) && player.GetMark(Breachingtower.ClassName) < 5)
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override TriggerStruct Cost(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            List<string> choices = new List<string> { "target", "discard" };
            if (player.GetMark("Breachingtower_ignore") == 0) choices.Add("ignore");
            choices.Add("cancel");
            string choice = room.AskForChoice(player, Name, string.Join("+", choices), null, null, info.SkillPosition);
            if (choice != "cancel")
            {
                room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
                room.NotifySkillInvoked(player, Name);
                player.SetTag(Name, choice);
                return info;
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            if (player.GetTag(Name) is string choice)
            {
                player.RemoveTag(Name);
                player.AddMark(Breachingtower.ClassName);
                room.SetPlayerStringMark(player, Breachingtower.ClassName, player.GetMark(Breachingtower.ClassName).ToString());

                LogMessage log = new LogMessage();
                log.From = player.Name;
                switch (choice)
                {
                    case "target":
                        log.Type = "#xianzhu-target";
                        room.SendLog(log);
                        player.AddMark("Breachingtower_target");
                        break;
                    case "discard":
                        log.Type = "#xianzhu-discard";
                        room.SendLog(log);
                        player.AddMark("Breachingtower_discard");
                        break;
                    default:
                        log.Type = "#xianzhu-ignore";
                        room.SendLog(log);
                        player.AddMark("Breachingtower_ignore");
                        break;
                }
            }

            return false;
        }
    }

    public class Chaixie : TriggerSkill
    {
        public Chaixie() : base("chaixie")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime };
            skill_type = SkillType.Replenish;
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardsMoveOneTimeStruct move && move.From != null && move.From.Alive && move.From_places.Contains(Place.PlaceEquip)
                && move.From.GetMark("Breachingtower_draw") > 0)
            {
                bool invoke = false;
                foreach (int id in move.Card_ids)
                {
                    if (room.GetCard(id).Name == Breachingtower.ClassName)
                    {
                        invoke = true;
                        break;
                    }
                }
                if (invoke) return new TriggerStruct(Name, move.From);
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int count = ask_who.GetMark("Breachingtower_draw");
            ask_who.SetMark("Breachingtower_draw", 0);
            room.DrawCards(ask_who, count, Name);
            return false;
        }
    }

    public class Huishu : TriggerSkill
    {
        public Huishu() : base("huishu")
        {
            events = new List<TriggerEvent> { TriggerEvent.EventPhaseEnd, TriggerEvent.GameStart, TriggerEvent.EventAcquireSkill, TriggerEvent.EventLoseSkill };
            skill_type = SkillType.Replenish;
        }

        public override void Record(TriggerEvent triggerEvent, Room room, Player player, ref object data)
        {
            if ((triggerEvent == TriggerEvent.GameStart && base.Triggerable(player, room)) || (triggerEvent == TriggerEvent.EventAcquireSkill && data is InfoStruct info && info.Info == Name))
            {
                int draw_count = player.GetMark("huishu_draw") + 3;
                int discard_count = player.GetMark("huishu_discard") + 1;
                int trick_count = player.GetMark("huishu_trick") + 2;

                room.SetPlayerStringMark(player, "huishu_draw", draw_count.ToString());
                room.SetPlayerStringMark(player, "huishu_discard", discard_count.ToString());
                room.SetPlayerStringMark(player, "huishu_trick", trick_count.ToString());
            }
            else if (triggerEvent == TriggerEvent.EventLoseSkill && data is InfoStruct _info && _info.Info == Name)
            {
                player.SetMark("huishu_draw", 0);
                player.SetMark("huishu_discard", 0);
                player.SetMark("huishu_trick", 0);

                room.RemovePlayerStringMark(player, "huishu_draw");
                room.RemovePlayerStringMark(player, "huishu_discard");
                room.RemovePlayerStringMark(player, "huishu_trick");
            }
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (triggerEvent == TriggerEvent.EventPhaseEnd && base.Triggerable(player, room) && player.Phase == PlayerPhase.Draw)
                return new TriggerStruct(Name, player);
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
            int count = player.GetMark("huishu_draw") + 3;
            if (count > 0) room.DrawCards(player, count, Name);
            if (player.Alive && !player.IsKongcheng() && RoomLogic.CanDiscard(room, player, player, "h"))
            {
                count = player.GetMark("huishu_discard") + 1;
                if (count > 0) room.AskForDiscard(player, Name, count, count, false, false, "@huishu-discard:::" + count.ToString(), false, info.SkillPosition);
            }
            return false;
        }
    }

    public class HuishuEffect : TriggerSkill
    {
        public HuishuEffect() : base("#huishu")
        {
            events = new List<TriggerEvent> { TriggerEvent.CardsMoveOneTime };
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardsMoveOneTimeStruct move && move.From != null && move.From.Alive && move.From.HasFlag("huishu") && (move.Reason.Reason & MoveReason.S_MASK_BASIC_REASON) == MoveReason.S_REASON_DISCARD
                && (move.From_places.Contains(Place.PlaceHand) || move.From_places.Contains(Place.PlaceEquip)))
            {
                int count = move.From.GetMark("huishu_trick") + 2;
                if (move.Card_ids.Count > count) return new TriggerStruct(Name, move.From);
            }
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int id = -1;
            foreach (int card in room.DiscardPile)
            {
                if (Engine.GetFunctionCard(room.GetCard(card).Name) is TrickCard)
                {
                    id = card;
                    break;
                }
            }
            if (id >= 0)
            {
                room.SendCompulsoryTriggerLog(ask_who, "huishu");
                room.BroadcastSkillInvoke("huishu", ask_who, info.SkillPosition);
                room.ObtainCard(ask_who, room.GetCard(id), new CardMoveReason(MoveReason.S_REASON_RECYCLE, ask_who.Name, "huishu", string.Empty));
            }

            return false;
        }
    }

    public class Yishu : TriggerSkill
    {
        public Yishu() : base("yishu")
        {
            events.Add(TriggerEvent.CardsMoveOneTime);
            frequency = Frequency.Compulsory;
        }

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (data is CardsMoveOneTimeStruct move && base.Triggerable(move.From, room) && move.From.Phase != PlayerPhase.Play && ((move.From_places.Contains(Place.PlaceEquip) && move.To_place != Place.PlaceHand)
                || move.From_places.Contains(Place.PlaceHand)))
                return new TriggerStruct(Name, move.From);
            return new TriggerStruct();
        }

        public override bool Effect(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who, TriggerStruct info)
        {
            int draw_count = ask_who.GetMark("huishu_draw") + 3;
            int discard_count = ask_who.GetMark("huishu_discard") + 1;
            int trick_count = ask_who.GetMark("huishu_trick") + 2;
            room.SendCompulsoryTriggerLog(ask_who, Name);
            room.BroadcastSkillInvoke(Name, ask_who, info.SkillPosition);

            int max = Math.Max(draw_count, Math.Max(trick_count, discard_count));
            int min = Math.Min(draw_count, Math.Min(trick_count, discard_count));
            List<string> choices_max = new List<string>();

            List<string> choices_min = new List<string>();
            List<string> description = new List<string> { "@yishu-min" };
            if (draw_count == min)
            {
                choices_max.Add("draw");
                description.Add("@yishu-draw:::" + draw_count.ToString());
            }
            if (discard_count == min)
            {
                choices_max.Add("discard");
                description.Add("@yishu-discard:::" + discard_count.ToString());
            }
            if (trick_count == min)
            {
                choices_max.Add("trick");
                description.Add("@yishu-trick:::" + trick_count.ToString());
            }
            string choice = room.AskForChoice(ask_who, Name, string.Join("+", choices_max), description, null, info.SkillPosition);
            switch (choice)
            {
                case "draw":
                    ask_who.AddMark("huishu_draw", 2);
                    room.SetPlayerStringMark(ask_who, "huishu_draw", (draw_count + 2).ToString());
                    break;
                case "discard":
                    ask_who.AddMark("huishu_discard", 2);
                    room.SetPlayerStringMark(ask_who, "huishu_discard", (discard_count + 2).ToString());
                    break;
                case "trick":
                    ask_who.AddMark("huishu_trick", 2);
                    room.SetPlayerStringMark(ask_who, "huishu_trick", (trick_count + 2).ToString());
                    break;
            }
            description = new List<string> { "@yishu-max" };
            choices_max.Clear();
            if (draw_count == max)
            {
                choices_max.Add("draw");
                description.Add("@yishu-draw:::" + draw_count.ToString());
            }
            if (discard_count == max)
            {
                choices_max.Add("discard");
                description.Add("@yishu-discard:::" + discard_count.ToString());
            }
            if (trick_count == max)
            {
                choices_max.Add("trick");
                description.Add("@yishu-trick:::" + trick_count.ToString());
            }

            choice = room.AskForChoice(ask_who, Name, string.Join("+", choices_max), description, null, info.SkillPosition);
            switch (choice)
            {
                case "draw":
                    ask_who.AddMark("huishu_draw", -1);
                    room.SetPlayerStringMark(ask_who, "huishu_draw", (draw_count - 1).ToString());
                    break;
                case "discard":
                    ask_who.AddMark("huishu_discard", -1);
                    room.SetPlayerStringMark(ask_who, "huishu_discard", (discard_count -1).ToString());
                    break;
                case "trick":
                    ask_who.AddMark("huishu_trick", -1);
                    room.SetPlayerStringMark(ask_who, "huishu_trick", (trick_count - 1).ToString());
                    break;
            }

            return false;
        }
    }

    public class Ligong : PhaseChangeSkill
    {
        public Ligong() : base("ligong")
        {
            frequency = Frequency.Wake;
        }

        private List<string> generals = new List<string>
        {
            "daqiao_jx", "xiaoqiao", "sunshangxiang", "zhoufei", "wuguotai", "bulianshi", "sunluban", "sunluyu", "xushi", "zhaoyan", "zhangxuan", "sunru_sp", "zhangyao", "tenggongzhu", "zhouyi", "erqiao", "panshu_sp"
        };

        public override TriggerStruct Triggerable(TriggerEvent triggerEvent, Room room, Player player, ref object data, Player ask_who)
        {
            if (player.Phase == PlayerPhase.Start && base.Triggerable(player, room) && player.GetMark(Name) == 0 && (player.GetMark("huishu_draw") + 3 >= 5 || player.GetMark("huishu_discard") + 1 >= 5 || player.GetMark("huishu_trick") + 2 >= 5))
                return new TriggerStruct(Name, player);

            return new TriggerStruct();
        }

        public override bool OnPhaseChange(Room room, Player player, TriggerStruct info)
        {
            room.BroadcastSkillInvoke(Name, player, info.SkillPosition);
            room.DoSuperLightbox(player, info.SkillPosition, Name);
            room.SetPlayerMark(player, Name, 1);
            room.SendCompulsoryTriggerLog(player, Name);

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
            room.HandleAcquireDetachSkills(player, "-yishu", false);

            if (player.Alive)
            {
                List<string> choices = new List<string>();
                Shuffle.shuffle(ref generals);
                foreach (string general in generals)
                {
                    if (!room.UsedGeneral.Contains(general))
                    {
                        choices.Add(general);
                        if (choices.Count >= 4)
                            break;
                    }
                }
                List<string> skills = new List<string>();
                Dictionary<string, string> general_skill = new Dictionary<string, string>();
                int count = 0;
                foreach (string general_name in generals)
                {
                    count++;
                    List<string> sks = Engine.GetGeneralSkills(general_name, room.Setting.GameMode);
                    skills.Add(string.Join("+", sks));
                    foreach (string sk in sks)
                        general_skill.Add(sk, general_name);
                    if (count >= 4) break;
                }
                string skill_choice = room.AskForSkill(player, Name, string.Join("|", skills), "@ligong", 0, 2, true, info.SkillPosition);
                bool draw = false;
                if (!string.IsNullOrEmpty(skill_choice))
                {
                    room.HandleAcquireDetachSkills(player, "-huishu", false);
                    List<string> selected = new List<string>(skill_choice.Split('+'));
                    foreach (string skill in selected)
                    {
                        room.AddSkill2Game(skill);
                        string from_general = general_skill[skill];
                        room.HandleUsedGeneral(from_general);
                        foreach (string skill2 in Engine.GetGeneralRelatedSkills(from_general, room.Setting.GameMode))
                            room.AddSkill2Game(skill2);
                    }
                    room.HandleAcquireDetachSkills(player, selected, true);
                }
                else
                    draw = true;
                room.SendPlayerSkillsToOthers(player);
                room.FilterCards(player, player.GetCards("he"), true);
                if (draw) room.DrawCards(player, 2, Name);
            }

            return false;
        }
    }
}