using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data
{
    public class PornVideoData : IEnumerable<object[]>
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
            List<PornVideo> videos = new List<PornVideo> {
                // Fix the value "&#039;" in the title
                new PornVideo {
                    Website = PornWebsite.Pornhub,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "ph5fc04dbacd1e6",
                    Title = "Valentine's Day Present is Double Fuck Threesome",
                    Channel = new PornIdName {
                        Id = "/model/miss-daisy-diamond",
                        Name = "Miss Daisy Diamond"
                    },
                    ThumbnailUrl = "https://ei.phncdn.com/videos/202011/27/374175402/original/(m=eaAaGwObaaaa)(mh=8mDb1m1o_9EAlB4k)14.jpg",
                    SmallThumbnailUrl =
                        "https://ci.phncdn.com/videos/202011/27/374175402/original/(m=eafTGgaaaa)(mh=AaHrhQhPfrLPy5_3)14.jpg",
                    PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5fc04dbacd1e6",
                    Duration = new TimeSpan(0, 27, 9),
                    Categories = new List<PornIdName> {
                        new PornIdName {
                            Id = "/video?c=3",
                            Name = "Amateur"
                        },
                        new PornIdName {
                            Id = "/video?c=7",
                            Name = "Big Dick"
                        },
                        new PornIdName {
                            Id = "/video?c=13",
                            Name = "Blowjob"
                        },
                        new PornIdName {
                            Id = "/video?c=115",
                            Name = "Exclusive"
                        },
                        new PornIdName {
                            Id = "/hd",
                            Name = "HD Porn"
                        },
                        new PornIdName {
                            Id = "/video?c=20",
                            Name = "Handjob"
                        },
                        new PornIdName {
                            Id = "/video?c=22",
                            Name = "Masturbation"
                        },
                        new PornIdName {
                            Id = "/video?c=42",
                            Name = "Red Head"
                        },
                        new PornIdName {
                            Id = "/video?c=59",
                            Name = "Small Tits"
                        },
                        new PornIdName {
                            Id = "/video?c=138",
                            Name = "Verified Amateurs"
                        }
                    },
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/video/search?search=amateur+teen",
                            Name = "Amateur Teen"
                        },
                        new PornIdName {
                            Id = "/video/search?search=mmf+threesome",
                            Name = "Mmf Threesome"
                        },
                        new PornIdName {
                            Id = "/video/search?search=limo+sex",
                            Name = "Limo Sex"
                        },
                        new PornIdName {
                            Id = "/video/search?search=domination",
                            Name = "Domination"
                        },
                        new PornIdName {
                            Id = "/video/search?search=deepthroat",
                            Name = "Deepthroat"
                        },
                        new PornIdName {
                            Id = "/video/search?search=cum+mouth",
                            Name = "Cum Mouth"
                        },
                        new PornIdName {
                            Id = "/video/search?search=redhead+teen",
                            Name = "Redhead Teen"
                        },
                        new PornIdName {
                            Id = "/video/search?search=penetration",
                            Name = "Penetration"
                        },
                        new PornIdName {
                            Id = "/video/search?search=tiny",
                            Name = "Tiny"
                        },
                        new PornIdName {
                            Id = "/video/search?search=missdaisydiamond",
                            Name = "Missdaisydiamond"
                        },
                        new PornIdName {
                            Id = "/video/search?search=cream",
                            Name = "Cream"
                        },
                        new PornIdName {
                            Id = "/video/search?search=load",
                            Name = "Load"
                        },
                        new PornIdName {
                            Id = "/video/search?search=hot+actions",
                            Name = "Hot Actions"
                        }
                    },
                    Actors = new List<PornIdName>(),
                    NbViews = 85557,
                    NbLikes = 308,
                    NbDislikes = 46,
                    Date = new DateTime(2021, 7, 31)
                },
                // Fix the value "\u00A0" in the title
                new PornVideo {
                    Website = PornWebsite.Pornhub,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "ph5d3c7d94e38f0",
                    Title = "Asuka loves ANAL babe cosplay ATM teen ass butt  pornstar Purple Bitch",
                    Channel = new PornIdName {
                        Id = "/model/purple-bitch",
                        Name = "Purple Bitch"
                    },
                    ThumbnailUrl = "https://di.phncdn.com/videos/201907/27/237967581/original/(m=eaAaGwObaaaa)(mh=ytHFxN6FIgeP-j3f)14.jpg",
                    SmallThumbnailUrl =
                        "https://ci.phncdn.com/videos/201907/27/237967581/original/(m=eafTGgaaaa)(mh=wsgEJN05BpMhMC7D)14.jpg",
                    PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5d3c7d94e38f0",
                    Duration = new TimeSpan(0, 10, 55),
                    Categories = new List<PornIdName> {
                        new PornIdName {
                            Id = "/video?c=105",
                            Name = "60FPS"
                        },
                        new PornIdName {
                            Id = "/video?c=3",
                            Name = "Amateur"
                        },
                        new PornIdName {
                            Id = "/video?c=35",
                            Name = "Anal"
                        },
                        new PornIdName {
                            Id = "/categories/babe",
                            Name = "Babe"
                        },
                        new PornIdName {
                            Id = "/video?c=4",
                            Name = "Big Ass"
                        },
                        new PornIdName {
                            Id = "/video?c=16",
                            Name = "Cumshot"
                        },
                        new PornIdName {
                            Id = "/hd",
                            Name = "HD Porn"
                        },
                        new PornIdName {
                            Id = "/video?c=562",
                            Name = "Tattooed Women"
                        },
                        new PornIdName {
                            Id = "/categories/teen",
                            Name = "Teen (18+)"
                        },
                        new PornIdName {
                            Id = "/video?c=138",
                            Name = "Verified Amateurs"
                        }
                    },
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/video/search?search=ass+fuck",
                            Name = "Ass Fuck"
                        },
                        new PornIdName {
                            Id = "/video?c=35",
                            Name = "Anal"
                        },
                        new PornIdName {
                            Id = "/video/search?search=teen",
                            Name = "Teen"
                        },
                        new PornIdName {
                            Id = "/categories/babe",
                            Name = "Babe"
                        },
                        new PornIdName {
                            Id = "/video/search?search=cute",
                            Name = "Cute"
                        },
                        new PornIdName {
                            Id = "/video?c=241",
                            Name = "Cosplay"
                        },
                        new PornIdName {
                            Id = "/video/search?search=asuka",
                            Name = "Asuka"
                        },
                        new PornIdName {
                            Id = "/video/search?search=big+ass+anal",
                            Name = "Big Ass Anal"
                        },
                        new PornIdName {
                            Id = "/video?c=4",
                            Name = "Big Ass"
                        },
                        new PornIdName {
                            Id = "/video/search?search=tattoo",
                            Name = "Tattoo"
                        },
                        new PornIdName {
                            Id = "/video/search?search=missionary",
                            Name = "Missionary"
                        },
                        new PornIdName {
                            Id = "/video/search?search=cowgirl",
                            Name = "Cowgirl"
                        },
                        new PornIdName {
                            Id = "/video/search?search=doggy+style",
                            Name = "Doggy Style"
                        },
                        new PornIdName {
                            Id = "/video/search?search=cum+in+mouth",
                            Name = "Cum In Mouth"
                        }
                    },
                    Actors = new List<PornIdName>(),
                    NbViews = 735402,
                    NbLikes = 3884,
                    NbDislikes = 708,
                    Date = new DateTime(2019, 7, 27)
                },
                // Fix no tags
                new PornVideo {
                    Website = PornWebsite.Pornhub,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "ph61d1f5079ab42",
                    Title = "hard pounding with a view of nice ass",
                    Channel = new PornIdName {
                        Id = "/model/stevenlucasxxx",
                        Name = "stevenlucasxxx"
                    },
                    ThumbnailUrl = "https://di.phncdn.com/videos/202201/02/400626481/original/(m=eaAaGwObaaaa)(mh=AZ_I8xVgFxXW6yjl)1.jpg",
                    SmallThumbnailUrl =
                        "https://di.phncdn.com/videos/202201/02/400626481/original/(m=eafTGgaaaa)(mh=9j4PqjygN1L2pill)1.jpg",
                    PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph61d1f5079ab42",
                    Duration = new TimeSpan(0, 0, 52),
                    Categories = new List<PornIdName> {
                        new PornIdName {
                            Id = "/video?c=13",
                            Name = "Blowjob"
                        },
                        new PornIdName {
                            Id = "/video?c=15",
                            Name = "Creampie"
                        },
                        new PornIdName {
                            Id = "/video?c=16",
                            Name = "Cumshot"
                        },
                        new PornIdName {
                            Id = "/video?c=115",
                            Name = "Exclusive"
                        },
                        new PornIdName {
                            Id = "/video?c=93",
                            Name = "Feet"
                        },
                        new PornIdName {
                            Id = "/hd",
                            Name = "HD Porn"
                        },
                        new PornIdName {
                            Id = "/video?c=138",
                            Name = "Verified Amateurs"
                        }
                    },
                    Tags = new List<PornIdName>(),
                    Actors = new List<PornIdName>(),
                    NbViews = 26872,
                    NbLikes = 5,
                    NbDislikes = 1,
                    Date = new DateTime(2022, 1, 2)
                },
                new PornVideo {
                    Website = PornWebsite.Pornhub,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "ph5a2f7e4f9c48a",
                    Title = "PropertySex - Hot property manager fucks pissed off tenant",
                    Channel = new PornIdName {
                        Id = "/channels/property-sex",
                        Name = "Property Sex"
                    },
                    ThumbnailUrl = "https://di.phncdn.com/videos/201712/12/145091652/original/(m=eaAaGwObaaaa)(mh=1_0bvB_2QRESJwUJ)3.jpg",
                    SmallThumbnailUrl =
                        "https://ei.phncdn.com/videos/201712/12/145091652/original/(m=eafTGgaaaa)(mh=dKfuDl_TV80fS7Wi)3.jpg",
                    PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5a2f7e4f9c48a",
                    Duration = new TimeSpan(0, 12, 0),
                    Categories = new List<PornIdName> {
                        new PornIdName {
                            Id = "/categories/babe",
                            Name = "Babe"
                        },
                        new PornIdName {
                            Id = "/video?c=4",
                            Name = "Big Ass"
                        },
                        new PornIdName {
                            Id = "/video?c=7",
                            Name = "Big Dick"
                        },
                        new PornIdName {
                            Id = "/video?c=8",
                            Name = "Big Tits"
                        },
                        new PornIdName {
                            Id = "/video?c=732",
                            Name = "Closed Captions"
                        },
                        new PornIdName {
                            Id = "/video?c=17",
                            Name = "Ebony"
                        },
                        new PornIdName {
                            Id = "/hd",
                            Name = "HD Porn"
                        },
                        new PornIdName {
                            Id = "/video?c=21",
                            Name = "Hardcore"
                        },
                        new PornIdName {
                            Id = "/video?c=41",
                            Name = "POV"
                        },
                        new PornIdName {
                            Id = "/popularwithwomen",
                            Name = "Popular With Women"
                        },
                        new PornIdName {
                            Id = "/categories/pornstar",
                            Name = "Pornstar"
                        },
                        new PornIdName {
                            Id = "/video?c=31",
                            Name = "Reality"
                        }
                    },
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/video/search?search=butt",
                            Name = "Butt"
                        },
                        new PornIdName {
                            Id = "/video/search?search=big+cock",
                            Name = "Big Cock"
                        },
                        new PornIdName {
                            Id = "/video/search?search=black",
                            Name = "Black"
                        },
                        new PornIdName {
                            Id = "/video/search?search=point+of+view",
                            Name = "Point Of View"
                        },
                        new PornIdName {
                            Id = "/video/search?search=tenant",
                            Name = "Tenant"
                        },
                        new PornIdName {
                            Id = "/video/search?search=harley+dean",
                            Name = "Harley Dean"
                        },
                        new PornIdName {
                            Id = "/video?c=13",
                            Name = "Blowjob"
                        },
                        new PornIdName {
                            Id = "/video/search?search=black+babe",
                            Name = "Black Babe"
                        },
                        new PornIdName {
                            Id = "/video?c=17",
                            Name = "Ebony"
                        },
                        new PornIdName {
                            Id = "/video?c=25",
                            Name = "Interracial"
                        },
                        new PornIdName {
                            Id = "/video?c=4",
                            Name = "Big Ass"
                        },
                        new PornIdName {
                            Id = "/video?c=41",
                            Name = "Pov"
                        },
                        new PornIdName {
                            Id = "/video?c=31",
                            Name = "Reality"
                        },
                        new PornIdName {
                            Id = "/video/search?search=facial",
                            Name = "Facial"
                        },
                        new PornIdName {
                            Id = "/video?c=16",
                            Name = "Cumshot"
                        },
                        new PornIdName {
                            Id = "/video/search?search=propertysex",
                            Name = "Propertysex"
                        }
                    },
                    Actors = new List<PornIdName> {
                        new PornIdName {
                            Id = "/pornstar/tony-rubino",
                            Name = "Tony Rubino"
                        },
                        new PornIdName {
                            Id = "/pornstar/harley-dean",
                            Name = "Harley Dean"
                        }
                    },
                    NbViews = 37412314,
                    NbLikes = 102562,
                    NbDislikes = 40631,
                    Date = new DateTime(2017, 12, 12)
                }
            };
            return videos.Select(i => new object[] { i });
        }

        private static IEnumerable<object[]> GetPornhubGay() {
            List<PornVideo> videos = new List<PornVideo> {
                // Fix the value "&#039;" in the title
                new PornVideo {
                    Website = PornWebsite.Pornhub,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "ph5d432ce7a448c",
                    Title = "GAYWIRE - Bar Addison Becomes Draven Navarro's Farm Fuck Boy",
                    Channel = new PornIdName {
                        Id = "/channels/gay-wire",
                        Name = "Gay Wire"
                    },
                    ThumbnailUrl = "https://di.phncdn.com/videos/201908/01/239007621/original/(m=eaAaGwObaaaa)(mh=6-925Q9Wh5OOgwfj)10.jpg",
                    SmallThumbnailUrl =
                        "https://ei.phncdn.com/videos/201908/01/239007621/original/(m=eafTGgaaaa)(mh=WYH3Zbs0FETrZK0h)10.jpg",
                    PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5d432ce7a448c",
                    Duration = new TimeSpan(0, 4, 5),
                    Categories = new List<PornIdName> {
                        new PornIdName {
                            Id = "/gay/video?c=252",
                            Name = "Amateur"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=58",
                            Name = "Big Dick"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=47",
                            Name = "Daddy"
                        },
                        new PornIdName {
                            Id = "/gayporn",
                            Name = "Gay"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=107",
                            Name = "HD Porn"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=70",
                            Name = "Hunks"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=51",
                            Name = "Muscle"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=60",
                            Name = "Pornstar"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=312",
                            Name = "Rough Sex"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=49",
                            Name = "Twink (18+)"
                        }
                    },
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/gay/video/search?search=gaywire",
                            Name = "Gaywire"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=pound+his+ass",
                            Name = "Pound His Ass"
                        },
                        new PornIdName {
                            Id = "/gayporn",
                            Name = "Gay"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=gay+anal",
                            Name = "Gay Anal"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=gay+sex",
                            Name = "Gay Sex"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=51",
                            Name = "Muscle"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=muscular",
                            Name = "Muscular"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=hunk",
                            Name = "Hunk"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=ranch",
                            Name = "Ranch"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=farm",
                            Name = "Farm"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=bar+addison",
                            Name = "Bar Addison"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=draven+navarro",
                            Name = "Draven Navarro"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=outdoors",
                            Name = "Outdoors"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=day+laborer",
                            Name = "Day Laborer"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=farmer",
                            Name = "Farmer"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=overalls",
                            Name = "Overalls"
                        }
                    },
                    Actors = new List<PornIdName> {
                        new PornIdName {
                            Id = "/pornstar/draven-navarro",
                            Name = "Draven Navarro"
                        }
                    },
                    NbViews = 134289,
                    NbLikes = 509,
                    NbDislikes = 162,
                    Date = new DateTime(2019, 8, 1)
                },
                new PornVideo {
                    Website = PornWebsite.Pornhub,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "ph60a518bb2da8a",
                    Title = "Marco Antonio, Pol Prince, Rafael Carreras, Joaquin Santana | Raw Foursome",
                    Channel = new PornIdName {
                        Id = "/channels/lucasentertainment",
                        Name = "Lucas Entertainment"
                    },
                    ThumbnailUrl = "https://di.phncdn.com/videos/202105/19/388272921/original/(m=eaAaGwObaaaa)(mh=FAmlwuMOegqg_ChD)11.jpg",
                    SmallThumbnailUrl =
                        "https://ci.phncdn.com/videos/202105/19/388272921/original/(m=eafTGgaaaa)(mh=fVKLwQqYceEaETFL)11.jpg",
                    PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph60a518bb2da8a",
                    Duration = new TimeSpan(0, 7, 48),
                    Categories = new List<PornIdName> {
                        new PornIdName {
                            Id = "/gay/video?c=40",
                            Name = "Bareback"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=58",
                            Name = "Big Dick"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=56",
                            Name = "Blowjob"
                        },
                        new PornIdName {
                            Id = "/gayporn",
                            Name = "Gay"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=62",
                            Name = "Group"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=107",
                            Name = "HD Porn"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=332",
                            Name = "Mature"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=51",
                            Name = "Muscle"
                        },
                        new PornIdName {
                            Id = "/categories/pornstar",
                            Name = "Pornstar"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=552",
                            Name = "Tattooed Men"
                        }
                    },
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/gay/video/search?search=lucasentertainment",
                            Name = "Gay Lucasentertainment"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=butthole",
                            Name = "Butthole"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=cum+in+mouth",
                            Name = "Cum In Mouth"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=big+dicks",
                            Name = "Gay Big Dicks"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=big+cocks",
                            Name = "Big Cocks"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=foursome",
                            Name = "Gay Foursome"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=assfuck",
                            Name = "Assfuck"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=big+cock",
                            Name = "Big Cock"
                        }
                    },
                    Actors = new List<PornIdName> {
                        new PornIdName {
                            Id = "/pornstar/rafael-carreras",
                            Name = "Rafael Carreras"
                        },
                        new PornIdName {
                            Id = "/pornstar/joaquin-santana",
                            Name = "Joaquin Santana"
                        }
                    },
                    NbViews = 92207,
                    NbLikes = 260,
                    NbDislikes = 30,
                    Date = new DateTime(2021, 5, 19)
                },
                new PornVideo {
                    Website = PornWebsite.Pornhub,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "ph610ecc9a8ca91",
                    Title = "Two cocks one toy Best friends do frotting together and cum HornyJohny66",
                    Channel = new PornIdName {
                        Id = "/model/hornyjohny66",
                        Name = "hornyjohny66"
                    },
                    ThumbnailUrl = "https://di.phncdn.com/videos/202108/07/392562291/thumbs_5/(m=eaAaGwObaaaa)(mh=EwnkTYRPaU2G-s9P)16.jpg",
                    SmallThumbnailUrl =
                        "https://di.phncdn.com/videos/202108/07/392562291/thumbs_5/(m=eafTGgaaaa)(mh=zrFKt_bp3k54N8-K)16.jpg",
                    PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph610ecc9a8ca91",
                    Duration = new TimeSpan(0, 11, 45),
                    Categories = new List<PornIdName> {
                        new PornIdName {
                            Id = "/gay/video?c=252",
                            Name = "Amateur"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=58",
                            Name = "Big Dick"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=352",
                            Name = "Cumshot"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=47",
                            Name = "Daddy"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=46",
                            Name = "Euro"
                        },
                        new PornIdName {
                            Id = "/gayporn",
                            Name = "Gay"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=107",
                            Name = "HD Porn"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=262",
                            Name = "Handjob"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=49",
                            Name = "Twink (18+)"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=731",
                            Name = "Verified Amateurs"
                        }
                    },
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/gay/video/search?search=cum",
                            Name = "Gay Cum"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=352",
                            Name = "Cumshot"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=frotting",
                            Name = "Frotting"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=frotting+cocks",
                            Name = "Gay Frotting Cocks"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=two+cocks",
                            Name = "Two Cocks"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=cock+rubbing+cock",
                            Name = "Cock Rubbing Cock"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=boy+moaning",
                            Name = "Boy Moaning"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=femboy",
                            Name = "Femboy"
                        },
                        new PornIdName {
                            Id = "/gay/video?c=49",
                            Name = "Gay Twink"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=amateur+couple",
                            Name = "Amateur Couple"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=best+friends",
                            Name = "Best Friends"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=frottage",
                            Name = "Frottage"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=big+cock",
                            Name = "Big Cock"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=homemade",
                            Name = "Homemade"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=cumming",
                            Name = "Cumming"
                        },
                        new PornIdName {
                            Id = "/gay/video/search?search=two+boys",
                            Name = "Two Boys"
                        }
                    },
                    Actors = new List<PornIdName>(),
                    NbViews = 36050,
                    NbLikes = 180,
                    NbDislikes = 10,
                    Date = new DateTime(2021, 8, 8)
                }
            };
            return videos.Select(i => new object[] { i });
        }

        private static IEnumerable<object[]> GetXVideosStraight() {
            List<PornVideo> videos = new List<PornVideo> {
                // Fix the value "&amp;" in the title
                new PornVideo {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "39773111",
                    Title = "Petite princess Sasha Rose fingers her delicious pink & rides her sex toy",
                    Channel = new PornIdName {
                        Id = "/pornworld_sexy_world",
                        Name = "Porn World Sexy World"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169lll/64/5a/cd/645acd983be57e6ca59f9389e13e5a69/645acd983be57e6ca59f9389e13e5a69.7.jpg",
                    SmallThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/64/5a/cd/645acd983be57e6ca59f9389e13e5a69/645acd983be57e6ca59f9389e13e5a69.7.jpg",
                    PageUrl =
                        "https://www.xvideos.com/video39773111/petite_princess_sasha_rose_fingers_her_delicious_pink_and_rides_her_sex_toy",
                    Duration = new TimeSpan(0, 17, 38),
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/tags/1by-day",
                            Name = "1by-day"
                        },
                        new PornIdName {
                            Id = "/tags/sasha-rose",
                            Name = "sasha-rose"
                        },
                        new PornIdName {
                            Id = "/tags/euro-porn",
                            Name = "euro-porn"
                        },
                        new PornIdName {
                            Id = "/tags/orgasm-porn",
                            Name = "orgasm-porn"
                        },
                        new PornIdName {
                            Id = "/tags/masturbation-porn",
                            Name = "masturbation-porn"
                        },
                        new PornIdName {
                            Id = "/tags/fingering-porn",
                            Name = "fingering-porn"
                        },
                        new PornIdName {
                            Id = "/tags/tease-porn",
                            Name = "tease-porn"
                        },
                        new PornIdName {
                            Id = "/tags/glamour-porn",
                            Name = "glamour-porn"
                        },
                        new PornIdName {
                            Id = "/tags/ddf-porn",
                            Name = "ddf-porn"
                        }
                    },
                    Actors = new List<PornIdName> {
                        new PornIdName {
                            Id = "/pornstar-channels/sasharoselive",
                            Name = "Sasha Rose"
                        }
                    },
                    NbViews = 267041,
                    NbLikes = 528,
                    NbDislikes = 27,
                    Date = new DateTime(2018, 9, 21)
                },
                // Fix the value "\u00A0" in the title
                new PornVideo {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "63965375",
                    Title = "Why is This Pussy Wet  Vol 72",
                    Channel = new PornIdName {
                        Id = "/ferame",
                        Name = "Ferame"
                    },
                    ThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169poster/25/12/97/25129756a8d056392608ce2a33f1cf03/25129756a8d056392608ce2a33f1cf03.4.jpg",
                    SmallThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/25/12/97/25129756a8d056392608ce2a33f1cf03/25129756a8d056392608ce2a33f1cf03.4.jpg",
                    PageUrl = "https://www.xvideos.com/video63965375/why_is_this_pussy_wet_vol_72",
                    Duration = new TimeSpan(0, 17, 43),
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/tags/pussy",
                            Name = "pussy"
                        },
                        new PornIdName {
                            Id = "/tags/amateur",
                            Name = "amateur"
                        },
                        new PornIdName {
                            Id = "/tags/squirt",
                            Name = "squirt"
                        },
                        new PornIdName {
                            Id = "/tags/asian",
                            Name = "asian"
                        },
                        new PornIdName {
                            Id = "/tags/pee",
                            Name = "pee"
                        },
                        new PornIdName {
                            Id = "/tags/japanese",
                            Name = "japanese"
                        },
                        new PornIdName {
                            Id = "/tags/piss",
                            Name = "piss"
                        }
                    },
                    Actors = new List<PornIdName>(),
                    NbViews = 42507,
                    NbLikes = 67,
                    NbDislikes = 50,
                    Date = new DateTime(2021, 7, 10)
                },
                // Fix no NbViews
                new PornVideo {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "64398615",
                    Title = "E-girl saborosa, apetitosa na manteiga",
                    Channel = new PornIdName {
                        Id = "/wasler",
                        Name = "Wasler"
                    },
                    ThumbnailUrl =
                        "https://img-cf.xvideos-cdn.com/videos/thumbs169poster/14/c7/14/14c714f1daf14b1859dbd9e1c8b5c4e3-2/14c714f1daf14b1859dbd9e1c8b5c4e3.27.jpg",
                    SmallThumbnailUrl =
                        "http://img-cf.xvideos-cdn.com/videos/thumbs169ll/14/c7/14/14c714f1daf14b1859dbd9e1c8b5c4e3-2/14c714f1daf14b1859dbd9e1c8b5c4e3.27.jpg",
                    PageUrl = "https://www.xvideos.com/video64398615/e-girl_saborosa_apetitosa_na_manteiga",
                    Duration = new TimeSpan(0, 0, 20),
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/tags/beautiful",
                            Name = "beautiful"
                        },
                        new PornIdName {
                            Id = "/tags/beauty",
                            Name = "beauty"
                        },
                        new PornIdName {
                            Id = "/tags/big-tits",
                            Name = "big-tits"
                        },
                        new PornIdName {
                            Id = "/tags/gostosa",
                            Name = "gostosa"
                        },
                        new PornIdName {
                            Id = "/tags/big-boobs",
                            Name = "big-boobs"
                        },
                        new PornIdName {
                            Id = "/tags/egirl",
                            Name = "egirl"
                        },
                        new PornIdName {
                            Id = "/tags/e-girl",
                            Name = "e-girl"
                        }
                    },
                    Actors = new List<PornIdName>(),
                    NbViews = 0,
                    NbLikes = 157,
                    NbDislikes = 39,
                    Date = new DateTime(2021, 7, 30)
                },
                new PornVideo {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "26195069",
                    Title = "Double penetrated gonzo babe facialized",
                    Channel = new PornIdName {
                        Id = "/darkxsite",
                        Name = "Darkxsite"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169lll/27/67/d4/2767d489b1eb14d7821e8df57b791a9d/2767d489b1eb14d7821e8df57b791a9d.20.jpg",
                    SmallThumbnailUrl =
                        "http://img-hw.xvideos-cdn.com/videos/thumbs169ll/27/67/d4/2767d489b1eb14d7821e8df57b791a9d/2767d489b1eb14d7821e8df57b791a9d.20.jpg",
                    PageUrl = "https://www.xvideos.com/video26195069/double_penetrated_gonzo_babe_facialized",
                    Duration = new TimeSpan(0, 7, 0),
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/tags/facial",
                            Name = "facial"
                        },
                        new PornIdName {
                            Id = "/tags/babe",
                            Name = "babe"
                        },
                        new PornIdName {
                            Id = "/tags/bikini",
                            Name = "bikini"
                        },
                        new PornIdName {
                            Id = "/tags/blowjob",
                            Name = "blowjob"
                        },
                        new PornIdName {
                            Id = "/tags/tattoo",
                            Name = "tattoo"
                        },
                        new PornIdName {
                            Id = "/tags/smalltits",
                            Name = "smalltits"
                        },
                        new PornIdName {
                            Id = "/tags/dp",
                            Name = "dp"
                        },
                        new PornIdName {
                            Id = "/tags/doublepenetration",
                            Name = "doublepenetration"
                        },
                        new PornIdName {
                            Id = "/tags/gonzo",
                            Name = "gonzo"
                        },
                        new PornIdName {
                            Id = "/tags/dicksucking",
                            Name = "dicksucking"
                        },
                        new PornIdName {
                            Id = "/tags/roughsex",
                            Name = "roughsex"
                        },
                        new PornIdName {
                            Id = "/tags/assfucking",
                            Name = "assfucking"
                        },
                        new PornIdName {
                            Id = "/tags/threeway",
                            Name = "threeway"
                        },
                        new PornIdName {
                            Id = "/tags/facefucking",
                            Name = "facefucking"
                        },
                        new PornIdName {
                            Id = "/tags/chokeplay",
                            Name = "chokeplay"
                        }
                    },
                    Actors = new List<PornIdName> {
                        new PornIdName {
                            Id = "/pornstars/megan-rain",
                            Name = "Megan Rain"
                        }
                    },
                    NbViews = 717980,
                    NbLikes = 922,
                    NbDislikes = 363,
                    Date = new DateTime(2017, 2, 1)
                },
                new PornVideo {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "63909971",
                    Title = "(Raul Costa) Waits With His Big Cock Out For Petite (Josephine Jackson) To Finish Her Yoga - Reality Kings",
                    Channel = new PornIdName {
                        Id = "/reality-kings-channel",
                        Name = "Reality Kings"
                    },
                    ThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169poster/e8/c3/b8/e8c3b880587e7e64cc3ace8b81645721/e8c3b880587e7e64cc3ace8b81645721.30.jpg",
                    SmallThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/e8/c3/b8/e8c3b880587e7e64cc3ace8b81645721/e8c3b880587e7e64cc3ace8b81645721.30.jpg",
                    PageUrl =
                        "https://www.xvideos.com/video63909971/_raul_costa_waits_with_his_big_cock_out_for_petite_josephine_jackson_to_finish_her_yoga_-_reality_kings",
                    Duration = new TimeSpan(0, 11, 11),
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/tags/facial",
                            Name = "facial"
                        },
                        new PornIdName {
                            Id = "/tags/blowjob",
                            Name = "blowjob"
                        },
                        new PornIdName {
                            Id = "/tags/doggystyle",
                            Name = "doggystyle"
                        },
                        new PornIdName {
                            Id = "/tags/missionary",
                            Name = "missionary"
                        },
                        new PornIdName {
                            Id = "/tags/stretching",
                            Name = "stretching"
                        },
                        new PornIdName {
                            Id = "/tags/pussy-eating",
                            Name = "pussy-eating"
                        },
                        new PornIdName {
                            Id = "/tags/reverse-cowgirl",
                            Name = "reverse-cowgirl"
                        },
                        new PornIdName {
                            Id = "/tags/big-cock",
                            Name = "big-cock"
                        },
                        new PornIdName {
                            Id = "/tags/yoga",
                            Name = "yoga"
                        },
                        new PornIdName {
                            Id = "/tags/big-boobs",
                            Name = "big-boobs"
                        },
                        new PornIdName {
                            Id = "/tags/deephtroat",
                            Name = "deephtroat"
                        },
                        new PornIdName {
                            Id = "/tags/titty-fuck",
                            Name = "titty-fuck"
                        },
                        new PornIdName {
                            Id = "/tags/big-booty",
                            Name = "big-booty"
                        },
                        new PornIdName {
                            Id = "/tags/reality-kings",
                            Name = "reality-kings"
                        },
                        new PornIdName {
                            Id = "/tags/hot-milf",
                            Name = "hot-milf"
                        },
                        new PornIdName {
                            Id = "/tags/side-fuck",
                            Name = "side-fuck"
                        },
                        new PornIdName {
                            Id = "/tags/petite-brunette",
                            Name = "petite-brunette"
                        },
                        new PornIdName {
                            Id = "/tags/rk-prime",
                            Name = "rk-prime"
                        }
                    },
                    Actors = new List<PornIdName> {
                        new PornIdName {
                            Id = "/pornstars/josephine-jackson",
                            Name = "Josephine Jackson"
                        }
                    },
                    NbViews = 1407786,
                    NbLikes = 3800,
                    NbDislikes = 2000,
                    Date = new DateTime(2021, 7, 6)
                }
            };
            return videos.Select(i => new object[] { i });
        }

        private static IEnumerable<object[]> GetXVideosGay() {
            List<PornVideo> videos = new List<PornVideo> {
                // Fix the value "&amp;" in the title
                new PornVideo {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "63543339",
                    Title = "Fireworks In His Ass For Day",
                    Channel = new PornIdName {
                        Id = "/youngperps",
                        Name = "YoungPerps"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169poster/5d/00/30/5d003011fae8c3df1c3bb9529c7dbeff/5d003011fae8c3df1c3bb9529c7dbeff.24.jpg",
                    SmallThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/5d/00/30/5d003011fae8c3df1c3bb9529c7dbeff/5d003011fae8c3df1c3bb9529c7dbeff.24.jpg",
                    PageUrl = "https://www.xvideos.com/video63543339/fireworks_in_his_ass_for_day",
                    Duration = new TimeSpan(0, 14, 07),
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/tags/t:gay/anal",
                            Name = "anal"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/cum",
                            Name = "cum"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/teen",
                            Name = "teen"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/hardcore",
                            Name = "hardcore"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/blowjob",
                            Name = "blowjob"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/gay",
                            Name = "gay"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/muscle",
                            Name = "muscle"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/twink",
                            Name = "twink"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/bareback",
                            Name = "bareback"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/bear",
                            Name = "bear"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/big-dick",
                            Name = "big-dick"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/huge-cock",
                            Name = "huge-cock"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/step-dad",
                            Name = "step-dad"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/gay-sex",
                            Name = "gay-sex"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/step-brother",
                            Name = "step-brother"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/drake-magnum",
                            Name = "drake-magnum"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/austin-xanders",
                            Name = "austin-xanders"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/alex-killian",
                            Name = "alex-killian"
                        }
                    },
                    Actors = new List<PornIdName> {
                        new PornIdName() {
                            Id = "/pornstar-channels/alexkillian",
                            Name = "Alex Killian"
                        }
                    },
                    NbViews = 105551,
                    NbLikes = 320,
                    NbDislikes = 132,
                    Date = new DateTime(2021, 6, 16)
                },
                // Fix the value "\u00A0" in the title
                new PornVideo {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "7859351",
                    Title = "Gay orgy   They're loving it so much, in fact, that they just can't",
                    Channel = new PornIdName {
                        Id = "/analgayfetish",
                        Name = "Analgayfetish"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169lll/12/9e/9c/129e9c59afac7c1afc2729e7b916ad6f/129e9c59afac7c1afc2729e7b916ad6f.15.jpg",
                    SmallThumbnailUrl =
                        "http://img-hw.xvideos-cdn.com/videos/thumbs169ll/12/9e/9c/129e9c59afac7c1afc2729e7b916ad6f/129e9c59afac7c1afc2729e7b916ad6f.15.jpg",
                    PageUrl = "https://www.xvideos.com/video7859351/gay_orgy_they_re_loving_it_so_much_in_fact_that_they_just_can_t",
                    Duration = new TimeSpan(0, 5, 33),
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/tags/t:gay/gay",
                            Name = "gay"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/twink",
                            Name = "twink"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/twinks",
                            Name = "twinks"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/gaysex",
                            Name = "gaysex"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/gayporn",
                            Name = "gayporn"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/gay-hardcore",
                            Name = "gay-hardcore"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/gay-blowjob",
                            Name = "gay-blowjob"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/gay-anal",
                            Name = "gay-anal"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/",
                            Name = ""
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/gay-dudes",
                            Name = "gay-dudes"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/gaydudes",
                            Name = "gaydudes"
                        }
                    },
                    Actors = new List<PornIdName>(),
                    NbViews = 6675,
                    NbLikes = 1,
                    NbDislikes = 0,
                    Date = new DateTime(2014, 4, 30)
                },
                new PornVideo {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "59864125",
                    Title = "Quiet Top gets Some Sloppy Head",
                    Channel = new PornIdName {
                        Id = "/finn-phillips",
                        Name = "Finn Phillips"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169poster/f3/b5/11/f3b511b10de81bc6abd730a02b914b42/f3b511b10de81bc6abd730a02b914b42.19.jpg",
                    SmallThumbnailUrl =
                        "http://img-hw.xvideos-cdn.com/videos/thumbs169ll/f3/b5/11/f3b511b10de81bc6abd730a02b914b42/f3b511b10de81bc6abd730a02b914b42.19.jpg",
                    PageUrl = "https://www.xvideos.com/video59864125/quiet_top_gets_some_sloppy_head",
                    Duration = new TimeSpan(0, 11, 29),
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/tags/t:gay/cum",
                            Name = "cum"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/hot",
                            Name = "hot"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/sucking",
                            Name = "sucking"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/interracial",
                            Name = "interracial"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/blowjob",
                            Name = "blowjob"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/slut",
                            Name = "slut"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/clothed",
                            Name = "clothed"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/deepthroat",
                            Name = "deepthroat"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/college",
                            Name = "college"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/gay",
                            Name = "gay"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/sub",
                            Name = "sub"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/dom",
                            Name = "dom"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/sloppy",
                            Name = "sloppy"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/big-cock",
                            Name = "big-cock"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/big-dick",
                            Name = "big-dick"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/black-cock",
                            Name = "black-cock"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/gay-blowjob",
                            Name = "gay-blowjob"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/gay-porn",
                            Name = "gay-porn"
                        }
                    },
                    Actors = new List<PornIdName>(),
                    NbViews = 73931,
                    NbLikes = 142,
                    NbDislikes = 38,
                    Date = new DateTime(2020, 12, 14)
                },
                new PornVideo {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "9390594",
                    Title = "Johnny Rapids orgy cumshot on a boat",
                    Channel = new PornIdName {
                        Id = "/menofuk",
                        Name = "Men Of Uk"
                    },
                    ThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169lll/b0/1e/c9/b01ec9383c300cf4bf21ff3745f3f6a3/b01ec9383c300cf4bf21ff3745f3f6a3.16.jpg",
                    SmallThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/b0/1e/c9/b01ec9383c300cf4bf21ff3745f3f6a3/b01ec9383c300cf4bf21ff3745f3f6a3.16.jpg",
                    PageUrl = "https://www.xvideos.com/video9390594/johnny_rapids_orgy_cumshot_on_a_boat",
                    Duration = new TimeSpan(0, 5, 59),
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/tags/t:gay/anal",
                            Name = "anal"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/cumshot",
                            Name = "cumshot"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/outdoor",
                            Name = "outdoor"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/blowjob",
                            Name = "blowjob"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/masturbation",
                            Name = "masturbation"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/groupsex",
                            Name = "groupsex"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/gay",
                            Name = "gay"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/orgy",
                            Name = "orgy"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/homosexual",
                            Name = "homosexual"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/muscular",
                            Name = "muscular"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/muscular",
                            Name = "muscular"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/hunk",
                            Name = "hunk"
                        },
                        new PornIdName {
                            Id = "/tags/t:gay/gaysex",
                            Name = "gaysex"
                        }
                    },
                    Actors = new List<PornIdName> {
                        new PornIdName {
                            Id = "/pornstars/johnny-rapid-1",
                            Name = "Johnny Rapid"
                        }
                    },
                    NbViews = 859997,
                    NbLikes = 1300,
                    NbDislikes = 337,
                    Date = new DateTime(2014, 10, 21)
                }
            };
            return videos.Select(i => new object[] { i });
        }

        private static IEnumerable<object[]> GetXVideosTrans() {
            List<PornVideo> videos = new List<PornVideo> {
                // Fix the value "&amp;" in the title
                new PornVideo {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Trans,
                    Id = "18936599",
                    Title = "Venus Lux Pounds Tyra Scott's Asshole",
                    Channel = new PornIdName {
                        Id = "/tsvenuslux",
                        Name = "Venus Lux"
                    },
                    ThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169lll/d4/a2/a9/d4a2a9883dd4eb3866afdfcb46457f43/d4a2a9883dd4eb3866afdfcb46457f43.16.jpg",
                    SmallThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/d4/a2/a9/d4a2a9883dd4eb3866afdfcb46457f43/d4a2a9883dd4eb3866afdfcb46457f43.16.jpg",
                    PageUrl = "https://www.xvideos.com/video18936599/venus_lux_pounds_tyra_scott_s_asshole",
                    Duration = new TimeSpan(0, 6, 11),
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/tags/t:shemale/anal",
                            Name = "anal"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/hardcore",
                            Name = "hardcore"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/blowjob",
                            Name = "blowjob"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/shaved",
                            Name = "shaved"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/asian",
                            Name = "asian"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/shemale",
                            Name = "shemale"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/transsexual",
                            Name = "transsexual"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/tgirl",
                            Name = "tgirl"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/cum-shot",
                            Name = "cum-shot"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/cum-on-tits",
                            Name = "cum-on-tits"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/venus-lux",
                            Name = "venus-lux"
                        }
                    },
                    Actors = new List<PornIdName> {
                        new PornIdName {
                            Id = "/pornstars/tyra-scott",
                            Name = "Tyra Scott"
                        }
                    },
                    NbViews = 349157,
                    NbLikes = 359,
                    NbDislikes = 93,
                    Date = new DateTime(2016, 2, 24)
                },
                new PornVideo {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Trans,
                    Id = "63886273",
                    Title = "TRANSEROTICA Trans Cutie Daisy C Anal Fucked By Kai Bailey",
                    Channel = new PornIdName {
                        Id = "/transerotica",
                        Name = "Trans Erotica"
                    },
                    ThumbnailUrl =
                        "https://img-hw.xvideos-cdn.com/videos/thumbs169poster/b6/cd/56/b6cd5694ea43141af6c5263138498983/b6cd5694ea43141af6c5263138498983.24.jpg",
                    SmallThumbnailUrl =
                        "http://img-hw.xvideos-cdn.com/videos/thumbs169ll/b6/cd/56/b6cd5694ea43141af6c5263138498983/b6cd5694ea43141af6c5263138498983.24.jpg",
                    PageUrl = "https://www.xvideos.com/video63886273/transerotica_trans_cutie_daisy_c_anal_fucked_by_kai_bailey",
                    Duration = new TimeSpan(0, 10, 0),
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/tags/t:shemale/anal",
                            Name = "anal"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/stockings",
                            Name = "stockings"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/cumshot",
                            Name = "cumshot"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/blowjob",
                            Name = "blowjob"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/riding",
                            Name = "riding"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/shemale",
                            Name = "shemale"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/transsexual",
                            Name = "transsexual"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/transgender",
                            Name = "transgender"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/rimming",
                            Name = "rimming"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/big-cock",
                            Name = "big-cock"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/big-dick",
                            Name = "big-dick"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/small-tits",
                            Name = "small-tits"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/transerotica",
                            Name = "transerotica"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/kai-bailey",
                            Name = "kai-bailey"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/daisy-c",
                            Name = "daisy-c"
                        }
                    },
                    Actors = new List<PornIdName> {
                        new PornIdName {
                            Id = "/models/kai-bailey1",
                            Name = "Kai Bailey"
                        }
                    },
                    NbViews = 320062,
                    NbLikes = 1300,
                    NbDislikes = 250,
                    Date = new DateTime(2021, 7, 5)
                },
                new PornVideo {
                    Website = PornWebsite.XVideos,
                    SexOrientation = PornSexOrientation.Trans,
                    Id = "64139835",
                    Title = "Carioca da pica grossa começou com camisinha depois tirou pra sentir no pelo",
                    Channel = new PornIdName {
                        Id = "/maria_flavia_ts",
                        Name = "Maria Flavia Ts"
                    },
                    ThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169poster/86/b3/7c/86b37cf8a6ada2e3eeef46277331c8f2/86b37cf8a6ada2e3eeef46277331c8f2.13.jpg",
                    SmallThumbnailUrl =
                        "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/86/b3/7c/86b37cf8a6ada2e3eeef46277331c8f2/86b37cf8a6ada2e3eeef46277331c8f2.13.jpg",
                    PageUrl =
                        "https://www.xvideos.com/video64139835/carioca_da_pica_grossa_comecou_com_camisinha_depois_tirou_pra_sentir_no_pelo",
                    Duration = new TimeSpan(0, 6, 3),
                    Tags = new List<PornIdName> {
                        new PornIdName {
                            Id = "/tags/t:shemale/porno",
                            Name = "porno"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/big",
                            Name = "big"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/shemale",
                            Name = "shemale"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/big-ass",
                            Name = "big-ass"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/amateurs",
                            Name = "amateurs"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/big-tits",
                            Name = "big-tits"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/bareback",
                            Name = "bareback"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/big-cock",
                            Name = "big-cock"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/big-dick",
                            Name = "big-dick"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/big-boobs",
                            Name = "big-boobs"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/bbc",
                            Name = "bbc"
                        },
                        new PornIdName {
                            Id = "/tags/t:shemale/nopelo",
                            Name = "nopelo"
                        }
                    },
                    Actors = new List<PornIdName>(),
                    NbViews = 281052,
                    NbLikes = 768,
                    NbDislikes = 315,
                    Date = new DateTime(2021, 7, 18)
                }
            };
            return videos.Select(i => new object[] { i });
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
