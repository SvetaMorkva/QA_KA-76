using System;

namespace Laba_1
{
	public class MusicTrack
	{
		public string artist { get; set; }
		public string name { get; set; }

		public string String()
		{
			return string.Format("Artsit: {0}, track: {1}", artist, name);
		}
	}


	public class Mock
	{
		public CustomQueue<MusicTrack> customQueue { get; }

		public Mock(int n = 6)
		{
			customQueue = new CustomQueue<MusicTrack>();

			if (n == 6)
			{
				customQueue.Enqueue(new MusicTrack { artist = "R.E.M.", name = "Leave" });
				customQueue.Enqueue(new MusicTrack { artist = "Жадан і собаки", name = "Тьолка барабанщика" });
				customQueue.Enqueue(new MusicTrack { artist = "Oxxxymiron", name = "До зимы" });
				customQueue.Enqueue(new MusicTrack { artist = "Rainbow", name = "Gates of Babylon" });
				customQueue.Enqueue(new MusicTrack { artist = "Nick Cave and The Bad Seeds", name = "Let Love In" });
				customQueue.Enqueue(new MusicTrack { artist = "The Rolling Stones", name = "Mother's Little Helper" });
			}
			else
			{
				customQueue.Enqueue(new MusicTrack { artist = "Ylvis", name = "WHAT DOES THE FOX SAY?!" });
				customQueue.Enqueue(new MusicTrack { artist = "The Killers", name = "When You Were Young" });
				customQueue.Enqueue(new MusicTrack { artist = "Моргенштерн", name = "Новый Мерин" });
				customQueue.Enqueue(new MusicTrack { artist = "Motorhead", name = "Ace of Spades" });
			}
		}
	}
}