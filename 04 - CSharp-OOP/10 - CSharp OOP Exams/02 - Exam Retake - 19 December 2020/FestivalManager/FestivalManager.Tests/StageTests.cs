// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void testPerformerThrows()
	    {
			var s = new Stage();
			Assert.Throws<ArgumentNullException>(()=> s.AddPerformer(null));
		}

		//da
		[Test]
		public void testPerformerAgeThrows()
		{
			var s = new Stage();
			Assert.Throws<ArgumentException>(() 
				=> s.AddPerformer(new Performer("alp", "aaa", 16)));
		}

		//da
		[Test]
		public void performerValid()
		{
			var s = new Stage();
			s.AddPerformer(new Performer("alp", "aaa", 888));
			Assert.AreEqual(1, s.Performers.Count);
		}

		[Test]
		public void addnullSongThrows()
		{
			var s = new Stage();
			Assert.Throws<ArgumentNullException>(() => s.AddSong(null));
		}

		[Test]
		public void addnullSongThtheprefomernrows()
		{
			var s = new Stage();
			var p = new Performer("alp", "aa", 22);
			s.AddPerformer(p);
			var sibg = new Song("asd", new TimeSpan(0, 0, 5, 0, 0));
			s.AddSong(sibg);
			var e = s.AddSongToPerformer("asd", "alp aa");

			Assert.AreEqual(e, "asd (05:00) will be performed by alp aa");

		}

		[Test]
		public void addnullSongTaahrows()
		{
			var s = new Stage();
			Assert.AreEqual("0 performers played 0 songs", s.Play());
		}

		//[Test]
		//public void addinvalidsongtovalidperf()
		//{
		//	var s = new Stage();
		//	var song = new Song("1111", new TimeSpan(0, 0, 5, 0, 0));

		//	s.AddSong(song);
		//	var p = new Performer("alp aa", "aaa", 26);
		//	s.AddSongToPerformer("1111", "alp aa");

		//	Assert.Throws<ArgumentNullException>(() => s.AddSong(null));
		//}

		[Test]
		public void addvalidsongworksSonginvalid()
		{
			var s = new Stage();
			Assert.Throws<ArgumentException>(() => s.AddSong(new Song("aa", new TimeSpan(0, 0, 0, 0, 0))));
		}


	}
}