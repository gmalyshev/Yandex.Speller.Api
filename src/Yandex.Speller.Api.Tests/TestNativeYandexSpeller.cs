using Xunit;
using Yandex.Speller.Api.DataContract;
using Yandex.Speller.Api.Native;

namespace Yandex.Speller.Api.Tests
{
	public class TestNativeYandexSpeller
	{
		[Fact]
		public void Test()
		{
			Assert.Equal(1, 1);
		}

		[Fact]
		public void TestRequestСheckText()
		{
			IYandexNativeSpeller speller = YandexNativeSpeller.CreateYandexNativeSpeller();
			SpellResult result = speller.CheckText("synchraphasotron", string.Empty, 0, "plain");
			Assert.Equal(result.Errors.Count, 1);
			Assert.Equal(result.Errors[0].Code, ErrorCode.ErrorUnknownWord);
			Assert.Equal(result.Errors[0].Steer.Count, 1);
		}

		[Fact]
		public void TestRequestCheckTexts()
		{
			IYandexNativeSpeller speller = YandexNativeSpeller.CreateYandexNativeSpeller();
			SpellResult[] result = speller.CheckTexts(new[] {"synchraphasotron", @"дубне"}, string.Empty, 0, "plain");
			Assert.Equal(result.Length, 2);
			Assert.Equal(result[0].Errors.Count, 1);
			Assert.Equal(result[0].Errors[0].Code, ErrorCode.ErrorUnknownWord);
			Assert.Equal(result[0].Errors[0].Steer.Count, 1);

			Assert.Equal(result[1].Errors.Count, 1);
			Assert.Equal(result[1].Errors[0].Code, ErrorCode.ErrorCapitalization);
			Assert.Equal(result[1].Errors[0].Steer.Count, 1);
		}
	}
}