namespace SimonsVoss.LSM.UnitTest
{
	/// <summary>
	/// Tests for Automapper
	/// </summary>
	public class AutoMapperTest : UnitTestBase
	{
		public AutoMapperTest()
			: base()
		{ }

		/// <summary>
		/// Test automapper mappings
		/// </summary>
		[Fact]
		public void Mapper_AllConfigurations_AssertConfigurationIsValid()
			=> Mapper.ConfigurationProvider.AssertConfigurationIsValid();
	}
}
