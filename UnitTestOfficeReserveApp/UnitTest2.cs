using OfficeReserveApp.MVVM.ViewModels;
using OfficeReserveApp.Converters;
using OfficeReserveApp.MVVM.Models;

namespace UnitTestOfficeReserveApp
{
    public class UnitTest2
    {
        BaseViewModel BaseViewModel = new BaseViewModel();

        [Fact]
        public void CheckIsLoadingWhileActiveProcess()
        {
            BaseViewModel.AddToLoadingque("Process");
            Assert.True(BaseViewModel.IsLoading);
        }

        [Fact]
        public void CheckIsLoadingWhileNonActiveProcess()
        {
            string process = "Process";
            BaseViewModel.AddToLoadingque(process);
            BaseViewModel.RemoveFromLoadingque(process);
            Assert.False(BaseViewModel.IsLoading);
        }


    }
}