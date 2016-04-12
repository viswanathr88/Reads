using Epiphany.ViewModel;
using System;
using System.Threading.Tasks;

namespace Epiphany.View.DesignData
{
    public class DesignBaseViewModel : DataViewModel<VoidType>
    {
        public override Task LoadAsync(VoidType parameter)
        {
            throw new NotImplementedException();
        }
    }
}
