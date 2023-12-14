using Core;
using Core.Utils;
using Moq;
using System.Globalization;

namespace Test.Utils
{
    public class FunctionsTest
    {
        [Fact]
        public void ParseDate_StringToDateTime_Valid()
        {
            // Act
            var date = Functions.ParseDate("13-01-2021");

            // Assert
            Assert.Equal(new DateTime(2021, 01, 13), date);
        }

        [Fact]
        public void ParseDate_DateTimeToString_Valid()
        {
            // Act
            var date = Functions.ParseDate(new DateTime(2021, 01, 13));

            // Assert
            Assert.NotNull(date);
            Assert.Equal("13-01-2021", date);
        }

        [Fact]
        public void ErrorMessageTemplate()
        {
            // Act
            var message = Functions.ErrorMessageTemplate(It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.NotEmpty(message);
        }
    }
}
