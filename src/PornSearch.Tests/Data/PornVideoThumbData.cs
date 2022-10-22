using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data
{
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
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            return videoThumbs.GetEnumerator();
        }

        private static IEnumerable<object[]> GetPornhubStraight() {
            List<PornVideoThumb> videoThumbs = new List<PornVideoThumb> {
                // Fix the value "&#039;" in the title
                new PornVideoThumb {
                    Website = PornWebsite.Pornhub,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "ph5fc04dbacd1e6",
                    Title = "Valentine's Day Present is Double Fuck Threesome",
                    Channel = new PornIdName {
                        Id = "/model/miss-daisy-diamond",
                        Name = "Miss Daisy Diamond"
                    },
                    ThumbnailUrl =
                        "https://ci.phncdn.com/videos/202011/27/374175402/original/(m=eafTGgaaaa)(mh=AaHrhQhPfrLPy5_3)14.jpg",
                    PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5fc04dbacd1e6"
                },
                // Fix the value "\u00A0" in the title
                new PornVideoThumb {
                    Website = PornWebsite.Pornhub,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "ph5d3c7d94e38f0",
                    Title = "Asuka loves ANAL babe cosplay ATM teen ass butt  pornstar Purple Bitch",
                    Channel = new PornIdName {
                        Id = "/model/purple-bitch",
                        Name = "Purple Bitch"
                    },
                    ThumbnailUrl =
                        "https://ci.phncdn.com/videos/201907/27/237967581/original/(m=eafTGgaaaa)(mh=wsgEJN05BpMhMC7D)14.jpg",
                    PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5d3c7d94e38f0"
                },
                new PornVideoThumb {
                    Website = PornWebsite.Pornhub,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "ph5a2f7e4f9c48a",
                    Title = "PropertySex - Hot property manager fucks pissed off tenant",
                    Channel = new PornIdName {
                        Id = "/channels/property-sex",
                        Name = "Property Sex"
                    },
                    ThumbnailUrl =
                        "https://ei.phncdn.com/videos/201712/12/145091652/original/(m=eafTGgaaaa)(mh=dKfuDl_TV80fS7Wi)3.jpg",
                    PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5a2f7e4f9c48a"
                }
            };
            return videoThumbs.Select(i => new object[] { i });
        }

        private static IEnumerable<object[]> GetPornhubGay() {
            List<PornVideoThumb> videoThumbs = new List<PornVideoThumb> {
                // Fix the value "&#039;" in the title
                new PornVideoThumb {
                    Website = PornWebsite.Pornhub,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "ph5d432ce7a448c",
                    Title = "GAYWIRE - Bar Addison Becomes Draven Navarro's Farm Fuck Boy",
                    Channel = new PornIdName {
                        Id = "/channels/gay-wire",
                        Name = "Gay Wire"
                    },
                    ThumbnailUrl =
                        "https://ei.phncdn.com/videos/201908/01/239007621/original/(m=eafTGgaaaa)(mh=WYH3Zbs0FETrZK0h)10.jpg",
                    PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5d432ce7a448c"
                },
                new PornVideoThumb {
                    Website = PornWebsite.Pornhub,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "ph61d1f5079ab42",
                    Title = "hard pounding with a view of nice ass",
                    Channel = new PornIdName {
                        Id = "/model/stevenlucasxxx",
                        Name = "stevenlucasxxx"
                    },
                    ThumbnailUrl =
                    "https://di.phncdn.com/videos/202201/02/400626481/original/(m=eafTGgaaaa)(mh=9j4PqjygN1L2pill)1.jpg",
                    PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph61d1f5079ab42"
                },
                new PornVideoThumb {
                    Website = PornWebsite.Pornhub,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "ph60a518bb2da8a",
                    Title = "Marco Antonio, Pol Prince, Rafael Carreras, Joaquin Santana | Raw Foursome",
                    Channel = new PornIdName {
                        Id = "/channels/lucasentertainment",
                        Name = "Lucas Entertainment"
                    },
                    ThumbnailUrl =
                        "https://ci.phncdn.com/videos/202105/19/388272921/original/(m=eafTGgaaaa)(mh=fVKLwQqYceEaETFL)11.jpg",
                    PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph60a518bb2da8a"
                },
                new PornVideoThumb {
                    Website = PornWebsite.Pornhub,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "ph610ecc9a8ca91",
                    Title = "Two cocks one toy Best friends do frotting together and cum HornyJohny66",
                    Channel = new PornIdName {
                        Id = "/model/hornyjohny66",
                        Name = "hornyjohny66"
                    },
                    ThumbnailUrl =
                        "https://ei.phncdn.com/videos/202108/07/392562291/thumbs_5/(m=eafTGgaaaa)(mh=zrFKt_bp3k54N8-K)16.jpg",
                    PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph610ecc9a8ca91"
                }
            };
            return videoThumbs.Select(i => new object[] { i });
        }

        private static IEnumerable<object[]> GetXVideosStraight() {
            List<PornVideoThumb> videoThumbs = new List<PornVideoThumb> {
                // Fix the value "&amp;" in the title
                new PornVideoThumb {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "39773111",
                    Title = "Petite princess Sasha Rose fingers her delicious pink & rides her sex toy",
                    Channel = new PornIdName {
                        Id = "/1by-day",
                        Name = "1By-Day"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/64/5a/cd/645acd983be57e6ca59f9389e13e5a69/645acd983be57e6ca59f9389e13e5a69.7.jpg",
                    PageUrl =
                        "https://www.xvideos.com/video39773111/petite_princess_sasha_rose_fingers_her_delicious_pink_and_rides_her_sex_toy"
                },
                // Fix the value "\u00A0" in the title
                new PornVideoThumb {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "63965375",
                    Title = "Why is This Pussy Wet  Vol 72",
                    Channel = new PornIdName {
                        Id = "/ferame",
                        Name = "Ferame"
                    },
                    ThumbnailUrl =
                        "https://img-l3.xvideos-cdn.com/videos/thumbs169ll/25/12/97/25129756a8d056392608ce2a33f1cf03/25129756a8d056392608ce2a33f1cf03.4.jpg",
                    PageUrl = "https://www.xvideos.com/video63965375/why_is_this_pussy_wet_vol_72"
                },
                new PornVideoThumb {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "26195069",
                    Title = "Double penetrated gonzo babe facialized",
                    Channel = new PornIdName {
                        Id = "/darkxsite",
                        Name = "Darkxsite"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/27/67/d4/2767d489b1eb14d7821e8df57b791a9d/2767d489b1eb14d7821e8df57b791a9d.20.jpg",
                    PageUrl = "https://www.xvideos.com/video26195069/double_penetrated_gonzo_babe_facialized"
                },
                new PornVideoThumb {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "63909971",
                    Title =
                        "(Raul Costa) Waits With His Big Cock Out For Petite (Josephine Jackson) To Finish Her Yoga - Reality Kings",
                    Channel = new PornIdName {
                        Id = "/reality-kings-channel",
                        Name = "Reality Kings"
                    },
                    ThumbnailUrl =
                        "https://img-l3.xvideos-cdn.com/videos/thumbs169ll/e8/c3/b8/e8c3b880587e7e64cc3ace8b81645721/e8c3b880587e7e64cc3ace8b81645721.30.jpg",
                    PageUrl =
                        "https://www.xvideos.com/video63909971/_raul_costa_waits_with_his_big_cock_out_for_petite_josephine_jackson_to_finish_her_yoga_-_reality_kings"
                }
            };
            return videoThumbs.Select(i => new object[] { i });
        }

        private static IEnumerable<object[]> GetXVideosGay() {
            List<PornVideoThumb> videoThumbs = new List<PornVideoThumb> {
                // Fix the value "&amp;" in the title
                new PornVideoThumb {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "63543339",
                    Title = "Fireworks In His Ass For Father's Day",
                    Channel = new PornIdName {
                        Id = "/youngperps",
                        Name = "YoungPerps"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/5d/00/30/5d003011fae8c3df1c3bb9529c7dbeff/5d003011fae8c3df1c3bb9529c7dbeff.24.jpg",
                    PageUrl = "https://www.xvideos.com/video63543339/fireworks_in_his_ass_for_father_s_day"
                },
                // Fix the value "\u00A0" in the title
                new PornVideoThumb {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "7859351",
                    Title = "Gay orgy   They're loving it so much, in fact, that they just can't",
                    Channel = new PornIdName {
                        Id = "/analgayfetish",
                        Name = "Analgayfetish"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/12/9e/9c/129e9c59afac7c1afc2729e7b916ad6f/129e9c59afac7c1afc2729e7b916ad6f.8.jpg",
                    PageUrl =
                        "https://www.xvideos.com/video7859351/gay_orgy_they_re_loving_it_so_much_in_fact_that_they_just_can_t"
                },
                new PornVideoThumb {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "59864125",
                    Title = "Quiet Top gets Some Sloppy Head",
                    Channel = new PornIdName {
                        Id = "/finn-phillips",
                        Name = "Finn Phillips"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/f3/b5/11/f3b511b10de81bc6abd730a02b914b42/f3b511b10de81bc6abd730a02b914b42.19.jpg",
                    PageUrl = "https://www.xvideos.com/video59864125/quiet_top_gets_some_sloppy_head"
                },
                new PornVideoThumb {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "9390594",
                    Title = "Johnny Rapids orgy cumshot on a boat",
                    Channel = new PornIdName {
                        Id = "/menofuk",
                        Name = "Men Of Uk"
                    },
                    ThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/b0/1e/c9/b01ec9383c300cf4bf21ff3745f3f6a3/b01ec9383c300cf4bf21ff3745f3f6a3.16.jpg",
                    PageUrl = "https://www.xvideos.com/video9390594/johnny_rapids_orgy_cumshot_on_a_boat"
                }
            };
            return videoThumbs.Select(i => new object[] { i });
        }

        private static IEnumerable<object[]> GetXVideosTrans() {
            List<PornVideoThumb> videoThumbs = new List<PornVideoThumb> {
                // Fix the value "&amp;" in the title
                new PornVideoThumb {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Trans,
                    Id = "18936599",
                    Title = "Venus Lux Pounds Tyra Scott's Asshole",
                    Channel = new PornIdName {
                        Id = "/tsvenuslux",
                        Name = "Venus Lux"
                    },
                    ThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/d4/a2/a9/d4a2a9883dd4eb3866afdfcb46457f43/d4a2a9883dd4eb3866afdfcb46457f43.16.jpg",
                    PageUrl = "https://www.xvideos.com/video18936599/venus_lux_pounds_tyra_scott_s_asshole"
                },
                new PornVideoThumb {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Trans,
                    Id = "63886273",
                    Title = "TRANSEROTICA Trans Cutie Daisy C Anal Fucked By Kai Bailey",
                    Channel = new PornIdName {
                        Id = "/transerotica",
                        Name = "Trans Erotica"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/b6/cd/56/b6cd5694ea43141af6c5263138498983/b6cd5694ea43141af6c5263138498983.24.jpg",
                    PageUrl = "https://www.xvideos.com/video63886273/transerotica_trans_cutie_daisy_c_anal_fucked_by_kai_bailey"
                },
                new PornVideoThumb {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Trans,
                    Id = "64139835",
                    Title = "Carioca da pica grossa começou com camisinha depois tirou pra sentir no pelo",
                    Channel = new PornIdName {
                        Id = "/maria_flavia_ts",
                        Name = "Maria Flavia Ts"
                    },
                    ThumbnailUrl =
                        "https://img-l3.xvideos-cdn.com/videos/thumbs169ll/86/b3/7c/86b37cf8a6ada2e3eeef46277331c8f2/86b37cf8a6ada2e3eeef46277331c8f2.13.jpg",
                    PageUrl =
                        "https://www.xvideos.com/video64139835/carioca_da_pica_grossa_comecou_com_camisinha_depois_tirou_pra_sentir_no_pelo"
                }
            };
            return videoThumbs.Select(i => new object[] { i });
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
