using System;
using Machine.Specifications;

namespace OptionStrict.oEmbed.Specs.CreateFromUri
{
    public class when_creating_oembed_request_from_uri
    {
        private Establish context = () =>
                                 {
                                     _uri=new Uri(
                                         "http://www.flickr.com/services/oembed/?url=http%3A//www.flickr.com/photos/bees/2341623661/");
                                 };

        private Because of = () => _request = _uri.GetOEmbedRequest();
        private It request_object_should_parse_api = () => _request.Api.ShouldEqual("http://www.flickr.com/services/oembed/");
        private It request_format_should_be_json = () => _request.Format.ShouldEqual(oEmbedFormat.Json);
        private static Uri _uri;
        private static oEmbedRequest _request;
    }
}