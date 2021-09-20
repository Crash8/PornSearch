using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data
{
    public class PornItemThumbData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() {
            List<object[]> pornItemThumbs = new List<object[]>();
            foreach (PornSource source in Enum.GetValues(typeof(PornSource))) {
                switch (source) {
                    case PornSource.Pornhub:
                        pornItemThumbs.AddRange(GetPornhubStraight());
                        pornItemThumbs.AddRange(GetPornhubGay());
                        break;
                    case PornSource.XVideos:
                        pornItemThumbs.AddRange(GetXVideosStraight());
                        pornItemThumbs.AddRange(GetXVideosGay());
                        pornItemThumbs.AddRange(GetXVideosTrans());
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            return pornItemThumbs.GetEnumerator();
        }

        private static IEnumerable<object[]> GetPornhubStraight() {
            List<PornItemThumb> itemThumbs = new List<PornItemThumb> {
                // Fix the value "&#039;" in the title
                new PornItemThumb {
                    Source = PornSource.Pornhub,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "ph5fc04dbacd1e6",
                    Title = "Valentine's Day Present is Double Fuck Threesome",
                    Channel = new PornIdName {
                        Id = "/model/miss-daisy-diamond",
                        Name = "Miss Daisy Diamond"
                    },
                    ThumbnailUrl =
                        "https://ci.phncdn.com/videos/202011/27/374175402/original/(m=eafTGgaaaa)(mh=AaHrhQhPfrLPy5_3)14.jpg"
                },
                // Fix the value "\u00A0" in the title
                new PornItemThumb {
                    Source = PornSource.Pornhub,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "ph5d3c7d94e38f0",
                    Title = "Asuka loves ANAL babe cosplay ATM teen ass butt  pornstar Purple Bitch",
                    Channel = new PornIdName {
                        Id = "/model/purple-bitch",
                        Name = "Purple Bitch"
                    },
                    ThumbnailUrl =
                        "https://ci.phncdn.com/videos/201907/27/237967581/original/(m=eafTGgaaaa)(mh=wsgEJN05BpMhMC7D)14.jpg"
                },
                new PornItemThumb {
                    Source = PornSource.Pornhub,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "ph5a2f7e4f9c48a",
                    Title = "PropertySex - Hot property manager fucks pissed off tenant",
                    Channel = new PornIdName {
                        Id = "/channels/property-sex",
                        Name = "Property Sex"
                    },
                    ThumbnailUrl =
                        "https://ei.phncdn.com/videos/201712/12/145091652/original/(m=eafTGgaaaa)(mh=dKfuDl_TV80fS7Wi)3.jpg"
                }
            };
            return itemThumbs.Select(i => new object[] { i });
        }

        private static IEnumerable<object[]> GetPornhubGay() {
            List<PornItemThumb> itemThumbs = new List<PornItemThumb> {
                // Fix the value "&#039;" in the title
                new PornItemThumb {
                    Source = PornSource.Pornhub,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "ph5d432ce7a448c",
                    Title = "GAYWIRE - Bar Addison Becomes Draven Navarro's Farm Fuck Boy",
                    Channel = new PornIdName {
                        Id = "/channels/gay-wire",
                        Name = "Gay Wire"
                    },
                    ThumbnailUrl =
                        "https://ei.phncdn.com/videos/201908/01/239007621/original/(m=eafTGgaaaa)(mh=WYH3Zbs0FETrZK0h)10.jpg"
                },
                new PornItemThumb {
                    Source = PornSource.Pornhub,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "ph60a518bb2da8a",
                    Title = "Marco Antonio, Pol Prince, Rafael Carreras, Joaquin Santana | Raw Foursome",
                    Channel = new PornIdName {
                        Id = "/channels/lucasentertainment",
                        Name = "Lucas Entertainment"
                    },
                    ThumbnailUrl =
                        "https://ci.phncdn.com/videos/202105/19/388272921/original/(m=eafTGgaaaa)(mh=fVKLwQqYceEaETFL)11.jpg"
                },
                new PornItemThumb {
                    Source = PornSource.Pornhub,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "ph5ff7f75ae5895",
                    Title = "Huge dick shot cum and continued to fuck the hole while making a creampie.",
                    Channel = new PornIdName {
                        Id = "/model/cris-fabio",
                        Name = "Cris Fabio"
                    },
                    ThumbnailUrl =
                        "https://ei.phncdn.com/videos/202101/08/381309022/original/(m=qM1VY-VbeafTGgaaaa)(mh=6k7w3qreddX5Pn38)0.jpg"
                }
            };
            return itemThumbs.Select(i => new object[] { i });
        }

        private static IEnumerable<object[]> GetXVideosStraight() {
            List<PornItemThumb> itemThumbs = new List<PornItemThumb> {
                // Fix the value "&amp;" in the title
                new PornItemThumb {
                    Source = PornSource.XVideos,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "/video39773111/petite_princess_sasha_rose_fingers_her_delicious_pink_and_rides_her_sex_toy",
                    Title = "Petite princess Sasha Rose fingers her delicious pink & rides her sex toy",
                    Channel = new PornIdName {
                        Id = "/channels/1by-day",
                        Name = "1By-Day"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/64/5a/cd/645acd983be57e6ca59f9389e13e5a69/645acd983be57e6ca59f9389e13e5a69.7.jpg"
                },
                // Fix the value "\u00A0" in the title
                new PornItemThumb {
                    Source = PornSource.XVideos,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "/video63965375/why_is_this_pussy_wet_vol_72",
                    Title = "Why is This Pussy Wet  Vol 72",
                    Channel = new PornIdName {
                        Id = "/channels/ferame",
                        Name = "Ferame"
                    },
                    ThumbnailUrl =
                        "https://img-l3.xvideos-cdn.com/videos/thumbs169ll/25/12/97/25129756a8d056392608ce2a33f1cf03/25129756a8d056392608ce2a33f1cf03.4.jpg"
                },
                new PornItemThumb {
                    Source = PornSource.XVideos,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "/video26195069/double_penetrated_gonzo_babe_facialized",
                    Title = "Double penetrated gonzo babe facialized",
                    Channel = new PornIdName {
                        Id = "/profiles/darkxsite",
                        Name = "Darkxsite"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/27/67/d4/2767d489b1eb14d7821e8df57b791a9d/2767d489b1eb14d7821e8df57b791a9d.20.jpg"
                },
                new PornItemThumb {
                    Source = PornSource.XVideos,
                    SexOrientation = PornSexOrientation.Straight,
                    Id =
                        "/video63909971/_raul_costa_waits_with_his_big_cock_out_for_petite_josephine_jackson_to_finish_her_yoga_-_reality_kings",
                    Title =
                        "(Raul Costa) Waits With His Big Cock Out For Petite (Josephine Jackson) To Finish Her Yoga - Reality Kings",
                    Channel = new PornIdName {
                        Id = "/channels/reality-kings-channel",
                        Name = "Reality Kings"
                    },
                    ThumbnailUrl =
                        "https://img-l3.xvideos-cdn.com/videos/thumbs169ll/e8/c3/b8/e8c3b880587e7e64cc3ace8b81645721/e8c3b880587e7e64cc3ace8b81645721.30.jpg"
                }
            };
            return itemThumbs.Select(i => new object[] { i });
        }

        private static IEnumerable<object[]> GetXVideosGay() {
            List<PornItemThumb> itemThumbs = new List<PornItemThumb> {
                // Fix the value "&amp;" in the title
                new PornItemThumb {
                    Source = PornSource.XVideos,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "/video63543339/fireworks_in_his_ass_for_father_s_day",
                    Title = "Fireworks In His Ass For Father's Day",
                    Channel = new PornIdName {
                        Id = "/channels/youngperps",
                        Name = "YoungPerps"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/5d/00/30/5d003011fae8c3df1c3bb9529c7dbeff/5d003011fae8c3df1c3bb9529c7dbeff.24.jpg"
                },
                // Fix the value "\u00A0" in the title
                new PornItemThumb {
                    Source = PornSource.XVideos,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "/video7859351/gay_orgy_they_re_loving_it_so_much_in_fact_that_they_just_can_t",
                    Title = "Gay orgy   They're loving it so much, in fact, that they just can't",
                    Channel = new PornIdName {
                        Id = "/profiles/analgayfetish",
                        Name = "Analgayfetish"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/12/9e/9c/129e9c59afac7c1afc2729e7b916ad6f/129e9c59afac7c1afc2729e7b916ad6f.8.jpg"
                },
                new PornItemThumb {
                    Source = PornSource.XVideos,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "/video59864125/quiet_top_gets_some_sloppy_head",
                    Title = "Quiet Top gets Some Sloppy Head",
                    Channel = new PornIdName {
                        Id = "/amateur-channels/finn-phillips",
                        Name = "Finn Phillips"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/f3/b5/11/f3b511b10de81bc6abd730a02b914b42/f3b511b10de81bc6abd730a02b914b42.19.jpg"
                },
                new PornItemThumb {
                    Source = PornSource.XVideos,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "/video9390594/johnny_rapids_orgy_cumshot_on_a_boat",
                    Title = "Johnny Rapids orgy cumshot on a boat",
                    Channel = new PornIdName {
                        Id = "/channels/menofuk",
                        Name = "Men Of Uk"
                    },
                    ThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/b0/1e/c9/b01ec9383c300cf4bf21ff3745f3f6a3/b01ec9383c300cf4bf21ff3745f3f6a3.16.jpg"
                }
            };
            return itemThumbs.Select(i => new object[] { i });
        }

        private static IEnumerable<object[]> GetXVideosTrans() {
            List<PornItemThumb> itemThumbs = new List<PornItemThumb> {
                // Fix the value "&amp;" in the title
                new PornItemThumb {
                    Source = PornSource.XVideos,
                    SexOrientation = PornSexOrientation.Trans,
                    Id = "/video18936599/venus_lux_pounds_tyra_scott_s_asshole",
                    Title = "Venus Lux Pounds Tyra Scott's Asshole",
                    Channel = new PornIdName {
                        Id = "/pornstar-channels/tsvenuslux",
                        Name = "Venus Lux"
                    },
                    ThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/d4/a2/a9/d4a2a9883dd4eb3866afdfcb46457f43/d4a2a9883dd4eb3866afdfcb46457f43.16.jpg"
                },
                new PornItemThumb {
                    Source = PornSource.XVideos,
                    SexOrientation = PornSexOrientation.Trans,
                    Id = "/video63886273/transerotica_trans_cutie_daisy_c_anal_fucked_by_kai_bailey",
                    Title = "TRANSEROTICA Trans Cutie Daisy C Anal Fucked By Kai Bailey",
                    Channel = new PornIdName {
                        Id = "/channels/transerotica",
                        Name = "Trans Erotica"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/b6/cd/56/b6cd5694ea43141af6c5263138498983/b6cd5694ea43141af6c5263138498983.24.jpg"
                },
                new PornItemThumb {
                    Source = PornSource.XVideos,
                    SexOrientation = PornSexOrientation.Trans,
                    Id = "/video64139835/carioca_da_pica_grossa_comecou_com_camisinha_depois_tirou_pra_sentir_no_pelo",
                    Title = "Carioca da pica grossa começou com camisinha depois tirou pra sentir no pelo",
                    Channel = new PornIdName {
                        Id = "/pornstar-channels/maria_flavia_ts",
                        Name = "Maria Flavia Ts"
                    },
                    ThumbnailUrl =
                        "https://img-l3.xvideos-cdn.com/videos/thumbs169ll/86/b3/7c/86b37cf8a6ada2e3eeef46277331c8f2/86b37cf8a6ada2e3eeef46277331c8f2.13.jpg"
                }
            };
            return itemThumbs.Select(i => new object[] { i });
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
