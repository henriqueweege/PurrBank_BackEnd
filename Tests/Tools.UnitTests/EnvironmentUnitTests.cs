using Bank.Tools;
using Tests.Helper.Orderer;

namespace Tools.UnitTests
{
    [TestCaseOrderer(
        ordererTypeName: "Tests.Helper.Orderer.PriorityOrderer",
        ordererAssemblyName: "Tests.Helper")]
    public class EnvironmentUnitTests : IDisposable
    {
        #region Environment Setter

        [Fact, TestPriority(1)]
        public void GivenEnvironmentSetToTest_IsTestEnv_ShouldReturnTrue()
            {
            //arrange
            EnvironmentSetter.SetTestEnvToTrue();
            //act
            //assert
            Assert.True(EnvironmentVerifier.IsTestEnv());

        }

        [Fact, TestPriority(2)]
        public void GivenEnvironmentNOTSetToTest_IsTestEnv_ShouldReturnFalse()
        {
            //arrange
            EnvironmentSetter.SetTestEnvToFalse();

            //act
            //assert
            Assert.False(EnvironmentVerifier.IsTestEnv());

        }

        [Fact, TestPriority(3)]
        public void GivenEnvironmentIsTestEnvSetToNull_IsTestEnv_ShouldReturnFalse()
        {
            //arrange
            EnvironmentSetter.SetTestEnvToNull();

            //act
            //assert
            Assert.False(EnvironmentVerifier.IsTestEnv());

        }

        #endregion

        #region Environment Setter

        [Fact, TestPriority(10)]
        public void GivenCallToSetTestEnvToTrue_IsTestEnv_ShouldBeTrue()
        {
            //arrange
            EnvironmentSetter.SetTestEnvToTrue();
            //act
            //assert
            Assert.True(bool.Parse(Environment.GetEnvironmentVariable("IsTestEnv")));

        }

        [Fact, TestPriority(20)]
        public void GivenCallToSetTestEnvToFalse_IsTestEnv_ShouldBeTrue()
        {
            //arrange
            EnvironmentSetter.SetTestEnvToFalse();
            //act
            //assert
            Assert.False(bool.Parse(Environment.GetEnvironmentVariable("IsTestEnv")));
        }

        [Fact, TestPriority(30)]
        public void GivenCallToSetTestEnvToNull_IsTestEnv_ShouldBeTrue()
        {
            //arrange
            EnvironmentSetter.SetTestEnvToNull();
            //act
            //assert
            Assert.Null(Environment.GetEnvironmentVariable("IsTestEnv"));
        }

        #endregion


        public void Dispose()
        {
            EnvironmentSetter.SetTestEnvToNull();
        }
    }
}
