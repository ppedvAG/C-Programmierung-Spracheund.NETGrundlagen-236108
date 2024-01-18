using M013;

namespace M013_Tests
{
	[TestClass]
	public class RechnerTests
	{
		Rechner rechner;

		[TestInitialize]
		public void Start()
		{
			rechner = new Rechner();
		}

		[TestCleanup]
		public void Cleanup()
		{
			rechner = null;
		}

		[TestMethod]
		[TestCategory("Addiere")]
		public void TesteAddiere()
		{
			double ergebnis = rechner.Addiere(3, 8);

			Assert.AreEqual(11, ergebnis);
		}

		[TestMethod]
		[TestCategory("Subtrahiere")]
		public void TesteSubtrahiere()
		{
			double ergebnis = rechner.Subtrahiere(3, 8);

			Assert.AreEqual(-5, ergebnis);
		}
	}
}