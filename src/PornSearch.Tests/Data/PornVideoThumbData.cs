using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data;

public class PornVideoThumbData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator() {
        List<object[]> videoThumbs = new List<object[]>();
        foreach (PornWebsite website in ConfigForTests.GetWebsites()) {
            switch (website) {
                case PornWebsite.Pornhub:
                    videoThumbs.AddRange(GetPornhubStraight());
                    videoThumbs.AddRange(GetPornhubGay());
                    break;
                case PornWebsite.XVideos:
                    videoThumbs.AddRange(GetXVideosStraight());
                    videoThumbs.AddRange(GetXVideosGay());
                    videoThumbs.AddRange(GetXVideosTrans());
                    break;
                case PornWebsite.YouPorn:
                    videoThumbs.AddRange(GetYouPornStraight());
                    videoThumbs.AddRange(GetYouPornGay());
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        return videoThumbs.GetEnumerator();
    }

    private static IEnumerable<object[]> GetPornhubStraight() {
        List<PornVideoThumb> videoThumbs = new List<PornVideoThumb> {
            // Fix the value "&#039;" in the title
            new() {
                Website = PornWebsite.Pornhub,
                SexOrientation = PornSexOrientation.Straight,
                Id = "65d3064b91914",
                Title = "My Neighbor's Cute Wife Was Home Alone On Valentine's Day",
                Channel = new PornIdName {
                    Id = "/model/brooke-tilli",
                    Name = "Brooke Tilli"
                },
                ThumbnailUrl = "https://ei.phncdn.com/videos/202402/19/448361951/original/(m=qRNTS9YbeafTGgaaaa)(mh=IxAiwQ6q2a7uiMZ1)0.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=65d3064b91914"
            },
            // Fix the value "\u00A0" in the title
            new() {
                Website = PornWebsite.Pornhub,
                SexOrientation = PornSexOrientation.Straight,
                Id = "ph5d3c7d94e38f0",
                Title = "Asuka loves ANAL babe cosplay ATM teen ass butt  pornstar Purple Bitch",
                Channel = new PornIdName {
                    Id = "/model/purple-bitch",
                    Name = "Purple Bitch"
                },
                ThumbnailUrl = "https://ci.phncdn.com/videos/201907/27/237967581/original/(m=eafTGgaaaa)(mh=wsgEJN05BpMhMC7D)14.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5d3c7d94e38f0"
            },
            new() {
                Website = PornWebsite.Pornhub,
                SexOrientation = PornSexOrientation.Straight,
                Id = "ph61d1f5079ab42",
                Title = "hard pounding with a view of nice ass",
                Channel = new PornIdName {
                    Id = "/model/stevenlucasxxx",
                    Name = "stevenlucasxxx"
                },
                ThumbnailUrl = "https://di.phncdn.com/videos/202201/02/400626481/original/(m=eafTGgaaaa)(mh=9j4PqjygN1L2pill)1.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph61d1f5079ab42"
            },
            new() {
                Website = PornWebsite.Pornhub,
                SexOrientation = PornSexOrientation.Straight,
                Id = "ph5a2f7e4f9c48a",
                Title = "PropertySex - Hot property manager fucks pissed off tenant",
                Channel = new PornIdName {
                    Id = "/channels/property-sex",
                    Name = "Property Sex"
                },
                ThumbnailUrl = "https://ei.phncdn.com/videos/201712/12/145091652/original/(m=eafTGgaaaa)(mh=dKfuDl_TV80fS7Wi)3.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5a2f7e4f9c48a"
            }
        };
        return videoThumbs.Select(i => new object[] { i });
    }

    private static IEnumerable<object[]> GetPornhubGay() {
        List<PornVideoThumb> videoThumbs = new List<PornVideoThumb> {
            // Fix the value "&#039;" in the title
            new() {
                Website = PornWebsite.Pornhub,
                SexOrientation = PornSexOrientation.Gay,
                Id = "ph5d432ce7a448c",
                Title = "GAYWIRE - Bar Addison Becomes Draven Navarro's Farm Fuck Boy",
                Channel = new PornIdName {
                    Id = "/channels/gay-wire",
                    Name = "Gay Wire"
                },
                ThumbnailUrl = "https://ei.phncdn.com/videos/201908/01/239007621/original/(m=eafTGgaaaa)(mh=WYH3Zbs0FETrZK0h)10.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5d432ce7a448c"
            },
            new() {
                Website = PornWebsite.Pornhub,
                SexOrientation = PornSexOrientation.Gay,
                Id = "ph60a518bb2da8a",
                Title = "Marco Antonio, Pol Prince, Rafael Carreras, Joaquin Santana | Raw Foursome",
                Channel = new PornIdName {
                    Id = "/channels/lucasentertainment",
                    Name = "Lucas Entertainment"
                },
                ThumbnailUrl = "https://ci.phncdn.com/videos/202105/19/388272921/original/(m=eafTGgaaaa)(mh=fVKLwQqYceEaETFL)11.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph60a518bb2da8a"
            },
            new() {
                Website = PornWebsite.Pornhub,
                SexOrientation = PornSexOrientation.Gay,
                Id = "ph610ecc9a8ca91",
                Title = "Two cocks one toy Best friends do frotting together and cum HornyJohny66",
                Channel = new PornIdName {
                    Id = "/model/hornyjohny66",
                    Name = "hornyjohny66"
                },
                ThumbnailUrl = "https://ei.phncdn.com/videos/202108/07/392562291/thumbs_5/(m=eafTGgaaaa)(mh=zrFKt_bp3k54N8-K)16.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph610ecc9a8ca91"
            }
        };
        return videoThumbs.Select(i => new object[] { i });
    }

    private static IEnumerable<object[]> GetXVideosStraight() {
        List<PornVideoThumb> videoThumbs = new List<PornVideoThumb> {
            // Fix the value "&amp;" in the title
            new() {
                Website = PornWebsite.XVideos,
                SexOrientation = PornSexOrientation.Straight,
                Id = "ioeekbmb9d4",
                Title = "Petite princess Sasha Rose fingers her delicious pink & rides her sex toy",
                Channel = new PornIdName {
                    Id = "/pornworld_sexy_world",
                    Name = "Porn World Sexy World"
                },
                ThumbnailUrl =
                    "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/64/5a/cd/645acd983be57e6ca59f9389e13e5a69/645acd983be57e6ca59f9389e13e5a69.7.jpg",
                PageUrl =
                    "https://www.xvideos.com/video.ioeekbmb9d4/petite_princess_sasha_rose_fingers_her_delicious_pink_and_rides_her_sex_toy"
            },
            // Fix the value "\u00A0" in the title
            new() {
                Website = PornWebsite.XVideos,
                SexOrientation = PornSexOrientation.Straight,
                Id = "kdttlbff98e",
                Title = "Why is This Pussy Wet  Vol 72",
                Channel = new PornIdName {
                    Id = "/ferame",
                    Name = "Ferame"
                },
                ThumbnailUrl =
                    "https://img-l3.xvideos-cdn.com/videos/thumbs169ll/25/12/97/25129756a8d056392608ce2a33f1cf03/25129756a8d056392608ce2a33f1cf03.4.jpg",
                PageUrl = "https://www.xvideos.com/video.kdttlbff98e/why_is_this_pussy_wet_vol_72"
            },
            // Fix verified profile tag
            new() {
                Website = PornWebsite.XVideos,
                SexOrientation = PornSexOrientation.Straight,
                Id = "udmuhcfcdb7",
                Title = "Verification video",
                Channel = new PornIdName {
                    Id = "/harnikandreea",
                    Name = "Harnikandreea"
                },
                ThumbnailUrl =
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/94/d1/08/94d10842ae8992b4834be50ea6017510/94d10842ae8992b4834be50ea6017510.15.jpg",
                PageUrl = "https://www.xvideos.com/video.udmuhcfcdb7/video_de_verification"
            },
            new() {
                Website = PornWebsite.XVideos,
                SexOrientation = PornSexOrientation.Straight,
                Id = "hlfbumd4167",
                Title = "Double penetrated gonzo babe facialized",
                Channel = new PornIdName {
                    Id = "/darkxsite",
                    Name = "Darkxsite"
                },
                ThumbnailUrl =
                    "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/27/67/d4/2767d489b1eb14d7821e8df57b791a9d/2767d489b1eb14d7821e8df57b791a9d.20.jpg",
                PageUrl = "https://www.xvideos.com/video.hlfbumd4167/double_penetrated_gonzo_babe_facialized"
            },
            new() {
                Website = PornWebsite.XVideos,
                SexOrientation = PornSexOrientation.Straight,
                Id = "kcfktok9712",
                Title = "(Raul Costa) Waits With His Big Cock Out For Petite (Josephine Jackson) To Finish Her Yoga - Reality Kings",
                Channel = new PornIdName {
                    Id = "/reality-kings-channel",
                    Name = "Reality Kings"
                },
                ThumbnailUrl =
                    "https://img-l3.xvideos-cdn.com/videos/thumbs169ll/e8/c3/b8/e8c3b880587e7e64cc3ace8b81645721/e8c3b880587e7e64cc3ace8b81645721.30.jpg",
                PageUrl =
                    "https://www.xvideos.com/video.kcfktok9712/_raul_costa_waits_with_his_big_cock_out_for_petite_josephine_jackson_to_finish_her_yoga_-_reality_kings"
            }
        };
        return videoThumbs.Select(i => new object[] { i });
    }

    private static IEnumerable<object[]> GetXVideosGay() {
        List<PornVideoThumb> videoThumbs = new List<PornVideoThumb> {
            // Fix the value "&amp;" in the title
            new() {
                Website = PornWebsite.XVideos,
                SexOrientation = PornSexOrientation.Gay,
                Id = "kcvvlibfd74",
                Title = "Fireworks In His Ass For Father's Day",
                Channel = new PornIdName {
                    Id = "/youngperps",
                    Name = "YoungPerps"
                },
                ThumbnailUrl =
                    "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/5d/00/30/5d003011fae8c3df1c3bb9529c7dbeff/5d003011fae8c3df1c3bb9529c7dbeff.24.jpg",
                PageUrl = "https://www.xvideos.com/video.kcvvlibfd74/fireworks_in_his_ass_for_father_s_day"
            },
            // Fix the value "\u00A0" in the title
            new() {
                Website = PornWebsite.XVideos,
                SexOrientation = PornSexOrientation.Gay,
                Id = "mmecvm318b",
                Title = "Gay orgy   They're loving it so much, in fact, that they just can't",
                Channel = new PornIdName {
                    Id = "/analgayfetish",
                    Name = "Analgayfetish"
                },
                ThumbnailUrl =
                    "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/12/9e/9c/129e9c59afac7c1afc2729e7b916ad6f/129e9c59afac7c1afc2729e7b916ad6f.8.jpg",
                PageUrl = "https://www.xvideos.com/video.mmecvm318b/gay_orgy_they_re_loving_it_so_much_in_fact_that_they_just_can_t"
            },
            new() {
                Website = PornWebsite.XVideos,
                SexOrientation = PornSexOrientation.Gay,
                Id = "kvhmukd804d",
                Title = "Quiet Top gets Some Sloppy Head",
                Channel = new PornIdName {
                    Id = "/finn-phillips",
                    Name = "Finn Phillips"
                },
                ThumbnailUrl =
                    "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/f3/b5/11/f3b511b10de81bc6abd730a02b914b42/f3b511b10de81bc6abd730a02b914b42.19.jpg",
                PageUrl = "https://www.xvideos.com/video.kvhmukd804d/quiet_top_gets_some_sloppy_head"
            },
            new() {
                Website = PornWebsite.XVideos,
                SexOrientation = PornSexOrientation.Gay,
                Id = "lfuati5234",
                Title = "Johnny Rapids orgy cumshot on a boat",
                Channel = new PornIdName {
                    Id = "/menofuk",
                    Name = "Men Of Uk"
                },
                ThumbnailUrl =
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/b0/1e/c9/b01ec9383c300cf4bf21ff3745f3f6a3/b01ec9383c300cf4bf21ff3745f3f6a3.16.jpg",
                PageUrl = "https://www.xvideos.com/video.lfuati5234/johnny_rapids_orgy_cumshot_on_a_boat"
            }
        };
        return videoThumbs.Select(i => new object[] { i });
    }

    private static IEnumerable<object[]> GetXVideosTrans() {
        List<PornVideoThumb> videoThumbs = new List<PornVideoThumb> {
            // Fix the value "&amp;" in the title
            new() {
                Website = PornWebsite.XVideos,
                SexOrientation = PornSexOrientation.Trans,
                Id = "hitfkhm99be",
                Title = "Venus Lux Pounds Tyra Scott's Asshole",
                Channel = new PornIdName {
                    Id = "/tsvenuslux",
                    Name = "Venus Lux"
                },
                ThumbnailUrl =
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/d4/a2/a9/d4a2a9883dd4eb3866afdfcb46457f43/d4a2a9883dd4eb3866afdfcb46457f43.16.jpg",
                PageUrl = "https://www.xvideos.com/video.hitfkhm99be/venus_lux_pounds_tyra_scott_s_asshole"
            },
            new() {
                Website = PornWebsite.XVideos,
                SexOrientation = PornSexOrientation.Trans,
                Id = "utipmab84dd",
                Title = "Shemale Kate Zoha sucked off by stepsis",
                Channel = new PornIdName {
                    Id = "/sweetysab",
                    Name = "Sweetysab"
                },
                ThumbnailUrl =
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/a2/f5/29/a2f5293dee979267d27c37aa623fac73/a2f5293dee979267d27c37aa623fac73.17.jpg",
                PageUrl = "https://www.xvideos.com/video.utipmab84dd/shemale_kate_zoha_sucked_off_by_stepsis"
            },
            new() {
                Website = PornWebsite.XVideos,
                SexOrientation = PornSexOrientation.Trans,
                Id = "kdibikb229c",
                Title = "Carioca da pica grossa começou com camisinha depois tirou pra sentir no pelo",
                Channel = new PornIdName {
                    Id = "/maria_flavia_ts",
                    Name = "Maria Flavia Ts"
                },
                ThumbnailUrl =
                    "https://img-l3.xvideos-cdn.com/videos/thumbs169ll/86/b3/7c/86b37cf8a6ada2e3eeef46277331c8f2/86b37cf8a6ada2e3eeef46277331c8f2.13.jpg",
                PageUrl =
                    "https://www.xvideos.com/video.kdibikb229c/carioca_da_pica_grossa_comecou_com_camisinha_depois_tirou_pra_sentir_no_pelo"
            }
        };
        return videoThumbs.Select(i => new object[] { i });
    }

    private static IEnumerable<object[]> GetYouPornStraight() {
        List<PornVideoThumb> videoThumbs = new List<PornVideoThumb> {
            new() {
                Website = PornWebsite.YouPorn,
                SexOrientation = PornSexOrientation.Straight,
                Id = "14545647",
                Title = "TRUE ANAL Megan Rain gets her butt stuffed",
                Channel = new PornIdName {
                    Id = "/channel/true-anal/",
                    Name = "True Anal"
                },
                ThumbnailUrl = "https://di1.ypncdn.com/m=eafT8f/201805/02/14545647/original/100.jpg",
                PageUrl = "https://www.youporn.com/watch/14545647/true-anal-megan-rain-gets-her-butt-stuffed/"
            },
            new() {
                Website = PornWebsite.YouPorn,
                SexOrientation = PornSexOrientation.Straight,
                Id = "13449035",
                Title = "HOLED - Cute brunette Aidra Fox enjoys an anal fuckfest",
                Channel = new PornIdName {
                    Id = "/channel/holed/",
                    Name = "Holed"
                },
                ThumbnailUrl = "https://di1.ypncdn.com/m=eafT8f/201701/24/13449035/original/15.jpg",
                PageUrl = "https://www.youporn.com/watch/13449035/holed-cute-brunette-aidra-fox-enjoys-an-anal-fuckfest/"
            },
            new() {
                Website = PornWebsite.YouPorn,
                SexOrientation = PornSexOrientation.Straight,
                Id = "16066894",
                Title = "Twistys - Super Hot Babes Molly Stewart & Desiree Dulce Had Sex",
                Channel = new PornIdName {
                    Id = "/channel/twistys/",
                    Name = "Twistys"
                },
                ThumbnailUrl = "https://di1-ph.ypncdn.com/videos/202007/10/331751472/original/(m=eafT8f)(mh=4PKOMDO0khBc3hcu)0.jpg",
                PageUrl = "https://www.youporn.com/watch/16066894/",
            },
            new() {
                Website = PornWebsite.YouPorn,
                SexOrientation = PornSexOrientation.Straight,
                Id = "16621610",
                Title = "TRIO AVEC ESCORTE À L'HÔTEL MA FEMME GOÛTE À LA CHATTE POUR LA PREMIÈRE FOIS FFM",
                Channel = new PornIdName {
                    Id = "",
                    Name = ""
                },
                ThumbnailUrl = "https://di1-ph.ypncdn.com/videos/202010/28/364664191/original/(m=eafT8f)(mh=rHFkT539TbUf95RC)8.jpg",
                PageUrl =
                    "https://www.youporn.com/watch/16621610/"
            }
        };
        return videoThumbs.Select(i => new object[] { i });
    }

    private static IEnumerable<object[]> GetYouPornGay() {
        List<PornVideoThumb> videoThumbs = new List<PornVideoThumb> {
            new() {
                Website = PornWebsite.YouPorn,
                SexOrientation = PornSexOrientation.Gay,
                Id = "16063976",
                Title = "Ashley Ryder Picked Up By 2 Hunks, Gets Dominated & DP'd",
                Channel = new PornIdName {
                    Id = "/gay/channel/falcon-studios/",
                    Name = "Falcon Studios"
                },
                ThumbnailUrl = "https://di1-ph.ypncdn.com/videos/202007/07/330899932/original/(m=eafT8f)(mh=z04kIFWNEkC9euHo)15.jpg",
                PageUrl = "https://www.youporn.com/watch/16063976/"
            },
            new() {
                Website = PornWebsite.YouPorn,
                SexOrientation = PornSexOrientation.Gay,
                Id = "14357193",
                Title = "NextDoorRaw Cheating RAW Style In The Next Room, Sorry!",
                Channel = new PornIdName {
                    Id = "/gay/channel/next-door-raw/",
                    Name = "Next Door Raw"
                },
                ThumbnailUrl = "https://di1.ypncdn.com/m=eafT8f/201802/08/14357193/original/14.jpg",
                PageUrl = "https://www.youporn.com/watch/14357193/nextdoorraw-cheating-raw-style-in-the-next-room-sorry/"
            },
            new() {
                Website = PornWebsite.YouPorn,
                SexOrientation = PornSexOrientation.Gay,
                Id = "16391424",
                Title = "Rencontre avec le minet bien monté Snauwflake au parc qui finit avec une baise sans capote",
                Channel = new PornIdName {
                    Id = "",
                    Name = ""
                },
                ThumbnailUrl = "https://di1-ph.ypncdn.com/videos/202009/06/349439741/original/(m=eafT8f)(mh=HGJLh-5TaFy4er3C)0.jpg",
                PageUrl =
                    "https://www.youporn.com/watch/16391424/rencontre-avec-le-minet-bien-monte-snauwflake-au-parc-qui-finit-avec-une-baise-sans-capote/"
            }
        };
        return videoThumbs.Select(i => new object[] { i });
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}
