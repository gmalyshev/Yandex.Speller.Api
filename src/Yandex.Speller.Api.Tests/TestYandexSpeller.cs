using Xunit;
using Yandex.Speller.Api.DataContract;

namespace Yandex.Speller.Api.Tests
{
	public class TestYandexSpeller
	{
		[Fact]
		public void Test()
		{
			Assert.Equal(1, 1);
		}

		[Fact]
		public void TestRequestCheckText()
		{
			IYandexSpeller speller = new YandexSpeller();
			SpellResult result = speller.CheckText("synchraphasotron", Lang.En, Options.Default, TextFormat.Plain);
			Assert.Equal(result.Errors.Count, 1);
			Assert.Equal(result.Errors[0].Code, ErrorCode.ErrorUnknownWord);
			Assert.Equal(result.Errors[0].Steer.Count, 1);
		}

		[Fact]
		public void TestRequestCheckTexts()
		{
			IYandexSpeller speller = new YandexSpeller();
			SpellResult[] result = speller.CheckTexts(new[] {"synchraphasotron", @"дубне"},	Lang.En | Lang.Ru, Options.Default,
				TextFormat.Plain);
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
