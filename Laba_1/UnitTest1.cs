using NUnit.Framework;

namespace Laba_1
{
    public class UnitTest1
    {
        Mock[] mocks = new Mock[4];

        [SetUp]
        public void Setup()
        {
            mocks[0] = new Mock();
            mocks[1] = new Mock();
            mocks[2] = new Mock(4);
            mocks[3] = new Mock(4);
        }

        [Test]
        public void Test_Dequeue()
        {
            CustomQueue<MusicTrack> q = mocks[0].customQueue;
            MusicTrack skip = q.Dequeue();
            Assert.AreEqual(5, q.Count);
        }


        [Test]
        public void Test_Enqueue()
        {
            CustomQueue<MusicTrack> q = mocks[1].customQueue;
            MusicTrack musicTrack = new MusicTrack { artist = "PIKA", name = "Ïàòèìåéêåð" };
            q.Enqueue(musicTrack);

            for (int i = 0; i < 6; i++)
            {
                MusicTrack skip = q.Dequeue();
            }

            Assert.AreEqual(musicTrack, q.Dequeue());
        }


        [Test]
        public void Test_Peek()
        {
            CustomQueue<MusicTrack> q = mocks[2].customQueue;
            MusicTrack skip = q.Dequeue();
            Assert.AreEqual("The Killers", q.Dequeue().artist);
        }


        [Test]
        public void Test_Clear()
        {
            CustomQueue<MusicTrack> q = mocks[3].customQueue;
            q.Clear();
            Assert.AreEqual(0, q.Count);
        }
    }
}