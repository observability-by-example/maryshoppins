using MaryShoppins.Web.Extensions;
using Xunit;

namespace MaryShoppins.UnitTests.Web.Extensions.CacheHelpersTests
{
    public class GenerateTypesCacheKey
    {
        [Fact]
        public void ReturnsTypesCacheKey()
        {
            var result = CacheHelpers.GenerateTypesCacheKey();

            Assert.Equal("types", result);
        }
    }
}
