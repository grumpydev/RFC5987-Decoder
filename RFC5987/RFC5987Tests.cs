namespace RFC5987
{
    using Xunit;

    public class RFC5987Tests
    {
        [Fact]
        public void Should_decode_string_with_language_code()
        {
            var input = "iso-8859-1'en'%A3%20rates";

            var result = RFC5987.Decode(input);

            Assert.Equal("£ rates", result);
        }

        [Fact]
        public void Should_decode_string_without_language_code()
        {
            var input = "iso-8859-1''%A3%20rates";

            var result = RFC5987.Decode(input);

            Assert.Equal("£ rates", result);
        }

        [Fact]
        public void Should_handle_utf8()
        {
            var input = "UTF-8''%c2%a3%20and%20%e2%82%ac%20rates";

            var result = RFC5987.Decode(input);

            Assert.Equal("£ and € rates", result);
        }

        [Fact]
        public void Should_decode_utf8_filename()
        {
            var input = "UTF-8''foo-%c3%a4.html";

            var result = RFC5987.Decode(input);

            Assert.Equal("foo-ä.html", result);
        }
    }
}