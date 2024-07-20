using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data;

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
        List<PornVideo> videos = new List<PornVideo> {
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
                ThumbnailUrl =
                    "https://ei.phncdn.com/videos/202402/19/448361951/original/(m=qRNTS9YbeaAaGwObaaaa)(mh=p5MhwVtGUeUq8W3v)0.jpg",
                SmallThumbnailUrl =
                    "https://ei.phncdn.com/videos/202402/19/448361951/original/(m=qRNTS9YbeafTGgaaaa)(mh=IxAiwQ6q2a7uiMZ1)0.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=65d3064b91914",
                VideoEmbedUrl = "https://www.pornhub.com/embed/65d3064b91914",
                Duration = new TimeSpan(0, 22, 22),
                Categories = new List<PornIdName> {
                    new() {
                        Id = "/video?c=105",
                        Name = "60FPS"
                    },
                    new() {
                        Id = "/video?c=3",
                        Name = "Amateur"
                    },
                    new() {
                        Id = "/categories/babe",
                        Name = "Babe"
                    },
                    new() {
                        Id = "/video?c=7",
                        Name = "Big Dick"
                    },
                    new() {
                        Id = "/video?c=16",
                        Name = "Cumshot"
                    },
                    new() {
                        Id = "/video?c=115",
                        Name = "Exclusive"
                    },
                    new() {
                        Id = "/video?c=502",
                        Name = "Female Orgasm"
                    },
                    new() {
                        Id = "/hd",
                        Name = "HD Porn"
                    },
                    new() {
                        Id = "/video?c=21",
                        Name = "Hardcore"
                    },
                    new() {
                        Id = "/categories/teen",
                        Name = "Teen (18+)"
                    },
                    new() {
                        Id = "/video?c=138",
                        Name = "Verified Amateurs"
                    },
                    new() {
                        Id = "/video?c=482",
                        Name = "Verified Couples"
                    }
                },
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/video/search?search=petite",
                        Name = "Petite"
                    },
                    new() {
                        Id = "/video/search?search=brunette",
                        Name = "Brunette"
                    },
                    new() {
                        Id = "/video/search?search=big+boobs",
                        Name = "Big Boobs"
                    },
                    new() {
                        Id = "/video/search?search=big+dick",
                        Name = "Big Dick"
                    },
                    new() {
                        Id = "/video/search?search=tight+pussy",
                        Name = "Tight Pussy"
                    },
                    new() {
                        Id = "/video/search?search=pov",
                        Name = "Pov"
                    },
                    new() {
                        Id = "/video/search?search=blowjob",
                        Name = "Blowjob"
                    },
                    new() {
                        Id = "/video/search?search=missionary",
                        Name = "Missionary"
                    },
                    new() {
                        Id = "/video/search?search=red+lingerie",
                        Name = "Red Lingerie"
                    },
                    new() {
                        Id = "/video/search?search=gorgeous+girl",
                        Name = "Gorgeous Girl"
                    },
                    new() {
                        Id = "/video/search?search=shaved+pussy",
                        Name = "Shaved Pussy"
                    },
                    new() {
                        Id = "/video/search?search=busty",
                        Name = "Busty"
                    },
                    new() {
                        Id = "/video/search?search=cowgirl",
                        Name = "Cowgirl"
                    },
                    new() {
                        Id = "/video/search?search=female+orgasm",
                        Name = "Female Orgasm"
                    },
                    new() {
                        Id = "/video/search?search=cumshot",
                        Name = "Cumshot"
                    }
                },
                Actors = new List<PornIdName>(),
                NbViews = 1947562,
                NbLikes = 3934,
                NbDislikes = 378,
                Date = new DateTime(2024, 2, 19)
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
                ThumbnailUrl = "https://di.phncdn.com/videos/201907/27/237967581/original/(m=eaAaGwObaaaa)(mh=ytHFxN6FIgeP-j3f)14.jpg",
                SmallThumbnailUrl = "https://ci.phncdn.com/videos/201907/27/237967581/original/(m=eafTGgaaaa)(mh=wsgEJN05BpMhMC7D)14.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5d3c7d94e38f0",
                VideoEmbedUrl = "https://www.pornhub.com/embed/ph5d3c7d94e38f0",
                Duration = new TimeSpan(0, 10, 55),
                Categories = new List<PornIdName> {
                    new() {
                        Id = "/video?c=105",
                        Name = "60FPS"
                    },
                    new() {
                        Id = "/video?c=3",
                        Name = "Amateur"
                    },
                    new() {
                        Id = "/video?c=35",
                        Name = "Anal"
                    },
                    new() {
                        Id = "/categories/babe",
                        Name = "Babe"
                    },
                    new() {
                        Id = "/video?c=4",
                        Name = "Big Ass"
                    },
                    new() {
                        Id = "/video?c=16",
                        Name = "Cumshot"
                    },
                    new() {
                        Id = "/hd",
                        Name = "HD Porn"
                    },
                    new() {
                        Id = "/video?c=562",
                        Name = "Tattooed Women"
                    },
                    new() {
                        Id = "/categories/teen",
                        Name = "Teen (18+)"
                    },
                    new() {
                        Id = "/video?c=138",
                        Name = "Verified Amateurs"
                    }
                },
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/video/search?search=ass+fuck",
                        Name = "Ass Fuck"
                    },
                    new() {
                        Id = "/video?c=35",
                        Name = "Anal"
                    },
                    new() {
                        Id = "/video/search?search=teen",
                        Name = "Teen"
                    },
                    new() {
                        Id = "/categories/babe",
                        Name = "Babe"
                    },
                    new() {
                        Id = "/video/search?search=cute",
                        Name = "Cute"
                    },
                    new() {
                        Id = "/video?c=241",
                        Name = "Cosplay"
                    },
                    new() {
                        Id = "/video/search?search=asuka",
                        Name = "Asuka"
                    },
                    new() {
                        Id = "/video/search?search=big+ass+anal",
                        Name = "Big Ass Anal"
                    },
                    new() {
                        Id = "/video?c=4",
                        Name = "Big Ass"
                    },
                    new() {
                        Id = "/video/search?search=tattoo",
                        Name = "Tattoo"
                    },
                    new() {
                        Id = "/video/search?search=missionary",
                        Name = "Missionary"
                    },
                    new() {
                        Id = "/video/search?search=cowgirl",
                        Name = "Cowgirl"
                    },
                    new() {
                        Id = "/video/search?search=doggy+style",
                        Name = "Doggy Style"
                    },
                    new() {
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
            new() {
                Website = PornWebsite.Pornhub,
                SexOrientation = PornSexOrientation.Straight,
                Id = "ph61d1f5079ab42",
                Title = "hard pounding with a view of nice ass",
                Channel = new PornIdName {
                    Id = "/model/stevenlucasxxx",
                    Name = "stevenlucasxxx"
                },
                ThumbnailUrl = "https://di.phncdn.com/videos/202201/02/400626481/original/(m=eaAaGwObaaaa)(mh=AZ_I8xVgFxXW6yjl)1.jpg",
                SmallThumbnailUrl = "https://di.phncdn.com/videos/202201/02/400626481/original/(m=eafTGgaaaa)(mh=9j4PqjygN1L2pill)1.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph61d1f5079ab42",
                VideoEmbedUrl = "https://www.pornhub.com/embed/ph61d1f5079ab42",
                Duration = new TimeSpan(0, 0, 52),
                Categories = new List<PornIdName> {
                    new() {
                        Id = "/video?c=13",
                        Name = "Blowjob"
                    },
                    new() {
                        Id = "/video?c=15",
                        Name = "Creampie"
                    },
                    new() {
                        Id = "/video?c=16",
                        Name = "Cumshot"
                    },
                    new() {
                        Id = "/video?c=115",
                        Name = "Exclusive"
                    },
                    new() {
                        Id = "/video?c=93",
                        Name = "Feet"
                    },
                    new() {
                        Id = "/hd",
                        Name = "HD Porn"
                    },
                    new() {
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
            // Example Free Premium
            new() {
                Website = PornWebsite.Pornhub,
                SexOrientation = PornSexOrientation.Straight,
                Id = "63dd6adb2b748",
                Title = "\"Say you wanna fuck your stepmom, we can have a three way. I need some dick.\" says Scarlett Alexis",
                Channel = new PornIdName {
                    Id = "/channels/mom-lover",
                    Name = "Mom Lover"
                },
                ThumbnailUrl =
                    "https://ei.phncdn.com/videos/202302/03/424738341/original/(m=q153L_XbeaAaGwObaaaa)(mh=B8NCaQEnRfyaYhgf)0.jpg",
                SmallThumbnailUrl =
                    "https://ei.phncdn.com/videos/202302/03/424738341/original/(m=q153L_XbeafTGgaaaa)(mh=lY6Vtk9KLFfaHy2T)0.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=63dd6adb2b748",
                VideoEmbedUrl = "https://www.pornhub.com/embed/63dd6adb2b748",
                Duration = new TimeSpan(0, 24, 56),
                Categories = new List<PornIdName> {
                    new() {
                        Id = "/video?c=9",
                        Name = "Blonde"
                    },
                    new() {
                        Id = "/video?c=13",
                        Name = "Blowjob"
                    },
                    new() {
                        Id = "/video?c=11",
                        Name = "Brunette"
                    },
                    new() {
                        Id = "/video?c=16",
                        Name = "Cumshot"
                    },
                    new() {
                        Id = "/video?c=761",
                        Name = "FFM in Threesome"
                    },
                    new() {
                        Id = "/hd",
                        Name = "HD Porn"
                    },
                    new() {
                        Id = "/video?c=21",
                        Name = "Hardcore"
                    },
                    new() {
                        Id = "/categories/pornstar",
                        Name = "Pornstar"
                    },
                    new() {
                        Id = "/video?c=444",
                        Name = "Step Fantasy"
                    },
                    new() {
                        Id = "/video?c=65",
                        Name = "Threesome"
                    }
                },
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/video/search?search=momlover",
                        Name = "Momlover"
                    },
                    new() {
                        Id = "/video/search?search=scarlett+alexis",
                        Name = "Scarlett Alexis"
                    },
                    new() {
                        Id = "/video/search?search=crystal+clark",
                        Name = "Crystal Clark"
                    },
                    new() {
                        Id = "/video/search?search=hot+brunette",
                        Name = "Hot Brunette"
                    },
                    new() {
                        Id = "/video?c=29",
                        Name = "Milf"
                    },
                    new() {
                        Id = "/video/search?search=hot+blonde",
                        Name = "Hot Blonde"
                    },
                    new() {
                        Id = "/video?c=8",
                        Name = "Big Tits"
                    },
                    new() {
                        Id = "/video/search?search=double+blowjob",
                        Name = "Double Blowjob"
                    },
                    new() {
                        Id = "/video/search?search=reverse+cowgirl",
                        Name = "Reverse Cowgirl"
                    },
                    new() {
                        Id = "/video/search?search=stepmom",
                        Name = "Stepmom"
                    },
                    new() {
                        Id = "/video/search?search=stepson",
                        Name = "Stepson"
                    },
                    new() {
                        Id = "/video?c=65",
                        Name = "Threesome"
                    },
                    new() {
                        Id = "/video/search?search=girl+masturbating",
                        Name = "Girl Masturbating"
                    },
                    new() {
                        Id = "/video?c=502",
                        Name = "Female Orgasm"
                    },
                    new() {
                        Id = "/video/search?search=doggystyle",
                        Name = "Doggystyle"
                    },
                    new() {
                        Id = "/video?c=16",
                        Name = "Cumshot"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/pornstar/crystal-clark",
                        Name = "Crystal Clark"
                    },
                    new() {
                        Id = "/pornstar/ricky-spanish",
                        Name = "Ricky Spanish"
                    },
                    new() {
                        Id = "/pornstar/scarlett-alexis",
                        Name = "Scarlett Alexis"
                    }
                },
                NbViews = 2196054,
                NbLikes = 3426,
                NbDislikes = 355,
                Date = new DateTime(2023, 2, 3)
            },
            // Example not video embed but not free premium
            new() {
                Website = PornWebsite.Pornhub,
                SexOrientation = PornSexOrientation.Straight,
                Id = "ph5de7d12f4fa33",
                Title = "Her Limit - Petite Latina Veronica Leal Hardcore Anal & Squirting LETSDOEIT",
                Channel = new PornIdName {
                    Id = "/channels/her-limit",
                    Name = "Her Limit"
                },
                ThumbnailUrl =
                    "https://ei.phncdn.com/videos/201912/04/266219572/original/(m=qYM_X-UbeaAaGwObaaaa)(mh=eoFZ8O7TBdh7ecWO)0.jpg",
                SmallThumbnailUrl =
                    "https://ei.phncdn.com/videos/201912/04/266219572/original/(m=qYM_X-UbeafTGgaaaa)(mh=e3lWEA-PsF7CAmbK)0.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5de7d12f4fa33",
                VideoEmbedUrl = "https://www.pornhub.com/embed/ph5de7d12f4fa33",
                Duration = new TimeSpan(0, 10, 10),
                Categories = new List<PornIdName> {
                    new() {
                        Id = "/video?c=35",
                        Name = "Anal"
                    },
                    new() {
                        Id = "/video?c=7",
                        Name = "Big Dick"
                    },
                    new() {
                        Id = "/video?c=502",
                        Name = "Female Orgasm"
                    },
                    new() {
                        Id = "/hd",
                        Name = "HD Porn"
                    },
                    new() {
                        Id = "/video?c=21",
                        Name = "Hardcore"
                    },
                    new() {
                        Id = "/video?c=26",
                        Name = "Latina"
                    },
                    new() {
                        Id = "/categories/pornstar",
                        Name = "Pornstar"
                    },
                    new() {
                        Id = "/video?c=42",
                        Name = "Red Head"
                    },
                    new() {
                        Id = "/video?c=67",
                        Name = "Rough Sex"
                    },
                    new() {
                        Id = "/video?c=69",
                        Name = "Squirt"
                    },
                    new() {
                        Id = "/video?c=23",
                        Name = "Toys"
                    }
                },
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/video/search?search=herlimit",
                        Name = "Herlimit"
                    },
                    new() {
                        Id = "/video/search?search=ass+fuck",
                        Name = "Ass Fuck"
                    },
                    new() {
                        Id = "/video/search?search=rough",
                        Name = "Rough"
                    },
                    new() {
                        Id = "/video/search?search=orgasm",
                        Name = "Orgasm"
                    },
                    new() {
                        Id = "/video/search?search=squirting",
                        Name = "Squirting"
                    },
                    new() {
                        Id = "/video/search?search=adult+toys",
                        Name = "Adult Toys"
                    },
                    new() {
                        Id = "/video/search?search=anal+gape",
                        Name = "Anal Gape"
                    },
                    new() {
                        Id = "/video/search?search=natural+tits",
                        Name = "Natural Tits"
                    },
                    new() {
                        Id = "/video/search?search=piss",
                        Name = "Piss"
                    },
                    new() {
                        Id = "/video/search?search=shivering+orgasm",
                        Name = "Shivering Orgasm"
                    },
                    new() {
                        Id = "/video/search?search=cum+mouth",
                        Name = "Cum Mouth"
                    },
                    new() {
                        Id = "/video/search?search=anal+fisting",
                        Name = "Anal Fisting"
                    },
                    new() {
                        Id = "/video/search?search=doggystyle",
                        Name = "Doggystyle"
                    },
                    new() {
                        Id = "/video/search?search=letsdoeit",
                        Name = "Letsdoeit"
                    },
                    new() {
                        Id = "/video/search?search=lets+doe+it",
                        Name = "Lets Doe It"
                    },
                    new() {
                        Id = "/video/search?search=her+limit",
                        Name = "Her Limit"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/pornstar/veronica-leal",
                        Name = "Veronica Leal"
                    }
                },
                NbViews = 2593876,
                NbLikes = 9130,
                NbDislikes = 1462,
                Date = new DateTime(2019, 12, 4)
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
                ThumbnailUrl = "https://di.phncdn.com/videos/201712/12/145091652/original/(m=eaAaGwObaaaa)(mh=1_0bvB_2QRESJwUJ)3.jpg",
                SmallThumbnailUrl = "https://ei.phncdn.com/videos/201712/12/145091652/original/(m=eafTGgaaaa)(mh=dKfuDl_TV80fS7Wi)3.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5a2f7e4f9c48a",
                VideoEmbedUrl = "https://www.pornhub.com/embed/ph5a2f7e4f9c48a",
                Duration = new TimeSpan(0, 12, 0),
                Categories = new List<PornIdName> {
                    new() {
                        Id = "/categories/babe",
                        Name = "Babe"
                    },
                    new() {
                        Id = "/video?c=4",
                        Name = "Big Ass"
                    },
                    new() {
                        Id = "/video?c=7",
                        Name = "Big Dick"
                    },
                    new() {
                        Id = "/video?c=8",
                        Name = "Big Tits"
                    },
                    new() {
                        Id = "/video?c=732",
                        Name = "Closed Captions"
                    },
                    new() {
                        Id = "/video?c=17",
                        Name = "Ebony"
                    },
                    new() {
                        Id = "/hd",
                        Name = "HD Porn"
                    },
                    new() {
                        Id = "/video?c=21",
                        Name = "Hardcore"
                    },
                    new() {
                        Id = "/video?c=41",
                        Name = "POV"
                    },
                    new() {
                        Id = "/popularwithwomen",
                        Name = "Popular With Women"
                    },
                    new() {
                        Id = "/categories/pornstar",
                        Name = "Pornstar"
                    },
                    new() {
                        Id = "/video?c=31",
                        Name = "Reality"
                    }
                },
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/video/search?search=butt",
                        Name = "Butt"
                    },
                    new() {
                        Id = "/video/search?search=big+cock",
                        Name = "Big Cock"
                    },
                    new() {
                        Id = "/video/search?search=black",
                        Name = "Black"
                    },
                    new() {
                        Id = "/video/search?search=point+of+view",
                        Name = "Point Of View"
                    },
                    new() {
                        Id = "/video/search?search=tenant",
                        Name = "Tenant"
                    },
                    new() {
                        Id = "/video/search?search=harley+dean",
                        Name = "Harley Dean"
                    },
                    new() {
                        Id = "/video?c=13",
                        Name = "Blowjob"
                    },
                    new() {
                        Id = "/video/search?search=black+babe",
                        Name = "Black Babe"
                    },
                    new() {
                        Id = "/video?c=17",
                        Name = "Ebony"
                    },
                    new() {
                        Id = "/video?c=25",
                        Name = "Interracial"
                    },
                    new() {
                        Id = "/video?c=4",
                        Name = "Big Ass"
                    },
                    new() {
                        Id = "/video?c=41",
                        Name = "Pov"
                    },
                    new() {
                        Id = "/video?c=31",
                        Name = "Reality"
                    },
                    new() {
                        Id = "/video/search?search=facial",
                        Name = "Facial"
                    },
                    new() {
                        Id = "/video?c=16",
                        Name = "Cumshot"
                    },
                    new() {
                        Id = "/video/search?search=propertysex",
                        Name = "Propertysex"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/pornstar/tony-rubino",
                        Name = "Tony Rubino"
                    },
                    new() {
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
            new() {
                Website = PornWebsite.Pornhub,
                SexOrientation = PornSexOrientation.Gay,
                Id = "ph5d432ce7a448c",
                Title = "GAYWIRE - Bar Addison Becomes Draven Navarro's Farm Fuck Boy",
                Channel = new PornIdName {
                    Id = "/channels/gay-wire",
                    Name = "Gay Wire"
                },
                ThumbnailUrl = "https://di.phncdn.com/videos/201908/01/239007621/original/(m=eaAaGwObaaaa)(mh=6-925Q9Wh5OOgwfj)10.jpg",
                SmallThumbnailUrl = "https://ei.phncdn.com/videos/201908/01/239007621/original/(m=eafTGgaaaa)(mh=WYH3Zbs0FETrZK0h)10.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph5d432ce7a448c",
                VideoEmbedUrl = "https://www.pornhub.com/embed/ph5d432ce7a448c",
                Duration = new TimeSpan(0, 4, 5),
                Categories = new List<PornIdName> {
                    new() {
                        Id = "/gay/video?c=252",
                        Name = "Amateur"
                    },
                    new() {
                        Id = "/gay/video?c=58",
                        Name = "Big Dick"
                    },
                    new() {
                        Id = "/gay/video?c=47",
                        Name = "Daddy"
                    },
                    new() {
                        Id = "/gayporn",
                        Name = "Gay"
                    },
                    new() {
                        Id = "/gay/video?c=107",
                        Name = "HD Porn"
                    },
                    new() {
                        Id = "/gay/video?c=70",
                        Name = "Hunks"
                    },
                    new() {
                        Id = "/gay/video?c=51",
                        Name = "Muscle"
                    },
                    new() {
                        Id = "/gay/video?c=60",
                        Name = "Pornstar"
                    },
                    new() {
                        Id = "/gay/video?c=312",
                        Name = "Rough Sex"
                    },
                    new() {
                        Id = "/gay/video?c=49",
                        Name = "Twink (18+)"
                    }
                },
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/gay/video/search?search=gaywire",
                        Name = "Gaywire"
                    },
                    new() {
                        Id = "/gay/video/search?search=pound+his+ass",
                        Name = "Pound His Ass"
                    },
                    new() {
                        Id = "/gayporn",
                        Name = "Gay"
                    },
                    new() {
                        Id = "/gay/video/search?search=gay+anal",
                        Name = "Gay Anal"
                    },
                    new() {
                        Id = "/gay/video/search?search=gay+sex",
                        Name = "Gay Sex"
                    },
                    new() {
                        Id = "/gay/video?c=51",
                        Name = "Muscle"
                    },
                    new() {
                        Id = "/gay/video/search?search=muscular",
                        Name = "Muscular"
                    },
                    new() {
                        Id = "/gay/video/search?search=hunk",
                        Name = "Hunk"
                    },
                    new() {
                        Id = "/gay/video/search?search=ranch",
                        Name = "Ranch"
                    },
                    new() {
                        Id = "/gay/video/search?search=farm",
                        Name = "Farm"
                    },
                    new() {
                        Id = "/gay/video/search?search=bar+addison",
                        Name = "Bar Addison"
                    },
                    new() {
                        Id = "/gay/video/search?search=draven+navarro",
                        Name = "Draven Navarro"
                    },
                    new() {
                        Id = "/gay/video/search?search=outdoors",
                        Name = "Outdoors"
                    },
                    new() {
                        Id = "/gay/video/search?search=day+laborer",
                        Name = "Day Laborer"
                    },
                    new() {
                        Id = "/gay/video/search?search=farmer",
                        Name = "Farmer"
                    },
                    new() {
                        Id = "/gay/video/search?search=overalls",
                        Name = "Overalls"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/pornstar/draven-navarro",
                        Name = "Draven Navarro"
                    }
                },
                NbViews = 134289,
                NbLikes = 509,
                NbDislikes = 162,
                Date = new DateTime(2019, 8, 1)
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
                ThumbnailUrl = "https://di.phncdn.com/videos/202105/19/388272921/original/(m=eaAaGwObaaaa)(mh=FAmlwuMOegqg_ChD)11.jpg",
                SmallThumbnailUrl = "https://ci.phncdn.com/videos/202105/19/388272921/original/(m=eafTGgaaaa)(mh=fVKLwQqYceEaETFL)11.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph60a518bb2da8a",
                VideoEmbedUrl = "https://www.pornhub.com/embed/ph60a518bb2da8a",
                Duration = new TimeSpan(0, 7, 48),
                Categories = new List<PornIdName> {
                    new() {
                        Id = "/gay/video?c=40",
                        Name = "Bareback"
                    },
                    new() {
                        Id = "/gay/video?c=58",
                        Name = "Big Dick"
                    },
                    new() {
                        Id = "/gay/video?c=56",
                        Name = "Blowjob"
                    },
                    new() {
                        Id = "/gayporn",
                        Name = "Gay"
                    },
                    new() {
                        Id = "/gay/video?c=62",
                        Name = "Group"
                    },
                    new() {
                        Id = "/gay/video?c=107",
                        Name = "HD Porn"
                    },
                    new() {
                        Id = "/gay/video?c=332",
                        Name = "Mature"
                    },
                    new() {
                        Id = "/gay/video?c=51",
                        Name = "Muscle"
                    },
                    new() {
                        Id = "/gay/video?c=552",
                        Name = "Tattooed Men"
                    }
                },
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/gay/video/search?search=lucasentertainment",
                        Name = "Gay Lucasentertainment"
                    },
                    new() {
                        Id = "/gay/video/search?search=butthole",
                        Name = "Butthole"
                    },
                    new() {
                        Id = "/gay/video/search?search=cum+in+mouth",
                        Name = "Cum In Mouth"
                    },
                    new() {
                        Id = "/gay/video/search?search=big+dicks",
                        Name = "Gay Big Dicks"
                    },
                    new() {
                        Id = "/gay/video/search?search=big+cocks",
                        Name = "Big Cocks"
                    },
                    new() {
                        Id = "/gay/video/search?search=foursome",
                        Name = "Gay Foursome"
                    },
                    new() {
                        Id = "/gay/video/search?search=assfuck",
                        Name = "Assfuck"
                    },
                    new() {
                        Id = "/gay/video/search?search=big+cock",
                        Name = "Big Cock"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/pornstar/rafael-carreras",
                        Name = "Rafael Carreras"
                    },
                    new() {
                        Id = "/pornstar/joaquin-santana",
                        Name = "Joaquin Santana"
                    }
                },
                NbViews = 92207,
                NbLikes = 260,
                NbDislikes = 30,
                Date = new DateTime(2021, 5, 19)
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
                ThumbnailUrl = "https://di.phncdn.com/videos/202108/07/392562291/thumbs_5/(m=eaAaGwObaaaa)(mh=EwnkTYRPaU2G-s9P)16.jpg",
                SmallThumbnailUrl = "https://di.phncdn.com/videos/202108/07/392562291/thumbs_5/(m=eafTGgaaaa)(mh=zrFKt_bp3k54N8-K)16.jpg",
                PageUrl = "https://www.pornhub.com/view_video.php?viewkey=ph610ecc9a8ca91",
                VideoEmbedUrl = "https://www.pornhub.com/embed/ph610ecc9a8ca91",
                Duration = new TimeSpan(0, 11, 45),
                Categories = new List<PornIdName> {
                    new() {
                        Id = "/gay/video?c=252",
                        Name = "Amateur"
                    },
                    new() {
                        Id = "/gay/video?c=58",
                        Name = "Big Dick"
                    },
                    new() {
                        Id = "/gay/video?c=352",
                        Name = "Cumshot"
                    },
                    new() {
                        Id = "/gay/video?c=47",
                        Name = "Daddy"
                    },
                    new() {
                        Id = "/gay/video?c=46",
                        Name = "Euro"
                    },
                    new() {
                        Id = "/gayporn",
                        Name = "Gay"
                    },
                    new() {
                        Id = "/gay/video?c=107",
                        Name = "HD Porn"
                    },
                    new() {
                        Id = "/gay/video?c=262",
                        Name = "Handjob"
                    },
                    new() {
                        Id = "/gay/video?c=49",
                        Name = "Twink (18+)"
                    },
                    new() {
                        Id = "/gay/video?c=731",
                        Name = "Verified Amateurs"
                    }
                },
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/gay/video/search?search=cum",
                        Name = "Gay Cum"
                    },
                    new() {
                        Id = "/gay/video?c=352",
                        Name = "Cumshot"
                    },
                    new() {
                        Id = "/gay/video/search?search=frotting",
                        Name = "Frotting"
                    },
                    new() {
                        Id = "/gay/video/search?search=frotting+cocks",
                        Name = "Gay Frotting Cocks"
                    },
                    new() {
                        Id = "/gay/video/search?search=two+cocks",
                        Name = "Two Cocks"
                    },
                    new() {
                        Id = "/gay/video/search?search=cock+rubbing+cock",
                        Name = "Cock Rubbing Cock"
                    },
                    new() {
                        Id = "/gay/video/search?search=boy+moaning",
                        Name = "Boy Moaning"
                    },
                    new() {
                        Id = "/gay/video/search?search=femboy",
                        Name = "Femboy"
                    },
                    new() {
                        Id = "/gay/video?c=49",
                        Name = "Gay Twink"
                    },
                    new() {
                        Id = "/gay/video/search?search=amateur+couple",
                        Name = "Amateur Couple"
                    },
                    new() {
                        Id = "/gay/video/search?search=best+friends",
                        Name = "Best Friends"
                    },
                    new() {
                        Id = "/gay/video/search?search=frottage",
                        Name = "Frottage"
                    },
                    new() {
                        Id = "/gay/video/search?search=big+cock",
                        Name = "Big Cock"
                    },
                    new() {
                        Id = "/gay/video/search?search=homemade",
                        Name = "Homemade"
                    },
                    new() {
                        Id = "/gay/video/search?search=cumming",
                        Name = "Cumming"
                    },
                    new() {
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
                    "https://img-hw.xvideos-cdn.com/videos/thumbs169lll/64/5a/cd/645acd983be57e6ca59f9389e13e5a69/645acd983be57e6ca59f9389e13e5a69.7.jpg",
                SmallThumbnailUrl =
                    "https://img-hw.xvideos-cdn.com/videos/thumbs169ll/64/5a/cd/645acd983be57e6ca59f9389e13e5a69/645acd983be57e6ca59f9389e13e5a69.7.jpg",
                PageUrl =
                    "https://www.xvideos.com/video.ioeekbmb9d4/petite_princess_sasha_rose_fingers_her_delicious_pink_and_rides_her_sex_toy",
                VideoEmbedUrl = "https://www.xvideos.com/embedframe/ioeekbmb9d4",
                Duration = new TimeSpan(0, 17, 38),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/tags/1by-day",
                        Name = "1by-day"
                    },
                    new() {
                        Id = "/tags/sasha-rose",
                        Name = "sasha-rose"
                    },
                    new() {
                        Id = "/tags/euro-porn",
                        Name = "euro-porn"
                    },
                    new() {
                        Id = "/tags/orgasm-porn",
                        Name = "orgasm-porn"
                    },
                    new() {
                        Id = "/tags/masturbation-porn",
                        Name = "masturbation-porn"
                    },
                    new() {
                        Id = "/tags/fingering-porn",
                        Name = "fingering-porn"
                    },
                    new() {
                        Id = "/tags/tease-porn",
                        Name = "tease-porn"
                    },
                    new() {
                        Id = "/tags/glamour-porn",
                        Name = "glamour-porn"
                    },
                    new() {
                        Id = "/tags/ddf-porn",
                        Name = "ddf-porn"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/pornstars/sasharoselive1",
                        Name = "Sasha Rose"
                    }
                },
                NbViews = 267041,
                NbLikes = 528,
                NbDislikes = 27,
                Date = new DateTime(2018, 9, 21)
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
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169poster/25/12/97/25129756a8d056392608ce2a33f1cf03/25129756a8d056392608ce2a33f1cf03.4.jpg",
                SmallThumbnailUrl =
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/25/12/97/25129756a8d056392608ce2a33f1cf03/25129756a8d056392608ce2a33f1cf03.4.jpg",
                PageUrl = "https://www.xvideos.com/video.kdttlbff98e/why_is_this_pussy_wet_vol_72",
                VideoEmbedUrl = "https://www.xvideos.com/embedframe/kdttlbff98e",
                Duration = new TimeSpan(0, 17, 43),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/tags/pussy",
                        Name = "pussy"
                    },
                    new() {
                        Id = "/tags/amateur",
                        Name = "amateur"
                    },
                    new() {
                        Id = "/tags/squirt",
                        Name = "squirt"
                    },
                    new() {
                        Id = "/tags/asian",
                        Name = "asian"
                    },
                    new() {
                        Id = "/tags/pee",
                        Name = "pee"
                    },
                    new() {
                        Id = "/tags/japanese",
                        Name = "japanese"
                    },
                    new() {
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
            /*new() {
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
                VideoEmbedUrl = "https://www.xvideos.com/embedframe/64398615",
                Duration = new TimeSpan(0, 0, 20),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/tags/beautiful",
                        Name = "beautiful"
                    },
                    new() {
                        Id = "/tags/beauty",
                        Name = "beauty"
                    },
                    new() {
                        Id = "/tags/big-tits",
                        Name = "big-tits"
                    },
                    new() {
                        Id = "/tags/gostosa",
                        Name = "gostosa"
                    },
                    new() {
                        Id = "/tags/big-boobs",
                        Name = "big-boobs"
                    },
                    new() {
                        Id = "/tags/egirl",
                        Name = "egirl"
                    },
                    new() {
                        Id = "/tags/e-girl",
                        Name = "e-girl"
                    }
                },
                Actors = new List<PornIdName>(),
                NbViews = 0,
                NbLikes = 157,
                NbDislikes = 39,
                Date = new DateTime(2021, 7, 30)
            },*/
            // Fix verified profile tag
            /*new() {
                Website = PornWebsite.XVideos,
                SexOrientation = PornSexOrientation.Straight,
                Id = "khvkpcv18e7",
                Title = "Hot Blonde and a Lucky *** My Free ChatRoom www.siswetlive.com/siswet19",
                Channel = new PornIdName {
                    Id = "/siswet",
                    Name = "Siswet Official"
                },
                ThumbnailUrl =
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169poster/8d/60/f4/8d60f41d9d89d9d7f3777bd0c8c1d37e/8d60f41d9d89d9d7f3777bd0c8c1d37e.3.jpg",
                SmallThumbnailUrl =
                    "https://img-l3.xvideos-cdn.com/videos/thumbs169ll/8d/60/f4/8d60f41d9d89d9d7f3777bd0c8c1d37e/8d60f41d9d89d9d7f3777bd0c8c1d37e.3.jpg",
                PageUrl = "https://www.xvideos.com/video.video51984073/hot_blonde_and_a_lucky_my_free_chatroom_www.siswetlive.com_siswet19",
                VideoEmbedUrl = "https://www.xvideos.com/embedframe/khvkpcv18e7",
                Duration = new TimeSpan(0, 14, 45),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/verified/videos",
                        Name = "verified profile"
                    },
                    new() {
                        Id = "/tags/teen",
                        Name = "teen"
                    },
                    new() {
                        Id = "/tags/fucked",
                        Name = "fucked"
                    },
                    new() {
                        Id = "/tags/doggystyle",
                        Name = "doggystyle"
                    },
                    new() {
                        Id = "/tags/young",
                        Name = "young"
                    },
                    new() {
                        Id = "/tags/doggy",
                        Name = "doggy"
                    },
                    new() {
                        Id = "/tags/siswet",
                        Name = "siswet"
                    },
                    new() {
                        Id = "/tags/siswet19",
                        Name = "siswet19"
                    },
                    new() {
                        Id = "/tags/whitney-wisconsin",
                        Name = "whitney-wisconsin"
                    },
                    new() {
                        Id = "/tags/amy-lynn-lew",
                        Name = "amy-lynn-lew"
                    },
                    new() {
                        Id = "/tags/amber-lynn-lew",
                        Name = "amber-lynn-lew"
                    },
                    new() {
                        Id = "/tags/lynn-lew",
                        Name = "lynn-lew"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/models/amy-lynn-baxter",
                        Name = "Amy Lynn Baxter"
                    }
                },
                NbViews = 198944543,
                NbLikes = 317800,
                NbDislikes = 262800,
                Date = new DateTime(2019, 11, 9)
            },*/
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
                    "https://img-hw.xvideos-cdn.com/videos/thumbs169lll/27/67/d4/2767d489b1eb14d7821e8df57b791a9d/2767d489b1eb14d7821e8df57b791a9d.20.jpg",
                SmallThumbnailUrl =
                    "http://img-hw.xvideos-cdn.com/videos/thumbs169ll/27/67/d4/2767d489b1eb14d7821e8df57b791a9d/2767d489b1eb14d7821e8df57b791a9d.20.jpg",
                PageUrl = "https://www.xvideos.com/video.hlfbumd4167/double_penetrated_gonzo_babe_facialized",
                VideoEmbedUrl = "https://www.xvideos.com/embedframe/hlfbumd4167",
                Duration = new TimeSpan(0, 7, 0),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/tags/facial",
                        Name = "facial"
                    },
                    new() {
                        Id = "/tags/babe",
                        Name = "babe"
                    },
                    new() {
                        Id = "/tags/bikini",
                        Name = "bikini"
                    },
                    new() {
                        Id = "/tags/blowjob",
                        Name = "blowjob"
                    },
                    new() {
                        Id = "/tags/tattoo",
                        Name = "tattoo"
                    },
                    new() {
                        Id = "/tags/smalltits",
                        Name = "smalltits"
                    },
                    new() {
                        Id = "/tags/dp",
                        Name = "dp"
                    },
                    new() {
                        Id = "/tags/doublepenetration",
                        Name = "doublepenetration"
                    },
                    new() {
                        Id = "/tags/gonzo",
                        Name = "gonzo"
                    },
                    new() {
                        Id = "/tags/dicksucking",
                        Name = "dicksucking"
                    },
                    new() {
                        Id = "/tags/roughsex",
                        Name = "roughsex"
                    },
                    new() {
                        Id = "/tags/assfucking",
                        Name = "assfucking"
                    },
                    new() {
                        Id = "/tags/threeway",
                        Name = "threeway"
                    },
                    new() {
                        Id = "/tags/facefucking",
                        Name = "facefucking"
                    },
                    new() {
                        Id = "/tags/chokeplay",
                        Name = "chokeplay"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/pornstars/megan-rain",
                        Name = "Megan Rain"
                    }
                },
                NbViews = 0,
                NbLikes = 922,
                NbDislikes = 363,
                Date = new DateTime(2017, 2, 1)
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
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169poster/e8/c3/b8/e8c3b880587e7e64cc3ace8b81645721/e8c3b880587e7e64cc3ace8b81645721.30.jpg",
                SmallThumbnailUrl =
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/e8/c3/b8/e8c3b880587e7e64cc3ace8b81645721/e8c3b880587e7e64cc3ace8b81645721.30.jpg",
                PageUrl =
                    "https://www.xvideos.com/video.kcfktok9712/_raul_costa_waits_with_his_big_cock_out_for_petite_josephine_jackson_to_finish_her_yoga_-_reality_kings",
                VideoEmbedUrl = "https://www.xvideos.com/embedframe/kcfktok9712",
                Duration = new TimeSpan(0, 11, 11),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/tags/facial",
                        Name = "facial"
                    },
                    new() {
                        Id = "/tags/blowjob",
                        Name = "blowjob"
                    },
                    new() {
                        Id = "/tags/doggystyle",
                        Name = "doggystyle"
                    },
                    new() {
                        Id = "/tags/missionary",
                        Name = "missionary"
                    },
                    new() {
                        Id = "/tags/stretching",
                        Name = "stretching"
                    },
                    new() {
                        Id = "/tags/pussy-eating",
                        Name = "pussy-eating"
                    },
                    new() {
                        Id = "/tags/reverse-cowgirl",
                        Name = "reverse-cowgirl"
                    },
                    new() {
                        Id = "/tags/big-cock",
                        Name = "big-cock"
                    },
                    new() {
                        Id = "/tags/yoga",
                        Name = "yoga"
                    },
                    new() {
                        Id = "/tags/big-boobs",
                        Name = "big-boobs"
                    },
                    new() {
                        Id = "/tags/deephtroat",
                        Name = "deephtroat"
                    },
                    new() {
                        Id = "/tags/titty-fuck",
                        Name = "titty-fuck"
                    },
                    new() {
                        Id = "/tags/big-booty",
                        Name = "big-booty"
                    },
                    new() {
                        Id = "/tags/reality-kings",
                        Name = "reality-kings"
                    },
                    new() {
                        Id = "/tags/hot-milf",
                        Name = "hot-milf"
                    },
                    new() {
                        Id = "/tags/side-fuck",
                        Name = "side-fuck"
                    },
                    new() {
                        Id = "/tags/petite-brunette",
                        Name = "petite-brunette"
                    },
                    new() {
                        Id = "/tags/rk-prime",
                        Name = "rk-prime"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/pornstars/josephine-jackson",
                        Name = "Josephine Jackson"
                    },
                    new() {
                        Id = "/pornstars/raul-costa-1",
                        Name = "Raul Costa"
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
                    "https://img-hw.xvideos-cdn.com/videos/thumbs169poster/5d/00/30/5d003011fae8c3df1c3bb9529c7dbeff/5d003011fae8c3df1c3bb9529c7dbeff.24.jpg",
                SmallThumbnailUrl =
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/5d/00/30/5d003011fae8c3df1c3bb9529c7dbeff/5d003011fae8c3df1c3bb9529c7dbeff.24.jpg",
                PageUrl = "https://www.xvideos.com/video.kcvvlibfd74/fireworks_in_his_ass_for_father_s_day",
                VideoEmbedUrl = "https://www.xvideos.com/embedframe/kcvvlibfd74",
                Duration = new TimeSpan(0, 14, 07),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/tags/t:gay/anal",
                        Name = "anal"
                    },
                    new() {
                        Id = "/tags/t:gay/cum",
                        Name = "cum"
                    },
                    new() {
                        Id = "/tags/t:gay/hardcore",
                        Name = "hardcore"
                    },
                    new() {
                        Id = "/tags/t:gay/blowjob",
                        Name = "blowjob"
                    },
                    new() {
                        Id = "/tags/t:gay/gay",
                        Name = "gay"
                    },
                    new() {
                        Id = "/tags/t:gay/muscle",
                        Name = "muscle"
                    },
                    new() {
                        Id = "/tags/t:gay/twink",
                        Name = "twink"
                    },
                    new() {
                        Id = "/tags/t:gay/bareback",
                        Name = "bareback"
                    },
                    new() {
                        Id = "/tags/t:gay/bear",
                        Name = "bear"
                    },
                    new() {
                        Id = "/tags/t:gay/big-dick",
                        Name = "big-dick"
                    },
                    new() {
                        Id = "/tags/t:gay/huge-cock",
                        Name = "huge-cock"
                    },
                    new() {
                        Id = "/tags/t:gay/step-dad",
                        Name = "step-dad"
                    },
                    new() {
                        Id = "/tags/t:gay/gay-sex",
                        Name = "gay-sex"
                    },
                    new() {
                        Id = "/tags/t:gay/step-brother",
                        Name = "step-brother"
                    },
                    new() {
                        Id = "/tags/t:gay/drake-magnum",
                        Name = "drake-magnum"
                    },
                    new() {
                        Id = "/tags/t:gay/austin-xanders",
                        Name = "austin-xanders"
                    },
                    new() {
                        Id = "/tags/t:gay/alex-killian",
                        Name = "alex-killian"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/pornstars/alexkillian1",
                        Name = "Alex Killian"
                    }
                },
                NbViews = 105551,
                NbLikes = 320,
                NbDislikes = 132,
                Date = new DateTime(2021, 6, 16)
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
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169poster/12/9e/9c/129e9c59afac7c1afc2729e7b916ad6f-1/129e9c59afac7c1afc2729e7b916ad6f.15.jpg",
                SmallThumbnailUrl =
                    "http://img-hw.xvideos-cdn.com/videos/thumbs169ll/12/9e/9c/129e9c59afac7c1afc2729e7b916ad6f/129e9c59afac7c1afc2729e7b916ad6f.15.jpg",
                PageUrl = "https://www.xvideos.com/video.mmecvm318b/gay_orgy_they_re_loving_it_so_much_in_fact_that_they_just_can_t",
                VideoEmbedUrl = "https://www.xvideos.com/embedframe/mmecvm318b",
                Duration = new TimeSpan(0, 5, 33),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/tags/t:gay/gay",
                        Name = "gay"
                    },
                    new() {
                        Id = "/tags/t:gay/twink",
                        Name = "twink"
                    },
                    new() {
                        Id = "/tags/t:gay/twinks",
                        Name = "twinks"
                    },
                    new() {
                        Id = "/tags/t:gay/gaysex",
                        Name = "gaysex"
                    },
                    new() {
                        Id = "/tags/t:gay/gayporn",
                        Name = "gayporn"
                    },
                    new() {
                        Id = "/tags/t:gay/gay-hardcore",
                        Name = "gay-hardcore"
                    },
                    new() {
                        Id = "/tags/t:gay/gay-blowjob",
                        Name = "gay-blowjob"
                    },
                    new() {
                        Id = "/tags/t:gay/gay-anal",
                        Name = "gay-anal"
                    },
                    new() {
                        Id = "/tags/t:gay/",
                        Name = ""
                    },
                    new() {
                        Id = "/tags/t:gay/gay-dudes",
                        Name = "gay-dudes"
                    },
                    new() {
                        Id = "/tags/t:gay/gaydudes",
                        Name = "gaydudes"
                    }
                },
                Actors = new List<PornIdName>(),
                NbViews = 0,
                NbLikes = 1,
                NbDislikes = 0,
                Date = new DateTime(2014, 4, 30)
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
                    "https://img-hw.xvideos-cdn.com/videos/thumbs169poster/f3/b5/11/f3b511b10de81bc6abd730a02b914b42/f3b511b10de81bc6abd730a02b914b42.19.jpg",
                SmallThumbnailUrl =
                    "http://img-hw.xvideos-cdn.com/videos/thumbs169ll/f3/b5/11/f3b511b10de81bc6abd730a02b914b42/f3b511b10de81bc6abd730a02b914b42.19.jpg",
                PageUrl = "https://www.xvideos.com/video.kvhmukd804d/quiet_top_gets_some_sloppy_head",
                VideoEmbedUrl = "https://www.xvideos.com/embedframe/kvhmukd804d",
                Duration = new TimeSpan(0, 11, 29),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/tags/t:gay/cum",
                        Name = "cum"
                    },
                    new() {
                        Id = "/tags/t:gay/hot",
                        Name = "hot"
                    },
                    new() {
                        Id = "/tags/t:gay/sucking",
                        Name = "sucking"
                    },
                    new() {
                        Id = "/tags/t:gay/interracial",
                        Name = "interracial"
                    },
                    new() {
                        Id = "/tags/t:gay/blowjob",
                        Name = "blowjob"
                    },
                    new() {
                        Id = "/tags/t:gay/slut",
                        Name = "slut"
                    },
                    new() {
                        Id = "/tags/t:gay/clothed",
                        Name = "clothed"
                    },
                    new() {
                        Id = "/tags/t:gay/deepthroat",
                        Name = "deepthroat"
                    },
                    new() {
                        Id = "/tags/t:gay/gay",
                        Name = "gay"
                    },
                    new() {
                        Id = "/tags/t:gay/sub",
                        Name = "sub"
                    },
                    new() {
                        Id = "/tags/t:gay/dom",
                        Name = "dom"
                    },
                    new() {
                        Id = "/tags/t:gay/sloppy",
                        Name = "sloppy"
                    },
                    new() {
                        Id = "/tags/t:gay/big-cock",
                        Name = "big-cock"
                    },
                    new() {
                        Id = "/tags/t:gay/big-dick",
                        Name = "big-dick"
                    },
                    new() {
                        Id = "/tags/t:gay/black-cock",
                        Name = "black-cock"
                    },
                    new() {
                        Id = "/tags/t:gay/gay-blowjob",
                        Name = "gay-blowjob"
                    },
                    new() {
                        Id = "/tags/t:gay/gay-porn",
                        Name = "gay-porn"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/amateurs/finn-phillips1",
                        Name = "Finn Phillips"
                    }
                },
                NbViews = 73931,
                NbLikes = 142,
                NbDislikes = 38,
                Date = new DateTime(2020, 12, 14)
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
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169lll/b0/1e/c9/b01ec9383c300cf4bf21ff3745f3f6a3/b01ec9383c300cf4bf21ff3745f3f6a3.16.jpg",
                SmallThumbnailUrl =
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/b0/1e/c9/b01ec9383c300cf4bf21ff3745f3f6a3/b01ec9383c300cf4bf21ff3745f3f6a3.16.jpg",
                PageUrl = "https://www.xvideos.com/video.lfuati5234/johnny_rapids_orgy_cumshot_on_a_boat",
                VideoEmbedUrl = "https://www.xvideos.com/embedframe/lfuati5234",
                Duration = new TimeSpan(0, 5, 59),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/tags/t:gay/anal",
                        Name = "anal"
                    },
                    new() {
                        Id = "/tags/t:gay/cumshot",
                        Name = "cumshot"
                    },
                    new() {
                        Id = "/tags/t:gay/outdoor",
                        Name = "outdoor"
                    },
                    new() {
                        Id = "/tags/t:gay/blowjob",
                        Name = "blowjob"
                    },
                    new() {
                        Id = "/tags/t:gay/masturbation",
                        Name = "masturbation"
                    },
                    new() {
                        Id = "/tags/t:gay/groupsex",
                        Name = "groupsex"
                    },
                    new() {
                        Id = "/tags/t:gay/gay",
                        Name = "gay"
                    },
                    new() {
                        Id = "/tags/t:gay/orgy",
                        Name = "orgy"
                    },
                    new() {
                        Id = "/tags/t:gay/homosexual",
                        Name = "homosexual"
                    },
                    new() {
                        Id = "/tags/t:gay/muscular",
                        Name = "muscular"
                    },
                    new() {
                        Id = "/tags/t:gay/muscular",
                        Name = "muscular"
                    },
                    new() {
                        Id = "/tags/t:gay/hunk",
                        Name = "hunk"
                    },
                    new() {
                        Id = "/tags/t:gay/gaysex",
                        Name = "gaysex"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
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
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169lll/d4/a2/a9/d4a2a9883dd4eb3866afdfcb46457f43/d4a2a9883dd4eb3866afdfcb46457f43.16.jpg",
                SmallThumbnailUrl =
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/d4/a2/a9/d4a2a9883dd4eb3866afdfcb46457f43/d4a2a9883dd4eb3866afdfcb46457f43.16.jpg",
                PageUrl = "https://www.xvideos.com/video.hitfkhm99be/venus_lux_pounds_tyra_scott_s_asshole",
                VideoEmbedUrl = "https://www.xvideos.com/embedframe/hitfkhm99be",
                Duration = new TimeSpan(0, 6, 11),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/tags/t:shemale/anal",
                        Name = "anal"
                    },
                    new() {
                        Id = "/tags/t:shemale/hardcore",
                        Name = "hardcore"
                    },
                    new() {
                        Id = "/tags/t:shemale/blowjob",
                        Name = "blowjob"
                    },
                    new() {
                        Id = "/tags/t:shemale/shaved",
                        Name = "shaved"
                    },
                    new() {
                        Id = "/tags/t:shemale/asian",
                        Name = "asian"
                    },
                    new() {
                        Id = "/tags/t:shemale/shemale",
                        Name = "shemale"
                    },
                    new() {
                        Id = "/tags/t:shemale/transsexual",
                        Name = "transsexual"
                    },
                    new() {
                        Id = "/tags/t:shemale/tgirl",
                        Name = "tgirl"
                    },
                    new() {
                        Id = "/tags/t:shemale/cum-shot",
                        Name = "cum-shot"
                    },
                    new() {
                        Id = "/tags/t:shemale/cum-on-tits",
                        Name = "cum-on-tits"
                    },
                    new() {
                        Id = "/tags/t:shemale/venus-lux",
                        Name = "venus-lux"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/pornstars/tsvenuslux1",
                        Name = "Venus Lux"
                    },
                    new() {
                        Id = "/pornstars/tyra-scott",
                        Name = "Tyra Scott"
                    }
                },
                NbViews = 349157,
                NbLikes = 359,
                NbDislikes = 93,
                Date = new DateTime(2016, 2, 24)
            },
            // With actors
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
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169poster/a2/f5/29/a2f5293dee979267d27c37aa623fac73/a2f5293dee979267d27c37aa623fac73.17.jpg",
                SmallThumbnailUrl =
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/a2/f5/29/a2f5293dee979267d27c37aa623fac73/a2f5293dee979267d27c37aa623fac73.17.jpg",
                PageUrl = "https://www.xvideos.com/video.utipmab84dd/shemale_kate_zoha_sucked_off_by_stepsis",
                VideoEmbedUrl = "https://www.xvideos.com/embedframe/utipmab84dd",
                Duration = new TimeSpan(0, 6, 10),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/tags/t-girl",
                        Name = "t-girl"
                    },
                    new() {
                        Id = "/tags/stepsister",
                        Name = "stepsister"
                    },
                    new() {
                        Id = "/tags/shemale-sex",
                        Name = "shemale-sex"
                    },
                    new() {
                        Id = "/tags/tranny-sex",
                        Name = "tranny-sex"
                    },
                    new() {
                        Id = "/tags/shemale-masturbation",
                        Name = "shemale-masturbation"
                    },
                    new() {
                        Id = "/tags/shemale-blowjob",
                        Name = "shemale-blowjob"
                    },
                    new() {
                        Id = "/tags/shemale-deepthroat",
                        Name = "shemale-deepthroat"
                    },
                    new() {
                        Id = "/tags/handjob-porn",
                        Name = "handjob-porn"
                    },
                    new() {
                        Id = "/tags/shemale-lingerie",
                        Name = "shemale-lingerie"
                    },
                    new() {
                        Id = "/tags/shemale-brunette",
                        Name = "shemale-brunette"
                    },
                    new() {
                        Id = "/tags/ass-licking-porn",
                        Name = "ass-licking-porn"
                    },
                    new() {
                        Id = "/tags/shemale-hardcore",
                        Name = "shemale-hardcore"
                    },
                    new() {
                        Id = "/tags/shemale-fuck-girl",
                        Name = "shemale-fuck-girl"
                    },
                    new() {
                        Id = "/tags/shemale-tranny",
                        Name = "shemale-tranny"
                    },
                    new() {
                        Id = "/tags/shemale-toy",
                        Name = "shemale-toy"
                    },
                    new() {
                        Id = "/tags/shemale-smalltits",
                        Name = "shemale-smalltits"
                    },
                    new() {
                        Id = "/tags/hardcore-shemale",
                        Name = "hardcore-shemale"
                    },
                    new() {
                        Id = "/tags/aften-opal",
                        Name = "aften-opal"
                    },
                    new() {
                        Id = "/tags/super-hot-shemale",
                        Name = "super-hot-shemale"
                    },
                    new() {
                        Id = "/tags/kate-zoha",
                        Name = "kate-zoha"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/models/aften_opal",
                        Name = "Aften Opal"
                    },
                    new() {
                        Id = "/pornstars/kate-zoha",
                        Name = "Kate Zoha"
                    }
                },
                NbViews = 683634,
                NbLikes = 1400,
                NbDislikes = 615,
                Date = new DateTime(2021, 12, 23)
            },
            // No actors
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
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169poster/86/b3/7c/86b37cf8a6ada2e3eeef46277331c8f2/86b37cf8a6ada2e3eeef46277331c8f2.13.jpg",
                SmallThumbnailUrl =
                    "https://cdn77-pic.xvideos-cdn.com/videos/thumbs169ll/86/b3/7c/86b37cf8a6ada2e3eeef46277331c8f2/86b37cf8a6ada2e3eeef46277331c8f2.13.jpg",
                PageUrl =
                    "https://www.xvideos.com/video.kdibikb229c/carioca_da_pica_grossa_comecou_com_camisinha_depois_tirou_pra_sentir_no_pelo",
                VideoEmbedUrl = "https://www.xvideos.com/embedframe/kdibikb229c",
                Duration = new TimeSpan(0, 6, 3),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/tags/t:shemale/porno",
                        Name = "porno"
                    },
                    new() {
                        Id = "/tags/t:shemale/big",
                        Name = "big"
                    },
                    new() {
                        Id = "/tags/t:shemale/shemale",
                        Name = "shemale"
                    },
                    new() {
                        Id = "/tags/t:shemale/big-ass",
                        Name = "big-ass"
                    },
                    new() {
                        Id = "/tags/t:shemale/amateurs",
                        Name = "amateurs"
                    },
                    new() {
                        Id = "/tags/t:shemale/big-tits",
                        Name = "big-tits"
                    },
                    new() {
                        Id = "/tags/t:shemale/bareback",
                        Name = "bareback"
                    },
                    new() {
                        Id = "/tags/t:shemale/big-cock",
                        Name = "big-cock"
                    },
                    new() {
                        Id = "/tags/t:shemale/big-dick",
                        Name = "big-dick"
                    },
                    new() {
                        Id = "/tags/t:shemale/big-boobs",
                        Name = "big-boobs"
                    },
                    new() {
                        Id = "/tags/t:shemale/bbc",
                        Name = "bbc"
                    },
                    new() {
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

    private static IEnumerable<object[]> GetYouPornStraight() {
        List<PornVideo> videos = new List<PornVideo> {
            new() {
                Website = PornWebsite.YouPorn,
                SexOrientation = PornSexOrientation.Straight,
                Id = "14545647",
                Title = "TRUE ANAL Megan Rain gets her butt stuffed",
                Channel = new PornIdName {
                    Id = "/channel/true-anal/",
                    Name = "True Anal"
                },
                ThumbnailUrl = "https://di1.ypncdn.com/m=eaSaaTbWx/201805/02/14545647/original/100.jpg",
                SmallThumbnailUrl = "https://di1.ypncdn.com/m=eah-8f/201805/02/14545647/original/100.jpg",
                PageUrl = "https://www.youporn.com/watch/14545647/true-anal-megan-rain-gets-her-butt-stuffed/",
                VideoEmbedUrl = "https://www.youporn.com/embed/14545647/true-anal-megan-rain-gets-her-butt-stuffed/",
                Duration = new TimeSpan(0, 12, 17),
                Categories = new List<PornIdName> {
                    new() {
                        Id = "/category/anal/",
                        Name = "Anal"
                    },
                    new() {
                        Id = "/category/bigass/",
                        Name = "Big Ass"
                    },
                    new() {
                        Id = "/category/blowjob/",
                        Name = "Blowjob"
                    },
                    new() {
                        Id = "/category/hd/",
                        Name = "HD"
                    }
                },
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/porntags/trueanal/",
                        Name = "trueanal"
                    },
                    new() {
                        Id = "/porntags/anal/",
                        Name = "anal"
                    },
                    new() {
                        Id = "/porntags/big-butt/",
                        Name = "big butt"
                    },
                    new() {
                        Id = "/porntags/close-up/",
                        Name = "close up"
                    },
                    new() {
                        Id = "/porntags/deepthroat/",
                        Name = "deepthroat"
                    },
                    new() {
                        Id = "/porntags/gagging/",
                        Name = "gagging"
                    },
                    new() {
                        Id = "/porntags/gape/",
                        Name = "gape"
                    },
                    new() {
                        Id = "/porntags/gaping/",
                        Name = "gaping"
                    },
                    new() {
                        Id = "/porntags/lingerie/",
                        Name = "lingerie"
                    },
                    new() {
                        Id = "/porntags/messy/",
                        Name = "messy"
                    },
                    new() {
                        Id = "/porntags/oil/",
                        Name = "oil"
                    },
                    new() {
                        Id = "/porntags/sloppy/",
                        Name = "sloppy"
                    },
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/pornstar/megan-rain/",
                        Name = "Megan Rain"
                    },
                    new() {
                        Id = "/pornstar/mike-adriano/",
                        Name = "Mike Adriano"
                    }
                },
                NbViews = 3432887,
                Date = new DateTime(2018, 5, 2)
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
                ThumbnailUrl = "https://di1.ypncdn.com/m=eaSaaTbWx/201701/24/13449035/original/15.jpg",
                SmallThumbnailUrl = "https://di1.ypncdn.com/m=eah-8f/201701/24/13449035/original/15.jpg",
                PageUrl = "https://www.youporn.com/watch/13449035/holed-cute-brunette-aidra-fox-enjoys-an-anal-fuckfest/",
                VideoEmbedUrl = "https://www.youporn.com/embed/13449035/holed-cute-brunette-aidra-fox-enjoys-an-anal-fuckfest/",
                Duration = new TimeSpan(0, 10, 15),
                Categories = new List<PornIdName> {
                    new() {
                        Id = "/category/anal/",
                        Name = "Anal"
                    },
                    new() {
                        Id = "/category/blowjob/",
                        Name = "Blowjob"
                    },
                    new() {
                        Id = "/category/brunette/",
                        Name = "Brunette"
                    },
                    new() {
                        Id = "/category/facials/",
                        Name = "Facials"
                    },
                    new() {
                        Id = "/category/hd/",
                        Name = "HD"
                    }
                },
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/porntags/aidra-fox/",
                        Name = "aidra-fox"
                    },
                    new() {
                        Id = "/porntags/anal/",
                        Name = "anal"
                    },
                    new() {
                        Id = "/porntags/anal-sex/",
                        Name = "anal-sex"
                    },
                    new() {
                        Id = "/porntags/anal-tyos/",
                        Name = "anal-tyos"
                    },
                    new() {
                        Id = "/porntags/facial/",
                        Name = "facial"
                    },
                    new() {
                        Id = "/porntags/porn/",
                        Name = "porn"
                    },
                    new() {
                        Id = "/porntags/sexy/",
                        Name = "sexy"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/pornstar/aidra-fox/",
                        Name = "Aidra Fox"
                    }
                },
                NbViews = 720858,
                Date = new DateTime(2017, 1, 24)
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
                ThumbnailUrl = "https://di1-ph.ypncdn.com/videos/202007/10/331751472/original/(m=eaSaaTbWx)(mh=-X5Ytr96Faw3QJNT)0.jpg",
                SmallThumbnailUrl = "https://di1-ph.ypncdn.com/videos/202007/10/331751472/original/(m=eah-8f)(mh=qWOEJGTyO99bxdFF)0.jpg",
                PageUrl = "https://www.youporn.com/watch/16066894/twistys-amazing-girls-molly-stewart-desiree-dulce-enjoyed-each-other/",
                VideoEmbedUrl =
                    "https://www.youporn.com/embed/16066894/twistys-amazing-girls-molly-stewart-desiree-dulce-enjoyed-each-other/",
                Duration = new TimeSpan(0, 12, 00),
                Categories = new List<PornIdName> {
                    new() {
                        Id = "/category/bigtits/",
                        Name = "Big Tits"
                    },
                    new() {
                        Id = "/category/brunette/",
                        Name = "Brunette"
                    },
                    new() {
                        Id = "/category/hd/",
                        Name = "HD"
                    },
                    new() {
                        Id = "/category/lesbian/",
                        Name = "Lesbian"
                    },
                    new() {
                        Id = "/category/pussy-licking/",
                        Name = "Pussy Licking"
                    },
                    new() {
                        Id = "/category/redhead/",
                        Name = "Redhead"
                    }
                },
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/porntags/big-tits/",
                        Name = "big tits"
                    },
                    new() {
                        Id = "/porntags/fingering/",
                        Name = "fingering"
                    },
                    new() {
                        Id = "/porntags/girl-on-girl/",
                        Name = "girl on girl"
                    },
                    new() {
                        Id = "/porntags/hard-nipples/",
                        Name = "hard nipples"
                    },
                    new() {
                        Id = "/porntags/lesbian/",
                        Name = "lesbian"
                    },
                    new() {
                        Id = "/porntags/licking-vagina/",
                        Name = "licking vagina"
                    },
                    new() {
                        Id = "/porntags/natural-tits/",
                        Name = "natural tits"
                    },
                    new() {
                        Id = "/porntags/shaved-pussy/",
                        Name = "shaved pussy"
                    },
                    new() {
                        Id = "/porntags/twistys/",
                        Name = "twistys"
                    },
                    new() {
                        Id = "/porntags/gog/",
                        Name = "gog"
                    },
                    new() {
                        Id = "/porntags/mgvideos/",
                        Name = "mgvideos"
                    },
                    new() {
                        Id = "/porntags/perfect-body/",
                        Name = "perfect body"
                    },
                    new() {
                        Id = "/porntags/porhub/",
                        Name = "porhub"
                    },
                    new() {
                        Id = "/porntags/pornohub/",
                        Name = "pornohub"
                    }
                },
                Actors = new List<PornIdName>(),
                NbViews = 75896,
                Date = new DateTime(2020, 7, 10)
            },
            new() {
                Website = PornWebsite.YouPorn,
                SexOrientation = PornSexOrientation.Straight,
                Id = "16621610",
                Title = "TRIO AVEC ESCORTE À L'HÔTEL MA FEMME GOÛTE À LA CHATTE POUR LA PREMIÈRE FOIS FFM",
                Channel = new PornIdName {
                    Id = "/uservids/ph-ultimepleasure/",
                    Name = "ultimepleasure"
                },
                ThumbnailUrl = "https://di1-ph.ypncdn.com/videos/202010/28/364664191/original/(m=eaSaaTbWx)(mh=BTu-QPUSDeiElsgj)8.jpg",
                SmallThumbnailUrl = "https://di1-ph.ypncdn.com/videos/202010/28/364664191/original/(m=eah-8f)(mh=wqJ9zzrUPphXIdE4)8.jpg",
                PageUrl =
                    "https://www.youporn.com/watch/16621610/plan-a-trois-avec-escort-dans-hotel-ma-femme-goute-la-chatte-premier-fois-ffm-camera-cache/",
                VideoEmbedUrl =
                    "https://www.youporn.com/embed/16621610/plan-a-trois-avec-escort-dans-hotel-ma-femme-goute-la-chatte-premier-fois-ffm-camera-cache/",
                Duration = new TimeSpan(0, 15, 55),
                Categories = new List<PornIdName> {
                    new() {
                        Id = "/category/european/",
                        Name = "European"
                    },
                    new() {
                        Id = "/category/hd/",
                        Name = "HD"
                    },
                    new() {
                        Id = "/category/milf/",
                        Name = "MILF"
                    },
                    new() {
                        Id = "/category/masturbation/",
                        Name = "Masturbation"
                    },
                    new() {
                        Id = "/category/pussy-licking/",
                        Name = "Pussy Licking"
                    },
                    new() {
                        Id = "/category/rough/",
                        Name = "Rough"
                    },
                    new() {
                        Id = "/category/threesome/",
                        Name = "Threesome"
                    },
                    new() {
                        Id = "/category/verifiedamateurs/",
                        Name = "Verified Amateurs"
                    }
                },
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/porntags/3some/",
                        Name = "3some"
                    },
                    new() {
                        Id = "/porntags/masturbate/",
                        Name = "Masturbate"
                    },
                    new() {
                        Id = "/porntags/rough/",
                        Name = "ROugh"
                    },
                    new() {
                        Id = "/porntags/amateur-threesome/",
                        Name = "amateur threesome"
                    },
                    new() {
                        Id = "/porntags/escort-francaise/",
                        Name = "escort francaise"
                    },
                    new() {
                        Id = "/porntags/escort-girl/",
                        Name = "escort girl"
                    },
                    new() {
                        Id = "/porntags/escort-hotel/",
                        Name = "escort hotel"
                    },
                    new() {
                        Id = "/porntags/ffm-amateur/",
                        Name = "ffm amateur"
                    },
                    new() {
                        Id = "/porntags/ffm-pov/",
                        Name = "ffm pov"
                    },
                    new() {
                        Id = "/porntags/ffm-threesome/",
                        Name = "ffm threesome"
                    },
                    new() {
                        Id = "/porntags/french-ffm/",
                        Name = "french ffm"
                    },
                    new() {
                        Id = "/porntags/real-escort/",
                        Name = "real escort"
                    }
                },
                Actors = new List<PornIdName>(),
                NbViews = 264888,
                Date = new DateTime(2021, 8, 19)
            }
        };
        return videos.Select(i => new object[] { i });
    }

    private static IEnumerable<object[]> GetYouPornGay() {
        List<PornVideo> videos = new List<PornVideo> {
            new() {
                Website = PornWebsite.YouPorn,
                SexOrientation = PornSexOrientation.Gay,
                Id = "16063976",
                Title = "Ashley Ryder Picked Up By 2 Hunks, Gets Dominated & DP'd",
                Channel = new PornIdName {
                    Id = "/gay/channel/falcon-studios/",
                    Name = "Falcon Studios"
                },
                ThumbnailUrl = "https://di1-ph.ypncdn.com/videos/202007/07/330899932/original/(m=eaSaaTbWx)(mh=Lu4oICI2KLl0ruYM)15.jpg",
                SmallThumbnailUrl = "https://di1-ph.ypncdn.com/videos/202007/07/330899932/original/(m=eah-8f)(mh=wqdkPx8phxDMSXzX)15.jpg",
                PageUrl = "https://www.youporn.com/watch/16063976/falconstudios-ashley-ryder-gets-dominated-dpd/",
                VideoEmbedUrl = "https://www.youporn.com/embed/16063976/falconstudios-ashley-ryder-gets-dominated-dpd/",
                Duration = new TimeSpan(0, 7, 43),
                Categories = new List<PornIdName> (),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/gay/porntags/ass-eating/",
                        Name = "ass eating"
                    },
                    new() {
                        Id = "/gay/porntags/ass-fingering/",
                        Name = "ass fingering"
                    },
                    new() {
                        Id = "/gay/porntags/bigcock/",
                        Name = "big cock"
                    },
                    new() {
                        Id = "/gay/porntags/deepthroat/",
                        Name = "deepthroat"
                    },
                    new() {
                        Id = "/gay/porntags/dp/",
                        Name = "dp"
                    },
                    new() {
                        Id = "/gay/porntags/double-blowjob/",
                        Name = "double blowjob"
                    },
                    new() {
                        Id = "/gay/porntags/double-penetration/",
                        Name = "double penetration"
                    },
                    new() {
                        Id = "/gay/porntags/falconstudios/",
                        Name = "falconstudios"
                    },
                    new() {
                        Id = "/gay/porntags/gape/",
                        Name = "gape"
                    },
                    new() {
                        Id = "/gay/porntags/rough/",
                        Name = "rough"
                    },
                    new() {
                        Id = "/gay/porntags/riding-dick/",
                        Name = "riding dick"
                    },
                    new() {
                        Id = "/gay/porntags/threesome/",
                        Name = "threesome"
                    },
                    new() {
                        Id = "/gay/porntags/tattoo/",
                        Name = "tattoo"
                    },
                    new() {
                        Id = "/gay/porntags/dominant-hard-fuck/",
                        Name = "dominant hard fuck"
                    },
                    new() {
                        Id = "/gay/porntags/muscle-hunk/",
                        Name = "muscle hunk"
                    },
                    new() {
                        Id = "/gay/porntags/spit-roast/",
                        Name = "spit roast"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/pornstar/ashley-ryder/",
                        Name = "Ashley Ryder"
                    },
                    new() {
                        Id = "/gay/pornstar/kayden-gray/",
                        Name = "Kayden Gray"
                    },
                    new() {
                        Id = "/gay/pornstar/rocco-steele/",
                        Name = "Rocco Steele"
                    }
                },
                NbViews = 759609,
                Date = new DateTime(2020, 7, 8)
            },
            /*new() {
                Website = PornWebsite.YouPorn,
                SexOrientation = PornSexOrientation.Gay,
                Id = "15787014",
                Title = "FalconStudios Austin Wolf Stacks 2 Jocks And Plows Them Both",
                Channel = new PornIdName {
                    Id = "/gay/channel/falcon-studios/",
                    Name = "Falcon Studios"
                },
                ThumbnailUrl = "https://di1-ph.ypncdn.com/videos/202001/06/274412661/original/(m=eaSaaTbWx)(mh=AdxZNtvVdQyiYrtm)9.jpg",
                SmallThumbnailUrl = "https://di1-ph.ypncdn.com/videos/202001/06/274412661/original/(m=eah-8f)(mh=PuyQWXUywdXpoH5P)9.jpg",
                PageUrl = "https://www.youporn.com/watch/15787014/austin-wolf-stacks-2-jocks-and-plows-them-both-falconstudios/",
                VideoEmbedUrl = "https://www.youporn.com/embed/15787014/austin-wolf-stacks-2-jocks-and-plows-them-both-falconstudios/",
                Duration = new TimeSpan(0, 8, 00),
                Categories = new List<PornIdName> {
                    new() {
                        Id = "/gay/category/bigcock/",
                        Name = "Big Cock"
                    },
                    new() {
                        Id = "/gay/category/jock/",
                        Name = "Jock"
                    }
                },
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/gay/porntags/anal/",
                        Name = "anal"
                    },
                    new() {
                        Id = "/gay/porntags/bigcock/",
                        Name = "big cock"
                    },
                    new() {
                        Id = "/gay/porntags/blowjob/",
                        Name = "blowjob"
                    },
                    new() {
                        Id = "/gay/porntags/bubble-butt/",
                        Name = "bubble butt"
                    },
                    new() {
                        Id = "/gay/porntags/falconstudios/",
                        Name = "falconstudios"
                    },
                    new() {
                        Id = "/gay/porntags/gay-threesome/",
                        Name = "gay threesome"
                    },
                    new() {
                        Id = "/gay/porntags/jocks/",
                        Name = "jocks"
                    },
                    new() {
                        Id = "/gay/porntags/jockstrap/",
                        Name = "jockstrap"
                    },
                    new() {
                        Id = "/gay/porntags/jockstrap-fetish/",
                        Name = "jockstrap fetish"
                    },
                    new() {
                        Id = "/gay/porntags/jockstrap-sniffing/",
                        Name = "jockstrap sniffing"
                    },
                    new() {
                        Id = "/gay/porntags/muscle/",
                        Name = "muscle"
                    },
                    new() {
                        Id = "/gay/porntags/threesome/",
                        Name = "threesome"
                    },
                    new() {
                        Id = "/gay/porntags/twink/",
                        Name = "twink"
                    },
                    new() {
                        Id = "/gay/porntags/voyeur/",
                        Name = "voyeur"
                    }
                },
                Actors = new List<PornIdName> {
                    new() {
                        Id = "/gay/pornstar/devin-franco/",
                        Name = "Devin Franco"
                    }
                },
                NbViews = 764811,
                Date = new DateTime(2020, 1, 8)
            },*/
            new() {
                Website = PornWebsite.YouPorn,
                SexOrientation = PornSexOrientation.Gay,
                Id = "14357193",
                Title = "NextDoorRaw Cheating RAW Style In The Next Room, Sorry!",
                Channel = new PornIdName {
                    Id = "/gay/channel/next-door-raw/",
                    Name = "Next Door Raw"
                },
                ThumbnailUrl = "https://di1.ypncdn.com/m=eaSaaTbWx/201802/08/14357193/original/14.jpg",
                SmallThumbnailUrl = "https://di1.ypncdn.com/m=eah-8f/201802/08/14357193/original/14.jpg",
                PageUrl = "https://www.youporn.com/watch/14357193/nextdoorraw-cheating-raw-style-in-the-next-room-sorry/",
                VideoEmbedUrl = "https://www.youporn.com/embed/14357193/nextdoorraw-cheating-raw-style-in-the-next-room-sorry/",
                Duration = new TimeSpan(0, 10, 32),
                Categories = new List<PornIdName> (),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/gay/porntags/bareback/",
                        Name = "bareback"
                    },
                    new() {
                        Id = "/gay/porntags/next-door-raw/",
                        Name = "Next Door Raw"
                    },
                    new() {
                        Id = "/gay/porntags/athletic/",
                        Name = "athletic"
                    },
                    new() {
                        Id = "/gay/porntags/big-dick/",
                        Name = "big-dick"
                    },
                    new() {
                        Id = "/gay/porntags/cheating/",
                        Name = "cheating"
                    },
                    new() {
                        Id = "/gay/porntags/couple/",
                        Name = "couple"
                    },
                    new() {
                        Id = "/gay/porntags/doggystyle/",
                        Name = "doggystyle"
                    },
                    new() {
                        Id = "/gay/porntags/hardcore/",
                        Name = "hardcore"
                    },
                    new() {
                        Id = "/gay/porntags/hunks/",
                        Name = "hunks"
                    },
                    new() {
                        Id = "/gay/porntags/raw/",
                        Name = "raw"
                    }
                },
                Actors = new List<PornIdName>(),
                NbViews = 154529,
                Date = new DateTime(2018, 2, 8)
            },
            new() {
                Website = PornWebsite.YouPorn,
                SexOrientation = PornSexOrientation.Gay,
                Id = "16391424",
                Title = "Rencontre avec le minet bien monté Snauwflake au parc qui finit avec une baise sans capote",
                Channel = new PornIdName {
                    Id = "/uservids/snauwflake/",
                    Name = "snauwflake"
                },
                ThumbnailUrl = "https://di1-ph.ypncdn.com/videos/202009/06/349439741/original/(m=eaSaaTbWx)(mh=o8g9FlOyVMAMJOiL)0.jpg",
                SmallThumbnailUrl = "https://di1-ph.ypncdn.com/videos/202009/06/349439741/original/(m=eah-8f)(mh=bRHrB7GfBTctEpFn)0.jpg",
                PageUrl =
                    "https://www.youporn.com/watch/16391424/rencontre-avec-le-minet-bien-monte-snauwflake-au-parc-qui-finit-avec-une-baise-sans-capote/",
                VideoEmbedUrl =
                    "https://www.youporn.com/embed/16391424/rencontre-avec-le-minet-bien-monte-snauwflake-au-parc-qui-finit-avec-une-baise-sans-capote/",
                Duration = new TimeSpan(0, 5, 25),
                Categories = new List<PornIdName>(),
                Tags = new List<PornIdName> {
                    new() {
                        Id = "/gay/porntags/bigcock/",
                        Name = "BIg Cock"
                    },
                    new() {
                        Id = "/gay/porntags/cum/",
                        Name = "Cum"
                    },
                    new() {
                        Id = "/gay/porntags/hd/",
                        Name = "HD"
                    },
                    new() {
                        Id = "/gay/porntags/outside/",
                        Name = "Outside"
                    },
                    new() {
                        Id = "/gay/porntags/public/",
                        Name = "Public"
                    },
                    new() {
                        Id = "/gay/porntags/bareback-fuck/",
                        Name = "bareback fuck"
                    },
                    new() {
                        Id = "/gay/porntags/college-boy/",
                        Name = "college boy"
                    },
                    new() {
                        Id = "/gay/porntags/french-twink/",
                        Name = "french twink"
                    },
                    new() {
                        Id = "/gay/porntags/gay-teen/",
                        Name = "gay teen"
                    },
                    new() {
                        Id = "/gay/porntags/huge-uncut-cock/",
                        Name = "huge uncut cock"
                    },
                    new() {
                        Id = "/gay/porntags/hung-bottom/",
                        Name = "hung bottom"
                    },
                    new() {
                        Id = "/gay/porntags/outdoor-fuck/",
                        Name = "outdoor fuck"
                    },
                    new() {
                        Id = "/gay/porntags/park-fuck/",
                        Name = "park fuck"
                    },
                    new() {
                        Id = "/gay/porntags/snauwflake/",
                        Name = "snauwflake"
                    }
                },
                Actors = new List<PornIdName>(),
                NbViews = 84053,
                Date = new DateTime(2021, 3, 8)
            }
        };
        return videos.Select(i => new object[] { i });
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}
