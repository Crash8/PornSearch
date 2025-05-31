using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;
using Newtonsoft.Json;

namespace PornSearch
{
    internal class XVideosSearchActorParser : IPornSearchActorParser
    {
        private readonly XVideosJsonSearchActor _content;

        public XVideosSearchActorParser(IDocument document) {
            _content = JsonConvert.DeserializeObject<XVideosJsonSearchActor>(document.Source.Text);
        }

        public bool IsAvailableContent() {
            return _content.is_model;
        }

        public bool IsAvailablePagination() {
            return _content.nb_videos > _content.nb_per_page;
        }

        public bool IsAvailableNextButton() {
            return _content.current_page + 1 > Math.Ceiling(_content.nb_videos * 1.0 / _content.nb_per_page);
        }

        public int? GetCurrentPageNumber() {
            return _content.current_page + 1;
        }

        public IEnumerable<IPornVideoThumbParser> GetVideoThumbs() {
            return _content.videos.Select(video => new XVideosVideoActorThumbParser(video));
        }
    }
}

internal class XVideosJsonSearchActor
{
    public int nb_videos { get; set; }
    public int nb_per_page { get; set; }
    public int current_page { get; set; }
    public List<XVideosJsonSearchActorVideos> videos { get; set; }
    public bool is_model { get; set; }
}

internal class XVideosJsonSearchActorVideos
{
    public string eid { get; set; }
    public string ip { get; set; }
    public string tf { get; set; }
    public string pn { get; set; }
    public string pu { get; set; }
}