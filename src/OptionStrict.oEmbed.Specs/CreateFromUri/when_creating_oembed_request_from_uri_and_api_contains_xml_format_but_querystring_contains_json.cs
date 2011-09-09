using System;
using Machine.Specifications;

namespace OptionStrict.oEmbed.Specs.CreateFromUri
{
    public class when_creating_oembed_request_from_uri_and_api_contains_xml_format_but_querystring_contains_json
    {
        private Establish context = () =>
                                        {
                                            _uri=new Uri(
                                                "http://www.flickr.com/services/oembed.xml?url=http%3A//www.flickr.com/photos/bees/2341623661/&format=json");
                                        };

        private Because of = () => _request = _uri.GetOEmbedRequest();
        private It request_object_should_parse_api = () => _request.Api.ShouldEqual("http://www.flickr.com/services/oembed.xml");
        private It request_object_should_parse_format_as_xml = () => _request.Format.ShouldEqual(oEmbedFormat.Xml);
        private static Uri _uri;
        private static oEmbedRequest _request;
    }
}